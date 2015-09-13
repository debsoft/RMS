using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Common.ObjectModel;
using RMS.Common.ObjectModel;
using RMS.DataAccess;

namespace BistroAdmin.DAO
{
   public  class InventoryPurchaseDAO:BaseDAO
    {
       public string InsertPurchase(InventoryPurchase aInventoryPurchase)
       {
           string sr = string.Empty;
           try
           {
               this.OpenConnection();
               string sqlCommand = String.Format(SqlQueries.GetQuery(Query.InsertPurchase),aInventoryPurchase.Category.CategoryId,aInventoryPurchase.Category.CategoryName,
                   aInventoryPurchase.Item.ItemId, aInventoryPurchase.Item.ItemName,aInventoryPurchase.Supplier.SupplierId,aInventoryPurchase.Supplier.Name,
                   aInventoryPurchase.Quantity,aInventoryPurchase.Unit.UnitName,aInventoryPurchase.Price,
                   aInventoryPurchase.Supplier.PaidAmount,aInventoryPurchase.Supplier.AdvanceAmount,
                   aInventoryPurchase.Supplier.DueAmount,aInventoryPurchase.Date,aInventoryPurchase.PaymentType,aInventoryPurchase.CUserInfo.UserName,
                   aInventoryPurchase.ExpireDate);
               this.ExecuteNonQuery(sqlCommand);
                   sr = "Purchase Insert Sucessfully";
           }
           catch
           {
               sr = "Please Try Again";
           }
           finally
           {
               this.CloseConnection();
           }
           return sr;

       }


       public List<InventoryPurchase> GetInventoryPurchaseBetweenDate(DateTime fromdate, DateTime todate)
       {
          List<InventoryPurchase> aInventoryPurchases=new List<InventoryPurchase>();
           try
           {
               this.OpenConnection();
               string sqlComm = String.Format(SqlQueries.GetQuery(Query.GetInventoryPurchaseBetweenDate), fromdate,
                                              todate);
               IDataReader aReader=this.ExecuteReader(sqlComm);
               if(aReader!=null)
               {
                   while (aReader.Read())
                   {
                       InventoryPurchase aInventoryPurchase=new InventoryPurchase();
                       aInventoryPurchase = ReaderToReadInventoryPurchase(aReader);
                       aInventoryPurchases.Add(aInventoryPurchase);
                   }
               }

           }
           catch (Exception ex)
           {

               throw new Exception("GetInventoryPurchaseBetweenDate()",ex);
           }
           finally
           {
               this.CloseConnection();
           }
           return aInventoryPurchases;
       }

       private InventoryPurchase ReaderToReadInventoryPurchase(IDataReader aReader)
       {
           InventoryPurchase aInventoryPurchase = new InventoryPurchase();
           InventoryCategory aCategory=new InventoryCategory();
           InventoryItem aItem=new InventoryItem();
           Supplier aSupplier=new Supplier();
           Unit aUnit = new Unit();
           CUserInfo aCUserInfo=new CUserInfo();

           try
           {
               aCategory.CategoryId = Convert.ToInt32(aReader["category_id"]);

           }
           catch
           {
               
           }
           try
           {

               aCategory.CategoryName = aReader["category_name"].ToString();
           }
           catch
           {               
           }
           

           try
           {
              aItem.ItemId = Convert.ToInt32(aReader["item_id"]);

           }
           catch
           {

           }
           try
           {
               aItem.ItemName = (aReader["item_name"]).ToString();

           }
           catch
           {

           }
           try
           {
               aSupplier.SupplierId = Convert.ToInt32(aReader["supplier_id"]);

           }
           catch
           {

           }
           try
           {
               aSupplier.Name =(aReader["supplier_name"]).ToString();

           }
           catch
           {

           }
           try
           {
               aInventoryPurchase.PurchaseId = Convert.ToInt32((aReader["purchase_id"]));

           }
           catch
           {

           }
         
           
           try
           {
               aInventoryPurchase.Quantity = Convert.ToDouble((aReader["quantity"]));

           }
           catch
           {
           }
           try
           {
              aUnit.UnitName = (aReader["unit"]).ToString();

           }
           catch
           {
           }
         

           try
           {
               aInventoryPurchase.Price = Convert.ToDouble((aReader["total_price"]));

           }
           catch
           {
           }
           try
           {
               aSupplier.PaidAmount = Convert.ToDouble((aReader["paid_amount"]));

           }
           catch
           {

           }
           try
           {
               aSupplier.AdvanceAmount = Convert.ToDouble((aReader["advance_amount"]));

           }
           catch
           {

           }
           try
           {
               aSupplier.DueAmount = Convert.ToDouble((aReader["due_amount"]));

           }
           catch
           {

           }
           try
           {
               aInventoryPurchase.Date = Convert.ToDateTime((aReader["date"]));

           }
           catch
           {
           }
           try
           {
               aInventoryPurchase.PaymentType = ((aReader["payment_type"])).ToString();

           }
           catch
           {
           }

           try
           {
               aCUserInfo.UserName = ((aReader["user_name"])).ToString();

           }
           catch
           {
           }

           try
           {
               aInventoryPurchase.ExpireDate = Convert.ToDateTime((aReader["ExpireDate"]));

           }
           catch
           {
           }


           aInventoryPurchase.Category = aCategory;
           aInventoryPurchase.Item = aItem;
           aInventoryPurchase.Supplier = aSupplier;
           aInventoryPurchase.Unit = aUnit;
           aInventoryPurchase.CUserInfo = aCUserInfo;
         


           return aInventoryPurchase;

          // DateTime aTime = DateTime.Now.AddDays(-1);

       }

       public List<InventoryPurchase> GetInventoryPurchaseById(int itemId)
       {
           List<InventoryPurchase> aInventoryPurchases = new List<InventoryPurchase>();
           try
           {
               this.OpenConnection();
               string sqlComm = String.Format(SqlQueries.GetQuery(Query.GetInventoryPurchaseById), itemId);
               IDataReader aReader = this.ExecuteReader(sqlComm);
               if (aReader != null)
               {
                   while (aReader.Read())
                   {
                       InventoryPurchase aInventoryPurchase = new InventoryPurchase();
                       aInventoryPurchase = ReaderToReadInventoryPurchase(aReader);
                       aInventoryPurchases.Add(aInventoryPurchase);
                   }
               }

           }
           catch (Exception ex)
           {

               throw new Exception("GetInventoryPurchaseBetweenDate()", ex);
           }
           finally
           {
               this.CloseConnection();
           }
           return aInventoryPurchases;
       }
    }
}
