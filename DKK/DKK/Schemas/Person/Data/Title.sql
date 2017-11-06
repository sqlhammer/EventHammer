
SET IDENTITY_INSERT [Person].[Title] ON

MERGE INTO [Person].[Title] AS [target]
USING
(VALUES
(1, 'Sensei'),
(2, 'Sempai'),
(3, 'Shihan'),
(4, 'Kancho'),
(5, 'Soshu'),
(6, 'Saikoshihan'),
(7, 'Master'),
(8, 'Doshu'),
(9, 'Renshi')
)
AS [source] (TitleId, [Name])
ON [target].TitleId = [source].TitleId

WHEN MATCHED THEN
UPDATE 
	SET [Name] = [source].[Name]

WHEN NOT MATCHED BY TARGET THEN
	INSERT (TitleId, [Name])
	VALUES (TitleId, [Name])

WHEN NOT MATCHED BY SOURCE THEN
	DELETE;

SET IDENTITY_INSERT [Person].[Title] OFF
