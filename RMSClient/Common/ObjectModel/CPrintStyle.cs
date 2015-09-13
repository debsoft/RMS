using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.Common.ObjectModel
{
    public class CPrintStyle
    {

        private int m_iStyleID;
        private String m_sHeader;
        private String m_sBody;
        private String m_sFooter;


        public CPrintStyle()
        {
            m_iStyleID = 0;
            m_sHeader = String.Empty;
            m_sBody = String.Empty;
            m_sFooter = String.Empty;

        }


        public int StyleID
        {
            get { return m_iStyleID; }
            set { m_iStyleID = value; }
        }


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



    }
}
