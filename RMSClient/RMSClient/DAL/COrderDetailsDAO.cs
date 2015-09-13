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
    public class COrderDetailsDAO : BaseDAO, IOrderDetailsDAO
    {
        #region IOrderDetails members

        public COrderDetails OrderDetailsInsert(COrderDetails inOrderDetails)
        {
            COrderDetails tempOrderDetails = inOrderDetails;

            inOrderDetails.OrderRemarks = inOrderDetails.OrderRemarks.Replace("''", "'");
            inOrderDetails.OrderRemarks = inOrderDetails.OrderRemarks.Replace("'", "''");

            try
            {

                this.OpenConnection();
                string sSql = string.Format(SqlQueries.GetQuery(Query.OrderDetailsInsert),
                    inOrderDetails.OrderID, inOrderDetails.ProductID, inOrderDetails.OrderQuantity, inOrderDetails.OrderAmount, inOrderDetails.OrderRemarks, inOrderDetails.OrderFoodType, inOrderDetails.CategoryLevel);

                this.ExecuteNonQuery(sSql);
                sSql = SqlQueries.GetQuery(Query.ScopeIdentity);

                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    bool bIsRead = oReader.Read();
                    if (bIsRead)
                    {

                        tempOrderDetails.OrderDetailsID = Int64.Parse(oReader[0].ToString());
                    }
                }

            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in OrderDetailsInsert()", LogLevel.Error, "Database");

                throw new Exception("Exception occure at OrderDetailsInsert()", ex);
            }
            finally
            {
                this.CloseConnection();
            }

            return tempOrderDetails;

        }

        public void OrderDetailsUpdate(COrderDetails inOrderDetails)
        {
            inOrderDetails.OrderRemarks = inOrderDetails.OrderRemarks.Replace("''", "'");
            inOrderDetails.OrderRemarks = inOrderDetails.OrderRemarks.Replace("'", "''");
            try
            {
                this.OpenConnection();
                string sSql = string.Format(SqlQueries.GetQuery(Query.OrderDetailsUpdate),
                    inOrderDetails.OrderID, inOrderDetails.ProductID, inOrderDetails.OrderQuantity, inOrderDetails.OrderAmount, inOrderDetails.OrderRemarks, inOrderDetails.OrderFoodType, inOrderDetails.CategoryLevel, inOrderDetails.OrderDetailsID);

                this.ExecuteNonQuery(sSql);
            }
            catch (Exception ex)
            {
                Console.Write("###" + ex.ToString() + "###");
                Logger.Write("Exception : " + ex + " in OrderDetailsUpdate()", LogLevel.Error, "Database");

                throw new Exception("Exception occure at OrderDetailsUpdate()", ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void OrderDetailsDelete(Int64 inOrderDetailsID)
        {
            try
            {
                this.OpenConnection();
                string sSql = string.Format(SqlQueries.GetQuery(Query.OrderDetailsDelete),
                    inOrderDetailsID);

                this.ExecuteNonQuery(sSql);
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in OrderDetailsDelete()", LogLevel.Error, "Database");

                throw new Exception("Exception occure at OrderDetailsDelete()", ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public List<COrderDetails> OrderDetailsGetAll()
        {
            List<COrderDetails> tempOrderDetailsList = new List<COrderDetails>();
            try
            {
                this.OpenConnection();
                string sSql = SqlQueries.GetQuery(Query.OrderDetailsGetAll);
                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        COrderDetails tempOrderDetails = ReaderToOrderDetails(oReader);
                        tempOrderDetailsList.Add(tempOrderDetails);

                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in GetOrderDetailsAll()", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occured at GetOrderDetailsAll()", ex);
                }
                else
                {
                    throw new Exception("Exception occure at GetOrderDetailsAll()", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }
            return tempOrderDetailsList;
        }

        public CResult OrderDetailsGetByOrderID(Int64 inOrderID)
        {
            CResult tempResult = new CResult();
            List<COrderDetails> tempOrderDetailsList = new List<COrderDetails>();
            try
            {
                this.OpenConnection();
                string sSql = String.Format(SqlQueries.GetQuery(Query.OrderDetailsGetByOrderId), inOrderID);
                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        COrderDetails tempOrderDetails = ReaderToOrderDetails(oReader);
                        tempOrderDetailsList.Add(tempOrderDetails);

                    }
                }
                tempResult.Data = tempOrderDetailsList;
                tempResult.IsSuccess = true;
            }
            catch (Exception ex)
            {
                tempResult.IsException = true;
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
            return tempResult;
        }

        public CResult OrderDetailsArchiveGetByOrderID(Int64 inOrderID) //New Added
        {
            CResult tempResult = new CResult();
            List<COrderDetails> tempOrderDetailsList = new List<COrderDetails>();
            try
            {
                this.OpenConnection();
                string sSql = String.Format(SqlQueries.GetQuery(Query.OrderDetailsArchiveGetByOrderId), inOrderID);
                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        COrderDetails tempOrderDetails = ReaderToOrderDetails(oReader);
                        tempOrderDetailsList.Add(tempOrderDetails);

                    }
                }
                tempResult.Data = tempOrderDetailsList;
                tempResult.IsSuccess = true;
            }
            catch (Exception ex)
            {
                tempResult.IsException = true;
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
            return tempResult;
        }

        public COrderDetails OrderDetailsGetByOrderDetailID(Int64 inOrderDetailID)
        {
            COrderDetails tempOrderDetails = new COrderDetails();
            try
            {
                this.OpenConnection();
                string sSql = String.Format(SqlQueries.GetQuery(Query.OrderDetailsGetByOrderDetailID), inOrderDetailID.ToString());
                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        tempOrderDetails = ReaderToOrderDetails(oReader);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write("###" + ex.ToString() + "###");
                Logger.Write("Exception : " + ex + " in OrderDetailsGetByOrderDetailID()", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occured at OrderDetailsGetByOrderDetailID()", ex);
                }
                else
                {
                    throw new Exception("Exception occure at OrderDetailsGetByOrderDetailID()", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }
            return tempOrderDetails;
        }

        #endregion

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
