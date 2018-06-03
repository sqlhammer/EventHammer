
SET IDENTITY_INSERT [Facility].[Dojo] ON

MERGE INTO [Facility].[Dojo] AS [target]
USING
(VALUES
(1, 1, 1),
(2, 2, 1),
(3, 3, 1),
(4, 4, 1),
(5, 5, 1),
(6, 6, 7),
(7, 7, 1),
(8, 8, 1),
(9, 9, 1),
(10, 10, 1),
(11, 11, 1),
(12, 12, 1),
(13, 13, 1),
(14, 14, 1),
(15, 15, 1),
(16, 16, 1),
(17, 17, 1),
(18, 18, 1),
(19, 19, 1),
(20, 20, 1),
(21, 21, 1),
(22, 22, 1),
(23, 23, 1),
(24, 24, 1),
(25, 25, 1),
(26, 26, 1),
(27, 27, 1),
(28, 28, 1),
(29, 29, 1),
(30, 30, 1),
(31, 31, 1),
(32, 32, 1),
(33, 33, 1),
(34, 34, 1)
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
