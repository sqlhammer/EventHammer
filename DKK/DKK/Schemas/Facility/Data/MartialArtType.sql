
SET IDENTITY_INSERT [Facility].[MartialArtType] ON

MERGE INTO [Facility].[MartialArtType] AS [target]
USING
(VALUES
(1, 'American Karate'),
(2, 'Bu Do Jutsu'),
(3, 'Elite Martial Arts'),
(4, 'Goju Yushukan'),
(5, 'Hapkido'),
(6, 'Indara Kakutoujuku'),
(7, 'Kanreikai'),
(8, 'Karate Martin Bernier'),
(9, 'Karate realite'),
(11, 'Kenshikai'),
(12, 'Koyama'),
(13, 'Kung Fu'),
(14, 'Kyodan Karate'),
(15, 'Kyokushinkai'),
(16, 'Me Sen Karate-Do'),
(17, 'Nazuka Dojo-Karate Do'),
(18, 'Oyama'),
(19, 'Real Fighting Dojo'),
(20, 'Seiryoku'),
(21, 'Shorin Kenpo Karate'),
(22, 'Toshindo')
)
AS [source] ([MartialArtTypeId], [Name])
ON [target].[MartialArtTypeId] = [source].[MartialArtTypeId]

WHEN MATCHED THEN
UPDATE 
	SET [Name] = [source].[Name]

WHEN NOT MATCHED BY TARGET THEN
	INSERT ([MartialArtTypeId], [Name])
	VALUES ([MartialArtTypeId], [Name])

WHEN NOT MATCHED BY SOURCE THEN
	DELETE;

SET IDENTITY_INSERT [Facility].[MartialArtType] OFF
