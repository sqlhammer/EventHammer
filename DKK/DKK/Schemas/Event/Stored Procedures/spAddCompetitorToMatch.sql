CREATE PROCEDURE [Event].[spAddCompetitorToMatch]
	@EventId INT,
	@MatchId INT,
	@CompetitorId INT
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;
	
	BEGIN TRY

		BEGIN TRANSACTION;
			
			DECLARE @Count INT = 0;

			SELECT @Count = COUNT(*)
			FROM [Event].[Match] m
			INNER JOIN [Event].[MatchCompetitor] mc ON mc.MatchId = m.MatchId
			LEFT JOIN Person.Competitor c ON c.CompetitorId = mc.CompetitorId
											AND c.CompetitorId = @CompetitorId
			WHERE c.CompetitorId = @CompetitorId
				AND m.MatchId = @MatchId
				AND mc.EventId = @EventId;

			IF @Count = 0
			BEGIN
				
				INSERT INTO Event.MatchCompetitor ( MatchId, CompetitorId, MatchPlacement, EventId )
				VALUES
				(
					@MatchId -- MatchId - int
					,@CompetitorId -- CompetitorId - int
					,NULL -- MatchPlacement - tinyint,
					,@EventId --EventId - int
				) 

			END
			ELSE
			BEGIN
				
				;THROW 50001, 'The competitor already exists in this match.', 1;

			END
			
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