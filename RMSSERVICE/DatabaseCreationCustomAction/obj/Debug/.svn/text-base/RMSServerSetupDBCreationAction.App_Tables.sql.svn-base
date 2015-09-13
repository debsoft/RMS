/****** Object:  Database RMSDB    Script Date: 1/25/2008 9:29:43 PM ******/

use [RMSDB]


/****** Object:  Table [dbo].[button_access]    Script Date: 1/25/2008 9:29:43 PM ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[button_access]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[bill_print_time] (
[order_id] [bigint] NOT NULL ,
[bill_print_time] [bigint] NULL ,
[payment_time] [bigint] NULL
) ON [PRIMARY]

ALTER TABLE [dbo].[bill_print_time] WITH NOCHECK ADD
CONSTRAINT [PK_bill_print_time] PRIMARY KEY CLUSTERED
(
[order_id]
) ON [PRIMARY]

END


/****** Object:  Table [dbo].[button_access]    Script Date: 1/25/2008 9:29:43 PM ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[button_access]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[button_access] (
	[user_id] [int] NOT NULL ,
	[button_id] [int] NOT NULL 
) ON [PRIMARY]

END


/****** Object:  Table [dbo].[button_color]    Script Date: 1/25/2008 9:29:43 PM ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[button_color]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[button_color] (
	[button_id] [int] IDENTITY (1, 1) NOT FOR REPLICATION  NOT NULL ,
	[name] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[color] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]

ALTER TABLE [dbo].[button_color] ADD 
	CONSTRAINT [PK_button_color] PRIMARY KEY  CLUSTERED 
	(
		[button_id]
	)  ON [PRIMARY] 

END

/****** Object:  Table [dbo].[category1]    Script Date: 1/25/2008 9:29:44 PM ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[category1]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[category1] (
	[cat1_id] [int] IDENTITY (1, 1) NOT FOR REPLICATION  NOT NULL ,
	[cat1_name] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[cat1_order] [int] NOT NULL ,
	[parent_cat_id] [int] NOT NULL 
) ON [PRIMARY]

ALTER TABLE [dbo].[category1] ADD 
	CONSTRAINT [PK_category1] PRIMARY KEY  CLUSTERED 
	(
		[cat1_id]
	)  ON [PRIMARY]
END

/****** Object:  Table [dbo].[category2]    Script Date: 1/25/2008 9:29:44 PM ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[category2]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[category2] (
	[cat2_id] [int] IDENTITY (1, 1) NOT FOR REPLICATION  NOT NULL ,
	[cat2_name] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[cat1_id] [int] NOT NULL ,
	[cat2_order] [int] NOT NULL ,
	[cat2_type] [tinyint] NULL ,
	[cat2_color] [varchar] (15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[view_table] [tinyint] NULL ,
	[view_bar] [tinyint] NULL ,
	[view_takeaway] [tinyint] NULL 
) ON [PRIMARY]

ALTER TABLE [dbo].[category2] ADD 
	CONSTRAINT [PK_category2] PRIMARY KEY  CLUSTERED 
	(
		[cat2_id]
	)  ON [PRIMARY]
END

/****** Object:  Table [dbo].[category3]    Script Date: 1/25/2008 9:29:44 PM ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[category3]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[category3] (
	[cat3_id] [int] IDENTITY (1, 1) NOT FOR REPLICATION  NOT NULL ,
	[cat3_name] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[cat2_id] [int] NOT NULL ,
	[description] [varchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[table_price] [float] NULL ,
	[tw_price] [float] NULL ,
	[bar_price] [float] NULL ,
	[status] [tinyint] NOT NULL ,
	[cat3_order] [int] NOT NULL ,
	[view_table] [tinyint] NULL ,
	[view_bar] [tinyint] NULL ,
	[view_takeaway] [tinyint] NULL ,
	[cat3_rank] [bigint] NULL 
) ON [PRIMARY]

ALTER TABLE [dbo].[category3] ADD 
	CONSTRAINT [DF_category3_status] DEFAULT (1) FOR [status],
	CONSTRAINT [DF_category3_cat3_rankl] DEFAULT (0) FOR [cat3_rank],
	CONSTRAINT [PK_category3] PRIMARY KEY  CLUSTERED 
	(
		[cat3_id]
	)  ON [PRIMARY] 
END

/****** Object:  Table [dbo].[category4]    Script Date: 1/25/2008 9:29:44 PM ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[category4]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[category4] (
	[cat4_id] [int] IDENTITY (1, 1) NOT FOR REPLICATION  NOT NULL ,
	[cat4_name] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[cat3_id] [int] NOT NULL ,
	[description] [varchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[table_price] [float] NULL ,
	[tw_price] [float] NULL ,
	[bar_price] [float] NULL ,
	[status] [tinyint] NOT NULL ,
	[cat4_order] [int] NOT NULL ,
	[view_table] [tinyint] NULL ,
	[view_bar] [tinyint] NULL ,
	[view_takeaway] [tinyint] NULL ,
	[cat4_rank] [bigint] NULL 
) ON [PRIMARY]

ALTER TABLE [dbo].[category4] ADD 
	CONSTRAINT [DF_Category4_status] DEFAULT (1) FOR [status],
	CONSTRAINT [DF_category4_cat4_rank] DEFAULT (0) FOR [cat4_rank],
	CONSTRAINT [PK_category4] PRIMARY KEY  CLUSTERED 
	(
		[cat4_id]
	)  ON [PRIMARY] 
END


/****** Object:  Table [dbo].[current_users]    Script Date: 1/25/2008 9:29:44 PM ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[current_users]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[current_users] (
	[user_id] [int] NOT NULL ,
	[pc_id] [int] NOT NULL 
) ON [PRIMARY]
END

/****** Object:  Table [dbo].[customer_info]    Script Date: 1/25/2008 9:29:44 PM ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[customer_info]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[customer_info] (
	[customer_id] [bigint] IDENTITY (1, 1) NOT FOR REPLICATION  NOT NULL ,
	[name] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[phone] [varchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[postal_code] [varchar] (15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[address] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[town] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[county] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[country] [char] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]

ALTER TABLE [dbo].[customer_info] ADD 
	CONSTRAINT [PK_customer_info] PRIMARY KEY  CLUSTERED 
	(
		[customer_id]
	)  ON [PRIMARY] 


END

/****** Object:  Table [dbo].[delivery]    Script Date: 1/25/2008 9:29:44 PM ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[delivery]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[delivery] (
[order_id] [bigint] NOT NULL ,
[delivery_time] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY]


ALTER TABLE [dbo].[delivery] WITH NOCHECK ADD
CONSTRAINT [PK_delivery] PRIMARY KEY CLUSTERED
(
[order_id]
) ON [PRIMARY]

END

/****** Object:  Table [dbo].[deposit]    Script Date: 1/25/2008 9:29:44 PM ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[deposit]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[deposit] (
	[deposit_id] [bigint] IDENTITY (1012431210159, 3) NOT FOR REPLICATION  NOT NULL ,
	[cash_amount] [float] NULL ,
	[EFT_amount] [float] NULL ,
	[cheque_amount] [float] NULL ,
	[voucher_amount] [float] NULL ,
	[account_pay] [float] NULL ,
	[balance] [float] NULL 
) ON [PRIMARY]

ALTER TABLE [dbo].[deposit] ADD 
	CONSTRAINT [DF_deposit_cash_amount] DEFAULT (0) FOR [cash_amount],
	CONSTRAINT [DF_deposit_EFT_amount] DEFAULT (0) FOR [EFT_amount],
	CONSTRAINT [DF_deposit_cheque_amount] DEFAULT (0) FOR [cheque_amount],
	CONSTRAINT [DF_deposit_voucher_amount] DEFAULT (0) FOR [voucher_amount],
	CONSTRAINT [DF_deposit_account_pay0] DEFAULT (0) FOR [account_pay],
	CONSTRAINT [DF_deposit_balance] DEFAULT (0) FOR [balance],
	CONSTRAINT [PK_deposit] PRIMARY KEY  CLUSTERED 
	(
		[deposit_id]
	)  ON [PRIMARY] 
END

/****** Object:  Table [dbo].[kitchen_print]    Script Date: 1/25/2008 9:29:44 PM ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[kitchen_print]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[kitchen_print] (
	[print_id] [bigint] IDENTITY (1, 1) NOT FOR REPLICATION  NOT NULL ,
	[order_id] [bigint] NOT NULL ,
	[print_time] [bigint] NOT NULL ,
	[pc_id] [int] NOT NULL 
) ON [PRIMARY]

ALTER TABLE [dbo].[kitchen_print] ADD 
	CONSTRAINT [PK_kitchen_print] PRIMARY KEY  CLUSTERED 
	(
		[print_id]
	)  ON [PRIMARY] 

END


/****** Object:  Table [dbo].[login_history]    Script Date: 1/25/2008 9:29:44 PM ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[login_history]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[login_history] (
	[user_id] [int] NOT NULL ,
	[pc_id] [tinyint] NOT NULL ,
	[login_time] [bigint] NOT NULL ,
	[logout_time] [bigint] NOT NULL 
) ON [PRIMARY]
END

/****** Object:  Table [dbo].[order_details]    Script Date: 1/25/2008 9:29:44 PM ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[order_details]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[order_details] (
	[order_detail_id] [bigint] IDENTITY (1, 1) NOT FOR REPLICATION  NOT NULL ,
	[order_id] [bigint] NOT NULL ,
	[product_id] [bigint] NOT NULL ,
	[quantity] [smallint] NOT NULL ,
	[amount] [float] NOT NULL ,
	[remarks] [varchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[food_type] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[cat_level] [tinyint] NOT NULL 
) ON [PRIMARY]

ALTER TABLE [dbo].[order_details] ADD 
	CONSTRAINT [DF_order_details_quantity] DEFAULT (0) FOR [quantity],
	CONSTRAINT [DF_order_details_amount] DEFAULT (0) FOR [amount],
	CONSTRAINT [PK_order_details] PRIMARY KEY  CLUSTERED 
	(
		[order_detail_id]
	)  ON [PRIMARY] 

END

/****** Object:  Table [dbo].[order_details_archive]    Script Date: 1/25/2008 9:29:44 PM ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[order_details_archive]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[order_details_archive] (
	[order_detail_id] [bigint] NOT NULL ,
	[order_id] [bigint] NOT NULL ,
	[product_id] [bigint] NOT NULL ,
	[quantity] [smallint] NOT NULL ,
	[amount] [float] NOT NULL ,
	[remarks] [varchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[food_type] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[cat_level] [tinyint] NOT NULL 
) ON [PRIMARY]

ALTER TABLE [dbo].[order_details_archive] ADD 
	CONSTRAINT [PK_order_details_archive] PRIMARY KEY  CLUSTERED 
	(
		[order_detail_id]
	)  ON [PRIMARY] 
END

/****** Object:  Table [dbo].[order_info]    Script Date: 1/25/2008 9:29:44 PM ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[order_info]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[order_info] (
	[order_id] [bigint] IDENTITY (1, 1) NOT FOR REPLICATION  NOT NULL ,
	[customer_id] [bigint] NULL ,
	[user_id] [int] NOT NULL ,
	[order_type] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[order_time] [bigint] NOT NULL ,
	[status] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[guest_count] [int] NULL ,
	[table_number] [int] NULL ,
	[table_name] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 	
) ON [PRIMARY]

ALTER TABLE [dbo].[order_info] ADD 
	CONSTRAINT [PK_order] PRIMARY KEY  CLUSTERED 
	(
		[order_id]
	)  ON [PRIMARY] 

END

/****** Object:  Table [dbo].[order_info_archive]    Script Date: 1/25/2008 9:29:44 PM ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[order_info_archive]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[order_info_archive] (
[order_id] [bigint] NOT NULL ,
[customer_id] [bigint] NULL ,
[user_id] [int] NOT NULL ,
[order_type] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
[order_time] [bigint] NOT NULL ,
[status] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
[guest_count] [int] NULL ,
[table_number] [int] NULL ,
[table_name] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
[serial_no] [bigint] NOT NULL
) ON [PRIMARY]

ALTER TABLE [dbo].[order_info_archive] WITH NOCHECK ADD
CONSTRAINT [PK_order_info_archive] PRIMARY KEY CLUSTERED
(
[order_id]
) ON [PRIMARY]
END


/****** Object:  Table [dbo].[order_seat_time]    Script Date: 1/25/2008 9:29:45 PM ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[order_seat_time]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[order_seat_time] (
	[order_id] [bigint] NOT NULL ,
	[seat_time] [bigint] NOT NULL 
) ON [PRIMARY]

ALTER TABLE [dbo].[order_seat_time] ADD 
	CONSTRAINT [PK_order_seat_time] PRIMARY KEY  CLUSTERED 
	(
		[order_id]
	)  ON [PRIMARY] 
END

/****** Object:  Table [dbo].[parent_category]    Script Date: 1/25/2008 9:29:45 PM ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[parent_category]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[parent_category] (
	[parent_cat_id] [int] IDENTITY (1, 1) NOT FOR REPLICATION  NOT NULL ,
	[parent_cat_name] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[parent_cat_order] [smallint] NULL 
) ON [PRIMARY]

ALTER TABLE [dbo].[parent_category] ADD 
	CONSTRAINT [DF_parent_category_parent_cat_order] DEFAULT (0) FOR [parent_cat_order],
	CONSTRAINT [PK_parent_category] PRIMARY KEY  CLUSTERED 
	(
		[parent_cat_id]
	)  ON [PRIMARY] 
END

/****** Object:  Table [dbo].[payment]    Script Date: 1/25/2008 9:29:45 PM ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[payment]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[payment] (
	[payment_id] [bigint] IDENTITY (1, 1) NOT FOR REPLICATION  NOT NULL ,
	[order_id] [bigint] NOT NULL ,
	[pc_id] [int] NOT NULL ,
	[total_amount] [float] NOT NULL ,
	[cash_amount] [float] NULL ,
	[EFT_amount] [float] NULL ,
	[cheque_amount] [float] NULL ,
	[voucher_amount] [float] NULL ,
	[service_amount] [float] NULL ,
	[discount] [float] NULL ,
	[account_pay] [float] NULL ,
	[deposit_id] [bigint] NULL ,
	[deposit_amount] [float] NULL 
) ON [PRIMARY]


ALTER TABLE [dbo].[payment] ADD 
	CONSTRAINT [DF_payment_total_amount] DEFAULT (0) FOR [total_amount],
	CONSTRAINT [DF_payment_cash_amount] DEFAULT (0) FOR [cash_amount],
	CONSTRAINT [DF_payment_EFT_amount] DEFAULT (0) FOR [EFT_amount],
	CONSTRAINT [DF_payment_cheque_amount] DEFAULT (0) FOR [cheque_amount],
	CONSTRAINT [DF_payment_voucher_amount] DEFAULT (0) FOR [voucher_amount],
	CONSTRAINT [DF_payment_service_amount] DEFAULT (0) FOR [service_amount],
	CONSTRAINT [DF_payment_discount] DEFAULT (0) FOR [discount],
	CONSTRAINT [DF_payment_account_pay] DEFAULT (0) FOR [account_pay],
	CONSTRAINT [DF_payment_deposit_amount] DEFAULT (0) FOR [deposit_amount],
	CONSTRAINT [PK_payment] PRIMARY KEY  CLUSTERED 
	(
		[payment_id]
	)  ON [PRIMARY] 
END

/****** Object:  Table [dbo].[pc_info]    Script Date: 1/25/2008 9:29:45 PM ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[pc_info]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[pc_info] (
	[pc_id] [int] IDENTITY (1, 1) NOT FOR REPLICATION  NOT NULL ,
	[pc_ip] [varchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[name] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]

ALTER TABLE [dbo].[pc_info] ADD 
	CONSTRAINT [PK_pc_info] PRIMARY KEY  CLUSTERED 
	(
		[pc_id]
	)  ON [PRIMARY] 
END




/****** Object:  Table [dbo].[print_style]    Script Date: 1/25/2008 9:29:45 PM ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[print_style]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[print_style] (
	[style_id] [int] NOT NULL ,
	[header] [varchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[body] [varchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[footer] [varchar] (1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[style_name] [varchar] (150) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]

ALTER TABLE [dbo].[print_style] ADD 
	CONSTRAINT [PK_print_style] PRIMARY KEY  CLUSTERED 
	(
		[style_id]
	)  ON [PRIMARY] 
END

delete from print_style

insert into print_style values(1,'header','body', 'footer','normal')

insert into print_style values(2,'header','body', 'footer','kitchen')


/****** Object:  Table [dbo].[stock]    Script Date: 1/25/2008 9:29:45 PM ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[stock]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[stock] (
	[stock_id] [int] IDENTITY (1, 1) NOT FOR REPLICATION  NOT NULL ,
	[cat_id] [int] NOT NULL ,
	[cat_level] [tinyint] NOT NULL ,
	[quantity] [float] NOT NULL ,
	[unit] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]

ALTER TABLE [dbo].[stock] ADD 
	CONSTRAINT [DF_stock_quantity] DEFAULT (0) FOR [quantity],
	CONSTRAINT [PK_stock] PRIMARY KEY  CLUSTERED 
	(
		[stock_id]
	)  ON [PRIMARY] 
END

/****** Object:  Table [dbo].[table_info]    Script Date: 1/25/2008 9:29:45 PM ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[table_info]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[table_info] (
	[table_number] [int] NOT NULL ,
	[capacity] [smallint] NULL ,
	[status] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[table_type] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]

ALTER TABLE [dbo].[table_info] ADD 
	CONSTRAINT [PK_table_info] PRIMARY KEY  CLUSTERED 
	(
		[table_number],
		[table_type]
	)  ON [PRIMARY] 
END

/****** Object:  Table [dbo].[terminal_print]    Script Date: 1/25/2008 9:29:45 PM ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[terminal_print]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[terminal_print] (
	[print_id] [bigint] IDENTITY (1, 1) NOT FOR REPLICATION  NOT NULL ,
	[order_id] [bigint] NOT NULL ,
	[print_time] [bigint] NOT NULL ,
	[pc_id] [int] NOT NULL 
) ON [PRIMARY]

ALTER TABLE [dbo].[terminal_print] ADD 
	CONSTRAINT [PK_terminal_print] PRIMARY KEY  CLUSTERED 
	(
		[print_id]
	)  ON [PRIMARY] 
END

/****** Object:  Table [dbo].[user_info]    Script Date: 1/25/2008 9:29:45 PM ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[user_info]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[user_info] (
	[user_id] [int] IDENTITY (1, 1) NOT FOR REPLICATION  NOT NULL ,
	[user_name] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[password] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[type] [int] NOT NULL ,
	[status] [int] NOT NULL ,
	[gender] [varchar] (15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]

ALTER TABLE [dbo].[user_info] ADD 
	CONSTRAINT [PK_user_info] PRIMARY KEY  CLUSTERED 
	(
		[user_id]
	)  ON [PRIMARY] 
END


/****** Object:  Table [dbo].[booking_info]    Script Date: 1/25/2008 9:29:45 PM ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[booking_info]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[booking_info] (
	[booking_id] [bigint] IDENTITY (1, 1) NOT FOR REPLICATION  NOT NULL ,
	[booking_type] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[booking_time] [bigint] NOT NULL ,
	[customer_id] [bigint] NULL ,
	[guest_count] [int] NULL ,
	[status] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[comments] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[table_count] [int] NULL 
) ON [PRIMARY]

ALTER TABLE [dbo].[booking_info] ADD 
	CONSTRAINT [PK_booking_info] PRIMARY KEY  CLUSTERED 
	(
		[booking_id]
	)  ON [PRIMARY] 
	
END


/****** Object:  Table [dbo].[booking_info]    Script Date: 1/25/2008 9:29:45 PM ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[booking_info]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[order_serial] (
[order_id] [bigint] NOT NULL ,
[serial_no] [bigint] IDENTITY (102312314231, 3) NOT FOR REPLICATION NOT NULL
) ON [PRIMARY]

ALTER TABLE [dbo].[order_serial] WITH NOCHECK ADD
CONSTRAINT [PK_order_serial] PRIMARY KEY CLUSTERED
(
[order_id]
) ON [PRIMARY]
	
END


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[category1_delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE category1_delete



if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[category2_delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE category2_delete



if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[category3_delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE category3_delete


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[category4_delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE category4_delete



if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[parent_category_delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE parent_category_delete




