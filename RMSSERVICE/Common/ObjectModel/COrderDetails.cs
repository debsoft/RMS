using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.Common.ObjectModel
{
    public class COrderDetails
    {
        private Int64 m_bOrderDetailsID;
        private Int64 m_bOrderID;
        private Int64 m_bProductID;
        private int m_iQuantity;
        private double m_dAmount;
        private String m_sRemarks;
        private String m_sFoodType;
        private int m_iCatLevel;

        public COrderDetails()
        {
            m_bOrderDetailsID = 0;
            m_bOrderID = 0;
            m_bProductID = 0;
            m_iQuantity = 0;
            m_dAmount = 0;
            m_sRemarks = string.Empty;
            m_sFoodType = string.Empty;
            m_iCatLevel = 0;
        }

        public Int64 OrderDetailsID
        {
            get { return m_bOrderDetailsID; }
            set { m_bOrderDetailsID = value; }
        }

        public Int64 ProductID
        {
            get { return m_bProductID; }
            set { m_bProductID = value; }
        }

        public Int64 OrderID
        {
            get { return m_bOrderID; }
            set { m_bOrderID = value; }
        }

        public int OrderQuantity
        {
            get { return m_iQuantity; }
            set { m_iQuantity = value; }
        }

        public double OrderAmount
        {
            get { return m_dAmount; }
            set { m_dAmount = value; }
        }

        public String OrderRemarks
        {
            get { return m_sRemarks; }
            set { m_sRemarks = value; }
        }

        public String OrderFoodType
        {
            get { return m_sFoodType; }
            set { m_sFoodType = value; }
        }

        public int CategoryLevel
        {
            get { return m_iCatLevel; }
            set { m_iCatLevel = value; }
        }
    }
}
