CREATE VIEW [Event].[vwDivision]
AS
SELECT d.DivisionId
	  ,d.MinimumWeight_lb
	  ,d.MaximumWeight_lb
	  ,d.WeightClass
	  ,d.Gender
	  ,d.MinimumLevelId
	  ,d.MaximumLevelId
	  ,d.MinimumAge
	  ,d.MaximumAge
	  ,d.IsKata
	  ,mt.MatchTypeId
	  ,mt.Name MatchTypeName
	  ,mt.IsSpecialConsideration
FROM [Event].[Division] d
CROSS APPLY [Event].[MatchType] mt
WHERE mt.Name LIKE '%Kata%'
	AND d.IsKata = 1
UNION ALL 
SELECT d.DivisionId
	  ,d.MinimumWeight_lb
	  ,d.MaximumWeight_lb
	  ,d.WeightClass
	  ,d.Gender
	  ,d.MinimumLevelId
	  ,d.MaximumLevelId
	  ,d.MinimumAge
	  ,d.MaximumAge
	  ,d.IsKata
	  ,mt.MatchTypeId
	  ,mt.Name MatchTypeName
	  ,mt.IsSpecialConsideration
FROM [Event].[Division] d
CROSS APPLY [Event].[MatchType] mt
WHERE mt.Name LIKE '%knockdown%'
	AND d.IsKata = 0