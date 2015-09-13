using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.ObjectModel
{
   public class Supplier
    {
        public int SupplierId { set; get; }
        public string Name { set; get; }
        public string ContactInformation { set; get; }
        public double TotalAmount { set; get; }
        public double PaidAmount { set; get; }
        public double DueAmount { set; get; }
        public double AdvanceAmount { set; get; }
        public string PaymentType { set; get; }

    }
}
