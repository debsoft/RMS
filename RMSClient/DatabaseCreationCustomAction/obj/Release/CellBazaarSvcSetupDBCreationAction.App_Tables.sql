use [dbCellBazaar];



-- BEGIN check if tables already added, if not, create them else skip
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[cb_audit]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN


/****** Object:  Table [dbo].[cb_audit]    Script Date: 3/14/2006 1:40:55 PM ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[cb_audit]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
	/****** Object:  Table [dbo].[cb_audit]    Script Date: 3/14/2006 1:40:57 PM ******/
	CREATE TABLE [dbo].[cb_audit] (
		[id] [uniqueidentifier] NOT NULL ,
		[operation_type] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
		[mobile_no] [bigint] NULL ,
		[sms] [nvarchar] (320) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
		[response_id] [uniqueidentifier] NULL ,
		[operation_time] [datetime] NULL ,
		[sub_operation_type] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
		[item_id] [uniqueidentifier] NULL ,
		[category_id] [uniqueidentifier] NULL ,
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
	[category_name] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[parent_category_id] [uniqueidentifier] NOT NULL ,
	[header] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
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
		[district_short_name] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
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
		[item_name] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
		[item_desc] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
		[item_price] [float] NULL ,
		[item_dist_id] [uniqueidentifier] NOT NULL ,
		[item_quantity] [float] NULL ,
		[item_unit] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
		[item_currency] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
		[seller_id] [uniqueidentifier] NOT NULL ,
		[category_id] [uniqueidentifier] NOT NULL ,
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
	[serial_no] [int] NOT NULL ,
	[search_item_name] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[search_item_id] [uniqueidentifier] NULL ,
	[send_status] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[search_category_name] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[search_sub_category_name] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[search_item_count] [int] NULL ,
	[search_item_price] [float] NULL ,
	[search_item_quantity] [float] NULL ,
	[search_item_location] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[search_item_start_price] [float] NULL ,
	[search_item_end_price] [float] NULL ,
	[search_item_start_quantity] [float] NULL ,
	[search_item_end_quantity] [float] NULL ,
	[search_sub_category2_name] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
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
		[mobile_no] [bigint] NOT NULL ,
		[seller_name] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
		[seller_address] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
		[seller_dist_id] [uniqueidentifier] NULL ,
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
	[mobile_number] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
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
		[mobile_no] [bigint] NOT NULL ,
		[search_id] [uniqueidentifier] NOT NULL ,
		[current_state] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
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
INSERT INTO [cb_category] ([category_id],[category_name],[parent_category_id],[header],[quantity_unit]) VALUES ('be00cbdb-a489-424e-87fd-225b7c4a91c4','3330','61805607-bcfc-46d6-a455-78d3cf7a3a86','Choose brand',NULL)
INSERT INTO [cb_category] ([category_id],[category_name],[parent_category_id],[header],[quantity_unit]) VALUES ('e2166e9f-6e65-4701-a3fd-2a58f2c1024c','TV','8177d8be-e9c3-4fe4-8fe0-677fbf944e5e','Choose category',NULL)
INSERT INTO [cb_category] ([category_id],[category_name],[parent_category_id],[header],[quantity_unit]) VALUES ('d9f867fa-f18e-42f7-b4b1-3010c2a8db34','Motorola','15171807-10e3-41c4-bfa6-a2b4e3eda168','Choose brand',NULL)
INSERT INTO [cb_category] ([category_id],[category_name],[parent_category_id],[header],[quantity_unit]) VALUES ('5acd605a-ef59-48f0-bbd9-308b1e1ed1a8','Transport','00000000-0000-0000-0000-000000000000','Choose your area of interest',NULL)
INSERT INTO [cb_category] ([category_id],[category_name],[parent_category_id],[header],[quantity_unit]) VALUES ('db23e872-4aa3-4eaf-b229-5d39612ba38d','Sony','15171807-10e3-41c4-bfa6-a2b4e3eda168','Choose brand',NULL)
INSERT INTO [cb_category] ([category_id],[category_name],[parent_category_id],[header],[quantity_unit]) VALUES ('16edaa7d-2fc5-466c-837d-64cb3749dded','Freeze','8177d8be-e9c3-4fe4-8fe0-677fbf944e5e','Choose category',NULL)
INSERT INTO [cb_category] ([category_id],[category_name],[parent_category_id],[header],[quantity_unit]) VALUES ('8177d8be-e9c3-4fe4-8fe0-677fbf944e5e','Electronics','00000000-0000-0000-0000-000000000000','Choose your area of interest',NULL)
INSERT INTO [cb_category] ([category_id],[category_name],[parent_category_id],[header],[quantity_unit]) VALUES ('61805607-bcfc-46d6-a455-78d3cf7a3a86','Nokia','15171807-10e3-41c4-bfa6-a2b4e3eda168','Choose brand',NULL)
INSERT INTO [cb_category] ([category_id],[category_name],[parent_category_id],[header],[quantity_unit]) VALUES ('430193a8-4439-4c61-85b6-92724bdde75c','Service','00000000-0000-0000-0000-000000000000','Choose your area of interest',NULL)
INSERT INTO [cb_category] ([category_id],[category_name],[parent_category_id],[header],[quantity_unit]) VALUES ('15171807-10e3-41c4-bfa6-a2b4e3eda168','Mobile','8177d8be-e9c3-4fe4-8fe0-677fbf944e5e','Choose category',NULL)
INSERT INTO [cb_category] ([category_id],[category_name],[parent_category_id],[header],[quantity_unit]) VALUES ('d58cc7f8-0139-4dcd-b47d-a35362cbf541','Sharp','e2166e9f-6e65-4701-a3fd-2a58f2c1024c','Choose brand',NULL)
INSERT INTO [cb_category] ([category_id],[category_name],[parent_category_id],[header],[quantity_unit]) VALUES ('80551617-7ec1-478f-a634-b20955a2cb51','6610','61805607-bcfc-46d6-a455-78d3cf7a3a86','Choose brand',NULL)
INSERT INTO [cb_category] ([category_id],[category_name],[parent_category_id],[header],[quantity_unit]) VALUES ('6c486b90-f55d-4b94-8545-bb9eb2efb7fa','BritishAirways','8e4b7fb7-88f0-4ae6-853b-c3f05459d4a7','Choose brand',NULL)
INSERT INTO [cb_category] ([category_id],[category_name],[parent_category_id],[header],[quantity_unit]) VALUES ('8e4b7fb7-88f0-4ae6-853b-c3f05459d4a7','ByAir','5acd605a-ef59-48f0-bbd9-308b1e1ed1a8','Choose category',NULL)
INSERT INTO [cb_category] ([category_id],[category_name],[parent_category_id],[header],[quantity_unit]) VALUES ('bafb3eea-5d08-44a0-b26d-dcd585d6b731','Philips','e2166e9f-6e65-4701-a3fd-2a58f2c1024c','Choose brand',NULL)
INSERT INTO [cb_category] ([category_id],[category_name],[parent_category_id],[header],[quantity_unit]) VALUES ('330eb076-9ba8-4e31-8435-ef1e26c3fb92','7500','61805607-bcfc-46d6-a455-78d3cf7a3a86','Choose brand',NULL)
ALTER TABLE [cb_category] CHECK CONSTRAINT ALL



ALTER TABLE [cb_district] NOCHECK CONSTRAINT ALL
INSERT INTO [cb_district] ([district_id],[district_short_name],[district_full_name]) VALUES ('159d2c86-1cd5-4a45-b1c5-000080e4ca25','dk','dhaka')
INSERT INTO [cb_district] ([district_id],[district_short_name],[district_full_name]) VALUES ('29358007-12dc-4045-9a2f-067d8361471a','cht','chitagong')
INSERT INTO [cb_district] ([district_id],[district_short_name],[district_full_name]) VALUES ('f13e0990-d483-4a66-a98f-4648ddc84c3b','kh','khulna')
INSERT INTO [cb_district] ([district_id],[district_short_name],[district_full_name]) VALUES ('77633e99-2242-42cf-8554-5fcf76183532','bar','barishal')
INSERT INTO [cb_district] ([district_id],[district_short_name],[district_full_name]) VALUES ('5bc7ad20-35d6-4bcc-b7cc-7945c5854a4e','syl','sylhet')
INSERT INTO [cb_district] ([district_id],[district_short_name],[district_full_name]) VALUES ('db4860d6-6fc9-4273-ade7-bad333d2fec8','raj','rajshahi')
ALTER TABLE [cb_district] CHECK CONSTRAINT ALL




ALTER TABLE [cb_seller] NOCHECK CONSTRAINT ALL
INSERT INTO [cb_seller] ([seller_id],[mobile_no],[seller_name],[seller_address],[seller_dist_id]) VALUES ('417a1f8b-c880-4832-a7b8-058bbff6f30b',21211,'','','159d2c86-1cd5-4a45-b1c5-000080e4ca25')
INSERT INTO [cb_seller] ([seller_id],[mobile_no],[seller_name],[seller_address],[seller_dist_id]) VALUES ('8e3c2657-7c3e-4449-853b-0e1d8b3e84a1',5544,'','','159d2c86-1cd5-4a45-b1c5-000080e4ca25')
INSERT INTO [cb_seller] ([seller_id],[mobile_no],[seller_name],[seller_address],[seller_dist_id]) VALUES ('babff2ee-97c2-4b5b-b83a-2084c7723e0e',17158006,'','','159d2c86-1cd5-4a45-b1c5-000080e4ca25')
INSERT INTO [cb_seller] ([seller_id],[mobile_no],[seller_name],[seller_address],[seller_dist_id]) VALUES ('65430dfd-c2d5-4670-887a-221bafffc802',123456,'ronny','somewhere','159d2c86-1cd5-4a45-b1c5-000080e4ca25')
INSERT INTO [cb_seller] ([seller_id],[mobile_no],[seller_name],[seller_address],[seller_dist_id]) VALUES ('ec12332c-7e80-4b14-b025-2e2086cbb72b',3,'','','159d2c86-1cd5-4a45-b1c5-000080e4ca25')
INSERT INTO [cb_seller] ([seller_id],[mobile_no],[seller_name],[seller_address],[seller_dist_id]) VALUES ('b6920186-d9ec-484e-a895-3349d1b08390',192479176,'','','159d2c86-1cd5-4a45-b1c5-000080e4ca25')
INSERT INTO [cb_seller] ([seller_id],[mobile_no],[seller_name],[seller_address],[seller_dist_id]) VALUES ('61a4d7bd-cb73-47aa-be2c-3deb744344d1',192479178,'','','159d2c86-1cd5-4a45-b1c5-000080e4ca25')
INSERT INTO [cb_seller] ([seller_id],[mobile_no],[seller_name],[seller_address],[seller_dist_id]) VALUES ('f8e3b0c2-8ce3-4e8c-86d1-425597cd0c3e',2121,'','','159d2c86-1cd5-4a45-b1c5-000080e4ca25')
INSERT INTO [cb_seller] ([seller_id],[mobile_no],[seller_name],[seller_address],[seller_dist_id]) VALUES ('86e026b7-c1f4-419d-b65b-690018680efa',192479177,'','','f13e0990-d483-4a66-a98f-4648ddc84c3b')
INSERT INTO [cb_seller] ([seller_id],[mobile_no],[seller_name],[seller_address],[seller_dist_id]) VALUES ('4c1f7cc7-37b9-43b6-b0ce-69eb06987e4f',12345678,'Ronny2','my_address','159d2c86-1cd5-4a45-b1c5-000080e4ca25')
INSERT INTO [cb_seller] ([seller_id],[mobile_no],[seller_name],[seller_address],[seller_dist_id]) VALUES ('1bfb1127-49f0-44aa-8138-953f90f9c221',1234,'test','Banani','159d2c86-1cd5-4a45-b1c5-000080e4ca25')
INSERT INTO [cb_seller] ([seller_id],[mobile_no],[seller_name],[seller_address],[seller_dist_id]) VALUES ('609889ce-8e78-49dc-ad47-a76238866e57',1,'','','f13e0990-d483-4a66-a98f-4648ddc84c3b')
INSERT INTO [cb_seller] ([seller_id],[mobile_no],[seller_name],[seller_address],[seller_dist_id]) VALUES ('e3f46b69-cb2c-4f08-a88e-c136359cb890',191495788,'Sohel','Mohakhali','159d2c86-1cd5-4a45-b1c5-000080e4ca25')
INSERT INTO [cb_seller] ([seller_id],[mobile_no],[seller_name],[seller_address],[seller_dist_id]) VALUES ('7aae4de6-b218-479b-ba99-c60e71758e1e',1111,'','','159d2c86-1cd5-4a45-b1c5-000080e4ca25')
INSERT INTO [cb_seller] ([seller_id],[mobile_no],[seller_name],[seller_address],[seller_dist_id]) VALUES ('3675c118-5b02-4b6f-b948-f1a43b3538dc',192479175,'name','description for account','159d2c86-1cd5-4a45-b1c5-000080e4ca25')
INSERT INTO [cb_seller] ([seller_id],[mobile_no],[seller_name],[seller_address],[seller_dist_id]) VALUES ('1010fcf4-372a-4b7c-84ad-f27de990fc79',176265565,'robin','Banani','159d2c86-1cd5-4a45-b1c5-000080e4ca25')
INSERT INTO [cb_seller] ([seller_id],[mobile_no],[seller_name],[seller_address],[seller_dist_id]) VALUES ('fcc29dee-525a-4219-8414-f3d6e4ac996d',121,'','','159d2c86-1cd5-4a45-b1c5-000080e4ca25')
INSERT INTO [cb_seller] ([seller_id],[mobile_no],[seller_name],[seller_address],[seller_dist_id]) VALUES ('02179baf-79ae-4373-abd8-f4fade3a03c2',2,'','','f13e0990-d483-4a66-a98f-4648ddc84c3b')
INSERT INTO [cb_seller] ([seller_id],[mobile_no],[seller_name],[seller_address],[seller_dist_id]) VALUES ('596ada5e-218e-4821-b4a5-fb020335e650',192479176,'','','159d2c86-1cd5-4a45-b1c5-000080e4ca25')
ALTER TABLE [cb_seller] CHECK CONSTRAINT ALL




ALTER TABLE [cb_item] NOCHECK CONSTRAINT ALL
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('6e13961e-4b79-4278-9d79-027741b9a724','','ok',0,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',4,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','d58cc7f8-0139-4dcd-b47d-a35362cbf541','2006/04/13 04:34:51 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('af4d7615-22cd-4266-8f2f-03c1b821e568','','good',1000,'f13e0990-d483-4a66-a98f-4648ddc84c3b',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','61805607-bcfc-46d6-a455-78d3cf7a3a86','2006/04/17 06:09:16 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('7672b100-ce93-4dff-ac45-03db077cb398','','good',1000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/17 04:43:25 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('49a23887-4ed7-4771-88d1-059d7dba56b4','','good',12000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','bafb3eea-5d08-44a0-b26d-dcd585d6b731','2006/03/30 03:02:56 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('2e3d05af-6fd6-49f3-b20a-05bea55d095f','','8',1000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','61805607-bcfc-46d6-a455-78d3cf7a3a86','2006/04/12 03:22:47 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('bb859299-238c-48df-926e-05d27c1eb3e7','','nice',25000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','61805607-bcfc-46d6-a455-78d3cf7a3a86','2006/04/01 03:16:33 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('9a551579-2ebd-4d5c-84af-07aaa568bebd','','good',1000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/17 04:43:21 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('f288f1a1-fe61-4ef8-ae62-08031b687bbc','','new_test3',1000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','61805607-bcfc-46d6-a455-78d3cf7a3a86','2006/04/09 06:15:06 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('18a2db22-b91f-4993-89b2-0a59c6c04f89','','good',1000,'f13e0990-d483-4a66-a98f-4648ddc84c3b',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','61805607-bcfc-46d6-a455-78d3cf7a3a86','2006/04/17 06:09:18 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('b38e0ab8-6904-407b-9a77-0a6123d623e0','','good',10000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/17 04:43:33 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('68eeaecc-3c98-493b-9f8a-0b4337137583','','good',10000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/17 04:43:34 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('ee2e648f-5241-43e7-a22d-0c20a3700741','','8',1000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','61805607-bcfc-46d6-a455-78d3cf7a3a86','2006/04/12 03:23:05 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('3ef33d04-b6d6-44cf-a529-0d3d347dea65','','goodie',0,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','61805607-bcfc-46d6-a455-78d3cf7a3a86','2006/04/12 12:28:01 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('d2549d3e-24f6-4abd-bd4a-0d8af67c03e9','','cheap camera',5000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','61805607-bcfc-46d6-a455-78d3cf7a3a86','2006/03/30 02:54:20 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('888ac28d-b294-49c3-8b88-0df8a9d9089e','','good',1000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','61805607-bcfc-46d6-a455-78d3cf7a3a86','2006/04/12 12:22:14 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('36270be8-ffc5-4996-a67b-0df8d1f991c1','','good',1000,'f13e0990-d483-4a66-a98f-4648ddc84c3b',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','61805607-bcfc-46d6-a455-78d3cf7a3a86','2006/04/17 06:09:17 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('458962d5-7d81-422c-95c5-0e2120daf1ec','','good',10000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/17 04:43:34 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('297f6cc9-d06c-4933-b37c-0e6b165e6a4f','','good',30000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/17 04:45:23 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('6ce4f1ad-6a36-4603-8f4b-11987a5fe890','','8',1000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','61805607-bcfc-46d6-a455-78d3cf7a3a86','2006/04/12 04:54:52 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('59b79958-2641-4ad9-a73d-12cd70b552e1','','good',1000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/17 04:43:22 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('df5dda6f-bd05-4bdb-882d-134f7529ef10','','good',1000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/17 04:43:26 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('f1535d73-673d-4dc4-8d10-140c3edd5e16','','good',30000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/17 04:45:21 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('74a0117c-b9c4-43a6-9854-14c8eff83260','','good',11000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','bafb3eea-5d08-44a0-b26d-dcd585d6b731','2006/03/30 03:02:53 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('f214694e-acb5-4e35-b6e1-175d256e4e05','','good',1000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/17 04:43:23 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('0d328406-6c2d-470b-a7ba-18919bd08d24','','8',1000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','61805607-bcfc-46d6-a455-78d3cf7a3a86','2006/04/13 09:37:11 AM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('79e0658f-b50e-4f42-8b61-1894e9b3a712','','good',10000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/17 04:43:34 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('950c0874-4c85-497f-8196-18a1984fd656','','8',1000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','61805607-bcfc-46d6-a455-78d3cf7a3a86','2006/04/13 09:50:17 AM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('379fccaf-9e8a-40a7-bbe9-191d69f1876a','','cheap good camera',6000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','d9f867fa-f18e-42f7-b4b1-3010c2a8db34','2006/03/30 02:55:18 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('a6c572a9-0b23-4de7-8e15-1963f372395d','','good',1000,'f13e0990-d483-4a66-a98f-4648ddc84c3b',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/17 07:06:21 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('2dd54746-ff78-4d43-9e44-1c2db3c048d5','','good',13000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','bafb3eea-5d08-44a0-b26d-dcd585d6b731','2006/03/30 03:02:59 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('7fdf90d0-701e-4453-a54e-212564361796','','good',18000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','bafb3eea-5d08-44a0-b26d-dcd585d6b731','2006/03/30 03:03:19 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('37972a26-9e27-4871-9deb-22e486feb689','','good',1000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/17 04:43:29 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('a53615fc-3a3e-44fc-99d5-2532492265b1','','good',14000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','d58cc7f8-0139-4dcd-b47d-a35362cbf541','2006/03/30 03:02:32 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('809b514d-f23b-4627-b02b-25399cda0f8d','','8',1000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','61805607-bcfc-46d6-a455-78d3cf7a3a86','2006/04/12 03:37:38 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('9af281b2-0d51-44c9-813a-27f655d59b46','','new_test',1000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','61805607-bcfc-46d6-a455-78d3cf7a3a86','2006/04/09 05:23:22 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('087e59b8-6cb6-4f23-bd6c-2840186dfdf9','','cheap good camera',7000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','d9f867fa-f18e-42f7-b4b1-3010c2a8db34','2006/03/30 02:55:22 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('18ed3081-ba5c-4aad-b70c-2bb08dfbf40f','','good',1000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/17 04:43:29 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('dda9859a-4a99-412e-86ec-2cffacb06177','','good',10000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/17 04:43:32 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('91a5665b-24b5-46fe-a7fa-2f464fe6122e','','cheap good camera nice',9000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','d9f867fa-f18e-42f7-b4b1-3010c2a8db34','2006/03/30 02:55:38 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('bad0d423-defe-4931-9581-30be77fd3eeb','','good',30000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/17 04:45:21 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('d6fffe40-c41c-4cc9-b0d8-311c5630c904','','good',1000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','d9f867fa-f18e-42f7-b4b1-3010c2a8db34','2006/04/18 09:37:13 AM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('356831c9-da44-42a4-94b8-333dfbfea32d','','8',1000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','61805607-bcfc-46d6-a455-78d3cf7a3a86','2006/04/12 03:50:52 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('2bfd798b-f369-4009-8227-33635be1ee70','','good',1000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/17 04:43:21 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('8351106e-21b2-4315-b690-359cfbd30425','','good',30000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/17 04:45:20 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('d67c644b-3044-43b3-bd4b-372a1341cdb9','','good',1000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/17 04:43:27 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('3327645a-1661-48cd-b35d-37d87bf68658','','good',10000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','61805607-bcfc-46d6-a455-78d3cf7a3a86','2006/03/30 12:20:18 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('54ec2b4a-6bc0-4797-a861-3ae95abad724','','8',1000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','61805607-bcfc-46d6-a455-78d3cf7a3a86','2006/04/12 03:46:27 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('c07f0cbd-f861-4289-97a6-3af30af212d3','','good',1000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','61805607-bcfc-46d6-a455-78d3cf7a3a86','2006/04/12 11:58:51 AM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('9cfe9af3-3d80-4bc9-a4cb-3b59f23507bc','','good',30000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/17 04:45:19 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('a4562b37-a36d-4192-82d9-3ba1494a3e29','','8',1000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','61805607-bcfc-46d6-a455-78d3cf7a3a86','2006/04/12 03:29:34 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('5a0db170-6711-4eb4-8309-3bbeef962034','','good',10000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/17 04:43:32 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('33504cdb-16e6-404a-9180-3e253a9458ce','','cheap good camera nice',2000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','db23e872-4aa3-4eaf-b229-5d39612ba38d','2006/03/30 02:56:39 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('13b1c93b-4f4a-4dcb-876c-406e3b660ac5','','cheap camera',7000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','61805607-bcfc-46d6-a455-78d3cf7a3a86','2006/03/30 02:54:37 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('a9d026af-d6a8-493d-83ac-40e76077e1d3','','good',25000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','bafb3eea-5d08-44a0-b26d-dcd585d6b731','2006/03/30 03:03:37 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('25d6a0c3-cc6a-457d-a0c5-40f23ea8cab9','','good',1000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/17 04:43:24 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('aff94d91-8edf-45d2-9ae0-4128c6ac0c34','','good',1000,'f13e0990-d483-4a66-a98f-4648ddc84c3b',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','61805607-bcfc-46d6-a455-78d3cf7a3a86','2006/04/17 06:09:19 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('10dbd93c-006f-4973-b855-41926618cb23','','good',30000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/17 04:45:20 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('0baf8954-abe5-4f63-a1b4-41c4a4bb34aa','','cheap good camera nice',8000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','db23e872-4aa3-4eaf-b229-5d39612ba38d','2006/03/30 02:56:15 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('c66d861e-cd98-443e-967c-435bda9d7ef2','','good',1000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/17 04:43:23 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('f89c4b50-9916-4b37-a022-46321b9a2bdf','','good',40000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','d58cc7f8-0139-4dcd-b47d-a35362cbf541','2006/03/30 03:02:20 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('57a46bf2-e091-4994-9838-49e7356e7170','','cheap good camera nice',9000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','db23e872-4aa3-4eaf-b229-5d39612ba38d','2006/03/30 02:56:11 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('af5489e5-1310-4002-b51c-4a31f15ba9a1','','cheap good camera',8000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','61805607-bcfc-46d6-a455-78d3cf7a3a86','2006/03/30 02:54:49 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('b9fb3bcf-be9c-4d6d-9df4-4fd197650140','','good',10000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/17 04:43:33 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('6a0a9808-22b6-42f9-9877-5281fc98b5b9','','good',10000,'f13e0990-d483-4a66-a98f-4648ddc84c3b',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','d9f867fa-f18e-42f7-b4b1-3010c2a8db34','2006/04/18 09:40:35 AM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('893a6031-df44-4137-9c5a-52fa27f3594b','','good',30000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/17 04:45:21 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('5ccf9820-d8b9-4de8-8963-5563426bc67b','','good',1000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/17 04:43:23 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('c4e43216-4ba3-430a-aa48-570e1a66451a','','89',1000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','61805607-bcfc-46d6-a455-78d3cf7a3a86','2006/04/13 09:39:00 AM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('331e4feb-1578-40da-9fd6-5a0dd9cdcffa','','cheap camera',8000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','61805607-bcfc-46d6-a455-78d3cf7a3a86','2006/03/30 02:54:41 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('d0498fdc-cdf5-400f-9a6c-5a3dbddd49e9','','8',1000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','61805607-bcfc-46d6-a455-78d3cf7a3a86','2006/04/12 03:23:15 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('453a78d0-20e6-4141-8345-5a790dde320f','','good',30000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/17 04:45:22 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('d0326ba5-49d1-496e-a933-5c76d52eb9fa','','good',1000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/17 04:43:24 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('8965813f-c374-4956-a5d5-5e3d8cc5552d','','good',10000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/17 04:43:33 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('fe8627f0-6990-46e7-8878-5ea4c2720082','','good',30000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/17 04:45:21 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('5da19977-1fa1-4fe9-8633-5ef4d31afeda','','good',17000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','bafb3eea-5d08-44a0-b26d-dcd585d6b731','2006/03/30 03:03:14 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('ef8f40ad-f569-45d8-9687-5fb032808d29','','8',1000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','61805607-bcfc-46d6-a455-78d3cf7a3a86','2006/04/12 02:05:28 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('d4a61bb1-4b96-4f28-952c-601b64c5f806','','good',1000,'f13e0990-d483-4a66-a98f-4648ddc84c3b',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','61805607-bcfc-46d6-a455-78d3cf7a3a86','2006/04/17 06:09:19 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('15c44236-580c-4cca-b042-61e9b7554ae9','','good',10000,'f13e0990-d483-4a66-a98f-4648ddc84c3b',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','d9f867fa-f18e-42f7-b4b1-3010c2a8db34','2006/04/18 09:43:30 AM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('8f05663e-cf63-46c7-ada9-662c6425ad33','','good',30000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/17 04:45:20 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('a035b1e8-dc7b-41a2-a703-66d3aaf3af00','','good',12000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','d58cc7f8-0139-4dcd-b47d-a35362cbf541','2006/03/30 03:02:38 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('c4b9f983-aa03-4547-85af-692ba1c64a9b','','',2222,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','61805607-bcfc-46d6-a455-78d3cf7a3a86','2006/04/12 02:08:03 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('eeb52925-beb0-4e41-a6c8-699e03ea4d6b','','new_test4',10000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','61805607-bcfc-46d6-a455-78d3cf7a3a86','2006/04/09 06:56:33 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('6cb92942-893b-477f-93a9-6ac44a929f99','','good',1000,'f13e0990-d483-4a66-a98f-4648ddc84c3b',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/17 07:05:28 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('cf32eea1-7607-4e17-9fcb-6ee59b17dcc8','','8',1000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','61805607-bcfc-46d6-a455-78d3cf7a3a86','2006/04/12 03:55:04 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('a9517a32-4726-427c-b243-6f4b7c09e898','','cheap good camera',4000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','61805607-bcfc-46d6-a455-78d3cf7a3a86','2006/03/30 02:54:57 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('a6545d94-3301-4726-b768-70079eb2eeab','','cheap good camera nice',3000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','db23e872-4aa3-4eaf-b229-5d39612ba38d','2006/03/30 02:56:34 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('346b6d3a-9110-4a08-8759-705b03ec07be','','good',10000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/17 04:43:32 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('70c391f5-3630-4dc7-8ca6-72f88979e944','','good',30000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/17 04:45:21 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('1d648780-d4b9-499b-b846-7428b480a3ec','','8',1000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','61805607-bcfc-46d6-a455-78d3cf7a3a86','2006/04/12 03:26:12 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('71d16c75-8f2a-4d48-8e6c-750fffc4557d','','good',14000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','bafb3eea-5d08-44a0-b26d-dcd585d6b731','2006/03/30 03:03:03 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('740ff93c-1925-4447-87d9-7746bb2b7355','','8',1000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','61805607-bcfc-46d6-a455-78d3cf7a3a86','2006/04/12 03:50:24 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('191f22d4-a16b-4275-ade5-783517c8a672','','local in place',12000,'f13e0990-d483-4a66-a98f-4648ddc84c3b',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','61805607-bcfc-46d6-a455-78d3cf7a3a86','2006/03/30 06:07:28 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('01718bbc-3184-4ef7-912a-79155a719d1a','','good',1000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/17 04:43:25 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('f5320c09-dd0d-4d27-a852-7a04cf1bc97f','','good',1000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','61805607-bcfc-46d6-a455-78d3cf7a3a86','2006/04/12 12:26:02 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('1fbfffd8-794a-444b-a6f3-7aef32adf3f9','','9',1000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','61805607-bcfc-46d6-a455-78d3cf7a3a86','2006/04/12 03:26:25 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('657b4a94-5094-437c-bd58-7c3bb1deccd3','','good',1000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/17 04:43:24 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('4d2d5291-be3e-4f88-aaa5-7f0ef0775136','','good',1000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/17 04:43:25 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('448d24cf-2dff-4823-b058-7f3406ff883b','','cheap good camera nice',7000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','db23e872-4aa3-4eaf-b229-5d39612ba38d','2006/03/30 02:56:18 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('9022d996-9843-4c0b-aaed-7f628f4e36bd','','good',1000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/17 04:43:25 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('25bf62cf-bb34-440a-bc4c-81c69b33b65e','','good',1000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/17 04:43:26 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('e99f2e72-9360-4041-b3c5-8557f2e5fda6','','good',1000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/17 04:43:23 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('a125d01a-5aa9-4550-b2a8-87d653003650','','good',1000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/17 04:43:22 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('bfb9e364-9bf9-45d3-a237-88ced3adf1fe','','good',30000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','d58cc7f8-0139-4dcd-b47d-a35362cbf541','2006/03/30 03:02:17 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('4f852f1b-dbcb-42a0-93df-8cb2ea2b0e08','','good',9000,'f13e0990-d483-4a66-a98f-4648ddc84c3b',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/17 07:06:49 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('f1dfbd81-a1bc-4445-92fb-8e6b3f8f2d59','','good',1000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/17 04:43:23 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('88763b45-ccae-40ce-a7aa-90364a2453fc','','good',1000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/17 04:43:23 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('0f3f02ef-49c4-4b81-9ccb-926137a5bc52','','good',28000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','bafb3eea-5d08-44a0-b26d-dcd585d6b731','2006/03/30 03:03:48 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('2a2e4c22-3d56-4b59-9263-9569d2f451c1','','good',1000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','d9f867fa-f18e-42f7-b4b1-3010c2a8db34','2006/04/18 09:36:38 AM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('443490db-6723-4e28-a9a3-95a5f45d071b','','good',30000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/17 04:45:22 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('1d44f94b-fcf1-4f48-bee4-95c75bfff819','','new_3',1500,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','61805607-bcfc-46d6-a455-78d3cf7a3a86','2006/04/09 05:58:27 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('48487cc8-12e4-4981-8164-95df2a319d69','','good',1000,'f13e0990-d483-4a66-a98f-4648ddc84c3b',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','d9f867fa-f18e-42f7-b4b1-3010c2a8db34','2006/04/18 09:39:51 AM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('2c60a5cd-77e8-4b27-b50a-961310da89c1','','good',1000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/17 04:43:26 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('7b25adeb-350a-4fff-bc95-9718101d5e27','','good nice cheap',40000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/02 10:52:06 AM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('9d270cbb-9b10-43cb-b7e2-9806ff7f3320','','good',29000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','bafb3eea-5d08-44a0-b26d-dcd585d6b731','2006/03/30 03:03:51 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('c563ff96-1b62-41d4-b6a1-98602284ffd5','','good',10000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/17 04:43:33 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('04ccc47c-04a1-4b63-88da-993becee64c6','','good',1000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/17 04:43:26 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('7b0bf389-4d8b-4455-b8d7-9ba62fe6240b','','',1000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','61805607-bcfc-46d6-a455-78d3cf7a3a86','2006/04/12 12:53:49 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('c5dca7f0-c761-4ea3-b34c-9cca3b9f5b6b','','good',1000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/17 04:43:29 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('09994a00-0014-4d52-8dc5-9dafc5442949','','',1000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','61805607-bcfc-46d6-a455-78d3cf7a3a86','2006/04/12 12:52:42 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('32320bc0-5acb-4889-b2a8-9dfc8c393e35','','good',1000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/17 04:43:18 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('aaf2087b-7da9-4528-a75e-9edc0d0bc3dc','','cheap good camera nice',6000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','db23e872-4aa3-4eaf-b229-5d39612ba38d','2006/03/30 02:56:21 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('a6b482f4-f1cb-4ed3-817f-a173252efc6d','','good6',1000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','61805607-bcfc-46d6-a455-78d3cf7a3a86','2006/04/12 12:47:41 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('0bf0fee2-101f-4e16-946e-a1d043e7cc94','','good',10000,'f13e0990-d483-4a66-a98f-4648ddc84c3b',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','d9f867fa-f18e-42f7-b4b1-3010c2a8db34','2006/04/18 09:44:43 AM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('3db3d9e1-ae65-4ecd-9dde-a35806c1d14f','','good',30000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/17 04:45:20 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('c13fb631-158c-4fad-8bc6-a6a3c58985f5','','good',1000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/17 04:43:24 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('97086891-a9fc-40eb-bfa3-a6c6a6c1094e','','good',30000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/17 04:45:20 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('68d73813-36cd-441e-8e85-a73fcd7fab60','','good',1000,'f13e0990-d483-4a66-a98f-4648ddc84c3b',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','61805607-bcfc-46d6-a455-78d3cf7a3a86','2006/04/17 06:09:18 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('4d8af146-84ab-4d4f-a695-a8f5c5ac4524','','cheap good camera',9000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','61805607-bcfc-46d6-a455-78d3cf7a3a86','2006/03/30 02:54:53 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('1d7d94f7-e0d9-4f92-a88b-aa063711bdf2','','cheap good camera nice',8000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','d9f867fa-f18e-42f7-b4b1-3010c2a8db34','2006/03/30 02:55:33 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('f0df8230-c92f-4ac0-91e1-aaadbcef1b81','','good',50000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','d58cc7f8-0139-4dcd-b47d-a35362cbf541','2006/03/30 03:02:23 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('6b9c972c-1800-40c4-87be-ab2c7ea6d866','','good',1000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/13 03:27:28 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('27164b6c-a605-49a1-a718-aea9faeede47','','good',1000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/17 04:43:25 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('0fca628a-8c41-4e27-b13b-b0d6d1a2ef4c','','good',1000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/17 04:43:26 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('c94afe52-2bee-4665-81d5-b0d8092ac935','','changed',1200,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',5,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','61805607-bcfc-46d6-a455-78d3cf7a3a86','2006/04/10 12:51:59 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('25200401-c75b-401f-9804-b17c94d6988a','','new',1000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','61805607-bcfc-46d6-a455-78d3cf7a3a86','2006/04/09 05:24:56 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('f9affc73-0d1a-44b0-a658-b1a3a84d015c','','good',26000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','bafb3eea-5d08-44a0-b26d-dcd585d6b731','2006/03/30 03:03:41 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('0eefbbb2-762c-490e-be12-b459cc25ed0c','','8',1000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','61805607-bcfc-46d6-a455-78d3cf7a3a86','2006/04/12 05:33:10 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('18d1840e-27bd-4dc0-a575-b4d26027f425','','good',1000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/17 04:43:24 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('162e3efd-548a-41f6-94e6-b67c281dfa6d','','cheap good camera nice',7000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','d9f867fa-f18e-42f7-b4b1-3010c2a8db34','2006/03/30 02:55:30 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('99a0e9b3-95b9-4827-9939-b6ab12a49672','','good5',0,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','61805607-bcfc-46d6-a455-78d3cf7a3a86','2006/04/12 12:33:20 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('8336b3c0-b225-4340-b7c0-b6fe635a141f','','good',1000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/17 04:43:27 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('3ed08e5a-a2dd-4ff8-a21a-b8bdd3f4058e','','nice',26000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','61805607-bcfc-46d6-a455-78d3cf7a3a86','2006/04/01 03:16:42 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('d5107813-80bd-4e06-b20d-b9b29a5e9f96','','good',10000,'f13e0990-d483-4a66-a98f-4648ddc84c3b',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','d9f867fa-f18e-42f7-b4b1-3010c2a8db34','2006/04/18 09:42:59 AM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('751d59bc-affd-4ebd-8dec-bd59a900126d','','good',15000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','d58cc7f8-0139-4dcd-b47d-a35362cbf541','2006/03/30 03:02:28 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('07770e71-705b-439d-afce-bf23e91fa2db','','8',1000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','61805607-bcfc-46d6-a455-78d3cf7a3a86','2006/04/13 09:36:51 AM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('643d7be2-9bb5-4661-92b3-c1552491e4ec','','good',1000,'f13e0990-d483-4a66-a98f-4648ddc84c3b',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','d9f867fa-f18e-42f7-b4b1-3010c2a8db34','2006/04/18 09:38:08 AM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('83a03714-50b6-4316-a0ee-c30165ac4207','','good',22000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','bafb3eea-5d08-44a0-b26d-dcd585d6b731','2006/03/30 03:03:34 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('b2858b08-4af9-4e98-a4cd-c30f3e670feb','','good',1000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/17 04:43:27 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('7b9d2ed0-23cc-461a-9d4e-c442878ff2e7','','good',19000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','bafb3eea-5d08-44a0-b26d-dcd585d6b731','2006/03/30 03:03:22 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('022afab9-48a0-4dac-8648-c7a05eff2664','','good',13000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','d58cc7f8-0139-4dcd-b47d-a35362cbf541','2006/03/30 03:02:35 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('7b6f9575-5b91-4257-85b1-c96c129a5b88','','good',27000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','bafb3eea-5d08-44a0-b26d-dcd585d6b731','2006/03/30 03:03:45 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('86a9f5c9-0701-4b16-85c8-ca0ef0e256f2','','good',15000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','bafb3eea-5d08-44a0-b26d-dcd585d6b731','2006/03/30 03:03:07 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('20bf5f07-e3c6-4e5e-8807-cac1d78a554d','','good',21000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','bafb3eea-5d08-44a0-b26d-dcd585d6b731','2006/03/30 03:03:31 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('244e9d6a-163c-4bfa-8645-cadc9df7f415','','good',16000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','bafb3eea-5d08-44a0-b26d-dcd585d6b731','2006/03/30 03:03:10 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('5f7c66ec-72d8-44f6-adc2-ce055ef7d98e','','good',11000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','d58cc7f8-0139-4dcd-b47d-a35362cbf541','2006/03/30 03:02:41 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('86e15ac1-d4d1-466f-bbf8-ce7eefb2eb45','','good',1000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','d9f867fa-f18e-42f7-b4b1-3010c2a8db34','2006/04/18 09:36:58 AM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('ffa613a0-c705-48dd-9328-ce973c546318','','cheap camera',6000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','61805607-bcfc-46d6-a455-78d3cf7a3a86','2006/03/30 02:54:29 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('dbc12dd5-5eae-4437-83b0-cf3d7369cf85','','good',10000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/17 04:43:33 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('55e27a90-69ee-4091-aace-cf4afe0905f0','','cheap good camera nice',1000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','db23e872-4aa3-4eaf-b229-5d39612ba38d','2006/03/30 02:56:43 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('93eb0435-2d4f-4c26-9cf6-d065a748c99d','','good',30000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/17 04:45:22 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('dd94d6cc-be46-4e7e-b967-d2144a8310f3','','good',1000,'f13e0990-d483-4a66-a98f-4648ddc84c3b',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','61805607-bcfc-46d6-a455-78d3cf7a3a86','2006/04/17 06:09:12 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('02668ab3-6860-4fad-ab04-d446b1442b51','','good',1000,'f13e0990-d483-4a66-a98f-4648ddc84c3b',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','61805607-bcfc-46d6-a455-78d3cf7a3a86','2006/04/17 06:09:14 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('7b588fc5-70ae-455d-9e33-d4b26ce197fe','','good',10000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/17 04:43:35 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('aae27531-bab5-4eb1-ac51-d516106f45bf','','good',1000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/17 04:43:21 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('4dea5b93-ac95-4839-b438-d5c4cfa3ee06','','8',1000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','61805607-bcfc-46d6-a455-78d3cf7a3a86','2006/04/12 03:43:55 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('a3b16259-e2b0-477f-af4b-d7f783bfaad4','','cheap good camera',4000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','d9f867fa-f18e-42f7-b4b1-3010c2a8db34','2006/03/30 02:55:09 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('e788daa1-fca4-4759-8341-d8febb52c795','','8',1000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','61805607-bcfc-46d6-a455-78d3cf7a3a86','2006/04/12 05:36:23 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('c0507f66-8467-495d-bafb-db69649c58db','','good',1000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/17 04:43:22 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('3a5b9e8d-87f9-417e-9ea8-dc8e7da4d7e3','','good',10000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/17 04:43:33 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('5c88c701-82c0-49ec-954d-dd652ad3b379','','good',1000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/17 04:43:23 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('78b42933-d454-4a5b-b226-de39f7bf0ee1','','8',1000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','61805607-bcfc-46d6-a455-78d3cf7a3a86','2006/04/12 05:33:30 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('b422b56d-319b-4a4e-a0ef-dfa75d9020ec','','good',10000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/17 04:43:35 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('ec0d1b34-12a4-4de8-b051-e3986a63344d','','8',1000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','61805607-bcfc-46d6-a455-78d3cf7a3a86','2006/04/12 03:44:45 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('fba563f7-532f-4a71-ba8e-e3eb0c2331fc','','cheap good camera nice',5000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','db23e872-4aa3-4eaf-b229-5d39612ba38d','2006/03/30 02:56:25 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('686800a2-02ce-48a6-912d-e60e62d50fc0','','good',100,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','61805607-bcfc-46d6-a455-78d3cf7a3a86','2006/04/13 04:31:41 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('08a588d2-adfb-48ec-b21a-e62167b0dcd7','','good',30000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/17 04:45:19 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('dbdeded3-e225-4377-b86a-e9d2a94f1a56','','cheap price for ticket',50000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/03/30 05:42:33 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('b3728ea0-3b87-4350-8bc9-ebe6798490bd','','good',1000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/17 04:43:21 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('d541b49a-66a9-4185-a8c3-ec76a7c0c625','','cheap good camera nice',4000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','db23e872-4aa3-4eaf-b229-5d39612ba38d','2006/03/30 02:56:30 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('6d248b8b-d2ac-4824-a7cd-ed6d9c5463ff','','good',1000,'f13e0990-d483-4a66-a98f-4648ddc84c3b',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','61805607-bcfc-46d6-a455-78d3cf7a3a86','2006/04/17 06:09:14 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('40b662c8-6596-4bf4-8d89-f022f20357ee','','good',30000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/17 04:45:21 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('f78da471-2d7e-4f33-87da-f11c7644081b','','8',1000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','61805607-bcfc-46d6-a455-78d3cf7a3a86','2006/04/12 12:56:40 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('02e29c21-6ee3-46e1-8283-f3c27275278f','','goodie',11,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','61805607-bcfc-46d6-a455-78d3cf7a3a86','2006/04/13 09:50:31 AM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('19a6416b-f052-470b-b736-f42510ca6ad9','','good',10000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/17 04:43:34 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('1e05762f-d1ef-4252-80b7-f4af3db0836e','','good',10000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','d58cc7f8-0139-4dcd-b47d-a35362cbf541','2006/03/30 03:02:05 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('d5b40e0a-23ca-4315-b497-f7c0e302f5db','','nice',15000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','61805607-bcfc-46d6-a455-78d3cf7a3a86','2006/04/01 03:16:50 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('4b1e9fb1-f22d-4b7f-8dce-f7d97150aea7','','good',10000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/17 04:43:34 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('3859a289-46d0-4553-9bc8-f904b4b9787e','','cheap good camera',5000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','d9f867fa-f18e-42f7-b4b1-3010c2a8db34','2006/03/30 02:55:14 PM')
INSERT INTO [cb_item] ([item_id],[item_name],[item_desc],[item_price],[item_dist_id],[item_quantity],[item_unit],[item_currency],[seller_id],[category_id],[create_time]) VALUES ('60ba2629-800c-4053-9d2d-fc94460fac67','','good',10000,'159d2c86-1cd5-4a45-b1c5-000080e4ca25',1,'','','3675c118-5b02-4b6f-b948-f1a43b3538dc','6c486b90-f55d-4b94-8545-bb9eb2efb7fa','2006/04/17 04:43:35 PM')
ALTER TABLE [cb_item] CHECK CONSTRAINT ALL





ALTER TABLE [cb_post] NOCHECK CONSTRAINT ALL
INSERT INTO [cb_post] ([post_id],[mobile_number],[description]) VALUES ('08b344b0-41dd-4e81-9f86-05309b372340','192479175','new sdd sds')
INSERT INTO [cb_post] ([post_id],[mobile_number],[description]) VALUES ('44ad765c-201f-4c42-a112-2116584bc887','192479175','new ddd')
INSERT INTO [cb_post] ([post_id],[mobile_number],[description]) VALUES ('37495d58-86dd-4a81-a86d-3e89b456ebc0','192479175','new adad')
INSERT INTO [cb_post] ([post_id],[mobile_number],[description]) VALUES ('99b6fde4-c245-44a0-b472-6103d9225b32','192479175','new test state')
INSERT INTO [cb_post] ([post_id],[mobile_number],[description]) VALUES ('3d9017d2-1159-4067-ba13-75df9efed583','192479175','new dasd ads adad ada')
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


/************************ For search Schedule *************************/
USE msdb
--Job--
declare @dbname varchar(50)
set @dbname='dbCellBazaar' --CHANGE DATABASE NAME HERE

declare @jobname1 varchar(100),@jobname2 varchar(100)
set @jobname1='Start_Full on '+@dbname
set @jobname2='Start_Incremental on '+@dbname
IF NOT EXISTS (SELECT name FROM sysjobs WHERE name = @jobname1)
EXEC sp_add_job @job_name = @jobname1,	
	@category_name='Full-Text'
IF NOT EXISTS (SELECT name FROM sysjobs WHERE name = @jobname2)
EXEC sp_add_job @job_name = @jobname2,	
	@category_name='Full-Text'

--JobStep--
declare @command1 varchar(150), @command2 varchar(150)
set @command1 ='use '+@dbname+' exec sp_fulltext_catalog ''CBDBCatalog'', ''start_full'''
set @command2 ='use '+@dbname+' exec sp_fulltext_catalog ''CBDBCatalog'', ''start_incremental'''
IF NOT EXISTS (SELECT step_name FROM sysjobsteps WHERE job_id = (SELECT job_id FROM sysjobs WHERE name = @jobname1))
EXEC sp_add_jobstep @job_name = @jobname1, 
	@step_name = 'Full-Text Indexing for Start_Full',
   	@subsystem = 'TSQL', 
	@command =@command1
IF NOT EXISTS (SELECT step_name FROM sysjobsteps WHERE job_id = (SELECT job_id FROM sysjobs WHERE name = @jobname2))
EXEC sp_add_jobstep @job_name = @jobname2, 
	@step_name = 'Full-Text Indexing For Start_Incremental',
	@subsystem = 'TSQL', 
	@command =@command2

--JobSchedule--
IF NOT EXISTS (SELECT name FROM sysjobschedules WHERE job_id = (SELECT job_id FROM sysjobs WHERE name = @jobname1))
EXEC sp_add_jobschedule @job_name = @jobname1, 
   @name = 'Scheduled for Start_Full',
   @freq_type = 64 -- when SQLServerAgent service starts
IF NOT EXISTS (SELECT name FROM sysjobschedules WHERE job_id = (SELECT job_id FROM sysjobs WHERE name = @jobname2))
EXEC sp_add_jobschedule @job_name = @jobname2, 
   @name = 'Scheduled for Start_Incremental',
   @freq_type = 4, -- daily
   @freq_interval = 1,
   @freq_subday_type = 4, -- minutes
   @freq_subday_interval = 1

--JobServer--
IF NOT EXISTS (SELECT * FROM sysjobservers WHERE job_id = (SELECT job_id FROM sysjobs WHERE name = @jobname1))
EXEC sp_add_jobserver @job_name = @jobname1
IF NOT EXISTS (SELECT * FROM sysjobservers WHERE job_id = (SELECT job_id FROM sysjobs WHERE name = @jobname2))
EXEC sp_add_jobserver @job_name = @jobname2




-- database for web admin





END