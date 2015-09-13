CREATE PROCEDURE category3_delete

@cat3_id int

AS

begin

declare @Error int

   BEGIN TRANSACTION
   delete from category4 where cat3_id = @cat3_id
delete from category3 where cat3_id =@cat3_id

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