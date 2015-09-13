USE [GP_InboxOutbox];

IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[tbl_Outbox]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
	CREATE TABLE [dbo].[tbl_Outbox] (
		[OUT_MSG_ID] [bigint] IDENTITY (1, 1) NOT NULL ,
		[MOBILENO] [bigint] NOT NULL ,
		[IN_MSG_ID] [bigint] NULL ,
		[BODY] [nvarchar] (320) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
		[STATUS] [bit] NOT NULL ,
		[MSG_TYPE] [int] NOT NULL ,
		[SEND_PORT] [int] NOT NULL 
	) ON [PRIMARY];

	
	ALTER TABLE [dbo].[tbl_Outbox] WITH NOCHECK ADD 
		CONSTRAINT [PK_tbl_Outbox] PRIMARY KEY  CLUSTERED 
		(
			[OUT_MSG_ID]
		)  ON [PRIMARY];
	
	CREATE INDEX [Status_Index] ON [dbo].[tbl_Outbox]([STATUS]) ON [PRIMARY];
END


IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[tbl_inbox]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
	CREATE TABLE [dbo].[tbl_inbox] (
		[IN_MSG_ID] [bigint] NOT NULL ,
		[MOBILENO] [bigint] NOT NULL ,
		[BODY] [nvarchar] (320) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
		[STATUS] [bit] NOT NULL ,
		[INSERT_TIME] [datetime] NOT NULL ,
		[ORIGIN_PORT] [int] NOT NULL 
	) ON [PRIMARY];

	ALTER TABLE [dbo].[tbl_inbox] WITH NOCHECK ADD 
		CONSTRAINT [PK_tbl_inbox] PRIMARY KEY  CLUSTERED 
		(
			[IN_MSG_ID]
		)  ON [PRIMARY];

	CREATE INDEX [Status_Index] ON [dbo].[tbl_inbox]([STATUS]) ON [PRIMARY];

END