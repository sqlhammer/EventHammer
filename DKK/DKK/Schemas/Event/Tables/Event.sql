CREATE TABLE [Event].[Event]
(
	[EventId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY
	,[Name] NVARCHAR(30) NOT NULL
	,EventTypeId INT NOT NULL CONSTRAINT FK_Event_Event_EventTypeId FOREIGN KEY REFERENCES [Event].EventType (EventTypeId)
	,[Date] DATE NOT NULL
)
GO
CREATE UNIQUE NONCLUSTERED INDEX UQ_Event_Event_Name_Date
ON [Event].[Event] ([Date],[Name])
GO
