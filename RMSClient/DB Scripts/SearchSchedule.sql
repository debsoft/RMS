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
