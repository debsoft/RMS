using System;
using System.Collections.Generic;
using System.Text;
using RMS.Common.ObjectModel;
using RMS.DataAccess;
using RMS.Common;
using RMS;

namespace Managers.TableInfo
{
    public class CPcInfoManager
    {
        private CResult m_oResult;

        public CPcInfoManager()
        {
            m_oResult = new CResult();
        }

        public CResult PcInfoByPcIP(string inPcIP)
        {
            try
            {
                CPcInfo tempPcInfo = Database.Instance.PcInfo.PcInfoByPcIP(inPcIP);
                m_oResult.Data = tempPcInfo;
                m_oResult.IsSuccess = true;
                m_oResult.Message = "Data Read Successful";
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occuer at PcInfoByPcIP() : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                m_oResult.SetParams(ex.Message);
                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in PcInfoByPcIP()", LogLevel.Error, "CPcInfoManager");
            }
            return m_oResult;

        }
    }
}
