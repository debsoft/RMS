using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.Common.ObjectModel
{
    [Serializable]
    public class CResult
    {
        private string m_sMessage;
        private bool m_bIsSuccess;
        private bool m_bIsExcepction;
        private object m_oData;
        private EERRORNAME m_eAction;
        private object[] m_oArgumentArray;

        public CResult()
        {
            m_sMessage = String.Empty;
            m_bIsSuccess = false;
            m_bIsExcepction = false;
            //m_oData = new object();
            m_eAction = EERRORNAME.NONE;
        }

        public string Message
        {
            get { return m_sMessage; }
            set { m_sMessage = value; }
        }
        public bool IsSuccess
        {
            get { return m_bIsSuccess; }
            set { m_bIsSuccess = value; }
        }
        public bool IsException
        {
            get { return m_bIsExcepction; }
            set { m_bIsExcepction = value; }
        }
        public object Data
        {
            get { return m_oData; }
            set { m_oData = value; }
        }
        public EERRORNAME Action
        {
            get { return m_eAction; }
            set { m_eAction = value; }
        }

        public void SetParams(params object[] args)
        {
            m_oArgumentArray = args;
        }

        public object[] ArgumentArray
        {
            get { return m_oArgumentArray; }
            set { m_oArgumentArray = value; }
        }
    }

}