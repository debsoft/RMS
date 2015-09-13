using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.Common.ObjectModel
{
   public  class PaymentDueBill
    {
        public int BillId { set; get; }
        public double CashAmount { set; get; }
        public DateTime PaymentDate { set; get; }
        public double CardAmount { set; get; }
        public double Cheque { set; get; }

    }
}
