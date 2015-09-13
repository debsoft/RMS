using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.Common.ObjectModel
{
    public class CTerminalPrint
    {

        private Int64 m_iPrintID;
        private Int64 m_iOrderID;
        private DateTime m_oPrintTime;
        private int m_iPcID;


        public CTerminalPrint()
        {
            m_iPrintID = 0;
            m_iOrderID = 0;
            m_oPrintTime = DateTime.Now;
            m_iPcID = 0;

        }


        public Int64 PrintID
        {
            get { return m_iPrintID; }
            set { m_iPrintID = value; }
        }


        public Int64 OrderID
        {
            get { return m_iOrderID; }
            set { m_iOrderID = value; }
        }


        public DateTime PrintTime
        {
            get { return m_oPrintTime; }
            set { m_oPrintTime = value; }
        }

        public int PcID
        {
            get { return m_iPcID; }
            set { m_iPcID = value; }
        }





    }
}
