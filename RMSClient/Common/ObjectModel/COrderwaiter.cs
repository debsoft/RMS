using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.Common.ObjectModel
{
    public class COrderwaiter
    {
        public long ID { get; set; }
        public long WaiterID { get; set; }
        public string WaiterName { get; set; }
        public long OrderID { get; set; }
        
    }
}
