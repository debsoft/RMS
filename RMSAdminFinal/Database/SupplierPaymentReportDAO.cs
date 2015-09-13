using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Common.ObjectModel;
using RMS.DataAccess;

namespace BistroAdmin.DAO
{
    public class SupplierPaymentReportDAO:BaseDAO
    {
        public List<SupplierPaymentReport> GetSupplierPaymentReportBetweenDate(DateTime fromdate, DateTime todate)
        {
            List<SupplierPaymentReport> aPaymentReports=new List<SupplierPaymentReport>();
            try
            {
                this.OpenConnection();
                string sqlComm = String.Format(SqlQueries.GetQuery(Query.GetSupplierPaymentReportBetweenDate),fromdate,todate);
                IDataReader aReader = this.ExecuteReader(sqlComm);
                if(aReader!=null)
                {
                    while(aReader.Read())
                    {
                        SupplierPaymentReport aReport=new SupplierPaymentReport();
                        aReport = ReaderToReadSupplierPaymentReport(aReader);
                        aPaymentReports.Add(aReport);
                    }
                }

            }
            catch (Exception ex)
            {

                throw new Exception("GetSupplierPaymentReportBetweenDate()",ex);
            }
            finally
            {
                CloseConnection();
            }

            return aPaymentReports;

        }
        //"select a.supplier_payment_id, a.total_amount, a.paid_amount, a.paid_type, 
        //a.date, a.user_name ,b.supplier_name from supplier_payment_report a, 
        //supplier b where a.supplier_id=b.supplier_id and a.date>='{0}' and a.date<='{1}'";
        private SupplierPaymentReport ReaderToReadSupplierPaymentReport(IDataReader aReader)
        {
            SupplierPaymentReport aReport = new SupplierPaymentReport();
            try
            {
                aReport.SupplierPaymentReportId = Convert.ToInt32(aReader["supplier_payment_id"]);
            }
            catch 
            {
            }
            try
            {
                aReport.TotalAmount = Convert.ToDouble(aReader["total_amount"]);
            }
            catch
            {
            }
            try
            {
                aReport.PaidAmount = Convert.ToDouble(aReader["paid_amount"]);
            }
            catch
            {
            }
            try
            {
                aReport.PaymentType = (aReader["paid_type"]).ToString();
            }
            catch
            {
            }
            try
            {
                aReport.UserName= (aReader["user_name"]).ToString();
            }
            catch
            {
            }
            try
            {
                aReport.SupplierName = (aReader["supplier_name"]).ToString();
            }
            catch
            {
            }
            try
            {
                aReport.PaymentDate=Convert.ToDateTime(aReader["date"]);
            }
            catch
            {
            }




            return aReport;
        }
    }
}
