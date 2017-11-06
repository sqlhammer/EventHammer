
SET IDENTITY_INSERT [Event].Division ON

MERGE INTO [Event].Division AS [target]
USING
(VALUES
(1, 0.00, 129.99, 'Light', 'F'),
(2, 130.00, 149.99, 'Middle', 'F'),
(3, 150.00, 400.00, 'Heavy', 'F'),
(4, 0.00, 159.99, 'Light', 'M'),
(5, 160.00, 179.99, 'Middle', 'M'),
(6, 180.00, 500.00, 'Heavy', 'M')
)
AS [source] (DivisionId, MinimumWeight_lb, MaximumWeight_lb, WeightClass, Gender)
ON [target].DivisionId = [source].DivisionId

WHEN MATCHED THEN
UPDATE 
	SET MinimumWeight_lb = [source].MinimumWeight_lb,
		MaximumWeight_lb = [source].MaximumWeight_lb,
		WeightClass = [source].WeightClass,
		Gender = [source].Gender

WHEN NOT MATCHED BY TARGET THEN
	INSERT (DivisionId, MinimumWeight_lb, MaximumWeight_lb, WeightClass, Gender)
	VALUES (DivisionId, MinimumWeight_lb, MaximumWeight_lb, WeightClass, Gender)

WHEN NOT MATCHED BY SOURCE THEN
	DELETE;

SET IDENTITY_INSERT [Event].Division OFF
