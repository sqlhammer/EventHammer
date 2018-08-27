
SET IDENTITY_INSERT [Event].[Event] ON

MERGE INTO [Event].[Event] AS [target]
USING
(VALUES
(1, 'World Kanreikai Open', 1, '20181013')
)
AS [source] ([EventId] ,[Name] ,[EventTypeId] ,[Date])
ON [target].[EventId] = [source].[EventId]

WHEN MATCHED THEN
UPDATE 
	SET [Name] = [source].[Name],
		[EventTypeId]  = [source].[EventTypeId],
		[Date] = [source].[Date]

WHEN NOT MATCHED BY TARGET THEN
	INSERT ([EventId] ,[Name] ,[EventTypeId] ,[Date])
	VALUES ([EventId] ,[Name] ,[EventTypeId] ,[Date])

WHEN NOT MATCHED BY SOURCE THEN
	DELETE;

SET IDENTITY_INSERT [Event].[Event] OFF
