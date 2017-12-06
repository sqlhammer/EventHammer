CREATE VIEW [Event].[vwSingleCompetitorDivision]
AS
WITH SingleCompetitorDivision AS
(
	SELECT e.EventId
		,e.Name EventName
		,mt.Name MatchTypeName
		,d.DivisionId
		,mt.MatchTypeId
		,mt.IsSpecialConsideration
	FROM [Event].[Match] m
	INNER JOIN [Event].[Event] e ON e.EventId = m.EventId
	INNER JOIN [Event].[MatchType] mt ON mt.MatchTypeId = m.MatchTypeId
	INNER JOIN [Event].[Division] d ON d.DivisionId = m.DivisionId
	INNER JOIN [Event].[MatchCompetitor] mc ON mc.MatchId = m.MatchId
	INNER JOIN [Person].[Competitor] c ON c.CompetitorId = mc.CompetitorId
	GROUP BY e.EventId, e.Name, mt.MatchTypeId, mt.Name, d.DivisionId, mt.IsSpecialConsideration
	HAVING COUNT(*) = 1
)
SELECT scd.MatchTypeName
	,scd.IsSpecialConsideration
	,scd.DivisionId
	,p.DisplayName
FROM SingleCompetitorDivision scd
LEFT JOIN [Event].[Match] m ON m.DivisionId = scd.DivisionId
								AND m.MatchTypeId = scd.MatchTypeId
LEFT JOIN [Event].[MatchCompetitor] mc ON mc.MatchId = m.MatchId
LEFT JOIN [Person].[Competitor] c ON c.CompetitorId = mc.CompetitorId
LEFT JOIN [Person].[Person] p ON p.PersonId = c.PersonId
LEFT JOIN [Event].[Rank] r ON r.RankId = c.RankId
LEFT JOIN Facility.Dojo dj ON dj.DojoId = c.DojoId
LEFT JOIN Facility.Facility djf ON djf.FacilityId = dj.FacilityId