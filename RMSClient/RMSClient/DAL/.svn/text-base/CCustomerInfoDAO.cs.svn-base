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
    public class CCustomerInfoDAO : BaseDAO, ICustomerInfoDAO
    {
        #region ICustomerInfo members

        public CCustomerInfo InsertCustomerInfo(CCustomerInfo inCustomerInfo)
        {

            inCustomerInfo.CustomerName = inCustomerInfo.CustomerName.Replace("''", "'");
            inCustomerInfo.CustomerName = inCustomerInfo.CustomerName.Replace("'", "''");

            inCustomerInfo.CustomerPhone = inCustomerInfo.CustomerPhone.Replace("''", "'");
            inCustomerInfo.CustomerPhone = inCustomerInfo.CustomerPhone.Replace("'", "''");

            inCustomerInfo.CustomerPostalCode = inCustomerInfo.CustomerPostalCode.Replace("''", "'");
            inCustomerInfo.CustomerPostalCode = inCustomerInfo.CustomerPostalCode.Replace("'", "''");

            inCustomerInfo.CustomerAddress = inCustomerInfo.CustomerAddress.Replace("''", "'");
            inCustomerInfo.CustomerAddress = inCustomerInfo.CustomerAddress.Replace("'", "''");

            inCustomerInfo.CustomerTown = inCustomerInfo.CustomerTown.Replace("''", "'");
            inCustomerInfo.CustomerTown = inCustomerInfo.CustomerTown.Replace("'", "''");

            inCustomerInfo.CustomerCounty = inCustomerInfo.CustomerCounty.Replace("''", "'");
            inCustomerInfo.CustomerCounty = inCustomerInfo.CustomerCounty.Replace("'", "''");

            inCustomerInfo.CustomerCountry = inCustomerInfo.CustomerCountry.Replace("''", "'");
            inCustomerInfo.CustomerCountry = inCustomerInfo.CustomerCountry.Replace("'", "''");
            inCustomerInfo.UserName = inCustomerInfo.UserName.Replace("'", "''");


            CCustomerInfo tempCustomerInfo = inCustomerInfo;
            try
            {
                this.OpenConnection();
                string sSql = string.Format(SqlQueries.GetQuery(Query.CustomerInsert),
                    inCustomerInfo.CustomerName, inCustomerInfo.CustomerPhone, inCustomerInfo.CustomerPostalCode, inCustomerInfo.CustomerAddress, inCustomerInfo.CustomerTown, inCustomerInfo.CustomerCounty, inCustomerInfo.CustomerCountry,inCustomerInfo.UserName,inCustomerInfo.InsertDate,inCustomerInfo.TerminalId);

                this.ExecuteNonQuery(sSql);
                sSql = SqlQueries.GetQuery(Query.ScopeIdentity);
                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    bool bIsRead = oReader.Read();
                    if (bIsRead)
                    {

                        tempCustomerInfo.CustomerID = Int64.Parse(oReader[0].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in InsertCustomerInfo()", LogLevel.Error, "Database");

                throw new Exception("Exception occure at InsertCustomerInfo()", ex);
            }
            finally
            {
                this.CloseConnection();
            }

            return tempCustomerInfo;
        }

        public void UpdateCustomerInfo(CCustomerInfo inCustomerInfo)
        {
            inCustomerInfo.CustomerName = inCustomerInfo.CustomerName.Replace("''", "'");
            inCustomerInfo.CustomerName = inCustomerInfo.CustomerName.Replace("'", "''");

            inCustomerInfo.CustomerPhone = inCustomerInfo.CustomerPhone.Replace("''", "'");
            inCustomerInfo.CustomerPhone = inCustomerInfo.CustomerPhone.Replace("'", "''");

            inCustomerInfo.CustomerPostalCode = inCustomerInfo.CustomerPostalCode.Replace("''", "'");
            inCustomerInfo.CustomerPostalCode = inCustomerInfo.CustomerPostalCode.Replace("'", "''");

            inCustomerInfo.CustomerAddress = inCustomerInfo.CustomerAddress.Replace("''", "'");
            inCustomerInfo.CustomerAddress = inCustomerInfo.CustomerAddress.Replace("'", "''");

            inCustomerInfo.CustomerTown = inCustomerInfo.CustomerTown.Replace("''", "'");
            inCustomerInfo.CustomerTown = inCustomerInfo.CustomerTown.Replace("'", "''");

            inCustomerInfo.CustomerCounty = inCustomerInfo.CustomerCounty.Replace("''", "'");
            inCustomerInfo.CustomerCounty = inCustomerInfo.CustomerCounty.Replace("'", "''");

            inCustomerInfo.CustomerCountry = inCustomerInfo.CustomerCountry.Replace("''", "'");
            inCustomerInfo.CustomerCountry = inCustomerInfo.CustomerCountry.Replace("'", "''");


            CCustomerInfo tempCustomerInfo = inCustomerInfo;

            try
            {
                this.OpenConnection();
                string sSql = string.Format(SqlQueries.GetQuery(Query.CustomerUpdate),
                    inCustomerInfo.CustomerName, inCustomerInfo.CustomerPhone, inCustomerInfo.CustomerPostalCode, inCustomerInfo.CustomerAddress, inCustomerInfo.CustomerTown, inCustomerInfo.CustomerCounty, inCustomerInfo.CustomerCountry, inCustomerInfo.CustomerID);

                this.ExecuteNonQuery(sSql);

            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in UpdateCustomerInfo()", LogLevel.Error, "Database");

                throw new Exception("Exception occure at UpdateCustomerInfo()", ex);
            }
            finally
            {
                this.CloseConnection();
            }

        }

        public void DeleteCustomerInfo(CCustomerInfo inCustomerInfo)
        {
            CCustomerInfo tempCustomerInfo = inCustomerInfo;

            try
            {
                this.OpenConnection();
                string sSql = string.Format(SqlQueries.GetQuery(Query.CustomerDelete),inCustomerInfo.CustomerID);

                this.ExecuteNonQuery(sSql);

            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in DeleteCustomerInfo()", LogLevel.Error, "Database");

                throw new Exception("Exception occure at DeleteCustomerInfo()", ex);
            }
            finally
            {
                this.CloseConnection();
            }

        }

        public CCustomerInfo CustomerInfoGetByCustomerID(Int64 inCustomerID)
        {
            CCustomerInfo tempCustomerInfo = new CCustomerInfo();
            try
            {
                this.OpenConnection();
                string sSql = String.Format(SqlQueries.GetQuery(Query.CustomerInfoGetByCustomerID), inCustomerID);
                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        tempCustomerInfo = ReaderToCustomerInfo(oReader);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in CustomerInfoGetByCustomerID()", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occured at CustomerInfoGetByCustomerID()", ex);
                }
                else
                {
                    throw new Exception("Exception occure at CustomerInfoGetByCustomerID()", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }
            return tempCustomerInfo;

        }

        public CCustomerInfo CustomerInfoGetByPhone(String CustomerPhone)
        {
            CCustomerInfo tempCustomerInfo = new CCustomerInfo();
            try
            {
                this.OpenConnection();
                string sSql = String.Format(SqlQueries.GetQuery(Query.CustomerInfoGetByPhone), CustomerPhone);
                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        tempCustomerInfo = ReaderToCustomerInfo(oReader);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in CustomerInfoGetByCustomerID()", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occured at CustomerInfoGetByCustomerID()", ex);
                }
                else
                {
                    throw new Exception("Exception occure at CustomerInfoGetByCustomerID()", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }
            return tempCustomerInfo;
        }


        public CCustomerInfo CustomerInfoGetByName(String CustomerPhone)
        {
            CCustomerInfo tempCustomerInfo = new CCustomerInfo();
            try
            {
                this.OpenConnection();
                string sSql = String.Format(SqlQueries.GetQuery(Query.CustomerInfoGetByName), CustomerPhone);
                IDataReader oReader = this.ExecuteReader(sSql);
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        tempCustomerInfo = ReaderToCustomerInfo(oReader);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in CustomerInfoGetByCustomerID()", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occured at CustomerInfoGetByCustomerID()", ex);
                }
                else
                {
                    throw new Exception("Exception occure at CustomerInfoGetByCustomerID()", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }
            return tempCustomerInfo;
        }

        #endregion

        private CCustomerInfo ReaderToCustomerInfo(IDataReader inReader)
        {
            CCustomerInfo tempCustomerInfo = new CCustomerInfo();

            if (inReader["customer_id"] != null)
                tempCustomerInfo.CustomerID = Int64.Parse(inReader["customer_id"].ToString());

            if (inReader["name"] != null)
                tempCustomerInfo.CustomerName= inReader["name"].ToString();
            if (inReader["phone"] != null)
                tempCustomerInfo.CustomerPhone= inReader["phone"].ToString();
            if (inReader["postal_code"] != null)
                tempCustomerInfo.CustomerPostalCode = inReader["postal_code"].ToString();
            if (inReader["address"] != null)
                tempCustomerInfo.CustomerAddress = inReader["address"].ToString();
            if (inReader["town"] != null)
                tempCustomerInfo.CustomerTown = inReader["town"].ToString();
            if (inReader["county"] != null)
                tempCustomerInfo.CustomerCounty = inReader["county"].ToString();
            if (inReader["country"] != null)
                tempCustomerInfo.CustomerCountry = inReader["country"].ToString();

            return tempCustomerInfo;
        }

    }
}
