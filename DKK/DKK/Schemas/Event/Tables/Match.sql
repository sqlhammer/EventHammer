CREATE TABLE [Event].[Match]
(
	[MatchId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY
	,EventId INT NOT NULL CONSTRAINT FK_Event_Match_EventId FOREIGN KEY REFERENCES [Event].[Event] (EventId)
	,MatchTypeId INT NOT NULL CONSTRAINT FK_Event_Match_MatchTypeId FOREIGN KEY REFERENCES [Event].[MatchType] (MatchTypeId)
	,DivisionId INT NOT NULL CONSTRAINT FK_Event_Division_DivisionId FOREIGN KEY REFERENCES [Event].[Division] (DivisionId)
	,MinimumAge TINYINT NULL
	,MaximumAge TINYINT NULL
	,TimeLimit_Sec INT NULL
	,MinimumLevelId INT NOT NULL CONSTRAINT FK_Event_Rank_MinimumLevelId FOREIGN KEY REFERENCES [Event].[Rank] (RankId)
	,MaximumLevelId INT NOT NULL CONSTRAINT FK_Event_Rank_MaximumLevelId FOREIGN KEY REFERENCES [Event].[Rank] (RankId)
)
