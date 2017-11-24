CREATE PROCEDURE [Event].[spUpdateEvent]
	@EventId INT
	,@EventName nvarchar(30)
	,@EventTypeId INT
	,@Date DATE
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;
	
	BEGIN TRY

		BEGIN TRANSACTION;

			UPDATE e
			SET e.[Name] = @EventName
				,e.EventTypeId = @EventTypeId
				,e.[Date] = @Date
			FROM [Event].[Event] e
			WHERE e.EventId = @EventId

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