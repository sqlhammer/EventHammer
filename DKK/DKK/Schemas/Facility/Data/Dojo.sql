
SET IDENTITY_INSERT [Facility].[Dojo] ON

MERGE INTO [Facility].[Dojo] AS [target]
USING
(VALUES
(1, 1, 1),
(2, 2, 1),
(3, 3, 1)
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
