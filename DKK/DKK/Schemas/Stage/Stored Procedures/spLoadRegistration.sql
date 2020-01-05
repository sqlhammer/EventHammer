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
				SELECT DISTINCT data_id
				FROM Stage.ElementorFormEntry
			) c
			CROSS APPLY 
			(
				SELECT 
				(SELECT TOP 1 meta_value FROM [Stage].[ElementorFormEntry] WHERE meta_key = 'age' AND data_id = c.data_id) age
				,(SELECT TOP 1 meta_value FROM [Stage].[ElementorFormEntry] WHERE meta_key = 'city' AND data_id = c.data_id) city
				,(SELECT TOP 1 meta_value FROM [Stage].[ElementorFormEntry] WHERE meta_key = 'country' AND data_id = c.data_id) country
				,(SELECT TOP 1 meta_value FROM [Stage].[ElementorFormEntry] WHERE meta_key = 'competitor_email' AND data_id = c.data_id) email_address
				,(SELECT TOP 1 meta_value FROM [Stage].[ElementorFormEntry] WHERE meta_key = 'competitor_first_name' AND data_id = c.data_id) first_name
				,(SELECT TOP 1 LEFT(meta_value,1) FROM [Stage].[ElementorFormEntry] WHERE meta_key = 'gender' AND data_id = c.data_id) gender
				,(SELECT TOP 1 meta_value FROM [Stage].[ElementorFormEntry] WHERE meta_key = 'height_in' AND data_id = c.data_id) height_inches
				,(SELECT TOP 1 meta_value FROM [Stage].[ElementorFormEntry] WHERE meta_key = 'instructor_name' AND data_id = c.data_id) instructor_name
				,(SELECT TOP 1 meta_value FROM [Stage].[ElementorFormEntry] WHERE meta_key = 'other_instructor_name' AND data_id = c.data_id) other_instructor
				,(SELECT TOP 1 meta_value FROM [Stage].[ElementorFormEntry] WHERE meta_key = 'competitor_last_name' AND data_id = c.data_id) last_name
				,(SELECT TOP 1 meta_value FROM [Stage].[ElementorFormEntry] WHERE meta_key = 'parent_first_name' AND data_id = c.data_id) parent_first_name
				,(SELECT TOP 1 meta_value FROM [Stage].[ElementorFormEntry] WHERE meta_key = 'parent_last_name' AND data_id = c.data_id) parent_last_name
				,(SELECT TOP 1 meta_value FROM [Stage].[ElementorFormEntry] WHERE meta_key = 'parent_email' AND data_id = c.data_id) parent_email
				,(SELECT TOP 1 meta_value FROM [Stage].[ElementorFormEntry] WHERE meta_key = 'kyu' AND data_id = c.data_id) rank_kyu
				,(SELECT TOP 1 meta_value FROM [Stage].[ElementorFormEntry] WHERE meta_key = 'school_name' AND data_id = c.data_id) school_name
				,(SELECT TOP 1 meta_value FROM [Stage].[ElementorFormEntry] WHERE meta_key = 'other_school_name' AND data_id = c.data_id) other_school
				,(SELECT TOP 1 meta_value FROM [Stage].[ElementorFormEntry] WHERE meta_key = 'state' AND data_id = c.data_id) state_province
				,(SELECT TOP 1 meta_value FROM [Stage].[ElementorFormEntry] WHERE meta_key = 'street_address' AND data_id = c.data_id) street_address
				,(SELECT TOP 1 meta_value FROM [Stage].[ElementorFormEntry] WHERE meta_key = 'weight_lb' AND data_id = c.data_id) weight_pounds
				,(SELECT TOP 1 meta_value FROM [Stage].[ElementorFormEntry] WHERE meta_key = 'postal_code' AND data_id = c.data_id) postal_code
				,ISNULL((
					SELECT TOP 1
						CAST(
							CASE 
								WHEN meta_value IS NOT NULL AND meta_value <> '' 
									THEN 1 
								ELSE 0 
							END 
							AS BIT
							) value 
						FROM [Stage].[ElementorFormEntry] 
						WHERE meta_key = 'special_considerations_description' 
							AND data_id = c.data_id
				),0) special_considerations
				,(SELECT TOP 1 meta_value FROM [Stage].[ElementorFormEntry] WHERE meta_key = 'special_considerations_description' AND data_id = c.data_id) consideration_description
			) pvt
			
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
					  ,r.postal_code
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
				  ,np.postal_code
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
                    AND trim(r.parent_first_name) <> ''
					AND trim(r.parent_last_name) <> ''
					AND trim(r.parent_email) <> ''
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
			(PersonId, Age, [Weight], Height, RankId, DojoId, OtherDojoName, OtherInstructorName, ParentId, IsMinor
				, IsSpecialConsideration, ConsiderationDescription, EventId, IsKata, IsWeaponKata, IsSemiKnockdown, IsKnockdown)
			SELECT p.PersonId				
				,COALESCE(TRY_CAST(r.age AS TINYINT),0)
				, r.weight_pounds
				, r.height_inches
				, (SELECT TOP 1 RankId FROM [Event].[Rank] WHERE Kyu = r.rank_kyu) RankId
				,(
					SELECT TOP 1 DojoId
					FROM Facility.Dojo d 
					INNER JOIN Facility.Facility f ON d.FacilityId = f.FacilityId
					INNER JOIN Facility.MartialArtType m ON d.MartialArtTypeId = m.MartialArtTypeId
					WHERE f.[Name] = r.school_name
				) DojoId
				, r.other_school 
				, r.other_instructor 
				, (
					SELECT TOP 1 p.PersonId
					FROM Person.Person p
					WHERE p.FirstName = r.parent_first_name
						AND p.LastName = r.parent_last_name
						AND p.EmailAddress = r.parent_email
				) ParentId
				, CASE WHEN r.age < 18 THEN 1 ELSE 0 END IsMinor
				, r.special_considerations
				, r.consideration_description
				, @EventId EventId
				, ISNULL((select top 1 1
							from stage.elementorformentry e
							cross apply string_split(e.meta_value,',') s
							where e.meta_key = 'participating_events'
								and lower(trim(s.value)) = 'kata'
								and data_id = r.data_id),0) IsKata
				, ISNULL((select top 1 1
							from stage.elementorformentry e
							cross apply string_split(e.meta_value,',') s
							where e.meta_key = 'participating_events'
								and lower(trim(s.value)) = 'weapons kata'
								and data_id = r.data_id),0) IsWeaponKata
				, ISNULL((select top 1 1
							from stage.elementorformentry e
							cross apply string_split(e.meta_value,',') s
							where e.meta_key = 'participating_events'
								and lower(trim(s.value)) = 'semi knockdown (with protection gear)'
								and data_id = r.data_id),0) IsSemiKnockdown
				, ISNULL((select top 1 1
							from stage.elementorformentry e
							cross apply string_split(e.meta_value,',') s
							where e.meta_key = 'participating_events'
								and lower(trim(s.value)) = 'knockdown (with protection gear)'
								and data_id = r.data_id),0) IsKnockdown
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
