using System;
using System.Collections.Generic;
using System.Collections;
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
                string sqlCommand = string.Format(SqlQueries.GetQuery(Query.CustomerInsert),
                    inCustomerInfo.CustomerName,inCustomerInfo.FloorAptNumber,inCustomerInfo.BuildingName,inCustomerInfo.HouseNumber,inCustomerInfo.CustomerPhone, inCustomerInfo.CustomerPostalCode, inCustomerInfo.CustomerTown, inCustomerInfo.CustomerCountry,inCustomerInfo.UserName,inCustomerInfo.InsertDate,inCustomerInfo.TerminalId,inCustomerInfo.StreetName);

                this.ExecuteNonQuery(sqlCommand);
                sqlCommand = SqlQueries.GetQuery(Query.ScopeIdentity);
                IDataReader oReader = this.ExecuteReader(sqlCommand);
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

            //inCustomerInfo.CustomerCounty = inCustomerInfo.CustomerCounty.Replace("''", "'");
            //inCustomerInfo.CustomerCounty = inCustomerInfo.CustomerCounty.Replace("'", "''");

            inCustomerInfo.CustomerCountry = inCustomerInfo.CustomerCountry.Replace("''", "'");
            inCustomerInfo.CustomerCountry = inCustomerInfo.CustomerCountry.Replace("'", "''");

            inCustomerInfo.FloorAptNumber = inCustomerInfo.FloorAptNumber.Replace("'", "''");
            inCustomerInfo.BuildingName = inCustomerInfo.BuildingName.Replace("'", "''");
            inCustomerInfo.HouseNumber = inCustomerInfo.HouseNumber.Replace("'", "''");
            inCustomerInfo.StreetName = inCustomerInfo.StreetName.Replace("'", "''");

            CCustomerInfo tempCustomerInfo = inCustomerInfo;

            try
            {
                this.OpenConnection();
                string sSql = string.Format(SqlQueries.GetQuery(Query.CustomerUpdate),
                    inCustomerInfo.CustomerName, inCustomerInfo.CustomerPhone, inCustomerInfo.CustomerPostalCode, inCustomerInfo.CustomerTown,  inCustomerInfo.CustomerCountry,inCustomerInfo.FloorAptNumber,inCustomerInfo.BuildingName,inCustomerInfo.HouseNumber,inCustomerInfo.StreetName, inCustomerInfo.CustomerID);

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
                string sqlCommand = string.Format(SqlQueries.GetQuery(Query.CustomerDelete),inCustomerInfo.CustomerID);

                this.ExecuteNonQuery(sqlCommand);

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
                string sqlCommand = String.Format(SqlQueries.GetQuery(Query.CustomerInfoGetByCustomerID), inCustomerID);
                IDataReader oReader = this.ExecuteReader(sqlCommand);
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
                string sqlCommand = String.Format(SqlQueries.GetQuery(Query.CustomerInfoGetByPhone), CustomerPhone);
                IDataReader oReader = this.ExecuteReader(sqlCommand);
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
                string sqlCommand = String.Format(SqlQueries.GetQuery(Query.CustomerInfoGetByName), CustomerPhone);
                IDataReader oReader = this.ExecuteReader(sqlCommand);
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
            if (inReader["town"] != null)
                tempCustomerInfo.CustomerTown = inReader["town"].ToString();
          
            if (inReader["country"] != null)
                tempCustomerInfo.CustomerCountry = inReader["country"].ToString();

            if (inReader["floororapt_number"] != null)
                tempCustomerInfo.FloorAptNumber = inReader["floororapt_number"].ToString();
            if (inReader["building_name"] != null)
                tempCustomerInfo.BuildingName = inReader["building_name"].ToString();
            if (inReader["house_number"] != null)
                tempCustomerInfo.HouseNumber = inReader["house_number"].ToString();
            if (inReader["street_name"] != null)
                tempCustomerInfo.StreetName = inReader["street_name"].ToString();


            return tempCustomerInfo;
        }

        private CCustomerInfo CollectAddressDetailsInfo(IDataReader inReader)
        {
            CCustomerInfo tempCustomerInfo = new CCustomerInfo();

            if (inReader["NUM"] != null)
                tempCustomerInfo.HouseNumber = inReader["NUM"].ToString();

            if (inReader["BNA"] != null)
                tempCustomerInfo.BuildingName = inReader["BNA"].ToString();

            if (inReader["DST"] != null)
                tempCustomerInfo.StreetName = inReader["DST"].ToString();

            if (inReader["TWN"] != null)
                tempCustomerInfo.CustomerTown = inReader["TWN"].ToString();

            if (inReader["PCD"] != null)
                tempCustomerInfo.CustomerPostalCode = inReader["PCD"].ToString();

            if (inReader["STR"] != null)
                tempCustomerInfo.StreetName = inReader["STR"].ToString();

            return tempCustomerInfo;
        }

        #region ICustomerInfoDAO Members

        /// <summary>
        /// Customer address details
        /// </summary>
        /// <param name="p_houseNumber"></param>
        /// <param name="p_postCode"></param>
        /// <returns></returns>
        public CCustomerInfo GetCustomerAddressDetailsInfo(string p_houseNumber, string p_postCode)
        {
            CCustomerInfo tempCustomerInfo = new CCustomerInfo();
            try
            {
                this.OpenConnection();
                string sqlCommand = String.Format(SqlQueries.GetQuery(Query.GetCustomerAddressDetails), p_houseNumber, p_postCode);
                IDataReader oReader = this.ExecuteReader(sqlCommand);
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        tempCustomerInfo = CollectAddressDetailsInfo(oReader);
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


            /// <summary>
        /// Filling up the address details info
        /// </summary>
        /// <param name="inReader"></param>
        /// <param name="p_slAddressInfo"></param>
        private void FillFlatInfo(IDataReader p_inReader, SortedList p_slAddressInfo,string p_houseNumber)
        {
            string flatNumber = String.Empty;
            string[] flatArray=new string[0];
            string flatInfo = Convert.ToString(p_inReader["SBN"]);
            flatArray = flatInfo.Split(';');
            for (int arrayIndex = 0; arrayIndex < flatArray.Length; arrayIndex++)
            {
                    clsCustomerInfo objCustInfo = new clsCustomerInfo();
                    objCustInfo.ApartmentNumber = Convert.ToString(flatArray[arrayIndex]);
                    objCustInfo.StreenName = Convert.ToString(p_inReader["STR"]);
                    objCustInfo.HouseNumber = p_houseNumber;
                    objCustInfo.Town = Convert.ToString(p_inReader["TWN"]);
                    objCustInfo.buildingName = Convert.ToString(p_inReader["BNA"]);
                    string key=objCustInfo.ApartmentNumber.Replace(" ", "").ToUpper() + objCustInfo.HouseNumber.Replace(" ", "").ToUpper();
                    if (!p_slAddressInfo.Contains(key))
                    {
                        p_slAddressInfo.Add(key, objCustInfo);
                    }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public CCustomerInfo ConfiguredTime()
        {
            CCustomerInfo tempCustomerInfo = new CCustomerInfo();
            try
            {
                this.OpenConnection();
                string sqlCommand ="select time_duration from takeaway_default_time";
                IDataReader oReader = this.ExecuteReader(sqlCommand);
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        Int32 configuredTime = Convert.ToInt32("0" + oReader["time_duration"]);
                        tempCustomerInfo.ConfiguredTime = configuredTime;
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

        /// <summary>
        /// Collecting the customer information by customer's name
        /// </summary>
        /// <param name="p_customerName"></param>
        /// <returns></returns>
        public CCustomerInfo GetCustomerInfoByName(string p_customerName)
        {
            CCustomerInfo tempCustomerInfo = new CCustomerInfo();

            tempCustomerInfo.CustomerDataTable.Columns.Add("Name");
            tempCustomerInfo.CustomerDataTable.Columns.Add("address");
            tempCustomerInfo.CustomerDataTable.Columns.Add("phone");
            try
            {
                this.OpenConnection();
                string sqlCommand = String.Format(SqlQueries.GetQuery(Query.GetCustomersByName), p_customerName);
                IDataReader oReader = this.ExecuteReader(sqlCommand);
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        tempCustomerInfo.CustomerDataTable.Rows.Add(new object[] { Convert.ToString(oReader["name"]), Convert.ToString(oReader["address"]), Convert.ToString(oReader["phone"]) });
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in GetCustomerInfoByName()", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occured at GetCustomerInfoByName()", ex);
                }
                else
                {
                    throw new Exception("Exception occure at GetCustomerInfoByName()", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }
            return tempCustomerInfo;
        }

        #endregion

        #region ICustomerInfoDAO Members

        SortedList ICustomerInfoDAO.GetCustomerAddresses(string p_houseNumber, string p_postCode)
        {
            SortedList slCustomerAddress = new SortedList();
            string sqlCommand = String.Empty;
            CCustomerInfo tempCustomerInfo = new CCustomerInfo();
            string[] houseNumberArray = new string[0];
            try
            {
                this.OpenConnection();
                if (p_houseNumber == String.Empty || p_houseNumber == null)
                {
                    sqlCommand = String.Format(SqlQueries.GetQuery(Query.GetCustomerAddressWithoutHouseNumber), p_postCode.Replace(" ",""));
                }
                else
                {
                    sqlCommand = String.Format(SqlQueries.GetQuery(Query.GetCustomerAddressDetails), p_houseNumber, p_postCode.Replace(" ", ""));
                }
                IDataReader oReader = this.ExecuteReader(sqlCommand);
                 string key ="";
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                                clsCustomerInfo objCustInfo = new clsCustomerInfo();
                                objCustInfo.ApartmentNumber = Convert.ToString(oReader["SBN"]);
                                objCustInfo.StreenName = Convert.ToString(oReader["STR"]);
                                objCustInfo.HouseNumber = Convert.ToString(oReader["NUM"]);
                                objCustInfo.Town = Convert.ToString(oReader["TWN"]);
                                objCustInfo.buildingName = Convert.ToString(oReader["BNA"]);
                                objCustInfo.PostalCode = p_postCode;
                                key = p_postCode.Replace(" ", "").ToUpper() + "-" + objCustInfo.ApartmentNumber.Replace(" ", "").ToUpper() + "-" + objCustInfo.HouseNumber.Replace(" ", "").ToUpper();
                                if (!slCustomerAddress.Contains(key))
                                {
                                    slCustomerAddress.Add(key, objCustInfo);
                                }
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
            return slCustomerAddress;
        }

          /// <summary>
          /// Online customer information of the selected order
          /// </summary>
          /// <param name="orderID"></param>
          /// <returns></returns>
      
       CCustomerInfo ICustomerInfoDAO.GetCustomerTakeawayInfo(long orderID)
        {
            string sqlCommand = String.Empty;
            CCustomerInfo tempCustomerInfo = new CCustomerInfo();

            try
            {
                this.OpenConnection();
                
                sqlCommand = String.Format(SqlQueries.GetQuery(Query.TakeawayCustomerInfo), orderID);
                
                IDataReader oReader = this.ExecuteReader(sqlCommand);
                string key = "";
                if (oReader != null)
                {
                    while (oReader.Read())
                    {
                        tempCustomerInfo.CustomerID = Convert.ToInt64("0"+oReader["customer_id"]);
                        tempCustomerInfo.CustomerName = Convert.ToString(oReader["name"]);
                        tempCustomerInfo.HouseNumber = Convert.ToString(oReader["house_number"]);
                        tempCustomerInfo.CustomerPostalCode = Convert.ToString(oReader["postal_code"]);
                        tempCustomerInfo.CustomerPhone = Convert.ToString(oReader["phone"]);
                        tempCustomerInfo.CustomerCountry = Convert.ToString(oReader["country"]);
                        tempCustomerInfo.CustomerTown = Convert.ToString(oReader["town"]);
                        tempCustomerInfo.BuildingName = Convert.ToString(oReader["building_name"]);
                        tempCustomerInfo.FloorAptNumber = Convert.ToString(oReader["floororapt_number"]);
                        tempCustomerInfo.StreetName = Convert.ToString(oReader["street_name"]);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in GetOnlineCustomerInfoByOrderID()", LogLevel.Error, "Database");
                if (ex.GetType().Equals(typeof(SqlException)))
                {
                    SqlException oSQLEx = ex as SqlException;
                    if (oSQLEx.Number != 7619)
                        throw new Exception("Exception occured at GetOnlineCustomerInfoByOrderID()", ex);
                }
                else
                {
                    throw new Exception("Exception occure at GetOnlineCustomerInfoByOrderID()", ex);
                }
            }
            finally
            {
                this.CloseConnection();
            }
            return tempCustomerInfo;
        }

        #endregion
    }
}
