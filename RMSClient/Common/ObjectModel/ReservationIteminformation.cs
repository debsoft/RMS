using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.Common.ObjectModel
{
   public  class ReservationIteminformation
    {
       public int ItemId { set; get; }
       public string ItemName { set; get; }
       public double UnitPrice { set; get; }
       public double TotalPrice { set; get; }
       public string Delete { set; get; }
    }
}
