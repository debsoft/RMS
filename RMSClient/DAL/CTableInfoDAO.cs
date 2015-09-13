using System;
using System.Collections.Generic;
using System.Text;
using RMS.Common.ObjectModel;
using System.Data;
using RMS.Common;
using RMS.Common.DataAccess;
using System.Data.SqlClient;

namespace RMS.DataAccess
{
    class CTableInfoDAO : BaseDAO, ITableInfoDAO
    {

        public CTableInfoDAO()
        {
        }

        #region IOrderShowDAO Members

        public void InsertTableInfo(CTableInfo inTableInfo)
        {
            inTableInfo.TableType = inTableInfo.TableType.Replace("''", "'");
            inTableInfo.TableType = inTableInfo.TableType.Replace("'", "''");
            try
            {
                this.OpenConnection();
                String sSql = string.Format(SqlQueries.GetQuery(Query.InsertTableInfo), inTableInfo.TableNumber, inTableInfo.Capacity, inTableInfo.Status, inTableInfo.TableType);
                this.ExecuteNonQuery(sSql);
            }
            catch (Exception ex)
            {
                Console.Write("###" + ex + "###");
                Logger.Write("Exception : " + ex + " in InsertTableInfo()", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occure at InsertTableInfo()", ex);
                }
                else
                {
                    throw new Exception("Exception occure at InsertTableInfo()", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }

        }

        /// <summary>
        /// ///This function changes the table status when any table is clicked. Indicates someone else engaged the table.
        /// </summary>
        /// <param name="inTableInfo"></param>

        public void UpdateTableInfo(CTableInfo inTableInfo)
        {
            inTableInfo.TableType = inTableInfo.TableType.Replace("''", "'");
            inTableInfo.TableType = inTableInfo.TableType.Replace("'", "''");
            try
            {
                this.OpenConnection();
                String sSql = string.Format(SqlQueries.GetQuery(Query.UpdateTableInfo), inTableInfo.Capacity, inTableInfo.Status, inTableInfo.TableNumber, inTableInfo.TableType);
                this.ExecuteNonQuery(sSql);
            }
            catch (Exception ex)
            {
                Console.Write("###" + ex + "###");
                Logger.Write("Exception : " + ex + " in UpdateTableInfo()", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occure at UpdateTableInfo()", ex);
                }
                else
                {
                    throw new Exception("Exception occure at UpdateTableInfo()", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void DeleteTableInfo(Int64 inTableNumber, string inTableType)
        {
            inTableType = inTableType.Replace("''", "'");
            inTableType = inTableType.Replace("'", "''");
            try
            {
                this.OpenConnection();
                String sSql = string.Format(SqlQueries.GetQuery(Query.DeleteTableInfo), inTableNumber, inTableType);
                this.ExecuteNonQuery(sSql);
            }
            catch (Exception ex)
            {
                Console.Write("###" + ex + "###");
                Logger.Write("Exception : " + ex + " in DeleteTableInfo()", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occure at DeleteTableInfo()", ex);
                }
                else
                {
                    throw new Exception("Exception occure at DeleteTableInfo()", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public CTableInfo TableInfoGetByTableNumber(Int64 inTableNumber, string inTableType)
        {
            CTableInfo tempTableInfo = new CTableInfo();

            try
            {
                inTableType = inTableType.Replace("''", "'");
                inTableType = inTableType.Replace("'", "''");

                this.OpenConnection();
                string sSql = string.Format(SqlQueries.GetQuery(Query.TableInfoGetByTableNumber), inTableNumber, inTableType);

                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        tempTableInfo = ReaderToAvailableTable(oReader);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write("###" + ex + "###");
                Logger.Write("Exception : " + ex + " in TableInfoGetByTableNumber()", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occure at TableInfoGetByTableNumber()", ex);
                }
                else
                {
                    throw new Exception("Exception occure at TableInfoGetByTableNumber()", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }
            return tempTableInfo;
        }

        public List<Int32> GetTableNumberList(String TableType)
        {
            List<Int32> tempTableNumberList = new List<int>();
            try
            {
                this.OpenConnection();
                string sSql = String.Format(SqlQueries.GetQuery(Query.GetTableNumberList), TableType);

                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        tempTableNumberList.Add(Int32.Parse(oReader[0].ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write("###" + ex + "###");
                Logger.Write("Exception : " + ex + " in GetMaxTableNumber()", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occure at GetMaxTableNumber()", ex);
                }
                else
                {
                    throw new Exception("Exception occure at TableInfoGetByTableNumber()", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }
            return tempTableNumberList;
        }

        public CResult UpdateDBForUnlock(Int64 inTableNumber, String inTableType)
        {
            CResult tempResult = new CResult();
            try
            {
                CCommonConstants oTempConstant = ConfigManager.GetConfig<CCommonConstants>();
                inTableType = inTableType.Replace("''", "'");
                inTableType = inTableType.Replace("'", "''");

                this.OpenConnection();

                String sSql = string.Format(SqlQueries.GetQuery(Query.UpdateDBForUnlock), inTableNumber, inTableType);
                //this.ExecuteReader(sSql);
                this.ExecuteNonQuery(sSql);
                tempResult.IsSuccess = true;
            }
            catch (Exception ex)
            {
                tempResult.IsException = true;
                Console.Write("###" + ex + "###");
                Logger.Write("Exception : " + ex + " in UpdateDBForUnlock()", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occure at UpdateDBForUnlock()", ex);
                }
                else
                {
                    throw new Exception("Exception occure at UpdateDBForUnlock()", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }
            return tempResult;
        }

        public CResult AvailableTableForTransfer()
        {
            CResult tempResult = new CResult();
            List<CTableInfo> tempAvailableTableListForTransfer = new List<CTableInfo>();
            try
            {
                CCommonConstants oTempConstant = ConfigManager.GetConfig<CCommonConstants>();

                this.OpenConnection();
                string sSql = string.Format(SqlQueries.GetQuery(Query.ShowAvailableTableForTransfer));

                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        CTableInfo tempTable = ReaderToAvailableTable(oReader);
                        tempAvailableTableListForTransfer.Add(tempTable);
                    }
                }
                tempResult.Data = tempAvailableTableListForTransfer;
                tempResult.IsSuccess = true;
            }
            catch (Exception ex)
            {
                tempResult.IsException = true;
                Console.Write("###" + ex + "###");
                Logger.Write("Exception : " + ex + " in AvailableTableForTransfer()", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occure at AvailableTableForTransfer()", ex);
                }
                else
                {
                    throw new Exception("Exception occure at AvailableTableForTransfer()", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }
            return tempResult;
        }

        #endregion

        private CTableInfo ReaderToAvailableTable(IDataReader oReader)
        {
            CTableInfo tempAvailableTable = new CTableInfo();

            if (oReader["table_number"] != null)
            {
                tempAvailableTable.TableNumber = Int64.Parse(oReader["table_number"].ToString());
            }

            if (oReader["capacity"] != null)
            {
                tempAvailableTable.Capacity = int.Parse(oReader["capacity"].ToString());
            }

            if (oReader["status"] != null)
            {
                tempAvailableTable.Status = int.Parse(oReader["status"].ToString());
            }

            if (oReader["table_type"] != null)
            {
                tempAvailableTable.TableType = oReader["table_type"].ToString();
            }



            return tempAvailableTable;

        }


        #region ITableInfoDAO Members


        //public CTableInfo TableInfoGetByTableNumber(long inTableNumber, string inTableType)
        //{
        //    throw new NotImplementedException();
        //}

        //public void DeleteTableInfo(long inTableNumber, string inTableType)
        //{
        //    throw new NotImplementedException();
        //}

        #endregion

        #region ITableInfoDAO Members

        /// <summary>
        /// Collects the current waiting number
        /// </summary>
        /// <param name="currentDate"></param>
        /// <returns></returns>
        public CResult GetCurentWaitingNumber(long currentDate)
        {
            CResult tempResult = new CResult();
            try
            {
                CTableInfo tempTable = new CTableInfo();

                this.OpenConnection();
                string sqlCommand = string.Format(SqlQueries.GetQuery(Query.CurrentWaitingNumber),currentDate);

                IDataReader oReader = this.ExecuteReader(sqlCommand);

                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        tempTable.WaitingNumber = Convert.ToInt64("0" + oReader["waiting_number_today"]);
                    }
                }
                tempResult.Data = tempTable;
                tempResult.IsSuccess = true;
            }
            catch (Exception ex)
            {
                tempResult.IsException = true;
                Console.Write("###" + ex + "###");
                Logger.Write("Exception : " + ex + " in GetCurentWaitingNumber()", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occure at GetCurentWaitingNumber()", ex);
                }
                else
                {
                    throw new Exception("Exception occure at GetCurentWaitingNumber()", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }
            return tempResult;
        }

        #endregion

        #region ITableInfoDAO Members


        public CResult GetCurentWaitingNumber(long currentDate, int orderIndex)
        {
            CResult tempResult = new CResult();
            try
            {
                CTableInfo tempTable = new CTableInfo();

                this.OpenConnection();
                string sqlCommand = "";
                if (orderIndex == 3)
                {
                    sqlCommand = string.Format(SqlQueries.GetQuery(Query.CurrentWaitingNumber), currentDate);
                }
                else if (orderIndex == 2)
                {
                    sqlCommand = string.Format(SqlQueries.GetQuery(Query.CurrentCollectionNumber), currentDate);
                }
                IDataReader oReader = this.ExecuteReader(sqlCommand);
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        if (orderIndex == 3)
                        {
                            tempTable.WaitingNumber = Convert.ToInt64("0" + oReader["waiting_number_today"]);
                        }
                        else if (orderIndex == 2)
                        { 
                          tempTable.WaitingNumber = Convert.ToInt64("0" + oReader["collection_number_today"]);
                        }
                    }
                }
                tempResult.Data = tempTable;
                tempResult.IsSuccess = true;
            }
            catch (Exception ex)
            {
                tempResult.IsException = true;
                Console.Write("###" + ex + "###");
                Logger.Write("Exception : " + ex + " in GetCurentWaitingNumber()", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occure at GetCurentWaitingNumber()", ex);
                }
                else
                {
                    throw new Exception("Exception occure at GetCurentWaitingNumber()", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }
            return tempResult;
        }

        #endregion
    }
}
