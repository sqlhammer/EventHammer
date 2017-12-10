CREATE TABLE [Event].[Match]
(
	[MatchId] INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Event_Match_MatchId PRIMARY KEY CLUSTERED
	,MatchDisplayId INT NOT NULL
	,EventId INT NOT NULL CONSTRAINT FK_Event_Match_EventId FOREIGN KEY REFERENCES [Event].[Event] (EventId)
	,MatchTypeId INT NOT NULL CONSTRAINT FK_Event_Match_MatchTypeId FOREIGN KEY REFERENCES [Event].[MatchType] (MatchTypeId)
	,DivisionId INT NOT NULL CONSTRAINT FK_Event_Division_DivisionId FOREIGN KEY REFERENCES [Event].[Division] (DivisionId)
	,SubDivisionId INT NOT NULL CONSTRAINT DF_Event_Match_SubDivisionId DEFAULT (1)
)
GO
CREATE UNIQUE INDEX UQ_Event_Match_MatchDisplayId_EventId
ON [Event].[Match] (MatchDisplayId, SubDivisionId, EventId)
GO
