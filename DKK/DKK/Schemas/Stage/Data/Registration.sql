TRUNCATE TABLE Stage.Registration;

INSERT INTO Stage.Registration
(
	[FirstName], 
	[LastName], 
	[Rank], 
	[Street1], 
	[Street2], 
	AppartmentCode,
	[City], 
	[StateProvince], 
	[PostalCode], 
	[Country], 
	[IsKata], 
	[IsSemiKnockdown], 
	[IsKnockdown], 
	[DojoName], 
	[EmailAddress],
	[Gender],
	[PhoneNumber],
	[Age],
	DateOfBirth,
	[Weight],
	[IsMinor]
)
VALUES
( N'John', N'Smith', 4, N'123 Street St.', NULL, NULL, N'Danbury', N'CT', N'06810', N'USA', 1, 1, 0, N'Kanreikai', N'jonny@aol.com', 'M', '1-555-232-1231' ), 
( N'Jane', N'Goodkicks', 7, N'123 Street St.', NULL, NULL, N'Seattle', N'WA', N'98101', N'USA', 0, 1, 1, N'BigDojo', N'jgoodkicks@gmail.com', 'F', '1-555-232-1231' ), 
( N'Han', N'Chee', 1, N'123 Street St.', NULL, NULL, N'Vancouver', N'British Columbia', N'98660', N'Canada', 1, 0, 0, N'AggressiveDojo', N'Han@Chee.com', 'M', '1-555-232-1231')
