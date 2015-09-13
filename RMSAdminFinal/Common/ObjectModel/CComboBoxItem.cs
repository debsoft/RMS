using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.Common.ObjectModel
{
    public class CComboBoxItem
    {

        private int m_iValue;
        private String m_sDisplay;


        public CComboBoxItem(int inValue, String inDisplay)
        {
            m_iValue = inValue;
            m_sDisplay = inDisplay;

        }

        public int Value
        {
            get { return m_iValue; }
            set { m_iValue = value; }
        }

        public String Display
        {
            get { return m_sDisplay; }
            set { m_sDisplay = value; }
        }

    }
}
