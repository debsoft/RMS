using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.Common.ObjectModel
{
    [Serializable]
    public class CUserAccess
    {

        private int m_iUserID;
        private int m_iOpenDrawer;
        private int m_iVoidTable;
        private int m_iTransferTable;
        private int m_iMergeTable;
        private int m_iReviewTransaction;
        private int m_iViewReport;
        private int m_iTillReporting;
        private int m_iExitRms;
        private int m_iBooking;
        private int m_iUsers;
        private int m_iCustomers;
        private int m_iUpdateItems;
        private int m_iDeposit;
        private int m_iRemoveItems;
        private int m_iRmsAdmin;

        private int m_iUnlockTable;
        private int m_iLogRegister;

        private int m_isystemSettings;


        public CUserAccess()
        {
            m_iUserID = 0;
            m_iOpenDrawer = 0;
            m_iVoidTable = 0;
            m_iTransferTable = 0;
            m_iMergeTable = 0;
            m_iReviewTransaction = 0;
            m_iViewReport = 0;
            m_iTillReporting = 0;
            m_iExitRms = 0;
            m_iUnlockTable = 0;
            m_iBooking = 0;
            m_iUsers = 0;
            m_iCustomers = 0;
            m_iDeposit = 0;

            m_iUpdateItems = 0;

            m_iRemoveItems = 0;

            m_isystemSettings = 0;
            m_iRmsAdmin = 0;
        }

        public int RmsAdminAccess
        {
            get { return m_iRmsAdmin; }
            set { m_iRmsAdmin = value; }
        }

        public int SystemSettings
        {
            get { return m_isystemSettings; }
            set { m_isystemSettings = value; }
        }

        public int Deposit
        {
            get { return m_iDeposit; }
            set { m_iDeposit = value; }
        }

        public int UpdateItems
        {
            get { return m_iUpdateItems; }
            set { m_iUpdateItems = value; }
        }

        public int Customers
        {
            get { return m_iCustomers; }
            set { m_iCustomers = value; }
        }


        public int Users
        {
            get { return m_iUsers; }
            set { m_iUsers = value; }
        }

        public int Booking
        {
            get { return m_iBooking; }
            set { m_iBooking = value; }
        }

        public int UnlockTable
        {
            get { return m_iUnlockTable; }
            set { m_iUnlockTable = value; }
        }

        public int UserID
        {
            get { return m_iUserID; }
            set { m_iUserID = value; }
        }


        public int OpenDrawer
        {
            get { return m_iOpenDrawer; }
            set { m_iOpenDrawer = value; }
        }


        public int VoidTable
        {
            get { return m_iVoidTable; }
            set { m_iVoidTable = value; }
        }

        public int TransferTable
        {
            get { return m_iTransferTable; }
            set { m_iTransferTable = value; }
        }

        public int MergeTable
        {
            get { return m_iMergeTable; }
            set { m_iMergeTable = value; }
        }

        public int ReviewTransaction
        {
            get { return m_iReviewTransaction; }
            set { m_iReviewTransaction = value; }
        }


        public int ViewReport
        {
            get { return m_iViewReport; }
            set { m_iViewReport = value; }
        }

        public int TillReporting
        {
            get { return m_iTillReporting; }
            set { m_iTillReporting = value; }
        }

        public int ExitRms
        {
            get { return m_iExitRms; }
            set { m_iExitRms = value; }
        }

        public int RemoveItems
        {
            get { return m_iRemoveItems; }
            set { m_iRemoveItems = value; }
        }


        public int LogRegister
        {
            get { return m_iLogRegister; }
            set { m_iLogRegister = value; }
        }
    }
}
