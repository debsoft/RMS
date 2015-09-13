using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.Common
{
    public class CSerialPrintContent
    {
        private String m_sStringLine;
        private bool m_bBold;
        private bool m_bIsNewLine;
        public CSerialPrintContent()
        {
            m_sStringLine = String.Empty;
            m_bBold = false;
        }

        public String StringLine
        {
            get { return m_sStringLine; }
            set { m_sStringLine = value; }
        }

        public bool Bold
        {
            get { return m_bBold; }
            set { m_bBold = value; }
        }

        public bool ISAlredyNewLine
        {
            get { return m_bIsNewLine; }
            set { m_bIsNewLine = value; }
        }


    }
}
