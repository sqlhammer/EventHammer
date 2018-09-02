CREATE VIEW Person.vwCompetitor
AS
SELECT c.CompetitorId
	  ,c.PersonId
	  ,c.EventId
	  ,p.FirstName
	  ,p.LastName
	  ,p.DisplayName
	  ,p.TitleId
	  ,p.IsInstructor
	  ,p.Gender
	  ,c.DateOfBirth
	  ,c.Age
	  ,c.Weight
	  ,c.Height
	  ,r.RankId
	  ,r.[Level]
	  ,r.Kyu
	  ,dj.DojoId
	  ,djf.Name DojoName
	  ,c.OtherDojoName
	  ,c.IsMinor
	  ,c.IsSpecialConsideration
	  ,c.ConsiderationDescription
	  ,e.Name EventName
	  ,c.IsKata
	  ,c.IsWeaponKata
	  ,c.IsSemiKnockdown
	  ,c.IsKnockdown
	  ,p.PhoneNumber
	  ,p.EmailAddress
	  ,p.StreetAddress1
	  ,p.StreetAddress2
	  ,p.AppartmentCode
	  ,p.City
	  ,p.StateProvince
	  ,p.PostalCode
	  ,p.Country
	  ,c.ParentId
	  ,parent.FirstName ParentFirstName
	  ,parent.LastName ParentLastName
	  ,parent.DisplayName ParentDisplayName
	  ,parent.EmailAddress ParentEmailAddress
FROM Person.Competitor c
INNER JOIN Person.Person p ON p.PersonId = c.PersonId
LEFT JOIN Person.Person parent ON parent.PersonId = c.ParentId
INNER JOIN [Event].[Rank] r ON r.RankId = c.RankId
INNER JOIN Facility.Dojo dj ON dj.DojoId = c.DojoId
INNER JOIN Facility.Facility djf ON djf.FacilityId = dj.FacilityId
LEFT JOIN [Event].[Event] e ON e.EventId = c.EventId