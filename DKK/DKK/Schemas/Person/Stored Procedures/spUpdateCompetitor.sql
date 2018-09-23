CREATE PROCEDURE [Person].[spUpdateCompetitor]
	--Required identifiers
	@CompetitorId INT,
	@ParentId INT = NULL,
	@PersonId INT,

	--Competitor
	@DateOfBirth DATE = NULL,
	@Age INT = NULL,
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
	@IsKata BIT = NULL,
	@IsWeaponKata BIT = NULL,
	@IsSemiKnockdown BIT = NULL,
	@IsKnockdown BIT = NULL,

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

			--TODO: re-write with dynamic SQL so you can only update a column if a non-NULL value is passed in.

			--Update Parent
			UPDATE p
			SET p.FirstName = @ParentFirstName
				,p.LastName = @ParentLastName
				,p.EmailAddress = @ParentEmailAddress
			FROM Person.Person p
			WHERE p.PersonId = @ParentId;

			--Update Person
			UPDATE p
			SET 
				p.AppartmentCode = @AppartmentCode
				,p.City = @City
				,p.Country = @Country
				,p.DisplayName = @DisplayName
				,p.EmailAddress = @EmailAddress
				,p.FirstName = @FirstName
				,p.Gender = @Gender
				,p.IsInstructor = @IsInstructor
				,p.LastName = @LastName
				,p.PhoneNumber = @PhoneNumber
				,p.PostalCode = @PostalCode
				,p.StateProvince = @StateProvince
				,p.StreetAddress1 = @StreetAddress1
				,p.StreetAddress2 = @StreetAddress2
				,p.TitleId = @TitleId
			FROM Person.Person p
			WHERE p.PersonId = @PersonId

			--Update Competitor
			UPDATE c
			SET
				c.DateOfBirth = @DateOfBirth
				,c.Age = @Age
				,c.DojoId = @DojoId
				,c.OtherDojoName = @OtherDojoName
				,c.Height = @Height
				,c.IsSpecialConsideration = @IsSpecialConsideration
				,c.ConsiderationDescription = @ConsiderationDescription
				,c.RankId = @RankId
				,c.Weight = @Weight
				,c.IsKata = @IsKata
				,c.IsWeaponKata = @IsWeaponKata
				,c.IsSemiKnockdown = @IsSemiKnockdown
				,c.IsKnockdown = @IsKnockdown
			FROM Person.Competitor c
			WHERE c.CompetitorId = @CompetitorId

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