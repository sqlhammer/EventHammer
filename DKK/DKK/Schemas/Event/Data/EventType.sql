
SET IDENTITY_INSERT [Event].[EventType] ON

MERGE INTO [Event].[EventType] AS [target]
USING
(VALUES
(1, 'Tournament')
)
AS [source] ([EventTypeId], [Name])
ON [target].[EventTypeId] = [source].[EventTypeId]

WHEN MATCHED THEN
UPDATE 
	SET [Name] = [source].[Name]

WHEN NOT MATCHED BY TARGET THEN
	INSERT ([EventTypeId], [Name])
	VALUES ([EventTypeId], [Name])

WHEN NOT MATCHED BY SOURCE THEN
	DELETE;

SET IDENTITY_INSERT [Event].[EventType] OFF
