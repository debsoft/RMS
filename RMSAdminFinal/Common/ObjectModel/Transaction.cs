using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RMS.Common.ObjectModel;

namespace Common.ObjectModel
{
   public  class Transaction
    {
       public int TransactionId { set; get; }
       public InventoryCategory Category { set; get; }
       public InventoryItem Item { set; get; }
       public String TransactionType { set; get; }
       public Unit Unit { set; get; }
       public CUserInfo UserInfo { set; get; }
       public string DamageReport { set; get; }
       public DateTime TransactionDate { set; get; }
       public Stock Stock { set; get; }
       public double TransactionAmount { set; get; }
      // public double UnitPrice { set; get; }

    }
}
