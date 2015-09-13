using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.Common.ObjectModel
{
   public  class KitchenStock
    {
       public int KitchenStockId { set; get; }
       public int ItemId { set; get; }
       public double Stocks { set; get; }
       public string ItemName { set; get; }
       public double UnitPrice { set; get; }
    }
}
