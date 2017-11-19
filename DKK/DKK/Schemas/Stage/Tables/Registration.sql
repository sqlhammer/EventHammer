CREATE TABLE [Stage].[Registration]
(
	[FirstName] NVARCHAR(60) NOT NULL
	,[LastName] NVARCHAR(60) NOT NULL
	,[Rank] TINYINT NOT NULL
	,[Age] TINYINT NOT NULL
	,DateOfBirth DATE NULL
	,[Weight] DECIMAL(5,2) NOT NULL
	,[IsMinor] BIT NOT NULL
	,[Street1] NVARCHAR(128) NULL
	,[Street2] NVARCHAR(128) NULL
	,AppartmentCode NVARCHAR(10) NULL
	,[City] NVARCHAR(128) NULL
	,[StateProvince] NVARCHAR(128) NULL
	,[PostalCode] NVARCHAR(128) NULL
	,[Country] NVARCHAR(128) NULL
	,[IsKata] BIT NOT NULL
	,[IsWeaponKata] BIT NOT NULL
	,[IsSemiKnockdown] BIT NOT NULL
	,[IsKnockdown] BIT NOT NULL
	,[DojoName] NVARCHAR(60) NOT NULL
	,[EmailAddress] NVARCHAR(128) NULL
	,[Gender] CHAR NOT NULL
	,[PhoneNumber] NVARCHAR(15) NULL
	,[MartialArtName] NVARCHAR(60) NOT NULL
	,[ParentFirstName] NVARCHAR(60) NOT NULL
	,[ParentLastName] NVARCHAR(60) NOT NULL
	,[ParentEmailAddress] NVARCHAR(128) NULL
	,IsSpecialConsideration BIT NOT NULL
)
