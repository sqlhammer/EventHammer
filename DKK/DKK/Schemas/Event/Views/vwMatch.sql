CREATE VIEW [Event].[vwMatch]
AS
SELECT 
	  e.EventId
	  ,e.Name EventName
	  ,m.MatchId
	  ,m.MatchDisplayId
	  ,mt.name MatchTypeName	  
	  ,m.DivisionId
	  ,m.SubDivisionId
	  ,d.MinimumWeight_lb
	  ,d.MaximumWeight_lb
	  ,d.WeightClass
	  ,d.Gender
	  ,d.MinimumLevelId
	  ,d.MaximumLevelId
	  ,d.MinimumAge
	  ,d.MaximumAge
	  ,mc.CompetitorId
	  ,p.FirstName
	  ,p.LastName
	  ,p.DisplayName
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
LEFT JOIN [Person].[Person] p ON p.PersonId = c.PersonId
LEFT JOIN [Event].[Rank] r ON r.RankId = c.RankId
LEFT JOIN Facility.Dojo dj ON dj.DojoId = c.DojoId
LEFT JOIN Facility.Facility djf ON djf.FacilityId = dj.FacilityId