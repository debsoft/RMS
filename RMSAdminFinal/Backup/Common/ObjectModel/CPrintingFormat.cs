using System;
using System.Collections.Generic;
using System.Text;
//using Microsoft.Reporting.WinForms;

namespace RMS.Common.ObjectModel
{
    [Serializable]
    public class CPrintingFormat
    {
        private String m_sHeader;
        private String m_sBody;
        private String m_sFooter;
        private int m_iPrintType;
        private Int64 m_iOrderID;

        //private LocalReport m_oReport;

        public CPrintingFormat()
        {
            m_sHeader = String.Empty;
            m_sBody = String.Empty;
            m_sFooter = String.Empty;
            m_iPrintType = 0;
            //m_oReport = null;
        }

        public int PrintType
        {
            get { return m_iPrintType; }
            set { m_iPrintType = value; }
        }

        //public LocalReport KitchenReport
        //{
        //    get { return m_oReport; }
        //    set { m_oReport = value; }
        //}

        public String Header
        {
            get { return m_sHeader; }
            set { m_sHeader = value; }
        }

        public String Body
        {
            get { return m_sBody; }
            set { m_sBody = value; }
        }

        public String Footer
        {
            get { return m_sFooter; }
            set { m_sFooter = value; }
        }

        public Int64 OrderID
        {
            get { return m_iOrderID; }
            set { m_iOrderID = value; }
        }
    }
}

