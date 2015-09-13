using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BistroAdmin.DAO;
using Common.ObjectModel;

namespace BistroAdmin.BLL
{
    public class TransactionBLL
    {
        public string SendToKitchen(Transaction aTransaction)
        {
            string sr = string.Empty;
            TransactionDAO aDao=new TransactionDAO();
            Stock aStock=new Stock();
            StockBLL aBll=new StockBLL();
            aStock = aBll.GetStockByItemidFrominventory_kitchen_stock(aTransaction.Item);
            if(aStock.StockId==0)
            {
                
                aStock = aTransaction.Stock;
                aStock.Category = aTransaction.Category;
                aStock.Item = aTransaction.Item;
                sr = aBll.InsertKitchenStock(aStock);
            }
            else if (aStock.StockId > 0)
            {
                Stock stock=new Stock();
                stock = aTransaction.Stock;
                double pricePrevious = stock.Stocks * stock.UnitPrice;
                double priceNow = aStock.Stocks * aStock.UnitPrice;
                double totalStocks = stock.Stocks + aStock.Stocks;
                double totalPrice = priceNow + pricePrevious;
                aStock.Stocks = totalStocks;
                if (totalStocks != 0 && totalPrice != 0)
                {
                    aStock.UnitPrice = totalPrice / totalStocks;
                }
                else aStock.UnitPrice = 0;
                // aStock.StockId = stock.StockId;
               sr=aBll.UpdateKitchenStock(aStock);
            }
            if (sr == "Insert Sucessfully")
            {
                aDao.InsertTransactionForReport(aTransaction);
            }
            if (sr == "Insert Sucessfully")
            {
                Stock aaStock=new Stock();
                aaStock = aTransaction.Stock;
                aaStock.Stocks *= -1;
                 aBll.UpdateStockByStockId(aaStock);
            }
           

            return sr;
        }

        public string ReturnFromKitchen(Transaction aTransaction)
        {
            string sr="";
            try
            {
                TransactionDAO aDao = new TransactionDAO();
                aDao.InsertTransactionForReport(aTransaction); 
                StockBLL aBll = new StockBLL();
                Stock dStock=new Stock();
                dStock = aTransaction.Stock;
                aBll.InsertStockOrUpdate(dStock);
                Stock cStock = new Stock();
                cStock = aTransaction.Stock;
                cStock.Stocks *= -1;
                aBll.UpdateKitchenStockByStockId(cStock);
                sr = "Insert Successfully";
            }
            catch 
            {

                sr = "Plz Try again";
            }



            return sr;

        }

        public string DamageInStock(Transaction aTransaction)
        {
            string sr = string.Empty;
            try
            {
               TransactionDAO aDao=new TransactionDAO();
               aDao.InsertTransactionForReport(aTransaction); 
               StockBLL aStockBll = new StockBLL();
                aStockBll.UpdateStockForDamage(aTransaction.Stock);
                sr = "Save Successfully";
            }
            catch
            {
                sr = "Please Try Again";

            }
            return sr;

        }

        public string DamageInKitchen(Transaction aTransaction)
        {
            string sr = string.Empty;
            try
            {
                TransactionDAO aDao = new TransactionDAO();
                aDao.InsertTransactionForReport(aTransaction);
                StockBLL aStockBll = new StockBLL();
                aStockBll.UpdateKitchenStockForDamage(aTransaction.Stock);
                sr = "Save Successfully";
            }
            catch
            {
                sr = "Please Try Again";

            }
            return sr;
        }

        public List<Transaction> GetTransactionBetweenDate(DateTime fromdate, DateTime todate)
        {
            List<Transaction> aTransactions = new List<Transaction>();
            TransactionDAO aTransactionDao=new TransactionDAO();
            aTransactions = aTransactionDao.GetTransactionBetweenDate(fromdate, todate);
            return aTransactions;
        }

        public string PrintTransactionReport(List<TransationReport> aReports)
        {
            string strBody = "";
            StringPrintFormater stringPrintFormater = new StringPrintFormater(172);
            VariousMethod aMethod = new VariousMethod();
            string header = aMethod.GetPrintDecorationText(VariousMethod.PrintDecoration.HEADER);
            strBody += header;
            //   strBody += "\r\n";

            strBody += "\r\n" + stringPrintFormater.CenterTextWithWhiteSpace("Inventory Transaction Report");
            // strBody += "\r\n";
            strBody += "\r\n";
            strBody += "\r\n" + stringPrintFormater.CreateDashedLine();

            strBody += "\r\n" + stringPrintFormater.GridCell("Date", 23, false);
            strBody += stringPrintFormater.GridCell("Item Name", 45, false);
            strBody += stringPrintFormater.GridCell("Quantity", 17, false);
            strBody += stringPrintFormater.GridCell("Unit", 17, false);
           // strBody += stringPrintFormater.GridCell("Total Price", 17, false);// Its should be active when Professional Package is active
            strBody += stringPrintFormater.GridCell("Transaction Type", 21, false);
            strBody += stringPrintFormater.GridCell("Damage Report", 17, false);
            // strBody += stringPrintFormater.GridCell("Advance Amount", 19, false);

            strBody += "\r\n" + stringPrintFormater.CreateDashedLine();

            foreach (TransationReport report in aReports)
            {
                strBody += "\r\n" + stringPrintFormater.GridCell(report.Date.ToString(), 23, false);
                strBody += stringPrintFormater.GridCell(report.ItemName, 45, false);
                strBody += stringPrintFormater.GridCell(report.Quantity.ToString("F02"), 17, false);
                strBody += stringPrintFormater.GridCell(report.Unit, 17, false);
                // strBody += stringPrintFormater.GridCell(report.TotalPrice.ToString("F02"), 17, false);// Its should be active when Professional Package is active
                strBody += stringPrintFormater.GridCell(report.TransactionType, 21, false);
                strBody += stringPrintFormater.GridCell(report.DamageReport, 17, false);
                // strBody += stringPrintFormater.GridCell(report.AdvanceAmount.ToString(), 19, false);
                strBody += "\r\n" + stringPrintFormater.CreateDashedLine();

            }


            strBody += aMethod.AddEndPart();


            return strBody;
        }

        public string SendOutInKitchen(Transaction aTransaction)
        {
            string sr = string.Empty;
            try
            {
                TransactionDAO aDao = new TransactionDAO();
                aDao.InsertTransactionForReport(aTransaction);
                StockBLL aStockBll = new StockBLL();
                aStockBll.UpdateKitchenStockForSendOut(aTransaction.Stock);
                sr = "Save Successfully";
            }
            catch
            {
                sr = "Please Try Again";

            }
            return sr;
        }
    }
}
