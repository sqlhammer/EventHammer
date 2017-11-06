
SET IDENTITY_INSERT [Event].MatchType ON

MERGE INTO [Event].MatchType AS [target]
USING
(VALUES
(1, 'Kata', 0),
(2, 'Weapon Kata', 0),
(3, 'Semi-Knockdown', 0),
(4, 'Knockdown', 0),
(5, 'Kata', 1),
(6, 'Weapon Kata', 1),
(7, 'Semi-Knockdown', 1),
(8, 'Knockdown', 1)
)
AS [source] ([MatchTypeId], [Name], IsSpecialConsideration)
ON [target].[MatchTypeId] = [source].[MatchTypeId]

WHEN MATCHED THEN
UPDATE 
	SET [Name] = [source].[Name],
		IsSpecialConsideration = [source].IsSpecialConsideration

WHEN NOT MATCHED BY TARGET THEN
	INSERT ([MatchTypeId], [Name], IsSpecialConsideration)
	VALUES ([MatchTypeId], [Name], IsSpecialConsideration)

WHEN NOT MATCHED BY SOURCE THEN
	DELETE;

SET IDENTITY_INSERT [Event].MatchType OFF
