using System;
using System.Collections.Generic;
using System.Text;
using RMS.Common.DataAccess;
using RMS.Common;
using System.Collections;
using System.Data;
using System.Data.SqlClient;



namespace RMS.DataAccess
{
    public class CItemDAO : BaseDAO, IItemDAO 
    {
        public CItemDAO()
        {
        }
        
        #region IItemDAO Members

        //public void ItemInsert(CItem oItem)
        //{
        //    try
        //    {
        //        this.OpenConnection();
        //        string sSql = string.Format(SqlQueries.GetQuery(Query.ItemCreate),
        //            oItem.ItemId, oItem.ItemName, oItem.ItemDesc, oItem.ItemPrice,
        //            oItem.ItemLocation.DistrictId, oItem.ItemQuantity, oItem.ItemUnit,
        //            oItem.ItemCurrency, oItem.Seller.SellerId, oItem.Category.CategoryId, oItem.CreateTime.ToString());
        //        this.ExecuteNonQuery(sSql);
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

        //public void ItemUpdate(CItem oItem)
        //{
        //    try
        //    {
        //        this.OpenConnection();
        //        string sSql = string.Format(SqlQueries.GetQuery(Query.ItemUpdate),
        //            oItem.ItemName, oItem.ItemDesc, oItem.ItemPrice,
        //            oItem.ItemLocation.DistrictId, oItem.ItemQuantity, oItem.ItemUnit,
        //            oItem.ItemCurrency, oItem.Category.CategoryId, oItem.ItemId);
        //        this.ExecuteNonQuery(sSql);
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.Write("Exception : " + ex + " in ItemUpdate()", LogLevel.Error, "Database");
                
        //        throw new Exception("Exception occure at ItemUpdate()", ex);
        //    }
        //    finally
        //    {
        //        this.CloseConnection();
        //    }
        //}

        //public void ItemDelete(CItem oItem)
        //{
        //    try
        //    {
        //        this.OpenConnection();
        //        string sSql = string.Format(SqlQueries.GetQuery(Query.ItemDelete), oItem.ItemId);
        //        this.ExecuteNonQuery(sSql);
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.Write("Exception : " + ex + " in ItemDelete()", LogLevel.Error, "Database");

        //        throw new Exception("Exception occure at ItemDelete()", ex);
        //    }
        //    finally
        //    {
        //        this.CloseConnection();
        //    }
        //}

        //public List<CItem> ItemListBySeller(CSeller oSeller)
        //{
        //    List<CItem> oItemList = new List<CItem>(); 
        //    try
        //    {
        //        this.OpenConnection();
        //        string sSql = string.Format(SqlQueries.GetQuery(Query.ItemListBySeller), oSeller.MobileNumber);
        //        IDataReader oReader = this.ExecuteReader(sSql);
        //        if (oReader != null)
        //        {
        //            while (oReader.Read())
        //            {
        //                CItem oItem = ReaderToItem(oReader);
        //                oItemList.Add(oItem);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.Write("Exception : " + ex + " in ItemListBySeller()", LogLevel.Error, "Database");

        //        throw new Exception("Exception occure at ItemListBySeller()", ex);
        //    }
        //    finally
        //    {
        //        this.CloseConnection();
        //    }
        //    return oItemList;
        //}

        //public void ItemDelete(CSeller oSeller)
        //{
        //    try
        //    {
        //        this.OpenConnection();
        //        string sSql = string.Format(SqlQueries.GetQuery(Query.ItemDeleteBySeller), oSeller.MobileNumber);
        //        this.ExecuteNonQuery(sSql);
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.Write("Exception : " + ex + " in ItemDelete()", LogLevel.Error, "Database");

        //        throw new Exception("Exception occure at ItemDelete()", ex);
        //    }
        //    finally
        //    {
        //        this.CloseConnection();
        //    }
        //}

        //public CItem ItemGetById(Guid gItemId)
        //{
        //    CItem oItem = null;
        //    try
        //    {
        //        this.OpenConnection();
        //        string sSql = string.Format(SqlQueries.GetQuery(Query.ItemGetById), gItemId);
        //        IDataReader oReader = this.ExecuteReader(sSql);
        //        if (oReader != null)
        //        {
        //            if(oReader.Read())
        //                oItem = ReaderToItem(oReader);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.Write("Exception : " + ex + " in ItemGetById()", LogLevel.Error, "Database");

        //        throw new Exception("Exception occure at ItemGetById()", ex);
        //    }
        //    finally
        //    {
        //        this.CloseConnection();
        //    }
        //    return oItem;
        //}

        //public List<CItem> ItemListBySearch(string sSearchQuery)
        //{
        //    List<CItem> oItemList = new List<CItem>();
        //    try
        //    {
        //        CCommonConstants oTempConstant = ConfigManager.GetConfig<CCommonConstants>();

        //        this.OpenConnection();
        //        //string sSql = string.Format(SqlQueries.GetQuery(Query.ItemSearch), oTempConstant.MAXIMUM_SEARCH_RESULT) + sSearchQuery + "ORDER BY ci.create_time DESC";//" Order BY NewID()";

        //        string sSql = string.Format(SqlQueries.GetQuery(Query.ItemSearch2), oTempConstant.MAXIMUM_SEARCH_RESULT) + sSearchQuery + " ORDER BY c1.category_name, c2.category_name, c3.category_name, ci.create_time DESC";//" Order BY NewID()";
                
        //        IDataReader oReader = this.ExecuteReader(sSql);
        //        if (oReader != null)
        //        {
        //            while (oReader.Read())
        //            {
        //                CItem oItem = ReaderToItem(oReader);
        //                oItemList.Add(oItem);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.Write("Exception : " + ex + " in ItemListBySearch()", LogLevel.Error, "Database");
        //        if (ex.GetType().Equals(typeof(SqlException)))
        //        {
        //            SqlException oSQLEx = ex as SqlException;
        //            if (oSQLEx.Number != 7619)
        //                throw new Exception("Exception occure at ItemListBySearch()", ex);
        //        }
        //        else
        //        {
        //            throw new Exception("Exception occure at ItemListBySearch()", ex);
        //        }
        //    }
        //    finally
        //    {
        //        this.CloseConnection();
        //    }
        //    return oItemList;
        //}

        //public List<CItem> GetAllItem()
        //{
        //    List<CItem> oItemList = new List<CItem>();
        //    try
        //    {
        //        this.OpenConnection();
        //        string sSql = SqlQueries.GetQuery(Query.AllItem);//" Order BY NewID()";
        //        IDataReader oReader = this.ExecuteReader(sSql);
        //        if (oReader != null)
        //        {
        //            while (oReader.Read())
        //            {
        //                CItem oItem = ReaderToItem(oReader);
        //                oItemList.Add(oItem);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.Write("Exception : " + ex + " in GetAllItem()", LogLevel.Error, "Database");
        //        if (ex.GetType().Equals(typeof(SqlException)))
        //        {
        //            SqlException oSQLEx = ex as SqlException;
        //            if (oSQLEx.Number != 7619)
        //                throw new Exception("Exception occure at GetAllItem()", ex);
        //        }
        //        else
        //        {
        //            throw new Exception("Exception occure at GetAllItem()", ex);
        //        }
        //    }
        //    finally
        //    {
        //        this.CloseConnection();
        //    }
        //    return oItemList;
        //}

        public void DeleteExpiredItems()
        {
            try
            {
                //CCommonConstants oTempConstant = ConfigManager.GetConfig<CCommonConstants>();
                //this.OpenConnection();
                //string sSql = string.Format(SqlQueries.GetQuery(Query.DeleteExpiredItem), oTempConstant.ITEM_EXPIRE_DAYS);
                //this.ExecuteNonQuery(sSql);
            }
            catch (Exception ex)
            {
                Logger.Write("Exception : " + ex + " in DeleteExpiredItems()", LogLevel.Error, "Database");

                throw new Exception("Exception occure at DeleteExpiredItems()", ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }


        #endregion

        /// <summary>
        /// The caller query should contain following fields
        ///ci.item_id,ci.item_name,ci.item_desc,ci.item_price,ci.item_quantity,ci.item_unit,
        ///ci.item_currency,cd.district_id,cd.district_short_name,cd.district_full_name,
        ///cc1.category_id,cc1.category_name,cc2.category_id AS parent_category_id,
        ///cc2.category_name AS parent_category_name,cc2.parent_category_id AS parent_parent_category_id
        /// cc2.parent_category_id AS parent_parent_category_id,
        /// cs1.seller_id,cs1.mobile_no,cs1.seller_name,
        /// cs1.seller_address,cd2.district_id AS seller_district_id,
        /// cd2.district_short_name AS seller_district_short_name,
        /// cd2.district_full_name AS seller_district_full_name
        /// </summary>
        /// <param name="oReader"></param>
        /// <returns></returns>
        //private CItem ReaderToItem(IDataReader oReader)
        //{
        //    CItem oItem = new CItem();

        //    if (oReader["item_id"] != null)
        //        oItem.ItemId = new Guid(oReader["item_id"].ToString());

        //    if (oReader["item_name"] != null)
        //        oItem.ItemName = oReader["item_name"].ToString();

        //    if (oReader["item_desc"] != null)
        //        oItem.ItemDesc = oReader["item_desc"].ToString();

        //    if (oReader["item_price"] != null)
        //        oItem.ItemPrice = double.Parse(oReader["item_price"].ToString());

        //    if (oReader["item_quantity"] != null)
        //        oItem.ItemQuantity = double.Parse(oReader["item_quantity"].ToString());

        //    if (oReader["item_unit"] != null)
        //        oItem.ItemUnit = oReader["item_unit"].ToString();

        //    if (oReader["item_currency"] != null)
        //        oItem.ItemCurrency = oReader["item_currency"].ToString();

        //    if (oReader["district_id"] != null)
        //        oItem.ItemLocation.DistrictId = new Guid(oReader["district_id"].ToString());

        //    if (oReader["district_full_name"] != null)
        //        oItem.ItemLocation.DistrictName = oReader["district_full_name"].ToString();

        //    if (oReader["district_short_name"] != null)
        //        oItem.ItemLocation.DistrictShortName = oReader["district_short_name"].ToString();

        //    if (oReader["sub_category2_id"] != null)
        //        oItem.Category.CategoryId = new Guid(oReader["sub_category2_id"].ToString());

        //    if (oReader["sub_category2_name"] != null)
        //        oItem.Category.CategoryName= oReader["sub_category2_name"].ToString();

        //    if (oReader["sub_category2_unit"] != null)
        //        oItem.Category.Unit = oReader["sub_category2_unit"].ToString();


        //    if (oReader["sub_category_id"] != null)
        //        oItem.Category.ParentCategory = new CCategory(new Guid(oReader["sub_category_id"].ToString()));

        //    if (oReader["sub_category_name"] != null)
        //        oItem.Category.ParentCategory.CategoryName = oReader["sub_category_name"].ToString();

        //    if (oReader["category_id"] != null)
        //        oItem.Category.ParentCategory.ParentCategory = new CCategory(new Guid(oReader["category_id"].ToString()));

        //    if (oReader["category_name"] != null)
        //        oItem.Category.ParentCategory.ParentCategory.CategoryName = oReader["category_name"].ToString();

            
           
        //    if (oReader["seller_id"] != null)
        //        oItem.Seller.SellerId = new Guid(oReader["seller_id"].ToString());
            
        //    if (oReader["mobile_no"] != null)
        //        oItem.Seller.MobileNumber = Int64.Parse(oReader["mobile_no"].ToString());
            
        //    if (oReader["seller_name"] != null)
        //        oItem.Seller.SellerName = oReader["seller_name"].ToString();
            
        //    if (oReader["seller_address"] != null)
        //        oItem.Seller.SellerAddress = oReader["seller_address"].ToString();

        //    if (oReader["seller_district_id"] != null)
        //        oItem.Seller.District.DistrictId = new Guid(oReader["seller_district_id"].ToString());

        //    if (oReader["seller_district_short_name"] != null)
        //        oItem.Seller.District.DistrictShortName = oReader["seller_district_short_name"].ToString();

        //    if (oReader["seller_district_full_name"] != null)
        //        oItem.Seller.District.DistrictName = oReader["seller_district_full_name"].ToString();

        //    if (oReader["create_time"] != null)
        //        oItem.CreateTime = (DateTime)oReader["create_time"];

        //    return oItem;

        //}

    }//CItemDAO
}//nc
