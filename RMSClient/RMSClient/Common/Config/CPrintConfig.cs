using System;
using System.Collections.Generic;
using System.Text;

namespace RMS
{
    namespace Common
    {
        namespace Config
        {
            public class CPrintConfig
            {

                private bool m_bPrintPaymentBill = true;
                

                public CPrintConfig()
                {

                }


                public bool PrintPaymentBill
                {
                    get { return m_bPrintPaymentBill; }
                    set { m_bPrintPaymentBill = value; }
                }


            }//CPrintConfig
        }//ns
    }//ns
}//ns
