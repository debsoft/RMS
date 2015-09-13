using System;
using System.Collections.Generic;
using System.Text;

using RMS.Common;
using RMS.Common.DataAccess;
using System.Data;
using System.Data.SqlClient;


namespace RMS
{
    namespace DataAccess
    {
        public class CDistrictDAO : BaseDAO, IItemDAO
        {
            public CDistrictDAO()
            {

            }
            #region IDistrictDAO Members
            /// <summary>
            /// Get district by short name
            /// </summary>
            /// <param name="oDistrict"></param>
            /// <returns></returns>
            //public CDistrict DistrictByShortName(CDistrict oDistrict)
            //{
            //    CDistrict oNewDistrict = null;
            //    try
            //    {
            //        this.OpenConnection();
            //        string sSql = string.Format(SqlQueries.GetQuery(Query.DistrictByShortName), oDistrict.DistrictShortName, oDistrict.DistrictShortName);
            //        IDataReader oReader = this.ExecuteReader(sSql);
            //        if (oReader != null)
            //        {
            //            bool bIsRead = oReader.Read();
            //            if (bIsRead)
            //                oNewDistrict = DistrictFromReader(oReader);
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        Logger.Write("Exception : " + ex + " in DistrictByShortName()", LogLevel.Error, "Database");

            //        throw new Exception("Exception occure at DistrictByShortName()", ex);
            //    }
            //    finally
            //    {
            //        this.CloseConnection();
            //    }
            //    return oNewDistrict;
            //}

            ///// <summary>
            ///// Get district by full name
            ///// </summary>
            ///// <param name="oDistrict"></param>
            ///// <returns></returns>
            //public CDistrict DistrictByName(CDistrict oDistrict)
            //{
            //    CDistrict oNewDistrict = null;
            //    try
            //    {
            //        this.OpenConnection();
            //        string sSql = string.Format(SqlQueries.GetQuery(Query.DistrictByName), oDistrict.DistrictName, oDistrict.DistrictShortName);
            //        IDataReader oReader = this.ExecuteReader(sSql);
            //        if (oReader != null)
            //        {
            //            bool bIsRead = oReader.Read();
            //            if (bIsRead)
            //                oNewDistrict = DistrictFromReader(oReader);
            //        }
            //        else
            //        {
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        Logger.Write("Exception : " + ex + " in DistrictByName()", LogLevel.Error, "Database");
                    
            //        throw new Exception("Exception occure at DistrictByName()", ex);
            //    }
            //    finally
            //    {
            //        this.CloseConnection();
            //    }
            //    return oNewDistrict;
            //}

            //public CDistrict IsDistrict(CDistrict oDistrict)
            //{
            //    CDistrict oNewDistrict = null;
            //    try
            //    {
            //        this.OpenConnection();
            //        string sSql = string.Format(SqlQueries.GetQuery(Query.DistrictCheck), oDistrict.DistrictName);
            //        IDataReader oReader = this.ExecuteReader(sSql);
            //        if (oReader != null)
            //        {
            //            bool bIsRead = oReader.Read();
            //            if (bIsRead)
            //                oNewDistrict = DistrictFromReader(oReader);
            //            else
            //            {
            //                //district not found

            //                oNewDistrict = null;

            //            }
            //        }
            //        else
            //        {

            //            //district not found

            //            oNewDistrict = null;
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        Logger.Write("Exception : " + ex + " in IsDistrict()", LogLevel.Error, "Database");

            //        throw new Exception("Exception occure at IsDistrict()", ex);
            //    }
            //    finally
            //    {
            //        this.CloseConnection();
            //    }
            //    return oNewDistrict;
            //}


            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            //public List<CDistrict> GetAllLocation()
            //{
            //    List<CDistrict> oItemList = new List<CDistrict>();
            //    try
            //    {
            //        this.OpenConnection();
            //        string sSql = SqlQueries.GetQuery(Query.AllDistrict);//" Order BY NewID()";
            //        IDataReader oReader = this.ExecuteReader(sSql);
            //        if (oReader != null)
            //        {
            //            while (oReader.Read())
            //            {
            //                CDistrict oItem = DistrictFromReader(oReader);
            //                oItemList.Add(oItem);
            //            }
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        Logger.Write("Exception : " + ex + " in GetAllLocation()", LogLevel.Error, "Database");
            //        if (ex.GetType().Equals(typeof(SqlException)))
            //        {
            //            SqlException oSQLEx = ex as SqlException;
            //            if (oSQLEx.Number != 7619)
            //                throw new Exception("Exception occure at GetAllLocation()", ex);
            //        }
            //        else
            //        {
            //            throw new Exception("Exception occure at GetAllLocation()", ex);
            //        }
            //    }
            //    finally
            //    {
            //        this.CloseConnection();
            //    }
            //    return oItemList;
            //}


            ///// <summary>
            ///// 
            ///// </summary>
            ///// <returns></returns>
            //public List<CDistrict> GetDistrictByFirstLetter(string sInStr)
            //{
            //    List<CDistrict> oItemList = new List<CDistrict>();
            //    try
            //    {
            //        sInStr = sInStr.Trim();
            //        string sTempStr = sInStr[0]+"%";
            //        this.OpenConnection();
            //        string sSql = string.Format(SqlQueries.GetQuery(Query.DistrictByFirstLetter), sTempStr);//" Order BY NewID()";
            //        IDataReader oReader = this.ExecuteReader(sSql);
            //        if (oReader != null)
            //        {
            //            while (oReader.Read())
            //            {
            //                CDistrict oItem = DistrictFromReader(oReader);
            //                oItemList.Add(oItem);
            //            }
            //        }
            //        else
            //        {
            //            // no data found

            //            oItemList = null;

            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        Logger.Write("Exception : " + ex + " in GetDistrictByFirstLetter()", LogLevel.Error, "Database");
            //        if (ex.GetType().Equals(typeof(SqlException)))
            //        {
            //            SqlException oSQLEx = ex as SqlException;
            //            if (oSQLEx.Number != 7619)
            //                throw new Exception("Exception occure at GetDistrictByFirstLetter()", ex);
            //        }
            //        else
            //        {
            //            throw new Exception("Exception occure at GetDistrictByFirstLetter()", ex);
            //        }
            //    }
            //    finally
            //    {
            //        this.CloseConnection();
            //    }
            //    return oItemList;
            //}

            //public CResult DistrictInsert(CDistrict oDistrict)
            //{
            //    try
            //    {
            //        CResult oResult = new CResult();

            //        CDistrict oTempDis = IsDistrict(oDistrict);

            //        if (oTempDis == null)
            //        {
            //            this.OpenConnection();
            //            //string sSql = string.Format(SqlQueries.GetQuery(Query.ItemCreate),
            //            //    oItem.ItemId, oItem.ItemName, oItem.ItemDesc, oItem.ItemPrice,
            //            //    oItem.ItemLocation.DistrictId, oItem.ItemQuantity, oItem.ItemUnit,
            //            //    oItem.ItemCurrency, oItem.Seller.SellerId, oItem.Category.CategoryId, oItem.CreateTime.ToString());
            //            string sSql = string.Format(SqlQueries.GetQuery(Query.DistrictInsert), oDistrict.DistrictId, oDistrict.DistrictShortName, oDistrict.DistrictName);

            //            //sSql = sSql.Replace("'", "''");

            //            this.ExecuteNonQuery(sSql);

            //            oResult.IsSuccess = true;
            //        }
            //        else
            //        {
            //            // null 

            //            oResult.IsSuccess = false;
            //            oResult.Message = "Location: "+oDistrict.DistrictName + " is already exists!";
            //        }

            //        return oResult;


                  
            //    }
            //    catch (Exception ex)
            //    {
            //        Logger.Write("Exception : " + ex + " in ItemInsert()", LogLevel.Error, "Database");

            //        throw new Exception("Exception occure at ItemInsert()", ex);
            //    }
            //    finally
            //    {
            //        this.CloseConnection();
            //    }
            //}

            //public void DistrictDelete(CDistrict oDistrict)
            //{
            //    try
            //    {
            //        this.OpenConnection();
            //        string sSql = string.Format(SqlQueries.GetQuery(Query.DistrictDelete), oDistrict.DistrictId);

            //        //sSql = sSql.Replace("'", "''");

            //        this.ExecuteNonQuery(sSql);
            //    }
            //    catch (Exception ex)
            //    {
            //        Logger.Write("Exception : " + ex + " in DistrictDelete()", LogLevel.Error, "Database");

            //        throw new Exception("Exception occure at DistrictDelete()", ex);
            //    }
            //    finally
            //    {
            //        this.CloseConnection();
            //    }
            //}

            //public void DistrictUpdate(CDistrict oDistrict)
            //{
            //    try
            //    {
            //        this.OpenConnection();
            //        string sSql = string.Format(SqlQueries.GetQuery(Query.DistrictUpdate), oDistrict.DistrictId, oDistrict.DistrictShortName, oDistrict.DistrictName);

            //        //sSql = sSql.Replace("'", "''");

            //        this.ExecuteNonQuery(sSql);
            //    }
            //    catch (Exception ex)
            //    {
            //        Logger.Write("Exception : " + ex + " in DistrictUpdate()", LogLevel.Error, "Database");

            //        throw new Exception("Exception occured in DistrictUpdate()", ex);
            //    }
            //    finally
            //    {
            //        this.CloseConnection();
            //    }
            //}

            #endregion

            /// <summary>
            /// This method convert reader object to District object
            /// </summary>
            /// <param name="oReader"></param>
            /// <returns></returns>
            //private CDistrict DistrictFromReader(IDataReader oReader)
            //{
            //    CDistrict oDistrict = new CDistrict();
                
            //    if (oReader["district_id"] != null)
            //        oDistrict.DistrictId = new Guid(oReader["district_id"].ToString());

            //    if (oReader["district_short_name"] != null)
            //        oDistrict.DistrictShortName = oReader["district_short_name"].ToString();

            //    if (oReader["district_full_name"] != null)
            //        oDistrict.DistrictName = oReader["district_full_name"].ToString();
                
            //    return oDistrict;
            //}

        }
    }
}
