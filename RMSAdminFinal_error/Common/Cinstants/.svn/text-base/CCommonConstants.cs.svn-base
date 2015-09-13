using System;
using System.Collections.Generic;
using System.Text;

using System.Xml.Serialization;
using RMS.Common.ObjectModel;
using System.Threading;

namespace RMS
{
    namespace Common
    {
        public class CCommonConstants
        {


            private string m_sSqlQueryDateFormat = "DMY"; //DMY, MDY etc

            private int m_iPrintStyleID = 1;

            private int m_iMaxOrderChange = 500000000;

            private CUserInfo m_oUserInfo;

            private String m_sRemoteURL = "";

            private string m_sConnetionString = "";

            private Mutex m_mPrintMutex = new Mutex(false);

            private int m_iThreadWaitTime = 5000;

            public int MaxOrderChange
            {
                set { m_iMaxOrderChange = value; }
                get { return m_iMaxOrderChange; }
            }

            public string DBConnection
            {
                get { return m_sConnetionString; }
                set { m_sConnetionString = value; }
            }

            public int ThreadWaitTime
            {
                set { m_iThreadWaitTime = value; }
                get { return m_iThreadWaitTime; }
            }

            public Mutex PrintMutex
            {
                set { m_mPrintMutex = value; }
                get { return m_mPrintMutex; }
            }

            public String RemoteURL
            {
                get { return m_sRemoteURL; }
                set { m_sRemoteURL = value; }
            }

            public CUserInfo UserInfo
            {
                get { return m_oUserInfo; }
                set { m_oUserInfo = value; }
            }


            public int PrintStyleID
            {
                get { return m_iPrintStyleID; }
                set { m_iPrintStyleID = value; }
            }

            public CCommonConstants() { }



            //public String ERROR_ACTION
            //{
            //    set { m_sErrorAction = value; }
            //    get { return m_sErrorAction; }
            //}                   

            public String SqlQueryDateFormat
            {
                set { m_sSqlQueryDateFormat = value; }
                get { return m_sSqlQueryDateFormat; }
            }

        }//CCommonConstants




        public enum EERRORNAME
        {
            NONE = 0,
            ITEM_NOT_FOUND = 1,
            EXCEPTION_OCCURE = 2,
            USER_EXIST = 3

        }

    }//ns
}//ns
