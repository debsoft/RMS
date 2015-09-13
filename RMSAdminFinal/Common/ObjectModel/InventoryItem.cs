using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.ObjectModel
{
   public class InventoryItem
    {
       public int ItemId { set; get; }
       public string ItemName { set; get; }
       public string UnitName { set; get; }
       public int CategoryId { set; get; }
       public string CategoryName { set; get; }
    }
}
