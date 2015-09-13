using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.ObjectModel
{
   public class Store
    {
        public int StoreId { set; get; }
        public int CategoryId { set; get; }
        public string CategoryName { set; get; }
        public string ItemName { set; get; }
        public string Unit { set; get; }
        public double Quantity { set; get; }
        public double Amount { set; get; }
        public double UnitPrice { set; get; }       
        public string Purchase { set; get; }
        public string StockOut { set; get; }
        public string Damage { set; get; }  
        public string Delete { set; get; }
        public string Return { set; get; }
       
    }
}
