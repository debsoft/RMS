using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.ObjectModel;
using RMS.Common.ObjectModel;

namespace Common.ObjectModel
{
   public  class Stock
    {
       public int StockId { set; get; }
       public InventoryCategory Category { set; get; }
       public InventoryItem Item { set; get; }
       public double Stocks { set; get; }
       public Unit Unit { set; get; }
       public double UnitPrice { set; get; }
    }
}
