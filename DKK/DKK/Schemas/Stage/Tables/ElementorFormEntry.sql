CREATE TABLE [Stage].[ElementorFormEntry](
	[id] int NOT NULL CONSTRAINT PK_Stage_ElementorFormEntry_id PRIMARY KEY CLUSTERED,
	[data_id] [int] NOT NULL,
	[meta_key] [nvarchar](255) NOT NULL,
	[meta_value] [nvarchar](4000) NOT NULL,
	[dtcreated] [datetime2](3) NOT NULL CONSTRAINT [DF_Stage_ElementorFormEntry_dtcreated]  DEFAULT (((sysutcdatetime() AT TIME ZONE 'UTC') AT TIME ZONE 'Eastern Standard Time')),
    INDEX uq_stage_elementorformentry_data_id_meta_key NONCLUSTERED (data_id, meta_key)
)
