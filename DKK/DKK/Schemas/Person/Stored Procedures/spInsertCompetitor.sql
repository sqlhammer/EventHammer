CREATE PROCEDURE [Person].[spInsertCompetitor]
	--Competitor
	@DateOfBirth DATE = NULL,
	@DojoId INT = NULL,
	@EventId INT = NULL,
	@Height DECIMAL = NULL,
	@IsSpecialConsideration BIT = NULL,
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

			DECLARE @PersonId TABLE (Id INT);
			DECLARE @ParentId TABLE (Id INT);

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
			INSERT INTO Person.Competitor
			(
				PersonId
				,DateOfBirth
				,Age
				,Weight
				,Height
				,RankId
				,DojoId
				,ParentId
				,IsMinor
				,IsSpecialConsideration
				,EventId
			)
			VALUES
			(
				(SELECT TOP 1 Id FROM @PersonId),
				@DateOfBirth,
				DATEDIFF(YEAR,@DateOfBirth,GETDATE()),
				@Weight,
				@Height,
				@RankId,
				@DojoId,
				(SELECT TOP 1 Id FROM @ParentId),
				CASE
					WHEN DATEDIFF(YEAR,@DateOfBirth,GETDATE()) < 18 THEN 1
					ELSE 0
				END,
				@IsSpecialConsideration,
				@EventId
			) 

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
END;
GO