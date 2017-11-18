
SET IDENTITY_INSERT [Facility].[FacilityType] ON

MERGE INTO [Facility].[FacilityType] AS [target]
USING
(VALUES
(1, 'Dojo'),
(2, 'Venue')
)
AS [source] ([FacilityTypeId], [Name])
ON [target].[FacilityTypeId] = [source].[FacilityTypeId]

WHEN MATCHED THEN
UPDATE 
	SET [Name] = [source].[Name]

WHEN NOT MATCHED BY TARGET THEN
	INSERT ([FacilityTypeId], [Name])
	VALUES ([FacilityTypeId], [Name])

WHEN NOT MATCHED BY SOURCE THEN
	DELETE;

SET IDENTITY_INSERT [Facility].[FacilityType] OFF
