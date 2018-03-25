CREATE TABLE [Stage].[CalderaFormEntry]
(
	form_id NVARCHAR(18) NOT NULL
	,entry_id INT NOT NULL
	,field_id NVARCHAR(20) NOT NULL
	,slug NVARCHAR(255) NOT NULL
	,[value] NVARCHAR(MAX) NOT NULL
)
GO
CREATE CLUSTERED INDEX IX_Stage_CalderaFormEntry_slug
ON Stage.CalderaFormEntry (slug);
GO
