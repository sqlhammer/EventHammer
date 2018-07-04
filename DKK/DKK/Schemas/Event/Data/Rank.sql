
SET IDENTITY_INSERT [Event].[Rank] ON

MERGE INTO [Event].[Rank] AS [target]
USING
(VALUES
(1, 'White', 1, '10'),
(2, 'White Blue', 2, '9'),
(3, 'Blue', 3, '8'),
(4, 'Blue Yellow', 4, '7'),
(5, 'Yellow', 5, '6'),
(6, 'Orange', 6, '5'),
(7, 'Green', 7, '4'),
(8, 'Green Brown', 8, '3'),
(9, 'Brown', 9, '2'),
(10, 'Brown Black', 10, '1'),
(11, 'Black', 11, 'Dan')
)
AS [source] ([RankId], [Name], [Level], [Kyu])
ON [target].[RankId] = [source].[RankId]

WHEN MATCHED THEN
UPDATE 
	SET [Name] = [source].[Name],
		[Level] = [source].[Level],
		[Kyu] = [source].[Kyu]

WHEN NOT MATCHED BY TARGET THEN
	INSERT ([RankId], [Name], [Level], [Kyu])
	VALUES ([RankId], [Name], [Level], [Kyu])

WHEN NOT MATCHED BY SOURCE THEN
	DELETE;

SET IDENTITY_INSERT [Event].[Rank] OFF
