CREATE TABLE [Person].[Competitor]
(
	[CompetitorId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY
	,PersonId INT NOT NULL CONSTRAINT FK_Person_Person_PersonId FOREIGN KEY REFERENCES Person.Person (PersonId)
	,DateOfBirth DATE NULL
	,Age TINYINT NOT NULL
	,[Weight] DECIMAL(5,2) NOT NULL
	,[Height] DECIMAL(5,2) NOT NULL
	,RankId INT NOT NULL CONSTRAINT FK_Person_Rank_RankId FOREIGN KEY REFERENCES [Event].[Rank] (RankId)
	,DojoId INT NOT NULL CONSTRAINT FK_Facility_Dojo_DojoId FOREIGN KEY REFERENCES Facility.Dojo (DojoId)
	,ParentId INT NULL CONSTRAINT FK_Person_Person_ParentId FOREIGN KEY REFERENCES Person.Person (PersonId)
	,IsMinor BIT NOT NULL CONSTRAINT DF_Person_Competitor_IsMinor DEFAULT(0)
	,IsSpecialConsideration BIT NOT NULL CONSTRAINT DF_Person_Competitor_IsSpecialConsideration DEFAULT(0)
    ,[EventId] INT NOT NULL CONSTRAINT FK_Event_Event_EventId FOREIGN KEY REFERENCES [Event].[Event] (EventId)
	,[IsKata] BIT NOT NULL CONSTRAINT DF_Person_Competitor_IsKata DEFAULT(0)
	,[IsWeaponKata] BIT NOT NULL CONSTRAINT DF_Person_Competitor_IsWeaponKata DEFAULT(0)
	,[IsSemiKnockdown] BIT NOT NULL CONSTRAINT DF_Person_Competitor_IsSemiKnockdown DEFAULT(0)
	,[IsKnockdown] BIT NOT NULL CONSTRAINT DF_Person_Competitor_IsKnockdown DEFAULT(0)
)
