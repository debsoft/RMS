use [RMSDB];



-- BEGIN check if tables already added, if not, create them else skip
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[cb_audit]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN


/****** Object:  Table [dbo].[cb_audit]    Script Date: 3/14/2006 1:40:55 PM ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[cb_audit]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
	/****** Object:  Table [dbo].[cb_audit]    Script Date: 3/14/2006 1:40:57 PM ******/
	CREATE TABLE [dbo].[cb_audit] (
		[id] [uniqueidentifier] NOT NULL ,
		
		[location_id] [uniqueidentifier] NULL 
	) ON [PRIMARY]
	
	ALTER TABLE [dbo].[cb_audit] WITH NOCHECK ADD 
	CONSTRAINT [PK_cb_audit] PRIMARY KEY  CLUSTERED 
	(
		[id]
	)  ON [PRIMARY] 
END


/****** Object:  Table [dbo].[cb_category]    Script Date: 3/14/2006 1:40:55 PM ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[cb_category]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
	/****** Object:  Table [dbo].[cb_category]    Script Date: 3/14/2006 1:40:57 PM ******/
	CREATE TABLE [dbo].[cb_category] (
	[category_id] [uniqueidentifier] NOT NULL ,
	
	[quantity_unit] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]

	ALTER TABLE [dbo].[cb_category] WITH NOCHECK ADD 
		CONSTRAINT [PK_cb_category] PRIMARY KEY  CLUSTERED 
		(
			[category_id]
		)  ON [PRIMARY] 
END


/****** Object:  Table [dbo].[cb_district]    Script Date: 3/14/2006 1:40:55 PM ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[cb_district]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
	/****** Object:  Table [dbo].[cb_district]    Script Date: 3/14/2006 1:40:58 PM ******/
	CREATE TABLE [dbo].[cb_district] (
		[district_id] [uniqueidentifier] NOT NULL ,
		
		[district_full_name] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
	) ON [PRIMARY]

	ALTER TABLE [dbo].[cb_district] WITH NOCHECK ADD 
		CONSTRAINT [PK_cb_district] PRIMARY KEY  CLUSTERED 
		(
			[district_id]
		)  ON [PRIMARY] 

END


/****** Object:  Table [dbo].[cb_item]    Script Date: 3/14/2006 1:40:55 PM ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[cb_item]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
	/****** Object:  Table [dbo].[cb_item]    Script Date: 3/14/2006 1:40:58 PM ******/
	CREATE TABLE [dbo].[cb_item] (
		[item_id] [uniqueidentifier] NOT NULL ,
		
		[create_time] [datetime] NULL 
	) ON [PRIMARY]


	ALTER TABLE [dbo].[cb_item] WITH NOCHECK ADD 
		CONSTRAINT [PK_cb_item] PRIMARY KEY  CLUSTERED 
		(
			[item_id]
		)  ON [PRIMARY] 

	ALTER TABLE [dbo].[cb_item] ADD 
		CONSTRAINT [DF_cb_item_item_currency] DEFAULT ('tk') FOR [item_currency]

END

/****** Object:  Table [dbo].[cb_search]    Script Date: 3/14/2006 1:40:55 PM ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[cb_search]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
	/****** Object:  Table [dbo].[cb_search]    Script Date: 3/14/2006 1:40:58 PM ******/
	CREATE TABLE [dbo].[cb_search] (
	[search_id] [uniqueidentifier] NOT NULL ,
	
	[search_item_description] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]

	ALTER TABLE [dbo].[cb_search] ADD 
		CONSTRAINT [DF_cb_search_send_status] DEFAULT ('notsend') FOR [send_status]

END

/****** Object:  Table [dbo].[cb_seller]    Script Date: 3/14/2006 1:40:55 PM ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[cb_seller]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
	/****** Object:  Table [dbo].[cb_seller]    Script Date: 3/14/2006 1:40:58 PM ******/
	CREATE TABLE [dbo].[cb_seller] (
		[seller_id] [uniqueidentifier] NOT NULL ,
		
		[create_time] [datetime] NULL
	) ON [PRIMARY]

	ALTER TABLE [dbo].[cb_seller] WITH NOCHECK ADD 
		CONSTRAINT [PK_cb_seller] PRIMARY KEY  CLUSTERED 
		(
			[seller_id]
		)  ON [PRIMARY] 
END



/****** Object:  Table [dbo].[cb_post]    Script Date: 3/14/2006 1:40:55 PM ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[cb_post]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
	/****** Object:  Table [dbo].[cb_post]    Script Date: 3/14/2006 1:40:58 PM ******/
	CREATE TABLE [dbo].[cb_post] (
	[post_id] [uniqueidentifier] NOT NULL ,
	
	[description] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]

	ALTER TABLE [dbo].[cb_post] WITH NOCHECK ADD 
		CONSTRAINT [PK_cb_post] PRIMARY KEY  CLUSTERED 
		(
			[post_id]
		)  ON [PRIMARY] 
END





/****** Object:  Table [dbo].[cb_state]    Script Date: 3/14/2006 1:40:55 PM ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[cb_state]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
	/****** Object:  Table [dbo].[cb_state]    Script Date: 3/14/2006 1:40:58 PM ******/
	CREATE TABLE [dbo].[cb_state] (
		[state_id] [uniqueidentifier] NOT NULL ,
		
		[unstate_time] [datetime] NULL 
	) ON [PRIMARY]

	ALTER TABLE [dbo].[cb_state] WITH NOCHECK ADD 
		CONSTRAINT [PK_cb_state] PRIMARY KEY  CLUSTERED 
		(
			[state_id]
		)  ON [PRIMARY] 

END


ALTER TABLE [dbo].[cb_item] ADD 
	CONSTRAINT [FK_cb_item_cb_category] FOREIGN KEY 
	(
		[category_id]
	) REFERENCES [dbo].[cb_category] (
		[category_id]
	),
	CONSTRAINT [FK_cb_item_cb_district] FOREIGN KEY 
	(
		[item_dist_id]
	) REFERENCES [dbo].[cb_district] (
		[district_id]
	),
	CONSTRAINT [FK_cb_item_cb_seller] FOREIGN KEY 
	(
		[seller_id]
	) REFERENCES [dbo].[cb_seller] (
		[seller_id]
	)



ALTER TABLE [dbo].[cb_seller] ADD 
	CONSTRAINT [FK_cb_seller_cb_district] FOREIGN KEY 
	(
		[seller_dist_id]
	) REFERENCES [dbo].[cb_district] (
		[district_id]
	)

/****** Dummy Data ******/


ALTER TABLE [cb_category] NOCHECK CONSTRAINT ALL

INSERT INTO [cb_category] ([category_id],[category_name],[parent_category_id],[header],[quantity_unit]) VALUES ('330eb076-9ba8-4e31-8435-ef1e26c3fb92','7500','61805607-bcfc-46d6-a455-78d3cf7a3a86','Choose brand',NULL)
ALTER TABLE [cb_category] CHECK CONSTRAINT ALL



ALTER TABLE [cb_district] NOCHECK CONSTRAINT ALL

INSERT INTO [cb_district] ([district_id],[district_short_name],[district_full_name]) VALUES ('5bc7ad20-35d6-4bcc-b7cc-7945c5854a4e','syl','sylhet')
INSERT INTO [cb_district] ([district_id],[district_short_name],[district_full_name]) VALUES ('db4860d6-6fc9-4273-ade7-bad333d2fec8','raj','rajshahi')
ALTER TABLE [cb_district] CHECK CONSTRAINT ALL




ALTER TABLE [cb_seller] NOCHECK CONSTRAINT ALL

INSERT INTO [cb_seller] ([seller_id],[mobile_no],[seller_name],[seller_address],[seller_dist_id]) VALUES ('596ada5e-218e-4821-b4a5-fb020335e650',192479176,'','','159d2c86-1cd5-4a45-b1c5-000080e4ca25')
ALTER TABLE [cb_seller] CHECK CONSTRAINT ALL




ALTER TABLE [cb_item] NOCHECK CONSTRAINT ALL
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('6e13961e-4b79-4278-9d79-027741b9a724','','ok',0,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',4,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','d58cc7f8-0139-4dcd-b47d-a35362cbf541','2006/04/13 04:34:51 PM')

INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('60ba2629-800c-4053-9d2d-fc94460fac67','','good',10000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/17 04:43:35 PM')
ALTER TABLE [cb_item] CHECK CONSTRAINT ALL





ALTER TABLE [cb_post] NOCHECK CONSTRAINT ALL
INSERT INTO [cb_post] ([post_id],[mobile_number],[description]) VALUES ('08b344b0-41dd-4e81-9f86-05309b372340','192479175','new sdd sds')

INSERT INTO [cb_post] ([post_id],[mobile_number],[description]) VALUES ('4cda8be0-f9bb-466b-96d7-cd7d573d3aa5','192479175','new')
ALTER TABLE [cb_post] CHECK CONSTRAINT ALL




/******* Dummy Data ************/
/*******Full Text******/
if (select DATABASEPROPERTY(DB_NAME(), N'IsFullTextEnabled')) <> 1 
exec sp_fulltext_database N'enable' 

if not exists (select * from dbo.sysfulltextcatalogs where name = N'CBDBCatalog')
exec sp_fulltext_catalog N'CBDBCatalog', N'create' 

if (select DATABASEPROPERTY(DB_NAME(), N'IsFullTextEnabled')) <> 1 
exec sp_fulltext_database N'enable' 

if not exists (select * from dbo.sysfulltextcatalogs where name = N'CBDBCatalog')
exec sp_fulltext_catalog N'CBDBCatalog', N'create' 

exec sp_fulltext_table N'[dbo].[cb_category]', N'create', N'CBDBCatalog', N'PK_cb_category'

exec sp_fulltext_column N'[dbo].[cb_category]', N'category_name', N'add', 1033  

exec sp_fulltext_table N'[dbo].[cb_category]', N'activate'  

if (select DATABASEPROPERTY(DB_NAME(), N'IsFullTextEnabled')) <> 1 
exec sp_fulltext_database N'enable' 

if not exists (select * from dbo.sysfulltextcatalogs where name = N'CBDBCatalog')
exec sp_fulltext_catalog N'CBDBCatalog', N'create' 

exec sp_fulltext_table N'[dbo].[cb_item]', N'create', N'CBDBCatalog', N'PK_cb_item'

exec sp_fulltext_column N'[dbo].[cb_item]', N'item_name', N'add', 1033  

exec sp_fulltext_column N'[dbo].[cb_item]', N'item_desc', N'add', 1033  

exec sp_fulltext_table N'[dbo].[cb_item]', N'activate'  





-- database for web admin





END