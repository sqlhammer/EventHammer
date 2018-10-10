CREATE VIEW Event.vwMatchCompetitorDetail
AS
SELECT mc.MatchCompetitorId
	  ,m.MatchId
	  ,m.MatchDisplayId
	  ,mc.CompetitorId
	  ,mc.MatchPlacement
	  ,m.EventId
	  ,m.MatchTypeId
	  ,m.DivisionId
	  ,m.SubDivisionId
	  ,mt.Name MatchTypeName
	  ,mt.IsSpecialConsideration MatchIsSpecialConsideration
	  ,e.Name EventName
	  ,e.EventTypeId
	  ,e.Date EventDate
	  ,et.Name EventTypeName
	  ,c.PersonId
	  ,c.DateOfBirth
	  ,c.Age
	  ,c.Weight
	  ,c.Height
	  ,c.DojoId
	  ,c.OtherDojoName
	  ,c.IsMinor
	  ,c.IsSpecialConsideration
	  ,c.IsKata
	  ,c.IsWeaponKata
	  ,c.IsSemiKnockdown
	  ,c.IsKnockdown
	  ,per.FirstName
	  ,per.LastName
	  ,per.DisplayName
	  ,per.IsInstructor
	  ,per.Gender
	  ,per.PhoneNumber
	  ,per.EmailAddress
	  ,per.StreetAddress1
	  ,per.StreetAddress2
	  ,per.AppartmentCode
	  ,per.City
	  ,per.StateProvince
	  ,per.PostalCode
	  ,per.Country
	  ,par.PersonId ParentId
	  ,par.FirstName ParentFirstName
	  ,par.LastName ParentLastName
	  ,par.DisplayName ParentDisplayName
	  ,par.EmailAddress ParentEmailAddress
	  ,r.RankId
	  ,r.Name Belt
	  ,r.Level
	  ,r.Kyu
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
	  ,t.TitleId
	  ,t.Name TitleName
	  ,t_owner.TitleId OwnerTitleId
	  ,t_owner.Name OwnerTitleName
	  ,d.MinimumWeight_lb
	  ,d.MaximumWeight_lb
	  ,d.WeightClass
	  ,d.Gender DivisionGender
	  ,d.MinimumLevelId
	  ,d.MaximumLevelId
	  ,d.MinimumAge
	  ,d.MaximumAge
	  ,d.IsKata DivisionIsKata
	  ,d_max_r.Name DivisionMaxBelt
	  ,d_max_r.Level DivisionMaxLevel
	  ,d_max_r.Kyu DivisionMaxKyu
	  ,d_min_r.Name DivisionMinBelt
	  ,d_min_r.Level DivisionMinLevel
	  ,d_min_r.Kyu DivisionMinKyu
	  ,mat.MartialArtTypeId
	  ,mat.Name MartialArtTypeName
	  ,c.OtherInstructorName
FROM Event.Match m
LEFT JOIN Event.MatchCompetitor mc ON m.MatchId = mc.MatchId
LEFT JOIN Event.MatchType mt ON mt.MatchTypeId = m.MatchTypeId
LEFT JOIN Event.Event e ON e.EventId = m.EventId
LEFT JOIN Event.EventType et ON et.EventTypeId = e.EventTypeId
LEFT JOIN Person.Competitor c ON c.CompetitorId = mc.CompetitorId
LEFT JOIN Person.Person per ON per.PersonId = c.PersonId
LEFT JOIN Person.Person par ON par.PersonId = c.ParentId
LEFT JOIN Event.Rank r ON r.RankId = c.RankId
LEFT JOIN Facility.Dojo dojo ON dojo.DojoId = c.DojoId
LEFT JOIN Facility.Facility f ON dojo.DojoId = f.FacilityId
LEFT JOIN Facility.FacilityType ft ON ft.FacilityTypeId = f.FacilityTypeId
LEFT JOIN Facility.MartialArtType mat ON dojo.MartialArtTypeId = mat.MartialArtTypeId
LEFT JOIN Person.Person ownr ON ownr.PersonId = f.OwnerId
LEFT JOIN Person.Title t ON t.TitleId = per.TitleId
LEFT JOIN Person.Title t_owner ON t_owner.TitleId = ownr.TitleId
LEFT JOIN Event.Division d ON d.DivisionId = m.DivisionId
LEFT JOIN Event.Rank d_min_r ON d_min_r.RankId = d.MinimumLevelId
LEFT JOIN Event.Rank d_max_r ON d_max_r.RankId = d.MaximumLevelId