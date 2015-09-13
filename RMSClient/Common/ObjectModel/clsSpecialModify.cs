using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.Common.ObjectModel
{
    public class clsSpecialModfifyText
    {
        private string m_SpecialModfifyText;
        private Int32 m_SpecialModfifyTextId;

        public clsSpecialModfifyText()
        {
            m_SpecialModfifyText = String.Empty;
            m_SpecialModfifyTextId = 0;
        }

        public string SpecialModfifyText
        {
            get { return m_SpecialModfifyText; }
            set { m_SpecialModfifyText = value; }
        }

        public Int32 SpecialModfifyTextId
        {
            get { return m_SpecialModfifyTextId; }
            set { m_SpecialModfifyTextId = value; }
        }
    }
}
