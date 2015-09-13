using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.Common.ObjectModel
{
    public class COrderSeatTime
    {
        private Int64 m_iOrderID;
        private DateTime m_dSeatTime;

        public COrderSeatTime()
        {
            m_dSeatTime = CCommonConstants.DefaultDateTime;
            m_iOrderID = 0;
        }

        public Int64 OrderID
        {
            get { return m_iOrderID; }
            set { m_iOrderID = value; }
        }

        public DateTime SeatTime
        {
            get { return m_dSeatTime; }
            set { m_dSeatTime = value; }
        }

    }
}
