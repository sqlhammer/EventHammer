CREATE VIEW [Event].[vwCompetitorsByDojo]
AS
SELECT f.Name DojoName
	,mat.Name MartialArtTypeName
	,op.DisplayName OwnerName
	,cp.DisplayName CompetitorName
	,mt.Name MatchTypeName
	,mt.IsSpecialConsideration
	,m.MatchDisplayId
	,m.SubDivisionId
	,m.EventId
	,d.DojoId
FROM Facility.Dojo d
INNER JOIN Facility.Facility f ON f.FacilityId = d.FacilityId
INNER JOIN Facility.MartialArtType mat ON mat.MartialArtTypeId = d.MartialArtTypeId
INNER JOIN Person.Competitor c ON c.DojoId = d.DojoId
INNER JOIN Person.Person cp ON cp.PersonId = c.PersonId
INNER JOIN Person.Person op ON op.PersonId = f.OwnerId
INNER JOIN Event.MatchCompetitor mc ON mc.CompetitorId = c.CompetitorId
										AND mc.EventId = c.EventId
INNER JOIN Event.Match m ON m.MatchId = mc.MatchId
INNER JOIN Event.MatchType mt ON mt.MatchTypeId = m.MatchTypeId