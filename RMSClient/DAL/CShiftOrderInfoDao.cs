using System;
using System.Collections.Generic;
using System.Text;
using RMS.Common.DataAccess;
using RMS.DataAccess;
using RMS.Common.ObjectModel;
using System.Data;
using RMS;
using System.Data.SqlClient;

namespace RMSClient.DataAccess
{
    public class CShiftOrderInfoDao : BaseDAO, IShiftOrderInfoDao
    {


        public RMS.Common.ObjectModel.CShiftOrderInfo AddShiftOrderInfo(RMS.Common.ObjectModel.CShiftOrderInfo shiftOrderInfo)
        {
            try
            {
                string insertSql = String.Format(SqlQueries.GetQuery(Query.AddShiftOrderInfo), shiftOrderInfo.ShiftID, shiftOrderInfo.OrderID, shiftOrderInfo.CreationDate, shiftOrderInfo.ShiftNo, shiftOrderInfo.PaymentCreationDate);

                this.ExecuteNonQuery(insertSql);
                this.CommitTransection();

                insertSql = "select max(ShiftOrderID) as ShiftOrderID from  ShiftOrderInfo";

                IDataReader oReader = this.ExecuteReader(insertSql);
                while (oReader.Read())
                {
                    shiftOrderInfo.ShiftOrderID = Int64.Parse(oReader["ShiftOrderID"].ToString());
                }

            }

            catch (Exception ex)
            {
                //  tempResult.IsException = true;
                this.RollBackTransection();

                Console.Write("###" + ex + "###");
                Logger.Write("Exception : " + ex + " in AddShiftOrderInfo()", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occure at AddShiftOrderInfo()", ex);
                }
                else
                {
                    throw new Exception("Exception occure at AddShiftOrderInfo()", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }

            return shiftOrderInfo;
        }

        public RMS.Common.ObjectModel.CShiftOrderInfo UpdateShiftOrderInfo(RMS.Common.ObjectModel.CShiftOrderInfo shiftOrderInfo)
        {
            try
            {
                string updateSql = String.Format(SqlQueries.GetQuery(Query.UpdateShiftOrderInfo), shiftOrderInfo.ShiftID, shiftOrderInfo.OrderID, shiftOrderInfo.CreationDate, shiftOrderInfo.ShiftNo, shiftOrderInfo.PaymentCreationDate, shiftOrderInfo.ShiftOrderID);

                this.ExecuteNonQuery(updateSql);
                this.CommitTransection();
              
            }

            catch (Exception ex)
            {              
                this.RollBackTransection();

                Console.Write("###" + ex + "###");
                Logger.Write("Exception : " + ex + " in UpdateShiftManage()", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occure at UpdateShiftManage()", ex);
                }
                else
                {
                    throw new Exception("Exception occure at UpdateShiftManage()", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }


            return shiftOrderInfo;
        }

        public bool DeleteShiftOrderInfo(long ShiftOrderID)
        {
            try
            {

                string deletSql = String.Format(SqlQueries.GetQuery(Query.DeleteShiftOrderInfo), ShiftOrderID);

                this.ExecuteNonQuery(deletSql);
                this.CommitTransection();

            }

            catch (Exception ex)
            {
                this.RollBackTransection();

                Console.Write("###" + ex + "###");

                Logger.Write("Exception : " + ex + " in DeleteShiftManage()", LogLevel.Error, "Database");

                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occure at DeleteShiftManage()", ex);
                }
                else
                {
                    throw new Exception("Exception occure at DeleteShiftManage()", ex);
                }

                return false;
            }
            finally
            {
                this.CloseConnection();
            }

            return true;
        }

        public List<RMS.Common.ObjectModel.CShiftOrderInfo> GetAllShiftOrderInfo()
        {
            List<CShiftOrderInfo> shiftorderList = new List<CShiftOrderInfo>();

            string sSql = SqlQueries.GetQuery(Query.GetAllShiftOrderInfo);

            try
            {
                this.OpenConnection();
                IDataReader oReader = this.ExecuteReader(sSql);

                while (oReader.Read())
                {
                    CShiftOrderInfo shiftSchedule = new CShiftOrderInfo();

                    shiftSchedule = ReaderToShiftOrder(oReader);

                    shiftorderList.Add(shiftSchedule);
                }

            }

            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in GetAllShiftManage()", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occured at GetAllShiftManage()", ex);
                }
                else
                {
                    throw new Exception("Exception occure at GetAllShiftManage()", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }

            return shiftorderList;
        }

        public RMS.Common.ObjectModel.CShiftOrderInfo GetAllShiftOrderInfoID(long ShiftOrderID)
        {
            CShiftOrderInfo shiftSchedule = new CShiftOrderInfo();

            string sSql = String.Format(SqlQueries.GetQuery(Query.GetAllShiftOrderInfoID), ShiftOrderID);

            try
            {

                this.OpenConnection();
                IDataReader oReader = this.ExecuteReader(sSql);


                while (oReader.Read())
                {
                    shiftSchedule = ReaderToShiftOrder(oReader);

                }


            }

            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in GetAllShiftManageByShiftID()", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occured at GetAllShiftManageByShiftID()", ex);
                }
                else
                {
                    throw new Exception("Exception occure at GetAllShiftManageByShiftID()", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }


            return shiftSchedule;
        }

          public List<CShiftOrderInfo> GetAllShiftOrderInfoByPaymentcreationDate(DateTime paymentcreationDate)
        {
                List<CShiftOrderInfo> shiftorderList = new List<CShiftOrderInfo>();
                DateTime toDate = new DateTime(paymentcreationDate.Year, paymentcreationDate.Month, paymentcreationDate.Day, 23, 59, 59);

                string sSql = String.Format(SqlQueries.GetQuery(Query.GetAllShiftOrderInfoByPaymentcreationDate), paymentcreationDate, toDate);

              
            try
            {
                this.OpenConnection();
                IDataReader oReader = this.ExecuteReader(sSql);

                while (oReader.Read())
                {
                    CShiftOrderInfo shiftSchedule = new CShiftOrderInfo();

                    shiftSchedule = ReaderToShiftOrder(oReader);

                    shiftorderList.Add(shiftSchedule);
                }

            }

            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in GetAllShiftManage()", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occured at GetAllShiftManage()", ex);
                }
                else
                {
                    throw new Exception("Exception occure at GetAllShiftManage()", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }

            return shiftorderList;           
        }

        private CShiftOrderInfo ReaderToShiftOrder(IDataReader inReader)
        {
            CShiftOrderInfo tempShiftSOrder = new CShiftOrderInfo();

            if (inReader["ShiftOrderID"] != null)
                tempShiftSOrder.ShiftOrderID = Int64.Parse(inReader["ShiftOrderID"].ToString());

            if (inReader["shiftID"] != null)
                tempShiftSOrder.ShiftID = Int64.Parse(inReader["shiftID"].ToString());

            if (inReader["orderID"] != null)
                tempShiftSOrder.OrderID = Int64.Parse(inReader["orderID"].ToString());

            if (inReader["creationDate"] != null)
                tempShiftSOrder.CreationDate = DateTime.Parse(inReader["creationDate"].ToString());

            if (inReader["shiftNo"] != null)
                tempShiftSOrder.ShiftNo = Int32.Parse(inReader["shiftNo"].ToString());


            if (inReader["paymentcreationDate"] != null)
                tempShiftSOrder.PaymentCreationDate = DateTime.Parse(inReader["paymentcreationDate"].ToString());

            return tempShiftSOrder;

        }
        
      
    }
}
