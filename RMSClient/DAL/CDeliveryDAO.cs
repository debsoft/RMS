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
    public class CDeliveryDAO : BaseDAO, IDeliveryDAO
    {
        public CResult InsertDelivery(CDelivery inDelivery)
        {
            CResult oResult = new CResult();

            try
            {
                this.OpenConnection();
                string sqlCommand = String.Format(SqlQueries.GetQuery(Query.InsertDelivery),inDelivery.DeliveryOrderID,inDelivery.DeliveryTime);
                this.ExecuteNonQuery(sqlCommand);
                oResult.IsSuccess = true;
            }

            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in InsertDeposit()", LogLevel.Error, "Database");
                oResult.IsException = true;
            }
            finally
            {
                this.CloseConnection();
            }

            return oResult;
        }

        #region IDeliveryDAO Members


        public CResult GetDelivery(CDelivery inDelivery)
        {
            CResult tempcResult = new CResult();
            try
            {
                this.OpenConnection();
                string sqlCommand =string.Format(SqlQueries.GetQuery(Query.GetdeliveryTime),inDelivery.DeliveryOrderID);
                IDataReader oReader = this.ExecuteReader(sqlCommand);
                CDelivery objDelivery=new CDelivery();
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        objDelivery.DeliveryTime = Convert.ToString(oReader["delivery_time"]);
                        objDelivery.DeliveryOrderID = inDelivery.DeliveryOrderID;
                        tempcResult.Data = objDelivery;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("###" + ex.ToString() + "###");
                Logger.Write("Exception : " + ex.Message + " in GetDelivery()", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occured at GetAllCategory3()", ex);
                }
                else
                {
                    throw new Exception("Exception occured at GetAllCategory3()", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }


            return tempcResult;
        }

        #endregion

        #region IDeliveryDAO Members

        /// <summary>
        /// This function modifies the delivery information
        /// </summary>
        /// <param name="inDelivery"></param>
        /// <returns></returns>
        public CResult UpdateDeliveryInfo(CDelivery inDelivery)
        {
            CResult oResult = new CResult();
            try
            {
                if (inDelivery != null)
                {
                    CResult objCresult = this.GetDelivery(inDelivery);
                    CDelivery objDelivery = (CDelivery)objCresult.Data;
                    if (objDelivery != null)
                    {
                        this.OpenConnection();
                        string sqlCommand = String.Format(SqlQueries.GetQuery(Query.UpdateDeliveryInfo), inDelivery.DeliveryOrderID, inDelivery.DeliveryTime);
                        this.ExecuteNonQuery(sqlCommand);
                    }
                    else
                    {
                        this.InsertDelivery(inDelivery);
                    }
                }
                else
                {
                    this.OpenConnection();
                    string sSql = String.Format("delete ", inDelivery.DeliveryOrderID, inDelivery.DeliveryTime);
                    this.ExecuteNonQuery(sSql);
                }

                oResult.IsSuccess = true;
            }

            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in UpdateDeliveryInfo()", LogLevel.Error, "Database");
                oResult.IsException = true;
            }
            finally
            {
                this.CloseConnection();
            }
            return oResult;
        }

        #endregion

        #region IDeliveryDAO Members


        public CResult DeleteDeliveryInfo(long orderID)
        {
            CResult oResult = new CResult();

            try
            {
                this.OpenConnection();
                string sqlCommand = String.Format("delete from delivery where order_id={0}", orderID);
                this.ExecuteNonQuery(sqlCommand);
                oResult.IsSuccess = true;
            }

            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in DeleteDeliveryInfo()", LogLevel.Error, "Database");
                oResult.IsException = true;
            }
            finally
            {
                this.CloseConnection();
            }

            return oResult;
        }

        #endregion
    }
}
