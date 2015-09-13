using System;
using System.Collections.Generic;
using System.Text;

using RMS.Common;


namespace RMS.DataAccess
{
    public class SqlQueries
    {
        private static string m_sDateFormat = "SET DateFormat {0};";
        private static CCommonConstants oConstants;

        static SqlQueries()
        {
            if (oConstants == null)
            {
                oConstants = ConfigManager.GetConfig<CCommonConstants>();
                m_sDateFormat = string.Format(m_sDateFormat, oConstants.SqlQueryDateFormat);
            }
        }

        public static string GetQuery(Query eQuery)
        {
            string sRetval;

            switch (eQuery)
            {
                #region Users

                //case Query.CategoryCreate:
                //    sRetval = "INSERT INTO cb_category VALUES ('{0}','{1}','{2}','{3}', '{4}')";
                //    break;

                case Query.DeleteCurrentUser:
                    sRetval = "delete from current_users where user_id =  {0}; ";
                    break;

                case Query.DeleteAllButtonAccess:
                    sRetval = "delete  FROM button_access  where user_id = {0} ;";
                    break;

                case Query.DeleteUser:
                    sRetval = "delete  FROM user_info  where user_id = {0} ;";
                    break;

                case Query.UnlockUser:
                    sRetval = "delete  FROM current_users  where user_id = {0} ;";
                    break;


                case Query.ViewUserInfo:
                    sRetval = "SELECT user_id, user_name , password , type , status, gender,'UPDATE' as up,'DELETE' as del FROM user_info ;";
                    break;

                case Query.ViewCurrentUsers:
                    sRetval = "SELECT a.user_id, a.user_name, b.pc_ip  FROM user_info a, pc_info b, current_users c  where c.user_id = a.user_id and c.pc_id = b.pc_id ;";
                    break;


                case Query.GetButtonIDByName:
                    sRetval = "SELECT button_id from button_color where name = '{0}' ";
                    break;

                case Query.GetUserAccess:
                    sRetval = "select b.name from user_info a, button_color b, button_access c  where a.user_id = c.user_id and a.user_id = {0} and c.button_id = b.button_id ; ";
                    break;

                case Query.getUserByID:
                    sRetval = "select user_id, user_name, password, type, status, gender from user_info where user_id = {0} ; ";
                    break;

                case Query.LoginUser:
                    sRetval = "SELECT user_id, user_name, password, type, status, gender FROM user_info where user_name = '{0}' ";
                    break;

                case Query.UserInfoByUsername:
                    sRetval = "select user_id,user_name,password,type,status,gender from user_info where user_name='{0}'";
                    break;



                case Query.AddButtonAccess:
                    sRetval = " insert into button_access values({0},{1}) ";
                    break;


                case Query.AddUser:
                    sRetval = " insert into user_info values('{0}','{1}',{2},{3},'{4}') ";
                    break;



                case Query.UpdateUser:
                    sRetval = " update user_info set user_name = '{0}', password = '{1}', type = {2}, status = {3}, gender = '{4}'  where user_id = {5} ";
                    break;



                case Query.CheckDupUser:
                    sRetval = "SELECT user_id  FROM user_info where user_name = '{0}' ;";
                    break;

                case Query.CheckDupUserForUpdate:
                    sRetval = "SELECT user_id  FROM user_info where user_name = '{0}' and user_id != {1} ;";
                    break;

                    //New at 30.07.2009
                case Query.GetPrintStyles:
                    sRetval = "select style_id,header,body,footer,style_name from print_style";
                    break;


                #endregion

                #region Category rank

                case Query.GetChildCat3ByCat2:
                    sRetval = "SELECT cat3_id, cat3_order FROM category3 where cat2_id = {0}  ";
                    break;

                case Query.GetChildCat4ByCat2:
                    sRetval = "SELECT a.cat4_id, a.cat4_order, b.cat3_order FROM category4 a, category3 b where a.cat3_id = b.cat3_id and b.cat2_id = {0}   ";
                    break;

                case Query.GetChildCat4ByCat3:
                    sRetval = "SELECT a.cat4_id, a.cat4_order FROM category4 a where a.cat3_id = {0}   ";
                    break;



                case Query.GetCategory2Order:
                    sRetval = "SELECT cat2_order FROM category2  where cat2_id = {0}   ";
                    break;

                case Query.GetCategory23Order:
                    sRetval = "SELECT a.cat2_order, b.cat3_order  FROM category2 a, category3 b  where a.cat2_id = b.cat2_id and b.cat3_id = {0}   ";
                    break;



                case Query.UpdateCat3Rank:
                    sRetval = " update category3 set cat3_rank = {0},user_id='{2}',datetime={3}  where cat3_id = {1} ";
                    break;

                case Query.UpdateCat4Rank:
                    sRetval = " update category4 set cat4_rank = {0},user_id='{2}',datetime={3}  where cat4_id = {1} ";
                    break;

                #endregion

                #region Category view

                case Query.GetParentCat:
                    sRetval = "SELECT parent_cat_id, parent_cat_name, parent_cat_order FROM parent_category ";
                    break;

                case Query.GetParentCatByID:
                    sRetval = "SELECT parent_cat_id, parent_cat_name FROM parent_category where parent_cat_id = {0}; ";
                    break;



                case Query.ViewParentCategory:
                    sRetval = "SELECT parent_cat_id, parent_cat_name as Parent_Category_Name,'UPDATE' as up,'DELETE' as del  FROM parent_category ";
                    break;

                case Query.ViewParentCategoryCombo:
                    sRetval = "SELECT parent_cat_id, parent_cat_name FROM parent_category order by parent_cat_name asc ;";
                    break;

                //case Query.ViewCategory1:
                //    sRetval = "SELECT a.cat1_id, a.cat1_name as Category1_Name,  b.parent_cat_name as Parent_Category_Name FROM category1 a, parent_category b where a.parent_cat_id = b.parent_cat_id  order by a.cat1_name  asc";
                //    break;

                case Query.ViewCategory1:
                    sRetval = "SELECT a.cat1_id, a.cat1_name as Category1_Name,  b.parent_cat_name as Parent_Category_Name,a.Cat1_order_number,'UPDATE' as up,'DELETE' as del FROM category1 a, parent_category b where a.parent_cat_id = b.parent_cat_id  order by a.Cat1_order_number  asc";
                    break;

                case Query.ViewCat1ComboBox:
                    sRetval = "SELECT a.cat1_id, a.cat1_name   FROM category1 a, parent_category b where a.parent_cat_id = b.parent_cat_id  and b.parent_cat_id = {0} order by a.cat1_name asc ;";
                    break;

                case Query.UpdateCategory1Order:
                    sRetval = "update category1 set Cat1_order_number={1},user_id='{2}', datetime={3} where cat1_id={0}";
                    break;

                //case Query.ViewCategory1ByParentCat:
                //    sRetval = "SELECT a.cat1_id, a.cat1_name as Category1_Name, b.parent_cat_name as Parent_Category_Name  FROM category1 a, parent_category b where a.parent_cat_id = b.parent_cat_id and a.parent_cat_id = {0}  order by a.cat1_name asc;";
                //    break;

                case Query.ViewCategory1ByParentCat:
                    sRetval = "SELECT a.cat1_id, a.cat1_name as Category1_Name, b.parent_cat_name as Parent_Category_Name,a.Cat1_order_number,'UPDATE' as up,'DELETE' as del  FROM category1 a, parent_category b where a.parent_cat_id = b.parent_cat_id and a.parent_cat_id = {0}  order by a.Cat1_order_number  asc;";
                    break;

                case Query.ViewCategory2:
                    sRetval = "SELECT a.cat2_id, a.cat2_name as Category2_Name, b.cat1_name as Category1_Name, a.cat2_order as Category2_Order, c.parent_cat_name as Parent_Category_Name FROM category2 a, category1 b, parent_category c where  a.cat1_id = b.cat1_id and b.parent_cat_id = c.parent_cat_id order by a.cat2_order asc";
                    break;

                case Query.ViewCategory2ByCat1:
                    sRetval = "SELECT a.cat2_id, a.cat2_name as Category2_Name, b.cat1_name as Category1_Name, a.cat2_order as Category2_Order, c.parent_cat_name as Parent_Category_Name,'UPDATE' as up,'DELETE' as del FROM category2 a, category1 b, parent_category c where  a.cat1_id = b.cat1_id and b.parent_cat_id = c.parent_cat_id and a.cat1_id = {0} order by a.cat2_order asc";
                    break;

                case Query.ViewCategory2ByCat1ComboBox:
                    sRetval = "SELECT a.cat2_id, a.cat2_name FROM category2 a, category1 b where  a.cat1_id = b.cat1_id and b.cat1_id = {0} order by a.cat2_name asc";
                    break;

                case Query.ViewCategory3:
                    sRetval = "SELECT a.cat3_id, a.cat3_name as Category3_Name, a.cat3_order as Category3_Order, b.cat2_name as Category2_Name, c.cat1_name as Category1_Name, d.parent_cat_name as Parent_Category_Name  FROM category3 a, category2 b, category1 c, parent_category d  where a.cat2_id = b.cat2_id  and b.cat1_id = c.cat1_id and c.parent_cat_id = d.parent_cat_id  order by a.cat3_order asc";
                    break;

                case Query.ViewCategory4:
                    sRetval = "SELECT e.cat4_id, e.cat4_name as Category4_Name, e.cat4_order as Category4_Order,a.cat3_name as Category3_Name, b.cat2_name as Category2_Name, c.cat1_name as Category1_Name, d.parent_cat_name as Parent_Category_Name  FROM category3 a, category2 b, category1 c, parent_category d, category4 e  where e.cat3_id = a.cat3_id and a.cat2_id = b.cat2_id  and b.cat1_id = c.cat1_id and c.parent_cat_id = d.parent_cat_id  order by e.cat4_order asc ";
                    break;

                case Query.ViewCategory3ByCat2Grid:
                    sRetval = "SELECT a.cat3_id, a.cat3_name as Category3_Name, a.cat3_order as Category3_Order, b.cat2_name as Category2_Name, c.cat1_name as Category1_Name, d.parent_cat_name as Parent_Category_Name,'UPDATE' as up,'DELETE' as del  FROM category3 a, category2 b, category1 c, parent_category d  where a.cat2_id = b.cat2_id  and b.cat1_id = c.cat1_id and c.parent_cat_id = d.parent_cat_id and a.cat2_id = {0} order by a.cat3_order asc";
                    break;


                case Query.ViewCategory3ByCat2:
                    sRetval = "SELECT a.cat3_id, a.cat3_name FROM category3 a, category2 b  where a.cat2_id = b.cat2_id and a.cat2_id = {0} order by a.cat3_name asc ;";
                    break;

                case Query.ViewCategory3ByCat2ComboBox:
                    sRetval = "SELECT a.cat3_id, a.cat3_name FROM category3 a, category2 b  where a.cat2_id = b.cat2_id and a.cat2_id = {0} order by a.cat3_name asc ;";
                    break;


                case Query.ViewCategory4ByCat3:
                    sRetval = "SELECT e.cat4_id, e.cat4_name as Category4_Name, e.cat4_order as Category4_Order, a.cat3_name as Category3_Name, b.cat2_name as Category2_Name, c.cat1_name as Category1_Name, d.parent_cat_name as Parent_Category_Name,'UPDATE' as up,'DELETE' as del  FROM category3 a, category2 b, category1 c, parent_category d, category4 e  where e.cat3_id = a.cat3_id and a.cat2_id = b.cat2_id  and b.cat1_id = c.cat1_id and c.parent_cat_id = d.parent_cat_id  and e.cat3_id = {0} order by e.cat4_order asc;";// "SELECT a.cat4_id, a.cat4_name FROM category4 a, category3 b  where a.cat3_id = b.cat3_id and a.cat4_id = {0} ";
                    break;

                case Query.ViewCategory4ByCat3ComboBox:
                    sRetval = "SELECT a.cat4_id, a.cat4_name, b.cat3_name FROM category4 a, category3 b  where a.cat3_id = b.cat3_id and a.cat3_id = {0} ";
                    break;

                case Query.ViewCategory3ByCat1:
                    sRetval = "SELECT a.cat3_id, a.cat3_name, b.cat2_name, c._cat1_name, d.parent_cat_name  FROM category3 a, category2 b, category1 c, parent_category d  where a.cat2_id = b.cat2_id  and b.cat1_id = c.cat1_id and c.parent_cat_id = d.parent_cat_id  and c.cat1_id = {0} ";
                    break;

                case Query.ViewCategory3ByParentCat:
                    sRetval = "SELECT a.cat3_id, a.cat3_name, b.cat2_name, c._cat1_name, d.parent_cat_name  FROM category3 a, category2 b, category1 c, parent_category d  where a.cat2_id = b.cat2_id  and b.cat1_id = c.cat1_id and c.parent_cat_id = d.parent_cat_id  and d.parent_cat_id = {0} ";
                    break;




                #endregion

                #region Category add
                //New by Baruri at 31.12.2008
                case Query.GetMaxCat1Order:
                    sRetval = "SELECT IsNull(max(Cat1_order_number),0) as max_cat1_order FROM category1 ";
                    break;

                case Query.GetMaxCat2Order:
                    sRetval = "SELECT IsNull(max(cat2_order),0) as max_cat2_order FROM category2 ";
                    break;

                case Query.GetMaxCat3Order:
                    sRetval = "SELECT IsNull(max(cat3_order),0) as max_cat3_order FROM category3 ";
                    break;

                case Query.GetMaxCat4Order:
                    sRetval = "SELECT  IsNull(max(cat4_order),0) as max_cat4_order FROM category4 ";
                    break;

                case Query.AddParentCategory:
                    sRetval = " insert into parent_category (parent_cat_name) values ('{0}') ";
                    break;


                case Query.CheckDupParentCatOrder:
                    sRetval = "SELECT parent_cat_id  FROM parent_category where parent_cat_order = {0} ;";
                    break;

                case Query.CheckDupParentCat:
                    sRetval = "SELECT parent_cat_id  FROM parent_category where parent_cat_name = '{0}' ;";
                    break;

                case Query.CheckDupParentCatUpdate:
                    sRetval = "SELECT parent_cat_id  FROM parent_category where parent_cat_name = '{0}' and parent_cat_id != {1} ;";
                    break;

                case Query.CheckCat1Order:
                    sRetval = "SELECT cat1_id  FROM category1 where cat1_order = {0} and parent_cat_id = {1} ;";
                    break;

                case Query.CheckDupCat1:
                    sRetval = "SELECT cat1_id  FROM category1 where cat1_name = '{0}' and parent_cat_id = {1} ;";
                    break;

                case Query.CheckDupCat1Update:
                    sRetval = "SELECT cat1_id  FROM category1 where cat1_name = '{0}' and parent_cat_id = {1}  and cat1_id != {2} ;";
                    break;

                case Query.CheckCat2Order:
                    sRetval = "SELECT cat2_id  FROM category2 where cat2_order = {0} and cat1_id = {1} ;";
                    break;

                case Query.CheckDupCat2:
                    sRetval = "SELECT cat2_id  FROM category2 where cat2_name = '{0}' and cat1_id = {1} ;";
                    break;


                case Query.CheckCat3Order:
                    sRetval = "SELECT cat3_id  FROM category3 where cat3_order = {0} and cat2_id = {1} ;";
                    break;



                case Query.CheckDupCat3:
                    sRetval = "SELECT cat3_id  FROM category3 where cat3_name = '{0}' and cat2_id = {1};";
                    break;

                case Query.CheckDupCat3ForUpdate:
                    sRetval = "SELECT cat3_id  FROM category3 where cat3_name = '{0}' and cat2_id = {1} and cat3_id != {2};";
                    break;

                case Query.CheckDupCat2ForUpdate:
                    sRetval = "SELECT cat2_id  FROM category2 where cat2_name = '{0}' and cat1_id = {1} and cat2_id != {2};";
                    break;

                case Query.CheckCat4Order:
                    sRetval = "SELECT cat4_id  FROM category4 where cat4_order = {0} and cat3_id = {1} ;";
                    break;

                case Query.CheckDupCat4:
                    sRetval = "SELECT cat4_id  FROM category4 where cat4_name = '{0}' and cat3_id = {1} ;";
                    break;

                case Query.CheckDupCat4ForUpdate:
                    sRetval = "SELECT cat4_id  FROM category4 where cat4_name = '{0}' and cat3_id = {1} and cat4_id != {2} ;";
                    break;


                //case Query.AddCategory1:
                //    sRetval = " insert into category1 (cat1_name,parent_cat_id,user_id,datetime)  values ('{0}',{1},'{2}',{3}) ;";
                //    break;

                case Query.AddCategory1:
                    sRetval = " insert into category1 (cat1_name,parent_cat_id,user_id,datetime,Cat1_order_number)  values ('{0}',{1},'{2}',{3},{4}) ;";
                    break;

                case Query.AddCategory2:
                    sRetval = " insert into category2 (cat2_name,cat1_id,cat2_order,cat2_type,cat2_color,view_table,view_bar,view_takeaway,user_id,datetime)  values ('{0}',{1},{2}, {3}, '{4}', {5}, {6}, {7},'{8}',{9}) ;";
                    break;

                case Query.AddCategory3:
                    sRetval = " insert into category3 (cat3_name,cat2_id,description,table_price,tw_price,bar_price,status,cat3_order,view_table,view_bar,view_takeaway,cat3_rank,user_id,datetime,food_item_stock_quantity,unlimited_status,selling_in)  values ('{0}',{1},'{2}', {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11},'{12}',{13},{14},{15},'{16}') ;";
                    break;

                case Query.AddCategory4:
                    sRetval = " insert into category4 (cat4_name,cat3_id,description,table_price,tw_price,bar_price,status,cat4_order,view_table,view_bar,view_takeaway,cat4_rank,user_id,datetime,slection_item_stock_quantity,unlimited_status)  values ('{0}',{1},'{2}', {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11},'{12}',{13} ,{14},{15}) ;";
                    break;


                #endregion

                #region Category Update



                case Query.GetCat2OrderCandidate:
                    sRetval = "SELECT cat2_id  FROM category2 where cat2_order >= {0} order by cat2_order asc;";
                    break;

                case Query.GetCat3OrderCandidate:
                    sRetval = "SELECT cat3_id  FROM category3 where cat2_id = {0} and cat3_order >= {1} order by cat3_order asc;";
                    break;


                case Query.GetCat4OrderCandidate:
                    sRetval = "SELECT cat4_id  FROM category4 where cat3_id = {0} and cat4_order >= {1} order by cat4_order asc;";
                    break;



                case Query.GetCat2OrderCandidateLower:
                    sRetval = "SELECT cat2_id  FROM category2 where cat2_order >= {0} and cat2_order < {1} order by cat2_order asc;";
                    break;

                case Query.GetCat3OrderCandidateLower:
                    sRetval = "SELECT cat3_id  FROM category3 where cat2_id = {0}  and cat3_order >= {1} and cat3_order < {2} order by cat3_order asc;";
                    break;


                case Query.GetCat4OrderCandidateLower:
                    sRetval = "SELECT cat4_id  FROM category4 where cat3_id = {0}  and cat4_order >= {1} and cat4_order < {2} order by cat4_order asc;";
                    break;



                case Query.CheckCat4OrderForUpdate:
                    sRetval = "SELECT cat4_id  FROM category4 where cat4_order = {0} and cat3_id = {1} and cat4_id != {2} ;";
                    break;

                case Query.CheckCat3OrderForUpdate:
                    sRetval = "SELECT cat3_id  FROM category3 where cat3_order = {0} and cat2_id = {1} and cat3_id != {2} ;";
                    break;

                case Query.CheckCat2OrderForUpdate:
                    sRetval = "SELECT cat2_id  FROM category2 where cat2_order = {0} and cat1_id = {1} and cat2_id != {2} ;";
                    break;

                case Query.CheckCat1OrderForUpdate:
                    sRetval = "SELECT cat1_id  FROM category1 where cat1_order = {0} and parent_cat_id = {1} and cat1_id != {2};";
                    break;


                //case Query.CheckDupParentCatOrderForUpdate:
                //    sRetval = "SELECT parent_cat_id  FROM parent_category where parent_cat_order = {0} ;";
                //    break;




                case Query.UpdateParentCategory:
                    sRetval = " update parent_category set parent_cat_name = '{0}'  where parent_cat_id = {1} ";
                    break;
                case Query.UpdateCategory1:
                    sRetval = " update category1 set cat1_name = '{0}', parent_cat_id = {1},user_id='{3}',datetime={4} where cat1_id = {2} ";
                    break;

                case Query.UpdateCategory2:
                    sRetval = " update category2 set cat2_name = '{0}', cat1_id = {1} , cat2_order = {2}, cat2_type = {3}, cat2_color = '{4}', view_table = {5}, view_bar = {6},view_takeaway = {7},user_id='{9}',datetime={10} where cat2_id = {8} ";
                    break;

                case Query.UpdateCategory2Order:
                    sRetval = " update category2 set cat2_order = {0},user_id='{2}',datetime={3} where cat2_id = {1} ";
                    break;

                case Query.UpdateCategory3Order:
                    sRetval = " update category3 set cat3_order = {0},user_id='{2}',datetime={3} where cat3_id = {1} ";
                    break;

                case Query.UpdateCategory4Order:
                    sRetval = " update category4 set cat4_order = {0} where cat4_id = {1} ";
                    break;

                //case Query.DeleteCategory2Order:
                //    sRetval = " update category2 set cat2_name = '{0}', cat1_id = {1} , cat2_order = {2}, cat2_type = {3}, cat2_color = '{4}', view_table = {5}, view_bar = {6},view_takeaway = {7} where cat2_id = {8} ";
                //    break;

                case Query.UpdateCategory3:
                    sRetval = " update category3 set cat3_name = '{0}', cat2_id = {1} , description = '{2}', table_price = {3}, tw_price = {4}, bar_price = {5}, status = {6}, cat3_order = {7}, view_table = {8}, view_bar = {9}, view_takeaway = {10},user_id='{12}',datetime={13},food_item_stock_quantity={14} ,unlimited_status={15},selling_in='{16}' where cat3_id = {11} ";
                    break;

                case Query.UpdateCategory4:
                    sRetval = " update category4 set cat4_name = '{0}', cat3_id = {1} , description = '{2}', table_price = {3}, tw_price = {4}, bar_price = {5}, status = {6}, cat4_order = {7}, view_table = {8}, view_bar = {9}, view_takeaway = {10},user_id='{12}' ,datetime={13}  ,slection_item_stock_quantity={14},unlimited_status={15} where cat4_id = {11}";
                    break;

                #endregion

                #region Category delete

                case Query.DeleteCategory1:
                    sRetval = " exec category1_delete '{0}' ";
                    break;

                case Query.DeleteCategory2:
                    sRetval = " exec category2_delete '{0}' ";
                    break;

                case Query.DeleteCategory3:
                    sRetval = " exec category3_delete '{0}' ";
                    break;

                case Query.DeleteCategory4:
                    sRetval = " exec category4_delete '{0}' ";
                    break;

                case Query.DeleteParentCategory:
                    sRetval = " exec parent_category_delete '{0}' ";
                    break;

                case Query.DeleteCategory2ByCat1:
                    sRetval = " delete from category2 where cat1_id ={0} ";
                    break;

                case Query.DeleteCategory3ByCat2:
                    sRetval = " delete from category3 where cat2_id ={0} ";
                    break;

                case Query.DeleteCategory4ByCat3:
                    sRetval = " delete from category4 where cat3_id ={0} ";
                    break;

                #endregion

                #region Category search

                #endregion

                #region Get Category

                case Query.GetCategory4:
                    sRetval = "select cat4_id,cat4_name,cat3_id,description,table_price,tw_price,bar_price,status,cat4_order,view_table,view_bar,view_takeaway,cat4_rank,slection_item_stock_quantity,unlimited_status from category4 where cat4_id={0}";
                    break;

                case Query.GetCategory3:
                    sRetval = "select cat3_id,cat3_name,cat2_id,description,table_price,tw_price,bar_price,status,cat3_order,view_table,view_bar,view_takeaway,cat3_rank,food_item_stock_quantity,unlimited_status,selling_in from category3 where cat3_id={0}";
                    break;

                case Query.GetCategory2:
                    sRetval = "select cat2_id,cat2_name,cat1_id,cat2_order,cat2_type,cat2_color,view_table,view_bar,view_takeaway from category2 where cat2_id={0}";
                    break;

                //case Query.GetCategory1:
                //    sRetval = "select cat1_id,cat1_name, parent_cat_id from category1 where cat1_id={0}";
                //    break;

                case Query.GetCategory1:
                    sRetval = "select cat1_id,cat1_name, parent_cat_id,Cat1_order_number from category1,'UPDATE' as up,'DELETE' as del where cat1_id={0} order by Cat1_order_number asc";
                    break;

                case Query.GetCategory3All:

                    sRetval = "select cat3_id,cat3_name,cat2_id,description,table_price,tw_price,bar_price,status,cat3_order,view_table,view_bar,view_takeaway,cat3_rank,food_item_stock_quantity,unlimited_status from category3";
                    break;

                case Query.GetCategory4All:
                    sRetval = "select cat4_id,cat4_name,cat3_id,description,table_price,tw_price,bar_price,status,cat4_order,view_table,view_bar,view_takeaway,cat4_rank,slection_item_stock_quantity,unlimited_status from category4";
                    break;

                #endregion

                #region Category anchestors

                case Query.GetCategory4Anchestor:
                    sRetval = "select a.cat4_id,b.cat3_id,c.cat2_id,d.cat1_id,d.parent_cat_id, a.cat4_order, b.cat3_order,c.cat2_order from category4 a,category3 b,category2 c,category1 d, parent_category e where a.cat4_id={0} and a.cat3_id=b.cat3_id and b.cat2_id=c.cat2_id and c.cat1_id=d.cat1_id and d.parent_cat_id=e.parent_cat_id";
                    break;

                case Query.GetCategory3Anchestor:
                    sRetval = "select 0 as cat4_id,a.cat3_id,b.cat2_id,c.cat1_id,c.parent_cat_id ,0 as cat4_order,a.cat3_order,b.cat2_order from category3 a,category2 b,category1 c, parent_category d where a.cat3_id={0} and a.cat2_id=b.cat2_id and b.cat1_id=c.cat1_id and c.parent_cat_id=d.parent_cat_id";
                    break;

                case Query.GetCategory2Anchestor:
                    sRetval = "select 0 as cat4_id, 0 as cat3_id,a.cat2_id,b.cat1_id,b.parent_cat_id,0 as cat4_order,0 as cat3_order,a.cat2_order from category2 a,category1 b,parent_category c where a.cat2_id={0} and a.cat1_id=b.cat1_id and b.parent_cat_id=c.parent_cat_id";
                    break;

                case Query.GetCategory1Anchestor:
                    sRetval = "select 0 as cat4_id, 0 as cat3_id, 0 as cat2_id, a.cat1_id,a.parent_cat_id,0 as cat4_order,0 as cat3_order, 0 as cat2_order from category1 a, parent_category b where a.cat1_id={0} and a.parent_cat_id=b.parent_cat_id";
                    break;


                #endregion

                #region Button color


                case Query.AddButtonColor:
                    sRetval = " insert into button_color values ('{0}','{1}','{2}',{3} ) ";
                    break;


                case Query.UpdateButtonColor:
                    sRetval = " update button_color set color = '{0}',user_id='{2}',datetime='{3}' where button_id = {1} ;";
                    break;



                case Query.GetButtonColor:
                    sRetval = "SELECT button_id, name, color  FROM button_color where button_id = {0} ;";
                    break;

                case Query.ViewButtonColorCombo:
                    sRetval = "SELECT button_id, name  FROM button_color ;";
                    break;



                #endregion

                #region Print Style


                case Query.GetAllPrintStyle:
                    sRetval = " select style_id, header, body, footer, style_name,'UPDATE' as up ,'DELETE' as del from print_style ; ";
                    break;

                case Query.GetPrintStyle:
                    sRetval = " select style_id, header, body, footer, style_name from print_style where style_id = {0} ; ";
                    break;

                //case Query.GetAllPrintStyle:
                //    sRetval = " select style_id, header, body, footer, style_name from print_style ; ";
                //    break;

                case Query.AddPrintStyle:
                    sRetval = " insert into print_style values ('{0}','{1}','{2}' ) ";
                    break;

                case Query.UpdatePrintStyle:
                    sRetval = "UPDATE print_style SET header ='{0}', body = '{1}', footer = '{2}' WHERE style_id={3}";
                    break;

                #endregion

                #region Customer

                case Query.AddCustomer:
                    sRetval = " insert into customer_info values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}' ) ";
                    break;

                #endregion

                #region Report

                case Query.DailyOrderSummary:
                    sRetval = "select a.order_id, a.payment, count(a.order_id), sum(a.payment)  FROM payment a, order_info b  where a.order_id = b.order_id  and b.order_time >= '{0}' and b.order_time <= '{1}' ";
                    break;

                case Query.OrderDetails:
                    sRetval = "select a.order_detail_id, a.amount, a.quantity, a.food_type  FROM payment a, order_info b  where a.order_id = b.order_id  and b.order_time >= '{0}' and b.order_time <= '{1}' ";
                    break;

                #endregion

                #region Login History

                case Query.CurrentUsers:
                    sRetval = "select a.order_id, a.payment, count(a.order_id), sum(a.payment)  FROM payment a, order_info b  where a.order_id = b.order_id  and b.order_time >= '{0}' and b.order_time <= '{1}' ";
                    break;

                case Query.LoginHistory:
                    sRetval = "select a.user_name, a.type, b.login_time, b.logout_time  FROM user_info a, login_history b  where a.user_id = b.user_id  and b.login_time >= '{0}' and b.login_time <= '{1}' ";
                    break;

                #endregion

                #region statistics

                //case Query.CurrentUsers:
                //    sRetval = "select a.order_id, a.payment, count(a.order_id), sum(a.payment)  FROM payment a, order_info b  where a.order_id = b.order_id  and b.order_time >= '{0}' and b.order_time <= '{1}' ";
                //    break;

                //case Query.LoginHistory:
                //    sRetval = "select a.user_name, a.type, b.login_time, b.logout_time  FROM user_info a, login_history b  where a.user_id = b.user_id  and b.login_time >= '{0}' and b.login_time <= '{1}' ";
                //    break;

                #endregion

                #region update rank

                case Query.DeleteAllCat3Rank:
                    sRetval = " update category3 set cat3_rank = 0 ; ";
                    break;

                case Query.DeleteAllCat4Rank:
                    sRetval = " update category4 set cat4_rank = 0 ";
                    break;



                case Query.GetAllCat3Rank:
                    sRetval = " select a.cat3_id, a.cat3_order, b.cat2_order from category3 a, category2 b where a.cat2_id = b.cat2_id ; ";
                    break;

                case Query.GetAllCat4Rank:
                    sRetval = " select a.cat4_id, a.cat4_order, b.cat3_order, c.cat2_order from category4 a, category3 b, category2 c where a.cat3_id = b.cat3_id and b.cat2_id = c.cat2_id ; ";
                    break;



                case Query.UpdateCat3Rank2:
                    sRetval = " update category3 set cat3_rank = {0} where cat3_id = {1} ; ";
                    break;

                case Query.UpdateCat4Rank2:
                    sRetval = " update category4 set cat4_rank = {0}  where cat4_id = {1} ; ";
                    break;




                #endregion

                #region Reports

                case Query.GetTotalPaymentByDayNDept:
                    sRetval = "select sum(a.total_amount) as total from payment a, order_info_archive b, bill_print_time c,pc_info d where a.order_id=b.order_id and b.order_id=c.order_id and a.pc_id=d.pc_id and d.name='{2}' and c.payment_time>={0} and c.payment_time<{1}; ";
                    break;

                case Query.GetOrderCountByDate:
                    sRetval = "select count(a.order_id) as total from order_info_archive a, bill_print_time b where a.order_id=b.order_id and b.payment_time>={0} and b.payment_time<{1}";
                    break;

                case Query.PaymentSummaryGetTotal:
                    sRetval = "select sum(a.total_amount) total,sum(a.cash_amount) cash_total, sum(a.EFT_amount) EFT_total, sum(a.cheque_amount) cheque_total, sum(a.voucher_amount) voucher_total, sum(a.service_amount) service_total,sum(a.deposit_amount) deposit_total from payment a, bill_print_time b where a.order_id=b.order_id and b.payment_time >= {0} and b.payment_time < {1} ";
                    break;

                #endregion

                #region "PLU"
                case Query.GetPLUProductList3:
                    sRetval = "select fditem.cat3_id as product_id ,fditem.cat3_name as product_name,3 as product_label,'ADD PLU' as plu,product3_plu as code from category3 fditem where  fditem.cat3_id not in(select cat3_id from category4)";
                    break;

                case Query.GetPLUProductList4:
                    sRetval = "select sitem.cat4_id as product_id,(sitem.cat4_name +'  '+fditem.cat3_name)  as product_name,4 as product_label,'ADD PLU' as plu,product4_plu as code from category4 sitem inner join category3 fditem on fditem.cat3_id=sitem.cat3_id";
                    break;
                    
                case Query.SaveProduct3PLU:
                    sRetval = "update category3 set product3_plu={0} where cat3_id={1}";
                    break;

                case Query.SaveProduct4PLU:
                    sRetval = "update category4 set product4_plu={0} where cat4_id={1}";
                    break;

                case Query.GetProduct3IDFromPLU:
                    sRetval = "select cat3_id from category3 where product3_plu={0}";
                    break;

                case Query.GetProduct4IDFromPLU:
                    sRetval = "select cat4_id from category4 where product4_plu={0} ";
                    break;
                
                #endregion


                case Query.ScopeIdentity:
                    sRetval = "select scope_identity() ";
                    break;

                //Added by Baruri
                case Query.ViewAllFoodType:
                    sRetval = "SELECT a.cat1_id, a.cat1_name FROM category1 a order by a.cat1_name asc ;";
                    break;

                    case Query.ViewAllCategory:
                    sRetval = "SELECT a.cat2_id, a.cat2_name as Category2_Name, b.cat1_name as Category1_Name, a.cat2_order as Category2_Order, c.parent_cat_name as Parent_Category_Name,'UPDATE' as up,'DELETE' as del FROM category2 a, category1 b, parent_category c where  a.cat1_id = b.cat1_id and b.parent_cat_id = c.parent_cat_id  order by a.cat2_order asc";
                    break;

                    case Query.UserInfoGetAll:
                    sRetval = "select user_id,user_name,password,type,status,gender from user_info";
                    break;


                    case Query.GetSoldRecords:
                    sRetval = "SELECT product_id,proname,sum(quantity) as quantity,sum(amount) as amount,'' as order_time,''as formateddate ,food_type,(select sum(guest_count) FROM order_info_archive  WHERE order_time>={0} and order_time<={1} ) as guest_count  FROM vw_solditems_all " +
                              " WHERE order_time>={0} and order_time<={1} group by product_id,proname,food_type";
                    break;

                    #region "Inventroy Sales Report"

                    case Query.GetInventorySalesRecords:
                    sRetval = " SELECT arordd.product_id, SUM(arordd.quantity) AS quantity, SUM(arordd.amount) AS amount, arordd.cat_level,food_type, " +
                              "(select sum(guest_count) from  order_info_archive  WHERE order_time>={0} and "+
                              " order_time<={1}) as guest_count FROM dbo.View_order_archive_info AS arordd WHERE order_time>={0} and order_time<={1}  GROUP BY arordd.product_id, arordd.cat_level,food_type";
                    break;
            
                    case Query.GetFoodTypeRecords:
                    sRetval = "select cat1_id,cat1_name,parent_cat_id,user_id,datetime,synk_status,online_status,Cat1_order_number from category1";
                    break;

                    case Query.GetFoodCategoryRecords:
                    sRetval = "select cat2_id,cat2_name,cat1_id,cat2_order,cat2_type,cat2_color,view_table,view_bar,view_takeaway,user_id,datetime,synk_status,online_status from category2";
                    break;

                    case Query.GetFoodItemRecords:
                    sRetval = "select cat3_id,cat3_name,cat2_id,description,table_price,tw_price,bar_price,status,cat3_order,view_table,view_bar,view_takeaway,cat3_rank,"+
                              " user_id,datetime,synk_status,online_status,product3_plu,food_item_stock_quantity,unlimited_status from category3";
                    break;

                    case Query.GetSelectionofItemsRecords:
                    sRetval = "select cat4_id,cat4_name,cat3_id,description,table_price,tw_price,bar_price,status,cat4_order,view_table,view_bar,view_takeaway,cat4_rank,user_id,"+
                              " datetime,synk_status,online_status,product4_plu,slection_item_stock_quantity,unlimited_status from category4";
                    break;
 
                    #endregion


                //Default
                 default:
                    sRetval = "";
                    break;
            }

            return m_sDateFormat + sRetval;
        }

    }//SqlQueries


    public enum Query
    {
        None = 0,
        AddUser = 1,
        UpdateUser = 2,
        DeleteUser = 3,
        AddCategory1 = 4,
        UpdateCategory1 = 5,
        DeleteCategory1 = 6,
        AddCategory2 = 7,
        UpdateCategory2 = 8,
        DeleteCategory2 = 9,
        AddCategory3 = 10,
        UpdateCategory3 = 11,
        DeleteCategory3 = 12,
        AddParentCategory = 13,
        UpdateParentCategory = 14,
        DeleteParentCategory = 15,
        AddCustomer = 16,
        UpdateCustomer = 17,
        DeleteCustomer = 18,
        AddButtonAccess = 19,
        UpdateButtonAccess = 20,
        DeleteButtonAccess = 21,
        AddButtonColor = 22,
        UpdateButtonColor = 23,
        DeleteButtonColor = 24,
        AddDelivery = 25,
        UpdateDelivery = 26,
        DeleteDelivery = 27,
        AddDeposit = 28,
        UpdateDeposit = 29,
        DeleteDeposit = 30,
        AddKitchenPrint = 31,
        UpdateKitchenPrint = 32,
        DeleteKitchenPrint = 33,
        AddOrderDetails = 34,
        UpdateOrderDetails = 35,
        DeleteOrderDetails = 36,
        AddOrderInfo = 37,
        UpdateOrderInfo = 38,
        DeleteOrderInfo = 39,
        UpdatePayment = 44,
        DeletePayment = 45,
        AddPcInfo = 46,
        UpdatePcInfo = 47,
        DeletePcInfo = 48,
        AddPrintStyle = 49,
        UpdatePrintStyle = 50,
        DeletePrintStyle = 51,
        AddStock = 52,
        UpdateStock = 53,
        DeleteStock = 54,
        AddTableInfo = 55,
        UpdateTableInfo = 56,
        DeleteTableInfo = 57,
        AddTerminalPrint = 58,
        UpdateTerminalPrint = 59,
        DeleteTerminalPrint = 60,
        ViewButtonAccess = 61,
        ViewButtonColor = 62,
        ViewCategory1 = 63,
        ViewCategory2 = 64,
        ViewCategory3 = 65,
        ViewCustomerInfo = 66,
        ViewDelivery = 67,
        ViewDeposit = 68,
        ViewKitchenPrint = 69,
        ViewOrderDetails = 70,
        ViewOrderInfo = 71,
        ViewParentCategory = 72,
        ViewPayment = 73,
        ViewPcInfo = 74,
        ViewPrintStyle = 75,
        ViewStock = 76,
        ViewTableInfo = 77,
        ViewTerminalPrint = 78,
        ViewUserInfo = 79,
        ViewCategory1ByParentCat = 80,
        ViewCategory2ByCat1 = 81,
        ViewCategory3ByCat2 = 82,
        ViewCategory3ByCat1 = 83,
        ViewCategory3ByParentCat = 84,
        DailyOrderSummary = 85,
        OrderDetails = 86,
        CurrentUsers = 87,
        LoginHistory = 88,
        CheckDupParentCat = 89,
        CheckDupCat1 = 90,
        CheckCat1Order = 91,
        ViewCat1ComboBox = 92,
        ViewCategory2ByCat1ComboBox = 93,
        ViewCategory3ByCat2ComboBox = 94,
        ViewCategory4ByCat3 = 95,
        ViewCategory4ByCat3ComboBox = 96,
        ViewCategory4 = 97,
        DeleteCategory2ByCat1 = 98,
        DeleteCategory3ByCat2 = 99,
        DeleteCategory4ByCat3 = 100,
        DeleteCategory4 = 101,
        AddCategory4 = 102,
        UpdateCategory4 = 103,
        ViewCategory3ByCat2Grid = 104,
        ViewParentCategoryCombo = 105,
        CheckDupParentCatOrder = 106,
        CheckCat2Order = 107,
        CheckDupCat2 = 108,
        CheckCat3Order = 109,
        CheckDupCat3 = 110,
        CheckDupCat4 = 111,
        CheckCat4Order = 112,
        GetParentCat = 113,
        GetButtonIDByName = 114,
        ScopeIdentity = 115,
        CheckDupUser = 116,
        GetUserAccess = 117,
        getUserByID = 118,
        GetPrintStyle = 119,
        GetAllPrintStyle = 120,
        GetButtonColor = 121,
        LoginUser = 122,
        UserInfoByUsername = 123,
        GetCategory4 = 124,
        GetCategory3 = 125,
        GetCategory2 = 126,
        GetCategory1 = 127,
        GetCategory4Anchestor = 128,
        GetCategory3Anchestor = 129,
        GetCategory2Anchestor = 130,
        GetCategory1Anchestor = 131,
        CheckCat4OrderForUpdate = 132,
        CheckCat3OrderForUpdate = 133,
        CheckCat2OrderForUpdate = 134,
        CheckCat1OrderForUpdate = 135,
        DeleteAllButtonAccess = 136,
        CheckDupUserForUpdate = 137,
        GetCategory3All = 138,
        GetCategory4All = 139,
        GetParentCatByID = 140,
        CheckDupCat3ForUpdate = 141,
        CheckDupCat4ForUpdate = 142,
        ViewCurrentUsers = 143,
        UnlockUser = 144,
        DeleteCurrentUser = 145,
        ViewButtonColorCombo = 146,
        GetTotalPaymentByDayNDept = 147,
        GetOrderCountByDate = 148,
        UpdateCategory2Order = 149,
        UpdateCategory3Order = 150,
        UpdateCategory4Order = 151,
        GetMaxCat2Order = 152,
        GetMaxCat3Order = 153,
        GetMaxCat4Order = 154,
        CheckDupCat2ForUpdate = 155,
        GetCat2OrderCandidate = 156,
        GetCat3OrderCandidate = 157,
        GetCat4OrderCandidate = 158,
        GetCat2OrderCandidateLower = 159,
        GetCat3OrderCandidateLower = 160,
        GetCat4OrderCandidateLower = 161,
        CheckDupParentCatUpdate = 162,
        CheckDupCat1Update = 163,
        GetChildCat3ByCat2 = 164,
        GetChildCat4ByCat2 = 165,
        GetChildCat4ByCat3 = 166,
        UpdateCat3Rank = 167,
        UpdateCat4Rank = 168,
        GetCategory2Order = 169,
        GetCategory23Order = 170,
        DeleteAllCat3Rank = 171,
        DeleteAllCat4Rank = 172,
        GetAllCat3Rank = 173,
        GetAllCat4Rank = 174,
        UpdateCat3Rank2 = 175,
        UpdateCat4Rank2 = 176,
        PaymentSummaryGetTotal = 179,
        GetMaxCat1Order = 180,
        UpdateCategory1Order = 181,

        GetPLUProductList3=182,
        GetPLUProductList4 = 183,
        SaveProduct3PLU=184,
        GetProduct3IDFromPLU=185,
        GetProduct4IDFromPLU = 186,
        SaveProduct4PLU=187,
        ViewAllFoodType=188,
        ViewAllCategory=189,
        UserInfoGetAll=190,

        GetSoldRecords = 191,
        GetPrintStyles=192,
        GetInventorySalesRecords=193,
        GetFoodTypeRecords = 194,
        GetFoodCategoryRecords=195,
        GetFoodItemRecords=196,
        GetSelectionofItemsRecords=197
    }
}//ns
