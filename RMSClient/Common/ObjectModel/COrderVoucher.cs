using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.Common.ObjectModel
{
    public class COrderVoucher
    {
        private Int64 m_iVoucherID;
        private Int64 m_iOrderID;
        private double m_fVoucherAmount;

        public COrderVoucher()
        {
            m_iOrderID = 0;
            m_iVoucherID = 0;
            m_fVoucherAmount = 0;
        }

        public Int64 VoucherID
        {
            get { return m_iVoucherID; }
            set { m_iVoucherID = value; }
        }

        public Int64 OrderID
        {
            get { return m_iOrderID; }
            set { m_iOrderID = value; }
        }

        public double VoucherAmount
        {
            get { return m_fVoucherAmount; }
            set { m_fVoucherAmount = value; }
        }

    }
}
