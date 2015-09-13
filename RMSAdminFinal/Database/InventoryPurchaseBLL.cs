using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BistroAdmin.DAO;
using Common.ObjectModel;
using RMS.Common.ObjectModel;

namespace BistroAdmin.BLL
{
   public  class InventoryPurchaseBLL
    {
       public string InsertPurchase(InventoryPurchase aInventoryPurchase)
       {
           InventoryPurchaseDAO aDao=new InventoryPurchaseDAO();
           string sr = aDao.InsertPurchase(aInventoryPurchase);
           return sr;
       }

       public List<InventoryPurchase> GetInventoryPurchaseBetweenDate(DateTime fromdate, DateTime todate)
       {
           List<InventoryPurchase> aInventoryPurchases = new List<InventoryPurchase>();
           InventoryPurchaseDAO aDao = new InventoryPurchaseDAO();
           aInventoryPurchases = aDao.GetInventoryPurchaseBetweenDate(fromdate, todate);
           return aInventoryPurchases;
       }

       public string PrintPurchaseReport(List<InventoryReport> aReports)
       {
           string strBody = "";
           StringPrintFormater stringPrintFormater = new StringPrintFormater(172);
           VariousMethod aMethod = new VariousMethod();
           string header = aMethod.GetPrintDecorationText(VariousMethod.PrintDecoration.HEADER);
           strBody += header;
           //   strBody += "\r\n";
           double totalPrice = aReports.Sum(a => a.TotalAmount);
           strBody += "\r\n" + stringPrintFormater.ItemLabeledText("Total Purchase Price: " + totalPrice, "");
           strBody += "\r\n" + stringPrintFormater.CenterTextWithWhiteSpace("Inventory Purchase Report");
           // strBody += "\r\n";
           strBody += "\r\n";
           strBody += "\r\n" + stringPrintFormater.CreateDashedLine();

           strBody += "\r\n" + stringPrintFormater.GridCell("Date", 23, false);
           strBody += stringPrintFormater.GridCell("Item Name", 35, false);
           strBody += stringPrintFormater.GridCell("Supplier Name", 35, false);
           strBody += stringPrintFormater.GridCell("Quantity", 17, false);
           strBody += stringPrintFormater.GridCell("Unit", 10, false);
           strBody += stringPrintFormater.GridCell("Total Amount", 17, false);
           strBody += stringPrintFormater.GridCell("Paid Amount", 17, false);
           strBody += stringPrintFormater.GridCell("Payment Type", 21, false);
         

           strBody += "\r\n" + stringPrintFormater.CreateDashedLine();

           foreach (InventoryReport report in aReports)
           {
               strBody += "\r\n" + stringPrintFormater.GridCell(report.Date.ToString(), 23, false);
               strBody += stringPrintFormater.GridCell(report.ItemName, 35, false);
               strBody += stringPrintFormater.GridCell(report.SupplierName, 35, false);
               strBody += stringPrintFormater.GridCell(report.Quantity.ToString("F02"), 17, false);
               strBody += stringPrintFormater.GridCell(report.Unit, 10, false);
               strBody += stringPrintFormater.GridCell(report.TotalAmount.ToString("F02"), 17, false);
               strBody += stringPrintFormater.GridCell(report.PaidAmount.ToString("F02"), 17, false);
               strBody += stringPrintFormater.GridCell(report.PaymentType, 21, false);
              // strBody += stringPrintFormater.GridCell(report.DamageReport, 17, false);
               // strBody += stringPrintFormater.GridCell(report.AdvanceAmount.ToString(), 19, false);
               strBody += "\r\n" + stringPrintFormater.CreateDashedLine();

           }


           strBody += aMethod.AddEndPart();


           return strBody;
       }


       public List<InventoryPurchase> GetInventoryPurchaseById(int itemId)
       {
           List<InventoryPurchase> aInventoryPurchases = new List<InventoryPurchase>();
           InventoryPurchaseDAO aDao = new InventoryPurchaseDAO();
           aInventoryPurchases = aDao.GetInventoryPurchaseById(itemId);
           return aInventoryPurchases;
       }
    }
}
