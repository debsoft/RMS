using System;
using System.Collections.Generic;
using System.Text;
using RMS.Common.ObjectModel;
using RMS.DataAccess;
using RMS.Common;
using RMS;

namespace Managers.Button
{
    public class CButtonAccessManager
    {
        private CResult m_oResult;

        public CButtonAccessManager()
        {
            m_oResult = new CResult(); 
        }

        public CResult GetAllButtonAccess()
        {
            try
            {
                List<CButtonAccess> tempButtonAccessList = Database.Instance.ButtonAccess.GetAllButtonAccess();
                m_oResult.Data = tempButtonAccessList;
                m_oResult.IsSuccess = true;
                m_oResult.Message = "Data Read Successful";
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occured at GetAllButtonAccess() : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                m_oResult.SetParams(ex.Message);
                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in GetAllButtonAccess()", LogLevel.Error, "CButtonAccessManager");
            }
            return m_oResult;
        }
    }
}
