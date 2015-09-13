using System;
using System.Collections.Generic;
using System.Text;
using RMS.Common.ObjectModel;
using RMS.DataAccess;
using RMS.Common;
using RMS;

namespace Managers.Category
{
    public class CCategory2Manager
    {
        private CResult m_oResult;

        public CCategory2Manager()
        {
            m_oResult = new CResult(); 
        }

        public CResult GetAllCategory2()
        {
            try
            {
                List<CCategory2> tempCategory2List = Database.Instance.Category2.GetAllCategory2();
                m_oResult.Data = tempCategory2List;
                m_oResult.IsSuccess = true;
                m_oResult.Message = "Data Read Successful";
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occured at GetAllCategory2() : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                m_oResult.SetParams(ex.Message);
                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in GetAllCategory2()", LogLevel.Error, "CCategory2Manager");
            }
            return m_oResult;
        }
    }
}
