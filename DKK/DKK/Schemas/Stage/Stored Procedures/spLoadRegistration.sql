CREATE PROCEDURE [Stage].[spLoadRegistration]
	@EventId INT
AS
BEGIN
	SET NOCOUNT ON
	SET XACT_ABORT ON

	BEGIN TRANSACTION
	
		BEGIN TRY

			SELECT *
			INTO #entries
			FROM 
			(
				SELECT DISTINCT entry_id
				FROM Stage.CalderaFormEntry
			) c
			CROSS APPLY 
			(
				SELECT 
				(SELECT TOP 1 value FROM [Stage].[CalderaFormEntry] WHERE slug = 'age' AND entry_id = c.entry_id) age
				,(SELECT TOP 1 value FROM [Stage].[CalderaFormEntry] WHERE slug = 'city' AND entry_id = c.entry_id) city
				-- ,(SELECT TOP 1 
				--     (
				--         SELECT TOP 1 REPLACE(REPLACE(REPLACE(value,'"',''),'{',''),'}','')  
				--         FROM STRING_SPLIT(c1.value, ':')  
				--         WHERE value NOT LIKE '%opt%'
				--     ) value FROM [Stage].[CalderaFormEntry] c1 WHERE slug = 'country' AND entry_id = c.entry_id
				-- ) country
				,(
					SELECT TOP 1 StringValue 
					FROM [Stage].[CalderaFormEntry] 
					CROSS APPLY Stage.parseJSON(value)
					WHERE slug = 'country' 
						AND entry_id = c.entry_id 
						AND StringValue <> ''
						AND StringValue NOT LIKE '%opt%'
				) country
				,(SELECT TOP 1 value FROM [Stage].[CalderaFormEntry] WHERE slug = 'email_address' AND entry_id = c.entry_id) email_address
				,(SELECT TOP 1 value FROM [Stage].[CalderaFormEntry] WHERE slug = 'first_name' AND entry_id = c.entry_id) first_name
				,(SELECT TOP 1 value FROM [Stage].[CalderaFormEntry] WHERE slug = 'gender' AND entry_id = c.entry_id) gender
				,(SELECT TOP 1 value FROM [Stage].[CalderaFormEntry] WHERE slug = 'height_inches' AND entry_id = c.entry_id) height_inches
				,(SELECT TOP 1 value FROM [Stage].[CalderaFormEntry] WHERE slug = 'instructor_name' AND entry_id = c.entry_id) instructor_name
				,(SELECT TOP 1 value FROM [Stage].[CalderaFormEntry] WHERE slug = 'last_name' AND entry_id = c.entry_id) last_name
				,(SELECT TOP 1 value FROM [Stage].[CalderaFormEntry] WHERE slug = 'parent_first_name' AND entry_id = c.entry_id) parent_first_name
				,(SELECT TOP 1 value FROM [Stage].[CalderaFormEntry] WHERE slug = 'parent_last_name' AND entry_id = c.entry_id) parent_last_name
				,(SELECT TOP 1 value FROM [Stage].[CalderaFormEntry] WHERE slug = 'participating_events' AND entry_id = c.entry_id) participating_events
				,(SELECT TOP 1 value FROM [Stage].[CalderaFormEntry] WHERE slug = 'rank_kyu' AND entry_id = c.entry_id) rank_kyu
				,(SELECT TOP 1 value FROM [Stage].[CalderaFormEntry] WHERE slug = 'school_name' AND entry_id = c.entry_id) school_name
				,(SELECT TOP 1 value FROM [Stage].[CalderaFormEntry] WHERE slug = 'special_considerations' AND entry_id = c.entry_id) special_considerations
				,(SELECT TOP 1 value FROM [Stage].[CalderaFormEntry] WHERE slug = 'state_province' AND entry_id = c.entry_id) state_province
				,(SELECT TOP 1 value FROM [Stage].[CalderaFormEntry] WHERE slug = 'street_address' AND entry_id = c.entry_id) street_address
				,(SELECT TOP 1 value FROM [Stage].[CalderaFormEntry] WHERE slug = 'weight_pounds' AND entry_id = c.entry_id) weight_pounds
				,(SELECT TOP 1 value FROM [Stage].[CalderaFormEntry] WHERE slug = 'zip_code' AND entry_id = c.entry_id) zip_code
				,(
					SELECT 
						CAST(
							CASE 
								WHEN value IS NOT NULL AND value <> '' 
									THEN 1 
								ELSE 0 
							END 
							AS BIT
							) value 
						FROM [Stage].[CalderaFormEntry] 
						WHERE slug = 'special_considerations' 
							AND entry_id = c.entry_id
				) special_considerations
			) pvt

			--Person updates
			UPDATE p
			SET p.DisplayName = r.last_name + ', ' + r.first_name
				,p.Gender = r.gender
				--,p.PhoneNumber = r.PhoneNumber
				,p.StreetAddress1 = r.street_address
				--,p.StreetAddress2 = r.Street2
				--,p.AppartmentCode = r.AppartmentCode
				,p.City = r.city
				,p.StateProvince = r.state_province
				,p.PostalCode = r.zip_code
				,p.Country = r.country
			FROM #entries r
			INNER JOIN Person.Person p ON p.FirstName = r.first_name
										AND p.LastName = r.last_name
										AND p.EmailAddress = r.email_address

			--Competitor updates
			UPDATE c
			SET c.PersonId = p.PersonId
				--,c.DateOfBirth = r.[DateOfBirth]
				,c.Age = r.age
				,c.[Weight] = r.weight_pounds
				,c.Height = r.height_inches
				,c.RankId = (SELECT TOP 1 RankId FROM [Event].[Rank] WHERE [Level] = r.[Rank]) --TODO: Translate kyu
				,c.DojoId = (
					SELECT TOP 1 DojoId 
					FROM Facility.Dojo d 
					INNER JOIN Facility.Facility f ON d.FacilityId = f.FacilityId
					INNER JOIN Facility.MartialArtType m ON d.MartialArtTypeId = m.MartialArtTypeId
					WHERE f.[Name] = r.school_name
						--AND m.[Name] = r.[MartialArtName]
				)
				,c.ParentId = (
					SELECT TOP 1 p.PersonId
					FROM Person.Person p
					WHERE p.FirstName = r.parent_first_name
						AND p.LastName = r.parent_last_name
						AND p.EmailAddress = r.ParentEmailAddress --TODO: Missing field from form
				)
				,c.IsMinor = CASE WHEN r.age < 18 THEN 1 ELSE 0 END
				,c.IsSpecialConsideration = r.special_considerations
				--, c.IsKata = r.IsKata 
				--, c.IsWeaponKata = r.IsWeaponKata
				--, c.IsSemiKnockdown = r.IsSemiKnockdown	  
				--, c.IsKnockdown = r.IsKnockdown
			FROM #entries r
			INNER JOIN Person.Person p ON p.FirstName = r.first_name
										AND p.LastName = r.last_name
										AND p.EmailAddress = r.email_address
			INNER JOIN Person.Competitor c ON c.PersonId = p.PersonId
											AND c.EventId = @EventId

			--TODO: make another update statement to populate a pivoted event set

			--Person inserts
			;WITH NewPersons AS
			(
				SELECT ROW_NUMBER() OVER (PARTITION BY r.first_name, r.last_name, r.email_address ORDER BY (SELECT NULL)) rownum
					  ,r.first_name
					  ,r.last_name
					  ,r.last_name + ', ' + r.first_name DisplayName
					  ,0 IsInstructor
					  ,r.gender
					  --,r.PhoneNumber
					  ,r.email_address
					  ,r.street_address
					  --,r.Street2
					  --,r.AppartmentCode
					  ,r.city
					  ,r.state_province
					  ,r.zip_code
					  ,r.country
				FROM #entries r
				LEFT JOIN Person.Person p ON p.FirstName = r.first_name
											AND p.LastName = r.last_name
											AND p.EmailAddress = r.email_address
				WHERE p.PersonId IS NULL
			)
			INSERT INTO Person.Person ( FirstName, LastName, DisplayName
				, IsInstructor, Gender, PhoneNumber, EmailAddress, StreetAddress1, StreetAddress2
				, AppartmentCode, City, StateProvince, PostalCode, Country )
			SELECT np.first_name
				  ,np.last_name
				  ,np.DisplayName
				  ,np.IsInstructor
				  ,np.Gender
				  --,np.PhoneNumber
				  ,np.email_address
				  ,np.street_address
				  --,np.Street2
				  --,np.AppartmentCode
				  ,np.city
				  ,np.street_address
				  ,np.zip_code
				  ,np.country
			FROM NewPersons np
			WHERE np.rownum = 1

			--Parent inserts
			;WITH NewPersons AS
			(
				SELECT ROW_NUMBER() OVER (PARTITION BY r.parent_first_name, r.parent_last_name, r.ParentEmailAddress ORDER BY (SELECT NULL)) rownum
					  ,r.parent_first_name
					  ,r.parent_last_name
					  ,r.parent_last_name + ', ' + r.parent_first_name DisplayName
					  ,0 IsInstructor
					  ,r.ParentEmailAddress 
				FROM #entries r
				LEFT JOIN Person.Person p ON p.FirstName = r.parent_first_name
											AND p.LastName = r.parent_last_name
											AND p.EmailAddress = r.ParentEmailAddress --TODO: missing parent email field
				WHERE p.PersonId IS NULL
			)
			INSERT INTO Person.Person ( FirstName, LastName, DisplayName, IsInstructor, EmailAddress )
			SELECT np.parent_first_name
				  ,np.parent_last_name
				  ,np.DisplayName
				  ,np.IsInstructor
				  ,np.ParentEmailAddress
			FROM NewPersons np
			WHERE np.rownum = 1

			--Competitor inserts
			INSERT INTO [Person].[Competitor]
			(PersonId, DateOfBirth, Age, [Weight], Height, RankId, DojoId, ParentId, IsMinor
				, IsSpecialConsideration, EventId, IsKata, IsWeaponKata, IsSemiKnockdown, IsKnockdown)
			SELECT p.PersonId
				--, r.[DateOfBirth]
				, r.age
				, r.weight_pounds
				, r.height_inches
				, (SELECT TOP 1 RankId FROM [Event].[Rank] WHERE [Level] = r.[Rank]) --TODO: Kyu
				, (
					SELECT TOP 1 DojoId 
					FROM Facility.Dojo d 
					INNER JOIN Facility.Facility f ON d.FacilityId = f.FacilityId
					INNER JOIN Facility.MartialArtType m ON d.MartialArtTypeId = m.MartialArtTypeId
					WHERE f.[Name] = r.school_name
						--AND m.[Name] = r.[MartialArtName]
				)
				, (
					SELECT TOP 1 p.PersonId
					FROM Person.Person p
					WHERE p.FirstName = r.parent_first_name
						AND p.LastName = r.parent_last_name
						AND p.EmailAddress = r.ParentEmailAddress --TODO
				)
				, CASE WHEN r.age < 18 THEN 1 ELSE 0 END
				, r.special_considerations
				, @EventId
				--, r.IsKata	  
				--, r.IsWeaponKata
				--, r.IsSemiKnockdown	  
				--, r.IsKnockdown
			FROM #entries r
			INNER JOIN Person.Person p ON p.FirstName = r.first_name
										AND p.LastName = r.last_name
										AND p.EmailAddress = r.email_address
			LEFT JOIN Person.Competitor c ON c.PersonId = p.PersonId
			WHERE c.CompetitorId IS NULL
			
			--TODO: make another insert statement to populate a pivoted event set
			
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
		COMMIT
END
GO
