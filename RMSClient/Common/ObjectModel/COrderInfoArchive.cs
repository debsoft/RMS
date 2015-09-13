using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.Common.ObjectModel
{
    public class COrderInfoArchive
    {

        private Int64 m_iOrderID;
        private Int64 m_iCustomerID;
        private int m_iUserID;
        private String m_sOrderType;
        private DateTime m_oOrderTime;
        private String m_sStatus;
        private int m_iGuestCount;
        private int m_iTableNumber;
        private String m_sTableName;
        private Int64 m_iSerialNo;
        private Int32 m_TerminalId;
        private string m_sUserName;


        public COrderInfoArchive()
        {
            m_iOrderID = 0;
            m_iCustomerID = 0;
            m_iUserID = 0;
            m_sOrderType = String.Empty;
            m_oOrderTime = CCommonConstants.DefaultDateTime;
            m_sStatus = String.Empty;
            m_iGuestCount = 0;
            m_iTableNumber = 0;
            m_sTableName = String.Empty;
            m_iSerialNo = 0;
            m_TerminalId = 0;
            m_sUserName = String.Empty;
        }

        public String UserName
        {
            get { return m_sUserName; }
            set { m_sUserName = value; }
        }


        public Int32 TerminalID
        {
            get { return m_TerminalId; }
            set { m_TerminalId = value; }
        }

        public Int64 OrderID
        {
            get { return m_iOrderID; }
            set { m_iOrderID = value; }
        }

        public Int64 CustomerID
        {
            get { return m_iCustomerID; }
            set { m_iCustomerID = value; }
        }


        public int UserID
        {
            get { return m_iUserID; }
            set { m_iUserID = value; }
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

        public int GuestCount
        {
            get { return m_iGuestCount; }
            set { m_iGuestCount = value; }
        }


        public int TableNumber
        {
            get { return m_iTableNumber; }
            set { m_iTableNumber = value; }
        }


        public String TableName
        {
            get { return m_sTableName; }
            set { m_sTableName = value; }
        }


        public DateTime OrderTime
        {
            get { return m_oOrderTime; }
            set { m_oOrderTime = value; }
        }

        public Int64 SerialNo
        {
            get { return m_iSerialNo; }
            set { m_iSerialNo = value; }
        }
    }
}
