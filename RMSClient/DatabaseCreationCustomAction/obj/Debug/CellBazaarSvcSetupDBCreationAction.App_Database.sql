IF NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'RMSDB')
BEGIN
	 CREATE DATABASE [RMSDB];
END
