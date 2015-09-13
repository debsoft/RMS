using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BistroAdmin.DAO;
using Common.ObjectModel;
using RMS.Common.ObjectModel;

namespace BistroAdmin.BLL
{
   public  class InventoryCategoryBLL
    {
       public string InsertInventoryCategory(InventoryCategory aCategory)
       {
           InventoryCategoryDAO aDao=new InventoryCategoryDAO();
           string sr = aDao.InsertInventoryCategory(aCategory);
           return sr;
       }

       public List<InventoryCategory> GetAllCategory()
       {
           InventoryCategoryDAO aDao = new InventoryCategoryDAO();
           List<InventoryCategory> aList = new List<InventoryCategory>();
           aList = aDao.GetAllCategory();
         //  aList = aList.Sort((s1, s2) => s1.CompareTo(s2));
          aList= aList.OrderBy(alist => alist.CategoryName).ToList();
           return aList;
       }

       public bool CheckExit(string categoryName)
       {
           InventoryCategoryDAO aDao = new InventoryCategoryDAO();
           List<InventoryCategory> aList = new List<InventoryCategory>();
           aList = aDao.GetAllCategory();
           bool flag = false;
           foreach (InventoryCategory category in aList)
           {
               if (category.CategoryName.ToUpper() == categoryName.ToUpper()) flag = true;
           }
           if (flag) return true;
           return false;
       }
    }
}
