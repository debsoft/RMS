using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.ObjectModel
{
   public  class ProfitLoss
    {
       public DateTime Date { set; get; }
       public double SalaryCost { set; get; }
       public double RMCost { set; get; }
       public double AccsCost { set; get; }
       public double SaleAmount { set; get; }
       public double Profit { set; get; }
       public double Loss { set; get; }
    }
}
