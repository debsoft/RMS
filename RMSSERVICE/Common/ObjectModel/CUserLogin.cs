using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.Common.ObjectModel
{
    [Serializable]
    public class CUserLogin 
    {

        public CUserInfo m_oUserInfo;
        public String m_sConnectionStr;
        


        public CUserLogin()
        {
            m_oUserInfo = new CUserInfo();
            m_sConnectionStr = String.Empty;
           
        }


        public CUserInfo UserInfo
        {
            get { return m_oUserInfo; }
            set { m_oUserInfo = value; }
        }


        public String ConnectionStr
        {
            get { return m_sConnectionStr; }
            set { m_sConnectionStr = value; }
        }



    }
}
