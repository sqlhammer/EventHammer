CREATE PROCEDURE [Stage].[spLoadRegistration]
AS
	SET NOCOUNT ON
	SET XACT_ABORT ON

	BEGIN TRANSACTION
	
		BEGIN TRY
			--Person inserts
			INSERT INTO Person.Person ( FirstName, LastName, DisplayName
				, IsInstructor, Gender, PhoneNumber, Email, StreetAddress1, StreetAddress2
				, AppartmentCode, City, StateProvidence, PostalCode, Country )
			SELECT r.FirstName
				  ,r.LastName
				  ,r.LastName + ', ' + r.FirstName
				  ,0
				  ,r.Gender
				  ,r.PhoneNumber
				  ,r.EmailAddress
				  ,r.Street1
				  ,r.Street2
				  ,r.AppartmentCode
				  ,r.City
				  ,r.StateProvince
				  ,r.PostalCode
				  ,r.Country
			FROM Stage.[Registration] r
			LEFT JOIN Person.Person p ON p.FirstName = r.FirstName
										AND p.LastName = r.LastName
										AND p.Email = r.EmailAddress
			WHERE p.PersonId IS NULL;

			--Parent inserts
			INSERT INTO Person.Person ( FirstName, LastName, DisplayName, IsInstructor, Email )
			SELECT r.ParentFirstName
				  ,r.ParentLastName
				  ,r.ParentLastName + ', ' + r.ParentFirstName
				  ,0
				  ,r.ParentEmailAddress
			FROM Stage.[Registration] r
			LEFT JOIN Person.Person p ON p.FirstName = r.ParentFirstName
										AND p.LastName = r.ParentLastName
										AND p.Email = r.ParentEmailAddress
			WHERE p.PersonId IS NULL;

			--Competitor inserts
			INSERT INTO [Person].[Competitor]
			(PersonId, DateOfBirth, Age, [Weight], RankId, DojoId, ParentId, IsMinor, IsSpecialConsideration)
			SELECT p.PersonId
				, r.[DateOfBirth]
				, r.[Age]
				, r.[Weight]
				, (SELECT TOP 1 RankId FROM [Event].[Rank] WHERE [Level] = r.[Rank])
				, (
					SELECT TOP 1 DojoId 
					FROM Facility.Dojo d 
					INNER JOIN Facility.Facility f ON d.FacilityId = f.FacilityId
					INNER JOIN Facility.MartialArtType m ON d.MartialArtTypeId = m.MartialArtTypeId
					WHERE f.[Name] = r.[DojoName]
						AND m.[Name] = r.[MartialArtName]
				)
				, (
					SELECT TOP 1 p.PersonId
					FROM Person.Person p
					WHERE p.FirstName = r.ParentFirstName
						AND p.LastName = r.ParentLastName
						AND p.Email = r.ParentEmailAddress
				)
				, r.[IsMinor]
				, r.IsSpecialConsideration
			FROM Stage.[Registration] r
			INNER JOIN Person.Person p ON p.FirstName = r.FirstName
										AND p.LastName = r.LastName
										AND p.Email = r.EmailAddress
			LEFT JOIN Person.Competitor c ON c.PersonId = p.PersonId
			WHERE c.CompetitorId IS NULL

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

		END CATCH

	WHILE @@TRANCOUNT > 0
	BEGIN
		COMMIT
	END
GO
