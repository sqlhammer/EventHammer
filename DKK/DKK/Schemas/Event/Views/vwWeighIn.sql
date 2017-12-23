CREATE VIEW [Event].[vwWeighIn]
AS
SELECT DISTINCT c.CompetitorId
	,p.DisplayName
	,c.Weight
	,mt.Name MatchTypeName
	,m.MatchDisplayId
	,m.SubDivisionId
	,d.MinimumWeight_lb
	,d.MaximumWeight_lb
	,m.EventId
FROM [Event].[MatchType] mt
INNER JOIN [Event].[Match] m ON mt.matchtypeid = m.matchtypeid
INNER JOIN [Event].[Division] d ON m.DivisionId = d.DivisionId
INNER JOIN [Event].[MatchCompetitor] mc ON mc.MatchId = m.MatchId
INNER JOIN [Person].[Competitor] c ON c.CompetitorId = mc.CompetitorId
INNER JOIN [Person].[Person] p ON p.PersonId = c.PersonId
