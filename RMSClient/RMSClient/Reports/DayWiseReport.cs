using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RMS.Common.ObjectModel;

namespace RMS.Reports
{
    public class  DayWiseReport
    {
        private List<CSearchOrderInfo> orderListPerday;

        public DayWiseReport()
        {
             orderListPerday = new List<CSearchOrderInfo>();
        }

        public void AddItem(CSearchOrderInfo item)
        {
            orderListPerday.Add(item);
        }

        public List<CSearchOrderInfo> OrderListPerday
        {
            get { return orderListPerday; }
            set { orderListPerday = value; }
        }
     
    }
}
