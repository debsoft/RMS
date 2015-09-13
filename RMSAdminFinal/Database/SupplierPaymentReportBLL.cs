using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BistroAdmin.DAO;
using Common.ObjectModel;

namespace BistroAdmin.BLL
{
   public  class SupplierPaymentReportBLL
    {
       public List<SupplierPaymentReport> GetSupplierPaymentReportBetweenDate(DateTime fromdate, DateTime todate)
       {
           List<SupplierPaymentReport> aSupplierPaymentReports = new List<SupplierPaymentReport>();
           SupplierPaymentReportDAO aDao=new SupplierPaymentReportDAO();
           aSupplierPaymentReports = aDao.GetSupplierPaymentReportBetweenDate(fromdate, todate);
           return aSupplierPaymentReports;
       }

      
       
       public string SupplierPaymentReportPrint(List<SupplierPaymentReport> aPaymentReports)
       {
            string strBody = "";
            StringPrintFormater stringPrintFormater = new StringPrintFormater(172);
           VariousMethod aMethod=new VariousMethod();
            string header = aMethod.GetPrintDecorationText(VariousMethod.PrintDecoration.HEADER);
            strBody += header;
            //   strBody += "\r\n";
          
            strBody += "\r\n" + stringPrintFormater.CenterTextWithWhiteSpace("Supplier Payment Report");
           // strBody += "\r\n";
            strBody += "\r\n";
            strBody += "\r\n" + stringPrintFormater.CreateDashedLine();

            strBody += "\r\n" + stringPrintFormater.GridCell("Date Time", 30, false);
              strBody += stringPrintFormater.GridCell("Supplier Name", 50, false);
            strBody += stringPrintFormater.GridCell("Total Amount", 18, false);
            strBody += stringPrintFormater.GridCell("Paid Amount", 18, false);
            strBody += stringPrintFormater.GridCell("Payment Type.", 18, false);
            strBody += stringPrintFormater.GridCell("User Name", 30, false);
       
            strBody += "\r\n" + stringPrintFormater.CreateDashedLine();

            foreach (SupplierPaymentReport report in aPaymentReports)
            {
                strBody += "\r\n" + stringPrintFormater.GridCell(report.PaymentDate.ToString(), 30, false);
                strBody += stringPrintFormater.GridCell(report.SupplierName, 50, false);
                strBody += stringPrintFormater.GridCell(report.TotalAmount.ToString(), 18, false);
                strBody += stringPrintFormater.GridCell(report.PaidAmount.ToString(), 18, false);
                strBody += stringPrintFormater.GridCell(report.PaymentType, 18, false);
                strBody += stringPrintFormater.GridCell(report.UserName, 30, false);               
                strBody += "\r\n" + stringPrintFormater.CreateDashedLine();

            }


           strBody += aMethod.AddEndPart();

           
            return strBody;
        }
       
    }
}
