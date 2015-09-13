using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BistroAdmin.DAO;
using Common.ObjectModel;
using RMS.Common.ObjectModel;



namespace BistroAdmin.BLL
{
   public  class StockBLL
    {
       public void InsertStockOrUpdate(Stock aStock)
       {
           Stock stock=new Stock();
           StockDAO aDao=new StockDAO();
           stock = aDao.GetStockByItemid(aStock.Item.ItemId);
           if(stock.StockId==0)
           {
               aDao.InsertStock(aStock);
           }
           else if(stock.StockId>0)
           {
               double pricePrevious = stock.Stocks*stock.UnitPrice;
               double priceNow = aStock.Stocks * aStock.UnitPrice;
               double totalStocks = stock.Stocks + aStock.Stocks;
               double totalPrice = priceNow + pricePrevious;
               stock.Stocks = totalStocks;
               if (totalStocks != 0 && totalPrice != 0)
               {
                   aStock.UnitPrice = totalPrice / totalStocks;
               }
               else aStock.UnitPrice = 0;
               stock.StockId = stock.StockId;
               aDao.UpdateStock(stock);
           }
       }

       public Stock GetStockByItemid(int itemId)
       {
           Stock stock = new Stock();
           StockDAO aDao = new StockDAO();
           stock = aDao.GetStockByItemid(itemId);
           return stock;
       }

       public Stock GetStockByItemidFrominventory_kitchen_stock(InventoryItem item)
       {
           Stock stock = new Stock();
           StockDAO aDao = new StockDAO();
           stock = aDao.GetStockByItemidFrominventory_kitchen_stock(item.ItemId);
           return stock;
       }

       public string InsertKitchenStock(Stock aStock)
       {
           Stock stock = new Stock();
           StockDAO aDao = new StockDAO();
           string sr = aDao.InsertKitchenStock(aStock);
           return sr;
       }

       public string UpdateKitchenStock(Stock aStock)
       {
           StockDAO aDao = new StockDAO();
           string sr = aDao.UpdateKitchenStock(aStock);
           return sr;
       }

       public string UpdateStockByStockId(Stock stock)
       {
           StockDAO aDao = new StockDAO();
           string sr = aDao.UpdateStockByStockId(stock);
           return sr;
       }

       public void UpdateKitchenStockByStockId(Stock cStock)
       {
           StockDAO aDao = new StockDAO();
           aDao.UpdateKitchenStockByStockId(cStock);
          
       }

       public void UpdateStockForDamage(Stock aStock)
       {
           Stock stock = new Stock();
           StockDAO aDao = new StockDAO();
           stock = aDao.GetStockByItemid(aStock.Item.ItemId);
           if (stock.StockId == 0)
           {
               aDao.InsertStock(aStock);
           }
           else if (stock.StockId > 0)
           {
               double pricePrevious = stock.Stocks * stock.UnitPrice;
               //double priceNow = aStock.Stocks * aStock.UnitPrice;
               double totalStocks = stock.Stocks - aStock.Stocks;
              // double totalPrice = priceNow + pricePrevious;
               stock.Stocks = totalStocks;
               if (pricePrevious != 0 && totalStocks != 0)
               {

                   stock.UnitPrice = pricePrevious / totalStocks;
               }
               else stock.UnitPrice = 0;
               stock.StockId = stock.StockId;
               aDao.UpdateStock(stock);
           }
       }

       public void UpdateKitchenStockForDamage(Stock aStock)
       {
           Stock stock = new Stock();
           StockDAO aDao = new StockDAO();
           stock = aDao.GetStockByItemidFrominventory_kitchen_stock(aStock.Item.ItemId);
           if (stock.StockId == 0)
           {
               aDao.InsertStock(aStock);
           }
           else if (stock.StockId > 0)
           {
               double pricePrevious = stock.Stocks * stock.UnitPrice;
               //double priceNow = aStock.Stocks * aStock.UnitPrice;
               double totalStocks = stock.Stocks - aStock.Stocks;
               // double totalPrice = priceNow + pricePrevious;
               stock.Stocks = totalStocks;
               if (pricePrevious != 0 && totalStocks != 0)
               {

                   stock.UnitPrice = pricePrevious / totalStocks;
               }
               else stock.UnitPrice = 0;
               stock.StockId = stock.StockId;
               aDao.UpdateKitchenStock(stock);
           }
       }


       public List<InventoryStockReport> GetAllStockForReport()
       {
            List<InventoryStockReport> aReports=new List<InventoryStockReport>();
            StockDAO aDao = new StockDAO();
           aReports = aDao.GetAllStockForReport();
           return aReports;

       }

       public List<InventoryStockReport> GetAllKitchenStockForReport()
       {
           List<InventoryStockReport> aReports = new List<InventoryStockReport>();
           StockDAO aDao = new StockDAO();
           aReports = aDao.GetAllKitchenStockForReport();
           return aReports;
       }


       public void UpdateKitchenStockForSendOut(Stock aStock)
       {
           Stock stock = new Stock();
           StockDAO aDao = new StockDAO();
           stock = aDao.GetStockByItemidFrominventory_kitchen_stock(aStock.Item.ItemId);
           if (stock.StockId == 0)
           {
               aDao.InsertStock(aStock);
           }
           else if (stock.StockId > 0)
           {
               double totalStocks = stock.Stocks - aStock.Stocks;
               // double totalPrice = priceNow + pricePrevious;
               stock.Stocks = totalStocks;
               stock.StockId = stock.StockId;
               aDao.UpdateKitchenStock(stock);
           }
       }
    }
}
