CREATE TABLE [Event].[Match]
(
	[MatchId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY
	,EventId INT NOT NULL CONSTRAINT FK_Event_Match_EventId FOREIGN KEY REFERENCES [Event].[Event] (EventId)
	,MatchTypeId INT NOT NULL CONSTRAINT FK_Event_Match_MatchTypeId FOREIGN KEY REFERENCES [Event].[MatchType] (MatchTypeId)
	,DivisionId INT NOT NULL CONSTRAINT FK_Event_Division_DivisionId FOREIGN KEY REFERENCES [Event].[Division] (DivisionId)
	,SubDivisionId INT NOT NULL CONSTRAINT DF_Event_Match_SubDivisionId DEFAULT (1)
)
GO
CREATE UNIQUE INDEX UQ_Event_Match_DivisionId_SubDivisionId_MatchTypeId_EventId
ON [Event].[Match] (DivisionId, SubDivisionId, MatchTypeId, EventId)
GO