CREATE PROCEDURE [Event].[spAutoSetMatches]
	@EventId INT
AS
BEGIN
	/* Decription
		This sproc is designed to place competitors into matches which
		fit their registration but have not already been placed.
		
		It will not delete or alter any existing match configurations
		and it will not reshuffle the matches to even things out.
		
		The primary use case for this srpoc is to place a competitor who was 
		registered for one event, such as Kata, into a match when a new event
		was added, such as Semi-Knockdown.
	*/

	/* TODO
		Test this situation:
		1. Competitor 222 is manually registered to division 333 in matchtypeid 2
		2. Auto reg is executed
		2.a. Auto reg believes that division 332 is a better fit.

		Does it add the competitor into division 332 and make a duplciate matchtypeid 2 for that competitor
		or, does it recognize the duplicate and not insert?
	*/

	SET NOCOUNT ON;
	SET XACT_ABORT ON;
	
	BEGIN TRY

		/* Process flow
			1. Build temp tables for process.
			2. Load temp tables with existing matches and competitors
				2.a. ReSEED IDENTITY afterwards.
			3. Place competitors into the all applicable divisions.
			4. Uniquify the competitor's matches (i.e. each competitor will only fight in 1 kata match, even if they are in range for 3 kata divisions.)
			5. Split matches when there are too many competitors in one match.
			6. Load into tables where competitors are not placed in match type
		*/

		--1. Build temp tables for process.

		IF OBJECT_ID('tempdb..#Match') IS NOT NULL
			DROP TABLE #Match;

		CREATE TABLE #Match
		(
			[MatchId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY CLUSTERED
			,EventId INT NOT NULL
			,MatchTypeId INT NOT NULL
			,DivisionId INT NOT NULL
		);

		IF OBJECT_ID('tempdb..#MatchCompetitor') IS NOT NULL
			DROP TABLE #MatchCompetitor;

		CREATE TABLE #MatchCompetitor
		(
			[MatchCompetitorId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY CLUSTERED
			,MatchId INT NOT NULL
			,CompetitorId INT NOT NULL
			,MatchPlacement TINYINT NULL
		);

		--2. Load temp tables with existing matches and competitors

		SET IDENTITY_INSERT #Match ON;

		INSERT INTO #Match
		(
			[MatchId]
			,EventId
			,MatchTypeId
			,DivisionId
		)
		SELECT [MatchId]
			,EventId
			,MatchTypeId
			,DivisionId
		FROM [Event].[Match];

		SET IDENTITY_INSERT #Match OFF;

		SET IDENTITY_INSERT #MatchCompetitor ON;

		INSERT INTO #MatchCompetitor 
		( 
			MatchCompetitorId
			, CompetitorId
			, MatchPlacement 
		)
		SELECT MatchCompetitorId
			, CompetitorId
			, MatchPlacement
		FROM [Event].[MatchCompetitor];

		SET IDENTITY_INSERT #MatchCompetitor OFF;

		--	2.a. ReSEED IDENTITY afterwards.

		DECLARE @reseed INT;

		SELECT @reseed = MAX(MatchId)
		FROM [Event].[Match];

		SELECT @reseed =
			ISNULL(CASE
				WHEN MAX(MatchId) > @reseed THEN MAX(MatchId)
				ELSE @reseed
			END,0) + 1
		FROM #Match;

		EXEC( 'DBCC CHECKIDENT (#Match, RESEED, ' + @reseed + ');' );

		SELECT @reseed = MAX(MatchId)
		FROM [Event].[MatchCompetitor];

		SELECT @reseed =
			ISNULL(CASE
				WHEN MAX(MatchId) > @reseed THEN MAX(MatchId)
				ELSE @reseed
			END,0) + 1
		FROM #MatchCompetitor;

		EXEC( 'DBCC CHECKIDENT (#MatchCompetitor, RESEED, ' + @reseed + ');' )

		--3. Place competitors into the all applicable divisions.

		IF OBJECT_ID('tempdb..#comp_complete') IS NOT NULL
			DROP TABLE #comp_complete

		;WITH comp AS
		(
		SELECT c.CompetitorId,c.PersonId,c.DateOfBirth,c.Age,c.Weight,c.RankId,c.DojoId,c.ParentId,c.IsMinor,c.IsSpecialConsideration,c.EventId,c.IsKata,c.IsWeaponKata,c.IsSemiKnockdown,c.IsKnockdown,p.FirstName,p.LastName,p.DisplayName,p.TitleId,p.IsInstructor,p.Gender,p.PhoneNumber,p.EmailAddress,p.StreetAddress1,p.StreetAddress2,p.AppartmentCode,p.City,p.StateProvince,p.PostalCode,p.Country,r.Name,r.Level,r.Kyn,d.DivisionId,d.MinimumWeight_lb,d.MaximumWeight_lb,d.WeightClass,d.MinimumLevelId,d.MaximumLevelId,d.MinimumAge,d.MaximumAge 
		FROM Person.Competitor c
		INNER JOIN Person.Person p ON p.PersonId = c.PersonId
		INNER JOIN [Event].[Rank] r ON r.RankId = c.RankId
		LEFT JOIN [Event].[Division] d ON d.MinimumWeight_lb <= c.[Weight]
											AND d.MaximumWeight_lb >= c.[Weight]
											AND d.MinimumLevelId <= r.[Level]
											AND d.MaximumLevelId >= r.[Level]
											AND d.Gender = p.Gender
											AND d.MinimumAge <= c.Age
											AND d.MaximumAge >= c.Age
		WHERE c.EventId = 1
		),
		comp_complete AS
		(
			SELECT c.CompetitorId,c.PersonId,c.DateOfBirth,c.Age,c.Weight,c.RankId,c.DojoId,c.ParentId,c.IsMinor,c.EventId,c.IsKata,c.IsWeaponKata,c.IsSemiKnockdown,c.IsKnockdown,c.FirstName,c.LastName,c.DisplayName,c.TitleId,c.IsInstructor,c.Gender,c.PhoneNumber,c.EmailAddress,c.StreetAddress1,c.StreetAddress2,c.AppartmentCode,c.City,c.StateProvince,c.PostalCode,c.Country,c.Name,c.Level,c.Kyn,c.DivisionId,c.MinimumWeight_lb,c.MaximumWeight_lb,c.WeightClass,c.MinimumLevelId,c.MaximumLevelId,c.MinimumAge,c.MaximumAge,mt.MatchTypeId,mt.Name MatchTypeName,mt.IsSpecialConsideration 
			FROM comp c
			INNER JOIN [Event].[MatchType] mt ON mt.IsSpecialConsideration = c.IsSpecialConsideration
												AND mt.[name] = 'Kata'
												AND c.IsKata = 1
			UNION ALL
			SELECT c.CompetitorId,c.PersonId,c.DateOfBirth,c.Age,c.Weight,c.RankId,c.DojoId,c.ParentId,c.IsMinor,c.EventId,c.IsKata,c.IsWeaponKata,c.IsSemiKnockdown,c.IsKnockdown,c.FirstName,c.LastName,c.DisplayName,c.TitleId,c.IsInstructor,c.Gender,c.PhoneNumber,c.EmailAddress,c.StreetAddress1,c.StreetAddress2,c.AppartmentCode,c.City,c.StateProvince,c.PostalCode,c.Country,c.Name,c.Level,c.Kyn,c.DivisionId,c.MinimumWeight_lb,c.MaximumWeight_lb,c.WeightClass,c.MinimumLevelId,c.MaximumLevelId,c.MinimumAge,c.MaximumAge,mt.MatchTypeId,mt.Name MatchTypeName,mt.IsSpecialConsideration 
			FROM comp c
			INNER JOIN [Event].[MatchType] mt ON mt.IsSpecialConsideration = c.IsSpecialConsideration
												AND mt.[name] = 'Weapon Kata'
												AND c.IsWeaponKata = 1
			UNION ALL
			SELECT c.CompetitorId,c.PersonId,c.DateOfBirth,c.Age,c.Weight,c.RankId,c.DojoId,c.ParentId,c.IsMinor,c.EventId,c.IsKata,c.IsWeaponKata,c.IsSemiKnockdown,c.IsKnockdown,c.FirstName,c.LastName,c.DisplayName,c.TitleId,c.IsInstructor,c.Gender,c.PhoneNumber,c.EmailAddress,c.StreetAddress1,c.StreetAddress2,c.AppartmentCode,c.City,c.StateProvince,c.PostalCode,c.Country,c.Name,c.Level,c.Kyn,c.DivisionId,c.MinimumWeight_lb,c.MaximumWeight_lb,c.WeightClass,c.MinimumLevelId,c.MaximumLevelId,c.MinimumAge,c.MaximumAge,mt.MatchTypeId,mt.Name MatchTypeName,mt.IsSpecialConsideration 
			FROM comp c
			INNER JOIN [Event].[MatchType] mt ON mt.IsSpecialConsideration = c.IsSpecialConsideration
												AND mt.[name] = 'Semi-Knockdown'
												AND c.IsSemiKnockdown = 1
			UNION ALL
			SELECT c.CompetitorId,c.PersonId,c.DateOfBirth,c.Age,c.Weight,c.RankId,c.DojoId,c.ParentId,c.IsMinor,c.EventId,c.IsKata,c.IsWeaponKata,c.IsSemiKnockdown,c.IsKnockdown,c.FirstName,c.LastName,c.DisplayName,c.TitleId,c.IsInstructor,c.Gender,c.PhoneNumber,c.EmailAddress,c.StreetAddress1,c.StreetAddress2,c.AppartmentCode,c.City,c.StateProvince,c.PostalCode,c.Country,c.Name,c.Level,c.Kyn,c.DivisionId,c.MinimumWeight_lb,c.MaximumWeight_lb,c.WeightClass,c.MinimumLevelId,c.MaximumLevelId,c.MinimumAge,c.MaximumAge,mt.MatchTypeId,mt.Name MatchTypeName,mt.IsSpecialConsideration 
			FROM comp c
			INNER JOIN [Event].[MatchType] mt ON mt.IsSpecialConsideration = c.IsSpecialConsideration
												AND mt.[name] = 'Knockdown'
												AND c.IsKnockdown = 1
		)
		SELECT * 
		INTO #comp_complete
		FROM comp_complete cc;

		--4. Uniquify the competitor's matches (i.e. each competitor will only fight in 1 kata match, even if they are in range for 3 kata divisions.)

		IF OBJECT_ID('tempdb..#PerferredDivisions') IS NOT NULL
			DROP TABLE #PerferredDivisions

		;WITH Tally AS
		(
			SELECT ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) n
			FROM sys.columns c
		),
		aggs AS
		(
			SELECT cc.CompetitorId, cc.MatchTypeId, cc.DivisionId
				, ABS(cc.level - AVG(tl.n)) LevelDiff, ABS(cc.age - AVG(ta.n)) AgeDiff
			FROM #comp_complete cc
			LEFT JOIN Tally tl ON tl.n BETWEEN cc.MinimumLevelId AND cc.MaximumLevelId
			LEFT JOIN Tally ta ON ta.n BETWEEN cc.MinimumAge AND cc.MaximumAge
			GROUP BY cc.CompetitorId, cc.MatchTypeId, cc.DivisionId, cc.age, cc.level
			HAVING COUNT(*) > 1
		),
		ordered_aggs AS
		(
			SELECT ROW_NUMBER() OVER (PARTITION BY a.CompetitorId, a.MatchTypeId ORDER BY a.LevelDiff ASC, a.AgeDiff ASC) rownum
				,a.CompetitorId
				,a.MatchTypeId
				,a.DivisionId
				,a.LevelDiff
				,a.AgeDiff 
			FROM aggs a
			INNER JOIN #comp_complete cc ON cc.CompetitorId = a.CompetitorId
											AND cc.DivisionId = a.DivisionId
		)
		SELECT DISTINCT 
			oa.CompetitorId
			,oa.DivisionId
			,oa.MatchTypeId
		INTO #PerferredDivisions
		FROM ordered_aggs oa
		WHERE oa.rownum = 1;

		DELETE FROM cc
		FROM #comp_complete cc
		INNER JOIN #PerferredDivisions pd_cc ON pd_cc.CompetitorId = cc.CompetitorId
												AND pd_cc.MatchTypeId = cc.MatchTypeId
		LEFT JOIN #PerferredDivisions pd ON pd.CompetitorId = cc.CompetitorId
											AND pd.DivisionId = cc.DivisionId
											AND pd.MatchTypeId = cc.MatchTypeId
		WHERE pd.DivisionId IS NULL;

		--5. Split matches when there are too many competitors in one match.

		--TODO

		--6. Load into tables where competitors are not placed in match type
			
		BEGIN TRANSACTION;

			INSERT INTO [Event].[Match] (EventId,MatchTypeId,DivisionId)
			SELECT DISTINCT @EventId, cc.MatchTypeId, cc.DivisionId
			FROM #comp_complete cc
			LEFT JOIN [Event].[Match] m ON m.EventId = @EventId
											AND m.MatchTypeId = cc.MatchTypeId
											AND m.DivisionId = cc.DivisionId
			WHERE m.MatchId IS NULL;

			INSERT INTO [Event].[MatchCompetitor] (MatchId ,CompetitorId)
			SELECT DISTINCT m.MatchId, cc.CompetitorId
			FROM #comp_complete cc
			INNER JOIN [Event].[Match] m ON m.EventId = @EventId
											AND m.MatchTypeId = cc.MatchTypeId
											AND m.DivisionId = cc.DivisionId
			LEFT JOIN [Event].[MatchCompetitor] mc ON mc.MatchId = m.MatchId
														AND mc.CompetitorId = cc.CompetitorId
			WHERE mc.MatchCompetitorId IS NULL;

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