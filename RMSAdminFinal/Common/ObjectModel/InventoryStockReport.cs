using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.ObjectModel
{
   public  class InventoryStockReport
    {
       public int InventoryStockReportId { set; get; }
       public int CategoryId { set; get; }
       public string CategoryName { set; get; }
       public int ItemId { set; get; }
       public string ItemName { set; get; }
       public double ReceivedQty { set; get; }
       public double SendQty { set; get; }
       public double DamageQty { set; get; }
       public double BalanceQty { set; get; }
       public string Unit { set; get; }
       public double UnitPrice { set; get; }
       public double BalancePrice { set; get; }
       public DateTime Date { set; get; }
       public double SaleQty { set; get; }
       public double Price { set; get; }

    }
}
