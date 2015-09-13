using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.ObjectModel
{
   public  class InventoryReport
   {
       public DateTime Date { set; get; }
       public string CategoryName{ set; get; }
       public string ItemName{ set; get; }
       public string SupplierName{ set; get; }
       public double Quantity{ set; get; }
       public string Unit { set; get; }
       public double TotalAmount{ set; get; }
       public double PaidAmount { set; get; }
       public double DueAmount { set; get; }
       public double AdvanceAmount { set; get; }
       public string PaymentType { set; get; }
       public string UserName { set; get; }


   }
}
