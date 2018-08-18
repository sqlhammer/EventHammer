CREATE TABLE [Stage].[CalderaFormEntry]
(
	form_id NVARCHAR(18) NOT NULL
	,entry_id INT NOT NULL
	,field_id NVARCHAR(20) NOT NULL
	,slug NVARCHAR(255) NOT NULL
	,[value] NVARCHAR(MAX) NOT NULL
	,dtcreated DATETIME2(3) NOT NULL CONSTRAINT DF_Stage_CalderaFormEntry_dtcreated DEFAULT (SYSUTCDATETIME() 
																									AT TIME ZONE 'UTC'
																									AT TIME ZONE 'Eastern Standard Time')
)
GO
CREATE CLUSTERED INDEX IX_Stage_CalderaFormEntry_entry_id_slug
ON Stage.CalderaFormEntry (entry_id,slug);
GO
