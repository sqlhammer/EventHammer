
SET IDENTITY_INSERT [Facility].[Facility] ON

MERGE INTO [Facility].[Facility] AS [target]
USING
(VALUES
(1, 'Kanreikai', NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, 'USA'),
(2, 'BigDojo', NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, 'USA'),
(3, 'AggressiveDojo', NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, 'Canada')
)
AS [source] ([FacilityId], [Name], PhoneNumber, Email, OwnerId, FacilityTypeId, StreetAddress1, StreetAddress2, AppartmentCode, City, StateProvidence, PostalCode, Country)
ON [target].[FacilityId] = [source].[FacilityId]

WHEN MATCHED THEN
UPDATE 
	SET [Name] = [source].[Name],
		PhoneNumber = [source].PhoneNumber,
		Email = [source].Email,
		OwnerId = [source].OwnerId,
		FacilityTypeId = [source].FacilityTypeId,
		StreetAddress1 = [source].StreetAddress1, 
		StreetAddress2 = [source].StreetAddress2, 
		AppartmentCode = [source].AppartmentCode, 
		City = [source].City, 
		StateProvidence = [source].StateProvidence, 
		PostalCode = [source].PostalCode, 
		Country = [source].Country

WHEN NOT MATCHED BY TARGET THEN
	INSERT ([FacilityId], [Name], PhoneNumber, Email, OwnerId, FacilityTypeId, StreetAddress1, StreetAddress2, AppartmentCode, City, StateProvidence, PostalCode, Country)
	VALUES ([FacilityId], [Name], PhoneNumber, Email, OwnerId, FacilityTypeId, StreetAddress1, StreetAddress2, AppartmentCode, City, StateProvidence, PostalCode, Country)

WHEN NOT MATCHED BY SOURCE THEN
	DELETE;

SET IDENTITY_INSERT [Facility].[Facility] OFF
