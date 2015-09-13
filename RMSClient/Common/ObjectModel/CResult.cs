/*
 * 
 * Author: Mutawaqqil Billah
 * Date: 22nd Feb, 2006
 * 
 * Description: 
 * 
 * Modification history:
 * Name					Date					Desc
 * 
 *  
 *
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.Common.ObjectModel
{
    [Serializable]
    public class CResult 
        {
            private string m_sMessage;
            private bool m_bIsSuccess;
            private bool m_bIsExcepction;
            private object m_oData; 
            private EERRORNAME m_eAction;
            private int m_productid;
            private object[] m_oArgumentArray;
            private double vateRate;
            private double amount = 0.0; 

            public CResult()
            {
                m_sMessage = String.Empty;
                m_bIsSuccess = false;
                m_bIsExcepction = false;
                //m_oData = new object();
                m_eAction = EERRORNAME.NONE;
                m_productid = 0;
                vateRate = 0;
                Amount = 0;
            }

            public string Message
            {
                get { return m_sMessage; }
                set { m_sMessage = value; }
            }
            public bool IsSuccess
            {
                get { return m_bIsSuccess; }
                set { m_bIsSuccess = value; }
            }
            public bool IsException
            {
                get { return m_bIsExcepction; }
                set { m_bIsExcepction = value; }
            }
            public object Data
            {
                get { return m_oData; }
                set { m_oData = value; }
            }
            public EERRORNAME Action
            {
                get { return m_eAction; }
                set { m_eAction = value; }
            }

            public void SetParams(params object[] args)
            {
                m_oArgumentArray = args;
            }

            public object[] ArgumentArray
            {
                get { return m_oArgumentArray; }
                set { m_oArgumentArray = value; }
            }
            public int Productid
            {
                get { return m_productid; }
                set { m_productid = value; }
            }
            public double VateRate
            {
                get { return vateRate; }
                set { vateRate = value; }
            }
            public double Amount
            {
                get { return amount; }
                set { amount = value; }
            }
        }
    
}
