
IF OBJECT_ID('tempdb..#Division') IS NOT NULL
	DROP TABLE #Division;

CREATE TABLE #Division(
	[DivisionId] [int] NOT NULL PRIMARY KEY CLUSTERED,
	[MinimumWeight_lb] [decimal](5, 2) NOT NULL,
	[MaximumWeight_lb] [decimal](5, 2) NOT NULL,
	[WeightClass] [nvarchar](20) NOT NULL,
	[Gender] [char](1) NULL,
	[MinimumLevelId] [int] NOT NULL,
	[MaximumLevelId] [int] NOT NULL,
	[MinimumAge] [tinyint] NULL,
	[MaximumAge] [tinyint] NULL,
	[IsKata] [bit] NOT NULL, 
    [IsWeaponKata] BIT NOT NULL, 
    [IsSemiKnockdown] BIT NOT NULL, 
    [IsKnockdown] BIT NOT NULL
) 


--Black belt kata
INSERT INTO #Division
(
	[DivisionId],
    MinimumWeight_lb,
    MaximumWeight_lb,
    WeightClass,
    Gender,
    MinimumLevelId,
    MaximumLevelId,
    MinimumAge,
    MaximumAge,
    IsKata, 
    [IsWeaponKata], 
    [IsSemiKnockdown], 
    [IsKnockdown]
)
VALUES
(   1, 0, 500, 'Kata', NULL, 11, 11, 18, 120, 1, 0, 0, 0   )


--Weapon kata divisions
INSERT INTO #Division
(
	[DivisionId],
    MinimumWeight_lb,
    MaximumWeight_lb,
    WeightClass,
    Gender,
    MinimumLevelId,
    MaximumLevelId,
    MinimumAge,
    MaximumAge,
    IsKata, 
    [IsWeaponKata], 
    [IsSemiKnockdown], 
    [IsKnockdown]
)
VALUES
(   2, 0, 500, 'Kata', NULL, 5, 11, 5, 13, 0, 1, 0, 0   ),
(   3, 0, 500, 'Kata', NULL, 5, 11, 14, 17, 0, 1, 0, 0   ),
(   4, 0, 500, 'Kata', NULL, 5, 11, 18, 120, 0, 1, 0, 0   )


--Kata
INSERT INTO #Division
(
	[DivisionId],
    MinimumWeight_lb,
    MaximumWeight_lb,
    WeightClass,
    Gender,
    MinimumLevelId,
    MaximumLevelId,
    MinimumAge,
    MaximumAge,
    IsKata, 
    [IsWeaponKata], 
    [IsSemiKnockdown], 
    [IsKnockdown]
)
VALUES
(   5, 0, 500, 'Kata', NULL, 1, 11, 5, 5, 1, 0, 0, 0   ),
(   6, 0, 500, 'Kata', NULL, 1, 6, 6, 7, 1, 0, 0, 0   ),
(   7, 0, 500, 'Kata', NULL, 7, 11, 6, 7, 1, 0, 0, 0   ),
(   8, 0, 500, 'Kata', NULL, 1, 6, 8, 9, 1, 0, 0, 0   ),
(   9, 0, 500, 'Kata', NULL, 7, 11, 8, 9, 1, 0, 0, 0   ),
(   10, 0, 500, 'Kata', NULL, 1, 6, 10, 11, 1, 0, 0, 0   ),
(   11, 0, 500, 'Kata', NULL, 7, 11, 10, 11, 1, 0, 0, 0   ),
(   12, 0, 500, 'Kata', NULL, 1, 6, 12, 13, 1, 0, 0, 0   ),
(   13, 0, 500, 'Kata', NULL, 7, 11, 12, 13, 1, 0, 0, 0   ),
(   14, 0, 500, 'Kata', NULL, 1, 6, 14, 15, 1, 0, 0, 0   ),
(   15, 0, 500, 'Kata', NULL, 7, 11, 14, 15, 1, 0, 0, 0   ),
(   16, 0, 500, 'Kata', NULL, 1, 6, 16, 17, 1, 0, 0, 0   ),
(   17, 0, 500, 'Kata', NULL, 7, 11, 16, 17, 1, 0, 0, 0   ),
(   18, 0, 500, 'Kata', NULL, 1, 6, 18, 120, 1, 0, 0, 0   ),
(   19, 0, 500, 'Kata', NULL, 7, 10, 18, 120, 1, 0, 0, 0   )


--semi knowndown
INSERT INTO #Division
(
	[DivisionId],
    MinimumWeight_lb,
    MaximumWeight_lb,
    WeightClass,
    Gender,
    MinimumLevelId,
    MaximumLevelId,
    MinimumAge,
    MaximumAge,
    IsKata, 
    [IsWeaponKata], 
    [IsSemiKnockdown], 
    [IsKnockdown]
)
VALUES
(   20, 0, 500, 'Fighting', NULL, 1, 11, 5, 5, 0, 0, 1, 0   ),
(   21, 0, 500, 'Fighting', 'M', 1, 6, 6, 7, 0, 0, 1, 0   ),
(   22, 0, 500, 'Fighting', 'F', 1, 6, 6, 7, 0, 0, 1, 0   ),
(   23, 0, 500, 'Fighting', 'M', 7, 11, 6, 7, 0, 0, 1, 0   ),
(   24, 0, 500, 'Fighting', 'F', 7, 11, 6, 7, 0, 0, 1, 0   ),
(   25, 0, 500, 'Fighting', 'M', 1, 6, 8, 9, 0, 0, 1, 0   ),
(   26, 0, 500, 'Fighting', 'F', 1, 6, 8, 9, 0, 0, 1, 0   ),
(   27, 0, 500, 'Fighting', 'M', 7, 11, 8, 9, 0, 0, 1, 0   ),
(   28, 0, 500, 'Fighting', 'F', 7, 11, 8, 9, 0, 0, 1, 0   ),
(   29, 0, 500, 'Fighting', 'M', 1, 6, 10, 11, 0, 0, 1, 0   ),
(   30, 0, 500, 'Fighting', 'F', 1, 6, 10, 11, 0, 0, 1, 0   ),
(   31, 0, 500, 'Fighting', 'M', 7, 11, 10, 11, 0, 0, 1, 0   ),
(   32, 0, 500, 'Fighting', 'F', 7, 11, 10, 11, 0, 0, 1, 0   ),
(   33, 0, 500, 'Fighting', 'M', 1, 6, 12, 13, 0, 0, 1, 0   ),
(   34, 0, 500, 'Fighting', 'F', 1, 6, 12, 13, 0, 0, 1, 0   ),
(   35, 0, 500, 'Fighting', 'M', 7, 11, 12, 13, 0, 0, 1, 0   ),
(   36, 0, 500, 'Fighting', 'F', 7, 11, 12, 13, 0, 0, 1, 0   ),
(   37, 0, 500, 'Fighting', 'M', 1, 6, 14, 15, 0, 0, 1, 0   ),
(   38, 0, 500, 'Fighting', 'F', 1, 6, 14, 15, 0, 0, 1, 0   ),
(   39, 0, 500, 'Fighting', 'M', 7, 11, 14, 15, 0, 0, 1, 0   ),
(   40, 0, 500, 'Fighting', 'F', 7, 11, 14, 15, 0, 0, 1, 0   ),
(   41, 0, 500, 'Fighting', 'M', 1, 6, 16, 17, 0, 0, 1, 0   ),
(   42, 0, 500, 'Fighting', 'F', 1, 6, 16, 17, 0, 0, 1, 0   ),
(   43, 0, 500, 'Fighting', 'M', 7, 11, 16, 17, 0, 0, 1, 0   ),
(   44, 0, 500, 'Fighting', 'F', 7, 11, 16, 17, 0, 0, 1, 0   ),
(   45, 0, 500, 'Fighting', 'F', 1, 6, 18, 34, 0, 0, 1, 0   ),
(   46, 0, 500, 'Fighting', 'F', 7, 11, 18, 34, 0, 0, 1, 0   ),
(   47, 0, 160, 'Light', 'M', 1, 6, 18, 34, 0, 0, 1, 0   ),
(   48, 161, 180, 'Middle', 'M', 1, 6, 18, 34, 0, 0, 1, 0   ),
(   49, 181, 500, 'Heavy', 'M', 1, 6, 18, 34, 0, 0, 1, 0   ),
(   50, 0, 160, 'Light', 'M', 7, 11, 18, 34, 0, 0, 1, 0   ),
(   51, 161, 180, 'Middle', 'M', 7, 11, 18, 34, 0, 0, 1, 0   ),
(   52, 181, 500, 'Heavy', 'M', 7, 11, 18, 34, 0, 0, 1, 0   ),
(   53, 0, 500, 'Fighting', 'M', 1, 6, 35, 120, 0, 0, 1, 0   ),
(   54, 0, 500, 'Fighting', 'M', 7, 11, 35, 120, 0, 0, 1, 0   )


--Merge
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
		,[IsWeaponKata]
		,[IsSemiKnockdown]
		,[IsKnockdown]
	FROM #Division
)
AS [source] (DivisionId, MinimumWeight_lb, MaximumWeight_lb, WeightClass, Gender
	, MinimumAge, MaximumAge,MinimumLevelId, MaximumLevelId, IsKata,[IsWeaponKata],[IsSemiKnockdown],[IsKnockdown] )
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
		IsKata = [source].IsKata,
		[IsWeaponKata] = [source].[IsWeaponKata],
		[IsSemiKnockdown] = [source].[IsSemiKnockdown],
		[IsKnockdown] = [source].[IsKnockdown]

WHEN NOT MATCHED BY TARGET THEN
	INSERT (DivisionId, MinimumWeight_lb, MaximumWeight_lb, WeightClass, Gender
		, MinimumLevelId, MaximumLevelId, MinimumAge, MaximumAge, IsKata,[IsWeaponKata],[IsSemiKnockdown],[IsKnockdown])
	VALUES (DivisionId, MinimumWeight_lb, MaximumWeight_lb, WeightClass, Gender
		, MinimumLevelId, MaximumLevelId, MinimumAge, MaximumAge, IsKata,[IsWeaponKata],[IsSemiKnockdown],[IsKnockdown])

WHEN NOT MATCHED BY SOURCE THEN
	DELETE;

SET IDENTITY_INSERT [Event].Division OFF
