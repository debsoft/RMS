using System;
using System.Collections.Generic;
using System.Text;
using RMS.DataAccess;
using RMS.Common.DataAccess;
using RMS.Common.ObjectModel;
using RMS;
using System.Data;
using System.Data.SqlClient;

namespace RMSClient.DataAccess
{
   public class FinishedRawProductListDAO : BaseDAO,IFinishedRawProductListDAO
    {
        public CFinishedRawProductList FinishedRawProductListInsert(CFinishedRawProductList finishedRawProductList)
        {
            if (ISDuplicate(finishedRawProductList.FinishedProductID, finishedRawProductList.RawProductID))
            {
                throw new Exception("This product alredy exits in Finished Product");
            }

            try
            {

                this.OpenConnection();
                string sqlCommand = String.Format(SqlQueries.GetQuery(Query.FinishedRawProductListInsert), 
                    finishedRawProductList.FinishedProductID, finishedRawProductList.RawProductID, 
                    finishedRawProductList.RawProductName, finishedRawProductList.Qnty, finishedRawProductList.Remarks,finishedRawProductList.InsType);
                this.ExecuteNonQuery(sqlCommand);

            }

            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in InsertDeposit()", LogLevel.Error, "Database");

                return null;
            }
            finally
            {
                this.CloseConnection();
            }

            return finishedRawProductList;
        }


        #region FinishedRawProductListUpdate
        public CFinishedRawProductList FinishedRawProductListUpdate(CFinishedRawProductList finishedRawProductList)
        {
            try
            {
                this.OpenConnection();
                string sqlCommand = String.Format(SqlQueries.GetQuery(Query.FinishedRawProductListUpdate),
                    finishedRawProductList.FinishedProductID,  finishedRawProductList.RawProductID, 
                    finishedRawProductList.RawProductName, finishedRawProductList.Qnty,
                    finishedRawProductList.Remarks, finishedRawProductList.ID,finishedRawProductList.InsType);
                this.ExecuteNonQuery(sqlCommand);
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in FinishedRawProductListUpdate()", LogLevel.Error, "Database");
            }
            finally
            {
                this.CloseConnection();
            }

            return finishedRawProductList;
        }
        #endregion


        public bool FinishedRawProductListDelete(CFinishedRawProductList finishedRawProductList)
        {
            try
            {
                //    GetFinishedRawProductListByFinishedProductIDRawProductID

                this.OpenConnection();
                string sqlCommand = String.Format(SqlQueries.GetQuery(Query.FinishedRawProductListDelete), finishedRawProductList.ID);
                this.ExecuteNonQuery(sqlCommand);

            }

            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in InsertDeposit()", LogLevel.Error, "Database");

                return false;
            }
            finally
            {
                this.CloseConnection();

            }

            return true;
        }

        public List<CFinishedRawProductList> GetFinishedRawProductListByProductID(long productID)
        {
            List<CFinishedRawProductList> cFinishedRawProductList = new List<CFinishedRawProductList>();

            CFinishedRawProductList tempFinishedRawProductList = new CFinishedRawProductList();
            try
            {
                this.OpenConnection();

                string sqlCommand = string.Format(SqlQueries.GetQuery(Query.GetFinishedRawProductListByProductID), productID);
                IDataReader oReader = this.ExecuteReader(sqlCommand);

                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        tempFinishedRawProductList = new CFinishedRawProductList();

                        tempFinishedRawProductList = ReaderToFinishedRawProductList(oReader);
                        if (tempFinishedRawProductList != null)
                        {
                            cFinishedRawProductList.Add(tempFinishedRawProductList);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("###" + ex.ToString() + "###");
                Logger.Write("Exception : " + ex.Message + " in GetFinishedRawProductListByProductID(long productID)", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occured at GetFinishedRawProductListByProductID(long productID) ", ex);
                }
                else
                {
                    throw new Exception("Exception occured at GetFinishedRawProductListByProductID(long productID) ", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }

            return cFinishedRawProductList;
        }

        public List<CFinishedRawProductList> GetFinishedRawProductListByProductName()
        {
            throw new NotImplementedException();
        }

        public List<CFinishedRawProductList> GetFinishedRawProductListAll()
        {
            return null;
        }

        #region ReaderToCategory3
        private CFinishedRawProductList ReaderToFinishedRawProductList(IDataReader inReader)
        {
            CFinishedRawProductList tempCategory3 = new CFinishedRawProductList();

            if (inReader["ID"] != null)
                tempCategory3.ID = long.Parse(inReader["ID"].ToString());

            if (inReader["finishedProductID"] != null)
                tempCategory3.RawProductID = long.Parse(inReader["finishedProductID"].ToString());

            if (inReader["rawProductID"] != null)
                tempCategory3.RawProductID = long.Parse(inReader["rawProductID"].ToString());

            if (inReader["rawProductName"] != null)
                tempCategory3.RawProductName = inReader["rawProductName"].ToString();

            if (inReader["qnty"] != null)
                tempCategory3.Qnty = double.Parse(inReader["qnty"].ToString());

            if (inReader["remarks"] != null)
                tempCategory3.Remarks = inReader["remarks"].ToString();
            try
            {
                tempCategory3.InsType = Convert.ToBoolean(inReader["ins_type"]);
            }
            catch 
            {
                
               
            }


            return tempCategory3;
        }
        #endregion



        private bool ISDuplicate(long productID, long rawProductID)
        {
            CFinishedRawProductList tempFinishedRawProductList = null;
            try
            {

                tempFinishedRawProductList = GetFinishedRawProductListByFinishedProductIDRawProductID(productID, rawProductID);
            }
            catch (Exception ex)
            {

            }

            if (tempFinishedRawProductList != null || tempFinishedRawProductList.ID == 0)
            {
                return false;
            }

            return true;
        }




        #region GetFinishedRawProductListByFinishedProductIDRawProductID
        public CFinishedRawProductList GetFinishedRawProductListByFinishedProductIDRawProductID(long productID, long rawProductID)
        {
            CFinishedRawProductList tempFinishedRawProductList = new CFinishedRawProductList();

            try
            {
                this.OpenConnection();

                string sqlCommand = string.Format(SqlQueries.GetQuery(Query.GetFinishedRawProductListByFinishedProductIDandRawProductID), productID, rawProductID);
                IDataReader oReader = this.ExecuteReader(sqlCommand);

                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        tempFinishedRawProductList = new CFinishedRawProductList();

                        tempFinishedRawProductList = ReaderToFinishedRawProductList(oReader);

                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("###" + ex.ToString() + "###");
                Logger.Write("Exception : " + ex.Message + " in GetFinishedRawProductListByProductID(long productID)", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occured at GetFinishedRawProductListByProductID(long productID) ", ex);
                }
                else
                {
                    throw new Exception("Exception occured at GetFinishedRawProductListByProductID(long productID) ", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }

            return tempFinishedRawProductList;
        }
        #endregion


        public void FinishedRawProductUpdate(CFinishedRawProductList list, double quantity)
        {
            try
            {
                this.OpenConnection();
                string command = string.Format(SqlQueries.GetQuery(Query.UpdateRawMaterialsByRawProductID),
                                                       list.RawProductID, (list.Qnty * quantity));
                this.ExecuteNonQuery(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.CloseConnection();
            }
        }


    }
}
