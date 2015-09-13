using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BistroAdmin.DAO;
using Common.ObjectModel;

namespace BistroAdmin.BLL
{
    public class InventoryKitchenStockReportBLL
    {

        InventoryItemBLL aInventoryItemBll=new InventoryItemBLL();
        public void InsertInventoryKitchenStock()
        {
            List<InventoryStockReport> aInventoryStockReports = new List<InventoryStockReport>();
            DateTime todate = DateTime.Today;
            DateTime fromdate = todate.AddDays(-1);
            todate = todate.AddSeconds(-1);
            aInventoryStockReports = GetTodayReport(fromdate,todate);
            InventoryKitchenStockReportDAO aInventoryKitchenStockReportDao = new InventoryKitchenStockReportDAO();
            aInventoryKitchenStockReportDao.InsertInventoryKitchenStock(aInventoryStockReports);

        }
        public void CheckInsertOrNotForKitchen()
        {
            InventoryKitchenStockReportDAO aInventoryKitchenStockReportDao = new InventoryKitchenStockReportDAO();
            bool check = aInventoryKitchenStockReportDao.CheckInsertOrNotForKitchen();
            if (check) InsertInventoryKitchenStock();
        }

        //public List<InventoryStockReport> GetInventoryStockReportBetweenDateForKitchen(DateTime fromdate, DateTime todate)
        //{
        //    List<InventoryStockReport> aInventoryStockReports = new List<InventoryStockReport>();
        //    List<InventoryStockReport> aInventoryStockReports1 = new List<InventoryStockReport>();
        //    InventoryKitchenStockReportDAO aInventoryKitchenStockReportDao = new InventoryKitchenStockReportDAO();
        //    aInventoryStockReports = aInventoryKitchenStockReportDao.GetInventoryStockReportBetweenDateForKitchen(fromdate, todate);

        //    if (todate >= DateTime.Today)
        //    {
        //        DateTime todate1 = DateTime.Today.AddDays(1);
        //        DateTime fromdate1 = DateTime.Today;
        //        todate1 = todate.AddSeconds(-1);
        //        aInventoryStockReports1 = GetTodayReport(fromdate1, todate1);
        //        foreach (InventoryStockReport report in aInventoryStockReports1)
        //        {
        //            aInventoryStockReports.Add(report);
        //        }
        //    }
        //    return aInventoryStockReports;
        //}

        public List<InventoryStockReport> GetTodayReport(DateTime fromdate, DateTime todate)
        {
            List<Transaction> aTransactions = new List<Transaction>();
            TransactionBLL aTransactionBll = new TransactionBLL();
            List<InventoryStockReport> aInventoryStockReports = new List<InventoryStockReport>();
            StockBLL aStockBll = new StockBLL();
            //DateTime todate = DateTime.Today.AddDays(1);
            //DateTime fromdate = DateTime.Today;
            //todate = todate.AddSeconds(-1);
            aTransactions = aTransactionBll.GetTransactionBetweenDate(fromdate, todate);
            aInventoryStockReports = aStockBll.GetAllKitchenStockForReport();

            foreach (InventoryStockReport report in aInventoryStockReports)
            {
                double  receive2 = 0, damage = 0, send = 0;

                receive2 = (from transaction in aTransactions
                            where ((transaction.TransactionType == "Send_to_Kitchen" || transaction.TransactionType == "Stock In") &&
                                transaction.Item.ItemId == report.ItemId)
                            select transaction.Stock.Stocks).Sum();
                damage = (from transaction in aTransactions
                          where (transaction.TransactionType == "Damage_in_kitchen" &&
                                transaction.Item.ItemId == report.ItemId)
                          select transaction.Stock.Stocks).Sum();
                send = (from transaction in aTransactions
                        where (transaction.TransactionType == "Return_from_Kitchen" &&
                              transaction.Item.ItemId == report.ItemId)
                        select transaction.Stock.Stocks).Sum();
                report.ReceivedQty =  receive2;
                report.SendQty = send;
                report.DamageQty = damage;
                report.Date = DateTime.Today;
            }
            return aInventoryStockReports;
        }

        public List<InventoryStockReport> GetInventoryKitchenStockReportBetweenDate(DateTime fromdate, DateTime todate)
        {
            List<InventoryStockReport> aInventoryStockReports = new List<InventoryStockReport>();
            List<InventoryStockReport> aInventoryStockReports1 = new List<InventoryStockReport>();
            InventoryKitchenStockReportDAO aInventoryStockReportDao = new InventoryKitchenStockReportDAO();
            aInventoryStockReports = aInventoryStockReportDao.GetInventoryKitchenStockReportBetweenDate(fromdate, todate);

            if (todate >= DateTime.Today)
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
            aInventoryStockReports = GetSaleReport(aInventoryStockReports,fromdate,todate);
            return aInventoryStockReports;
        }

        public List<InventoryStockReport> GetSaleReport(List<InventoryStockReport> aInventoryStockReports, DateTime fromdate, DateTime todate)
        {
            InventoryKitchenStockReportDAO aInventoryStockReportDao = new InventoryKitchenStockReportDAO();
            List<InventoryStockReport> aList=new List<InventoryStockReport>();
            aList = aInventoryStockReportDao.GetSaleReport(fromdate, todate);

            foreach (InventoryStockReport report in aInventoryStockReports)
            {
                report.BalancePrice = report.BalanceQty*report.UnitPrice;
                foreach (InventoryStockReport stockReport in aList)
                {
                    if(stockReport.Date==report.Date && stockReport.ItemId==report.ItemId)
                    {
                        report.SaleQty = stockReport.SaleQty;
                        report.Price = stockReport.Price;
                    }
                }
            }
             List<InventoryStockReport> aList2=new List<InventoryStockReport>();
            foreach (InventoryStockReport stockReport in aList)
            {
                int flag = 0;
                foreach (InventoryStockReport report in aInventoryStockReports)
                {
                    if (stockReport.Date == report.Date && stockReport.ItemId == report.ItemId)
                    {
                        flag = 1;
                    }
                }
                if (flag == 0)
                {
                    InventoryItem aInventoryItem = aInventoryItemBll.GetInventoryItem(stockReport.ItemId);
                    stockReport.ItemName = aInventoryItem.ItemName;
                    stockReport.CategoryName = aInventoryItem.CategoryName;

                    aList2.Add(stockReport);
                }
            }
            aInventoryStockReports.AddRange(aList2);
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

            strBody += "\r\n" + stringPrintFormater.CenterTextWithWhiteSpace("Kitchen Stock Report");
            // strBody += "\r\n";
            double totalRawCost = aReports.Sum(a => a.Price);
            strBody += "\r\n" + "Total Raw Costing= " + totalRawCost.ToString("F02");
            double balanceAmount = aReports.Sum(a => a.UnitPrice * a.BalanceQty);
            strBody += "\r\n" + stringPrintFormater.ItemLabeledText("Total Balance Price: " + balanceAmount, "");
            
            strBody += "\r\n";
            strBody += "\r\n" + stringPrintFormater.CreateDashedLine();

             strBody += "\r\n" + stringPrintFormater.GridCell("Date", 30, false);
            strBody += stringPrintFormater.GridCell("Item Name", 50, false);
            strBody += stringPrintFormater.GridCell("Received Qty.", 17, false);
             strBody += stringPrintFormater.GridCell("Send Qty.", 17, false);// Its should be active when Professional Package is active
            strBody += stringPrintFormater.GridCell("Damage Qty.", 17, false);
            strBody += stringPrintFormater.GridCell("Sale Qty.", 17, false);
            strBody += stringPrintFormater.GridCell("Balance Qty.", 17, false);
             strBody += stringPrintFormater.GridCell("Raw M.P.", 17, false);//// Its should be active when Professional Package is active
           // strBody += stringPrintFormater.GridCell("Advance Amount", 19, false);

            strBody += "\r\n" + stringPrintFormater.CreateDashedLine();

            foreach (InventoryStockReport report in aReports)
            {
                strBody += "\r\n" + stringPrintFormater.GridCell(report.Date.ToString(), 30, false);
                strBody += stringPrintFormater.GridCell(report.ItemName, 50, false);
                strBody += stringPrintFormater.GridCell(report.ReceivedQty.ToString("F02"), 17, false);
                  strBody += stringPrintFormater.GridCell(report.SendQty.ToString("F02"), 17, false);// Its should be active when Professional Package is active
                strBody += stringPrintFormater.GridCell(report.DamageQty.ToString("F02"), 17, false);
                strBody += stringPrintFormater.GridCell(report.SaleQty.ToString("F02"), 17, false);
                strBody += stringPrintFormater.GridCell(report.BalanceQty.ToString("F02"), 17, false);
                 strBody += stringPrintFormater.GridCell(report.Price.ToString("F02"), 17, false);// Its should be active when Professional Package is active
               // strBody += stringPrintFormater.GridCell(report.AdvanceAmount.ToString(), 19, false);
                strBody += "\r\n" + stringPrintFormater.CreateDashedLine();

            }


            strBody += aMethod.AddEndPart();


            return strBody;
        }
    }
}

