IF NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'GP_InboxOutbox')
BEGIN
	CREATE DATABASE [GP_InboxOutbox];
END