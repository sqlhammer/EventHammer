CREATE TABLE [Facility].[Dojo]
(
	[DojoId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY
	,FacilityId INT NOT NULL CONSTRAINT FK_Facility_Dojo_FacilityId FOREIGN KEY REFERENCES Facility.Facility (FacilityId)
	,[MartialArtTypeId] INT NOT NULL CONSTRAINT FK_Facility_Dojo_MartialArtTypeId FOREIGN KEY REFERENCES Person.MartialArtType (MartialArtTypeId)
)
