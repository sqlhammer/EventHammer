
IF OBJECT_ID('tempdb..#instructor') IS NOT NULL
	DROP TABLE #instructor;

CREATE TABLE #instructor
(
	[FirstName] [NVARCHAR](60) NOT NULL,
	[LastName] [NVARCHAR](60) NOT NULL,
	[DisplayName] [NVARCHAR](130) NOT NULL,
	[IsInstructor] [BIT] NOT NULL
)

INSERT INTO #instructor
(
	[FirstName]
	,[LastName]
	,[DisplayName]
	,[IsInstructor]
)
VALUES
('Clement', 'Bouchard', 'Bouchard, Clement', 1),
('Raul', 'Dueno', 'Dueno, Raul', 1),
('Mike', 'Skinner', 'Skinner, Mike', 1),
('Bob', 'Hopwood', 'Hopwood, Bob', 1),
('Manny', 'Matias', 'Matias, Manny', 1),
('Sean', 'Schenker', 'Schenker, Sean', 1),
('Karl', 'Biedlingmaier', 'Biedlingmaier, Karl', 1),
('John', 'Pendergast', 'Pendergast, John', 1),
('Kenji', 'Fujiwara', 'Fujiwara, Kenji', 1),
('Dominic', 'Morin', 'Morin, Dominic', 1),
('Carl', 'Tremblay', 'Tremblay, Carl', 1),
('Jonathan', 'Ouellet', 'Ouellet, Jonathan', 1),
('Fouad', 'El Harrif', 'El Harrif, Fouad', 1),
('Andre', 'Lafond', 'Lafond, Andre', 1),
('Hiro', 'Iwata', 'Iwata, Hiro', 1),
('Michelle', 'Gay', 'Gay, Michelle', 1),
('Anthony', 'Celestine', 'Celestine, Anthony', 1),
('Daiki', 'Nazuka', 'Nazuka, Daiki', 1),
('Jose', 'Irizariy', 'Irizariy, Jose', 1),
('Robert', 'Cuda', 'Cuda, Robert', 1),
('Jose', 'Cotton', 'Cotton, Jose', 1),
('Doug', 'Brown', 'Brown, Doug', 1),
('Calvin', 'Ortiz', 'Ortiz, Calvin', 1),
('Junior', 'Russo', 'Russo, Junior', 1),
('Sincere', 'Marvin', 'Sincere, Marvin', 1),
('Eric', 'Mercado', 'Mercado, Eric', 1),
('Philip', 'Lehram', 'Lehram, Philip', 1),
('Michael', 'Cordeiro', 'Cordeiro, Michael', 1),
('Claibourne', 'Henry', 'Henry, Claibourne', 1),
('Kristen', 'O''Connor', 'O''Connor, Kristen', 1)


INSERT INTO [Person].[Person]
(
	[FirstName]
	,[LastName]
	,[DisplayName]
	,[IsInstructor]
)
SELECT i.FirstName
	  ,i.LastName
	  ,i.DisplayName
	  ,i.IsInstructor
FROM #instructor i
LEFT JOIN Person.Person p 
	ON p.FirstName = i.FirstName 
		AND p.LastName = i.LastName 
		AND p.IsInstructor = i.IsInstructor
WHERE p.PersonId IS NULL;
