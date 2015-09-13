using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.Common.ObjectModel
{
   public  class ItemVoid
    {
        public int ItemVoidId { set; get; }
        public int OrderId { set; get; }
        public int Creator_Id { set; get; }
        public string CreatorName { set; get; }
        public int RemoverId { set; get; }
        public string RemoverName { set; get; }
        public string ItemName { set; get; }
        public double Quantity { set; get; }
        public double Amount { set; get; }
        public DateTime VoidDate { set; get; }
        public int TableNumber { set; get; }
        public string Reason { set; get; }

    }
}
