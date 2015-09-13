using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.ObjectModel
{
   public  class TransationReport
    {
       public DateTime Date { set; get; }
       public string CategoryName { set; get; }
       public string ItemName { set; get; }
       public double Quantity { set; get; }
       public string Unit { set; get; }
       public double UnitPrice { set; get; }
       public double TotalPrice { set; get; }
       public string TransactionType { set; get; }
       public string DamageReport { set; get; }
       public string UserName { set; get; }
    }
}
