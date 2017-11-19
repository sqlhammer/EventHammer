CREATE PROCEDURE [Event].[spAutoSetMatches]
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

	SET NOCOUNT ON
	SET XACT_ABORT ON

	BEGIN TRANSACTION

		BEGIN TRY

			/* Process flow
				1. Build temp tables for process.
				2. Load temp tables with existing matches and competitors
					2.a. ReSEED IDENTITY afterwards.
				3. Build out matches for every possible combination
					of weight, rank, gender, special consideration.
				4. Place competitors into the empty brackets.
				5. Split matches when there are too many competitors in one match.
				6. Drop brackets are empty.
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
			)

			IF OBJECT_ID('tempdb..#MatchCompetitor') IS NOT NULL
				DROP TABLE #MatchCompetitor;

			CREATE TABLE #MatchCompetitor
			(
				[MatchCompetitorId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY CLUSTERED
				,MatchId INT NOT NULL
				,CompetitorId INT NOT NULL
				,MatchPlacement TINYINT NULL
			)

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
			FROM [Event].[Match]

			SET IDENTITY_INSERT #Match OFF;

			SET IDENTITY_INSERT #MatchCompetitor ON;

			INSERT INTO #MatchCompetitor 
			( 
				MatchId
				, CompetitorId
				, MatchPlacement 
			)
			SELECT MatchId
				, CompetitorId
				, MatchPlacement
			FROM [Event].[MatchCompetitor]

			SET IDENTITY_INSERT #MatchCompetitor OFF;

			--	2.a. ReSEED IDENTITY afterwards.

			DECLARE @reseed INT

			SELECT @reseed = MAX(MatchId)
			FROM [Event].[Match]

			SELECT @reseed =
				CASE
					WHEN MAX(MatchId) > @reseed THEN MAX(MatchId)
					ELSE @reseed
				END + 1
			FROM #Match

			EXEC( 'DBCC CHECKIDENT (#Match, RESEED, ' + @reseed + ');' )

			SELECT @reseed = MAX(MatchId)
			FROM [Event].[MatchCompetitor]

			SELECT @reseed =
				CASE
					WHEN MAX(MatchId) > @reseed THEN MAX(MatchId)
					ELSE @reseed
				END + 1
			FROM #MatchCompetitor

			EXEC( 'DBCC CHECKIDENT (#MatchCompetitor, RESEED, ' + @reseed + ');' )

			--3. Build out matches for every possible combination
				--	of weight, rank, gender, special consideration.



			--4. Place competitors into the empty brackets.
			--5. Split matches when there are too many competitors in one match.
			--6. Drop brackets are empty.

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