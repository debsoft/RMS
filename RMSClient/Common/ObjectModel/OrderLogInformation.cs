using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.Common.ObjectModel
{
public class OrderLogInformation
    {
        private Int64 m_bOrderID;
        private Int64 m_bFirstOrderTakenTime;
        private Int64 m_bLastOrderTakenTime;
        private Int64 m_bFirstOrderPrintTime;
        private Int64 m_bLastOrderPrintTime;
        private int m_iUserID;
        private string m_sUsername;
        private string m_skitchenText;
        private int m_iguestBillPrintStatus;
        private int m_ikitchentextPrintStatus;

        public OrderLogInformation()
        {
            m_bOrderID = 0;
            m_bFirstOrderTakenTime = 0;
            m_bLastOrderTakenTime = 0;
            m_bFirstOrderPrintTime = 0;
            m_bLastOrderPrintTime = 0;
            m_iUserID = 0;
            m_sUsername = String.Empty;
            m_iguestBillPrintStatus = 0;
            m_skitchenText = String.Empty;
            m_ikitchentextPrintStatus = 0;
        }

        public int KitchenTextPrintStatus
        {
            get { return m_ikitchentextPrintStatus; }
            set { m_ikitchentextPrintStatus = value; }
        }

        public string KitchenText
        {
            get { return m_skitchenText; }
            set { m_skitchenText = value; }
        }

        public string UserName
        {
            get { return m_sUsername; }
            set { m_sUsername = value; }
        }

        public int UserID
        {
            get { return m_iUserID; }
            set { m_iUserID = value; }
        }

        public int BillPrintStatus
        {
            get { return m_iguestBillPrintStatus; }
            set { m_iguestBillPrintStatus = value; }
        }

        public Int64 OrderID
        {
            get { return m_bOrderID; }
            set { m_bOrderID = value; }
        }

        public Int64 FirstOrderTakenTime
        {
            get { return m_bFirstOrderTakenTime; }
            set { m_bFirstOrderTakenTime = value; }
        }

        public Int64 LastOrderTakenTime
        {
            get { return m_bLastOrderTakenTime; }
            set { m_bLastOrderTakenTime = value; }
        }

        public Int64 FirstOrderPrintTime
        {
            get { return m_bFirstOrderPrintTime; }
            set { m_bFirstOrderPrintTime = value; }
        }

        public Int64 LastOrderPrintTime
        {
            get { return m_bLastOrderPrintTime; }
            set { m_bLastOrderPrintTime = value; }
        }
    }
}
