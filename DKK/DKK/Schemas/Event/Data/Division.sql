
IF OBJECT_ID('tempdb..#BaseDivision') IS NOT NULL
	DROP TABLE #BaseDivision;

CREATE TABLE #BaseDivision
(
	MinimumWeight_lb DECIMAL(5,2) NOT NULL
	,MaximumWeight_lb DECIMAL(5,2) NOT NULL
	,WeightClass NVARCHAR(10) NOT NULL
	,Gender CHAR NOT NULL
)

INSERT INTO #BaseDivision ( MinimumWeight_lb, MaximumWeight_lb, WeightClass, Gender )
VALUES
	(0.00, 129.99, 'Light', 'F'),
	(130.00, 149.99, 'Middle', 'F'),
	(150.00, 400.00, 'Heavy', 'F'),
	(0.00, 159.99, 'Light', 'M'),
	(160.00, 179.99, 'Middle', 'M'),
	(180.00, 500.00, 'Heavy', 'M')

IF OBJECT_ID('tempdb..#KataDivision') IS NOT NULL
	DROP TABLE #KataDivision;

CREATE TABLE #KataDivision
(
	MinimumWeight_lb DECIMAL(5,2) NOT NULL
	,MaximumWeight_lb DECIMAL(5,2) NOT NULL
	,WeightClass NVARCHAR(10) NOT NULL
	,Gender CHAR NOT NULL
)

INSERT INTO #KataDivision ( MinimumWeight_lb, MaximumWeight_lb, WeightClass, Gender )
VALUES
	(0.00, 500.00, 'Kata', 'F'),
	(0.00, 500.00, 'Kata', 'M')

IF OBJECT_ID('tempdb..#Ages') IS NOT NULL
	DROP TABLE #Ages;

CREATE TABLE #Ages
(
	MinimumAge TINYINT NOT NULL
	,MaximumAge TINYINT NOT NULL
)

INSERT INTO #Ages ( MinimumAge, MaximumAge )
VALUES
	( 5, 7 ),
	( 7, 9 ),
	( 9, 11 ),
	( 11, 14 ),
	( 13, 16 ),
	( 16, 18 ),
	( 18, 255 )

IF OBJECT_ID('tempdb..#Ranks') IS NOT NULL
	DROP TABLE #Ranks;

CREATE TABLE #Ranks
(
	MinimumLevelId INT NOT NULL
	,MaximumLevelId INT NOT NULL
)

INSERT INTO #Ranks ( MinimumLevelId, MaximumLevelId )
VALUES
	( 1, 4 ),
	( 4, 7 ),
	( 7, 9 ),
	( 9, 11 )

IF OBJECT_ID('tempdb..#Division') IS NOT NULL
	DROP TABLE #Division

SELECT IDENTITY(INT, 1, 1) AS DivisionId
	,MinimumWeight_lb
	,MaximumWeight_lb
	,WeightClass
	,Gender
	,MinimumAge
	,MaximumAge
	,MinimumLevelId
	,MaximumLevelId
	,IsKata
INTO #Division
FROM
(
	SELECT
		bd.MinimumWeight_lb
		,bd.MaximumWeight_lb
		,bd.WeightClass
		,bd.Gender
		,MinimumAge
		,MaximumAge
		,MinimumLevelId
		,MaximumLevelId
		,0 IsKata
	FROM #BaseDivision bd
	CROSS APPLY #Ages
	CROSS APPLY #Ranks
	UNION ALL
	SELECT
		kd.MinimumWeight_lb
		,kd.MaximumWeight_lb
		,kd.WeightClass
		,kd.Gender
		,MinimumAge
		,MaximumAge
		,MinimumLevelId
		,MaximumLevelId
		,1 IsKata
	FROM #KataDivision kd
	CROSS APPLY #Ages
	CROSS APPLY #Ranks
) dt;

SET IDENTITY_INSERT [Event].Division ON

MERGE INTO [Event].Division AS [target]
USING
(
	SELECT DivisionId
		,MinimumWeight_lb
		,MaximumWeight_lb
		,WeightClass
		,Gender
		,MinimumAge
		,MaximumAge
		,MinimumLevelId
		,MaximumLevelId
		,IsKata
	FROM #Division
)
AS [source] (DivisionId, MinimumWeight_lb, MaximumWeight_lb, WeightClass, Gender
	, MinimumAge, MaximumAge,MinimumLevelId, MaximumLevelId, IsKata )
ON [target].DivisionId = [source].DivisionId

WHEN MATCHED THEN
UPDATE 
	SET MinimumWeight_lb = [source].MinimumWeight_lb,
		MaximumWeight_lb = [source].MaximumWeight_lb,
		WeightClass = [source].WeightClass,
		Gender = [source].Gender,
		MinimumLevelId = [source].MinimumLevelId, 
		MaximumLevelId = [source].MaximumLevelId, 
		MinimumAge = [source].MinimumAge, 
		MaximumAge = [source].MaximumAge,
		IsKata = [source].IsKata

WHEN NOT MATCHED BY TARGET THEN
	INSERT (DivisionId, MinimumWeight_lb, MaximumWeight_lb, WeightClass, Gender
		, MinimumLevelId, MaximumLevelId, MinimumAge, MaximumAge, IsKata)
	VALUES (DivisionId, MinimumWeight_lb, MaximumWeight_lb, WeightClass, Gender
		, MinimumLevelId, MaximumLevelId, MinimumAge, MaximumAge, IsKata)

WHEN NOT MATCHED BY SOURCE THEN
	DELETE;

SET IDENTITY_INSERT [Event].Division OFF
