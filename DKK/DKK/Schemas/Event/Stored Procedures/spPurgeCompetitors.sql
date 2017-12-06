CREATE PROCEDURE [Event].[spPurgeCompetitors]
	@EventId INT
AS
BEGIN
	SET NOCOUNT ON
	SET XACT_ABORT ON

	BEGIN TRANSACTION
	
		BEGIN TRY

			DELETE FROM mc
			FROM [Event].[MatchCompetitor] mc
			INNER JOIN [Event].[Match] m ON m.MatchId = mc.MatchId
			WHERE m.EventId = @EventId

			DELETE FROM c
			FROM [Person].[Competitor] c
			WHERE c.EventId = @EventId;

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

