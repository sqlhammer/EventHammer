    
CREATE PROCEDURE [Event].[spMergeScores]
	@EventId int, --I don't want this from the DataTable as an extra protection against the Scores object containing an object for an event which is not current.
	@Scores [Event].[ttScore] READONLY
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;
	
	BEGIN TRY

		BEGIN TRANSACTION;

			--delete
			DELETE
			FROM [Event].[Score]
			WHERE eventid = @eventid
				AND NOT EXISTS (SELECT scoreid FROM @Scores)
							
			--update
			UPDATE [Event].[Score]
			SET
				ScoreJudge1 = t.ScoreJudge1,
				ScoreJudge2 = t.ScoreJudge2,
				ScoreJudge3 = t.ScoreJudge3,
				ScoreJudge4 = t.ScoreJudge4,
				ScoreJudge5 = t.ScoreJudge5,
				Ranked = t.Ranked,
				IsDisqualified = t.IsDisqualified
			FROM @Scores t
			INNER JOIN [Event].[Score] s ON s.ScoreId = t.ScoreId 
											and s.EventId = @EventId   --These three make up the a unique key
											and t.MatchId = s.MatchId  --They are a procaution against @Scores with default ScoreIds matching
											and t.CompetitorId = s.CompetitorId

			--insert
			INSERT INTO [Event].[Score]
			(
				EventId
				,MatchId
				,MatchTypeId
				,CompetitorId
				,ScoreJudge1
				,ScoreJudge2
				,ScoreJudge3
				,ScoreJudge4
				,ScoreJudge5
				,Ranked
				,IsDisqualified
			)
			SELECT 
				@EventId
				,s1.MatchId
				,s1.MatchTypeId
				,s1.CompetitorId
				,s1.ScoreJudge1
				,s1.ScoreJudge2
				,s1.ScoreJudge3
				,s1.ScoreJudge4
				,s1.ScoreJudge5
				,s1.Ranked
				,s1.IsDisqualified
			FROM @Scores s1
			LEFT JOIN [Event].[Score] s2 ON s2.EventId = @EventId 
											and s1.MatchId = s2.MatchId
											and s1.CompetitorId = s2.CompetitorId
			WHERE s2.ScoreId IS NULL

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