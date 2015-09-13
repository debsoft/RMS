using System;
using System.Collections.Generic;
using System.Text;

namespace RMS
{
    namespace Common
    {
        namespace Config
        {
            public class CMouseConfig
            {


                private bool m_bShowMouse = true;

                public CMouseConfig()
                {
                    
                }


                
                public bool ShowMouse
                {
                    get { return m_bShowMouse; }
                    set { m_bShowMouse = value; }
                }
               
            }//CDalConfig
        }//ns
    }//ns
}//ns
