/*
 * File name: CButtonAccess.cs 
 * Author: Md. Zahidur Rahman
 *   
 * Description: 
 * 
 * Modification history:
 * Name					Date					Desc
 *                     1/4/2008
 *  
 * Version: 1.0
 * Copyright (c) 2007: Ibacs Ltd..
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.Common.ObjectModel
{
    public class CPaymentSummaryByOrder
    {
        private Int64 m_sOrderID;
        private string m_sOrderType;
        private int m_iTableNumber;  
        private float m_fTotalPayment;
        private float m_fTotalCashPayment;
        private float m_fTotalAccPayment;
        private float m_fTotalEFTPayment;
        private float m_fTotalChequePayment;
        private float m_fTotalVoucherPayment;
        private float m_fTotalServicePayment;
        private float m_fTotalDepositePayment;
        private float m_fDiscount;
        private float m_fTotalOtherPayment;

        private double m_service_cash = 0.0;
        private double m_service_eft = 0.0;
        private double m_service_cheque = 0.0;
        private double m_service_voucher = 0.0;
        private double m_service_acc = 0.0;

        public CPaymentSummaryByOrder()
        {
            m_sOrderID = 0;
            m_sOrderType = String.Empty;
            m_iTableNumber = 0;
            m_fTotalPayment = 0;
            m_fTotalCashPayment = 0;
            m_fTotalEFTPayment = 0;
            m_fTotalChequePayment = 0;
            m_fTotalVoucherPayment = 0;
            m_fTotalServicePayment = 0;
            m_fTotalDepositePayment = 0;
            m_fDiscount = 0;
            m_fTotalOtherPayment = 0;
            m_fTotalAccPayment = 0;

            m_service_cash = 0.0;
            m_service_eft = 0.0;
            m_service_cheque = 0.0;
            m_service_voucher = 0.0;
            m_service_acc = 0.0;
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

        public Int64 OrderID
        {
            get { return m_sOrderID; }
            set { m_sOrderID = value; }
        }

        public String OrderType
        {
            get { return m_sOrderType; }
            set { m_sOrderType = value; }
        }

        public int TableNumber
        {
            get { return m_iTableNumber; }
            set { m_iTableNumber = value; }
        } 
        
        public float TotalPayment
        {
            get { return m_fTotalPayment; }
            set { m_fTotalPayment = value; }
        }
        

        public float TotalAccPayment
        {
            get { return m_fTotalAccPayment; }
            set { m_fTotalAccPayment = value; }
        }


        public float TotalCashPayment
        {
            get { return m_fTotalCashPayment; }
            set { m_fTotalCashPayment = value; }
        }

        public float TotalEFTPayment
        {
            get { return m_fTotalEFTPayment; }
            set { m_fTotalEFTPayment = value; }
        }

        public float TotalChequePayment
        {
            get { return m_fTotalChequePayment; }
            set { m_fTotalChequePayment = value; }
        }

        public float TotalServicePayment
        {
            get { return m_fTotalServicePayment; }
            set { m_fTotalServicePayment = value; }
        }

        public float TotalVoucherPayment
        {
            get { return m_fTotalVoucherPayment; }
            set { m_fTotalVoucherPayment = value; }
        }

        public float TotalDepositePayment
        {
            get { return m_fTotalDepositePayment; }
            set { m_fTotalDepositePayment = value; }
        }

        public float Discount
        {
            get { return m_fDiscount; }
            set { m_fDiscount = value; }
        }

        public float TotalOtherPayment
        {
            get { return m_fTotalOtherPayment; }
            set { m_fTotalOtherPayment = value; }
        }              
    }
}

