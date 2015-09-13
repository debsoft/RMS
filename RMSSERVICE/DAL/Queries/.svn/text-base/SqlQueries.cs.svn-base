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
            if (oConstants==null)
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
                //Category
                

                //case Query.CategoryUpdate:
                //    sRetval = "UPDATE cb_category SET category_name='{0}',parent_category_id= '{1}', header= '{3}', quantity_unit = '{4}' WHERE category_id='{2}'";
                //    break;

                #region Users

                //case Query.CategoryCreate:
                //    sRetval = "INSERT INTO cb_category VALUES ('{0}','{1}','{2}','{3}', '{4}')";
                //    break;
                case Query.ViewUserInfo:
                    sRetval = "SELECT user_id, user_name, password, type, status, gender FROM user_info ;";
                    break;

                case Query.LoginUser:
                    sRetval = "SELECT user_id, user_name, password, type, status, gender FROM user_info where user_name = '{0}'; ";
                    break;

                case Query.CheckCurrentUser:
                    sRetval = "SELECT a.user_id FROM user_info a, current_users b where a.user_id = b.user_id and a.user_name = '{0}'; ";
                    break;

                case Query.DeleteCurrentUser:
                    sRetval = "delete from current_users where user_id =  {0}; ";
                    break;

                case Query.AddCurrentUser:
                    sRetval = "insert into current_users values({0}, {1}) ; ";
                    break;


                //case Query.UserButtonAccess:
                //    sRetval = "SELECT a.name FROM button_color a, button_access b, user_info c where c.user_id = b.user_id and a.button_id = b.button_id  and c.user_id = {0} ; ";
                //    break;

                case Query.GetUserAccess:
                    sRetval = "select b.name from user_info a, button_color b, button_access c  where a.user_id = c.user_id and a.user_id = {0} and c.button_id = b.button_id ; ";
                    break;
                    

                case Query.AddUser:
                    sRetval = " insert into user_info values('{0}','{1}',{2},{3},'{4}') ";
                    break;

                #endregion

                #region Category view

                //case Query.ViewParentCategory:
                //    sRetval = "SELECT parent_cat_id, parent_cat_name FROM parent_category ";

                case Query.ViewCategory1:
                    sRetval = "SELECT a.cat1_id, a.cat1_name, a.cat1_order, b.parent_cat_name FROM category1 a, parent_category b where a.parent_cat_id = b.parent_cat_id  order by b.parent_cat_name  asc";
                    break;

                case Query.ViewCat1ComboBox:
                    sRetval = "SELECT a.cat1_id, a.cat1_name  FROM category1 a, parent_category b where a.parent_cat_id = b.parent_cat_id  and b.parent_cat_id = {0} ";
                    break;

                    

                case Query.ViewCategory1ByParentCat:
                    sRetval = "SELECT cat1_id, cat1_name, cat1_order, parent_cat_id FROM category1 where parent_cat_id = {0} ";
                    break;

                case Query.ViewCategory2:
                    sRetval = "SELECT a.cat2_id, a.cat2_name, b.cat1_name, a.cat2_order FROM category2 a, category1 b where  a.cat1_id = b.cat1_id order by b.cat1_name asc";
                    break;

                case Query.ViewCategory2ByCat1:
                    sRetval = "SELECT a.cat2_id, a.cat2_name, b.cat1_name FROM category2 a, category1 b where  a.cat1_id = b.cat1_id order by b.cat1_name asc";
                    break;

                case Query.ViewCategory2ByCat1ComboBox:
                    sRetval = "SELECT a.cat2_id, a.cat2_name FROM category2 a, category1 b where  a.cat1_id = b.cat1_id and b.cat1_id = {0} order by a.cat2_name asc";
                    break;

                case Query.ViewCategory3:
                    sRetval = "SELECT a.cat3_id, a.cat3_name, b.cat2_name, c.cat1_name, d.parent_cat_name  FROM category3 a, category2 b, category1 c, parent_category d  where a.cat2_id = b.cat2_id  and b.cat1_id = c.cat1_id and c.parent_cat_id = d.parent_cat_id  ";                    
                    break;

                case Query.ViewCategory4:
                    sRetval = "SELECT e.cat4_id, e.cat4_name, a.cat3_name, b.cat2_name, c.cat1_name, d.parent_cat_name  FROM category3 a, category2 b, category1 c, parent_category d, category4 e  where e.cat3_id = a.cat3_id and a.cat2_id = b.cat2_id  and b.cat1_id = c.cat1_id and c.parent_cat_id = d.parent_cat_id";
                    break;


                case Query.ViewCategory3ByCat2:
                    sRetval = "SELECT a.cat3_id, a.cat3_name FROM category3 a, category2 b  where a.cat2_id = b.cat2_id and a.cat2_id = {0} ";
                    break;

                case Query.ViewCategory3ByCat2ComboBox:
                    sRetval = "SELECT a.cat3_id, a.cat3_name, b.cat2_name FROM category3 a, category2 b  where a.cat2_id = b.cat2_id and a.cat2_id = {0} ";
                    break;


                case Query.ViewCategory4ByCat3:
                    sRetval = "SELECT e.cat4_id, e.cat4_name, a.cat3_name, b.cat2_name, c.cat1_name, d.parent_cat_name  FROM category3 a, category2 b, category1 c, parent_category d, category4 e  where e.cat3_id = a.cat3_id and a.cat2_id = b.cat2_id  and b.cat1_id = c.cat1_id and c.parent_cat_id = d.parent_cat_id  and e.cat4_id = {0} ";// "SELECT a.cat4_id, a.cat4_name FROM category4 a, category3 b  where a.cat3_id = b.cat3_id and a.cat4_id = {0} ";
                    break;

                case Query.ViewCategory4ByCat3ComboBox:
                    sRetval = "SELECT a.cat4_id, a.cat4_name, b.cat3_name FROM category4 a, category3 b  where a.cat3_id = b.cat3_id and a.cat4_id = {0} ";
                    break;

                case Query.ViewCategory3ByCat1:
                    sRetval = "SELECT a.cat3_id, a.cat3_name, b.cat2_name, c._cat1_name, d.parent_cat_name  FROM category3 a, category2 b, category1 c, parent_category d  where a.cat2_id = b.cat2_id  and b.cat1_id = c.cat1_id and c.parent_cat_id = d.parent_cat_id  and c.cat1_id = {0} ";
                    break;

                case Query.ViewCategory3ByParentCat:
                    sRetval = "SELECT a.cat3_id, a.cat3_name, b.cat2_name, c._cat1_name, d.parent_cat_name  FROM category3 a, category2 b, category1 c, parent_category d  where a.cat2_id = b.cat2_id  and b.cat1_id = c.cat1_id and c.parent_cat_id = d.parent_cat_id  and d.parent_cat_id = {0} ";
                    break;

               
                

                #endregion

                #region Category add

                case Query.AddParentCategory:
                    sRetval = " insert into parent_category values ('{0}') ";
                    break;

                case Query.CheckDupParentCat:
                    sRetval = "SELECT parent_cat_id  FROM parent_category where parent_cat_name = '{0}' ";
                    break;

                case Query.CheckCat1Order:
                    sRetval = "SELECT cat1_id  FROM category1 where cat1_order = {0} and parent_cat_id = {1} ";
                    break;

                case Query.CheckDupCat1:
                    sRetval = "SELECT cat1_id  FROM category1 where cat1_name = '{0}' ";
                    break;

                case Query.AddCategory1:
                    sRetval = " insert into category1 values ('{0}',{1},{2}) ";
                    break;

                case Query.AddCategory2:
                    sRetval = " insert into category2 values ('{0}',{1},{2}, {3}, '{4}', {5}, {6}, {7}) ";
                    break;

                case Query.AddCategory3:
                    sRetval = " insert into category3 values ('{0}',{1},'{2}', {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11} ) ";
                    break;

                case Query.AddCategory4:
                    sRetval = " insert into category4 values ('{0}',{1},'{2}', {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11} ) ";
                    break;


                #endregion

                #region Category Update

                case Query.UpdateCategory1:
                    sRetval = " update category1 set cat1_name = '{0}', cat1_order = {1} , parent_cat_id = {2} where cat1_id = {3} ";
                    break;

                case Query.UpdateCategory2:
                    sRetval = " update category2 set cat2_name = '{0}', cat1_id = {1} , cat2_order = {2}, cat2_type = {3}, cat2_color = '{4}', view_table = {5}, view_bar = {6},view_takeaway = {7} where cat2_id = {8} ";
                    break;

                case Query.UpdateCategory3:
                    sRetval = " update category3 set cat3_name = '{0}', cat2_id = {1} , description = '{2}', table_price = {3}, tw_price = {4}, bar_price = {5}, status = {6}, cat3_order = {7}, view_table = {8}, view_bar = {9}, view_takeaway = {10}, cat3_rank = {11} where cat3_id = {12} ";
                    break;

                case Query.UpdateCategory4:
                    sRetval = " update category4 set cat4_name = '{0}', cat3_id = {1} , description = '{2}', table_price = {3}, tw_price = {4}, bar_price = {5}, status = {6}, cat4_order = {7}, view_table = {8}, view_bar = {9}, view_takeaway = {10}, cat4_rank = {11} where cat4_id = {12} ";
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

                #region Button color


                case Query.AddButtonColor:
                    sRetval = " insert into button_color values ('{0}','{1}' ) ";
                    break;

                #endregion


                #region Print Style


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

               

                case Query.OrderInfoUpdate:
                    sRetval = "update order_info set customer_id={0},user_id={1},order_type='{2}', order_time={3},status='{4}',guest_count={5},table_number={6},table_name='{7}' where order_id={8}";
                    break;

                

                case Query.OrderInfoGetByOrderID:
                    sRetval = "select order_id,customer_id,user_id,order_type,order_time,status,guest_count,table_number,table_name from order_info where order_id={0}";
                    break;


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
        DeleteCategory2ByCat1 =98,
        DeleteCategory3ByCat2 = 99,
        DeleteCategory4ByCat3 = 100,
        DeleteCategory4 = 101,
        AddCategory4 = 102,
        UpdateCategory4 = 103,
        LoginUser = 104,
        UserButtonAccess = 105,
        GetUserAccess = 106,
        CheckCurrentUser = 107,
        DeleteCurrentUser = 108,
        AddCurrentUser = 109,
        OrderInfoUpdate=110,
        OrderInfoGetByOrderID=111
      
    }
}//ns
