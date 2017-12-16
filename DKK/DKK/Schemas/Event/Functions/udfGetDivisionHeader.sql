CREATE FUNCTION [Event].[udfGetDivisionHeader]
(
	@MatchTypeName nvarchar(30),
	@EventId INT,
	@IsSpecialConsideration BIT
)
RETURNS TABLE
AS
RETURN
(
	SELECT 
		  m.MatchDisplayId
		  ,m.SubDivisionId
		  ,d.MinimumWeight_lb
		  ,d.MaximumWeight_lb
		  ,d.WeightClass
		  ,d.Gender
		  ,(SELECT Name FROM [Event].[Rank] WHERE RankId = d.MinimumLevelId) MinimumBelt
		  ,(SELECT Name FROM [Event].[Rank] WHERE RankId = d.MaximumLevelId) MaximumBelt
		  ,d.MinimumAge
		  ,d.MaximumAge 
	FROM [Event].[Division] d
	INNER JOIN [Event].[Match] m ON m.DivisionId = d.DivisionId
	INNER JOIN [Event].[MatchType] mt ON mt.MatchTypeId = m.MatchTypeId
	WHERE mt.IsSpecialConsideration = @IsSpecialConsideration
		AND m.EventId = @EventId
		AND mt.[Name] = @MatchTypeName
)
