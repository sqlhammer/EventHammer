CREATE TABLE [Event].[MatchType]
(
	[MatchTypeId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY
	,[Name] NVARCHAR(30) NOT NULL
	,IsSpecialConsideration BIT NOT NULL
)
