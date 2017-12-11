CREATE PROCEDURE [Person].[spDeleteCompetitor]
	@CompetitorId INT
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;
	
	BEGIN TRY

		BEGIN TRANSACTION;

			DECLARE @PersonId INT

			SELECT @PersonId = c.PersonId
			FROM Person.Competitor c
			WHERE c.CompetitorId = @CompetitorId

			DELETE FROM mc
			FROM [Event].[MatchCompetitor] mc
			WHERE mc.CompetitorId = @CompetitorId
			
			DELETE FROM c
			FROM Person.Competitor c
			WHERE c.CompetitorId = @CompetitorId

			DELETE FROM p
			FROM Person.Person p
			WHERE p.PersonId = @PersonId

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