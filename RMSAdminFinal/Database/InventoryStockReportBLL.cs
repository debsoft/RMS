using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BistroAdmin.DAO;
using Common.ObjectModel;

namespace BistroAdmin.BLL
{
   public  class InventoryStockReportBLL
    {
       
       public void InsertInventoryStock()
       {
           List<InventoryStockReport> aInventoryStockReports = new List<InventoryStockReport>();
           DateTime todate = DateTime.Today;
           DateTime fromdate = todate.AddDays(-1);
           todate = todate.AddSeconds(-1);
           aInventoryStockReports = GetTodayReport(fromdate, todate);
           InventoryStockReportDAO aInventoryStockReportDao=new InventoryStockReportDAO();
           aInventoryStockReportDao.InsertInventoryStock(aInventoryStockReports);

       }
       public void CheckInsertOrNot()
       {
           InventoryStockReportDAO aInventoryStockReportDao = new InventoryStockReportDAO();
           bool check = aInventoryStockReportDao.CheckInsertOrNot();
           if(check)InsertInventoryStock();
       }

       public List<InventoryStockReport> GetInventoryStockReportBetweenDate(DateTime fromdate, DateTime todate)
       {
           List<InventoryStockReport> aInventoryStockReports = new List<InventoryStockReport>();
           List<InventoryStockReport> aInventoryStockReports1 = new List<InventoryStockReport>();
           InventoryStockReportDAO aInventoryStockReportDao=new InventoryStockReportDAO();
           aInventoryStockReports = aInventoryStockReportDao.GetInventoryStockReportBetweenDate(fromdate, todate);

           if(todate>=DateTime.Today)
           {
               DateTime todate1 = DateTime.Today.AddDays(1);
               DateTime fromdate1 = DateTime.Today;
               todate1 = todate.AddSeconds(-1);
               aInventoryStockReports1 = GetTodayReport(fromdate1,todate1);
               foreach (InventoryStockReport report in aInventoryStockReports1)
               {
                   aInventoryStockReports.Add(report);
               }
           }
           return aInventoryStockReports;
       }

       public List<InventoryStockReport> GetTodayReport(DateTime fromdate,DateTime todate)
       {
           List<Transaction> aTransactions = new List<Transaction>();
           TransactionBLL aTransactionBll = new TransactionBLL();
           List<InventoryPurchase> aInventoryPurchases = new List<InventoryPurchase>();
           InventoryPurchaseBLL aInventoryPurchaseBll = new InventoryPurchaseBLL();
           List<InventoryStockReport> aInventoryStockReports = new List<InventoryStockReport>();
           StockBLL aStockBll = new StockBLL();
           //DateTime todate = DateTime.Today.AddDays(1);
           //DateTime fromdate = DateTime.Today;
           //todate = todate.AddSeconds(-1);
           aTransactions = aTransactionBll.GetTransactionBetweenDate(fromdate, todate);
           aInventoryPurchases = aInventoryPurchaseBll.GetInventoryPurchaseBetweenDate(fromdate, todate);
           aInventoryStockReports = aStockBll.GetAllStockForReport();

           foreach (InventoryStockReport report in aInventoryStockReports)
           {
               double receive1 = 0, receive2 = 0, damage = 0, send = 0;


               receive1 = (from purchase in aInventoryPurchases
                           where (purchase.Item.ItemId == report.ItemId)
                           select purchase.Quantity).Sum();
               receive2 = (from transaction in aTransactions
                           where (transaction.TransactionType == "Return_from_Kitchen" &&
                               transaction.Item.ItemId == report.ItemId)
                           select transaction.Stock.Stocks).Sum();
               damage = (from transaction in aTransactions
                         where (transaction.TransactionType == "Damage_in_Stock" &&
                               transaction.Item.ItemId == report.ItemId)
                         select transaction.Stock.Stocks).Sum();
               send = (from transaction in aTransactions
                       where (transaction.TransactionType == "Send_to_Kitchen" &&
                             transaction.Item.ItemId == report.ItemId)
                       select transaction.Stock.Stocks).Sum();
               report.ReceivedQty = receive1 + receive2;
               report.SendQty = send;
               report.DamageQty = damage;
               report.Date = DateTime.Today;
           }
           return aInventoryStockReports;
       }


       public string PrintKitchenStockReport(List<InventoryStockReport> aReports)
       {
           string strBody = "";
           StringPrintFormater stringPrintFormater = new StringPrintFormater(172);
           VariousMethod aMethod = new VariousMethod();
           string header = aMethod.GetPrintDecorationText(VariousMethod.PrintDecoration.HEADER);
           strBody += header;
           //   strBody += "\r\n";


           double balanceAmount = aReports.Sum(a => a.UnitPrice * a.BalanceQty);

           strBody += "\r\n" + stringPrintFormater.ItemLabeledText("Total Balance Price: "+balanceAmount,"");
           strBody += "\r\n" + stringPrintFormater.CenterTextWithWhiteSpace("Inventory Stock Report");
           // strBody += "\r\n";
           strBody += "\r\n";
           strBody += "\r\n" + stringPrintFormater.CreateDashedLine();

           strBody += "\r\n" + stringPrintFormater.GridCell("Date", 30, false);
           strBody += stringPrintFormater.GridCell("Item Name", 50, false);
           strBody += stringPrintFormater.GridCell("Received Qty.", 17, false);
           strBody += stringPrintFormater.GridCell("Send Qty.", 17, false);
           strBody += stringPrintFormater.GridCell("Damage Qty.", 17, false);
           strBody += stringPrintFormater.GridCell("Balance Qty.", 17, false);
           // strBody += stringPrintFormater.GridCell("Advance Amount", 19, false);

           strBody += "\r\n" + stringPrintFormater.CreateDashedLine();

           foreach (InventoryStockReport report in aReports)
           {
               strBody += "\r\n" + stringPrintFormater.GridCell(report.Date.ToString(), 30, false);
               strBody += stringPrintFormater.GridCell(report.ItemName, 50, false);
               strBody += stringPrintFormater.GridCell(report.ReceivedQty.ToString(), 17, false);
               strBody += stringPrintFormater.GridCell(report.SendQty.ToString(), 17, false);
               strBody += stringPrintFormater.GridCell(report.DamageQty.ToString(), 17, false);
               strBody += stringPrintFormater.GridCell(report.BalanceQty.ToString(), 17, false);
               // strBody += stringPrintFormater.GridCell(report.AdvanceAmount.ToString(), 19, false);
               strBody += "\r\n" + stringPrintFormater.CreateDashedLine();

           }


           strBody += aMethod.AddEndPart();


           return strBody;
       }
    }
}
