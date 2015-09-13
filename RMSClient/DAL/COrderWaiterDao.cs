using System;
using System.Collections.Generic;
using System.Text;
using RMS.Common.DataAccess;
using RMS.Common.ObjectModel;
using RMS.DataAccess;
using System.Data;
using RMS;

namespace RMSClient.DataAccess
{
    public class COrderWaiterDao : BaseDAO, IOrderwaiterDao
    {
        public RMS.Common.ObjectModel.COrderwaiter InsertOrderwaiter(RMS.Common.ObjectModel.COrderwaiter orderwaiter)
        {           
            orderwaiter.WaiterName = orderwaiter.WaiterName.Replace("''", "'");
            orderwaiter.WaiterName = orderwaiter.WaiterName.Replace("'", "''");

            try
            {
                this.OpenConnectionWithTransection();

                string sqlCommand = string.Format(SqlQueries.GetQuery(Query.InsertWaiterOrder), orderwaiter.WaiterID, orderwaiter.WaiterName, orderwaiter.OrderID);

                this.ExecuteNonQuery(sqlCommand);

                sqlCommand = SqlQueries.GetQuery(Query.ScopeIdentity);

                IDataReader oReader = this.ExecuteReader(sqlCommand);
                if (oReader != null)
                {
                    bool bIsRead = oReader.Read();
                    if (bIsRead)
                    {

                        orderwaiter.ID = Int64.Parse(oReader[0].ToString());
                    }
                    oReader.Close();
                }

               

                this.CommitTransection();

            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in InsertOrderwaiter()", LogLevel.Error, "Database");
                RollBackTransection();
                throw new Exception("Exception occured at InsertOrderwaiter()", ex);

            }
            finally
            {
                this.CloseConnection();
            }

            return orderwaiter;
        }

        public RMS.Common.ObjectModel.COrderwaiter UpdateOrderwaiter(RMS.Common.ObjectModel.COrderwaiter orderwaiter)
        {
            orderwaiter.WaiterName = orderwaiter.WaiterName.Replace("''", "'");
            orderwaiter.WaiterName = orderwaiter.WaiterName.Replace("'", "''");

            try
            {
                this.OpenConnectionWithTransection();

                string sqlCommand = string.Format(SqlQueries.GetQuery(Query.UpdateWaiterOrder), orderwaiter.WaiterID, orderwaiter.WaiterName, orderwaiter.OrderID);

                this.ExecuteNonQuery(sqlCommand);

                this.CommitTransection();

            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in InsertOrderwaiter()", LogLevel.Error, "Database");
                RollBackTransection();
                throw new Exception("Exception occured at InsertOrderwaiter()", ex);

            }
            finally
            {
                this.CloseConnection();
            }

            return orderwaiter;
        }

        public bool DeleteOrderwaiter(long orderID)
        {
            try
            {
                this.OpenConnectionWithTransection();

                string sqlCommand = string.Format(SqlQueries.GetQuery(Query.DeleteWaiterOrderbyOrderID), orderID);

                this.ExecuteNonQuery(sqlCommand);

                this.CommitTransection();

            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in InsertOrderwaiter()", LogLevel.Error, "Database");
                RollBackTransection();
                throw new Exception("Exception occured at InsertOrderwaiter()", ex);

            }
            finally
            {
                this.CloseConnection();
            }

            return true;
        }

        public RMS.Common.ObjectModel.COrderwaiter GetOrderwaiterByOrderID(long inOrderID)
        {
            COrderwaiter tempOrderWaiter = new COrderwaiter();

            try
            {
                this.OpenConnection();
                string sSql = string.Format(SqlQueries.GetQuery(Query.GetWaiterOrderByOrderID), inOrderID);

                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        tempOrderWaiter = ReaderToOrderWaiter(oReader);
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

            return tempOrderWaiter;
        }

        public RMS.Common.ObjectModel.COrderwaiter GetOrderwaiterBywaiterID(long inOrderID)
        {
            throw new NotImplementedException();
        }

        public List<RMS.Common.ObjectModel.COrderwaiter> GetAllOrderwaiter()
        {
            List<RMS.Common.ObjectModel.COrderwaiter> orderWaiterList = new List<COrderwaiter>();
            COrderwaiter tempOrderWaiter = new COrderwaiter();

            try
            {
                this.OpenConnection();
                string sSql = string.Format(SqlQueries.GetQuery(Query.GetAllWaiterOrder));

                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        tempOrderWaiter = new COrderwaiter();

                        tempOrderWaiter = ReaderToOrderWaiter(oReader);

                        orderWaiterList.Add(tempOrderWaiter);
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

            return orderWaiterList;
        }


        private COrderwaiter ReaderToOrderWaiter(IDataReader inReader)//Changed
        {
            COrderwaiter tempOrderWaiter = new COrderwaiter();

            if (inReader["id"] != null)
                tempOrderWaiter.ID = Int64.Parse(inReader["id"].ToString());

            if (inReader["id"] != null)
                tempOrderWaiter.WaiterID = Int64.Parse(inReader["waiterID"].ToString());

            if (inReader["waiterName"] != null)
                tempOrderWaiter.WaiterName = inReader["waiterName"].ToString();

            if (inReader["orderID"] != null)
                tempOrderWaiter.OrderID = Int64.Parse(inReader["orderID"].ToString());

            return tempOrderWaiter;
        }
    }
}
