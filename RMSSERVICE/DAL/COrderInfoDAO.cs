using System;
using System.Collections.Generic;
using System.Text;
using RMS.DataAccess;
using RMS.Common.DataAccess;
using RMS.Common.ObjectModel;
using System.Data;
using System.Data.SqlClient;


namespace RMS.DataAccess
{
    public class COrderInfoDAO : BaseDAO, IOrderInfoDAO
    {
        #region IOrderInfoDAO members

        //public COrderInfo OrderInfoInsert(COrderInfo inOrderInfo)// Changed
        //{
        //    COrderInfo tempOrderInfo = inOrderInfo;
        //    inOrderInfo.TableName = inOrderInfo.TableName.Replace("''", "'");
        //    inOrderInfo.TableName = inOrderInfo.TableName.Replace("'", "''");

        //     try
        //     {
        //         this.OpenConnection();
        //         //string sSql = string.Format(SqlQueries.GetQuery(Query.OrderInfoInsert),
        //         //    inOrderInfo.CustomerID,inOrderInfo.UserID,inOrderInfo.OrderType,inOrderInfo.OrderTime,inOrderInfo.Status,inOrderInfo.GuestCount,inOrderInfo.TableNumber,inOrderInfo.TableName,inOrderInfo.SerialNo);

        //         string sSql = string.Format(SqlQueries.GetQuery(Query.OrderInfoInsert),
        //             inOrderInfo.CustomerID,inOrderInfo.UserID,inOrderInfo.OrderType,inOrderInfo.OrderTime.Ticks,inOrderInfo.Status,inOrderInfo.GuestCount,inOrderInfo.TableNumber,inOrderInfo.TableName,inOrderInfo.SerialNo);

        //         this.ExecuteNonQuery(sSql);

        //         sSql = SqlQueries.GetQuery(Query.ScopeIdentity);

        //         IDataReader oReader = this.ExecuteReader(sSql);
        //         if (oReader != null)
        //         {
        //             bool bIsRead = oReader.Read();
        //             if (bIsRead)
        //             {

        //                 tempOrderInfo.OrderID = Int64.Parse(oReader[0].ToString());
        //             }
        //         }
        //     }
        //     catch (Exception ex)
        //     {
        //         Logger.Write("Exception : " + ex + " in OrderInfoInsert()", LogLevel.Error, "Database");

        //         throw new Exception("Exception occure at OrderInfoInsert()", ex);
        //     }
        //     finally
        //     {
        //         this.CloseConnection();
        //     }

        //     return tempOrderInfo;
        //}

        //public void OrderInfoUpdate(COrderInfo inOrderInfo)//Changed
        //{

        //    inOrderInfo.TableName = inOrderInfo.TableName.Replace("''", "'");
        //    inOrderInfo.TableName = inOrderInfo.TableName.Replace("'", "''");

        //    try
        //    {
        //        this.OpenConnection();
        //        //string sSql = string.Format(SqlQueries.GetQuery(Query.OrderInfoUpdate),
        //        //    inOrderInfo.CustomerID, inOrderInfo.UserID, inOrderInfo.OrderType, inOrderInfo.OrderTime, inOrderInfo.Status, inOrderInfo.GuestCount, inOrderInfo.TableNumber, inOrderInfo.TableName,inOrderInfo.SerialNo,inOrderInfo.OrderID);

        //        string sSql = string.Format(SqlQueries.GetQuery(Query.OrderInfoUpdate),
        //            inOrderInfo.CustomerID, inOrderInfo.UserID, inOrderInfo.OrderType, inOrderInfo.OrderTime.Ticks, inOrderInfo.Status, inOrderInfo.GuestCount, inOrderInfo.TableNumber, inOrderInfo.TableName, inOrderInfo.SerialNo, inOrderInfo.OrderID);

        //        this.ExecuteNonQuery(sSql);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.Write("###"+ex.ToString()+"###");
        //        Logger.Write("Exception : " + ex + " in OrderInfoUpdate()", LogLevel.Error, "Database");

        //        throw new Exception("Exception occure at OrderInfoUpdate()", ex);
        //    }
        //    finally
        //    {
        //        this.CloseConnection();
        //    }

            
        //}


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

        public void OrderInfoUpdate(COrderInfo inOrderInfo)//Changed
        {

            inOrderInfo.TableName = inOrderInfo.TableName.Replace("''", "'");
            inOrderInfo.TableName = inOrderInfo.TableName.Replace("'", "''");

            try
            {
                this.OpenConnection();
                //string sSql = string.Format(SqlQueries.GetQuery(Query.OrderInfoUpdate),
                // inOrderInfo.CustomerID, inOrderInfo.UserID, inOrderInfo.OrderType, inOrderInfo.OrderTime, inOrderInfo.Status, inOrderInfo.GuestCount, inOrderInfo.TableNumber, inOrderInfo.TableName,inOrderInfo.SerialNo,inOrderInfo.OrderID);

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
        //public COrderInfo GetOrderInfoByOrderID(Int64 inOrderID)
        //{
        //    COrderInfo tempOrderInfo = new COrderInfo();

        //    try
        //    {
        //        this.OpenConnection();
        //        string sSql = string.Format(SqlQueries.GetQuery(Query.OrderInfoGetByOrderID),inOrderID);

        //        IDataReader oReader = this.ExecuteReader(sSql);
        //        if (oReader != null)
        //        {
        //            while (oReader.Read())
        //            {
        //                tempOrderInfo = ReaderToOrderInfo(oReader);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.Write("###"+ex.ToString()+"###");
        //        Logger.Write("Exception : " + ex + " in GetOrderInfoByOrderID()", LogLevel.Error, "Database");

        //        throw new Exception("Exception occure at GetOrderInfoByOrderID()", ex);
        //    }
        //    finally
        //    {
        //        this.CloseConnection();
        //    }

        //    return tempOrderInfo;
        //}

        //public void InsertOrderSeatTime(COrderSeatTime inOrderSeatTime)
        //{
        //    try
        //    {
        //        this.OpenConnection();
        //        //string sSql = string.Format(SqlQueries.GetQuery(Query.OrderSeatTimeInsert),
        //        //    inOrderSeatTime.OrderID,inOrderSeatTime.SeatTime);

        //        string sSql = string.Format(SqlQueries.GetQuery(Query.OrderSeatTimeInsert),
        //            inOrderSeatTime.OrderID, inOrderSeatTime.SeatTime.Ticks);

        //        this.ExecuteNonQuery(sSql);
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.Write("Exception : " + ex + " in InsertOrderSeatTime()", LogLevel.Error, "Database");

        //        throw new Exception("Exception occure at InsertOrderSeatTime()", ex);
        //    }
        //    finally
        //    {
        //        this.CloseConnection();
        //    }
        //}

        //public COrderSeatTime OrderSeatTimeByOrderID(Int64 inOrderID)
        //{
        //    COrderSeatTime tempOrderSeatTime = new COrderSeatTime();

        //    try
        //    {
        //        this.OpenConnection();
        //        string sSql = string.Format(SqlQueries.GetQuery(Query.OrderSeatTimeByOrderID), inOrderID);

        //        IDataReader oReader = this.ExecuteReader(sSql);
        //        if (oReader != null)
        //        {
        //            while (oReader.Read())
        //            {
        //                tempOrderSeatTime = ReaderToOrderSeatTime(oReader);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.Write("###" + ex.ToString() + "###");
        //        Logger.Write("Exception : " + ex + " in OrderSeatTimeByOrderID()", LogLevel.Error, "Database");

        //        throw new Exception("Exception occure at OrderSeatTimeByOrderID()", ex);
        //    }
        //    finally
        //    {
        //        this.CloseConnection();
        //    }

        //    return tempOrderSeatTime;
        //}

        //public CResult OrderDetailsGetByOrderID(Int64 inOrderID)
        //{
        //    CResult oResult = new CResult();

        //    List<COrderDetails> tempOrderDetailsList = new List<COrderDetails>();
        //    try
        //    {
        //        this.OpenConnection();
        //        string sSql = String.Format(SqlQueries.GetQuery(Query.OrderDetailsGetByOrderId), inOrderID.ToString());
        //        IDataReader oReader = this.ExecuteReader(sSql);
        //        if (oReader != null)
        //        {
        //            while (oReader.Read())
        //            {
        //                COrderDetails tempOrderDetails = ReaderToOrderDetails(oReader);
        //                tempOrderDetailsList.Add(tempOrderDetails);

        //            }
        //        }

        //        oResult.Data = tempOrderDetailsList;

        //        oResult.IsSuccess = true;


        //    }
        //    catch (Exception ex)
        //    {
        //        Console.Write("###" + ex.ToString() + "###");
        //        Logger.Write("Exception : " + ex + " in OrderDetailsGetByOrderID()", LogLevel.Error, "Database");
        //        if (ex.GetType().Equals(typeof(SqlException)))
        //        {
        //            SqlException oSQLEx = ex as SqlException;
        //            if (oSQLEx.Number != 7619)
        //                throw new Exception("Exception occured at OrderDetailsGetByOrderID()", ex);
        //        }
        //        else
        //        {
        //            throw new Exception("Exception occure at OrderDetailsGetByOrderID()", ex);
        //        }
        //    }
        //    finally
        //    {
        //        this.CloseConnection();
        //    }
        //    return oResult;
        //}

        //public CResult InsertOrderArchive(COrderInfo inOrderInfo)//Changed
        //{
        //    CResult oNewResult = new CResult();

        //    COrderInfo tempOrderInfo = inOrderInfo;
        //    inOrderInfo.TableName = inOrderInfo.TableName.Replace("''", "'");
        //    inOrderInfo.TableName = inOrderInfo.TableName.Replace("'", "''");

        //    try
        //    {
        //        //this.OpenConnection();

        //        this.OpenConnectionWithTransection();

        //        string sSql = string.Format(SqlQueries.GetQuery(Query.DeleteOrderByID), inOrderInfo.OrderID);

        //        this.ExecuteNonQuery(sSql);

        //        //sSql = string.Format(SqlQueries.GetQuery(Query.OrderInfoArchieveInsert),inOrderInfo.OrderID,
        //        //    inOrderInfo.CustomerID, inOrderInfo.UserID, inOrderInfo.OrderType, inOrderInfo.OrderTime, inOrderInfo.Status, inOrderInfo.GuestCount, inOrderInfo.TableNumber, inOrderInfo.TableName, inOrderInfo.SerialNo);

        //        sSql = string.Format(SqlQueries.GetQuery(Query.OrderInfoArchieveInsert), inOrderInfo.OrderID,
        //            inOrderInfo.CustomerID, inOrderInfo.UserID, inOrderInfo.OrderType, inOrderInfo.OrderTime.Ticks, inOrderInfo.Status, inOrderInfo.GuestCount, inOrderInfo.TableNumber, inOrderInfo.TableName, inOrderInfo.SerialNo);

        //        this.ExecuteNonQuery(sSql);

        //        this.CommitTransection();

        //    }
        //    catch (Exception ex)
        //    {
        //        //Console.Write("###" + ex.ToString() + "###");

        //        this.RollBackTransection();
        //        Logger.Write("Exception : " + ex + " in InsertOrderArchive()", LogLevel.Error, "Database");
        //        if (ex.GetType().Equals(typeof(SqlException)))
        //        {
        //            SqlException oSQLEx = ex as SqlException;
        //            if (oSQLEx.Number != 7619)
        //                throw new Exception("Exception occured at InsertOrderArchive()", ex);
        //        }
        //        else
        //        {
        //            throw new Exception("Exception occure at InsertOrderArchive()", ex);
        //        }
        //    }
        //    finally
        //    {
        //        this.CloseConnection();
        //    }

        //    return oNewResult;
        //}

        //public CResult InsertOrderDetailsArchive(Int64 inOrderID)
        //{
        //    CResult oNewResult = new CResult();

        //    try
        //    {

        //        //COrderDetails tempOrderDetails = inOrderDetails;

        //        CResult oResult = OrderDetailsGetByOrderID(inOrderID);

        //        this.OpenConnectionWithTransection();

        //        if (oResult.IsSuccess && oResult.Data != null)
        //        {
        //            List<COrderDetails> oTempList = (List<COrderDetails>)oResult.Data;

        //            for (int i = 0; i < oTempList.Count; i++)
        //            {
        //                COrderDetails oOrderDetails = oTempList[i];

        //                String sTempSql = String.Format(SqlQueries.GetQuery(Query.OrderDetailsDelete), oOrderDetails.OrderDetailsID);
        //                this.ExecuteNonQuery(sTempSql);
        //            }

        //            for (int i = 0; i < oTempList.Count; i++)
        //            {
        //                COrderDetails oOrderDetails = oTempList[i];

        //                oOrderDetails.OrderRemarks = oOrderDetails.OrderRemarks.Replace("''", "'");
        //                oOrderDetails.OrderRemarks = oOrderDetails.OrderRemarks.Replace("'", "''");


        //                String sSql = String.Format(SqlQueries.GetQuery(Query.OrderDetailsArchieveInsert),oOrderDetails.OrderDetailsID,
        //             oOrderDetails.OrderID, oOrderDetails.ProductID, oOrderDetails.OrderQuantity, oOrderDetails.OrderAmount, oOrderDetails.OrderRemarks, oOrderDetails.OrderFoodType, oOrderDetails.CategoryLevel);
        //                this.ExecuteNonQuery(sSql);

        //            }

        //            this.CommitTransection();

        //            oNewResult.IsSuccess = true;
        //        }

        //    }

        //    catch (Exception ex)
        //    {
        //        Logger.Write("Exception : " + ex + " in OrderDetailsInsert()", LogLevel.Error, "Database");

        //        //throw new Exception("Exception occure at OrderDetailsInsert()", ex);

        //        this.RollBackTransection();
        //    }
        //    finally
        //    {
        //        this.CloseConnection();
        //    }

        //    return oNewResult;



        //}

        #endregion


        private COrderInfo ReaderToOrderInfo(IDataReader inReader)//Changed
        {
            COrderInfo tempOrderInfo = new COrderInfo();

            if (inReader["order_id"] != null)
                tempOrderInfo.OrderID = int.Parse(inReader["order_id"].ToString());

            if (inReader["customer_id"] != null)
                tempOrderInfo.CustomerID = int.Parse(inReader["customer_id"].ToString());

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

            //if (inReader["serial_no"] != null)
            //    tempOrderInfo.SerialNo = new Guid(inReader["serial_no"].ToString());

            return tempOrderInfo;

        }

        //private COrderSeatTime ReaderToOrderSeatTime(IDataReader inReader)//Changed
        //{
        //    COrderSeatTime tempOrderSeatTime = new COrderSeatTime();

        //    if (inReader["order_id"] != null)
        //        tempOrderSeatTime.OrderID = Int64.Parse(inReader["order_id"].ToString());

        //    if (inReader["seat_time"] != null)
        //        //tempOrderSeatTime.SeatTime = DateTime.Parse(inReader["seat_time"].ToString());
        //        tempOrderSeatTime.SeatTime = new DateTime(Int64.Parse(inReader["seat_time"].ToString()));

        //    return tempOrderSeatTime;
        //}
        private COrderDetails ReaderToOrderDetails(IDataReader inReader)
        {
            COrderDetails tempOrderDetails = new COrderDetails();

            if (inReader["order_detail_id"] != null)
                tempOrderDetails.OrderDetailsID = int.Parse(inReader["order_detail_id"].ToString());

            if (inReader["order_id"] != null)
                tempOrderDetails.OrderID = int.Parse(inReader["order_id"].ToString());

            if (inReader["product_id"] != null)
                tempOrderDetails.ProductID = Int32.Parse(inReader["product_id"].ToString());

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

            return tempOrderDetails;

        }
    }
}
