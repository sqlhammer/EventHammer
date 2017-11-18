CREATE TABLE [Facility].[Facility]
(
	[FacilityId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY
	,[Name] NVARCHAR(120) NOT NULL
	,PhoneNumber NVARCHAR(15) NULL --TODO: Check Constraint for format
	,Email NVARCHAR(255) NULL --TODO: Check Constraint for format
	,OwnerId INT NULL CONSTRAINT FK_Facility_Facility_OwnerId FOREIGN KEY REFERENCES Person.Person (PersonId)
	,FacilityTypeId INT NOT NULL CONSTRAINT FK_Facility_Facility_FacilityTypeId FOREIGN KEY REFERENCES Facility.FacilityType (FacilityTypeId)
	,StreetAddress1 NVARCHAR(255) NULL
	,StreetAddress2 NVARCHAR(255) NULL
	,AppartmentCode NVARCHAR(10) NULL
	,City NVARCHAR(30) NULL
	,StateProvidence NVARCHAR(30) NULL
	,PostalCode NVARCHAR(10) NULL
	,Country NVARCHAR(30) NULL
)
