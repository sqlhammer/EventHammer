
SET IDENTITY_INSERT [Facility].[Dojo] ON

MERGE INTO [Facility].[Dojo] AS [target]
USING
(VALUES
(1, 1, 1),
(2, 2, 7),
(3, 3, 24),
(4, 4, 24),
(5, 5, 24),
(6, 6, 7),
(7, 7, 25),
(8, 8, 24),
(9, 9, 7),
(10, 10, 24),
(11, 11, 7),
(12, 12, 7),
(13, 13, 24),
(14, 14, 24),
(15, 15, 24),
(16, 16, 24),
(17, 17, 25),
(18, 18, 24),
(19, 19, 24),
(20, 20, 7),
(21, 21, 24),
(22, 22, 24),
(23, 23, 24),
(24, 24, 7),
(25, 25, 7),
(26, 26, 23),
(27, 27, 7),
(28, 28, 24),
(29, 29, 24),
(30, 30, 24),
(31, 31, 24),
(32, 32, 7),
(33, 33, 24),
(34, 34, 24)
)
AS [source] ([DojoId], [FacilityId], [MartialArtTypeId])
ON [target].[DojoId] = [source].[DojoId]

WHEN MATCHED THEN
UPDATE 
	SET [FacilityId] = [source].[FacilityId],
		[MartialArtTypeId] = [source].[MartialArtTypeId]

WHEN NOT MATCHED BY TARGET THEN
	INSERT ([DojoId], [FacilityId], [MartialArtTypeId])
	VALUES ([DojoId], [FacilityId], [MartialArtTypeId])

WHEN NOT MATCHED BY SOURCE THEN
	DELETE;

SET IDENTITY_INSERT [Facility].[Dojo] OFF
