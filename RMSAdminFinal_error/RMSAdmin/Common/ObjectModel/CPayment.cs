using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.Common.ObjectModel
{
    public class CPayment
    {

        private Int64 m_iPaymentID;
        private Int64 m_iOrderID;
        private int m_iPcID;
        private double m_dTotalAmount;
        private double m_dCashAmount;
        private double m_dEFTAmount;
        private double m_dChequeAmount;
        private double m_dVoucherAmount;
        private double m_dServiceAmount;
        private double m_dDiscount;
        private double m_dAccountPay;


        public CPayment()
        {
            m_iOrderID = 0;
            m_iPaymentID = 0;
            m_iPcID = 0;
            m_dTotalAmount = 0;
            m_dCashAmount = 0;
            m_dEFTAmount = 0;
            m_dChequeAmount = 0;
            m_dVoucherAmount = 0;
            m_dServiceAmount = 0;
            m_dDiscount = 0;
            m_dAccountPay = 0;


        }


        public Int64 OrderID
        {
            get { return m_iOrderID; }
            set { m_iOrderID = value; }
        }

        public Int64 PaymentID
        {
            get { return m_iPaymentID; }
            set { m_iPaymentID = value; }
        }


        public int PcID
        {
            get { return m_iPcID; }
            set { m_iPcID = value; }
        }


        public double TotalAmount
        {
            get { return m_dTotalAmount; }
            set { m_dTotalAmount = value; }
        }


        public double CashAmount
        {
            get { return m_dCashAmount; }
            set { m_dCashAmount = value; }
        }

        public double EFTAmount
        {
            get { return m_dEFTAmount; }
            set { m_dEFTAmount = value; }
        }


        public double ChequeAmount
        {
            get { return m_dChequeAmount; }
            set { m_dChequeAmount = value; }
        }


        public double VoucherAmount
        {
            get { return m_dVoucherAmount; }
            set { m_dVoucherAmount = value; }
        }



        public double ServiceAmount
        {
            get { return m_dServiceAmount; }
            set { m_dServiceAmount = value; }
        }



        public double Discount
        {
            get { return m_dDiscount; }
            set { m_dDiscount = value; }
        }



        public double AccountPay
        {
            get { return m_dAccountPay; }
            set { m_dAccountPay = value; }
        }
    }
}
