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
                case Query.OrderShowByStatus:
                    sRetval = "select order_id,order_type,table_name,table_number,guest_count,order_info.status,user_name from order_info,user_info where order_info.status != '{0}'  and order_info.user_id=user_info.user_id";
                    break;

                case Query.OrderInfoInsert://Changed
                    //sRetval = "insert into order_info values( {0},{1},'{2}','{3}','{4}',{5},{6},'{7}','{8}')";                    
                    sRetval = "insert into order_info(customer_id,user_id,order_type,order_time,status,guest_count,table_number,table_name,terminal_id) values( {0},{1},'{2}',{3},'{4}',{5},{6},'{7}',{8})";                    
                    break;
                case Query.OrderSerialInsert:
                    sRetval="insert into order_serial values({0})";
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
                    sRetval = "select order_id,customer_id,user_id,order_type,order_time,status,guest_count,table_number,table_name from order_info where order_id={0}";
                    break;

                case Query.orderInfoArchiveByOrderID:
                    sRetval = "select order_id,customer_id,user_id,order_type,order_time,status,guest_count,table_number,table_name,serial_no from order_info_archive where order_id={0}";
                    break;

                case Query.OrderSeatTimeInsert:
                    sRetval = "insert into order_seat_time values({0},{1})";
                    break;

                case Query.OrderInfoArchieveInsert:
                    sRetval = "insert into order_info_archive(order_id,customer_id,user_id,order_type,order_time,status,guest_count,table_number,table_name,serial_no,terminal_id ) values({0},{1},{2},'{3}','{4}','{5}',{6},{7},'{8}',{9},{10})";
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
                    sRetval = "select order_id, guest_count, order_type,a.table_number, (select name from customer_info where customer_id = a.customer_id) as customer_name from order_info a where a.status='Seated' and a.order_type='Table' and a.table_number in( select table_number from table_info where status=0 and table_type='Table')";
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

                case Query.UpdateDBForVoidReport:
                    //sRetval = "delete from order_details_archive where order_id={0};delete from order_info_archive where order_id={0}; delete from payment where order_id={0}";
                    sRetval = "delete from order_details_archive where order_id={0};delete from order_info_archive where order_id={0}; delete from payment where order_id={0}";
                    break;
                case Query.OrderShowForViewReportByRef://Changed
                    //sRetval = "select b.order_id, b.order_type, b.table_number, a.total_amount, a.cash_amount, a.EFT_amount, a.cheque_amount,a.voucher_amount, a.service_amount, a.deposit_amount from payment a, order_info_archive b,bill_print_time c where a.order_id=b.order_id and a.order_id=c.order_id and c.payment_time >= {0} and c.payment_time < {1} and b.serial_no='{2}' order by b.order_type";
                    sRetval = "select b.order_id, b.order_type, b.table_number, a.total_amount, a.cash_amount, a.EFT_amount, a.cheque_amount,a.voucher_amount, a.service_amount, a.discount, a.deposit_amount from payment a, order_info_archive b,bill_print_time c where a.order_id=b.order_id and a.order_id=c.order_id and c.payment_time >= {0} and c.payment_time < {1} and b.serial_no='{2}' order by b.order_type";
                    break;

                case Query.OrderShowForViewReportByTable://Changed
                    sRetval = "select b.order_id, b.order_type, b.table_number, a.total_amount, a.cash_amount, a.EFT_amount, a.cheque_amount,a.voucher_amount, a.service_amount, a.discount, a.deposit_amount from payment a, order_info_archive b,bill_print_time c where a.order_id=b.order_id and a.order_id=c.order_id and c.payment_time >= {0} and c.payment_time < {1} and b.table_number={2} order by b.order_type";
                    break;

                case Query.OrderShowForViewReportByPrice://Changed
                    sRetval = "select b.order_id, b.order_type, b.table_number, a.total_amount, a.cash_amount, a.EFT_amount, a.cheque_amount,a.voucher_amount, a.service_amount, a.discount, a.deposit_amount from payment a, order_info_archive b,bill_print_time c where a.order_id=b.order_id and a.order_id=c.order_id and c.payment_time >= {0} and c.payment_time < {1} and a.total_amount={2} order by b.order_type";
                    break;

                case Query.OrderShowForViewReportByRefNTable://Changed
                    sRetval = "select b.order_id, b.order_type, b.table_number, a.total_amount, a.cash_amount, a.EFT_amount, a.cheque_amount,a.voucher_amount, a.service_amount, a.discount, a.deposit_amount from payment a, order_info_archive b,bill_print_time c where a.order_id=b.order_id and a.order_id=c.order_id and c.payment_time >= {0} and c.payment_time < {1} and b.serial_no='{2}' and b.table_number={3} order by b.order_type";
                    break;

                case Query.OrderShowForViewReportByRefNPrice://Changed
                    sRetval = "select b.order_id, b.order_type, b.table_number, a.total_amount, a.cash_amount, a.EFT_amount, a.cheque_amount,a.voucher_amount, a.service_amount, a.discount, a.deposit_amount from payment a, order_info_archive b,bill_print_time c where a.order_id=b.order_id and a.order_id=c.order_id and c.payment_time >= {0} and c.payment_time < {1} and b.serial_no='{2}' and a.total_amount={3} order by b.order_type";
                    break;

                case Query.OrderShowForViewReportByTableNPrice://Changed
                    sRetval = "select b.order_id, b.order_type, b.table_number, a.total_amount, a.cash_amount, a.EFT_amount, a.cheque_amount,a.voucher_amount, a.service_amount, a.discount, a.deposit_amount from payment a, order_info_archive b,bill_print_time c where a.order_id=b.order_id and a.order_id=c.order_id and c.payment_time >= {0} and c.payment_time < {1} and b.table_number={2} and a.total_amount={3} order by b.order_type";
                    break;

                case Query.OrderShowForViewReportByAll://Changed
                    sRetval = "select b.order_id, b.order_type, b.table_number, a.total_amount, a.cash_amount, a.EFT_amount, a.cheque_amount,a.voucher_amount, a.service_amount, a.discount, a.deposit_amount from payment a, order_info_archive b,bill_print_time c where a.order_id=b.order_id and a.order_id=c.order_id and c.payment_time >= {0} and c.payment_time < {1} and b.serial_no='{2}' and b.table_number={3} and a.total_amount={4} order by b.order_type";
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
                    sRetval = "select b.order_id, b.order_type, b.table_number, a.total_amount, a.cash_amount, a.EFT_amount, a.cheque_amount, a.voucher_amount, a.service_amount, a.discount, a.deposit_amount from payment a, order_info_archive b,bill_print_time c where a.order_id=b.order_id and a.order_id=c.order_id and c.payment_time >= {0} and c.payment_time < {1} order by b.order_type";
                    break;

                case Query.OrderShowForViewReportByPC://Changed
                    sRetval = "select b.order_id, b.order_type, b.table_number, a.total_amount, a.cash_amount, a.EFT_amount, a.cheque_amount, a.voucher_amount, a.service_amount, a.discount, a.deposit_amount from payment a, order_info_archive b, bill_print_time c where a.order_id=b.order_id and a.order_id=c.order_id and c.payment_time >= {0} and c.payment_time < {1} and a.pc_id={2} order by b.order_type";
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
                    break;

                #endregion

                #region Category 3 Queries
                case Query.Category3GetAll:
                    sRetval = "select * from category3 order by cat3_order";
                    break;
                #endregion

                #region Category 4 Queries
                case Query.Category4GetAll:
                    sRetval = "select * from category4 order by cat4_order";
                    break;

                #endregion


                #region Order Details Queries
                case Query.OrderDetailsInsert:
                    sRetval = "insert into order_details(order_id,product_id,quantity,amount,remarks,food_type,cat_level) values ( {0},{1},{2},{3},'{4}','{5}',{6})";
                    break;

                case Query.OrderDetailsArchieveInsert:
                    sRetval = "insert into order_details_archive(order_detail_id,order_id,product_id,quantity,amount,remarks,food_type,cat_level) values ( {0},{1},{2},{3},{4},'{5}','{6}',{7})";
                    break;


                case Query.OrderDetailsUpdate:
                    sRetval = "update order_details set order_id={0},product_id={1},quantity={2},amount={3},remarks='{4}',food_type='{5}',cat_level={6} where order_detail_id={7}";
                    break;

                case Query.OrderDetailsDelete:
                    sRetval = "delete from order_details where order_detail_id={0}";
                    break;

                case Query.OrderDetailsGetAll:
                    sRetval = "select order_detail_id,order_id,product_id,quantity,amount,remarks,food_type,cat_level from order_details";
                    break;

                case Query.OrderDetailsGetByOrderId:
                    sRetval = "select order_detail_id,order_id,product_id,quantity,amount,remarks,food_type,cat_level from order_details where order_id={0}";
                    break;

                case Query.OrderDetailsGetByOrderDetailID:
                    sRetval = "select order_detail_id,order_id,product_id,quantity,amount,remarks,food_type,cat_level from order_details where order_detail_id={0}";
                    break;

                case Query.OrderDetailsArchiveGetByOrderId:
                    sRetval = "select order_detail_id,order_id,product_id,quantity,amount,remarks,food_type,cat_level from order_details_archive where order_id={0}";
                    break;

                #endregion

                #region Order Discount queries

                case Query.OrderDiscountInsert:
                    sRetval = "insert into order_discount(order_id,discount) values({0},{1});";
                    break;

                case Query.OrderDiscountUpdate:
                    sRetval = "update order_discount set discount={0} where order_id={1};";
                    break;

                case Query.OrderDiscountGetByOrderID:
                    sRetval = "select order_id,discount from order_discount where order_id={0};";
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
                    sRetval = "insert into table_info values({0},{1},{2},'{3}')";
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
                    sRetval = "insert into table_info values({0},{1},0,'Table')";
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
                    sRetval = "insert into payment values( {0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13} )";
                    break;

                case Query.PaymentUpdate:
                    sRetval = "update payment set order_id={0}, pc_id={1}, total_amount={2},cash_amount={3},eft_amount={4},cheque_amount={5},voucher_amount={6},service_amount={7},discount={8},account_pay={9},deposit_id={10},deposit_amount={11} where payment_id={12}";
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
                    //7,8,9 are newly added by Baruri at 04.09.2008
                    sRetval = "insert into customer_info values( '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}',{8},{9})";
                    break;

                case Query.CustomerUpdate:
                    sRetval = "update customer_info set name='{0}',phone='{1}',postal_code='{2}',address='{3}',town='{4}',county='{5}',country='{6}' where customer_id='{7}'";
                    break;

                case Query.CustomerDelete:
                    sRetval = "delete from customer_info where customer_id={0}";
                    break;

                case Query.CustomerInfoGetByCustomerID:
                    sRetval = "select customer_id,name,phone,address,postal_code,address,town,county,country from customer_info where customer_id={0}";
                    break;

                case Query.CustomerInfoGetByPhone:
                    sRetval = "select customer_id,name,phone,address,postal_code,address,town,county,country from customer_info where phone='{0}'";
                    break;

                case Query.CustomerInfoGetByName:
                    sRetval = "select customer_id,name,phone,address,postal_code,address,town,county,country from customer_info where name='{0}'";
                    break;

                case Query.CustomerInfoGetByNameNPhone:
                    sRetval = "select customer_id,name,phone,address,postal_code,address,town,county,country from customer_info where name = '{0}' and phone='{1}'";
                    break;

                case Query.CustomerInfoGetAll:
                    sRetval = "select customer_id,name as Name,phone as Phone,address as Address,postal_code as \"Postal Code\",town as Town,county as County,country as Country from customer_info;";
                    break;

                #endregion

                # region Payment Summary Queries//total changed

                case Query.PaymentSummaryGetTotal:
                    sRetval = "select sum(a.total_amount) total,sum(a.cash_amount) cash_total, sum(a.EFT_amount) EFT_total, sum(a.cheque_amount) cheque_total, sum(a.voucher_amount) voucher_total, sum(a.service_amount) service_total, sum(a.discount) discount_total, sum(a.deposit_amount) deposit_total, sum(b.guest_count) guest_total, count(distinct b.table_number) table_total from payment a,order_info_archive b,bill_print_time c where a.order_id=b.order_id and a.order_id=c.order_id and c.payment_time >= {0} and c.payment_time < {1}";
                    break;

                case Query.PaymentSummaryGetTotalByOrderType:
                    sRetval = "select sum(a.total_amount) total,sum(a.cash_amount) cash_total, sum(a.EFT_amount) EFT_total, sum(a.cheque_amount) cheque_total, sum(a.voucher_amount) voucher_total, sum(a.service_amount) service_total, sum(a.discount) discount_total, sum(a.deposit_amount) deposit_total, sum(b.guest_count) guest_total, count(distinct b.table_number) table_total from payment a,order_info_archive b,bill_print_time c where a.order_id=b.order_id and a.order_id=c.order_id and c.payment_time >= {0} and c.payment_time < {1} and b.order_type='{2}'";
                    break;

                case Query.PaymentSummaryGetTotalByPC:
                    sRetval = "select sum(a.total_amount) total,sum(a.cash_amount) cash_total, sum(a.EFT_amount) EFT_total, sum(a.cheque_amount) cheque_total, sum(a.voucher_amount) voucher_total, sum(a.service_amount) service_total, sum(a.discount) discount_total, sum(a.deposit_amount) deposit_total, sum(b.guest_count) guest_total, count(distinct b.table_number) table_total from payment a,order_info_archive b,bill_print_time c where a.order_id=b.order_id and a.order_id=c.order_id and c.payment_time >= {0} and c.payment_time < {1} and a.pc_id={2}";
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
                    sRetval = "select a.booking_id,a.customer_id,a.booking_time,a.booking_type,a.status,a.comments,a.guest_count,a.table_count,b.name,b.phone,b.address from booking_info a,customer_info b where a.customer_id=b.customer_id and booking_time>={0} and booking_time<{1}";
                    break;

                case Query.BookingInfoGetByID:
                    sRetval = "select a.booking_id,a.customer_id,a.booking_time,a.booking_type,a.status,a.comments,a.guest_count,a.table_count,b.name,b.phone,b.address from booking_info a,customer_info b where a.customer_id=b.customer_id and a.booking_id={0}";
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
                    sRetval = "select infar.terminal_id,infar.user_id,infar.order_time,infar.order_type,uinfo.user_name from order_info_archive infar left outer join user_info uinfo on  uinfo.user_id=infar.user_id  where infar.order_time>={0} and infar.order_time<={1}";
                    break;

                case Query.LogRegisterForPayment:
                    sRetval = "select pc_id,userid,paymentdate,total_amount from payment where paymentdate>={0} and paymentdate<={1}";
                    break;
                    
                case Query.SaveDrawerOpening:
                    sRetval = "insert into tbl_opendrawer_tracking (userid,opentime,terminal_id) values('{0}',{1},{2})";
                    break;

                case Query.DrawerLogdetails:
                    sRetval = "select terminal_id,userid,opentime,'open' as pp from tbl_opendrawer_tracking where opentime>={0} and opentime<={1}";
                    break;
                #endregion



                case Query.PcInfoByPcIP:
                    sRetval = "select pc_id,pc_ip,name from pc_info where pc_ip='{0}'";
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
        DrawerLogdetails=147
    }
}//ns
