CREATE PROCEDURE [Person].[spInsertCompetitor]
	--Competitor
	@Age INT = NULL,
	@DateOfBirth DATE = NULL,
	@DojoId INT = NULL,
	@OtherDojoName VARCHAR(120) = NULL,
	@EventId INT = NULL,
	@Height DECIMAL = NULL,
	@IsSpecialConsideration BIT = NULL,
	@ConsiderationDescription VARCHAR(8000) = NULL,
	@RankId INT = NULL,
	@Weight DECIMAL = NULL,
	@AppartmentCode NVARCHAR(10) = NULL,
	@City NVARCHAR(30) = NULL,
	@Country NVARCHAR(30) = NULL,
	@DisplayName NVARCHAR(60) = NULL,
	@EmailAddress NVARCHAR(255) = NULL,
	@FirstName NVARCHAR(60) = NULL,
	@Gender CHAR = NULL,
	@IsInstructor BIT = NULL,
	@LastName NVARCHAR(60) = NULL,
	@OtherInstructorName VARCHAR(120) = NULL,

	--Person
	@PhoneNumber NVARCHAR(15) = NULL,
	@PostalCode NVARCHAR(10) = NULL,
	@StateProvince NVARCHAR(30) = NULL,
	@StreetAddress1 NVARCHAR(255) = NULL,
	@StreetAddress2 NVARCHAR(255) = NULL,
	@TitleId INT = NULL,

	--Parent
	@ParentFirstName NVARCHAR(60) = NULL,
	@ParentLastName NVARCHAR(60) = NULL,
	@ParentEmailAddress NVARCHAR(255) = NULL
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;
	
	BEGIN TRY

		BEGIN TRANSACTION;

			IF EXISTS (	SELECT TOP 1 1 
						FROM Person.Person 
						WHERE FirstName = @FirstName 
							AND LastName = @LastName 
							AND EmailAddress = @EmailAddress)
			BEGIN
				DECLARE @msg VARCHAR(1000)
				SELECT @msg = 'This person already exists and cannot be duplicated. FirstName = ' + @FirstName + ', LastName = ' + @LastName + ', EmailAddress = ' + @EmailAddress
				;THROW 50001, @msg, 1;
			END

			DECLARE @PersonId TABLE (Id INT);
			DECLARE @ParentId TABLE (Id INT);

			IF @ParentFirstName IS NOT NULL AND @ParentFirstName <> ''
				AND @ParentLastName IS NOT NULL AND @ParentLastName <> ''
				AND @ParentEmailAddress IS NOT NULL AND @ParentEmailAddress <> ''
			BEGIN
				IF EXISTS (	SELECT TOP 1 1 
							FROM Person.Person 
							WHERE FirstName = @ParentFirstName 
								AND LastName = @ParentLastName 
								AND EmailAddress = @ParentEmailAddress)
				BEGIN
					INSERT INTO @ParentId ( Id )
					SELECT [PersonId]
					FROM Person.Person p
					WHERE p.FirstName = @ParentFirstName
						AND p.LastName = @ParentLastName
						AND p.EmailAddress = @ParentEmailAddress
				END
				ELSE
				BEGIN
					--Insert Parent
					INSERT INTO Person.Person
					(
						FirstName
						,LastName
						,DisplayName				
						,EmailAddress
					)
					OUTPUT Inserted.PersonId INTO @ParentId
					VALUES
					(
						@ParentFirstName,
						@ParentLastName,
						@ParentLastName + ', ' + @ParentFirstName,
						@ParentEmailAddress
					) 
				END
			END
						
			--Insert Person
			INSERT INTO Person.Person
			(
				FirstName
				,LastName
				,DisplayName
				,TitleId
				,IsInstructor
				,Gender
				,PhoneNumber
				,EmailAddress
				,StreetAddress1
				,StreetAddress2
				,AppartmentCode
				,City
				,StateProvince
				,PostalCode
				,Country
			)
			OUTPUT Inserted.PersonId INTO @PersonId
			VALUES
			(
				@FirstName,
				@LastName,
				@LastName + ', ' + @FirstName,
				@TitleId,
				@IsInstructor,
				@Gender,
				@PhoneNumber,
				@EmailAddress,
				@StreetAddress1,
				@StreetAddress2,
				@AppartmentCode,
				@City,
				@StateProvince,
				@PostalCode,
				@Country
			)

			--Insert Competitor
			DECLARE @returnTable TABLE (competitorid INT NOT NULL);
			DECLARE @competitorid INT = 0;

			INSERT INTO Person.Competitor
			(
				PersonId
				,DateOfBirth
				,Age
				,Weight
				,Height
				,RankId
				,DojoId
				,OtherDojoName
				,ParentId
				,IsMinor
				,IsSpecialConsideration
				,ConsiderationDescription
				,EventId
				,OtherInstructorName
			)
			OUTPUT inserted.CompetitorId INTO @returnTable
			VALUES
			(
				(SELECT TOP 1 Id FROM @PersonId),
				@DateOfBirth,
				@Age,
				@Weight,
				@Height,
				@RankId,
				@DojoId,
				@OtherDojoName,
				(SELECT TOP 1 Id FROM @ParentId),
				CASE
					WHEN @Age < 18 THEN 1
					ELSE 0
				END,
				@IsSpecialConsideration,
				@ConsiderationDescription,
				@EventId,
				@OtherInstructorName
			) 

			SELECT TOP 1 @competitorid = competitorid FROM @returnTable;
			
	END TRY
	BEGIN CATCH
			
		SELECT ERROR_NUMBER() AS ErrorNumber
				,ERROR_SEVERITY() AS ErrorSeverity
				,ERROR_STATE() AS ErrorState
				,ERROR_PROCEDURE() AS ErrorProcedure
				,ERROR_LINE() AS ErrorLine
				,ERROR_MESSAGE() AS ErrorMessage;

		IF @@TRANCOUNT > 0  
			ROLLBACK TRANSACTION;  

		THROW;

	END CATCH;

	WHILE @@TRANCOUNT > 0
		COMMIT;

	RETURN @competitorid;
END;
GO