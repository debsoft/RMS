using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.ObjectModel
{
   public  class Transaction1
    {
       public int TransactionId { set; get; }
       public string TransactionType { set; get; }
       public string ItemName { set; get; }
       public string ItemUnit { set; get; }
       public double Quantity { set; get; }
       public double Amount { set; get; }
       public string SupplierName { set; get; }
       public string CauseOrPurpose { set; get; }
       public DateTime Date { set; get; }
    }
}
