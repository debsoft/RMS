using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.Common.ObjectModel
{
    public class CCategory3
    {
        private int m_iCategory3ID;
        private String m_sCategory3Name;
        private int m_iCategory2ID;
        private String m_sCategory3Description;
        private double m_dTablePrice;
        private double m_dTakeAwayPrice;
        private double m_dBarPrice;
        private int m_iOrderStatus;
        private int m_iCategory3Order;
        private int m_iViewTable;
        private int m_iViewBar;
        private int m_iViewTakeAway;
        private Int64 m_iRank;
        private int m_synchronization_status;
        private bool m_online_status;
        private int m_initialQuantity;
        private int m_unlimitStatus;
        private int m_itemSoldIn;
        private string m_sellingIn;
        private Boolean m_vatIncluded;
        private double m_vatRate;
        private string m_productType;
        private string m_uom;
        public double TableCost { set; get; }
        public double TakeAwayCost { set; get; }
        public double BarCost { set; get; }
        public string PrintArea { set; get; }

        public CCategory3()
        {
            m_iCategory3ID = 0;
            m_sCategory3Name = String.Empty;
            m_iCategory2ID = 0;
            m_sCategory3Description = String.Empty;
            m_dTablePrice = 0;
            m_dTakeAwayPrice = 0;
            m_dBarPrice = 0;
            m_iOrderStatus = 0;
            m_iCategory3Order = 0;
            m_iViewTable = 0;
            m_iViewBar = 0;
            m_iViewTakeAway = 0;

            m_iRank = 0;
            m_synchronization_status = 0;
            m_online_status = false;
            m_initialQuantity = 0;
            m_unlimitStatus = 0;
            m_itemSoldIn = 0;
            m_sellingIn = String.Empty;
            m_vatIncluded=false;
            m_vatRate = 0;
            m_productType = String.Empty;
            m_uom = String.Empty;
        }

        public string ItemSellingIn
        {
            get { return m_sellingIn; }
            set { m_sellingIn = value; }
        }

        public int ItemSoldIn
        {
            get { return m_itemSoldIn; }
            set { m_itemSoldIn = value; }
        }

        public int UnlimitStatus
        {
            get { return m_unlimitStatus; }
            set { m_unlimitStatus = value; }
        }

        /// <summary>
        /// Indicates how many items are available at the current moment.
        /// </summary>
        public int InitialItemQuantity
        {
            get { return m_initialQuantity; }
            set { m_initialQuantity = value; }
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

        public int Category3ID
        {
            get { return m_iCategory3ID; }
            set { m_iCategory3ID = value; }
        }

        public String Category3Name
        {
            get { return m_sCategory3Name; }
            set { m_sCategory3Name = value; }
        }

        public int Category2ID
        {
            get { return m_iCategory2ID; }
            set { m_iCategory2ID = value; }
        }

        public String Category3Description
        {
            get { return m_sCategory3Description; }
            set { m_sCategory3Description = value; }
        }

        public double Category3TablePrice
        {
            get { return m_dTablePrice; }
            set { m_dTablePrice = value; }
        }

        public double Category3TakeAwayPrice
        {
            get { return m_dTakeAwayPrice; }
            set { m_dTakeAwayPrice = value; }
        }

        public double Category3BarPrice
        {
            get { return m_dBarPrice; }
            set { m_dBarPrice = value; }
        }

        public int Category3OrderStatus
        {
            get { return m_iOrderStatus; }
            set { m_iOrderStatus = value; }
        }

        public int Category3Order
        {
            get { return m_iCategory3Order; }
            set { m_iCategory3Order = value; }
        }

        public int Category3ViewTable
        {
            get { return m_iViewTable; }
            set { m_iViewTable = value; }
        }

        public int Category3ViewBar
        {
            get { return m_iViewBar; }
            set { m_iViewBar = value; }
        }

        public int Category3ViewTakeAway
        {
            get { return m_iViewTakeAway; }
            set { m_iViewTakeAway = value; }
        }

        public double vatRate
        {
            get { return m_vatRate; }
            set { m_vatRate = value; }
        }
        public bool vatIncluded
        {
            get { return m_vatIncluded; }
            set { m_vatIncluded = value; }
        }

        public string ProductType
        {
            get { return m_productType; }
            set { m_productType = value; }
        }

        public string UoM
        {
            get { return m_uom; }
            set { m_uom = value; }
        }

        
    }
}