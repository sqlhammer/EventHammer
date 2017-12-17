CREATE VIEW [Event].[vwDivisionHeader]
AS
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
		,mt.Name MatchTypeName
		,m.EventId
FROM [Event].[Division] d
INNER JOIN [Event].[Match] m ON m.DivisionId = d.DivisionId
INNER JOIN [Event].[MatchType] mt ON mt.MatchTypeId = m.MatchTypeId
