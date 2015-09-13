using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.Common.ObjectModel
{
    public class CCat3Rank
    {
        private int m_iCategory3ID;

        private int m_iCategory3Order;

        private int m_iCategory2Order;

        private Int64 m_iRank;

        private List<CCat4Rank> m_oChildCat4List;

        public CCat3Rank()
        {
            m_iCategory3ID = 0;
            m_iCategory3Order = 0;

            m_oChildCat4List = new List<CCat4Rank>();

            m_iRank = 0;

            m_iCategory2Order = 0;
        }

        public Int64 Rank
        {
            get { return m_iRank; }
            set { m_iRank = value; }
        }

        public int Category3ID
        {
            get { return m_iCategory3ID; }
            set { m_iCategory3ID = value; }
        }



        public int Category2Order
        {
            get { return m_iCategory2Order; }
            set { m_iCategory2Order = value; }
        }


        public int Category3Order
        {
            get { return m_iCategory3Order; }
            set { m_iCategory3Order = value; }
        }

        public List<CCat4Rank> ChildCat4List
        {
            get { return m_oChildCat4List; }
            set { m_oChildCat4List = value; }
        }

    }
}
