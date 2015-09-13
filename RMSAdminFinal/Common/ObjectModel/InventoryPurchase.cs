using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.ObjectModel;
using RMS.Common.ObjectModel;

namespace Common.ObjectModel
{
    public class InventoryPurchase
    {
        public int PurchaseId { set; get; }
        public InventoryCategory Category { set; get; }
        public InventoryItem Item { set; get; }
        public Supplier Supplier { set; get; }
        public double Quantity { set; get; }
        public double Price { set; get; }
        public DateTime Date { set; get; }
        public Unit Unit { set; get; }
        public string PaymentType { set; get; }
        public CUserInfo CUserInfo { set; get; }
        public DateTime? ExpireDate { set; get; }




    }
}
