CREATE VIEW [Person].[vwCompetitorDetail]
AS
SELECT c.CompetitorId,
       c.DateOfBirth,
       c.Age,
       c.Weight,
       c.Height,
       c.DojoId,
       c.OtherDojoName,
       c.ParentId,
       c.IsMinor,
       c.IsSpecialConsideration,
       c.ConsiderationDescription,
       c.IsKata,
       c.IsWeaponKata,
       c.IsSemiKnockdown,
       c.IsKnockdown,
       p.PersonId,
       p.FirstName,
       p.LastName,
       p.DisplayName,
       p.TitleId,
	   t.Name TitleName,
       p.IsInstructor,
       p.Gender,
       p.PhoneNumber,
       p.EmailAddress,
       p.StreetAddress1,
       p.StreetAddress2,
       p.AppartmentCode,
       p.City,
       p.StateProvince,
       p.PostalCode,
       p.Country,
       parent.PersonId ParentPersonId,
       parent.FirstName ParentFirstName,
       parent.LastName ParentLastName,
       parent.DisplayName ParentDisplayName,
       parent.EmailAddress ParentEmailAddress,
       r.RankId,
       r.Name Belt,
       r.Level,
       r.Kyu,
       e.EventId,
       e.Name EventName,
       e.EventTypeId,
       e.Date EventDate
	  ,f.Name DojoName
	  ,f.OwnerId
	  ,f.FacilityId
	  ,f.Name FacilityName
	  ,f.PhoneNumber FacilityPhoneNumber
	  ,f.Email FacilityEmail
	  ,f.StreetAddress1 FacilityStreetAddress1
	  ,f.StreetAddress2 FacilityStreetAddress2
	  ,f.AppartmentCode FacilityAppartmentCode
	  ,f.City FacilityCity
	  ,f.StateProvidence FacilityStateProvidence
	  ,f.PostalCode FacilityPostalCode
	  ,f.Country FacilityCountry
	  ,ft.FacilityTypeId
	  ,ft.Name FacilityTypeName
	  ,ownr.FirstName OwnerFirstName
	  ,ownr.LastName OwnerLastName
	  ,ownr.DisplayName OwnerDisplayName
	  ,mat.MartialArtTypeId
	  ,mat.Name MartialArtTypeName
	  ,c.OtherInstructorName
FROM Person.Competitor AS c
INNER JOIN Person.Person AS p ON p.PersonId = c.PersonId
LEFT JOIN Person.Person AS parent ON parent.PersonId = c.ParentId
INNER JOIN Event.Rank AS r ON r.RankId = c.RankId
INNER JOIN Event.Event AS e ON e.EventId = c.EventId
LEFT JOIN Facility.Dojo AS d ON d.DojoId = c.DojoId
LEFT JOIN Facility.Facility AS f ON f.FacilityId = d.FacilityId
LEFT JOIN Facility.FacilityType AS ft ON ft.FacilityTypeId = f.FacilityTypeId
LEFT JOIN Person.Person ownr ON ownr.PersonId = f.OwnerId
LEFT JOIN Person.Title AS t ON t.TitleId = p.TitleId
LEFT JOIN Facility.MartialArtType AS mat ON mat.MartialArtTypeId = d.MartialArtTypeId
