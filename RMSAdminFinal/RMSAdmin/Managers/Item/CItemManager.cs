using System;
using System.Collections.Generic;
using System.Text;
using RMS.Common;
using RMS.DataAccess;
using System.Collections;
using RMS.Common.ObjectModel;


namespace RMS
{
    namespace Managers
    {
        public class CItemManager
        {
            private CResult m_oResult;

            public CItemManager()
            {
                m_oResult = new CResult();
            }

            ///// <summary>
            ///// This method Insert Item
            ///// </summary>
            ///// <param name="oItem"></param>
            ///// <returns></returns>
            ////public CResult InsertItem( CItem oInItem)
            ////{
            ////    try
            ////    {
            ////        CItem oItem = new CItem();

            ////        oItem = oInItem;
            ////        CResult oResult;
            ////        //Checking User
            ////        CSellerManager oSellerMgr = new CSellerManager();
            ////        oResult = oSellerMgr.GetSellerByMobileNo(oItem.Seller);
            ////        if (oResult.IsSuccess && oResult.Data != null)
            ////        {
            ////            oItem.Seller = (CSeller)oResult.Data;
            ////            CDistrictManager oDistrictMgr = new CDistrictManager();
            ////            //Checking location
            ////            if (oItem.ItemLocation.DistrictName != String.Empty)
            ////            {
            ////                oResult = oDistrictMgr.GetDistrictByFullName(oItem.ItemLocation);
            ////            }
            ////            else if (oItem.ItemLocation.DistrictShortName != String.Empty)
            ////            {
            ////                oResult = oDistrictMgr.GetDistrictByShortName(oItem.ItemLocation);
            ////            }
            ////            else
            ////            {
            ////                oResult.Data = oItem.Seller.District;
            ////            }
            ////            if (oResult.IsSuccess && oResult.Data != null)
            ////            {
            ////                oItem.ItemLocation = (CDistrict)oResult.Data;
            ////                //Checking category
            ////                CCategoryManager oCategoryMgr = new CCategoryManager();
            ////                oResult = oCategoryMgr.CategoryGetByName(oItem.Category);
            ////                if (oResult.IsSuccess && oResult.Data != null)
            ////                {
            ////                    oItem.Category = (CCategory)oResult.Data;
            ////                    Database.Instance.Item.ItemInsert(oItem);
            ////                    m_oResult.IsSuccess = true;
            ////                    m_oResult.Message = "Data Inserted Successfully";
            ////                }//Category Check
            ////                else
            ////                {
            ////                    m_oResult.IsSuccess = false;
            ////                    m_oResult.Action = EERRORNAME.CATEGORY_NOT_FOUND;
            ////                    m_oResult.SetParams(oItem.Category.ParentCategory.ParentCategory.CategoryName,oItem.Category.ParentCategory.CategoryName, oItem.Category.CategoryName);
            ////                    m_oResult.Message = "Category is not valid.";
            ////                }
            ////            }//Location Check
            ////            else
            ////            {
            ////                m_oResult.IsSuccess = false;
            ////                m_oResult.Action = EERRORNAME.LOCATION_NOT_FOUND;
            ////                if (oItem.ItemLocation.DistrictName != String.Empty)
            ////                    m_oResult.SetParams(oItem.ItemLocation.DistrictName);
            ////                else
            ////                    m_oResult.SetParams(oItem.ItemLocation.DistrictShortName);
            ////                m_oResult.Message = "Location is not valid.";
            ////            }
            ////        }//User Check
            ////        else
            ////        {
            ////            m_oResult.IsSuccess = false;
            ////            m_oResult.Action = EERRORNAME.USER_NOT_REGISTERED;
            ////            m_oResult.SetParams(oItem.Seller.MobileNumber);
            ////            m_oResult.Message = "User is not registerd";
            ////        }
            ////    }
            ////    catch (Exception ex)
            ////    {
            ////        System.Console.WriteLine("Exception occuer at InsertItem() : " + ex.Message);
            ////        m_oResult.IsException = true;
            ////        m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
            ////        //m_oResult.SetParams(ex.Message);
            ////        m_oResult.SetParams(oInItem.Seller.MobileNumber);
            ////        m_oResult.Message = ex.Message;
            ////        Logger.Write("Exception : " + ex + " in InsertItem()", LogLevel.Error, "CItemManager");
            ////    }
            ////    return m_oResult;
            ////}

            /////// <summary>
            /////// This method update Item
            /////// </summary>
            /////// <param name="oItem"></param>
            /////// <returns></returns>
            ////public CResult UpdateItem(CItem oItem)
            ////{
            ////    try
            ////    {
            ////        CResult oResult;
            ////        //Checking User
            ////        CSellerManager oSellerMgr = new CSellerManager();
            ////        oResult = oSellerMgr.GetSellerByMobileNo(oItem.Seller);
            ////        if (oResult.IsSuccess && oResult.Data != null)
            ////        {
            ////            oItem.Seller = (CSeller)oResult.Data;
            ////            CDistrictManager oDistrictMgr = new CDistrictManager();
            ////            //Checking location
            ////            if (oItem.ItemLocation.DistrictName != String.Empty)
            ////            {
            ////                oResult = oDistrictMgr.GetDistrictByFullName(oItem.ItemLocation);
            ////            }
            ////            else if (oItem.ItemLocation.DistrictShortName != String.Empty)
            ////            {
            ////                oResult = oDistrictMgr.GetDistrictByShortName(oItem.ItemLocation);
            ////            }
            ////            else
            ////            {
            ////                oResult.Data = oItem.Seller.District;
            ////            }
            ////            if (oResult.IsSuccess && oResult.Data != null)
            ////            {
            ////                oItem.ItemLocation = (CDistrict)oResult.Data;
            ////                //Checking category
            ////                CCategoryManager oCategoryMgr = new CCategoryManager();
            ////                oResult = oCategoryMgr.CategoryGetByName(oItem.Category);
            ////                if (oResult.IsSuccess && oResult.Data != null)
            ////                {
            ////                    oItem.Category = (CCategory)oResult.Data;
            ////                    Database.Instance.Item.ItemDelete(oItem);
            ////                    m_oResult.IsSuccess = true;
            ////                    m_oResult.Message = "Data Update Successful";
            ////                }//Category check
            ////                else
            ////                {
            ////                    m_oResult.IsSuccess = false;
            ////                    m_oResult.Action = EERRORNAME.CATEGORY_NOT_FOUND;
            ////                    //m_oResult.SetParams(oItem.Category.ParentCategory.CategoryName, oItem.Category.CategoryName);
            ////                    m_oResult.SetParams(oItem.Category.ParentCategory.ParentCategory.CategoryName, oItem.Category.ParentCategory.CategoryName, oItem.Category.CategoryName);
            ////                    m_oResult.Message = "Category is not valid.";
            ////                }
            ////            }//Location Check
            ////            else
            ////            {
            ////                m_oResult.IsSuccess = false;
            ////                m_oResult.Action = EERRORNAME.LOCATION_NOT_FOUND;
            ////                m_oResult.Message = "Location is not valid.";
            ////                if (oItem.ItemLocation.DistrictName != String.Empty)
            ////                    m_oResult.SetParams(oItem.ItemLocation.DistrictName);
            ////                else
            ////                    m_oResult.SetParams(oItem.ItemLocation.DistrictShortName);
            ////            }
            ////        }//User Check
            ////        else
            ////        {
            ////            m_oResult.IsSuccess = false;
            ////            m_oResult.Action = EERRORNAME.USER_NOT_REGISTERED;
            ////            m_oResult.SetParams(oItem.Seller.MobileNumber);
            ////            m_oResult.Message = "User is not registerd";
            ////        }

            ////    }
            ////    catch (Exception ex)
            ////    {
            ////        System.Console.WriteLine("Exception occuer at UpdateItem() : " + ex.Message);
            ////        m_oResult.IsException = true;
            ////        m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
            ////        m_oResult.SetParams(ex.Message);
            ////        m_oResult.Message = ex.Message;
            ////        Logger.Write("Exception : " + ex + " in UpdateItem()", LogLevel.Error, "CItemManager");
            ////    }
            ////    return m_oResult;
            ////}

            ///// <summary>
            ///// This method delete Item
            ///// </summary>
            ///// <param name="oItem"></param>
            ///// <returns></returns>
            //public CResult SaveProductPLU(int )
            //{
            //    try
            //    {
            //        Database.Instance.Item.ItemDelete(oItem);
            //        m_oResult.IsSuccess = true;
            //        m_oResult.Message = "Data Delete Successful";
            //        m_oResult.Data = oItem;
            //    }
            //    catch (Exception ex)
            //    {
            //        System.Console.WriteLine("Exception occuer at DeleteItem() : " + ex.Message);
            //        m_oResult.IsException = true;
            //        m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
            //        m_oResult.SetParams(ex.Message);
            //        m_oResult.Message = ex.Message;
            //        Logger.Write("Exception : " + ex + " in DeleteItem()", LogLevel.Error, "CItemManager");
            //    }
            //    return m_oResult;
            //}

            ///// <summary>
            ///// This method delete Item
            ///// </summary>
            ///// <param name="oItem"></param>
            ///// <returns></returns>
            //public CResult DeleteItemBySeller(CSeller oSeller)
            //{
            //    try
            //    {
            //        Database.Instance.Item.ItemDelete(oSeller);
            //        m_oResult.IsSuccess = true;
            //        m_oResult.Message = "Data Delete Successful";
            //    }
            //    catch (Exception ex)
            //    {
            //        System.Console.WriteLine("Exception occuer at DeleteItemBySeller() : " + ex.Message);
            //        m_oResult.IsException = true;
            //        m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
            //        m_oResult.Message = ex.Message;
            //        m_oResult.SetParams(ex.Message);
            //        Logger.Write("Exception : " + ex + " in DeleteItemBySeller()", LogLevel.Error, "CItemManager");
            //    }
            //    return m_oResult;
            //}

            ///// <summary>
            ///// This method return item list by user
            ///// </summary>
            ///// <param name="oSeller"></param>
            ///// <returns></returns>
            //public CResult GetItemListBySeller(CSeller oSeller)
            //{
            //    try
            //    {
            //        List<CItem> oItemList = Database.Instance.Item.ItemListBySeller(oSeller);
            //        m_oResult.Data = oItemList;
            //        m_oResult.IsSuccess = true;
            //        m_oResult.Message = "Data Read Successful";
            //    }
            //    catch (Exception ex)
            //    {
            //        System.Console.WriteLine("Exception occuer at GetItemListBySeller() : " + ex.Message);
            //        m_oResult.IsException = true;
            //        m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
            //        m_oResult.SetParams(ex.Message);
            //        m_oResult.Message = ex.Message;
            //        Logger.Write("Exception : " + ex + " in GetItemListBySeller()", LogLevel.Error, "CItemManager");
            //    }
            //    return m_oResult;
            //}


            //public CResult GetItemById(Guid gItemId)
            //{
            //    try
            //    {
            //        CItem oItem = Database.Instance.Item.ItemGetById(gItemId);
            //        m_oResult.Data = oItem;
            //        m_oResult.IsSuccess = true;
            //        m_oResult.Message = "Data Read Successful";
            //    }
            //    catch (Exception ex)
            //    {
            //        System.Console.WriteLine("Exception occuer at GetItemById() : " + ex.Message);
            //        m_oResult.IsException = true;
            //        m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
            //        m_oResult.SetParams(ex.Message);
            //        m_oResult.Message = ex.Message;
            //        Logger.Write("Exception : " + ex + " in GetItemById()", LogLevel.Error, "CItemManager");
            //    }
            //    return m_oResult;
            //}

            ///// <summary>
            ///// This method return item list by user
            ///// </summary>
            ///// <param name="oSeller"></param>
            ///// <returns></returns>
            //public CResult GetItemListForSearch(string sSearchQuery)
            //{
            //    try
            //    {
            //        List<CItem> oItemList = Database.Instance.Item.ItemListBySearch(sSearchQuery);
            //        m_oResult.Data = oItemList;
            //        m_oResult.IsSuccess = true;
            //        m_oResult.Message = "Data Read Successful";
            //    }
            //    catch (Exception ex)
            //    {
            //        System.Console.WriteLine("Exception occuer at GetItemListForSearch() : " + ex.Message);
            //        m_oResult.IsException = true;
            //        m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
            //        m_oResult.SetParams(ex.Message);
            //        m_oResult.Message = ex.Message;
            //        Logger.Write("Exception : " + ex + " in GetItemListForSearch()", LogLevel.Error, "CItemManager");
            //    }
            //    return m_oResult;
            //}

            //public CResult GetAllItem()
            //{
            //    try
            //    {
            //        List<CItem> oItemList = Database.Instance.Item.GetAllItem();
            //        m_oResult.Data = oItemList;
            //        m_oResult.IsSuccess = true;
            //        m_oResult.Message = "Data Read Successful";
            //    }
            //    catch (Exception ex)
            //    {
            //        System.Console.WriteLine("Exception occuer at GetItemListBySeller() : " + ex.Message);
            //        m_oResult.IsException = true;
            //        m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
            //        m_oResult.SetParams(ex.Message);
            //        m_oResult.Message = ex.Message;
            //        Logger.Write("Exception : " + ex + " in GetItemListBySeller()", LogLevel.Error, "CItemManager");
            //    }
            //    return m_oResult;
            //}

            //public CResult DeleteExpiredItems()
            //{
            //    try
            //    {
            //        Database.Instance.Item.DeleteExpiredItems();                    
            //        m_oResult.IsSuccess = true;
            //        m_oResult.Message = "Data Read Successful";
            //    }
            //    catch (Exception ex)
            //    {
            //        System.Console.WriteLine("Exception occuer at GetItemById() : " + ex.Message);
            //        m_oResult.IsException = true;
            //        m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
            //        m_oResult.SetParams(ex.Message);
            //        m_oResult.Message = ex.Message;
            //        Logger.Write("Exception : " + ex + " in GetItemById()", LogLevel.Error, "CItemManager");
            //    }
            //    return m_oResult;
            //}


        }//CItemManager
    }//ns
}//ns
