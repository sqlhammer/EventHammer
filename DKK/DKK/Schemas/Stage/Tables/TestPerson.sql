CREATE TABLE [Stage].[TestPerson]
(
	[FirstName] NVARCHAR(60) NOT NULL
	,[LastName] NVARCHAR(60) NOT NULL
	,[Rank] TINYINT NOT NULL
	,[Address] NVARCHAR(255) NULL
	,[IsKata] BIT NOT NULL
	,[IsSemiKnockdown] BIT NOT NULL
	,[IsKnockdown] BIT NOT NULL
)
