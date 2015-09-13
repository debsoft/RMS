CREATE PROCEDURE category4_delete

@cat4_id int

AS

begin

declare @Error int

   BEGIN TRANSACTION
   
delete from category4 where cat4_id = @cat4_id
  set @Error = @@ERROR
   if @Error <> 0
Begin
 ROLLBACK TRANSACTION
end
Else
begin
 COMMIT TRANSACTION
end

End