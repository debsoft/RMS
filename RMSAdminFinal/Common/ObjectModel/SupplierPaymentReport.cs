using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.ObjectModel
{
    public class SupplierPaymentReport
    {
        public int SupplierPaymentReportId { set; get; }
        public DateTime PaymentDate { set; get; }
        public string SupplierName { set; get; }
        public double TotalAmount { set; get; }
        public double PaidAmount { set; get; }
        public string PaymentType { set; get; }
        public string UserName { set; get; }
    }
}
