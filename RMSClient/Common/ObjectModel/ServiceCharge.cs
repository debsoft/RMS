using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.Common.ObjectModel
{
    public class ServiceCharge
    {
        private Int64 m_iOrderID;
        private Double m_chargeAmount;
        private Double m_svc_chargeRate; 
        
        public ServiceCharge()
        {
            m_iOrderID = 0;
            m_chargeAmount = 0;
        }

        public Int64 OrderID
        {
            get { return m_iOrderID; }
            set { m_iOrderID = value; }
        }

        public Double ServiceChargeAmount
        {
            get { return m_chargeAmount; }
            set { m_chargeAmount = value; }
        }

        public double ServicechargeRate
        {
            get { return m_svc_chargeRate; }
            set {  m_svc_chargeRate = value; }
        }

    }
}

