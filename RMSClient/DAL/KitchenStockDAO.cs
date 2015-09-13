using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RMS.Common.ObjectModel;
using RMS.DataAccess;

namespace RMSClient.DataAccess
{
   public  class KitchenStockDAO:BaseDAO
    {

       public KitchenStock GetStockByItemidFrominventory_kitchen_stock(int itemId)
       {
           KitchenStock stock = new KitchenStock();
           try
           {
               this.OpenConnection();
               string sqlComm = String.Format(SqlQueries.GetQuery(Query.GetStockByItemidFrominventory_kitchen_stock), itemId);
               IDataReader oReader = this.ExecuteReader(sqlComm);
               if (oReader != null)
               {
                   while (oReader.Read())
                   {
                       stock = ReaderToKitchenStock(oReader);
                   }
               }
             //  else stock.StockId = 0;

           }
           catch (Exception ex)
           {
               throw new Exception("GetStockByItemidFrominventory_kitchen_stock()",ex);
           }
           finally
           {
               this.CloseConnection();
           }
           return stock;
       }

       private KitchenStock ReaderToKitchenStock(IDataReader oReader)
       {
           KitchenStock aStock=new KitchenStock();
           try
           {
               aStock.KitchenStockId = Convert.ToInt32(oReader["kitchen_stock_id"]);
           }
           catch 
           {   
           }

           try
           {
               aStock.ItemId = Convert.ToInt32(oReader["item_id"]);
           }
           catch
           {
           }

           try
           {
               aStock.Stocks = Convert.ToDouble(oReader["stock"]);
           }
           catch
           {
           }
           try
           {
               aStock.ItemName = (oReader["item_name"]).ToString();
           }
           catch
           {
           }
           //unit_price
           try
           {
               aStock.UnitPrice = Convert.ToDouble(oReader["unit_price"]);
           }
           catch
           {
           }

           return aStock;
       }

     

       public void UpdateStock(int kitchenStockId, double stocks)
       {
         
           try
           {
               this.OpenConnection();
               string sqlcomm = String.Format(SqlQueries.GetQuery(Query.UpdateStock),
                          kitchenStockId,stocks);
               this.ExecuteNonQuery(sqlcomm);
              

           }
           catch (Exception ex)
           {

               throw new Exception("UpdateStock()",ex);
           }
           finally
           {
               this.CloseConnection();
           }
          
       }
    }
}
