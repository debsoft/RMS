using System;
using System.Collections.Generic;
using System.Text;

using System.Xml.Serialization;
using RMS.Common.Config;

namespace RMS
{
    namespace Common
    {

        public class CErrorStrings
        {


            private string m_sItemNotFound;
            private string m_sUserExist;
            private string m_sExceptionOccure;

            private string m_sNone;

            public CErrorStrings()
            {

                m_sItemNotFound = String.Empty;

                m_sUserExist = String.Empty;

                m_sExceptionOccure = String.Empty;

                m_sNone = String.Empty;





            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="eErrorName"></param>
            /// <returns></returns>
            public string GetErrorString(EERRORNAME eErrorName)
            {
                string sRetval;

                switch (eErrorName)
                {

                    case EERRORNAME.USER_EXIST:
                        sRetval = m_sUserExist;
                        break;

                    case EERRORNAME.EXCEPTION_OCCURE:
                        sRetval = m_sExceptionOccure;
                        break;

                    case EERRORNAME.NONE:
                        sRetval = m_sNone;// "Error. Please try again!";
                        break;

                    default:
                        sRetval = "Error. Please try again!";
                        break;
                }

                return sRetval;
            }

            public String ITEM_NOT_FOUND
            {
                set { m_sItemNotFound = value; }
                get { return m_sItemNotFound; }
            }

            public String USER_EXIST
            {
                set { m_sUserExist = value; }
                get { return m_sUserExist; }
            }

            public String EXCEPTION_OCCURE
            {
                set { m_sExceptionOccure = value; }
                get { return m_sExceptionOccure; }
            }

            public String NONE
            {
                set { m_sNone = value; }
                get { return m_sNone; }
            }



        }//ErrorName
    }//ns

}//ns
