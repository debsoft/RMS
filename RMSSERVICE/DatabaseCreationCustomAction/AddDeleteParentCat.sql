CREATE PROCEDURE parent_category_delete

@parent_cat_id int

AS

begin

declare @Error int

   BEGIN TRANSACTION
   delete from category4 where cat3_id IN (select cat3_id from category3 where cat2_id IN (select cat2_id from category2 where cat1_id IN (select cat1_id from category1 where parent_cat_id = @parent_cat_id)))
delete from category3 where cat2_id  IN (select cat2_id from category2 where cat1_id IN (select cat1_id from category1 where parent_cat_id = @parent_cat_id))
delete from category2 where cat1_id IN (select cat1_id from category1 where parent_cat_id = @parent_cat_id )
delete from category1 where parent_cat_id = @parent_cat_id
delete from parent_category where parent_cat_id =@parent_cat_id

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