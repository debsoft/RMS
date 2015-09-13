using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BistroAdmin.DAO;
using Common.ObjectModel;
using RMS.Common.ObjectModel;

namespace BistroAdmin.BLL
{
    public class SupplierBLL
    {
        public string InsertSupplier(Supplier aSupplier)
        {
            SupplierDAO aDao=new SupplierDAO();
            string sr = aDao.InsertSupplier(aSupplier);
            return sr;
        }

        public List<Supplier> GetAllSupplier()
        {
         List<Supplier> aList=new List<Supplier>();
            SupplierDAO aDao=new SupplierDAO();
            aList = aDao.GetAllSupplier();
            return aList;

        }

        public string GetDueOrAdvance(List<Supplier> aSuppliers,Int32 supplierId)
        {
            string sr = string.Empty;
              if(aSuppliers.Count!=0)
            {
                foreach (Supplier supplier in aSuppliers)
                {
                    if(supplier.SupplierId==supplierId)
                    {
                        if(supplier.AdvanceAmount==0&&supplier.DueAmount==0)
                        {
                            sr = "There is No Due Amount Also No Advance Amount";
                        }
                        else if(supplier.AdvanceAmount==0)
                        {
                            sr = "Due Amount: " + supplier.DueAmount;
                        }
                        else if(supplier.DueAmount==0)
                        {
                            sr = "Advance Amount: " + supplier.AdvanceAmount;
                        }
                    }
                }
            }
            return sr;

        }

        public void UpdateSupplierForPurchase(Supplier aSupplier)
        {
            SupplierDAO aDao=new SupplierDAO();
            aDao.UpdateSupplierForPurchase(aSupplier);
        }

        public Supplier GetSupplierByid(int toInt32)
        {
            SupplierDAO aDao=new SupplierDAO();
            Supplier aSupplier=new Supplier();
            aSupplier = aDao.GetSupplierByid(toInt32);
            return aSupplier;
        }

        public void InsertIntosupplier_payment_reportForSupplierPaymentTrack(Supplier aSupplier)
        {
            SupplierDAO aDao = new SupplierDAO();
            aDao.InsertIntosupplier_payment_reportForSupplierPaymentTrack(aSupplier);
        }

        public string SupplierPaymentReportPrint(List<Supplier> aSupplierReports)
        {
            string strBody = "";
            StringPrintFormater stringPrintFormater = new StringPrintFormater(172);
            VariousMethod aMethod = new VariousMethod();
            string header = aMethod.GetPrintDecorationText(VariousMethod.PrintDecoration.HEADER);
            strBody += header;
            //   strBody += "\r\n";

            strBody += "\r\n" + stringPrintFormater.CenterTextWithWhiteSpace("Supplier Information");
            // strBody += "\r\n";
            strBody += "\r\n";
            strBody += "\r\n" + stringPrintFormater.CreateDashedLine();

           // strBody += "\r\n" + stringPrintFormater.GridCell("Date Time", 30, false);
            strBody += "\r\n" + stringPrintFormater.GridCell("Supplier Name", 30, false);
            strBody += stringPrintFormater.GridCell("Supplier Information", 65, false);
            strBody += stringPrintFormater.GridCell("Total Amount", 17, false);
            strBody += stringPrintFormater.GridCell("Paid Amount", 17, false);
            strBody += stringPrintFormater.GridCell("Due Amount.", 17, false);
            strBody += stringPrintFormater.GridCell("Advance Amount", 19, false);

            strBody += "\r\n" + stringPrintFormater.CreateDashedLine();

            foreach (Supplier report in aSupplierReports)
            {
                //strBody += "\r\n" + stringPrintFormater.GridCell(report.PaymentDate.ToString(), 30, false);
                strBody += "\r\n" + stringPrintFormater.GridCell(report.Name, 30, false);
                strBody += stringPrintFormater.GridCell(report.ContactInformation, 65, false);
                strBody += stringPrintFormater.GridCell(report.TotalAmount.ToString(), 17, false);
                strBody += stringPrintFormater.GridCell(report.PaidAmount.ToString(), 17, false);
                strBody += stringPrintFormater.GridCell(report.DueAmount.ToString(), 17, false);
                strBody += stringPrintFormater.GridCell(report.AdvanceAmount.ToString(), 19, false);
                strBody += "\r\n" + stringPrintFormater.CreateDashedLine();

            }


            strBody += aMethod.AddEndPart();


            return strBody;
        }

        public bool CheckExit(string name)
        {
            List<Supplier> aList = new List<Supplier>();
            SupplierBLL aBLL = new SupplierBLL();
            aList = aBLL.GetAllSupplier();
            bool flag = false;
            foreach (Supplier supplier in aList)
            {
                if (supplier.Name.ToUpper() == name.ToUpper()) flag = true;
            }
            if (flag) return true;
            return false;
        }
    }
}
