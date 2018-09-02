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
				,(SELECT TOP 1 value FROM [Stage].[CalderaFormEntry] WHERE slug = 'country' AND entry_id = c.entry_id) country
				,(SELECT TOP 1 value FROM [Stage].[CalderaFormEntry] WHERE slug = 'email_address' AND entry_id = c.entry_id) email_address
				,(SELECT TOP 1 value FROM [Stage].[CalderaFormEntry] WHERE slug = 'first_name' AND entry_id = c.entry_id) first_name
				,(SELECT TOP 1 LEFT(value,1) FROM [Stage].[CalderaFormEntry] WHERE slug = 'gender' AND entry_id = c.entry_id) gender
				,(SELECT TOP 1 value FROM [Stage].[CalderaFormEntry] WHERE slug = 'height_inches' AND entry_id = c.entry_id) height_inches
				,(SELECT TOP 1 value FROM [Stage].[CalderaFormEntry] WHERE slug = 'instructor_name' AND entry_id = c.entry_id) instructor_name
				,(SELECT TOP 1 value FROM [Stage].[CalderaFormEntry] WHERE slug = 'last_name' AND entry_id = c.entry_id) last_name
				,(SELECT TOP 1 value FROM [Stage].[CalderaFormEntry] WHERE slug = 'parent_first_name' AND entry_id = c.entry_id) parent_first_name
				,(SELECT TOP 1 value FROM [Stage].[CalderaFormEntry] WHERE slug = 'parent_last_name' AND entry_id = c.entry_id) parent_last_name
				,(SELECT TOP 1 value FROM [Stage].[CalderaFormEntry] WHERE slug = 'parent_email' AND entry_id = c.entry_id) parent_email
				,(SELECT TOP 1 value FROM [Stage].[CalderaFormEntry] WHERE slug = 'rank_kyu' AND entry_id = c.entry_id) rank_kyu
				,(SELECT TOP 1 value FROM [Stage].[CalderaFormEntry] WHERE slug = 'school_name' AND entry_id = c.entry_id) school_name
				,(SELECT TOP 1 value FROM [Stage].[CalderaFormEntry] WHERE slug = 'state_province' AND entry_id = c.entry_id) state_province
				,(SELECT TOP 1 value FROM [Stage].[CalderaFormEntry] WHERE slug = 'street_address' AND entry_id = c.entry_id) street_address
				,(SELECT TOP 1 value FROM [Stage].[CalderaFormEntry] WHERE slug = 'weight_pounds' AND entry_id = c.entry_id) weight_pounds
				,(SELECT TOP 1 value FROM [Stage].[CalderaFormEntry] WHERE slug = 'zip_code' AND entry_id = c.entry_id) zip_code
				,ISNULL((
					SELECT TOP 1
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
				),0) special_considerations
				,(SELECT TOP 1 value FROM [Stage].[CalderaFormEntry] WHERE slug = 'special_considerations' AND entry_id = c.entry_id) consideration_description
			) pvt

			/* 
			
			Removing updates because the load pulls in all competitors every time, not deltas.
			This is a problem because changes in the app will be over-ridden by the next hourly load.


			--Person updates
			UPDATE p
			SET p.DisplayName = r.last_name + ', ' + r.first_name
				,p.Gender = r.gender
				,p.StreetAddress1 = r.street_address
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
				,c.Age = r.age
				,c.[Weight] = r.weight_pounds
				,c.Height = r.height_inches
				,c.RankId = (SELECT TOP 1 RankId FROM [Event].[Rank] WHERE Kyu = r.rank_kyu) 
				,c.DojoId = (
					SELECT TOP 1 DojoId 
					FROM Facility.Dojo d 
					INNER JOIN Facility.Facility f ON d.FacilityId = f.FacilityId
					INNER JOIN Facility.MartialArtType m ON d.MartialArtTypeId = m.MartialArtTypeId
					WHERE f.[Name] = r.school_name
				)
				,c.ParentId = (
					SELECT TOP 1 p.PersonId
					FROM Person.Person p
					WHERE p.FirstName = r.parent_first_name
						AND p.LastName = r.parent_last_name
						AND p.EmailAddress = r.parent_email
				)
				,c.IsMinor = CASE WHEN r.age < 18 THEN 1 ELSE 0 END
				,c.IsSpecialConsideration = r.special_considerations
				,c.ConsiderationDescription = r.consideration_description
				,c.IsKata = ISNULL((SELECT TOP 1 1
					FROM [Stage].[CalderaFormEntry] 
					CROSS APPLY Stage.parseJSON(value)
					WHERE slug = 'participating_events' 
						AND entry_id = r.entry_id
						AND StringValue = 'Kata'),0) 
				,c.IsWeaponKata = ISNULL((SELECT TOP 1 1
					FROM [Stage].[CalderaFormEntry] 
					CROSS APPLY Stage.parseJSON(value)
					WHERE slug = 'participating_events' 
						AND entry_id = r.entry_id
						AND StringValue = 'Weapons Kata'),0) 
				,c.IsSemiKnockdown = ISNULL((SELECT TOP 1 1
					FROM [Stage].[CalderaFormEntry] 
					CROSS APPLY Stage.parseJSON(value)
					WHERE slug = 'participating_events' 
						AND entry_id = r.entry_id
						AND StringValue = 'Semi Knockdown (with protection gear)'),0) 
				,c.IsKnockdown = ISNULL((SELECT TOP 1 1
					FROM [Stage].[CalderaFormEntry] 
					CROSS APPLY Stage.parseJSON(value)
					WHERE slug = 'participating_events' 
						AND entry_id = r.entry_id
						AND StringValue = 'Knockdown (without protection gear)'),0) 
			FROM #entries r
			INNER JOIN Person.Person p ON p.FirstName = r.first_name
										AND p.LastName = r.last_name
										AND p.EmailAddress = r.email_address
			INNER JOIN Person.Competitor c ON c.PersonId = p.PersonId
											AND c.EventId = @EventId

			--*/

			--Person inserts
			;WITH NewPersons AS
			(
				SELECT ROW_NUMBER() OVER (PARTITION BY r.first_name, r.last_name, r.email_address ORDER BY (SELECT NULL)) rownum
					  ,r.first_name
					  ,r.last_name
					  ,r.last_name + ', ' + r.first_name DisplayName
					  ,0 IsInstructor
					  ,r.gender
					  ,r.email_address
					  ,r.street_address
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
				, IsInstructor, Gender, EmailAddress, StreetAddress1
				, City, StateProvince, PostalCode, Country )
			SELECT np.first_name
				  ,np.last_name
				  ,np.DisplayName
				  ,np.IsInstructor
				  ,np.Gender
				  ,np.email_address
				  ,np.street_address
				  ,np.city
				  ,np.state_province
				  ,np.zip_code
				  ,np.country
			FROM NewPersons np
			WHERE np.rownum = 1

			--Parent inserts
			;WITH NewPersons AS
			(
				SELECT ROW_NUMBER() OVER (PARTITION BY r.parent_first_name, r.parent_last_name, r.parent_email ORDER BY (SELECT NULL)) rownum
					  ,r.parent_first_name
					  ,r.parent_last_name
					  ,r.parent_last_name + ', ' + r.parent_first_name DisplayName
					  ,0 IsInstructor
					  ,r.parent_email 
				FROM #entries r
				LEFT JOIN Person.Person p ON p.FirstName = r.parent_first_name
											AND p.LastName = r.parent_last_name
											AND p.EmailAddress = r.parent_email
				WHERE p.PersonId IS NULL
					AND r.parent_first_name IS NOT NULL
					AND r.parent_last_name IS NOT NULL
					AND r.parent_email IS NOT NULL
			)
			INSERT INTO Person.Person ( FirstName, LastName, DisplayName, IsInstructor, EmailAddress )
			SELECT np.parent_first_name
				  ,np.parent_last_name
				  ,np.DisplayName
				  ,np.IsInstructor
				  ,np.parent_email
			FROM NewPersons np
			WHERE np.rownum = 1

			--Competitor inserts
			INSERT INTO [Person].[Competitor]
			(PersonId, Age, [Weight], Height, RankId, DojoId, ParentId, IsMinor
				, IsSpecialConsideration, ConsiderationDescription, EventId, IsKata, IsWeaponKata, IsSemiKnockdown, IsKnockdown)
			SELECT p.PersonId
				, r.age
				, r.weight_pounds
				, r.height_inches
				, (SELECT TOP 1 RankId FROM [Event].[Rank] WHERE Kyu = r.rank_kyu)
				,(
					SELECT TOP 1 DojoId
					FROM Facility.Dojo d 
					INNER JOIN Facility.Facility f ON d.FacilityId = f.FacilityId
					INNER JOIN Facility.MartialArtType m ON d.MartialArtTypeId = m.MartialArtTypeId
					WHERE f.[Name] = r.school_name
				) 
				, (
					SELECT TOP 1 p.PersonId
					FROM Person.Person p
					WHERE p.FirstName = r.parent_first_name
						AND p.LastName = r.parent_last_name
						AND p.EmailAddress = r.parent_email
				)
				, CASE WHEN r.age < 18 THEN 1 ELSE 0 END
				, r.special_considerations
				, r.consideration_description
				, @EventId				
				, ISNULL((SELECT TOP 1 1
					FROM [Stage].[CalderaFormEntry] 
					CROSS APPLY Stage.parseJSON(value)
					WHERE slug = 'participating_events' 
						AND entry_id = r.entry_id
						AND StringValue = 'Kata'),0) IsKata
				, ISNULL((SELECT TOP 1 1
					FROM [Stage].[CalderaFormEntry] 
					CROSS APPLY Stage.parseJSON(value)
					WHERE slug = 'participating_events' 
						AND entry_id = r.entry_id
						AND StringValue = 'Weapons Kata'),0) IsWeaponKata
				, ISNULL((SELECT TOP 1 1
					FROM [Stage].[CalderaFormEntry] 
					CROSS APPLY Stage.parseJSON(value)
					WHERE slug = 'participating_events' 
						AND entry_id = r.entry_id
						AND StringValue = 'Semi Knockdown (with protection gear)'),0) IsSemiKnockdown
				, ISNULL((SELECT TOP 1 1
					FROM [Stage].[CalderaFormEntry] 
					CROSS APPLY Stage.parseJSON(value)
					WHERE slug = 'participating_events' 
						AND entry_id = r.entry_id
						AND StringValue = 'Knockdown (without protection gear)'),0) IsKnockdown
			FROM #entries r
			INNER JOIN Person.Person p ON p.FirstName = r.first_name
										AND p.LastName = r.last_name
										AND p.EmailAddress = r.email_address
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
		COMMIT
END
GO
