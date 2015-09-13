using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common.ObjectModel;
using RMS.Common.ObjectModel;
using RMS.DataAccess;

namespace BistroAdmin.DAO
{
   public  class StockDAO:BaseDAO
    {
      
       public Stock GetStockByCategoryAndItem(Stock aStock)
       {
           Stock stock=new Stock();
           try
           {
               this.OpenConnection();
               string sqlComm = String.Format(SqlQueries.GetQuery(Query.GetStockByCategoryAndItem), aStock.Category.CategoryId,
                                              aStock.Item.ItemId);
               IDataReader oReader = this.ExecuteReader(sqlComm);
               if (oReader != null)
               {
                   while (oReader.Read())
                   {
                       stock = ReaderToStock(oReader);
                   }
               }
               else stock.StockId = 0;

           }
           catch(Exception ex)
           {
               MessageBox.Show("Ooops " + ex);
           }
           finally
           {
               this.CloseConnection();
           }
           return stock;
          
       }

       private Stock ReaderToStock(IDataReader oReader)
       {
           Stock aStock=new Stock();
           try
           {
               aStock.StockId = Convert.ToInt32(oReader["stock_id"]);
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
               aStock.UnitPrice = Convert.ToDouble(oReader["unit_price"]);
           }
           catch
           {
           }
           return aStock;
       }

       public void InsertStock(Stock aStock)
       {
           try
           {
               this.OpenConnection();
               string sqlcomm = String.Format(SqlQueries.GetQuery(Query.InsertStock), aStock.Category.CategoryId,
                            aStock.Category.CategoryName,aStock.Item.ItemId,aStock.Item.ItemName,
                            aStock.Stocks,aStock.Unit.UnitName,aStock.UnitPrice);
               this.ExecuteNonQuery(sqlcomm);

           }
           catch (Exception ex)
           {

               MessageBox.Show("ohh No " + ex);
           }
           finally
           {
               this.CloseConnection();
           }
       }

       public void UpdateStock(Stock aStock)
       {
           try
           {
               this.OpenConnection();
               string sqlcomm = String.Format(SqlQueries.GetQuery(Query.UpdateStocks), 
                            aStock.Stocks, aStock.UnitPrice,aStock.StockId);
               this.ExecuteNonQuery(sqlcomm);

           }
           catch (Exception ex)
           {

               MessageBox.Show("ohh No " + ex);
           }
           finally
           {
               this.CloseConnection();
           }
       }

       public Stock GetStockByItemid(int itemId)
       {
           Stock stock = new Stock();
           try
           {
               this.OpenConnection();
               string sqlComm = String.Format(SqlQueries.GetQuery(Query.GetStockByItemid), itemId
                                              );
               IDataReader oReader = this.ExecuteReader(sqlComm);
               if (oReader != null)
               {
                   while (oReader.Read())
                   {
                       stock = ReaderToStock(oReader);
                   }
               }
               else stock.StockId = 0;

           }
           catch (Exception ex)
           {
               MessageBox.Show("Ooops " + ex);
           }
           finally
           {
               this.CloseConnection();
           }
           return stock;
       }

       public Stock GetStockByItemidFrominventory_kitchen_stock(int itemId)
       {
           Stock stock = new Stock();
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
               else stock.StockId = 0;

           }
           catch (Exception ex)
           {
               MessageBox.Show("Ooops " + ex);
           }
           finally
           {
               this.CloseConnection();
           }
           return stock;
       }

       private Stock ReaderToKitchenStock(IDataReader oReader)
       {
           Stock aStock = new Stock();
           try
           {
               aStock.StockId = Convert.ToInt32(oReader["kitchen_stock_id"]);
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
               aStock.UnitPrice = Convert.ToDouble(oReader["unit_price"]);
           }
           catch
           {
           }
           return aStock;
       }

       public string InsertKitchenStock(Stock aStock)
       {
           string sr = string.Empty;
           try
           {
               this.OpenConnection();
               string sqlcomm = String.Format(SqlQueries.GetQuery(Query.InsertKitchenStock), aStock.Category.CategoryId,
                            aStock.Category.CategoryName, aStock.Item.ItemId, aStock.Item.ItemName,
                            aStock.Stocks, aStock.Item.UnitName, aStock.UnitPrice);
               this.ExecuteNonQuery(sqlcomm);
               sr = "Insert Sucessfully";


           }
           catch (Exception ex)
           {

               MessageBox.Show("ohh No " + ex);
           }
           finally
           {
               this.CloseConnection();
           }
           return sr;
       }

       public string UpdateKitchenStock(Stock aStock)
       {
           string sr = string.Empty;
           try
           {
               this.OpenConnection();
               string sqlcomm = String.Format(SqlQueries.GetQuery(Query.UpdateKitchenStock),
                            aStock.Stocks, aStock.UnitPrice, aStock.StockId);
               this.ExecuteNonQuery(sqlcomm);
               sr = "Insert Sucessfully";

           }
           catch (Exception ex)
           {

               MessageBox.Show("ohh No " + ex);
           }
           finally
           {
               this.CloseConnection();
           }
           return sr;
       }

       public string UpdateStockByStockId(Stock stock)
       {
           string sr = string.Empty;
           try
           {
               this.OpenConnection();
               string sqlcomm = String.Format(SqlQueries.GetQuery(Query.UpdateStockByStockId),
                            stock.Stocks,stock.StockId);
               this.ExecuteNonQuery(sqlcomm);
               sr = "Update Sucessfully";

           }
           catch (Exception ex)
           {

               MessageBox.Show("ohh No " + ex);
           }
           finally
           {
               this.CloseConnection();
           }
           return sr;
       }

       public void UpdateKitchenStockByStockId(Stock cStock)
       {
           
           try
           {
               this.OpenConnection();
               string sqlcomm = String.Format(SqlQueries.GetQuery(Query.UpdateKitchenStockByStockId),
                            cStock.Stocks, cStock.StockId);
               this.ExecuteNonQuery(sqlcomm);
               

           }
           catch (Exception ex)
           {

               MessageBox.Show("ohh No " + ex);
           }
           finally
           {
               this.CloseConnection();
           }
         
       }


       public List<InventoryStockReport> GetAllStockForReport()
       {
           List<InventoryStockReport> aReports = new List<InventoryStockReport>();
           try
           {
               this.OpenConnection();
               string sqlComm = String.Format(SqlQueries.GetQuery(Query.AllInventoryStock));
               IDataReader aReader = this.ExecuteReader(sqlComm);
               if(aReader!=null)
               {
                   while(aReader.Read())
                   {
                       InventoryStockReport aReport=new InventoryStockReport();
                       aReport = ReaderToReadAllStock(aReader);
                       aReports.Add(aReport);
                   }
               }

           }
           catch (Exception ex)
           {

               throw new Exception("GetAllStockForReport()", ex);
           }
           finally
           {
               this.CloseConnection();
           }
           return aReports;
       }

       private InventoryStockReport ReaderToReadAllStock(IDataReader aReader)
       {
           InventoryStockReport aStockReport=new InventoryStockReport();
           try
           {
               aStockReport.CategoryId = Convert.ToInt32(aReader["category_id"]);
           }
           catch 
           {
           }
           try
           {
               aStockReport.CategoryName = (aReader["category_name"]).ToString();
           }
           catch
           {
           }
           try
           {
               aStockReport.ItemId = Convert.ToInt32(aReader["item_id"]);
           }
           catch
           {
           }
           try
           {
               aStockReport.ItemName = (aReader["item_name"]).ToString();
           }
           catch
           {
           }
             
           
           try
           {
               aStockReport.BalanceQty= Convert.ToDouble(aReader["stock"]);
           }
           catch
           {
           }
           try
           {
               aStockReport.Unit = (aReader["unit"]).ToString();
           }
           catch
           {
           }
           try
           {
               aStockReport.UnitPrice = Convert.ToDouble(aReader["unit_price"]);
           }
           catch
           {
           }
           return aStockReport;


       }

       public List<InventoryStockReport> GetAllKitchenStockForReport()
       {
           List<InventoryStockReport> aReports = new List<InventoryStockReport>();
           try
           {
               this.OpenConnection();
               string sqlComm = String.Format(SqlQueries.GetQuery(Query.AllInventoryKitchenStock));
               IDataReader aReader = this.ExecuteReader(sqlComm);
               if (aReader != null)
               {
                   while (aReader.Read())
                   {
                       InventoryStockReport aReport = new InventoryStockReport();
                       aReport = ReaderToReadAllStock(aReader);
                       aReports.Add(aReport);
                   }
               }

           }
           catch (Exception ex)
           {

               throw new Exception("GetAllKitchenStockForReport()", ex);
           }
           finally
           {
               this.CloseConnection();
           }
           return aReports;
       }


       public void InsertOrUpdateSaleRawmaterialsReport(int itemId,double orderQty,double unitPrice)
       {


           try
           {
               this.OpenConnection();




                       int flag = 0;
                       string sqlComm = String.Format(SqlQueries.GetQuery(Query.ExitOrNot), itemId,
                                                      DateTime.Now.Date);
                       IDataReader aReader = this.ExecuteReader(sqlComm);
                       if (aReader != null)
                       {
                           while (aReader.Read())
                           {
                               flag = Convert.ToInt32(aReader["sale_id"]);
                           }
                           aReader.Close();
                       }
                       if (flag == 0)
                       {
                           sqlComm = String.Format(SqlQueries.GetQuery(Query.InsertSalereport), itemId,
                                  orderQty, unitPrice * orderQty,
                                  DateTime.Now.Date);
                           this.ExecuteNonQuery(sqlComm);
                       }
                       if (flag > 0)
                       {
                           sqlComm = String.Format(SqlQueries.GetQuery(Query.UpdateSalereport),
                                         orderQty, unitPrice * orderQty, flag);
                           this.ExecuteNonQuery(sqlComm);
                       }



                   

               

           }
           catch (Exception ex)
           {

               throw new Exception("InsertOrUpdateSaleRawmaterialsReport()", ex);
           }
           finally
           {
               this.CloseConnection();
           }
       }

    }
}
