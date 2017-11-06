
CREATE TABLE [Event].[Division]
(
	[DivisionId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY
	,MinimumWeight_lb DECIMAL(6,2) NOT NULL
	,MaximumWeight_lb DECIMAL(6,2) NOT NULL
	,WeightClass NVARCHAR(10) NOT NULL
	,Gender CHAR NOT NULL
)
