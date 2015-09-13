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
               
                #region Button Color Queries

                case Query.ButtonColorByButtonName:
                    sRetval = "select button_id,name,color from button_color where name='{0}'";
                    break ;

            #endregion

                #region User Info Queries
                case Query.UserInfoGetAll:
                    sRetval = "select user_id,user_name,password,type,status,gender from user_info";
                    break;

                case Query.UserInfoByUsername:
                    sRetval = "select user_id,user_name,password,type,status,gender from user_info where user_name='{0}'";
                    break;

                case Query.LoginUser:
                    sRetval = "SELECT user_id, user_name, password, type, status, gender FROM user_info where user_name = '{0}' ";
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

                case Query.GetUserAccess:
                    sRetval = "select b.name from user_info a, button_color b, button_access c  where a.user_id = c.user_id and a.user_id = {0} and c.button_id = b.button_id ; ";
                    break;


                case Query.CheckDupUser:
                    sRetval = "SELECT user_id  FROM user_info where user_name = '{0}' ;";
                    break;

                case Query.AddUser:
                    sRetval = " insert into user_info values('{0}','{1}',{2},{3},'{4}') ";
                    break;

                case Query.GetButtonIDByName:
                    sRetval = "SELECT button_id from button_color where name = '{0}' ";
                    break;

                case Query.AddButtonAccess:
                    sRetval = " insert into button_access values({0},{1}) ";
                    break;

                case Query.CheckDupUserForUpdate:
                    sRetval = "SELECT user_id  FROM user_info where user_name = '{0}' and user_id != {1} ;";
                    break;

                case Query.UpdateUser:
                    sRetval = " update user_info set user_name = '{0}', password = '{1}', type = {2}, status = {3}, gender = '{4}'  where user_id = {5} ";
                    break;

                case Query.DeleteAllButtonAccess:
                    sRetval = "delete  FROM button_access  where user_id = {0} ;";
                    break;

                case Query.DeleteUser:
                    sRetval = "delete  FROM user_info  where user_id = {0} ;";
                    break;

                case Query.getUserByID:
                    sRetval = "select user_id, user_name, password, type, status, gender from user_info where user_id = {0} ; ";
                    break;

                
                #endregion

                #region Order Info Queries CHANGED
                //case Query.OrderShowByStatus:
                //    sRetval = "select order_id,order_type,table_name,table_number,guest_count,order_info.status,user_name from order_info,user_info where order_info.status != '{0}'  and order_info.user_id=user_info.user_id";
                //    break;

                case Query.OrderShowByStatus:
                    sRetval = "select ord.order_id,ord.order_type,ord.table_name,ord.table_number,ord.guest_count,ord.status,usr.user_name,ord.online_orderid,ord.FloorNo from order_info ord " +
                              " left outer join user_info usr on usr.user_id=ord.user_id where ord.status != 'Paid' and ord.online_orderid=0;";
                    break;


                case Query.OrderInfoInsert://Changed
                    //sRetval = "insert into order_info values( {0},{1},'{2}','{3}','{4}',{5},{6},'{7}','{8}')";                    
                    sRetval = "insert into order_info(customer_id,user_id,order_type,order_time,status,guest_count,table_number,table_name,terminal_id,FloorNo) values( {0},{1},'{2}',{3},'{4}',{5},{6},'{7}',{8},'{9}')";                    
                    break;
                case Query.OrderSerialInsert:
                    sRetval = "insert into order_serial (order_id) values({0})";
                    break;

                case Query.DeleteOrderSerial:
                    sRetval = "delete from order_serial where order_id={0}";
                    break;

                case Query.GetOrderSerial:
                    sRetval = "select serial_no from order_serial where order_id={0}";
                    break;

                case Query.OrderInfoUpdate:
                    sRetval = "update order_info set customer_id={0},user_id={1},order_type='{2}', order_time={3},status='{4}',guest_count={5},table_number={6},table_name='{7}' where order_id={8}";
                    break;

                case Query.OrderInfoGetByOrderID:
                    sRetval = "select order_id,customer_id,user_id,order_type,order_time,status,guest_count,table_number,table_name,online_orderid from order_info where order_id={0}";
                    break;

                case Query.orderInfoArchiveByOrderID:
                    sRetval = "select order_id,customer_id,user_id,order_type,order_time,status,guest_count,table_number,table_name,serial_no from order_info_archive where order_id={0}";
                    break;

                case Query.OrderSeatTimeInsert:
                    sRetval = "insert into order_seat_time values({0},{1})";
                    break;

                case Query.OrderInfoArchieveInsert:
                    sRetval = "insert into order_info_archive(order_id,customer_id,user_id,order_type,order_time,status,guest_count,table_number,table_name,serial_no,terminal_id,online_orderid ) values({0},{1},{2},'{3}','{4}','{5}',{6},{7},'{8}',{9},{10},{11})";
                    break;


                case Query.OrderListForTransfer:
                    //sRetval = "select order_id, guest_count, order_type,a.table_number, (select name from customer_info where customer_id = a.customer_id) as customer_name from order_info a where a.status != 'Paid' and a.order_type='Table' and a.order_time>={0} and a.order_time<{1} and a.table_number in( select table_number from table_info where status=0 and table_type='Table')";
                    sRetval = "select order_id, guest_count, order_type,a.table_number, (select name from customer_info where customer_id = a.customer_id) as customer_name from order_info a where a.status != 'Paid' and a.order_type='Table' and a.table_number in( select table_number from table_info where status=0 and table_type='Table')";
                    break;


                case Query.ShowAvailableTableForUnlock:
                    //sRetval = "select order_id, guest_count, order_type,a.table_number, (select name from customer_info where customer_id = a.customer_id) as customer_name from order_info a where a.status!='Paid' and a.order_time>={0} and a.order_time<{1} and a.table_number in( select table_number from table_info where status=1 and table_type=a.order_type)";
                    sRetval = "select order_id, guest_count, order_type,a.table_number, (select name from customer_info where customer_id = a.customer_id) as customer_name from order_info a where a.status!='Paid' and a.table_number in( select table_number from table_info where status=1 and table_type=a.order_type)";
                    break;

                case Query.OrderListForMerge:
                    //sRetval = "select order_id, guest_count, order_type,a.table_number, (select name from customer_info where customer_id = a.customer_id) as customer_name from order_info a where a.status='Seated' and a.order_type='Table' and a.order_time>={0} and a.order_time<{1} and a.table_number in( select table_number from table_info where status=0 and table_type='Table')";
                    //sRetval = "select order_id, guest_count, order_type,a.table_number, (select name from customer_info where customer_id = a.customer_id) as customer_name from order_info a where a.status='Seated' and a.order_type='Table' and a.table_number in( select table_number from table_info where status=0 and table_type='Table')";

                    sRetval = "select  a.order_id,a.guest_count,a.order_type,a.table_number,b.name as customer_name from order_info a left outer join customer_info b on a.customer_id=b.customer_id where a.order_type='Table' and a.table_number in( select table_number from table_info where status=0 and table_type='Table')"; //Changed at 14.03.2009
                    break;

                case Query.ShowAvailableTableForVoid:
                    //sRetval = "select order_id, guest_count, order_type,a.table_number, (select name from customer_info where customer_id = a.customer_id) as customer_name from order_info a where a.status!='Paid' and a.order_time>={0} and a.order_time<{1} and a.table_number not in(select table_number from table_info where status=1 and table_type=a.order_type)";
                    sRetval = "select order_id, guest_count, order_type,a.table_number, (select name from customer_info where customer_id = a.customer_id) as customer_name from order_info a where a.status!='Paid' and a.table_number not in(select table_number from table_info where status=1 and table_type=a.order_type)";
                    break;

                case Query.UpdateDBForTransfer:
                    //sRetval = "update order_info set table_number={2} where order_id={0} and table_number={1}; delete from table_info where table_number={1} and table_type='Table'";
                    sRetval = "update order_info set table_number={2} where order_id={0} and table_number={1}; delete from table_info where table_number={1} and table_type='Table'";
                    break;

                case Query.UpdateDBForVoid:
                    //sRetval = "delete from order_details where order_id={0};delete from order_info where order_id={0}; delete from table_info where table_number={1} and table_type='{2}'";
                    sRetval = "delete from order_details where order_id={0};delete from order_info where order_id={0}; delete from table_info where table_number={1} and table_type='{2}'";
                    break;


                case Query.VoidOnlineItems:
                    sRetval = "exec sp_VoidOnlineItems {0}";
                    break;


                case Query.UpdateDBForVoidReport:
                    //sRetval = "delete from order_details_archive where order_id={0};delete from order_info_archive where order_id={0}; delete from payment where order_id={0}";
                    sRetval = "delete from order_details_archive where order_id={0};delete from order_info_archive where order_id={0}; delete from payment where order_id={0}";
                    break;
                case Query.OrderShowForViewReportByRef://Changed
                    //sRetval = "select b.order_id, b.order_type, b.table_number, a.total_amount, a.cash_amount, a.EFT_amount, a.cheque_amount,a.voucher_amount, a.service_amount, a.deposit_amount from payment a, order_info_archive b,bill_print_time c where a.order_id=b.order_id and a.order_id=c.order_id and c.payment_time >= {0} and c.payment_time < {1} and b.serial_no='{2}' order by b.order_type";
                    sRetval = "select b.order_id, b.order_type, b.table_number, a.total_amount, a.cash_amount, a.EFT_amount, a.cheque_amount,a.voucher_amount,a.account_pay, a.service_amount, a.discount, a.deposit_amount,a.service_charge_cash,a.service_charge_eft,a.service_charge_cheque,a.service_charge_voucher,a.service_charge_acc from payment a, order_info_archive b,bill_print_time c where a.order_id=b.order_id and a.order_id=c.order_id and c.payment_time >= {0} and c.payment_time < {1} and b.serial_no='{2}' order by b.order_type";
                    break;

                case Query.OrderShowForViewReportByTable://Changed
                    sRetval = "select b.order_id, b.order_type, b.table_number, a.total_amount, a.cash_amount, a.EFT_amount, a.cheque_amount,a.voucher_amount,a.account_pay, a.service_amount, a.discount, a.deposit_amount,a.service_charge_cash,a.service_charge_eft,a.service_charge_cheque,a.service_charge_voucher,a.service_charge_acc from payment a, order_info_archive b,bill_print_time c where a.order_id=b.order_id and a.order_id=c.order_id and c.payment_time >= {0} and c.payment_time < {1} and b.table_number={2} order by b.order_type";
                    break;

                case Query.OrderShowForViewReportByPrice://Changed
                    sRetval = "select b.order_id, b.order_type, b.table_number, a.total_amount, a.cash_amount, a.EFT_amount, a.cheque_amount,a.voucher_amount,a.account_pay, a.service_amount, a.discount, a.deposit_amount,a.service_charge_cash,a.service_charge_eft,a.service_charge_cheque,a.service_charge_voucher,a.service_charge_acc from payment a, order_info_archive b,bill_print_time c where a.order_id=b.order_id and a.order_id=c.order_id and c.payment_time >= {0} and c.payment_time < {1} and a.total_amount={2} order by b.order_type";
                    break;

                case Query.OrderShowForViewReportByRefNTable://Changed
                    sRetval = "select b.order_id, b.order_type, b.table_number, a.total_amount, a.cash_amount, a.EFT_amount, a.cheque_amount,a.voucher_amount,a.account_pay, a.service_amount, a.discount, a.deposit_amount,a.service_charge_cash,a.service_charge_eft,a.service_charge_cheque,a.service_charge_voucher,a.service_charge_acc from payment a, order_info_archive b,bill_print_time c where a.order_id=b.order_id and a.order_id=c.order_id and c.payment_time >= {0} and c.payment_time < {1} and b.serial_no='{2}' and b.table_number={3} order by b.order_type";
                    break;

                case Query.OrderShowForViewReportByRefNPrice://Changed
                    sRetval = "select b.order_id, b.order_type, b.table_number, a.total_amount, a.cash_amount, a.EFT_amount, a.cheque_amount,a.voucher_amount,a.account_pay, a.service_amount, a.discount, a.deposit_amount,a.service_charge_cash,a.service_charge_eft,a.service_charge_cheque,a.service_charge_voucher,a.service_charge_acc from payment a, order_info_archive b,bill_print_time c where a.order_id=b.order_id and a.order_id=c.order_id and c.payment_time >= {0} and c.payment_time < {1} and b.serial_no='{2}' and a.total_amount={3} order by b.order_type";
                    break;

                case Query.OrderShowForViewReportByTableNPrice://Changed
                    sRetval = "select b.order_id, b.order_type, b.table_number, a.total_amount, a.cash_amount, a.EFT_amount, a.cheque_amount,a.voucher_amount,a.account_pay, a.service_amount, a.discount, a.deposit_amount,a.service_charge_cash,a.service_charge_eft,a.service_charge_cheque,a.service_charge_voucher,a.service_charge_acc from payment a, order_info_archive b,bill_print_time c where a.order_id=b.order_id and a.order_id=c.order_id and c.payment_time >= {0} and c.payment_time < {1} and b.table_number={2} and a.total_amount={3} order by b.order_type";
                    break;

                case Query.OrderShowForViewReportByAll://Changed
                    sRetval = "select b.order_id, b.order_type, b.table_number, a.total_amount, a.cash_amount, a.EFT_amount, a.cheque_amount,a.voucher_amount,a.account_pay, a.service_amount, a.discount, a.deposit_amount,a.service_charge_cash,a.service_charge_eft,a.service_charge_cheque,a.service_charge_voucher,a.service_charge_acc from payment a, order_info_archive b,bill_print_time c where a.order_id=b.order_id and a.order_id=c.order_id and c.payment_time >= {0} and c.payment_time < {1} and b.serial_no='{2}' and b.table_number={3} and a.total_amount={4} order by b.order_type";
                    break;

                case Query.DeleteDBForMerge:
                    //sRetval = "delete from order_info where order_id={0} and table_number={1}; delete from order_details where order_id={0}; delete from table_info where table_number={1} and table_type='Table'";
                    sRetval = "delete from order_info where order_id={0} and table_number={1}; delete from table_info where table_number={1} and table_type='Table'; update order_details set order_id={2} where order_id={0}";
                    break;

                case Query.UpdateDBForMerge:
                    //sRetval = "update order_info set guest_count={2} where order_id={0} and table_number={1}";
                    sRetval = "update order_info set guest_count={2} where order_id={0} and table_number={1}";
                    break;

                case Query.OrderShowByStatusNDate:
                    //sRetval = "select order_id, order_type, table_number from order_info where status='{0}' and convert(varchar,order_time,101)='{1}' order by order_type";
                    sRetval = "select order_id, order_type, table_number from order_info where status='{2}' and order_time>={0} and order_time<{1} order by order_type";
                    break;

                case Query.OrderShowForViewReport: //Changed                                       
                    sRetval = "select b.order_id, b.order_type, b.table_number, a.total_amount, a.cash_amount, a.EFT_amount, a.cheque_amount, a.voucher_amount, a.service_amount,a.account_pay, a.discount, a.deposit_amount,a.service_charge_cash,a.service_charge_eft,a.service_charge_cheque,a.service_charge_voucher,a.service_charge_acc from payment a, order_info_archive b,bill_print_time c where a.order_id=b.order_id and a.order_id=c.order_id and c.payment_time >= {0} and c.payment_time < {1} order by b.order_type";
                    break;

                case Query.OrderShowForViewReportByPC://Changed
                    sRetval = "select b.order_id, b.order_type, b.table_number, a.total_amount, a.cash_amount, a.EFT_amount, a.cheque_amount, a.voucher_amount, a.service_amount,a.account_pay, a.discount, a.deposit_amount,a.service_charge_cash,a.service_charge_eft,a.service_charge_cheque,a.service_charge_voucher,a.service_charge_acc from payment a, order_info_archive b, bill_print_time c where a.order_id=b.order_id and a.order_id=c.order_id and c.payment_time >= {0} and c.payment_time < {1} and a.pc_id={2} order by b.order_type";
                    break;

                case Query.OrderSeatTimeByOrderID:
                    sRetval = "select order_id,seat_time from order_seat_time where order_id = {0}";
                    break;

                case Query.DeleteOrderByID:
                    sRetval = "delete from order_info where order_id={0}";
                    break;

                case Query.OrderVoucherInsert:
                    sRetval = "insert into order_voucher values({0},{1},{2})";
                    break;

                #endregion

                #region Button Access Queries
                case Query.ButtonAccessInsert:
                    sRetval = "insert into button_access values( {0}, {1} )";
                    break;

                case Query.ButtonAccessUpdate:
                    sRetval = "update button_access set user_id={0},button_id={1}";
                    break;

                case Query.ButtonAccessDelete:
                    sRetval = "delete from button_access where user_id={0} and button_id={1}";
                    break;

                case Query.ButtonAccessGetAll:
                    sRetval = "select * from button_access";
                    break;
                # endregion
              
                #region Button Color Queries
                case Query.ButtonColorGetAll:
                    sRetval = "select * from button_color";
                    break;
                #endregion

                #region Parent Category Queries

                case Query.ParentCategoryGetAll:
                    sRetval = "select * from parent_category";
                    break;
                #endregion

                #region Category 1 Queries
                case Query.Category1GetAll:
                    sRetval = "select * from category1";
                    break;
                #endregion

                #region Category 2 Queries 
                case Query.Category2GetAll:
                    sRetval = "select * from category2 order by cat2_order";
                    //sRetval = "select category2.*,category1.Cat1_order_number from category2 inner join category1 on category1.cat1_id=category2.cat1_id order by category1.Cat1_order_number,category2.cat2_order";
                    break;

                #endregion

                #region Category 3 Queries
                case Query.Category3GetAll:
                    sRetval = "select * from category3 order by cat3_order";
                    break;
                case Query.GetCategory3ByCategory3ID:
                    sRetval = " select * from category3 where cat3_id = {0} ";
                    break;
                
                #endregion

                #region Category 4 Queries
                case Query.Category4GetAll:
                    sRetval = "select * from category4 order by cat4_order";
                    break;

                #endregion


                #region Order Details Queries
                case Query.OrderDetailsInsert:
                   // sRetval = "insert into order_details(order_id,product_id,quantity,amount,remarks,food_type,cat_level,item_order_time,user_id, itemUnitPrice,VatTotal,Amount_with_vat,product_Name) values ( {0},{1},{2},{3},'{4}','{5}',{6},{7},{8},{9},{10},{11},'{12}')";
                    sRetval = "insert into order_details(order_id,product_id,quantity,amount,remarks,food_type,cat_level,item_order_time,user_id, itemUnitPrice,VatTotal,Amount_with_vat,product_Name,UoM,productType) values ( {0},{1},{2},{3},'{4}','{5}',{6},{7},{8},{9},{10},{11},'{12}','{13}','{14}')";
                    break;

                case Query.OrderDetailsArchieveInsert:
                    //sRetval = "insert into order_details_archive(order_detail_id,order_id,product_id,quantity,amount,remarks,food_type,cat_level,user_id,item_order_time,product_Name) values ( {0},{1},{2},{3},{4},'{5}','{6}',{7},{8},{9},'{10}')";

                    sRetval = "insert into order_details_archive(order_detail_id,order_id,product_id,quantity,amount,remarks,food_type,cat_level,user_id,item_order_time,product_Name,UoM,productType) values ( {0},{1},{2},{3},{4},'{5}','{6}',{7},{8},{9},'{10}','{11}','{12}')";
                    break;


                case Query.OrderDetailsUpdate:
                    sRetval = "update order_details set order_id={0},product_id={1},quantity={2},amount={3},remarks='{4}',food_type='{5}',cat_level={6},print_send={8},vatTotal ={9}, amount_with_vat={10} where order_detail_id={7}";
                    break;

                case Query.OrderDetailsDelete:
                    sRetval = "delete from order_details where order_detail_id={0}";
                    break;

                //case Query.OrderDetailsGetAll:
                //    sRetval = "select order_detail_id,order_id,product_id,quantity,amount,remarks,food_type,cat_level from order_details";
                //    break;

                //case Query.OrderDetailsGetAll:
                //    sRetval = "select order_detail_id,order_id,product_id,quantity,amount,remarks,food_type,cat_level,itemUnitPrice from order_details";
                //    break;


                case Query.OrderDetailsGetAll:
                    sRetval = "select order_detail_id,order_id,product_id,quantity,amount,remarks,food_type,cat_level,vatTotal,amount_with_vat,itemUnitPrice,print_send,kitchen_quantity,guest_print_qnty,item_discount from order_details";
                    break;

                case Query.OrderDetailsGetByOrderId:
                   //sRetval = "select order_detail_id,order_id,product_id,quantity,amount,remarks,food_type,cat_level,print_send,user_id,item_order_time, itemUnitPrice from order_details where order_id={0}";
                    sRetval = "select order_detail_id,order_id,product_id,quantity,amount,remarks,food_type,cat_level,print_send,user_id,item_order_time, itemUnitPrice,vatTotal,amount_with_vat,product_Name,productType,UoM,guest_print_qnty,kitchen_quantity,item_discount from order_details where order_id={0}";
                    break;

                case Query.OrderDetailsGetByOrderDetailID:
                    sRetval = "select order_detail_id,order_id,product_id,quantity,amount,remarks,food_type,cat_level,print_send,guest_print_qnty,item_discount,itemUnitPrice,item_discount from order_details where order_detail_id={0}";
                    break;

                case Query.OrderDetailsArchiveGetByOrderId:
                    sRetval = "select order_detail_id,order_id,product_id,quantity,amount,remarks,food_type,cat_level,0 as print_send from order_details_archive where order_id={0}";
                    break;

                case Query.GetOrderInfo:
                    /*sRetval = "select order_id,  table_number, guest_count, order_type, order_time, " +
                             "NonfoodPrice, FoodPrice, total_amount, service_charge_cash, discount " +
                             "from vw_orderDetails" +
                             " where order_time >= {0} AND order_time <= {1} ";
                     * */
                    sRetval = "select * " +
                          "from VIEW_REPORT" +
                          " where [Order Date-Time] >= {0} AND [Order Date-Time] <= {1} ";
                    break;

                case Query.GetArchiveItemDetails:
                    sRetval = "SELECT user_name, order_detail_id, item_order_time, cat_level, order_id, product_id, "+
                        "quantity,amount,remarks,food_type,serial_no,guest_count,order_time,table_name,item_name "+
                        " FROM vw_itemDetails Where order_id = {0}";
                    break;

                    //for valt in PLU
                case Query.LastPLUOrderDetails:
                    sRetval="SELECT TOP(1) *FROM order_details ORDER BY order_detail_id DESC ";
                    break;

                #region "Added By Baruri"
                ///Collecting the online order added by baruri at 08.01.2009.These orders are merged with the local orders
                case Query.GetOnlineOrders:
                    sRetval =  " select distinct ord.order_id,onord.order_id,onord.order_type,onord.table_name,onord.table_number,"+
                               " onord.guest_count,onord.status,onord.user_id as user_name,ord.online_orderid as online_orderid from online_order_info onord " +
                               " inner join order_info ord on ord.online_orderid=onord.order_id";
                    break;
                    //Online order details query
                case Query.OnlineOrderDetailsByOrderID:
                    sRetval = "select order_id,item_name,quantity,amount,cat_id,cat_level,cat_rank,order_details_id,printed_quantity,food_type,remarks,item_order_number from vw_online_order_details where order_id={0}";
                    break;

                case Query.DeleteOnlineOrders:
                    sRetval = "delete from online_order_info where item_order_number={0}";
                    break;

                case Query.AddNewOnlineOrderedItem:
                    sRetval = "update online_order_info set quantity={0},amount={1} where item_order_number={2}";
                    break;

                case Query.AddNewLocalProducts:
                    sRetval = "update order_details set quantity={0},amount={1},vatTotal={5},amount_with_vat={6} where product_id={2} and order_id={3} and order_detail_id={4}";
                    break;

                case Query.DeleteOnlineOrder:
                    sRetval = "delete from online_order_info where order_id={0}";
                    break;

                case Query.UpdateOnlineOrdersDetails:
                    sRetval = "update online_order_info set quantity={0},amount={1} where item_order_number={2}";
                    break;

                case Query.InsertOnlineOrderDetails:
                    sRetval = "insert into online_order_info (order_id,customer_id,user_id,order_type,order_time,status,guest_count,table_number,table_name,terminal_id,online_orderid,webstatus,webstatusnote,OnlineStatus,quantity,amount,remarks,food_type,pcat_name,cat1_name,cat2_name,item_name) values({0},{1},'{2}','{3}',{4},'{5}',{6},{7},'{8}',{9},{10},'{11}','{12}',{13},{14},{15},'{16}','{17}','{18}','{19}','{20}','{21}')";
                    break;

                #endregion

                #endregion

                //#region Order Discount queries

                //case Query.OrderDiscountInsert:
                //    sRetval = "insert into order_discount(order_id,discount) values({0},{1});";
                //    break;

                //case Query.OrderDiscountUpdate:
                //    sRetval = "update order_discount set discount={0} where order_id={1};";
                //    break;

                //case Query.OrderDiscountGetByOrderID:
                //    sRetval = "select order_id,discount from order_discount where order_id={0};";
                //    break;


                //#endregion

                #region Order Discount queries

                case Query.OrderDiscountInsert:
                    sRetval = "insert into order_discount( order_id,discount, discountPercentRate, membershipID , membershipCardID, clientID, membershipPoint, membershipTotalPoint, membershipDiscountRate, membershipDiscountAmount,TotalItemDiscount) "
                                                 + " values(  {0},    {1},            {2},             {3},           {4},            {5},        {6},              {7},                     {8},                   {9},                  {10}   );";
                    break;
                //order_id, discount, discountPercentRate, membershipID, membershipCardID, clientID, membershipPoint, membershipTotalPoint, membershipDiscountRate, membershipDiscountAmount
                case Query.OrderDiscountUpdate:
                    sRetval = "update order_discount set discount = {0}, discountPercentRate = {1}, membershipID  = {2}, membershipCardID  = {3}, clientID  = {4}, membershipPoint  = {5}, membershipTotalPoint  = {6}, membershipDiscountRate  = {7}, membershipDiscountAmount  = {8}, TotalItemDiscount={10}  where order_id={9};";
                    break;

                case Query.OrderDiscountGetByOrderID:
                    sRetval = "select * from order_discount where order_id={0};";
                    break;

                #endregion

                case Query.ScopeIdentity:
                    sRetval = "select scope_identity() ";
                    break;

                #region Table Info Queries

                case Query.UpdateTableInfo:
                    sRetval = "update table_info set capacity={0},status={1} where table_number={2} and table_type='{3}'";
                    break;

                case Query.InsertTableInfo:
                    sRetval = "insert into table_info (table_number,capacity,status,table_type) values({0},{1},{2},'{3}')";
                    break;

                case Query.TableInfoGetAll:
                    sRetval = "select table_number,capacity,status,table_type from table_info";
                    break;

                case Query.TableInfoGetByTableNumber:
                    sRetval = "select table_number,table_type,capacity,status from table_info where table_number = {0} and table_type='{1}'";
                    break;

                case Query.GetTableNumberList:
                    sRetval = "select table_number from table_info where table_type='{0}' order by table_number asc";
                    break;

                case Query.InsertDBForTransfer:
                    sRetval = "insert into table_info(table_number,capacity,status,table_type)   values({0},{1},0,'Table')";
                    break;

                case Query.UpdateDBForUnlock:
                    sRetval = "update table_info set status=0 where table_number={0} and table_type='{1}'";
                    break;

                case Query.ShowAvailableTableForTransfer:
                    sRetval = "select a.table_number, a.capacity, a.status, a.table_type  from table_info a where a.table_type='Table'";
                    break;
                case Query.DeleteTableInfo:
                    sRetval = "delete from table_info where table_number={0} and table_type='{1}'";
                    break;

                #endregion

                #region Payment queries

                case Query.PaymentInsert:
                    sRetval = "insert into payment(order_id,pc_id,total_amount,cash_amount,EFT_amount,cheque_amount,voucher_amount,service_amount,discount,account_pay,deposit_id,deposit_amount,userid,paymentdate,service_charge_cash,service_charge_eft,service_charge_cheque,service_charge_voucher,service_charge_acc,vat_imposed, guest_bill, vat_stat,cost,waiter,tipsamount ,membershipDiscount,Complementory,Due,PaymentPerson,ItemDiscount)  values( {0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18}, {19}, '{20}', {21},{22},'{23}',{24},{25},'{26}','{27}','{28}',{29} )";
                    break;

                case Query.PaymentUpdate:
                    sRetval = "update payment set order_id={0}, pc_id={1}, total_amount={2},cash_amount={3},eft_amount={4},cheque_amount={5},voucher_amount={6},service_amount={7},discount={8},account_pay={9},deposit_id={10},deposit_amount={11},service_charge_cash={13},service_charge_eft={14},service_charge_cheque={15},service_charge_voucher={16},service_charge_acc={17}, vat_imposed={18}, guest_bill='{19}', vat_stat={20} where payment_id={12}";
                    break;

                case Query.PaymentUpdateOnlyVatStat:
                    sRetval = "update payment set  vat_stat={0} where order_id={1}";
                    break;

                case Query.PaymentDelete:
                    sRetval = "delete from payment where payment_id={0}";
                    break;

                case Query.PayementGetByOrderID:
                    sRetval = "select payment_id,order_id,pc_id,total_amount,cash_amount,eft_amount,cheque_amount,voucher_amount,service_amount,discount,account_pay,deposit_id,deposit_amount from payment where order_id={0}";
                    break;

                case Query.GetOrderIDFromBillPrintTime:
                    sRetval = "select order_id from bill_print_time where order_id={0};";
                    break;

                case Query.InsertBillPrintTime://Changed
                    //sRetval = "insert into bill_print_time values({0},'{1}','{2}');";
                    sRetval = "insert into bill_print_time values({0},{1},{2}); ";
                    break;

                case Query.UpdateBillPrintTime://Changed
                    //sRetval = "update bill_print_time set bill_print_time='{0}',payment_time='{1}' where order_id={2};";
                    sRetval = "update bill_print_time set bill_print_time={0},payment_time={1} where order_id={2};";
                    break;

                case Query.GetSortedPayment:
                    //sRetval = "select max(payment.total_amount) from payment,bill_print_time where payment.order_id=bill_print_time.order_id and bill_print_time.payment_time>='{0}' and bill_print_time.payment_time<'{1}'";
                    sRetval = "select max(payment.total_amount) from payment,bill_print_time where payment.order_id=bill_print_time.order_id and bill_print_time.payment_time>={0} and bill_print_time.payment_time<{1}";
                    break;

                #endregion

                #region Customer Info Queries

                case Query.CustomerInsert:
                    //Modified by Baruri at 01.12.2008
                    sRetval = "insert into customer_info(name,floororapt_number,building_name,house_number,phone,postal_code,town,country,userid,insertdate,terminal_id,street_name) values( '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}',{9},{10},'{11}')";
                    break;

                case Query.CustomerUpdate:
                    sRetval = "update customer_info set name='{0}',phone='{1}',postal_code='{2}',town='{3}',country='{4}',floororapt_number='{5}',building_name='{6}',house_number='{7}',street_name='{8}' where customer_id='{9}'";
                    break;

                case Query.CustomerDelete:
                    sRetval = "delete from customer_info where customer_id={0}";
                    break;

                case Query.CustomerInfoGetByCustomerID:
                    sRetval = "select customer_id,name,floororapt_number,building_name,house_number,phone,postal_code,town,country,userid,insertdate,terminal_id,street_name from customer_info where customer_id={0}";
                    break;

                case Query.CustomerInfoGetByPhone:
                    sRetval = "select customer_id,name,floororapt_number,building_name,house_number,phone,postal_code,town,country,userid,insertdate,terminal_id,street_name from customer_info where phone='{0}'";
                    break;

                case Query.CustomerInfoGetByName:
                    sRetval = "select customer_id,name,floororapt_number,building_name,house_number,phone,postal_code,town,country,userid,insertdate,terminal_id,street_name from customer_info where name='{0}'";
                    break;

                case Query.CustomerInfoGetByNameNPhone:
                    sRetval = "select customer_id,name,floororapt_number,building_name,house_number,phone,postal_code,town,country,userid,insertdate,terminal_id,street_name from customer_info where name = '{0}' and phone='{1}'";
                    break;

                case Query.CustomerInfoGetAll:
                    sRetval = "select customer_id,name,floororapt_number,building_name,house_number,phone,postal_code,town,country,userid,insertdate,terminal_id,street_name from customer_info;";
                    break;

                case Query.GetCustomerAddressDetails:
                    sRetval = "select  ORD,ORG,SBN,BNA,POB,NUM,DST,STR,DDL,DLO,TWN,PCD,CTA,CTP,CTT,SCD,CAT,NDP,DPS,URN from bn20premperpostcode where  NUM ='{0}' and replace(PCD,' ','')='{1}'";
                    break;


                case Query.GetCustomerAddressWithoutHouseNumber:
                    sRetval = "select  ORD,ORG,SBN,BNA,POB,NUM,DST,STR,DDL,DLO,TWN,PCD,CTA,CTP,CTT,SCD,CAT,NDP,DPS,URN from bn20premperpostcode where replace(PCD,' ','')='{0}'";
                    break;

                case Query.GetCustomersByName:
                    sRetval = "select name,(floororapt_number+' '+building_name+' '+house_number) as address,phone from customer_info where name like '%{0}%'";
                    break;

                case Query.TakeawayCustomerInfo:
                    sRetval = "select ordinfo.customer_id,cusinfo.name,cusinfo.house_number,cusinfo.phone,cusinfo.postal_code,cusinfo.country,cusinfo.town,cusinfo.floororapt_number,cusinfo.building_name,cusinfo.street_name from order_info ordinfo  inner join customer_info cusinfo on cusinfo.customer_id=ordinfo.customer_id where ordinfo.order_id={0}";
                    break;

                #endregion

                # region Payment Summary Queries//total changed

                case Query.PaymentSummaryGetTotal:
                    sRetval = "select sum(a.total_amount) total,sum(a.cash_amount) cash_total, sum(a.EFT_amount) EFT_total, sum(a.cheque_amount) cheque_total, sum(a.voucher_amount) voucher_total, sum(a.service_amount) service_total,sum(a.account_pay) acc_total ,sum(a.service_charge_cash) total_cash,sum(a.service_charge_eft) total_eft,sum(a.service_charge_cheque) total_cheque,sum(a.service_charge_voucher) total_voucher,sum(a.service_charge_acc) total_acc , sum(a.discount) discount_total, sum(a.deposit_amount) deposit_total, sum(b.guest_count) guest_total, count(distinct b.table_number) table_total from payment a,order_info_archive b,bill_print_time c where a.order_id=b.order_id and a.order_id=c.order_id and c.payment_time >= {0} and c.payment_time < {1}";
                    break;

                case Query.PaymentSummaryGetTotalByOrderType:
                    sRetval = "select sum(a.total_amount) total,sum(a.cash_amount) cash_total, sum(a.EFT_amount) EFT_total, sum(a.cheque_amount) cheque_total, sum(a.voucher_amount) voucher_total, sum(a.service_amount) service_total, sum(a.discount) discount_total, sum(a.deposit_amount) deposit_total,sum(a.account_pay) acc_total ,sum(a.service_charge_cash) total_cash,sum(a.service_charge_eft) total_eft,sum(a.service_charge_cheque) total_cheque,sum(a.service_charge_voucher) total_voucher,sum(a.service_charge_acc) total_acc, sum(b.guest_count) guest_total, count(distinct b.table_number) table_total from payment a,order_info_archive b,bill_print_time c where a.order_id=b.order_id and a.order_id=c.order_id and c.payment_time >= {0} and c.payment_time < {1} and b.order_type='{2}'";
                    break;

                case Query.PaymentSummaryGetTotalByPC:
                    sRetval = "select sum(a.total_amount) total,sum(a.cash_amount) cash_total, sum(a.EFT_amount) EFT_total, sum(a.cheque_amount) cheque_total, sum(a.voucher_amount) voucher_total, sum(a.service_amount) service_total, sum(a.discount) discount_total, sum(a.deposit_amount) deposit_total,sum(a.account_pay) acc_total ,sum(a.service_charge_cash) total_cash,sum(a.service_charge_eft) total_eft,sum(a.service_charge_cheque) total_cheque,sum(a.service_charge_voucher) total_voucher,sum(a.service_charge_acc) total_acc, sum(b.guest_count) guest_total, count(distinct b.table_number) table_total from payment a,order_info_archive b,bill_print_time c where a.order_id=b.order_id and a.order_id=c.order_id and c.payment_time >= {0} and c.payment_time < {1} and a.pc_id={2}";
                    break;

                case Query.PaymentSummaryGetFoodTypeTotal:
                    sRetval = "select sum(amount) food_total from order_details_archive where order_id in(select a.order_id from payment a,order_info_archive b,bill_print_time c where a.order_id=b.order_id and a.order_id=c.order_id and convert(varchar,c.payment_time,101)='{0}') and food_type='Food'";
                    break;

                case Query.PaymentSummaryGetNonFoodTypeTotal:
                    sRetval = "select sum(amount) nonfood_total from order_details_archive where order_id in(select a.order_id from payment a,order_info_archive b,bill_print_time c where a.order_id=b.order_id and a.order_id=c.order_id and convert(varchar,c.payment_time,101)='{0}') and food_type='Nonfood'";
                    break;

                case Query.PaymentGetTypeTotal:
                    sRetval = "select sum(amount) type_total from order_details_archive where order_id in(select a.order_id from payment a,order_info_archive b,bill_print_time c where a.order_id=b.order_id and a.order_id=c.order_id and c.payment_time>={0} and c.payment_time <{1}) and food_type='{2}'";
                    break;

                case Query.PaymentGetTypeTotalByPC:
                    sRetval = "select sum(amount) type_total from order_details_archive where order_id in(select a.order_id from payment a,bill_print_time c where a.order_id=c.order_id and c.payment_time >={0} and c.payment_time < {1} and a.pc_id={3}) and food_type='{2}'";
                    break;

                case Query.PaymentGetTypeTotalByOrderType:
                    sRetval = "select sum(amount) type_total from order_details_archive where order_id in(select a.order_id from payment a,order_info_archive b,bill_print_time c where a.order_id=b.order_id and a.order_id=c.order_id and c.payment_time>={0} and c.payment_time <{1} and b.order_type='{3}') and food_type='{2}'";
                    break;

                #endregion

                #region Booking

                case Query.BookingInfoGetAll:
                    sRetval = "select a.booking_id,a.customer_id,a.booking_time,a.booking_type,a.status,a.comments,a.guest_count,a.table_count,b.name,b.floororapt_number,b.building_name,b.house_number,b.phone,b.postal_code,b.town,b.country,b.street_name from booking_info a,customer_info b where a.customer_id=b.customer_id and booking_time>={0} and booking_time<{1}";
                    break;

                case Query.BookingInfoGetByID:
                    sRetval = "select a.booking_id,a.customer_id,a.booking_time,a.booking_type,a.status,a.comments,a.guest_count,a.table_count,b.name,b.floororapt_number,b.building_name,b.house_number,b.phone,b.postal_code,b.town,b.country,b.street_name from booking_info a,customer_info b where a.customer_id=b.customer_id and a.booking_id={0}";
                    break;

                case Query.BookingInfoInsert:
                    sRetval = "insert into booking_info (booking_type,booking_time,customer_id,guest_count,status,comments,table_count) values('{0}',{1},{2},{3},'{4}','{5}',{6})";
                    break;

                case Query.BookingInfoDelete:
                    sRetval = "delete from booking_info where booking_id={0}";
                    break;

                case Query.BookingInfoUpdate:
                    sRetval = "update booking_info set booking_type='{1}',booking_time={2},customer_id={3},guest_count={4},status='{5}',comments='{6}',table_count={7} where booking_id={0}";
                    break;

                #endregion

                #region Deposit Queries

                case Query.DepositInsert:
                    sRetval = "insert into deposit(balance,deposit_time,customer_id,total_amount,pc_id,status,deposit_type) values({0},{1},{2},{3},{4},{5},'{6}')";
                    break;
                    

                case Query.DepositGetByDepositID:
                    sRetval = "select deposit_id,balance,deposit_time,customer_id,total_amount,pc_id,status,deposit_type from deposit where deposit_id={0}";
                    break;

                case Query.DepositUpdate:
                    sRetval = "update deposit set balance={0},deposit_time={1},customer_id={2},total_amount={3},pc_id={4},status={5},deposit_type='{6}' where deposit_id={7}";
                    break;

                case Query.InsertDepositUsed:
                    sRetval = "insert into deposit_used(deposit_id,used_amount) values({0},{1})";
                    break;

                case Query.GetDepositsByDate:
                    sRetval = "select deposit_id,balance,deposit_time,customer_id, total_amount,pc_id,status,deposit_type from deposit where deposit_time>={0} and deposit_time<{1} and balance>0";
                    break;

                case Query.GetDepositSummary:
                    sRetval = "select sum(a.total_amount) total,sum(a.cash_amount) cash_total, sum(a.EFT_amount) EFT_total, sum(a.cheque_amount) cheque_total, sum(a.voucher_amount) voucher_total, 0 as service_total, 0 as discount_total, 0 as deposit_total, 0 as guest_total, 0 as table_total from Deposit a where  a.deposit_time >= {0} and a.deposit_time < {1} and balance>0";
                    break;

                case Query.DepositGetByCustomerID:
                    sRetval = "select deposit_id,balance,deposit_time,customer_id,total_amount,pc_id,status,deposit_type from deposit where customer_id={0} and balance>0";
                    break;
                

                #endregion

                #region Delivery Queries

                case Query.InsertDelivery:
                    sRetval = "insert into delivery(order_id,delivery_time) values({0},'{1}')";
                    break;
    
                #endregion

                #region Recent Order Queries
                case Query.GetRecentOrderByCustomerID:
                    sRetval = "select * from order_info_archive,payment where order_info_archive.order_id=payment.order_id and customer_id={0} and order_type='TakeAway' order by order_time desc";
                    break;

                #endregion

                #region Print Style Queries

                case Query.GetPrintStyles:
                    sRetval = "select * from print_style";
                    break;

                #endregion

                #region "Log register for the different activities"

                case Query.LogRegisterForOrders:
                    sRetval = "select infar.terminal_id,infar.user_id,infar.order_time,infar.order_type,uinfo.user_name,infar.order_id from order_info_archive infar left outer join user_info uinfo on  uinfo.user_id=infar.user_id  where infar.order_time>={0} and infar.order_time<={1}";
                    break;

                case Query.LogRegisterForPayment:
                    sRetval = "select pc_id,userid,paymentdate,total_amount,order_id from payment where paymentdate>={0} and paymentdate<={1}";
                    break;
                    
                case Query.SaveDrawerOpening:
                    sRetval = "insert into tbl_opendrawer_tracking (userid,opentime,terminal_id) values('{0}',{1},{2})";
                    break;

                case Query.DrawerLogdetails:
                    sRetval = "select terminal_id,userid,opentime,'open' as pp from tbl_opendrawer_tracking where opentime>={0} and opentime<={1}";
                    break;
                #endregion


                #region "System Management"
                case Query.DeleteDefaultTime:
                    sRetval = "delete from takeaway_default_time";
                    break;
                     case Query.SaveDefaultTime:
                    sRetval = "insert into takeaway_default_time  (record_id,time_duration) values(1,{0})";
                    break;

                    
                #endregion

                #region "KitchenText Area"

                    case Query.GetKitchenTextByID:
                    sRetval = "select kicthen_text_id,kitchen_text from kitchen_text where kicthen_text_id={0}";
                    break;

                    case Query.GetAllKitchenText:
                    sRetval = "select kicthen_text_id,kitchen_text from kitchen_text";
                    break;

                    case Query.SaveKitchenText:
                    sRetval = "insert into kitchen_text (kitchen_text) values('{0}')";
                    break;

                    case Query.UpdateKitchenText:
                    sRetval = "update kitchen_text set kitchen_text='{0}' where kicthen_text_id={1}";
                    break;

                    case Query.DeleteKitchenText:
                    sRetval = "delete from kitchen_text where kicthen_text_id={0}";
                    break;

                #endregion


                    #region Shift Order Info

                    case Query.AddShiftOrderInfo:
                    sRetval = " insert into ShiftOrderInfo (  shiftID, orderID, creationDate,  shiftNo, paymentcreationDate ) " +
                                             "  values (          {0},      {1},        '{2}' ,    {3}  ,         '{4}' )";
                    break;

                    case Query.UpdateShiftOrderInfo:
                    sRetval = " update ShiftOrderInfo set shiftID =  {0},  orderID = {1} , creationDate = '{2}',  shiftNo  = {3}, paymentcreationDate = '{4}'  where shift_id =   {5} ;";
                    break;

                    case Query.DeleteShiftOrderInfo:
                    sRetval = " delete from ShiftOrderInfo where ShiftOrderID = {0} ";
                    break;

                    case Query.GetAllShiftOrderInfoByPaymentcreationDate:

                    sRetval = " select * from ShiftOrderInfo where paymentcreationDate between '{0}'and '{1}'";
                    break;

                    case Query.GetAllShiftOrderInfoID:
                    sRetval = " select * from ShiftOrderInfo where ShiftOrderID ={0}";
                    break;

                    case Query.GetAllShiftOrderInfo:
                    sRetval = " select *from ShiftOrderInfo ";
                    break;

                    case Query.DeleteShiftSchedule:
                    sRetval = " delete from Shift_Schedule where schedule_id = {0} ";
                    break;

                    case Query.GetAllShiftSchedule:
                    sRetval = " select *from Shift_Schedule ";
                    break;

                    case Query.UpdateShiftSchedule:
                    sRetval = " update Shift_Schedule set creationDate = '{0}',  shift_no = {1} , start_day = '{2}',  start_time  = '{3}',   end_day  = '{4}',   end_time = '{5}',  start_timestamp = {6}, end_timestamp = {7},  isactive  = '{8}' , shift_id = {9}  where schedule_id =   {10} ;";
                    break;

                    case Query.GetAllShiftScheduleID:
                    sRetval = " select * from Shift_Schedule where schedule_id ={0}";
                    break;

                    case Query.AddShiftSchedule:
                    sRetval = " insert into Shift_Schedule (  creationDate ,  shift_no,   start_day, start_time,   end_day,  end_time,   start_timestamp, end_timestamp, isactive , shift_id) " +
                                             "  values (         '{0}',             {1},     '{2}',      '{3}' ,    '{4}',     '{5}',     {6},                 {7},      '{8}'  , {9}) ";
                    break;

                    case Query.GetAllShiftScheduleByShiftID:
                    sRetval = " select * from Shift_Schedule where shift_id ={0}";
                    break;


                    case Query.GetAllShiftSCheduleByCreationDate:
                    sRetval = " select * from Shift_Schedule where creationDate = '{0}'";
                    break;

                    #endregion


                    case Query.PcInfoByPcIP:
                    sRetval = "select pc_id,pc_ip,name from pc_info where pc_ip='{0}'";
                    break;
                    

                case Query.GetdeliveryTime:
                    sRetval = "select delivery_time from delivery where order_id={0}";
                    break;

                case Query.UpdateDeliveryInfo:
                    sRetval = "update delivery set delivery_time='{1}'  where order_id={0}";
                    break;

                case Query.UpdateTakwawayOrderStatus:
                    sRetval = "update order_info set status='{1}'  where order_id={0}";
                    break;

                case Query.SelectOnlineOrderDetailsDetailsByIDFromOrderTable:
                    sRetval = "select online_orderid from order_info where order_id={0}";
                    break;

                case Query.SelectOnlineOrderDetailsDetailsByIDFromOnlineOrderTable:
                    sRetval = "select order_id,customer_id,user_id,order_type,order_time,status,guest_count,table_number,table_name,terminal_id,online_orderid,webstatus,webstatusnote,OnlineStatus,remarks,food_type,pcat_name,cat1_name,cat2_name,item_name,item_order_number from online_order_info where order_id={0}";
                    break;

                case Query.GetOnlineItemOrderMaxNumber:
                    sRetval = "select max(item_order_number) as item_order_number from online_order_info";
                    break;
                 
                case Query.GetOnlineOrderPrintStatus:
                    sRetval = "select online_order_print_status from order_info where order_id={0}";
                    break;

                case Query.ChangeOnlineOrderPrintStatus:
                    sRetval = " update order_info set online_order_print_status=2 where order_id={0}";
                    break;


                case Query.GetOnlineOrderedItemsById:
                    sRetval = "select order_id,customer_id,user_id,order_type,order_time,status,guest_count,table_number,table_name,terminal_id,online_orderid,webstatus,webstatusnote,OnlineStatus,quantity,amount,remarks,food_type,pcat_name,cat1_name,cat2_name,item_name,item_order_number,printed_quantity from vw_onlineOrderedItems where order_id={0}";
                    break;

                case Query.InsertOnlineOrderedItemsArchive:
                    sRetval = "insert into online_order_info_archive (order_id,customer_id,user_id,order_type,order_time,status,guest_count,table_number,table_name,terminal_id,online_orderid,webstatus,webstatusnote,OnlineStatus,quantity,amount,remarks,food_type,pcat_name,cat1_name,cat2_name,item_name,item_order_number,printed_quantity) values({0},{1},'{2}','{3}',{4},'{5}',{6},{7},'{8}',{9},{10},'{11}','{12}',{13},{14},{15},'{16}','{17}','{18}','{19}','{20}','{21}',{22},{23})";
                    break;
                    

                case Query.UpdatePrintedQuantity:
                    sRetval = " update order_details set print_send={0},send_kitchen_time={4} where product_id={1} and order_id={2} and order_detail_id={3} ";
                    break;

                case Query.UpdateOnlineOrderPrintedQuantity:
                    sRetval = " update online_order_info set printed_quantity={0},send_kitchen_time={3} where item_order_number={1}";
                    break;


                case Query.DeleteOnlineItem:
                    sRetval = " delete from  online_order_info where order_id={0}";
                    break;


                #region "Service Charge"


                   case Query.InsertServiceCharge:
                    sRetval = "insert into order_service_charge (order_id, svc_charge, svc_chargeRate) values({0},{1},{2})";
                    break;

                    case Query.UpdateServiceCharge:
                    sRetval = " update order_service_charge set svc_charge={0}, svc_chargeRate={1} where order_id={2}";
                    break;

                    case Query.GetServiceCharge:
                    sRetval = "select svc_charge, svc_chargeRate from order_service_charge  where order_id={0}";
                    break;


                    case Query.UpdateOnlineItemSpecial:
                    sRetval = " update online_order_info set remarks='{0}' where item_order_number={1}";
                    break;


                    case Query.UpdateLocalVoidItems:
                    sRetval = " update order_details set quantity={0}, print_send={1},amount={3},amount_with_vat={4},vatTotal={5},guest_print_qnty={0} where order_detail_id={2}";
                    break;

                    #region "Order kitchen text area"

                    case Query.SaveOrderKitchenText:
                    sRetval = "INSERT INTO order_kitchen_text (order_id,kitchen_text,print_status) VALUES({0},'{1}',{2})";
                    break;

                    case Query.ModifyOrderkitchenTextStatus:
                    sRetval = " update order_kitchen_text SET print_status=1 where order_id={0}";
                    break;

                    case Query.GetOrderPreviousKtText:
                    sRetval = "select order_id,kitchen_text,print_status from order_kitchen_text where order_id={0}";
                    break;

                  case Query.GetMergeItems:
                    //sRetval = " select  product_id, order_id,quantity ,amount,print_send,remarks,food_type,cat_level from vw_mergeItems where order_id={0} ";
                    sRetval = " select  product_id, order_id,quantity ,amount,print_send,remarks,food_type,cat_level,vatTotal from vw_mergeItems where order_id={0} ";
                    break;

                   case Query.SaveMergeItems:
                   // sRetval = "insert into order_details (order_id,product_id,quantity,amount,remarks,food_type,cat_level,print_send) values({0},{1},{2},{3},'{4}','{5}',{6},{7})";
                    sRetval = "insert into order_details (order_id,product_id,quantity,amount,remarks,food_type,cat_level,print_send,vatTotal) values({0},{1},{2},{3},'{4}','{5}',{6},{7},{8})";

                    break;

                   case Query.DeleteMergeItems:
                    sRetval = "delete from order_details where order_id={0}";
                    break;

                    #endregion

                #endregion

                   #region "Special Modify"

                   case Query.GetSpecialModifyText:
                    sRetval = "select special_modify_text_id,special_modify_text from special_modify_text";
                    break;

                    case Query.SaveSpecialModifyTex:
                    sRetval = "insert into special_modify_text (special_modify_text) values('{0}')";
                    break;

                    case Query.UpdateSpecialModifyTex:
                    sRetval = "update special_modify_text set special_modify_text='{1}' where special_modify_text_id={0}";
                    break;

                    case Query.DeleteSpecialModifyTex:
                    sRetval = "delete from special_modify_text where special_modify_text_id={0}";
                    break;


                    //case Query.CollectProduct3ByPLU:
                    //sRetval = "select cat3_name from category3 where product3_plu={0}";
                    //break;

                    case Query.CollectProduct3ByPLU:
                    sRetval = "select cat3_name,cat3_id,vat_Rate from category3 where product3_plu={0}";
                    break;

                    //case Query.CollectProduct4ByPLU:
                    //sRetval = "select cat4_name from category4 where product4_plu={0}";
                    //break;


                    case Query.CollectProduct4ByPLU:
                    sRetval = "select cat4_name,cat4_id,vat_Rate from category4 where product4_plu={0}";
                    break;

                   case Query.UpdateOnlineVoidItems:
                    sRetval = "update online_order_info set quantity={0}, print_send={1},amount={2} where item_order_number={3} ";
                    break;

                    case Query.DeleteOnlineVoidItems:
                    sRetval = "delete from online_order_info where item_order_number={0}";
                    break;

                    case Query.DeleteLocalOrderVoidID:
                    sRetval = "delete from order_info where order_id={0}";
                    break;
                   #endregion

                    case Query.GetOrderLogInformation:
                    sRetval = " select ordd.order_detail_id,ordd.order_id,ordd.item_order_time,ordd.send_kitchen_time,ordd.user_id,"+
                              "  usr.user_name,ord.guest_bill_print_status  from order_details ordd "+ 
                              "  inner join user_info usr on usr.user_id=ordd.user_id inner join order_info "+
                              " ord on ord.order_id=ordd.order_id where ordd.order_id={0} and ordd.order_detail_id= " +
                              "(select min(order_detail_id) as order_detail_id from order_details where order_id={0}) union " +
                              "  select ordd.order_detail_id,ordd.order_id,ordd.item_order_time,ordd.send_kitchen_time,ordd.user_id,"+
                              "  usr.user_name,ord.guest_bill_print_status  from order_details ordd "+
                              "  inner join user_info usr on usr.user_id=ordd.user_id inner join order_info "+
                              "  ord on ord.order_id=ordd.order_id where ordd.order_id={0} and ordd.order_detail_id= " +
                              "  (select max(order_detail_id) as order_detail_id from order_details where order_id={0})";
                    break;


                    case Query.GetOnlineOrderLogInformation:
                    sRetval = "select onord.order_id as order_detail_id,onord.item_add_time as item_order_time, "+
                              " onord.send_kitchen_time,ord.user_id,usr.user_name,ord.guest_bill_print_status "+
                              " from online_order_info onord  inner join order_info ord on ord.online_orderid=onord.order_id  inner join "+
                              " user_info usr on usr.user_id=ord.user_id  where onord.item_order_number=(select min(item_order_number) "+ 
                              " from online_order_info where order_id=(select online_orderid from order_info where order_id={0})) "+
                              " union all select onord.order_id as order_detail_id,onord.item_add_time as item_order_time, "+
                              " onord.send_kitchen_time,ord.user_id,usr.user_name,ord.guest_bill_print_status "+
                              " from online_order_info onord  inner join order_info ord on ord.online_orderid=onord.order_id  inner join "+
                              " user_info usr on usr.user_id=ord.user_id  where onord.item_order_number=(select max(item_order_number) "+
                              " from online_order_info where order_id=(select online_orderid from order_info where order_id={0}))";
                    break;

                    case Query.ChangeGuestBillPrintStatus:
                    sRetval = "update order_info set guest_bill_print_status=2 where order_id={0}";
                    break;

                    case Query.CurrentWaitingNumber:
                    sRetval = "select max(waiting_number_today) as waiting_number_today from waiting_order_info  where create_date={0}";
                    break;

                    case Query.CurrentCollectionNumber:
                    sRetval = "select max(collection_number_today) as collection_number_today from collection_order_info  where create_date={0}";
                    break;

                    case Query.SaveWaitingInfo:
                    sRetval = "exec sp_save_waiting_info {0}";
                    break;

                    case Query.SaveCollectionInfo:
                    sRetval = "exec sp_save_collection_info {0}";
                    break;

                    case Query.GetSalesRecords:
                    sRetval = "SELECT product_id,proname,sum(quantity) as quantity,sum(amount) as amount,'' as order_time,''as formateddate  FROM vw_solditems_all " +
                              " WHERE order_time>={0} and order_time<={1} group by product_id,proname,food_type";
                    break;


                    case Query.GetInventorySalesRecords:
                    sRetval = 
                        " SELECT arordd.product_id, SUM(arordd.quantity) AS quantity, SUM(arordd.amount) AS amount, arordd.cat_level,food_type, " +
                              "(select sum(guest_count) from  order_info_archive  WHERE order_time>={0} and " +
                              " order_time<={1}) as guest_count FROM dbo.View_order_archive_info AS arordd WHERE order_time>={0} and order_time<={1}  GROUP BY arordd.product_id, arordd.cat_level,food_type order by quantity desc";
                
                        
                        
                              break;

                    case Query.GetInventorySalesRecordsInv:
                              sRetval = //" select arordd.product_id, arordd.product_Name,  arordd.cat_level, arordd.food_type, " +
                                        //   " sum(arordd.quantity) as quantity, (CAST((SUM(arordd.amount)/sum(arordd.quantity)) AS dec(10, 2))) AS amount, (CAST (sum(arordd.amount) AS dec(10, 2))) as TotalAmount, arordd.cat_level, " +
                                         //  " (select sum(guest_count) from order_info_archive WHERE order_time >= {0} and  order_time <= {1} ) as guest_count " +
                                         //  " FROM dbo.View_order_archive_info AS arordd WHERE paymentdate >= {0} and paymentdate <= {1}  group by  arordd.product_id, " +
                                         //  " arordd.product_Name, arordd.cat_level, arordd.food_type order by arordd.product_id desc";

                              " select arordd.product_id, arordd.product_Name,  arordd.cat_level, arordd.food_type," +
                 "sum(arordd.quantity) as quantity, (CAST((SUM(arordd.amount)/sum(arordd.quantity)) AS dec(10, 2))) AS amount, (CAST (sum(arordd.amount) AS dec(10, 2))) as TotalAmount," +
                 "arordd.cat_level, sum(orderArch.guest_count) as guest_count " +
                 " FROM dbo.View_order_archive_info AS arordd inner join  order_info_archive as orderArch " +
                 "on arordd.order_id = orderArch.order_id WHERE paymentdate >= {0} and paymentdate <= {1}" +
                 "group by  arordd.product_id, arordd.product_Name, arordd.cat_level, arordd.food_type order by arordd.product_id desc";
                              
                                           break;

                    case Query.GetRawMat:

                                           sRetval = "Select cat3_id, cat3_name, UnitsInStock, uom, Date, AdditionalQty, PrevQty From raw_mat_in_stock Where datetime >= {0} and datetime <= {1}";

                    break;

                    case Query.GetInventorySalesRecordsInv1:
                                           sRetval = " select arordd.product_id, arordd.product_Name,  arordd.cat_level, arordd.food_type," +
                              "sum(arordd.quantity) as quantity, (CAST((SUM(arordd.amount)/sum(arordd.quantity)) AS dec(10, 2))) AS amount, (CAST (sum(arordd.amount) AS dec(10, 2))) as TotalAmount," +
                              "arordd.cat_level, sum(orderArch.guest_count) as guest_count " +
                              " FROM dbo.View_order_archive_info AS arordd inner join  order_info_archive as orderArch " +
                              "on arordd.order_id = orderArch.order_id WHERE paymentdate >= {0} and paymentdate <= {1} and arordd.productType = Finished" +
                              "group by  arordd.product_id, arordd.product_Name, arordd.cat_level, arordd.food_type order by arordd.product_id desc";

                                           break;

                    case Query.GetGeneralSetting:
                    sRetval = "select * from general_settings";
                    break;


                    case Query.UpdateGenerallSettings:
                    sRetval = "Update general_settings set vat_amount={0}, vat_enabled={1}, currency='{2}' where id=1";
                    break;

                    case Query.InsertEftCard:
                    sRetval = "insert into EFTCard (CardName) Values('{0}')";
                    break;

                    case Query.GetEftCatds:
                    sRetval = "Select distinct id, CardName from EFTCard";
                    break;

                    case Query.UpdateEftCard:
                    sRetval = "update  EFTCard set CardName='{0}' where id={1}";
                    break;

                    case Query.DeleteEftCard:
                    sRetval = "delete  EFTCard where CardName='{0}'";
                    break;


                    case Query.CountEFTpaymentForparticularOrderid:
                    sRetval = "select count(*) from EFTPayment where orderID={0}";
                    break;
                    case Query.AddEFTPayment:
                    sRetval = "insert into  EFTPayment (orderID, cardID, cardName) values({0}, {1}, '{2}')";
                    break;

                    case Query.UpdateEFTpaymentByOrderID:
                    sRetval = "update EFTPayment  set cardID={1}, cardName='{2}'  where orderID={0}";
                    break;

                    case Query.GetSalesItemReportWithOrderRange:
                    sRetval = "exec [dbo].[sp_GetSaleReportItemWise]{0},{1},'{2}', {3}";
                    break;

                    #region Order Waiter
                            
                    case Query.InsertWaiterOrder:
                    sRetval = "insert into order_waiter (waiterID, waiterName, orderID) values({0}, '{1}', {2})";
                    break;

                    case Query.UpdateWaiterOrder:
                    sRetval = " update order_waiter set waiterID={0}, waiterName ='{1}' where orderID={2}";
                    break;

                    case Query.DeleteWaiterOrderbyOrderID:
                    sRetval = "delete from order_waiter  where orderID={0}";
                    break;
                   
                       case Query.GetAllWaiterOrder:
                    sRetval = "select * from order_waiter ";
                    break;

                        case Query.GetWaiterOrderByOrderID:
                    sRetval = "select * from order_waiter  where orderID={0}";
                    break;

                    #endregion


                    case Query.UpdateOrderDetailsPricebyPLUProductTablePrice:
                    sRetval = "update order_details set itemUnitPrice = (select table_price from category3  where product3_plu = {0}) "  +
                              " where order_id = {1} and  product_id =(select cat3_id from category3  where product3_plu = {2}) ";
                    break;

                    case Query.UpdateOrderDetailsPricebyPLUProductTakeAwayPrice:
                    sRetval = "update order_details set itemUnitPrice = (select tw_price from category3  where product3_plu = {0}) " +
                              " where order_id = {1} and  product_id =(select cat3_id from category3  where product3_plu = {2}) ";
                    break;

                    case Query.UpdateOrderDetailsPricebyPLUProductBarPrice:
                    sRetval = "update order_details set itemUnitPrice = (select bar_price from category3  where product3_plu = {0}) " +
                              " where order_id = {1} and  product_id =(select cat3_id from category3  where product3_plu = {2}) ";
                    break;


                    case Query.ViewParentCategory:
                    sRetval = "SELECT parent_cat_id, parent_cat_name as Parent_Category_Name,'UPDATE' as up,'DELETE' as del  FROM parent_category ";
                    break;


                    case Query.CheckDupCat3:
                    sRetval = "SELECT cat3_id  FROM category3 where cat3_name = '{0}' and cat2_id = {1};";
                    break;

                    case Query.GetMaxCat3Order:
                    sRetval = "SELECT IsNull(max(cat3_order),0) as max_cat3_order FROM category3 ";
                    break;

                    case Query.AddCategory3:
                    sRetval = " insert into category3 (cat3_name,cat2_id,description,table_price,tw_price,bar_price,status,cat3_order,view_table,view_bar,view_takeaway,cat3_rank,user_id,datetime,food_item_stock_quantity,unlimited_status," +
                       " [RetailPrice] ,[WholeSalePrice]  ,[LastPurchasePrice] ,[UnitsInStock] ,[ReorderLevel]  ,[QTYPerSaleUint]  ,[QTYPerPurchaseUnit] ,[StandardUoM] ,[SalesUoM] ,[PurchaseUoM] ,[NonTaxableGood] ,[NonStockable]  ,[SupplierID], Barcode, selling_in, vat_included,  productType) " +
                       " values" +
                       "('{0}',{1},'{2}', {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11},'{12}',{13},{14},{15}, {16}, {17},{18},{19},{20},{21},{22},'{23}','{24}','{25}',{26},{27},{28},'{29}','{30}', {31}, '{32}') ;";
                    break;

                    case Query.GetCategory3ByCategory2ID:
                    sRetval = " select *from category3  where  cat2_id = {0}  ";
                    break;

                    case Query.ViewCategory1:
                    sRetval = "SELECT a.cat1_id, a.cat1_name as Category1_Name,  b.parent_cat_name as Parent_Category_Name,a.Cat1_order_number,'UPDATE' as up,'DELETE' as del FROM category1 a, parent_category b where a.parent_cat_id = b.parent_cat_id  order by a.Cat1_order_number  asc";
                    break;

                    case Query.ViewCat1ComboBox:
                    sRetval = "SELECT a.cat1_id, a.cat1_name   FROM category1 a, parent_category b where a.parent_cat_id = b.parent_cat_id  and b.parent_cat_id = {0} order by a.cat1_name asc ;";
                    break;

                    case Query.GetFinishedRawProductListByProductID:
                    sRetval = " select * from finishedRawProductList where finishedProductID ={0}";
                    break;

                    case Query.GetFinishedRawProductListByFinishedProductIDandRawProductID:
                    sRetval = " select * from finishedRawProductList where  finishedProductID = {0} and rawProductID = {1}";
                    break;

                    case Query.GetAllUnit:
                    sRetval = "select id, name, 'EDIT' as edit, 'DELETE' as del from unit order by id DESC";
                    break;

                    case Query.FinishedRawProductListUpdate:
                    sRetval = " update finishedRawProductList set finishedProductID = {0},  rawProductID = {1}, rawProductName = '{2}', qnty = {3}, remarks = '{4}' where ID = {5} ";
                    break;

                    case Query.FinishedRawProductListDelete:
                    sRetval = " delete from finishedRawProductList where ID = {0} ";
                    break;

                    case Query.ViewCategory1ByParentCat:
                    sRetval = "SELECT a.cat1_id, a.cat1_name as Category1_Name, b.parent_cat_name as Parent_Category_Name,a.Cat1_order_number,'UPDATE' as up,'DELETE' as del  FROM category1 a, parent_category b where a.parent_cat_id = b.parent_cat_id and a.parent_cat_id = {0}  order by a.Cat1_order_number  asc;";
                    break;

                    case Query.FinishedRawProductListInsert:
                    sRetval = " insert into finishedRawProductList values ({0}, {1}, '{2}', {3}, '{4}' )";
                    break;

                    case Query.ViewCategory3ByCat2GridAll:
                  //  sRetval = "SELECT a.cat3_id, a.cat3_name as Category3_Name, a.Barcode as BarCode, CAST( a.RetailPrice*(select (1+ (vat_amount*vat_included)/100) from general_settings) AS dec(12,2)) as RetailPrice,  a.UnitsInStock as UnitsInStock,  a.cat3_order as Category3_Order, b.cat2_name as Category2_Name, c.cat1_name as Category1_Name, d.parent_cat_name as Parent_Category_Name, a.description, a.ReorderLevel, 'ADD STOCK' as addStock, 'Reconcile' as Reconcile, 'Setting' as up,'DELETE' as del  FROM category3 a, category2 b, category1 c, parent_category d  where a.cat2_id = b.cat2_id  and b.cat1_id = c.cat1_id and c.parent_cat_id = d.parent_cat_id  order by a.cat3_order asc";
                   sRetval = "SET DateFormat MDY;SELECT a.cat3_id, a.cat3_name as Category3_Name, a.Barcode as BarCode, CAST( a.RetailPrice*(select (1+ (vat_amount*vat_included)/100) from general_settings) AS dec(12,2)) as RetailPrice,  a.UnitsInStock as UnitsInStock,  a.cat3_order as Category3_Order, b.cat2_name as Category2_Name, c.cat1_name as Category1_Name, d.parent_cat_name as Parent_Category_Name, a.description, a.ReorderLevel, 'ADD STOCK' as addStock, 'Reconcile' as Reconcile, 'Setting' as up,'DELETE' as del,a.uom as Unit,a.productType as ProductType FROM category3 a, category2 b, category1 c, parent_category d  where a.cat2_id = b.cat2_id  and b.cat1_id = c.cat1_id and c.parent_cat_id = d.parent_cat_id  order by a.cat3_order asc";
                   // sRetval = "SET DateFormat MDY;SELECT a.cat3_id, a.cat3_name as Category3_Name, a.Barcode as BarCode, CAST( a.RetailPrice*(select (1+ (vat_amount*vat_included)/100) from general_settings) AS dec(12,2)) as RetailPrice,  a.UnitsInStock as UnitsInStock,a.uom as Unit,a.productType as ProductType, a.cat3_order as Category3_Order, b.cat2_name as Category2_Name, c.cat1_name as Category1_Name, d.parent_cat_name as Parent_Category_Name, a.description, a.ReorderLevel, 'ADD STOCK' as addStock, 'Reconcile' as Reconcile, 'Setting' as up,'DELETE' as del FROM category3 a, category2 b, category1 c, parent_category d  where a.cat2_id = b.cat2_id  and b.cat1_id = c.cat1_id and c.parent_cat_id = d.parent_cat_id  order by a.cat3_order asc";
                    break;

                    case Query.ViewCategory2ByCat1ComboBox:
                    sRetval = "SELECT a.cat2_id, a.cat2_name FROM category2 a, category1 b where  a.cat1_id = b.cat1_id and b.cat1_id = {0} order by a.cat2_name asc";
                    break;

                    case Query.ViewCategory3ByCat2Grid:
                   // sRetval = "SELECT a.cat3_id, a.cat3_name as Category3_Name, a.Barcode as BarCode,  CAST( a.RetailPrice*(select (1+ (vat_amount*vat_included)/100) from general_settings) AS dec(12,2)) as RetailPrice, a.UnitsInStock as UnitsInStock,  a.cat3_order as Category3_Order, b.cat2_name as Category2_Name, c.cat1_name as Category1_Name, d.parent_cat_name as Parent_Category_Name, a.description, a.ReorderLevel, 'ADD STOCK' as addStock, 'RECONCILE' as Reconcile, 'Setting' as up,'DELETE' as del  FROM category3 a, category2 b, category1 c, parent_category d  where a.cat2_id = b.cat2_id  and b.cat1_id = c.cat1_id and c.parent_cat_id = d.parent_cat_id and a.cat2_id = {0} order by a.cat3_order asc";

                    sRetval = "SET DateFormat MDY;SELECT a.cat3_id, a.cat3_name as Category3_Name, a.Barcode as BarCode,  CAST( a.RetailPrice*(select (1+ (vat_amount*vat_included)/100) from general_settings) AS dec(12,2)) as RetailPrice, a.UnitsInStock as UnitsInStock,  a.cat3_order as Category3_Order, b.cat2_name as Category2_Name, c.cat1_name as Category1_Name, d.parent_cat_name as Parent_Category_Name, a.description, a.ReorderLevel, 'ADD STOCK' as addStock, 'RECONCILE' as Reconcile, 'Setting' as up,'DELETE' as del,a.uom as Unit,a.productType  FROM category3 a, category2 b, category1 c, parent_category d  where a.cat2_id = b.cat2_id  and b.cat1_id = c.cat1_id and c.parent_cat_id = d.parent_cat_id and a.cat2_id = {0} order by a.cat3_order asc";
                    break;

                    case Query.ViewCategory3ByCat2AndOutofReorderGridAll:
                    sRetval = "SELECT a.cat3_id, a.cat3_name as Category3_Name, a.Barcode as BarCode, CAST( a.RetailPrice*(select (1+ (vat_amount*vat_included)/100) from general_settings) AS dec(12,2)) as RetailPrice,  a.UnitsInStock as UnitsInStock,  a.cat3_order as Category3_Order, b.cat2_name as Category2_Name, c.cat1_name as Category1_Name, d.parent_cat_name as Parent_Category_Name, a.description, a.ReorderLevel, 'ADD STOCK' as addStock, 'Reconcile' as Reconcile, 'Setting' as up,'DELETE' as del  FROM category3 a, category2 b, category1 c, parent_category d  where a.cat2_id = b.cat2_id  and b.cat1_id = c.cat1_id and c.parent_cat_id = d.parent_cat_id and a.UnitsInStock <= a.ReorderLevel  order by a.cat3_order asc";
                    break;
                    case Query.ViewCategory3ByCat2AndOutofStockGrid:
                    sRetval = "SELECT a.cat3_id, a.cat3_name as Category3_Name, a.Barcode as BarCode,  CAST( a.RetailPrice*(select (1+ (vat_amount*vat_included)/100) from general_settings) AS dec(12,2)) as RetailPrice, a.UnitsInStock as UnitsInStock,  a.cat3_order as Category3_Order, b.cat2_name as Category2_Name, c.cat1_name as Category1_Name, d.parent_cat_name as Parent_Category_Name, a.description, a.ReorderLevel, 'ADD STOCK' as addStock, 'RECONCILE' as Reconcile, 'Setting' as up,'DELETE' as del  FROM category3 a, category2 b, category1 c, parent_category d  where a.cat2_id = b.cat2_id  and b.cat1_id = c.cat1_id and c.parent_cat_id = d.parent_cat_id and a.cat2_id = {0} and a.UnitsInStock <= 0  order by a.cat3_order asc";
                    break;

                    case Query.ViewCategory3ByCat2AndOutofStockGridAll:
                    sRetval = "SELECT a.cat3_id, a.cat3_name as Category3_Name, a.Barcode as BarCode, CAST( a.RetailPrice*(select (1+ (vat_amount*vat_included)/100) from general_settings) AS dec(12,2)) as RetailPrice,  a.UnitsInStock as UnitsInStock,  a.cat3_order as Category3_Order, b.cat2_name as Category2_Name, c.cat1_name as Category1_Name, d.parent_cat_name as Parent_Category_Name, a.description, a.ReorderLevel, 'ADD STOCK' as addStock, 'Reconcile' as Reconcile, 'Setting' as up,'DELETE' as del  FROM category3 a, category2 b, category1 c, parent_category d  where a.cat2_id = b.cat2_id  and b.cat1_id = c.cat1_id and c.parent_cat_id = d.parent_cat_id and a.UnitsInStock <= 0  order by a.cat3_order asc";
                    break;

                    case Query.GetCategory2Order:
                    sRetval = "SELECT cat2_order FROM category2  where cat2_id = {0}   ";
                    break;

                    case Query.Category3UpdateStock:
                    sRetval = "update category3 set [UnitsInStock]=[UnitsInStock]-{0} where cat3_id={1}";
                    break;

                    case Query.UpdateCategory3Latest:
                    sRetval = " update  category3 set cat3_name='{0}',cat2_id={1},description='{2}',table_price={3},tw_price={4},bar_price={5},status={6}, cat3_order=cat3_order,view_table={8},view_bar={9},view_takeaway={10},cat3_rank={11},user_id='{12}',datetime={13},food_item_stock_quantity={14},unlimited_status={15}," +
                       " [RetailPrice]={16} ,[WholeSalePrice]={17} ,[LastPurchasePrice]= {18},[UnitsInStock]={19} ,[ReorderLevel] ={20} ,[QTYPerSaleUint]={21}  ,[QTYPerPurchaseUnit]={22} ,[StandardUoM]='{23}' ,[SalesUoM]='{24}' ,[PurchaseUoM]='{25}' ,[NonTaxableGood]={26} ,[NonStockable]={27}  ,[SupplierID]={28}, Barcode='{29}', selling_in='{30}' " +
                       " where cat3_id={31} ;";

                    //sRetval = " update  category3 set cat3_rank={0},user_id='{1}',datetime={2},food_item_stock_quantity={3},unlimited_status={4}," +
                    //  " selling_in='{6}',[UnitsInStock]={5}" +
                    //  " where cat3_id={7} ;";
                    break;

                case Query.InsertRawMatinStock:

                    sRetval = "insert into raw_mat_in_stock (cat3_id, cat2_id, cat3_name, description,datetime, uom, UnitsInStock,Date,AdditionalQty,PrevQty) values ({0},{1},'{2}','{3}',{4},'{5}', {6}, '{7}',{8}, {9})";

                    break;

                    case Query.UpdateCat3Rank:
                    sRetval = " update category3 set cat3_rank = {0},user_id='{2}',datetime={3}  where cat3_id = {1} ";
                    break;

                    case Query.UpdateCat4Rank:
                    sRetval = " update category4 set cat4_rank = {0},user_id='{2}',datetime={3}  where cat4_id = {1} ";
                    break;

                    case Query.GetChildCat4ByCat3:
                    sRetval = "SELECT a.cat4_id, a.cat4_order FROM category4 a where a.cat3_id = {0}   ";
                    break;

                    case Query.GetCat3OrderCandidate:
                    sRetval = "SELECT cat3_id  FROM category3 where cat2_id = {0} and cat3_order >= {1} order by cat3_order asc;";
                    break;

                      

                  
                    case Query.GetCat3OrderCandidateLower:
                    sRetval = "SELECT cat3_id  FROM category3 where cat2_id = {0}  and cat3_order >= {1} and cat3_order < {2} order by cat3_order asc;";
                    break;

                    case Query.UpdateCategory3Order:
                    sRetval = " update category3 set cat3_order = {0},user_id='{2}',datetime={3} where cat3_id = {1} ";
                    break;

                    case Query.UpdateCategory3:
                   sRetval = " update category3 set cat3_name = '{0}', cat2_id = {1} , description = '{2}', table_price = {3}, tw_price = {4}, bar_price = {5}, status = {6}, cat3_order = {7}, view_table = {8}, view_bar = {9}, view_takeaway = {10},user_id='{12}',datetime={13},food_item_stock_quantity={14} ,unlimited_status={15},selling_in='{16}' where cat3_id = {11} ";
                  // sRetval = " update category3 set cat3_name = '{0}', cat2_id = {1} , description = '{2}', status = {3}, cat3_order = {4}, view_table = {5}, view_bar = {6}, view_takeaway = {7},user_id='{8}',datetime={9},food_item_stock_quantity={10} ,unlimited_status={11},selling_in='{12}' where cat3_id = {13} ";
                    break;

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

                    case Query.GetAllPcInfoBy:
                    sRetval = "select *from pc_info ";
                    break;
                    // sRetval = " update category3 set cat3_order = {0},user_id='{2}',datetime={3} where cat3_id = {1} ";
                    case Query. UpdateOrderInfoDAOForDelivary:
                    sRetval = "update order_info set status='{1}' where order_id={0};";
                    break;

                    //InsertOrderForVoid
                    case Query.InsertOrderForVoid:
                    sRetval = "insert into order_void values ({0},{1},{2},{3},'{4}','{5}',{6},'{7}')";
                    break;
                    // " insert into finishedRawProductList values ({0}, {1}, '{2}', {3}, '{4}','{5}' )";

                    case Query.InsertItemForVoid:
                    sRetval = "insert into item_void values ({0},{1},{2},'{3}',{4},{5},'{6}','{7}')";
                    break;

                    case Query.GetAllOrderVoid:
                    sRetval = "select a.order_id, a.order_amount, a.order_date, a.void_date, a.table_number, a.reason,a.creator_id,a.remover_id, (select user_name  from user_info where user_id=a.creator_id) as creatorname , (select user_name  from user_info where user_id=a.remover_id) as removername from order_void a where (a.void_date>='{0}' and a.void_date<='{1}')";
                    break;

                    case Query.GetAllItemVoid:
                    sRetval = "select a.order_id, a.amount, a.time, a.item_quantity,a.item_name, a.reason,a.creator_id,a.remover_id, (select user_name  from user_info where user_id=a.creator_id) as creatorname , (select user_name  from user_info where user_id=a.remover_id) as removername from item_void a where (a.time>='{0}' and a.time<='{1}')";
                    break;



                    // start for reservation
                   #region  
                    case Query.Insertreservation:
                    sRetval = "insert into partyreservation (partydate, fromtime, totime,bookingarea) values ('{0}','{1}','{2}','{3}')";
                    break;

                    case Query.InsertMainGuestItemInformation:
                    sRetval = "insert into mainguestiteminformation values ('{0}',{1},{2},{3})";
                    break;

                    case Query.GetMainguestIteminformationByreservationId:
                    sRetval = "SELECT *  FROM mainguestiteminformation where reservationid = {0};";
                    break;

                    case Query.InsertotherGuestItemInformation:
                    sRetval = "insert into otherguestiteminformation values ('{0}',{1},{2},{3})";
                    break;

                    case Query.GetotherguestIteminformationByreservationId:
                    sRetval = "SELECT *  FROM otherguestiteminformation where reservationid = {0};";
                    break;

                    case Query.InsertUtilityItemInformation:
                    sRetval = "insert into ulilitycostinformation values ('{0}',{1},{2})";
                    break;

                    case Query.GetUtilityIteminformationByreservationId:
                    sRetval = "SELECT *  FROM ulilitycostinformation where reservationid = {0};";
                    break;

                    case Query.UpdatePartyReservation:
                    sRetval = "update partyreservation set bookingdate='{1}',loginperson='{2}',bookingarea='{3}', bookingtype='{4}', numberofguest={5}, numberofotherguest={6}, mainguestamount={7}, otherguestamount={8}, utilitycostamount={9}, totalpayableamount={10}, depositeamount={11}, dueamount={12}, specialinstruction='{13}', clientname='{14}', clientphone='{15}', clientemail='{16}',servicecharge={17},vat={18},discount={19},printpreview='{20}' where partyreservationid={0};";
                    break;

                    case Query.DeleteItemInfromationFormainGuest:
                    sRetval = " delete from mainguestiteminformation where itemid = {0} ";
                    break;

                    case Query.DeleteItemInfromationFormautilityCost:
                    sRetval = " delete from ulilitycostinformation where itemid = {0} ";
                    break;

                    case Query.DeleteItemInfromationForotherGuest:
                    sRetval = " delete from otherguestiteminformation where itemid = {0} ";
                    break;

                    case Query.CheckAvabilityByDateAndArea:
                    sRetval = "SELECT *  FROM partyreservation where partydate= '{0}' AND bookingarea='{1}';";
                    break;

                    case Query.GetReservationServiceCharge:
                    sRetval = "select svc_charge, svc_chargeRate from resevation_service_charge  where reservationid={0}";
                    break;


                    case Query.InsertReservationServiceCharge:
                    sRetval = "insert into resevation_service_charge (reservationid, svc_charge, svc_chargeRate) values({0},{1},{2})";
                    break;

                    case Query.UpdateReservationServiceCharge:
                    sRetval = " update resevation_service_charge set svc_charge={0}, svc_chargeRate={1} where reservationid={2}";
                    break;

                    case Query.GetReservationDiscount:
                    sRetval = "select discount, discountPercent from reservation_discount  where reservationid={0}";
                    break;


                    case Query.InsertReservationDiscount:
                    sRetval = "insert into reservation_discount (reservationid, discount, discountPercent) values({0},{1},{2})";
                    break;

                    case Query.UpdateReservationDiscount:
                    sRetval = " update reservation_discount set discount={0}, discountPercent={1} where reservationid={2}";
                    break;

                case Query.GetReservationReportByDateToDate:
                        sRetval = "select * " +
                          "from PrintPreview" +
                          " where partydate >= '{0}' AND partydate <= '{1}' ";
                    break;

                   #endregion
                    // // end for reservation

                    // banktransaction
                   #region

                case Query.InsertDebitTransaction:
                    sRetval = "insert into  debittransaction (bankname, branchname, accountnumber,debitdate,person,amount) values('{0}', '{1}', '{2}','{3}', '{4}', {5});";
                    break;

                case Query.InsertCreditTransaction:
                    sRetval = "insert into  credittransaction (bankname, branchname, accountnumber,creditdate,person,amount) values('{0}', '{1}', '{2}','{3}', '{4}', {5});";
                    break;
                case Query.InsertotherCreditTransaction:
                    sRetval = "insert into  otherdebittransaction (bankname, branchname, accountnumber,otherdebitdate,person,amount) values('{0}', '{1}', '{2}','{3}', '{4}', {5});";
                    break;

                case Query.GetDebitreportBydate:
                    sRetval = "select * from debittransaction where debitdate>='{0}' AND debitdate <='{1}'  ORDER BY debitdate ASC;";
                    break;
                case Query.GetAllDebitAmountByDate:
                    sRetval = "select * from dbo.View_Bank_Transaction where Transaction_Date>='{0}' AND Transaction_Date <='{1}'  ORDER BY Transaction_Date ASC;";
                    break;

                case Query.GetCreditreportBydate:
                    sRetval = "select * from credittransaction where creditdate >='{0}' AND creditdate <='{1}'  ORDER BY creditdate ASC;";
                    break;
                case Query.GetAllCreditAmountByDate:
                    sRetval = "select * from dbo.View_Bank_Transaction where Transaction_Date>='{0}' AND Transaction_Date <='{1}'  ORDER BY Transaction_Date ASC;";
                    break;

                case Query.GetotherDebitreportBydate:
                    sRetval = "select * from otherdebittransaction where otherdebitdate>='{0}' AND otherdebitdate<='{1}'  ORDER BY otherdebitdate ASC;";
                    break;
                case Query.GetAllotherDebitAmountByDate:
                    sRetval = "select * from dbo.View_Bank_Transaction where Transaction_Date>='{0}' AND Transaction_Date <='{1}'  ORDER BY Transaction_Date ASC;";
                    break;

                case Query.GetBalanceReport:
                    sRetval = "select Transaction_Date, Credit_Amount,Debit_Amount,Other_DEBIT,Balance,Cash_Amount,Cash_Balance from dbo.View_Bank_Transaction where Transaction_Date>='{0}' AND Transaction_Date<='{1}' ORDER BY Transaction_Date ASC;";
                    break;

                case Query.GetNowBankbalance:
                    sRetval = "select SUM(Balance)as balanceamount,SUM(Credit_Amount)as creditamount,SUM(Debit_Amount)as debitamount, SUM(Other_DEBIT)as otherdebitamount,SUM(Cash_Balance)as cashamount  from dbo.View_Bank_Transaction where Transaction_Date<='{0}';";
                    break;

                //new
                case Query.InsertCashTransaction:
                    sRetval = "insert into  cashtransaction (source,cashdate,person,amount) values('{0}', '{1}', '{2}', {3});";
                    break;

                case Query.GetCashreportBydate:
                    sRetval = "select * from cashtransaction where cashdate >='{0}' AND cashdate <='{1}'  ORDER BY cashdate ASC;";
                    break;

                case Query.GetAllCashAmountByDate:
                    sRetval = "select * from dbo.View_Bank_Transaction where Transaction_Date>='{0}' AND Transaction_Date <='{1}' ORDER BY Transaction_Date ASC ;";
                    break;

                   #endregion



                #region MembershipCardNo

                case Query.AddMembershipCardNo:
                    sRetval = "insert into MembershipCardNo (code, cardId, isActive) Values('{0}', {1}, '{2}')";
                    break;

                case Query.UpdateMembershipCardNo:
                    sRetval = "update  MembershipCardNo set code = '{0}', cardId = {1}, isActive = '{2}'  where id={3}";
                    break;

                case Query.DeleteMembershipCardNo:
                    sRetval = "delete  MembershipCardNo where id={0}";
                    break;

                case Query.GetAllMembershipCardNo:
                    sRetval = "Select * from MembershipCardNo";
                    break;

                case Query.GetMembershipCardNoByID:
                    sRetval = "Select * from MembershipCardNo where id={0}";
                    break;

                #endregion


                #region Membership

                case Query.AddMembership:
                    sRetval = "insert into Membership (customerID, customerName, customerPhone, membershipCardType, mebershipCardID, membershipCardName, membershipCardTitle, point, discountPercentRate, startDate, endDate, issueDate, isActvie, membershipCardCode ) " +
                                              " Values(    {0},       '{1}',        '{2}',            '{3}',             {4} ,             '{5}' ,            '{6}'   ,        {7}   ,      {8},           '{9}' ,   '{10}',  '{11}',      '{12}',   '{13}' )";
                    break;

                case Query.UpdateMembership:
                    sRetval = "update  Membership set customerID  = {0}, customerName  = '{1}', customerPhone  = '{2}', membershipCardType = '{3}', mebershipCardID  = {4}, membershipCardName  = '{5}', membershipCardTitle  = '{6}', point  = {7}, " +
                                                      " discountPercentRate  = {8}, startDate  = '{9}', endDate  = '{10}', issueDate  = '{11}' ,isActvie  = '{12}'  where id = {13}";
                    break;

                case Query.DeleteMembership:
                    sRetval = "delete  Membership where id={0}";
                    break;

                case Query.GetAllMembership:
                    sRetval = "Select * from Membership";
                    break;

                case Query.GetMembershipByID:
                    sRetval = "Select * from Membership where id={0}";
                    break;

                case Query.GetMembershipByCustomerID:
                    sRetval = "Select * from Membership where customerID={0} and isActvie = 'True'";
                    break;

                case Query.GetMembershipBymembershipCardName:
                    sRetval = "Select * from Membership where membershipCardName like '{0}' and isActvie = 'True'";
                    break;

                case Query.GetMembershipByCustomerPhone:
                    sRetval = "Select * from Membership where customerPhone='{0}'and isActvie = 'True'";
                    break;

                case Query.GetMembershipBymembershipCode:
                    sRetval = "Select * from Membership where membershipCardCode='{0}' and isActvie = 'True'";
                    break;

                #endregion


                #region MembershipCard

                case Query.AddMembershipCard:
                    sRetval = "insert into MembershipCard ( code, title, description, name, points, discountPercent, type, startDate, endDate, isActive, creationDate) Values('{0}', '{1}', '{2}', '{3}', {4}, {5}, '{6}', '{7}', '{8}', '{9}', '{10}' )";
                    break;

                case Query.UpdateMembershipCard:
                    sRetval = "update  MembershipCard set code= '{0}', title= '{1}', description= '{2}', name= '{3}', points= {4}, discountPercent= {5}, type= '{6}', startDate= '{7}', endDate= '{8}', isActive = '{9}', creationDate ='{10}'  where id = {11}";
                    break;

                case Query.DeleteMembershipCard:
                    sRetval = "delete  MembershipCard where id={0}";
                    break;

                case Query.GetAllMembershipCard:
                    sRetval = "Select * from MembershipCard";
                    break;

                case Query.GetMembershipCardByID:
                    sRetval = "Select * from MembershipCard where id={0}";
                    break;

                case Query.GetAllMembershipCardByName:
                    sRetval = "Select * from MembershipCard where name like '{0}'";
                    break;

                case Query.GetAllMembershipCardByCode:
                    sRetval = "Select * from MembershipCard where code like '{0}'";
                    break;

                #endregion


                case Query.UpdateItemWiseDiscount:
                    sRetval = "update  order_details set item_discount= {1}  where order_detail_id = {0}";
                    break;


                case Query.GetCategoryWiseSales:
                    sRetval = "exec [dbo].[sp_GetSaleReportCategoryWise]{0},{1}";
                    break;

                case Query.UpdateOrderComplementory:
                    sRetval = "update  order_info set complementory= '{1}'  where order_id = {0}";
                    break;


                case Query.UpdateOrderDetailsComplementory:
                    sRetval = "update  order_details set amount= {1}, amount_with_vat={1},vatTotal={1}  where order_id = {0}";
                    break;

                case Query.UpdateOrderDetailsItemComplementory:
                    sRetval = "update  order_details set amount= {1}, amount_with_vat={1},vatTotal={1}  where order_detail_id = {0}";
                    break;

                case Query.UpdateOrderVatComplementory:
                    sRetval = "update  order_info set vatComplementory= '{1}'  where order_id = {0}";
                    break;


                case Query.UpdateOrderDetailsVatComplementory:
                    sRetval = "update  order_details set  amount_with_vat=amount,vatTotal={1}  where order_id = {0}";
                    break;

                case Query.GetMembershipDiscountReport:
                    sRetval = "exec [dbo].[sp_GetMembership_ViewReport]";
                    break;

                case Query.LoadMemberDetailsReport:
                    sRetval = "Select * from ViewMembershipReport where id={0}";
                    break;


                #region   update guest quantity

                case Query.UpdateGuestQuantity: // add for keep track guest bill print 
                    sRetval = " update order_details set guest_print_qnty={2} where order_id = {0} and product_id={1} ";
                    break;
                #endregion


                case Query.GetCategory1IdByParentId:
                    sRetval = "select cat1_id,cat1_name from category1 where parent_cat_id={0}";
                    break;


                // add for inventory System
                case Query.GetAllCategory:
                    sRetval = "select * from inventory_category";
                    break;

                case Query.GetItemByCategory:
                    sRetval = "select * from inventory_item where IC_id={0};";
                    break;
                case Query.GetStockByItemidFrominventory_kitchen_stock:
                    sRetval = "select * from inventory_kitchen_stock where item_id={0};";
                    break;

                case Query.UpdateStock:
                    sRetval = "update inventory_kitchen_stock set stock=stock-{1} where item_id={0};";
                    break;

                case Query.UpdateRawMaterialsByRawProductID: // Add for raw materials update
                    sRetval = "update inventory_kitchen_stock set stock=stock+{1} where item_id={0};";
                    break;

                case Query.ExitOrNot:
                    sRetval = "select * from sale_report where item_id={0} and date='{1}';";
                    break;

                case Query.InsertSalereport:
                    sRetval = "insert into sale_report (item_id,item_qty,sale_price,date) values({0},{1},{2},'{3}');";
                    break;

                case Query.UpdateSalereport:
                    sRetval = "update sale_report set  item_qty=item_qty+{0},sale_price=sale_price+{1} where sale_id={2};";
                    break;

                case Query.ViewCategory2ByCat1ComboBox1:
                    sRetval = "select cat2_id, cat2_name FROM category2 where cat1_id={0}";
                    break;

                case Query.UpdateKitchenQuantity: // Add for update kitchen_quantity from order_details tb.
                    sRetval = "update order_details set [kitchen_quantity]=[kitchen_quantity]+{2} where order_id={0} and product_id={1}";
                    break;


                case Query.UpdatePaymentForDueBill:
                    sRetval = "update payment set  cash_amount=cash_amount+{1},EFT_amount=EFT_amount+{2},cheque_amount={3} where order_id={0};";
                    break;

                case Query.UpdateTotalDueBillPayment:
                    sRetval = "update dueBillPayment set  cashamount=cashamount+{1},cardamount=cardamount+{2} where billId={0};";
                    break;

                case Query.InsertTotalDueBillPayment:
                    sRetval = "insert into dueBillPayment values ({0},{1},'{3}');";
                    break;

                case Query.CheckExistsDueBill:
                    sRetval = "select * from dueBillPayment where paymentdate='{0}';";
                    break;

                case Query.GetTotalDuePayment:
                    sRetval = "select * from dueBillPayment where paymentdate>='{0}' AND paymentdate <='{1}';";
                    break;



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
        UserInfoGetAll = 4,
        UserInfoByUsername=5,
        OrderShowByStatus = 6,
        OrderInfoInsert=7,
        OrderInfoUpdate=8,
        OrderInfoDelete=9,
        ButtonAccessInsert=10,
        ButtonAccessUpdate=11,
        ButtonAccessDelete=12,
        ButtonAccessGetAll=13,
        ButtonColorInsert=14,
        ButtonColorUpdate=15,
        ButtonColorDelete=16,
        ButtonColorGetAll=17,
        ParentCategoryInsert=18,
        ParentCategoryUpdate=19,
        ParentCategoryDelete=20,
        ParentCategoryGetAll=21,
        Category1Insert=22,
        Category1Update=23,
        Category1Delete=24,
        Category1GetAll=25,
        Category2Insert = 26,
        Category2Update = 27,
        Category2Delete = 28,
        Category2GetAll = 29,
        Category3Insert = 30,
        Category3Update = 31,
        Category3Delete = 32,
        Category3GetAll = 33,
        Category4GetAll = 34,
        OrderDetailsInsert=35,
        OrderDetailsUpdate=36,
        OrderDetailsDelete=37,
        OrderDetailsGetAll=38,
        ScopeIdentity=39,
        OrderDetailsGetByOrderId=40,
        OrderDetailsGetByOrderDetailID=41,
        OrderInfoGetByOrderID=42,
        UpdateTableInfo=43,
        UpdateDBForUnlock=44,
        ShowAvailableTableForTransfer=45,
        InsertTableInfo=46,
        TableInfoGetAll=47,
        TableInfoGetByTableNumber=48,
        PaymentInsert=49,
        PaymentUpdate=50,
        PaymentDelete=51,
        PayementGetByOrderID=52,
        LoginUser=53,
        CustomerInsert=54,
        CustomerUpdate=55,
        CustomerDelete=56,
        CustomerInfoGetByCustomerID=57,
        CustomerInfoGetByPhone = 58,
        GetTableNumberList=59,
        OrderSeatTimeInsert=60,
        PaymentSummaryGetTotal = 61,
        PaymentSummaryGetFoodTypeTotal = 62,
        PaymentSummaryGetNonFoodTypeTotal = 63,
        OrderListForTransfer = 65,
        ShowAvailableTableForUnlock = 67,
        ShowAvailableTableForVoid = 68,
        UpdateDBForTransfer = 69,
        InsertDBForTransfer = 70,
        UpdateDBForVoid = 72,
        DeleteDBForMerge = 74,
        UpdateDBForMerge = 75,
        OrderShowByStatusNDate = 76,
        OrderShowForViewReport = 77,
        ButtonColorByButtonName=78,
        PcInfoByPcIP=79,
        OrderSeatTimeByOrderID=80,
        PaymentGetTypeTotal = 81,
        UpdateDBForVoidReport = 82,
        OrderInfoArchieveInsert = 83,
        OrderDetailsArchieveInsert = 84,
        DeleteOrderByID = 85,
        DeleteTableInfo=86,
        OrderListForMerge = 87,
        CheckCurrentUser = 88,
        DeleteCurrentUser = 89,
        AddCurrentUser = 90,
        GetUserAccess=91,
        GetOrderIDFromBillPrintTime=92,
        InsertBillPrintTime=93,
        UpdateBillPrintTime=94,
        PaymentSummaryGetTotalByPC = 95,
        PaymentGetTypeTotalByPC = 96, 
        OrderShowForViewReportByPC = 97,
        GetSortedPayment = 98,
        OrderShowForViewReportByRef = 99,
        OrderShowForViewReportByTable = 100,
        OrderShowForViewReportByPrice = 101,
        OrderShowForViewReportByRefNTable = 102,
        OrderShowForViewReportByRefNPrice = 103,
        OrderShowForViewReportByTableNPrice = 104,
        OrderShowForViewReportByAll = 105,
        CustomerInfoGetAll=106,
        OrderSerialInsert=107,
        DeleteOrderSerial=108,
        GetOrderSerial=109,
        CustomerInfoGetByName=110,
        CustomerInfoGetByNameNPhone=111,
        BookingInfoGetAll = 112,
        BookingInfoInsert = 113,
        BookingInfoDelete = 114,
        BookingInfoGetByID = 115,
        BookingInfoUpdate = 116,
        PaymentSummaryGetTotalByOrderType = 117,
        PaymentGetTypeTotalByOrderType = 118,
        OrderDetailsArchiveGetByOrderId = 119,
        orderInfoArchiveByOrderID = 120,
        DepositInsert=121,
        DepositGetByDepositID=122,
        DepositUpdate=123,
        InsertDelivery=124,
        GetRecentOrderByCustomerID=125,
        GetPrintStyles=126,
        InsertDepositUsed=127,
        CheckDupUser = 128,//New Added from Here
        AddUser = 129,
        GetButtonIDByName = 130,
        AddButtonAccess = 131,
        CheckDupUserForUpdate = 132,
        UpdateUser = 133,
        DeleteAllButtonAccess = 134,
        DeleteUser = 135,
        getUserByID = 136,
        OrderDiscountInsert=137,
        OrderDiscountUpdate=138,
        OrderDiscountGetByOrderID=139,
        GetDepositsByDate = 140,//New Added
        GetDepositSummary = 141,
        DepositGetByCustomerID=142,
        OrderVoucherInsert=143,
        LogRegisterForOrders=144,
        LogRegisterForPayment=145,
        SaveDrawerOpening=146,
        DrawerLogdetails=147,
        GetCustomerAddressDetails=148,
        DeleteDefaultTime=149,
        SaveDefaultTime=150,
        GetCustomersByName=151,
        GetCustomerAddressWithoutHouseNumber=152,
        GetOnlineOrders=153,
        OnlineOrderDetailsByOrderID=154,
        DeleteOnlineOrders=155,
        UpdateOnlineOrdersDetails=156,
        DeleteOnlineOrder=157,
        AddNewOnlineOrderedItem=158,
        AddNewLocalProducts=159,
        GetKitchenTextByID=160,
        SaveKitchenText=161,
        UpdateKitchenText=162,
        GetAllKitchenText=163,
        DeleteKitchenText=164,
        InsertOnlineOrderDetails=165,
        GetdeliveryTime=166,
        TakeawayCustomerInfo=167,
        UpdateDeliveryInfo=168,
        UpdateTakwawayOrderStatus=169,
        SelectOnlineOrderDetailsDetailsByIDFromOrderTable=170,
        SelectOnlineOrderDetailsDetailsByIDFromOnlineOrderTable = 171,
        GetOnlineItemOrderMaxNumber=172,
        GetOnlineOrderPrintStatus=173,
        ChangeOnlineOrderPrintStatus=174,
        UpdatePrintedQuantity=175,
        GetOnlineOrderedItemsById=176,
        InsertOnlineOrderedItemsArchive=177,
        UpdateOnlineOrderPrintedQuantity=178,
        DeleteOnlineItem=179,

        InsertServiceCharge=180,
        UpdateServiceCharge=181,
        GetServiceCharge=182,
        UpdateOnlineItemSpecial=183,
        UpdateLocalVoidItems = 184,
        
        SaveOrderKitchenText=185,
        ModifyOrderkitchenTextStatus=186,
        GetOrderPreviousKtText=187,

        GetMergeItems=188,
        SaveMergeItems=189,
        DeleteMergeItems=190,

        GetSpecialModifyText=191,
        SaveSpecialModifyTex=192,
        UpdateSpecialModifyTex=193,
        DeleteSpecialModifyTex=194,

        CollectProduct3ByPLU=195,
        CollectProduct4ByPLU=196,


        UpdateOnlineVoidItems=197,
        DeleteOnlineVoidItems = 198,
        DeleteLocalOrderVoidID=199,

        GetOrderLogInformation=200,
        ChangeGuestBillPrintStatus=201,
        GetOnlineOrderLogInformation = 202,

        VoidOnlineItems=203,

        CurrentWaitingNumber=204,
        SaveWaitingInfo=205,
        CurrentCollectionNumber=206,
        SaveCollectionInfo=207,
        GetSalesRecords = 208, 
        GetInventorySalesRecords=209,


        GetGeneralSetting=210,
        UpdateGenerallSettings=211,

        GetOrderInfo = 212,
        GetArchiveItemDetails = 213,

        InsertEftCard=214,
        GetEftCatds=215,
        UpdateEftCard=216,
        DeleteEftCard=217,

        AddEFTPayment=218,
        UpdateEFTpaymentByOrderID=219,
        CountEFTpaymentForparticularOrderid = 220,


        PaymentUpdateOnlyVatStat=221,

        GetSalesItemReportWithOrderRange=222,


        InsertWaiterOrder=223,
        UpdateWaiterOrder = 224,
        DeleteWaiterOrderbyOrderID = 225,
        GetAllWaiterOrder = 226,
        GetWaiterOrderByOrderID = 227,

        UpdateOrderDetailsPricebyPLUProductTablePrice = 228,
        UpdateOrderDetailsPricebyPLUProductTakeAwayPrice = 229,
        GetCategory3ByCategory3ID = 259,
        ViewParentCategory = 260,
        ViewCategory1 = 261,
        ViewCategory1ByParentCat = 262,
        ViewCategory3ByCat2GridAll = 263,
        ViewCategory3ByCat2Grid = 264,
        ViewCategory2ByCat1ComboBox = 265,
        ViewCat1ComboBox = 266,
        CheckDupCat3 = 268,
        GetMaxCat3Order = 269,
        AddCategory3 = 270,
        
        

        GetAllUnit = 271,
        FinishedRawProductListInsert = 272,
        FinishedRawProductListUpdate = 273,
        FinishedRawProductListDelete = 274,
        GetFinishedRawProductListByProductID = 275,
        GetFinishedRawProductListByFinishedProductIDandRawProductID = 279,
        UpdateCategory3Latest = 302,
        GetCategory2Order = 305,
        UpdateCat3Rank = 306,
        UpdateCat4Rank = 307,
        GetChildCat4ByCat3 = 308,
        GetCat3OrderCandidate = 309,
        GetCat3OrderCandidateLower = 310,
        UpdateCategory3Order = 311,
        UpdateCategory3 = 312,
        Category3UpdateStock = 313,
        GetCategory3ByCategory2ID = 314,
        ViewCategory3ByCat2AndOutofReorderGridAll = 316,
        ViewCategory3ByCat2AndOutofStockGrid = 319,
        ViewCategory3ByCat2AndOutofStockGridAll = 320,

        AddShiftSchedule = 326,
        GetAllShiftScheduleByShiftID = 327,

        GetAllShiftSCheduleByCreationDate = 328,
        UpdateOrderDetailsPricebyPLUProductBarPrice = 330,


        GetAllPcInfoBy = 331,
        LastPLUOrderDetails=332,
        AddShiftOrderInfo = 333,
        UpdateShiftOrderInfo = 334,
        DeleteShiftOrderInfo = 335,
        GetAllShiftOrderInfoByPaymentcreationDate = 336,
        GetAllShiftOrderInfoID = 337,
        GetAllShiftOrderInfo = 338,
        DeleteShiftSchedule = 339,
        GetAllShiftScheduleID = 340,
        GetAllShiftSchedule = 341,
        UpdateShiftSchedule = 342,
        GetInventorySalesRecordsInv = 343,
        GetCategory4Anchestor = 348,
        GetCategory3Anchestor = 349,
        GetCategory2Anchestor = 350,
        GetCategory1Anchestor = 351,
        GetInventorySalesRecordsInv1 = 352,
        InsertRawMatinStock = 353,
        GetRawMat = 354,
        UpdateOrderInfoDAOForDelivary=355,
        InsertOrderForVoid=356,
        InsertItemForVoid=357,
        GetAllOrderVoid=358,
        GetAllItemVoid=359,
        Insertreservation=360,
        InsertMainGuestItemInformation=361,
        GetMainguestIteminformationByreservationId=362,
        InsertotherGuestItemInformation=363,
        GetotherguestIteminformationByreservationId=364,
        InsertUtilityItemInformation=365,
        GetUtilityIteminformationByreservationId=366,
        UpdatePartyReservation=367,
        DeleteItemInfromationFormainGuest=368,
        DeleteItemInfromationFormautilityCost=369,
        DeleteItemInfromationForotherGuest=370,
        CheckAvabilityByDateAndArea=371,
        GetReservationServiceCharge=372,
        UpdateReservationServiceCharge=373,
        InsertReservationServiceCharge=374,
        GetReservationDiscount=375,
        UpdateReservationDiscount=376,
        InsertReservationDiscount=377,
        GetReservationReportByDateToDate=378,



        InsertDebitTransaction = 379,
        InsertCreditTransaction = 380,
        InsertotherCreditTransaction = 381,
        GetDebitreportBydate = 382,
        GetAllDebitAmountByDate = 383,
        GetCreditreportBydate = 384,
        GetAllCreditAmountByDate = 385,
        GetotherDebitreportBydate = 386,
        GetAllotherDebitAmountByDate = 387,
        GetBalanceReport = 388,
        GetNowBankbalance = 389,

        // new
        InsertCashTransaction = 390,
        GetCashreportBydate = 391,
        GetAllCashAmountByDate = 392,


         /////////////////////////////
        AddMembershipCardNo = 393,
        UpdateMembershipCardNo = 394,
        DeleteMembershipCardNo = 395,
        GetAllMembershipCardNo = 396,
        GetMembershipCardNoByID = 397,

        AddMembershipCard = 398,
        UpdateMembershipCard = 399,
        DeleteMembershipCard = 400,
        GetAllMembershipCard = 401,
        GetMembershipCardByID = 402,
        
        AddMembership = 403,
        UpdateMembership = 404,
        DeleteMembership = 405,
        GetAllMembership = 406,
        GetMembershipByID = 407,


        GetAllMembershipCardByName = 408,
        GetAllMembershipCardByCode = 409,

        GetMembershipByCustomerID = 410,



        GetMembershipBymembershipCardName = 411,
        GetMembershipByCustomerPhone = 412,
        GetMembershipBymembershipCode = 413,
        UpdateItemWiseDiscount=414,
        GetCategoryWiseSales=415,
        UpdateOrderComplementory=416,
        UpdateOrderDetailsComplementory=417,
        UpdateOrderDetailsItemComplementory=418,
        UpdateOrderVatComplementory=419,
        UpdateOrderDetailsVatComplementory=420,
        GetMembershipDiscountReport=421,
        LoadMemberDetailsReport=422,
        UpdateGuestQuantity=423,
        GetCategory1IdByParentId = 424,

        GetAllCategory = 425,
        GetItemByCategory = 426,
        GetStockByItemidFrominventory_kitchen_stock = 427,
        UpdateStock = 428,
        ExitOrNot = 429,
        InsertSalereport = 430,
        UpdateSalereport = 431,
        UpdateRawMaterialsByRawProductID = 432,
        ViewCategory2ByCat1ComboBox1=433,
        UpdateKitchenQuantity=434,
        UpdatePaymentForDueBill=435,
        UpdateTotalDueBillPayment=436,
        InsertTotalDueBillPayment=437,
        CheckExistsDueBill=438,
        GetTotalDuePayment=439
    }
}//ns
