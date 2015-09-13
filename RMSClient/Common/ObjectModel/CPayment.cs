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
        private Int64 m_iDepositID;
        private double m_dDepositAmount;
        private DateTime m_oBillPrintTime;
        private DateTime m_oPaymentTime;
        private string m_userID;
        private object m_oData;

        private double m_service_cash =0.0;
        private double m_service_eft = 0.0;
        private double m_service_cheque = 0.0;
        private double m_service_voucher = 0.0;
        private double m_service_acc = 0.0;
        private string m_vatImposed = "0%";
        private string m_GusetBill = "Guest Bill";
        private bool m_vat_stat = true;
        public double TotalCost { set; get; }
        public string Waiter { set; get; }
        public double TipsAmount { set; get; }
        private double m_membershipDiscount;





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
            m_iDepositID = 0;
            m_dDepositAmount = 0;
            m_oBillPrintTime = CCommonConstants.DefaultDateTime;
            m_oPaymentTime = CCommonConstants.DefaultDateTime;
            m_userID =String.Empty;
            m_oData = null;
           
            m_service_cash =0.0;
            m_service_eft = 0.0;
            m_service_cheque = 0.0;
            m_service_voucher = 0.0;
            m_service_acc = 0.0;
            m_membershipDiscount = 0;
        }

        public double ServiceChargeCash
        {
            get { return m_service_cash; }
            set { m_service_cash = value; }
        }
        public double ServiceChargeEft
        {
            get { return m_service_eft; }
            set { m_service_eft = value; }
        }
        public double ServiceChargeCheque
        {
            get { return m_service_cheque; }
            set { m_service_cheque = value; }
        }
        public double ServiceChargeVoucher
        {
            get { return m_service_voucher; }
            set { m_service_voucher = value; }
        }
        public double ServiceChargeAcc
        {
            get { return m_service_acc; }
            set { m_service_acc = value; }
        }

        public object Data
        {
            get { return m_oData; }
            set { m_oData = value; }
        }

        public string UserID
        {
            get { return m_userID; }
            set { m_userID = value; }
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

        public Int64 DepositID
        {
            get { return m_iDepositID; }
            set { m_iDepositID = value; }
        }

        public double DepositAmount
        {
            get { return m_dDepositAmount; }
            set { m_dDepositAmount = value; }
        }

        public DateTime BillPrintTime
        {
            get { return m_oBillPrintTime; }
            set { m_oBillPrintTime = value; }
        }

        public DateTime PaymentTime
        {
            get { return m_oPaymentTime; }
            set { m_oPaymentTime = value; }
        }
        public string VatImposed
        {
            get { return m_vatImposed; }
            set { m_vatImposed = value; }
        }
        public string GuestBill
        {
            get { return m_GusetBill; }
            set { m_GusetBill = value; }
        }

        public bool Vat_stat
        {
            get { return m_vat_stat; }
            set { m_vat_stat = value; }
        }
        public double membershipDiscount
        {
            get { return m_membershipDiscount; }
            set { m_membershipDiscount = value; }

        }

        public string DueMessage { set; get; }
        public string ComplementoryMessage { set; get; }
        public string PaymentPerson { set; get; }
        public double ItemDiscount { set; get; }


    }
}
