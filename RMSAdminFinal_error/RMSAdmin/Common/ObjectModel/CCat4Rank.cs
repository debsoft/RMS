using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.Common.ObjectModel
{
    public class CCat4Rank
    {
        private int m_iCategory4ID;
        private int m_iCategory4Order;
        private int m_iCategory3Order;

        private int m_iCategory2Order;
        private Int64 m_iRank;

        public CCat4Rank()
        {
            m_iCategory4ID = 0;
            m_iCategory4Order = 0;
            m_iRank = 0;
            m_iCategory3Order = 0;
            m_iCategory2Order = 0;
        }

        public Int64 Rank
        {
            get { return m_iRank; }
            set { m_iRank = value; }
        }

        public int Category4ID
        {
            get { return m_iCategory4ID; }
            set { m_iCategory4ID = value; }
        }

        public int Category4Order
        {
            get { return m_iCategory4Order; }
            set { m_iCategory4Order = value; }
        }

        public int Category3Order
        {
            get { return m_iCategory3Order; }
            set { m_iCategory3Order = value; }
        }

        public int Category2Order
        {
            get { return m_iCategory2Order; }
            set { m_iCategory2Order = value; }
        }




    }
}
