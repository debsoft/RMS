using System;
using System.Collections.Generic;
using System.Text;
using RMS.Common.ObjectModel;
using RMS.DataAccess;
using RMS.Common;
using RMS;

namespace Managers.Category
{
    public class CCategory1Manager
    {
        private CResult m_oResult;

        public CCategory1Manager()
        {
            m_oResult = new CResult(); 
        }

        public CResult GetAllCategory1()
        {
            try
            {
                List<CCategory1> tempCategory1List = Database.Instance.Category1.GetAllCategory1();
                m_oResult.Data = tempCategory1List;
                m_oResult.IsSuccess = true;
                m_oResult.Message = "Data Read Successful";
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occured at GetAllCategory1() : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                m_oResult.SetParams(ex.Message);
                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in GetAllCategory1()", LogLevel.Error, "CCategory1Manager");
            }
            return m_oResult;
        }
    }
}
