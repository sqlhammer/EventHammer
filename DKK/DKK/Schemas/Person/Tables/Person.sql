CREATE TABLE [Person].[Person]
(
	[PersonId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY
	,[FirstName] NVARCHAR(60) NOT NULL
	,[LastName] NVARCHAR(60) NOT NULL
	,DisplayName NVARCHAR(130) NOT NULL
	,TitleId INT NULL CONSTRAINT FK_Person_Title_TitleId FOREIGN KEY REFERENCES Person.Title (TitleId)
	,IsInstructor BIT NOT NULL CONSTRAINT DF_Person_Person_IsInstructor DEFAULT(0)
	,Gender CHAR NULL
	,PhoneNumber NVARCHAR(15) NULL --TODO: Check Constraint for format
	,EmailAddress NVARCHAR(255) NULL --TODO: Check Constraint for format
	,StreetAddress1 NVARCHAR(255) NULL
	,StreetAddress2 NVARCHAR(255) NULL
	,AppartmentCode NVARCHAR(10) NULL
	,City NVARCHAR(30) NULL
	,StateProvince NVARCHAR(30) NULL
	,PostalCode NVARCHAR(10) NULL
	,Country NVARCHAR(30) NULL
)
GO
CREATE UNIQUE NONCLUSTERED INDEX UQ_Person_Person_FirstName_LastName_Email
ON Person.Person (EmailAddress, LastName, FirstName);
GO
