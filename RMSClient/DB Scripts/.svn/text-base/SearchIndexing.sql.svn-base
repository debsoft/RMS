-- Enable database for fulltext indexing --
if (select DATABASEPROPERTY(DB_NAME(), 'IsFullTextEnabled')) <> 1 
EXEC sp_fulltext_database 'enable' 
GO
-- Create and build the catalog for fulltext indexing --
if not exists (select * from dbo.sysfulltextcatalogs where name = 'CBDBCatalog')
EXEC sp_fulltext_catalog 'CBDBCatalog', 'create' 
GO



-- Start of Indexing of gc_EventElement table --
EXEC sp_fulltext_table '[cb_item]', 'create', 'CBDBCatalog', 'PK_cb_item'
GO
-- add name field for indexing --
EXEC sp_fulltext_column '[cb_item]', 'item_name', 'add'
GO
-- add description field for indexing --
EXEC sp_fulltext_column '[cb_item]', 'item_desc', 'add' 
GO
-- activate the table for fulltext indexing --
EXEC sp_fulltext_table '[cb_item]', 'activate'  
GO
-- End of Indexing of gc_Event table --

-- Start full poplulation --
EXEC sp_fulltext_catalog 'CBDBCatalog', 'start_full'
GO