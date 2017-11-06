CREATE TABLE [Facility].[Facility]
(
	[FacilityId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY
	,[Name] NVARCHAR(120) NOT NULL
	,AddressId INT NOT NULL CONSTRAINT FK_Person_Address_AddressId FOREIGN KEY REFERENCES Person.[Address] (AddressId)
	,PhoneNumber NVARCHAR(15) NULL --TODO: Check Constraint for format
	,Email NVARCHAR(255) NULL --TODO: Check Constraint for format
	,OwnerId INT NULL CONSTRAINT FK_Facility_Facility_OwnerId FOREIGN KEY REFERENCES Person.Person (PersonId)
	,FacilityTypeId INT NOT NULL CONSTRAINT FK_Facility_Facility_FacilityTypeId FOREIGN KEY REFERENCES Facility.FacilityType (FacilityTypeId)
)
