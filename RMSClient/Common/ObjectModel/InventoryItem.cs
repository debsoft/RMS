using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.Common.ObjectModel
{
   public  class InventoryItem
    {
        public int ItemId { set; get; }
        public string ItemName { set; get; }
        public string UnitName { set; get; }
        public int CategoryId { set; get; }
    }
}
