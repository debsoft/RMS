using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BistroAdmin.DAO;
using Common.ObjectModel;
using RMS.Common.ObjectModel;

namespace BistroAdmin.BLL
{
   public  class InventoryItemBLL
    {
       public string InsertInventoryItem(InventoryItem aItem)
       {
           InventoryItemDAO aDao=new InventoryItemDAO();
           string sr = aDao.InsertInventoryItem(aItem);
           return sr;
       }


       public List<InventoryItem> GetItemByCategory(int categoryId)
       {
           InventoryItemDAO aDao=new InventoryItemDAO();
           List<InventoryItem> aList=new List<InventoryItem>();
           aList = aDao.GetItemByCategory(categoryId);
           aList = aList.OrderBy(alist => alist.ItemName).ToList();
           return aList;
       }

       public bool CheckExit(string itemName)
       {
           InventoryItemBLL aBll = new InventoryItemBLL();
           List<InventoryItem> aList = new List<InventoryItem>();
           aList = aBll.GetAllItem();
           bool flag = false;
           foreach (InventoryItem inventoryItem in aList)
           {
               if (inventoryItem.ItemName.ToUpper() == itemName.ToUpper()) flag = true;
           }
           if (flag) return true;
           return false;
       }

       private List<InventoryItem> GetAllItem()
       {
           InventoryItemDAO aDao = new InventoryItemDAO();
           List<InventoryItem> aList = new List<InventoryItem>();
           aList = aDao.GetAllItem();
           aList = aList.OrderBy(alist => alist.ItemName).ToList();
           return aList;
       }
       public string UpdateItem(InventoryItem aInventoryItem)
       {
           InventoryItemDAO aDao = new InventoryItemDAO();
           string result = aDao.UpdateItem(aInventoryItem);
           return result;
       }

       public InventoryItem GetInventoryItem(int itemId)
       {
           InventoryItemDAO aDao = new InventoryItemDAO();
           InventoryItem aInventoryItem = new InventoryItem();
           aInventoryItem = aDao.GetInventoryItem(itemId);
           return aInventoryItem;
       }
       public DataTable GetItemByCategoryintoTable(int categoryId)
       {
           InventoryItemDAO aDao = new InventoryItemDAO();
           DataTable aDataTable = new DataTable();
           aDataTable = aDao.GetItemByCategoryintoTable(categoryId);
           return aDataTable;
       }
       public bool DeleteItem(int itemId)
       {
           InventoryItemDAO aDao = new InventoryItemDAO();
           bool result = aDao.DeleteItem(itemId);
           return result;
       }
    }
}
