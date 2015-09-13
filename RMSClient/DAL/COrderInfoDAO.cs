using System;
using System.Collections.Generic;
using System.Text;
using RMS.DataAccess;
using RMS.Common.DataAccess;
using RMS.Common.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using RMSClient.DataAccess;


namespace RMS.DataAccess
{
    public class COrderInfoDAO : BaseDAO, IOrderInfoDAO
    {
        #region IOrderInfoDAO members

        public COrderInfo OrderInfoInsert(COrderInfo inOrderInfo)
        {
            COrderInfo tempOrderInfo = inOrderInfo;
            inOrderInfo.TableName = inOrderInfo.TableName.Replace("''", "'");
            inOrderInfo.TableName = inOrderInfo.TableName.Replace("'", "''");

            try
            {
                this.OpenConnectionWithTransection();
               
                string sqlCommand = string.Format(SqlQueries.GetQuery(Query.OrderInfoInsert),
                    inOrderInfo.CustomerID, inOrderInfo.UserID, inOrderInfo.OrderType, inOrderInfo.OrderTime.Ticks, inOrderInfo.Status, inOrderInfo.GuestCount, inOrderInfo.TableNumber, inOrderInfo.TableName,RMSGlobal.Terminal_Id,inOrderInfo.FloorNo);

                this.ExecuteNonQuery(sqlCommand);

                sqlCommand = SqlQueries.GetQuery(Query.ScopeIdentity);

                IDataReader oReader = this.ExecuteReader(sqlCommand);
                if (oReader != null)
                {
                    bool bIsRead = oReader.Read();
                    if (bIsRead)
                    {

                        tempOrderInfo.OrderID = Int64.Parse(oReader[0].ToString());
                    }
                    oReader.Close();
                }

                sqlCommand = String.Format(SqlQueries.GetQuery(Query.OrderSerialInsert), tempOrderInfo.OrderID);
                this.ExecuteNonQuery(sqlCommand);

                if (inOrderInfo.Status.ToUpper() == "Waiting".ToUpper()) //If waiting type order then save the waiting information
                {
                    DateTime dt = DateTime.Now;
                    DateTime dtFinal = new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0);
                    sqlCommand = String.Format(SqlQueries.GetQuery(Query.SaveWaitingInfo), dtFinal.Ticks);
                    this.ExecuteNonQuery(sqlCommand);
                }

                if (inOrderInfo.Status.ToUpper() == "Collection".ToUpper()) //If collection type order then save the collection information
                {
                    DateTime dt = DateTime.Now;
                    DateTime dtFinal = new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0);
                    sqlCommand = String.Format(SqlQueries.GetQuery(Query.SaveCollectionInfo), dtFinal.Ticks);
                    this.ExecuteNonQuery(sqlCommand);
                }

                this.CommitTransection();

            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in OrderInfoInsert()", LogLevel.Error, "Database");
                RollBackTransection();
                throw new Exception("Exception occured at OrderInfoInsert()", ex);
                
            }
            finally
            {
                this.CloseConnection();
            }

            return tempOrderInfo;
        }



        public void OrderInfoUpdate(COrderInfo inOrderInfo)
        {

            inOrderInfo.TableName = inOrderInfo.TableName.Replace("''", "'");
            inOrderInfo.TableName = inOrderInfo.TableName.Replace("'", "''");

            try
            {
                this.OpenConnection();

                string sSql = string.Format(SqlQueries.GetQuery(Query.OrderInfoUpdate),
                    inOrderInfo.CustomerID, inOrderInfo.UserID, inOrderInfo.OrderType, inOrderInfo.OrderTime.Ticks, inOrderInfo.Status, inOrderInfo.GuestCount, inOrderInfo.TableNumber, inOrderInfo.TableName, inOrderInfo.OrderID);

                this.ExecuteNonQuery(sSql);
            }
            catch (Exception ex)
            {
                Console.Write("###" + ex.ToString() + "###");
                Logger.Write("Exception : " + ex + " in OrderInfoUpdate()", LogLevel.Error, "Database");

                throw new Exception("Exception occure at OrderInfoUpdate()", ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public COrderInfo GetOrderInfoByOrderID(Int64 inOrderID)
        {
            COrderInfo tempOrderInfo = new COrderInfo();

            try
            {
                this.OpenConnection();
                string sSql = string.Format(SqlQueries.GetQuery(Query.OrderInfoGetByOrderID), inOrderID);

                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        tempOrderInfo = ReaderToOrderInfo(oReader);
                    }
                    oReader.Close();

                }

                sSql = string.Format(SqlQueries.GetQuery(Query.GetOrderSerial), inOrderID);
                oReader = this.ExecuteReader(sSql);

                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        tempOrderInfo.SerialNo = Int64.Parse("0"+oReader["serial_no"].ToString());
                    }
                    oReader.Close();

                }

            }
            catch (Exception ex)
            {
                Console.Write("###" + ex.ToString() + "###");
                Logger.Write("Exception : " + ex + " in GetOrderInfoByOrderID()", LogLevel.Error, "Database");

                throw new Exception("Exception occure at GetOrderInfoByOrderID()", ex);
            }
            finally
            {
                this.CloseConnection();
            }

            return tempOrderInfo;
        }

        public CResult GetOrderInfoArchiveByOrderID(Int64 inOrderID) //new Added
        {
            CResult tempResult = new CResult();
            COrderInfoArchive tempOrderInfoArchive = new COrderInfoArchive();

            try
            {
                this.OpenConnection();
                string sSql = string.Format(SqlQueries.GetQuery(Query.orderInfoArchiveByOrderID), inOrderID);

                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        tempOrderInfoArchive = ReaderToOrderInfoArchive(oReader);
                    }
                    oReader.Close();

                }
                tempResult.Data = tempOrderInfoArchive;
                tempResult.IsSuccess = true;
            }
            catch (Exception ex)
            {
                tempResult.IsException = true;
                Console.Write("###" + ex.ToString() + "###");
                Logger.Write("Exception : " + ex + " in GetOrderInfoArchiveByOrderID()", LogLevel.Error, "Database");

                throw new Exception("Exception occure at GetOrderInfoArchiveByOrderID()", ex);
            }
            finally
            {
                this.CloseConnection();
            }

            return tempResult;
        }

        #region "Log Register Area"

        /// <summary>
        /// Orders of the selected date 
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public CResult GetOrderdetails(Int64 startTime, Int64 endTime) 
        {
            CResult tempResult = new CResult();
            List<COrderInfoArchive> tempOrderInfoArchive = new List<COrderInfoArchive>();

            try
            {
                this.OpenConnection();
                string sSql = string.Format(SqlQueries.GetQuery(Query.LogRegisterForOrders), startTime,endTime);

                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        COrderInfoArchive orderDetails = new COrderInfoArchive();
                        orderDetails = ReaderToOrderInfoArchive(oReader, false); ;
                        tempOrderInfoArchive.Add(orderDetails);
                    }
                    oReader.Close();
                    tempResult.Data = tempOrderInfoArchive;
                    tempResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                tempResult.IsException = true;
                Console.Write("###" + ex.ToString() + "###");
                Logger.Write("Exception : " + ex + " in GetOrderdetails()", LogLevel.Error, "Database");

                throw new Exception("Exception occure at GetOrderdetails()", ex);
            }
            finally
            {
                this.CloseConnection();
            }

            return tempResult;
        }


        #endregion



        public void DeleteOrderInfo(Int64 inOrderID)
        {

            try
            {
                this.OpenConnection();
                string sSql = string.Format(SqlQueries.GetQuery(Query.DeleteOrderByID), inOrderID);
                this.ExecuteNonQuery(sSql);

            }
            catch (Exception ex)
            {
                Console.Write("###" + ex.ToString() + "###");
                Logger.Write("Exception : " + ex + " in DeleteOrderInfo()", LogLevel.Error, "Database");

                throw new Exception("Exception occure at DeleteOrderInfo()", ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void InsertOrderSeatTime(COrderSeatTime inOrderSeatTime)
        {
            try
            {
                this.OpenConnection();
                string sSql = string.Format(SqlQueries.GetQuery(Query.OrderSeatTimeInsert),
                    inOrderSeatTime.OrderID, inOrderSeatTime.SeatTime.Ticks);

                this.ExecuteNonQuery(sSql);
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in InsertOrderSeatTime()", LogLevel.Error, "Database");

                throw new Exception("Exception occure at InsertOrderSeatTime()", ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public COrderSeatTime OrderSeatTimeByOrderID(Int64 inOrderID)
        {
            COrderSeatTime tempOrderSeatTime = new COrderSeatTime();

            try
            {
                this.OpenConnection();
                string sSql = string.Format(SqlQueries.GetQuery(Query.OrderSeatTimeByOrderID), inOrderID);

                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        tempOrderSeatTime = ReaderToOrderSeatTime(oReader);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write("###" + ex.ToString() + "###");
                Logger.Write("Exception : " + ex + " in OrderSeatTimeByOrderID()", LogLevel.Error, "Database");

                throw new Exception("Exception occure at OrderSeatTimeByOrderID()", ex);
            }
            finally
            {
                this.CloseConnection();
            }

            return tempOrderSeatTime;
        }

        public CResult OrderDetailsGetByOrderID(Int64 inOrderID)
        {
            CResult oResult = new CResult();

            List<COrderDetails> tempOrderDetailsList = new List<COrderDetails>();
            try
            {
                this.OpenConnection();
                string sSql = String.Format(SqlQueries.GetQuery(Query.OrderDetailsGetByOrderId), inOrderID.ToString());
                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        COrderDetails tempOrderDetails = ReaderToOrderDetails(oReader);
                        tempOrderDetailsList.Add(tempOrderDetails);
                    }
                }

                oResult.Data = tempOrderDetailsList;

                oResult.IsSuccess = true;
            }
            catch (Exception ex)
            {
                Console.Write("###" + ex.ToString() + "###");
                Logger.Write("Exception : " + ex + " in OrderDetailsGetByOrderID()", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occured at OrderDetailsGetByOrderID()", ex);
                }
                else
                {
                    throw new Exception("Exception occure at OrderDetailsGetByOrderID()", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }
            return oResult;
        }

        public CResult OrderDetailsArchiveGetByOrderID(Int64 inOrderID) //new Added
        {
            CResult oResult = new CResult();

            List<COrderDetails> tempOrderDetailsList = new List<COrderDetails>();
            try
            {
                this.OpenConnection();
                string sSql = String.Format(SqlQueries.GetQuery(Query.OrderDetailsArchiveGetByOrderId), inOrderID.ToString());
                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        COrderDetails tempOrderDetails = ReaderToOrderDetails(oReader);
                        tempOrderDetailsList.Add(tempOrderDetails);
                    }
                }

                oResult.Data = tempOrderDetailsList;

                oResult.IsSuccess = true;
            }
            catch (Exception ex)
            {
                Console.Write("###" + ex.ToString() + "###");
                Logger.Write("Exception : " + ex + " in OrderDetailsGetByOrderID()", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occured at OrderDetailsGetByOrderID()", ex);
                }
                else
                {
                    throw new Exception("Exception occure at OrderDetailsGetByOrderID()", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }
            return oResult;
        }

        public CResult InsertOrderArchive(COrderInfo inOrderInfo)//Changed
        {
            CResult oNewResult = new CResult();

            COrderInfo tempOrderInfo = inOrderInfo;
            inOrderInfo.TableName = inOrderInfo.TableName.Replace("''", "'");
            inOrderInfo.TableName = inOrderInfo.TableName.Replace("'", "''");

            try
            {
                //this.OpenConnection();

                this.OpenConnectionWithTransection();

                string sSql = string.Format(SqlQueries.GetQuery(Query.DeleteOrderByID), inOrderInfo.OrderID);

                this.ExecuteNonQuery(sSql);

                sSql = string.Format(SqlQueries.GetQuery(Query.DeleteOrderSerial), inOrderInfo.OrderID);

                this.ExecuteNonQuery(sSql);

                sSql = string.Format(SqlQueries.GetQuery(Query.OrderInfoArchieveInsert), inOrderInfo.OrderID,
                    inOrderInfo.CustomerID, inOrderInfo.UserID, inOrderInfo.OrderType, inOrderInfo.OrderTime.Ticks, inOrderInfo.Status, inOrderInfo.GuestCount, inOrderInfo.TableNumber, inOrderInfo.TableName, inOrderInfo.SerialNo,RMSGlobal.Terminal_Id,inOrderInfo.OnlineOrderID);

                this.ExecuteNonQuery(sSql);

                this.CommitTransection();

            }
            catch (Exception ex)
            {
                this.RollBackTransection();
                Logger.Write("Exception : " + ex + " in InsertOrderArchive()", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occured at InsertOrderArchive()", ex);
                }
                else
                {
                    throw new Exception("Exception occure at InsertOrderArchive()", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }

            return oNewResult;
        }


        private DataTable GetRecordsTable(IDataReader oReader)
        {
            DataTable dtRecords = new DataTable();
            dtRecords.Columns.Add("order_id",typeof(Int64));
            dtRecords.Columns.Add("customer_id", typeof(Int64));
            dtRecords.Columns.Add("user_id", typeof(string));
            dtRecords.Columns.Add("order_type", typeof(string));
            dtRecords.Columns.Add("order_time", typeof(Int64));
            dtRecords.Columns.Add("status", typeof(string));
            dtRecords.Columns.Add("guest_count", typeof(int));
            dtRecords.Columns.Add("table_number", typeof(Int32));
            dtRecords.Columns.Add("table_name", typeof(string));
            dtRecords.Columns.Add("terminal_id", typeof(int));
            dtRecords.Columns.Add("online_orderid", typeof(Int64));
            dtRecords.Columns.Add("webstatus", typeof(string));
            dtRecords.Columns.Add("webstatusnote", typeof(string));
            dtRecords.Columns.Add("OnlineStatus", typeof(int));
            dtRecords.Columns.Add("quantity", typeof(int));
            dtRecords.Columns.Add("amount", typeof(double));
            dtRecords.Columns.Add("remarks", typeof(string));
            dtRecords.Columns.Add("food_type", typeof(string));
            dtRecords.Columns.Add("pcat_name", typeof(string));
            dtRecords.Columns.Add("cat1_name", typeof(string));
            dtRecords.Columns.Add("cat2_name", typeof(string));
            dtRecords.Columns.Add("item_name", typeof(string));
            dtRecords.Columns.Add("item_order_number", typeof(Int64));
            dtRecords.Columns.Add("printed_quantity", typeof(int));

            if (oReader != null)
            {
                while (oReader.Read())
                {
                   dtRecords.Rows.Add(
                       new object[]{
                       
                       Convert.ToInt64("0" + oReader["online_orderid"]), 
                       Convert.ToInt64("0" + oReader["customer_id"]), 
                       Convert.ToString(oReader["user_id"]),
                       Convert.ToString(oReader["order_type"]), 
                       Convert.ToInt64("0" +oReader["order_time"]), 
                       Convert.ToString(oReader["status"]), 
                       Convert.ToInt32("0" +oReader["guest_count"]), 
                       Convert.ToInt32("0" +oReader["table_number"]), 
                       Convert.ToString(oReader["table_name"]), 
                       Convert.ToInt32("0" +oReader["terminal_id"]), 
                       0, 
                       Convert.ToString(oReader["webstatus"]), 
                       Convert.ToString(oReader["webstatusnote"]), 
                       Convert.ToInt32("0" +oReader["OnlineStatus"]), 
                       Convert.ToInt32("0" +oReader["quantity"]), 
                       Convert.ToDouble("0" +oReader["amount"]), 
                       Convert.ToString(oReader["remarks"]), 
                       Convert.ToString(oReader["food_type"]), 
                       Convert.ToString(oReader["pcat_name"]), 
                       Convert.ToString(oReader["cat1_name"]), 
                       Convert.ToString(oReader["cat2_name"]), 
                       Convert.ToString(oReader["item_name"]), 
                       Convert.ToInt64("0" +oReader["item_order_number"]), 
                       Convert.ToInt32("0" +oReader["printed_quantity"])
                       }
                       );
                }
            }
            oReader.Close();

            return dtRecords;
        }


        /// <summary>
        /// This function 
        /// </summary>
        /// <param name="inOrderInfo"></param>
        /// <returns></returns>
        public CResult InsertOnlineOrderArchive(COrderInfo inOrderInfo)//Changed
        {
            CResult oNewResult = new CResult();
            string sqlCommand = "";
            COrderInfo tempOrderInfo = inOrderInfo;
            inOrderInfo.TableName = inOrderInfo.TableName.Replace("''", "'");
            inOrderInfo.TableName = inOrderInfo.TableName.Replace("'", "''");

            try
            {
                this.OpenConnectionWithTransection();

                #region "Archive"

                sqlCommand = string.Format(SqlQueries.GetQuery(Query.GetOnlineOrderedItemsById), inOrderInfo.OrderID);

                IDataReader oReader = this.ExecuteReader(sqlCommand);

                DataTable dtRecords = this.GetRecordsTable(oReader);

                oReader.Close();

                foreach (DataRow dtRow in dtRecords.Rows)
                {
                    sqlCommand = string.Format(SqlQueries.GetQuery(Query.InsertOnlineOrderedItemsArchive), Convert.ToInt64("0" + dtRow["order_id"]), Convert.ToInt64("0" + dtRow["customer_id"]), Convert.ToString(dtRow["user_id"]), Convert.ToString(dtRow["order_type"]), Convert.ToInt64(dtRow["order_time"]), Convert.ToString(dtRow["status"]), Convert.ToInt32(dtRow["guest_count"]), Convert.ToInt32(dtRow["table_number"]), Convert.ToString(dtRow["table_name"]), Convert.ToInt32(dtRow["terminal_id"]), Convert.ToInt64(dtRow["online_orderid"]), Convert.ToString(dtRow["webstatus"]), Convert.ToString(dtRow["webstatusnote"]), Convert.ToInt32(dtRow["OnlineStatus"]), Convert.ToInt32(dtRow["quantity"]), Convert.ToDouble(dtRow["amount"]), Convert.ToString(dtRow["remarks"]), Convert.ToString(dtRow["food_type"]), Convert.ToString(dtRow["pcat_name"]), Convert.ToString(dtRow["cat1_name"]), Convert.ToString(dtRow["cat2_name"]), Convert.ToString(dtRow["item_name"]), Convert.ToInt64(dtRow["item_order_number"]), Convert.ToInt32(dtRow["printed_quantity"]));
                    this.ExecuteNonQuery(sqlCommand);

                    sqlCommand = string.Format(SqlQueries.GetQuery(Query.DeleteOnlineItem), Convert.ToInt64("0" + dtRow["order_id"]));
                    this.ExecuteNonQuery(sqlCommand);
                }

                #endregion


                sqlCommand = string.Format(SqlQueries.GetQuery(Query.DeleteOrderByID), inOrderInfo.OrderID);

                this.ExecuteNonQuery(sqlCommand);

                sqlCommand = string.Format(SqlQueries.GetQuery(Query.DeleteOrderSerial), inOrderInfo.OrderID);

                this.ExecuteNonQuery(sqlCommand);

                sqlCommand = string.Format(SqlQueries.GetQuery(Query.OrderInfoArchieveInsert), inOrderInfo.OrderID,
                    inOrderInfo.CustomerID, inOrderInfo.UserID, inOrderInfo.OrderType, inOrderInfo.OrderTime.Ticks, inOrderInfo.Status, inOrderInfo.GuestCount, inOrderInfo.TableNumber, inOrderInfo.TableName, inOrderInfo.SerialNo, RMSGlobal.Terminal_Id,inOrderInfo.OnlineOrderID);

                this.ExecuteNonQuery(sqlCommand);

                this.CommitTransection();
            }
            catch (Exception ex)
            {
                this.RollBackTransection();
                Logger.Write("Exception : " + ex + " in InsertOrderArchive()", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occured at InsertOrderArchive()", ex);
                }
                else
                {
                    throw new Exception("Exception occure at InsertOrderArchive()", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }

            return oNewResult;
        }


        public CResult InsertOrderDetailsArchive(Int64 inOrderID)
        {
            CResult oNewResult = new CResult();

            try
            {

                CResult oResult = OrderDetailsGetByOrderID(inOrderID);

                this.OpenConnectionWithTransection();

                if (oResult.IsSuccess && oResult.Data != null)
                {
                    List<COrderDetails> oTempList = (List<COrderDetails>)oResult.Data;

                    for (int i = 0; i < oTempList.Count; i++)
                    {
                        COrderDetails oOrderDetails = oTempList[i];

                        String sTempSql = String.Format(SqlQueries.GetQuery(Query.OrderDetailsDelete), oOrderDetails.OrderDetailsID);
                        this.ExecuteNonQuery(sTempSql);
                    }

                    for (int i = 0; i < oTempList.Count; i++)
                    {
                        COrderDetails oOrderDetails = oTempList[i];

                        oOrderDetails.OrderRemarks = oOrderDetails.OrderRemarks.Replace("''", "'");
                        oOrderDetails.OrderRemarks = oOrderDetails.OrderRemarks.Replace("'", "''");


                        String sSql = String.Format(SqlQueries.GetQuery(Query.OrderDetailsArchieveInsert), oOrderDetails.OrderDetailsID,
                     oOrderDetails.OrderID, oOrderDetails.ProductID, oOrderDetails.OrderQuantity, oOrderDetails.OrderAmount, oOrderDetails.OrderRemarks, oOrderDetails.OrderFoodType, oOrderDetails.CategoryLevel, oOrderDetails.UserID, oOrderDetails.ItemOrderTime, oOrderDetails.Product_Name,oOrderDetails.UOM,oOrderDetails.Product_Type);
                        this.ExecuteNonQuery(sSql);

                    }

                    this.CommitTransection();

                    oNewResult.IsSuccess = true;
                }

            }

            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in OrderDetailsInsert()", LogLevel.Error, "Database");

                

                this.RollBackTransection();
            }
            finally
            {
                this.CloseConnection();
            }

            return oNewResult;



        }

        public CResult InsertOrderDiscount(COrderDiscount inOrderDiscount)
        {
            CResult oResult = new CResult();
            try
            {
                this.OpenConnection();


                string sSql = string.Format(SqlQueries.GetQuery(Query.OrderDiscountInsert),
                      inOrderDiscount.OrderID, inOrderDiscount.Discount, inOrderDiscount.discountPercentRate, inOrderDiscount.membershipID, inOrderDiscount.membershipCardID, inOrderDiscount.clientID, inOrderDiscount.membershipPoint, inOrderDiscount.membershipTotalPoint, inOrderDiscount.membershipDiscountRate, inOrderDiscount.membershipDiscountAmount,inOrderDiscount.TotalItemDiscount);

                this.ExecuteNonQuery(sSql);
                oResult.IsSuccess = true;
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in InsertOrderDiscount()", LogLevel.Error, "Database");

                // throw new Exception("Exception occure at InsertOrderSeatTime()", ex);
                oResult.IsException = true;
            }
            finally
            {
                this.CloseConnection();
            }
            return oResult;
        }

        public CResult UpdateOrderDiscount(COrderDiscount inOrderDiscount)
        {
            CResult oResult = new CResult();
            try
            {
                this.OpenConnection();


                string sSql = string.Format(SqlQueries.GetQuery(Query.OrderDiscountUpdate),
                     inOrderDiscount.Discount, inOrderDiscount.discountPercentRate, inOrderDiscount.membershipID, inOrderDiscount.membershipCardID, inOrderDiscount.clientID, inOrderDiscount.membershipPoint, inOrderDiscount.membershipTotalPoint, inOrderDiscount.membershipDiscountRate, inOrderDiscount.membershipDiscountAmount, inOrderDiscount.OrderID,inOrderDiscount.TotalItemDiscount);

                this.ExecuteNonQuery(sSql);
                oResult.IsSuccess = true;
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in UpdateOrderDiscount()", LogLevel.Error, "Database");

                // throw new Exception("Exception occure at InsertOrderSeatTime()", ex);
                oResult.IsException = true;
            }
            finally
            {
                this.CloseConnection();
            }
            return oResult;
        }

        public CResult GetOrderDiscountByOrderID(Int64 inOrderID)
        {
            CResult oResult = new CResult();
            try
            {
                this.OpenConnection();


                string sSql = string.Format(SqlQueries.GetQuery(Query.OrderDiscountGetByOrderID), inOrderID);

                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        oResult.Data = ReaderToOrderDiscount(oReader);
                    }
                }
                oResult.IsSuccess = true;
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in GetOrderDiscountByOrderID()", LogLevel.Error, "Database");

                // throw new Exception("Exception occure at InsertOrderSeatTime()", ex);
                oResult.IsException = true;
            }
            finally
            {
                this.CloseConnection();
            }
            return oResult;
        }

        public CResult InsertOrderVoucher(COrderVoucher inOrderVoucher)
        {
            CResult oResult = new CResult();
            try
            {
                this.OpenConnection();


                string sSql = string.Format(SqlQueries.GetQuery(Query.OrderVoucherInsert),
                    inOrderVoucher.VoucherID,inOrderVoucher.OrderID,inOrderVoucher.VoucherAmount);

                this.ExecuteNonQuery(sSql);
                oResult.IsSuccess = true;
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in InsertOrderDiscount()", LogLevel.Error, "Database");

                // throw new Exception("Exception occure at InsertOrderSeatTime()", ex);
                oResult.IsException = true;
            }
            finally
            {
                this.CloseConnection();
            }
            return oResult;
        }

        #endregion


        private COrderInfo ReaderToOrderInfo(IDataReader inReader)//Changed
        {
            COrderInfo tempOrderInfo = new COrderInfo();

            if (inReader["order_id"] != null)
                tempOrderInfo.OrderID = Int64.Parse(inReader["order_id"].ToString());

            if (inReader["customer_id"] != null)
                tempOrderInfo.CustomerID = Int64.Parse("0"+inReader["customer_id"].ToString());

            if (inReader["user_id"] != null)
                tempOrderInfo.UserID = int.Parse("0"+inReader["user_id"].ToString());

            if (inReader["status"] != null)
                tempOrderInfo.Status = inReader["status"].ToString();

            if (inReader["order_type"] != null)
                tempOrderInfo.OrderType = inReader["order_type"].ToString();

            if (inReader["order_time"] != null)
                //tempOrderInfo.OrderTime = DateTime.Parse(inReader["order_time"].ToString());
                tempOrderInfo.OrderTime = new DateTime(Int64.Parse("0"+inReader["order_time"].ToString()));

            if (inReader["guest_count"] != null)
                tempOrderInfo.GuestCount = int.Parse("0"+inReader["guest_count"].ToString());

            if (inReader["table_number"] != null)
                tempOrderInfo.TableNumber = Int64.Parse("0"+inReader["table_number"].ToString());

            if (inReader["table_name"] != null)
                tempOrderInfo.TableName = inReader["table_name"].ToString();

            //if (inReader["serial_no"] != null)
            //    tempOrderInfo.SerialNo = Int64.Parse(inReader["serial_no"].ToString());

            if (inReader["online_orderid"] != null)
                tempOrderInfo.OnlineOrderID = Int64.Parse("0"+inReader["online_orderid"].ToString());

            try
            {
                if (inReader["vatComplementory"] != null)
                    tempOrderInfo.VatComplementory = Convert.ToBoolean(inReader["vatComplementory"]);
            }
            catch (Exception)
            {
            }

            try
            {
                if (inReader["FloorNo"] != null)
                    tempOrderInfo.FloorNo = inReader["FloorNo"].ToString();
            }
            catch (Exception)
            {
            }


           

            return tempOrderInfo;

        }

        private COrderInfoArchive ReaderToOrderInfoArchive(IDataReader inReader)//new Added
        {
            COrderInfoArchive tempOrderInfo = new COrderInfoArchive();

            if (inReader["order_id"] != null)
                tempOrderInfo.OrderID = Int64.Parse(inReader["order_id"].ToString());

            if (inReader["customer_id"] != null)
                tempOrderInfo.CustomerID = Int64.Parse(inReader["customer_id"].ToString());

            if (inReader["user_id"] != null)
                tempOrderInfo.UserID = int.Parse(inReader["user_id"].ToString());

            if (inReader["status"] != null)
                tempOrderInfo.Status = inReader["status"].ToString();

            if (inReader["order_type"] != null)
                tempOrderInfo.OrderType = inReader["order_type"].ToString();

            if (inReader["order_time"] != null)
                //tempOrderInfo.OrderTime = DateTime.Parse(inReader["order_time"].ToString());
                tempOrderInfo.OrderTime = new DateTime(Int64.Parse(inReader["order_time"].ToString()));

            if (inReader["guest_count"] != null)
                tempOrderInfo.GuestCount = int.Parse(inReader["guest_count"].ToString());

            if (inReader["table_number"] != null)
                tempOrderInfo.TableNumber = int.Parse(inReader["table_number"].ToString());

            if (inReader["table_name"] != null)
                tempOrderInfo.TableName = inReader["table_name"].ToString();

            if (inReader["serial_no"] != null)
                tempOrderInfo.SerialNo = Int64.Parse(inReader["serial_no"].ToString());

            return tempOrderInfo;
        }
/// <summary>
/// /For LogRegister
/// </summary>
/// <param name="inReader"></param>
/// <param name="blnValue"></param>
/// <returns></returns>

        private COrderInfoArchive ReaderToOrderInfoArchive(IDataReader inReader,bool blnValue)//new Added
        {
            COrderInfoArchive tempOrderInfo = new COrderInfoArchive();
            blnValue = true;
            
            if (inReader["user_id"] != null)
                tempOrderInfo.UserID = int.Parse(inReader["user_id"].ToString());


            if (inReader["order_type"] != null)
                tempOrderInfo.OrderType = inReader["order_type"].ToString();

            if (inReader["order_time"] != null)
                //tempOrderInfo.OrderTime = DateTime.Parse(inReader["order_time"].ToString());
                tempOrderInfo.OrderTime = new DateTime(Int64.Parse(inReader["order_time"].ToString()));

         
            if (inReader["terminal_id"] != null)
                tempOrderInfo.TerminalID = Int32.Parse(inReader["terminal_id"].ToString());

            if (inReader["user_name"] != null)
                tempOrderInfo.UserName = Convert.ToString(inReader["user_name"].ToString());

            if (inReader["order_id"] != null)
                tempOrderInfo.OrderID = Convert.ToInt32(inReader["order_id"].ToString());

            return tempOrderInfo;
        }


        private COrderSeatTime ReaderToOrderSeatTime(IDataReader inReader)//Changed
        {
            COrderSeatTime tempOrderSeatTime = new COrderSeatTime();

            if (inReader["order_id"] != null)
                tempOrderSeatTime.OrderID = Int64.Parse(inReader["order_id"].ToString());

            if (inReader["seat_time"] != null)
                //tempOrderSeatTime.SeatTime = DateTime.Parse(inReader["seat_time"].ToString());
                tempOrderSeatTime.SeatTime = new DateTime(Int64.Parse(inReader["seat_time"].ToString()));

            return tempOrderSeatTime;
        }

        private COrderDetails ReaderToOrderDetails(IDataReader inReader)
        {
            COrderDetails tempOrderDetails = new COrderDetails();

            if (inReader["order_detail_id"] != null)
                tempOrderDetails.OrderDetailsID = Int64.Parse(inReader["order_detail_id"].ToString());

            if (inReader["order_id"] != null)
                tempOrderDetails.OrderID = Int64.Parse(inReader["order_id"].ToString());

            if (inReader["product_id"] != null)
                tempOrderDetails.ProductID = Int64.Parse(inReader["product_id"].ToString());

            if (inReader["quantity"] != null)
                tempOrderDetails.OrderQuantity = Int32.Parse(inReader["quantity"].ToString());

            if (inReader["amount"] != null)
                tempOrderDetails.OrderAmount = Double.Parse(inReader["amount"].ToString());

            if (inReader["remarks"] != null)
                tempOrderDetails.OrderRemarks = inReader["remarks"].ToString();

            if (inReader["food_type"] != null)
                tempOrderDetails.OrderFoodType = inReader["food_type"].ToString();

            if (inReader["cat_level"] != null)
                tempOrderDetails.CategoryLevel = Int32.Parse(inReader["cat_level"].ToString());

            if (inReader["user_id"] != null)
                tempOrderDetails.UserID = Int32.Parse(inReader["user_id"].ToString());

            if (inReader["item_order_time"] != null)
                tempOrderDetails.ItemOrderTime = Int64.Parse(inReader["item_order_time"].ToString());

            if (inReader["product_Name"] != null)
                tempOrderDetails.Product_Name = Convert.ToString(inReader["product_Name"].ToString());

            if (inReader["productType"] != null)
                tempOrderDetails.Product_Type = Convert.ToString(inReader["productType"].ToString());

            if (inReader["UoM"] != null)
                tempOrderDetails.UOM = Convert.ToString(inReader["UoM"].ToString());


            try
            {
                //if (inReader["kitchen_quantity"] != null)
                {
                    tempOrderDetails.DiscountAmount = Convert.ToDouble(inReader["item_discount"]);
                }

            }
            catch
            {


            }

          //  tempOrderDetails.OrderAmount = tempOrderDetails.OrderAmount - tempOrderDetails.DiscountAmount;

            return tempOrderDetails;

        }

        private COrderDiscount ReaderToOrderDiscount(IDataReader inReader)
        {
            COrderDiscount tempOrderDiscount = new COrderDiscount();

            if (inReader["order_id"] != null)
                tempOrderDiscount.OrderID = Int64.Parse(inReader["order_id"].ToString());
            if (inReader["discount"] != null)
                tempOrderDiscount.Discount = Double.Parse(inReader["discount"].ToString());

            if (inReader["discountPercentRate"] != null)
                tempOrderDiscount.discountPercentRate = float.Parse(inReader["discountPercentRate"].ToString());

            if (inReader["membershipID"] != null)
                tempOrderDiscount.membershipID = long.Parse(inReader["membershipID"].ToString());

            if (inReader["membershipCardID"] != null)
                tempOrderDiscount.membershipCardID = long.Parse(inReader["membershipCardID"].ToString());

            if (inReader["clientID"] != null)
                tempOrderDiscount.clientID = long.Parse(inReader["clientID"].ToString());

            if (inReader["membershipPoint"] != null)
                tempOrderDiscount.membershipPoint = float.Parse(inReader["membershipPoint"].ToString());

            if (inReader["membershipTotalPoint"] != null)
                tempOrderDiscount.membershipTotalPoint = float.Parse(inReader["membershipTotalPoint"].ToString());


            if (inReader["membershipDiscountRate"] != null)
                tempOrderDiscount.membershipDiscountRate = float.Parse(inReader["membershipDiscountRate"].ToString());


            if (inReader["membershipDiscountAmount"] != null)
                tempOrderDiscount.membershipDiscountAmount = float.Parse(inReader["membershipDiscountAmount"].ToString());
            if (inReader["TotalItemDiscount"] != null)
                tempOrderDiscount.TotalItemDiscount = float.Parse(inReader["TotalItemDiscount"].ToString());

            return tempOrderDiscount;
        }

        #region IOrderInfoDAO Members


        public void UpdateTakeawayOrder(COrderInfo inOrderInfo)
        {
            try
            {
                this.OpenConnection();

                string sqlCommand = string.Format(SqlQueries.GetQuery(Query.UpdateTakwawayOrderStatus),
                    inOrderInfo.OrderID, inOrderInfo.Status);

                this.ExecuteNonQuery(sqlCommand);
            }
            catch (Exception ex)
            {
                Console.Write("###" + ex.ToString() + "###");
                Logger.Write("Exception : " + ex + " in OrderInfoUpdate()", LogLevel.Error, "Database");

                throw new Exception("Exception occure at OrderInfoUpdate()", ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        #endregion

        #region IOrderInfoDAO Members


        public CResult GetOnlineOrderPrintStatus(long inOrderID)
        {
            CResult oResult = new CResult();
            COrderInfo tempOrderInfo = new COrderInfo();
            try
            {
                this.OpenConnection();

                string sqlCommand = string.Format(SqlQueries.GetQuery(Query.GetOnlineOrderPrintStatus), inOrderID);

                IDataReader oReader = this.ExecuteReader(sqlCommand);
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                       tempOrderInfo.OnlineOrderPrintStatus=Convert.ToInt32("0"+oReader[0]);
                    }
                }
                oResult.IsSuccess = true;
                oResult.Data = tempOrderInfo;
                oReader.Close();
            }
            catch (Exception ex)
            {
                Console.Write("###" + ex.ToString() + "###");
                Logger.Write("Exception : " + ex + " in GetOnlineOrderPrintStatus()", LogLevel.Error, "Database");

                throw new Exception("Exception occure at GetOnlineOrderPrintStatus()", ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return oResult;
        }

        public CResult ChangeOnlineOrderPrintStatus(long inOrderID)
        {
            CResult objResult = new CResult();
            try
            {
                this.OpenConnection();

                string sqlCommand = string.Format(SqlQueries.GetQuery(Query.ChangeOnlineOrderPrintStatus),inOrderID);

                this.ExecuteNonQuery(sqlCommand);
            }
            catch (Exception ex)
            {
                Console.Write("###" + ex.ToString() + "###");
                Logger.Write("Exception : " + ex + " in ChangeOnlineOrderPrintStatus()", LogLevel.Error, "Database");

                throw new Exception("Exception occure at ChangeOnlineOrderPrintStatus()", ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return objResult;
        }

        #endregion

        #region IOrderInfoDAO Members


        public CResult InsertOrderServiceCharge(ServiceCharge inOrderServiceCharge)
        {
            CResult oResult = new CResult();
            try
            {
                this.OpenConnection();


                string sqlCommand = string.Format(SqlQueries.GetQuery(Query.InsertServiceCharge),
                    inOrderServiceCharge.OrderID, inOrderServiceCharge.ServiceChargeAmount, inOrderServiceCharge.ServicechargeRate);

                this.ExecuteNonQuery(sqlCommand);
                oResult.IsSuccess = true;
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in InsertOrderServiceCharge()", LogLevel.Error, "Database");
                oResult.IsException = true;
            }
            finally
            {
                this.CloseConnection();
            }
            return oResult;
        }

        public CResult UpdateOrderServiceCharge(ServiceCharge inOrderServiceCharge)
        {
            CResult oResult = new CResult();
            try
            {
                this.OpenConnection();


                string sqlCommand = string.Format(SqlQueries.GetQuery(Query.UpdateServiceCharge),
                    inOrderServiceCharge.ServiceChargeAmount, inOrderServiceCharge.ServicechargeRate , inOrderServiceCharge.OrderID);

                this.ExecuteNonQuery(sqlCommand);
                oResult.IsSuccess = true;
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in UpdateOrderServiceCharge()", LogLevel.Error, "Database");
                oResult.IsException = true;
            }
            finally
            {
                this.CloseConnection();
            }
            return oResult;
        }

        public CResult GetOrderServiceChargeByOrderID(long inOrderID)
        {
            CResult oResult = new CResult();

            ServiceCharge tempServiceCharge = new ServiceCharge();
            try
            {
                this.OpenConnection();
                string sqlCommand = String.Format(SqlQueries.GetQuery(Query.GetServiceCharge), inOrderID);
                IDataReader oReader = this.ExecuteReader(sqlCommand);
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        tempServiceCharge.ServiceChargeAmount = Convert.ToDouble("" + oReader["svc_charge"]);
                        tempServiceCharge.ServicechargeRate = Convert.ToDouble("" + oReader["svc_chargeRate"]);
                        oResult.IsSuccess = true;
                    }
                }

                oResult.Data = tempServiceCharge;
            }
            catch (Exception ex)
            {
                Console.Write("###" + ex.ToString() + "###");
                Logger.Write("Exception : " + ex + " in GetOrderServiceChargeByOrderID()", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occured at GetOrderServiceChargeByOrderID()", ex);
                }
                else
                {
                    throw new Exception("Exception occure at GetOrderServiceChargeByOrderID()", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }
            return oResult;
        }

        #endregion

      #region IOrderInfoDAO Members


        public CResult VoidPrintedItems(System.Collections.SortedList slPrintedList, long orderID)
        {
            DataSet tempStockDataSet = new DataSet();
            tempStockDataSet.ReadXml("Config/StockSetting.xml");

            bool isAllowedToOrder = Convert.ToBoolean(tempStockDataSet.Tables[0].Rows[0]["AllowedtoOrder"].ToString());

            CResult oResult = new CResult();
            string sqlCommand = "";

            try
            {
                this.OpenConnection();

                foreach (COrderDetails objDetails in slPrintedList.Values)
                {
                    COrderDetails aDetails = new COrderDetails();
                    aDetails = GetAll(objDetails); // Add for Vat and Cost find out
                    if (objDetails.OrderQuantity > 0) //If item is rest.
                    {

                        sqlCommand = string.Format(SqlQueries.GetQuery(Query.UpdateLocalVoidItems),
                                                   aDetails.OrderQuantity, aDetails.PrintedQuantity,
                                                   aDetails.OrderDetailsID, aDetails.OrderAmount,
                                                   aDetails.Amount_with_vat, aDetails.VatTotal);

                    }
                    else
                    {
                        sqlCommand = string.Format(SqlQueries.GetQuery(Query.OrderDetailsDelete),
                                                   objDetails.OrderDetailsID);
                    }
                    this.ExecuteNonQuery(sqlCommand);

                    //Add for raw materials update
                    if (!isAllowedToOrder)
                    {
                        if (objDetails.KitchenQuantity - objDetails.OrderQuantity >= 0)
                        {
                            double quantity = objDetails.KitchenQuantity - objDetails.OrderQuantity;
                            //if (objDetails.OrderQuantity == 0)
                            //{
                            //    quantity = 1;
                            //}
                            COrderDetailsDAO cOrderDetailsDao = new COrderDetailsDAO();
                            cOrderDetailsDao.UpdateKitchenQuantity(aDetails);
                            FinishedRawProductListDAO aDao = new FinishedRawProductListDAO();
                            List<CFinishedRawProductList> aList =
                                aDao.GetFinishedRawProductListByProductID(objDetails.ProductID);
                            foreach (CFinishedRawProductList list in aList)
                            {
                                string command = string.Format(SqlQueries.GetQuery(Query.UpdateRawMaterialsByRawProductID),
                                                               list.RawProductID, (list.Qnty * quantity));
                                this.ExecuteNonQuery(command);
                            }
                        }
                    }

                }
                oResult.IsSuccess = true;
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in VoidPrintedItems()", LogLevel.Error, "Database");
                oResult.IsException = true;
            }
            finally
            {
                this.CloseConnection();
            }
            return oResult;
        }

        private COrderDetails GetAll(COrderDetails objDetails)//Add for vat and cost find out
        {
            try
            {
                COrderDetailsDAO aDao = new COrderDetailsDAO();
                List<COrderDetails> aCOrderDetailses = aDao.OrderDetailsGetAll();
                COrderDetails orderDetails = new COrderDetails();
                foreach (COrderDetails details in aCOrderDetailses)
                {
                    if (details.OrderID == objDetails.OrderID && details.ProductID == objDetails.ProductID)
                    {
                        orderDetails = details;
                    }
                }

                int quantity = objDetails.OrderQuantity;
                double unit_amount = (orderDetails.OrderAmount / orderDetails.OrderQuantity);
                double unit_vat = ((orderDetails.Amount_with_vat - orderDetails.OrderAmount) * 100) / orderDetails.OrderAmount;
                unit_vat = (unit_amount * unit_vat) / 100.0;
                objDetails.OrderAmount = (unit_amount * quantity);
                objDetails.VatTotal = unit_vat * quantity;
                objDetails.Amount_with_vat = objDetails.OrderAmount + objDetails.VatTotal;
                objDetails.KitchenQuantity = orderDetails.KitchenQuantity;


            }
            catch
            {


            }
            return objDetails;
        }

        #endregion

        #region IOrderInfoDAO Members


        public CResult SaveOrderKitchenText(long inOrderID, string kitchenText)
        {
            CResult oResult = new CResult();
            string sqlCommand = "";
            string previousKitchenText = String.Empty;

            try
            {
                this.OpenConnection();
                sqlCommand = string.Format(SqlQueries.GetQuery(Query.SaveOrderKitchenText), inOrderID, kitchenText);
                 this.ExecuteNonQuery(sqlCommand);
                
                oResult.IsSuccess = true;
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in SaveOrderKitchenText()", LogLevel.Error, "Database");
                oResult.IsException = true;
            }
            finally
            {
                this.CloseConnection();
            }
            return oResult;
        }

        #endregion

        #region IOrderInfoDAO Members

        /// <summary>
        /// This function changes the print status of kitchen text of the order.Whether the kitchen text command is printed or not.
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        public CResult UpdateOrderKitchenTextStatus(long orderID)
        {
            CResult oResult = new CResult();
            string sqlCommand = "";

            try
            {
                this.OpenConnection();
                sqlCommand = string.Format(SqlQueries.GetQuery(Query.ModifyOrderkitchenTextStatus), orderID);//If order kitchen text i.e initial kitchen text is printed or not.
                this.ExecuteNonQuery(sqlCommand);
                oResult.IsSuccess = true;
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in UpdateOrderKitchenTextStatus()", LogLevel.Error, "Database");
                oResult.IsException = true;
            }
            finally
            {
                this.CloseConnection();
            }
            return oResult;
        }

        #endregion

        #region IOrderInfoDAO Members


        public CResult VoidOnlinePrintedItems(System.Collections.SortedList slPrintedList)
        {
            CResult oResult = new CResult();
            string sqlCommand = "";

            try
            {
                this.OpenConnection();

                foreach (COrderDetails objDetails in slPrintedList.Values)
                {
                    if (objDetails.OrderQuantity > 0)//If item is rest.
                    {
                        sqlCommand = string.Format(SqlQueries.GetQuery(Query.UpdateOnlineVoidItems), objDetails.OrderQuantity, objDetails.PrintedQuantity, objDetails.OrderAmount, objDetails.OnlineItemSequenceNumber);
                        this.ExecuteNonQuery(sqlCommand);
                    }
                    else
                    {
                        sqlCommand = string.Format(SqlQueries.GetQuery(Query.DeleteOnlineVoidItems), objDetails.OnlineItemSequenceNumber);
                        this.ExecuteNonQuery(sqlCommand);

                        sqlCommand = string.Format(SqlQueries.GetQuery(Query.DeleteLocalOrderVoidID), objDetails.OrderID);//Local order info table
                        this.ExecuteNonQuery(sqlCommand);
                    }
                }
                oResult.IsSuccess = true;
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in VoidPrintedItems()", LogLevel.Error, "Database");
                oResult.IsException = true;
            }
            finally
            {
                this.CloseConnection();
            }
            return oResult;
        }

        #endregion

        #region IOrderInfoDAO Members

        private OrderLogInformation ConvertLogInfo(IDataReader oReader, Int64 orderID)
        {
            OrderLogInformation tempOrderLogInfo = new OrderLogInformation();

                tempOrderLogInfo.OrderID = orderID;
                tempOrderLogInfo.FirstOrderTakenTime = Convert.ToInt64("0" + oReader["item_order_time"]);
                tempOrderLogInfo.FirstOrderPrintTime = Convert.ToInt64("0" + oReader["send_kitchen_time"]);
                tempOrderLogInfo.UserName = Convert.ToString(oReader["user_name"]);
                tempOrderLogInfo.BillPrintStatus = Convert.ToInt32("0" + oReader["guest_bill_print_status"]);
              
                tempOrderLogInfo.UserID = Convert.ToInt32("0" + oReader["user_id"]);

            return tempOrderLogInfo;
        }


        #endregion

        #region IOrderInfoDAO Members

        /// <summary>
        /// Changes the print status after printing for indicating whether the guest bill is printed or not.
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        public CResult ChangeGuestBillPrintStatus(long orderID)
        {
            CResult oResult = new CResult();
            string sqlCommand = "";

            try
            {
                this.OpenConnection();
      
                sqlCommand = string.Format(SqlQueries.GetQuery(Query.ChangeGuestBillPrintStatus), orderID);
                this.ExecuteNonQuery(sqlCommand);
                
                oResult.IsSuccess = true;
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in ChangeGuestBillPrintStatus()", LogLevel.Error, "Database");
                oResult.IsException = true;
            }
            finally
            {
                this.CloseConnection();
            }
            return oResult;
        }

        #endregion

        #region IOrderInfoDAO Members


        CResult IOrderInfoDAO.GetOrderLogInformation(long orderID)
        {
            CResult objResult = new CResult();
            List<OrderLogInformation> tempOrderLogInfoList = new List<OrderLogInformation>();
            int counter = 0;
            try
            {
                this.OpenConnection();
                string sqlCommand = String.Format(SqlQueries.GetQuery(Query.GetOrderLogInformation), orderID);
                IDataReader oReader = this.ExecuteReader(sqlCommand);
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        OrderLogInformation tempObject = new OrderLogInformation();
                        tempObject = ConvertLogInfo(oReader, orderID);
                        tempOrderLogInfoList.Add(tempObject);
                        counter++;
                    }
                    objResult.Data = tempOrderLogInfoList;
                }
            }
            catch (Exception ex)
            {
                Console.Write("###" + ex.ToString() + "###");
                Logger.Write("Exception : " + ex + " in GetOrderLogInformation()", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occured at GetOrderLogInformation()", ex);
                }
                else
                {
                    throw new Exception("Exception occure at GetOrderLogInformation()", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }
            return objResult;
        }

        #endregion

        #region IOrderInfoDAO Members


        public CResult GetOnlineOrderLogInformation(long orderID)
        {
            CResult objResult = new CResult();
            List<OrderLogInformation> tempOrderLogInfoList = new List<OrderLogInformation>();
            int counter = 0;
            try
            {
                this.OpenConnection();
                string sqlCommand = String.Format(SqlQueries.GetQuery(Query.GetOnlineOrderLogInformation), orderID);
                IDataReader oReader = this.ExecuteReader(sqlCommand);
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        OrderLogInformation tempObject = new OrderLogInformation();
                        tempObject = ConvertLogInfo(oReader, orderID);
                        tempOrderLogInfoList.Add(tempObject);
                        counter++;
                    }
                    objResult.Data = tempOrderLogInfoList;
                }
            }
            catch (Exception ex)
            {
                Console.Write("###" + ex.ToString() + "###");
                Logger.Write("Exception : " + ex + " in GetOrderLogInformation()", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occured at GetOrderLogInformation()", ex);
                }
                else
                {
                    throw new Exception("Exception occure at GetOrderLogInformation()", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }
            return objResult;
        }

        #endregion

        #region IOrderInfoDAO Members


        public CResult SaveOrderKitchenText(long inOrderID, string kitchenText, int printstatus)
        {
            CResult oResult = new CResult();
            string sqlCommand = "";
            string previousKitchenText = String.Empty;

            try
            {
                this.OpenConnection();
                sqlCommand = string.Format(SqlQueries.GetQuery(Query.SaveOrderKitchenText), inOrderID, kitchenText, printstatus);
                this.ExecuteNonQuery(sqlCommand);

                oResult.IsSuccess = true;
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in SaveOrderKitchenText()", LogLevel.Error, "Database");
                oResult.IsException = true;
            }
            finally
            {
                this.CloseConnection();
            }
            return oResult;
        }

        #endregion

        #region IOrderInfoDAO Members

        /// <summary>
        /// Collecting the kitchen text under an order ID
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        public CResult GetKitchenText(long orderID)
        {
            CResult objResult = new CResult();
            List<OrderLogInformation> tempOrderLogInfoList = new List<OrderLogInformation>();
            try
            {
                this.OpenConnection();
                string sqlCommand = String.Format(SqlQueries.GetQuery(Query.GetOrderPreviousKtText), orderID);
                IDataReader oReader = this.ExecuteReader(sqlCommand);
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        OrderLogInformation tempObject = new OrderLogInformation();
                        tempObject = ConvertKitchenTextInfo(oReader);
                        tempOrderLogInfoList.Add(tempObject);
                    }
                    objResult.Data = tempOrderLogInfoList;
                }
            }
            catch (Exception ex)
            {
                Console.Write("###" + ex.ToString() + "###");
                Logger.Write("Exception : " + ex + " in GetOrderLogInformation()", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occured at GetOrderLogInformation()", ex);
                }
                else
                {
                    throw new Exception("Exception occure at GetOrderLogInformation()", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }
            return objResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oReader"></param>
        /// <returns></returns>
        private OrderLogInformation ConvertKitchenTextInfo(IDataReader oReader)
        {
            OrderLogInformation tempOrderLogInfo = new OrderLogInformation();
            tempOrderLogInfo.KitchenText = Convert.ToString(oReader["kitchen_text"]);
            tempOrderLogInfo.KitchenTextPrintStatus = Convert.ToInt32("0" + oReader["print_status"]);
            return tempOrderLogInfo;
        }
        #endregion

        public string UpdateOrderInfoDAOForDelivary(string s,int orderid)
        {
            string sr = "Delivary UnSucess plz try again";
            try
            {
                this.OpenConnection();
                string sqlCOM = string.Format(SqlQueries.GetQuery(Query.UpdateOrderInfoDAOForDelivary), orderid, s);
                this.ExecuteNonQuery(sqlCOM);
                sr = "Delivary Sucessfully";

            }
            catch (Exception ex)
            {

                throw new Exception("UpdateOrderInfoDAOForDelivary()",ex);
            }

            return sr;
        }

        public string UpdateOrderComplementory(Int64 orderId, bool complentoryStatus)
        {
            string sr = "";
            try
            {
                this.OpenConnection();
                string sqlCOM = string.Format(SqlQueries.GetQuery(Query.UpdateOrderComplementory), orderId, complentoryStatus);
                this.ExecuteNonQuery(sqlCOM);

               sqlCOM = string.Format(SqlQueries.GetQuery(Query.UpdateOrderDetailsComplementory), orderId,0);
                this.ExecuteNonQuery(sqlCOM);
                sr = "Complementory Order Create Successfully";

            }
            catch (Exception ex)
            {

                throw new Exception("Something Error", ex);
            }

            return sr;
        }


        public string UpdateItemComplementory(Int64 orderDetailsId)
        {
            string sr = "";
            try
            {
                this.OpenConnection();


                string sqlCOM = string.Format(SqlQueries.GetQuery(Query.UpdateOrderDetailsItemComplementory), orderDetailsId, 0);
                this.ExecuteNonQuery(sqlCOM);
                sr = " Item Complementory Order Create Successfully";

            }
            catch (Exception ex)
            {

                throw new Exception("Something Error", ex);
            }

            return sr;
        }


        public string UpdateOrderVatComplementory(Int64 orderId, bool complentoryStatus)
        {
            string sr = "";
            try
            {
                this.OpenConnection();
                string sqlCOM = string.Format(SqlQueries.GetQuery(Query.UpdateOrderVatComplementory), orderId, complentoryStatus);
                this.ExecuteNonQuery(sqlCOM);

                sqlCOM = string.Format(SqlQueries.GetQuery(Query.UpdateOrderDetailsVatComplementory), orderId, 0);
                this.ExecuteNonQuery(sqlCOM);
                sr = "Complementory Order Create Successfully";

            }
            catch (Exception ex)
            {

                throw new Exception("Something Error", ex);
            }

            return sr;
        }

    }
}
