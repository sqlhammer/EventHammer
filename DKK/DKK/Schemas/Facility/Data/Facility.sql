
SET IDENTITY_INSERT [Facility].[Facility] ON

MERGE INTO [Facility].[Facility] AS [target]
USING
(VALUES
(1, 'Police Athletics League', '12037784725', NULL, NULL, 2, '35 Hayestown Rd', NULL, NULL, 'Danbury', 'CT', '06811', 'USA'),
(2, 'Alam Kanreikai', NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(3, 'Brooklyn Kyokushin Karate', NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(4, 'Busiken Karate', NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(5, 'CT Budo Karate', NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(6, 'Danbury Kanreikai Karate', NULL, NULL, NULL, 1, NULL, NULL, NULL, 'Danbury', 'CT', '06811', 'USA'),
(7, 'Fighting Spirit Karate', NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(8, 'Grey Wolf Kyokushin', NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(9, 'Halifax Kanreikai Karate', NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(10, 'Japanese Karate', NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(11, 'Joilette Kanreikei Karate', NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(12, 'Jonquiere Kanreikai Karate', NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(13, 'Karate Kyokushin Quebec', NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(14, 'Karate Kyokushin St-Luc', NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(15, 'Karate Realite', NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(16, 'Karate-Do Iwata Dojo', NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(17, 'Karate-Do Ken Wa Kan', NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(18, 'Kyokushin Karate', NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(19, 'Maine Kyokushin Karate', NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(20, 'Montreal Kanreikai Karate', NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(21, 'N.A.K.O.', NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(22, 'Nazuka Dojo', NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(23, 'New Britian Kyokushin Kan Karate', NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(24, 'New Canaan Kanreikai Karate', NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(25, 'New York Kanreikai Karate', NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(26, 'Performance Fitness', NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(27, 'Ravena Kanreikai Karate', NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(28, 'Russo Dojo', NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(29, 'Saint-Cyr Dojo', NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(30, 'Saw Creek Kyokushin Karate', NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(31, 'USA Sieshin Assoc of Kyokushin Karate', NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(32, 'Vaudreuil Kanreikai Karate', NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(33, 'Westchester Kyokushin', NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(34, 'Western Maine Budo Arts', NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
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
