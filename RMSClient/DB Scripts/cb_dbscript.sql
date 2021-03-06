/****** Object:  Database dbCellBazaar    Script Date: 3/14/2006 1:40:55 PM ******/
IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'dbCellBazaar')
	DROP DATABASE [dbCellBazaar]
GO

CREATE DATABASE [dbCellBazaar]  ON (NAME = N'dbCellBazaar_Data', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL\data\dbCellBazaar_Data.MDF' , SIZE = 2, FILEGROWTH = 10%) LOG ON (NAME = N'dbCellBazaar_Log', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL\data\dbCellBazaar_Log.LDF' , SIZE = 1, FILEGROWTH = 10%)
 COLLATE SQL_Latin1_General_CP1_CI_AS
GO

exec sp_dboption N'dbCellBazaar', N'autoclose', N'false'
GO

exec sp_dboption N'dbCellBazaar', N'bulkcopy', N'false'
GO

exec sp_dboption N'dbCellBazaar', N'trunc. log', N'false'
GO

exec sp_dboption N'dbCellBazaar', N'torn page detection', N'true'
GO

exec sp_dboption N'dbCellBazaar', N'read only', N'false'
GO

exec sp_dboption N'dbCellBazaar', N'dbo use', N'false'
GO

exec sp_dboption N'dbCellBazaar', N'single', N'false'
GO

exec sp_dboption N'dbCellBazaar', N'autoshrink', N'false'
GO

exec sp_dboption N'dbCellBazaar', N'ANSI null default', N'false'
GO

exec sp_dboption N'dbCellBazaar', N'recursive triggers', N'false'
GO

exec sp_dboption N'dbCellBazaar', N'ANSI nulls', N'false'
GO

exec sp_dboption N'dbCellBazaar', N'concat null yields null', N'false'
GO

exec sp_dboption N'dbCellBazaar', N'cursor close on commit', N'false'
GO

exec sp_dboption N'dbCellBazaar', N'default to local cursor', N'false'
GO

exec sp_dboption N'dbCellBazaar', N'quoted identifier', N'false'
GO

exec sp_dboption N'dbCellBazaar', N'ANSI warnings', N'false'
GO

exec sp_dboption N'dbCellBazaar', N'auto create statistics', N'true'
GO

exec sp_dboption N'dbCellBazaar', N'auto update statistics', N'true'
GO

if( (@@microsoftversion / power(2, 24) = 8) and (@@microsoftversion & 0xffff >= 724) )
	exec sp_dboption N'dbCellBazaar', N'db chaining', N'false'
GO

use [dbCellBazaar]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_cb_item_cb_category]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[cb_item] DROP CONSTRAINT FK_cb_item_cb_category
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_cb_item_cb_district]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[cb_item] DROP CONSTRAINT FK_cb_item_cb_district
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_cb_seller_cb_district]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[cb_seller] DROP CONSTRAINT FK_cb_seller_cb_district
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_cb_item_cb_seller]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[cb_item] DROP CONSTRAINT FK_cb_item_cb_seller
GO

/****** Object:  Table [dbo].[cb_category]    Script Date: 3/14/2006 1:40:55 PM ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[cb_category]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[cb_category]
GO

/****** Object:  Table [dbo].[cb_district]    Script Date: 3/14/2006 1:40:55 PM ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[cb_district]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[cb_district]
GO

/****** Object:  Table [dbo].[cb_item]    Script Date: 3/14/2006 1:40:55 PM ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[cb_item]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[cb_item]
GO

/****** Object:  Table [dbo].[cb_search]    Script Date: 3/14/2006 1:40:55 PM ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[cb_search]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[cb_search]
GO

/****** Object:  Table [dbo].[cb_seller]    Script Date: 3/14/2006 1:40:55 PM ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[cb_seller]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[cb_seller]
GO

/****** Object:  Table [dbo].[cb_state]    Script Date: 3/14/2006 1:40:55 PM ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[cb_state]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[cb_state]
GO

if (select DATABASEPROPERTY(DB_NAME(), N'IsFullTextEnabled')) <> 1 
exec sp_fulltext_database N'enable' 

GO


if exists (select * from dbo.sysfulltextcatalogs where name = N'CBDBCatalog')
exec sp_fulltext_catalog N'CBDBCatalog', N'drop'

GO

if not exists (select * from dbo.sysfulltextcatalogs where name = N'CBDBCatalog')
exec sp_fulltext_catalog N'CBDBCatalog', N'create' 

GO

/****** Object:  Table [dbo].[cb_category]    Script Date: 3/14/2006 1:40:57 PM ******/
CREATE TABLE [dbo].[cb_category] (
	[category_id] [uniqueidentifier] NOT NULL ,
	[category_name] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[parent_category_id] [uniqueidentifier] NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[cb_district]    Script Date: 3/14/2006 1:40:58 PM ******/
CREATE TABLE [dbo].[cb_district] (
	[district_id] [uniqueidentifier] NOT NULL ,
	[district_short_name] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[district_full_name] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO

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
	[category_id] [uniqueidentifier] NOT NULL 
) ON [PRIMARY]
GO

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
	[search_item_end_quantity] [float] NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[cb_seller]    Script Date: 3/14/2006 1:40:58 PM ******/
CREATE TABLE [dbo].[cb_seller] (
	[seller_id] [uniqueidentifier] NOT NULL ,
	[mobile_no] [bigint] NOT NULL ,
	[seller_name] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[seller_address] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[seller_dist_id] [uniqueidentifier] NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[cb_state]    Script Date: 3/14/2006 1:40:58 PM ******/
CREATE TABLE [dbo].[cb_state] (
	[state_id] [uniqueidentifier] NOT NULL ,
	[mobile_no] [bigint] NOT NULL ,
	[search_id] [uniqueidentifier] NOT NULL ,
	[current_state] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[unstate_time] [datetime] NULL 
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[cb_category] WITH NOCHECK ADD 
	CONSTRAINT [PK_cb_category] PRIMARY KEY  CLUSTERED 
	(
		[category_id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[cb_district] WITH NOCHECK ADD 
	CONSTRAINT [PK_cb_district] PRIMARY KEY  CLUSTERED 
	(
		[district_id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[cb_item] WITH NOCHECK ADD 
	CONSTRAINT [PK_cb_item] PRIMARY KEY  CLUSTERED 
	(
		[item_id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[cb_search] WITH NOCHECK ADD 
	CONSTRAINT [PK_cb_search] PRIMARY KEY  CLUSTERED 
	(
		[search_id],
		[serial_no]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[cb_seller] WITH NOCHECK ADD 
	CONSTRAINT [PK_cb_seller] PRIMARY KEY  CLUSTERED 
	(
		[seller_id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[cb_state] WITH NOCHECK ADD 
	CONSTRAINT [PK_cb_state] PRIMARY KEY  CLUSTERED 
	(
		[state_id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[cb_item] ADD 
	CONSTRAINT [DF_cb_item_item_currency] DEFAULT ('tk') FOR [item_currency]
GO

ALTER TABLE [dbo].[cb_search] ADD 
	CONSTRAINT [DF_cb_search_send_status] DEFAULT ('notsend') FOR [send_status]
GO

if (select DATABASEPROPERTY(DB_NAME(), N'IsFullTextEnabled')) <> 1 
exec sp_fulltext_database N'enable' 

GO

if not exists (select * from dbo.sysfulltextcatalogs where name = N'CBDBCatalog')
exec sp_fulltext_catalog N'CBDBCatalog', N'create' 

GO

exec sp_fulltext_table N'[dbo].[cb_item]', N'create', N'CBDBCatalog', N'PK_cb_item'
GO

exec sp_fulltext_column N'[dbo].[cb_item]', N'item_name', N'add', 1033  
GO

exec sp_fulltext_column N'[dbo].[cb_item]', N'item_desc', N'add', 1033  
GO

exec sp_fulltext_table N'[dbo].[cb_item]', N'activate'  
GO

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
GO

ALTER TABLE [dbo].[cb_seller] ADD 
	CONSTRAINT [FK_cb_seller_cb_district] FOREIGN KEY 
	(
		[seller_dist_id]
	) REFERENCES [dbo].[cb_district] (
		[district_id]
	)
GO

