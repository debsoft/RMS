using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.Common.ObjectModel
{
    public class CCategory4
    {
        private int m_iCategory4ID;
        private String m_sCategory4Name;
        private int m_iCategory3ID;
        private String m_sCategory4Description;
        private double m_dTablePrice;
        private double m_dTakeAwayPrice;
        private double m_dBarPrice;
        private int m_iOrderStatus;
        private int m_iCategory4Order;
        private int m_iCategory3Order;
        private int m_iCategory2Order;
        private int m_iViewTable;
        private int m_iViewBar;
        private int m_iViewTakeAway;
        private Int64 m_iRank;
        private int m_synchronization_status;
        private bool m_online_status;

        public CCategory4()
        {
            m_iCategory4ID = 0;
            m_sCategory4Name = String.Empty;
            m_iCategory3ID = 0;
            m_sCategory4Description = String.Empty;
            m_dTablePrice = 0;
            m_dTakeAwayPrice = 0;
            m_dBarPrice = 0;
            m_iOrderStatus = 0;
            m_iCategory4Order = 0;
            m_iViewTable = 0;
            m_iViewBar = 0;
            m_iViewTakeAway = 0;
            m_iRank = 0;
            m_synchronization_status = 0;
            m_online_status = false;
        }

        public int ItemSynchronizationStatus
        {
            get { return m_synchronization_status; }
            set { m_synchronization_status = value; }
        }


        public bool ItemOnlineStatus
        {
            get { return m_online_status; }
            set { m_online_status = value; }
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

        public String Category4Name
        {
            get { return m_sCategory4Name; }
            set { m_sCategory4Name = value; }
        }

        public int Category3ID
        {
            get { return m_iCategory3ID; }
            set { m_iCategory3ID = value; }
        }

        public String Category4Description
        {
            get { return m_sCategory4Description; }
            set { m_sCategory4Description = value; }
        }

        public double Category4TablePrice
        {
            get { return m_dTablePrice; }
            set { m_dTablePrice = value; }
        }

        public double Category4TakeAwayPrice
        {
            get { return m_dTakeAwayPrice; }
            set { m_dTakeAwayPrice = value; }
        }

        public double Category4BarPrice
        {
            get { return m_dBarPrice; }
            set { m_dBarPrice = value; }
        }

        public int Category4OrderStatus
        {
            get { return m_iOrderStatus; }
            set { m_iOrderStatus = value; }
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

        public int Category4ViewTable
        {
            get { return m_iViewTable; }
            set { m_iViewTable = value; }
        }

        public int Category4ViewBar
        {
            get { return m_iViewBar; }
            set { m_iViewBar = value; }
        }

        public int Category4ViewTakeAway
        {
            get { return m_iViewTakeAway; }
            set { m_iViewTakeAway = value; }
        }
    }
}
