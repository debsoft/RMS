using System;
using System.Collections.Generic;
using System.Text;

namespace CellBazaar
{
    namespace Common
    {
        namespace Config
        {
            public class CSyntaxConfig
            {
                private String m_sDelimeter;


                public CSyntaxConfig()
                {
                    //m_sConfigName = String.Empty;

                }


                public String Delimiter
                {
                    set { m_sDelimeter = value; }
                    get { return m_sDelimeter; }
                }


            }
        }
    }
}
