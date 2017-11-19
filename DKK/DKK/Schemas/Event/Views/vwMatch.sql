﻿CREATE VIEW [Event].[vwMatch]
AS
SELECT 
	  e.Name EventName
	  ,m.MatchId
	  ,mt.name MatchTypeName	  
	  ,m.DivisionId
	  ,d.MinimumWeight_lb
	  ,d.MaximumWeight_lb
	  ,d.WeightClass
	  ,d.Gender
	  ,d.MinimumLevelId
	  ,d.MaximumLevelId
	  ,d.MinimumAge
	  ,d.MaximumAge
	  ,mc.CompetitorId
	  ,mc.MatchPlacement
	  ,c.DateOfBirth
	  ,c.Age
	  ,c.Weight
	  ,r.[Level]
	  ,r.[Kyn]
	  ,djf.Name DojoName
	  ,c.IsSpecialConsideration
FROM [Event].[Match] m
INNER JOIN [Event].[Event] e ON e.EventId = m.EventId
INNER JOIN [Event].[MatchType] mt ON mt.MatchTypeId = m.MatchTypeId
INNER JOIN [Event].[Division] d ON d.DivisionId = m.DivisionId
LEFT JOIN [Event].[MatchCompetitor] mc ON mc.MatchId = m.MatchId
LEFT JOIN [Person].[Competitor] c ON c.CompetitorId = mc.CompetitorId
LEFT JOIN [Event].[Rank] r ON r.RankId = c.RankId
LEFT JOIN Facility.Dojo dj ON dj.DojoId = c.DojoId
LEFT JOIN Facility.Facility djf ON djf.FacilityId = dj.FacilityId