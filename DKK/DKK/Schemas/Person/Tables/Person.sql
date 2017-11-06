CREATE TABLE [Person].[Person]
(
	[PersonId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY
	,[FirstName] NVARCHAR(60) NOT NULL
	,[LastName] NVARCHAR(60) NOT NULL
	,DisplayName NVARCHAR(60) NOT NULL
	,TitleId INT NULL CONSTRAINT FK_Person_Title_TitleId FOREIGN KEY REFERENCES Person.Title (TitleId)
	,IsInstructor BIT NOT NULL CONSTRAINT DF_Person_Person_IsInstructor DEFAULT(0)
	,Gender CHAR NULL
	,PhoneNumber NVARCHAR(15) NULL --TODO: Check Constraint for format
	,Email NVARCHAR(255) NULL --TODO: Check Constraint for format
)
GO
