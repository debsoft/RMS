using System;
using System.Collections.Generic;

using System.Text;

namespace RMS.Common.ObjectModel
{
   public  class CashReportDami
    {
       public string TransactionDate { set; get; }
       public double CreditAmount { set; get; }
       public double DebitAmount { set; get; }
       public double OtherDebitAmount { set; get; }
       public double Balance { set; get; }
       public double CashAmount { set; get; }
       public double CashBalance { set; get; }
       public double CashIn { set; get; }
       public double CashOut { set; get; }
       public double CashExtra { set; get; }



    }
}
