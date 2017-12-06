
CREATE TABLE [Event].[Division]
(
	[DivisionId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY
	,MinimumWeight_lb DECIMAL(5,2) NOT NULL
	,MaximumWeight_lb DECIMAL(5,2) NOT NULL
	,WeightClass NVARCHAR(10) NOT NULL
	,Gender CHAR NOT NULL
	,MinimumLevelId INT NOT NULL CONSTRAINT FK_Event_Division_MinimumLevelId FOREIGN KEY REFERENCES [Event].[Rank] (RankId)
	,MaximumLevelId INT NOT NULL CONSTRAINT FK_Event_Division_MaximumLevelId FOREIGN KEY REFERENCES [Event].[Rank] (RankId)
	,MinimumAge TINYINT NULL
	,MaximumAge TINYINT NULL
	,IsKata BIT NOT NULL
)
