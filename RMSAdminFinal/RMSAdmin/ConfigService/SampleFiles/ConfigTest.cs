using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigServiceSamples
{
    public class ConfigTest
    {
        private string m_sConfigProp1;
        private string m_sConfigProp2;

        public string ConfigProp1
        {
            get { return m_sConfigProp1; }
            set { m_sConfigProp1 = value; }
        }

        public string ConfigProp2
        {
            get { return m_sConfigProp2; }
            set { m_sConfigProp2 = value; }
        }
    }
}
