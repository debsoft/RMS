using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.Common.ObjectModel
{
    public class COrderShow
    {
        private Int64 m_iOrderID;
        private String m_sOrderType;
        private String m_sStatus;
        private int m_iGuestCount;
        private Int64 m_iTableNumber;
        private String m_sTableName;
        private String m_sUserName;
        private String m_sCustomerName;
        private Int64 m_onlineOrderID;

        public COrderShow()
        {
            m_iOrderID=0;
            m_sOrderType=String.Empty;
            m_sStatus=String.Empty;
            m_iGuestCount=0;
            m_iTableNumber=0;
            m_sTableName=String.Empty;
            m_sUserName = String.Empty;
            m_sCustomerName = String.Empty;
            m_onlineOrderID = 0;
        }

        public Int64 OnlineOrderID
        {
            get { return m_onlineOrderID; }
            set { m_onlineOrderID = value; }
        }

        public Int64 OrderID
        {
            get { return m_iOrderID; }
            set { m_iOrderID = value; }
        }

        public String OrderType
        {
            get { return m_sOrderType; }
            set { m_sOrderType = value; }
        }
        public String Status
        {
            get { return m_sStatus; }
            set { m_sStatus = value; }
        }

        public int  GuestCount
        {
            get { return m_iGuestCount; }
            set { m_iGuestCount = value; }
        }

        public Int64 TableNumber
        {
            get { return m_iTableNumber; }
            set { m_iTableNumber = value; }
        }

        public String TableName
        {
            get { return m_sTableName; }
            set { m_sTableName = value; }
        }

        public String UserName
        {
            get { return m_sUserName; }
            set { m_sUserName = value; }
        }

        public String CustomerName
        {
            get { return m_sCustomerName; }
            set { m_sCustomerName = value; }
        }

        public string FloorNo { set; get; }
    }
}
