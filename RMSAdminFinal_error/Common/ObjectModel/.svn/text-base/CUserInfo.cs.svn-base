using System;
using System.Collections.Generic;
using System.Text;
using RMS.Common.ObjectModel;

namespace RMS.Common.ObjectModel
{
    [Serializable]
    public class CUserInfo
    {

        private int m_iUserID;
        private String m_sUserName;
        private String m_sPassword;
        private int m_iType;
        private int m_iStatus;
        private String m_sGender;
        private CUserAccess m_oUserAccess;



        public CUserInfo()
        {
            m_iUserID = 0;
            m_sUserName = String.Empty;
            m_sPassword = String.Empty;
            m_iType = 0;
            m_iStatus = 0;
            m_sGender = String.Empty;

            m_oUserAccess = new CUserAccess();

        }


        public CUserAccess UserAccess
        {
            get { return m_oUserAccess; }
            set { m_oUserAccess = value; }
        }

        public int UserID
        {
            get { return m_iUserID; }
            set { m_iUserID = value; }
        }


        public String UserName
        {
            get { return m_sUserName; }
            set { m_sUserName = value; }
        }


        public String Password
        {
            get { return m_sPassword; }
            set { m_sPassword = value; }
        }

        public int Type
        {
            get { return m_iType; }
            set { m_iType = value; }
        }

        public int Status
        {
            get { return m_iStatus; }
            set { m_iStatus = value; }
        }

        public String Gender
        {
            get { return m_sGender; }
            set { m_sGender = value; }
        }






    }
}
