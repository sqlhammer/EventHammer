CREATE VIEW [Event].[vwDivisionHeader]
AS
SELECT d.DivisionId MatchDisplayId
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
		,mt.IsSpecialConsideration
FROM [Event].[Division] d
INNER JOIN [Event].[Match] m ON m.DivisionId = d.DivisionId
INNER JOIN [Event].[MatchType] mt 
	ON mt.MatchTypeId = m.MatchTypeId
		AND 
		(
			CASE WHEN d.IsKata = 1 THEN 'Kata' ELSE '' END = mt.Name
			OR CASE WHEN d.IsWeaponKata = 1 THEN 'Weapon Kata' ELSE '' END = mt.NAME
            OR CASE WHEN d.IsSemiKnockdown = 1 THEN 'Semi-Knockdown' ELSE '' END = mt.NAME
            OR CASE WHEN d.IsKnockdown = 1 THEN 'Knockdown' ELSE '' END = mt.Name
		)
