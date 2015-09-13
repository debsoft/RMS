using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.Common.ObjectModel
{
    public class COrderDiscount
    {
        private Int64 m_iOrderID;
        private Double m_fDiscount;

        private float m_discountPercentRate;
        private long m_membershipID;
        private long m_membershipCardID;
        private long m_clientID;
        private float m_membershipPoint;
        private float m_membershipTotalPoint;
        private float m_membershipDiscountRate;
        private double m_membershipDiscountAmount;


        public COrderDiscount()
        {
            m_iOrderID = 0;
            m_fDiscount = 0;
        }

        public Int64 OrderID
        {
            get { return m_iOrderID; }
            set { m_iOrderID = value; }
        }

        public Double Discount
        {
            get { return m_fDiscount; }
            set { m_fDiscount = value; }
        }



        public float discountPercentRate
        {
            get { return m_discountPercentRate; }
            set { m_discountPercentRate = value; }
        }

        public long membershipID
        {
            get { return m_membershipID; }
            set { m_membershipID = value; }
        }

        public long membershipCardID
        {
            get { return m_membershipCardID; }
            set { m_membershipCardID = value; }
        }


        public long clientID
        {
            get { return m_clientID; }
            set { m_clientID = value; }
        }

        public float membershipPoint
        {
            get { return m_membershipPoint; }
            set { m_membershipPoint = value; }
        }

        public float membershipTotalPoint
        {
            get { return m_membershipTotalPoint; }
            set { m_membershipTotalPoint = value; }
        }

        public float membershipDiscountRate
        {
            get { return m_membershipDiscountRate; }
            set { m_membershipDiscountRate = value; }
        }
        public double membershipDiscountAmount
        {
            get { return m_membershipDiscountAmount; }
            set { m_membershipDiscountAmount = value; }
        }


        public double TotalItemDiscount { set; get; }
    }
}
