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

        public void DeleteTableInfo(int inTableNumber, string inTableType)
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

        public CTableInfo TableInfoGetByTableNumber(int inTableNumber, string inTableType)
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

        public CResult UpdateDBForUnlock(int inTableNumber, String inTableType)
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
                tempAvailableTable.TableNumber = int.Parse(oReader["table_number"].ToString());
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

    }
}
