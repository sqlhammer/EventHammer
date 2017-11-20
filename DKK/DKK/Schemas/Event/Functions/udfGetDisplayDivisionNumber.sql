CREATE FUNCTION [Event].[udfGetDisplayDivisionNumber]
(
	@MatchTypeName nvarchar(30),
	@EventId INT
)
RETURNS TABLE
AS
RETURN
(
	SELECT 
		ROW_NUMBER() OVER (ORDER BY mt.Name
									,mt.IsSpecialConsideration
									,d.MinimumWeight_lb
									,d.MinimumLevelId
									,d.MinimumAge
									,d.Gender) DisplayDivisionNumber
		,m.SubDivisionId
		,mt.Name
		,mt.IsSpecialConsideration
		,m.MatchId
		,d.DivisionId
	FROM Event.Event e
	INNER JOIN Event.Match m ON m.EventId = e.EventId
	INNER JOIN Event.MatchType mt ON mt.MatchTypeId = m.MatchTypeId
	INNER JOIN Event.Division d ON d.DivisionId = m.DivisionId
	WHERE e.EventId = @EventId
		AND mt.Name = @MatchTypeName
)
