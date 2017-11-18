CREATE PROCEDURE [Stage].[spLoadPersonPerson]
	@param1 int = 0,
	@param2 int
AS
	BEGIN TRANSACTION

SELECT FirstName
	  ,LastName
	  ,Rank
	  ,Street1
	  ,Street2
	  ,City
	  ,StateProvince
	  ,PostalCode
	  ,Country
	  ,IsKata
	  ,IsSemiKnockdown
	  ,IsKnockdown
	  ,DojoName
	  ,EmailAddress
	  ,Gender
	  ,PhoneNumber
FROM Stage.TestPerson

--Person inserts
INSERT INTO Person.Person ( FirstName, LastName, DisplayName, TitleId, IsInstructor, Gender, PhoneNumber, Email, StreetAddress1, StreetAddress2, AppartmentCode, City, StateProvidence, PostalCode, Country )
SELECT FirstName
	  ,LastName
	  ,LastName + ', ' + FirstName
	  ,NULL
	  ,0
	  ,Gender
	  ,PhoneNumber
	  ,EmailAddress
	  ,Street1
	  ,Street2
	  ,AppartmentCode
	  ,City
	  ,StateProvince
	  ,PostalCode
	  ,Country
FROM Stage.TestPerson



ROLLBACK
