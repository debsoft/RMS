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
   public  class TransactionDAO:BaseDAO
    {
       public void InsertTransactionForReport(Transaction aTransaction)
       {
           try
           {
               this.OpenConnection();
               string sqlComm = String.Format(SqlQueries.GetQuery(Query.InsertTransactionForReport),aTransaction.Category.CategoryId,
                   aTransaction.Category.CategoryName,aTransaction.Item.ItemId,aTransaction.Item.ItemName,aTransaction.Stock.Stocks,
                   aTransaction.Item.UnitName, aTransaction.Stock.UnitPrice, aTransaction.Stock.Stocks * aTransaction.Stock.UnitPrice,
                  aTransaction.TransactionDate,aTransaction.TransactionType,aTransaction.UserInfo.UserName,aTransaction.DamageReport);
               this.ExecuteNonQuery(sqlComm);


           }
           catch (Exception ex)
           {
               
               throw ex;
           }
           finally
           {
               this.CloseConnection();
           }
       }

       public List<Transaction> GetTransactionBetweenDate(DateTime fromdate, DateTime todate)
       {
           List<Transaction> aTransactions= new List<Transaction>();
           try
           {
               this.OpenConnection();
               string sqlComm = String.Format(SqlQueries.GetQuery(Query.GetTransactionBetweenDate), fromdate,
                                              todate);
               IDataReader aReader = this.ExecuteReader(sqlComm);
               if (aReader != null)
               {
                   while (aReader.Read())
                   {
                       Transaction aTransaction=new Transaction();
                       aTransaction = ReaderToReadInventoryTransaction(aReader);
                       aTransactions.Add(aTransaction);
                   }
               }

           }
           catch (Exception ex)
           {

               throw new Exception("GetTransactionBetweenDate()", ex);
           }
           finally
           {
               this.CloseConnection();
           }
           return aTransactions;
       }

       private Transaction ReaderToReadInventoryTransaction(IDataReader aReader)
       {

           Transaction aTransaction=new Transaction();
           InventoryCategory aCategory = new InventoryCategory();
           InventoryItem aItem = new InventoryItem();
           Unit aUnit = new Unit();
           CUserInfo aCUserInfo = new CUserInfo();
           Stock aStock = new Stock();
           


           try
           {
               aTransaction.TransactionId = Convert.ToInt32(aReader["transaction_id"]);

           }
           catch 
           {

           }


           try
           {
               aTransaction.TransactionType = (aReader["transaction_type"]).ToString();

           }
           catch
           {

           }
           try
           {
               aTransaction.TransactionDate = Convert.ToDateTime((aReader["date"]));

           }
           catch
           {

           }

           try
           {
               aTransaction.TransactionAmount = Convert.ToDouble(aReader["total_price"]);

           }
           catch
           {

           }
           try
           {
               aTransaction.DamageReport = (aReader["damage_report"]).ToString();

           }
           catch
           {

           }

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
               aUnit.UnitName = (aReader["unit"]).ToString();

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
               aCUserInfo.UserName = ((aReader["user_name"])).ToString();

           }
           catch
           {
           }
           try
           {
               aStock.Stocks = Convert.ToDouble(aReader["quantity"]);

           }
           catch
           {
           }
           try
           {
               aStock.UnitPrice = Convert.ToDouble(aReader["unit_price"]);

           }
           catch
           {
           }
           

           aTransaction.Category = aCategory;
           aTransaction.Item = aItem;
           aTransaction.Unit = aUnit;
           aTransaction.UserInfo = aCUserInfo;
           aTransaction.Stock = aStock;
           return aTransaction;

       }
    }
}
