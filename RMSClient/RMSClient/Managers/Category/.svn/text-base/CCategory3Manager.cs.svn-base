using System;
using System.Collections.Generic;
using System.Text;
using RMS.Common.ObjectModel;
using RMS.DataAccess;
using RMS.Common;
using RMS;

namespace Managers.Category
{
    public class CCategory3Manager
    {
        private CResult m_oResult;

        public CCategory3Manager()
        {
            m_oResult = new CResult(); 
        }

        public CResult GetAllCategory3()
        {
            try
            {
                List<CCategory3> tempCategory3List = Database.Instance.Category3.GetAllCategory3();
                m_oResult.Data = tempCategory3List;
                m_oResult.IsSuccess = true;
                m_oResult.Message = "Data Read Successful";
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occured at GetAllCategory3() : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                m_oResult.SetParams(ex.Message);
                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in GetAllCategory3()", LogLevel.Error, "CCategory3Manager");
            }
            return m_oResult;
        }
    }
}
