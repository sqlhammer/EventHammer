CREATE PROCEDURE [Event].[spInsertMatch]
	@EventId INT
	,@MatchTypeId INT
	,@MatchDisplayId INT = NULL
	,@DivisionId INT
	,@SubDivisionId INT
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;
	
	BEGIN TRY

		BEGIN TRANSACTION;

			INSERT INTO [Event].[Match] ( EventId, MatchTypeId, DivisionId, SubDivisionId, MatchDisplayId )
			VALUES
			(
				@EventId -- EventId - int
				,@MatchTypeId -- MatchTypeId - int
				,@DivisionId -- DivisionId - int
				,@SubDivisionId -- SubDivisionId - int
				,@MatchDisplayId -- MatchDisplayId - int
			) 

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