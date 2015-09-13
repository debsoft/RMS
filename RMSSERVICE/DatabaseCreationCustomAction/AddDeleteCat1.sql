
CREATE PROCEDURE category1_delete
@cat1_id int
AS
begin
declare @Error int
   BEGIN TRANSACTION
   delete from category4 where cat3_id IN (select cat3_id from category3 where cat2_id IN (select cat2_id from category2 where cat1_id = @cat1_id))
delete from category3 where cat2_id IN (select cat2_id from category2 where cat1_id = @cat1_id)
delete from category2 where cat1_id =@cat1_id
delete from category1 where cat1_id =@cat1_id

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