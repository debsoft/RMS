using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.Common.ObjectModel
{
    public class OrderVoid
    {
        public int OrderVoidId { set; get; }
        public int OrderId { set; get; }
        public int Creator_Id { set; get; }
        public string CreatorName { set; get; }
        public int RemoverId { set; get; }
        public string RemoverName { set; get; }
        public double OrderAmount { set; get; }
        public DateTime OrderDate { set; get; }
        public DateTime VoidDate { set; get; }
        public int TableNumber { set; get; }
        public string Reason { set; get; }

    }
}
