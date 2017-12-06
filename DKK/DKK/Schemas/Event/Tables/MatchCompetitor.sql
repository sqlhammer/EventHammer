CREATE TABLE [Event].[MatchCompetitor]
(
	[MatchCompetitorId] INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Event_MatchCompetitor_MatchCompetitorId PRIMARY KEY CLUSTERED
	,MatchId INT NOT NULL CONSTRAINT FK_Event_MatchCompetitor_MatchId FOREIGN KEY REFERENCES [Event].[Match] (MatchId)
	,CompetitorId INT NOT NULL CONSTRAINT FK_Event_MatchCompetitor_CompetitorId FOREIGN KEY REFERENCES Person.Competitor (CompetitorId)
	,MatchPlacement TINYINT NULL
	,EventId INT NOT NULL CONSTRAINT FK_Event_MatchCompetitor_EventId FOREIGN KEY REFERENCES [Event].[Event] (EventId)
)
