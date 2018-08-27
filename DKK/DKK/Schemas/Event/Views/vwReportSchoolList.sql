CREATE VIEW [Event].[vwReportSchoolList]
AS
SELECT ISNULL(f.Name, 'Unknown') DojoName
	,ISNULL(mat.Name, 'Unknown') MartialArtTypeName
	,ISNULL(op.DisplayName,'Unknown') OwnerName
	,cp.DisplayName CompetitorName
	,CASE WHEN c.IsSpecialConsideration = 1 THEN 'True' ELSE 'False' END IsSpecialConsideration
FROM Person.Competitor c
INNER JOIN Person.Person cp ON cp.PersonId = c.PersonId
LEFT JOIN Facility.Dojo d ON c.DojoId = d.DojoId
LEFT JOIN Facility.Facility f ON f.FacilityId = d.FacilityId
LEFT JOIN Facility.MartialArtType mat ON mat.MartialArtTypeId = d.MartialArtTypeId
LEFT JOIN Person.Person op ON op.PersonId = f.OwnerId
