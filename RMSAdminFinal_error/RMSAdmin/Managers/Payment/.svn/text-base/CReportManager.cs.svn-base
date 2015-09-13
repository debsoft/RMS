using System;
using System.Collections.Generic;
using System.Text;
using RMS.DataAccess;
using RMS.Common.ObjectModel;
using RMS.Common;
using RMS;

namespace Managers.Payment
{
    public class CReportManager
    {
        private CResult m_oResult;

        public CReportManager()
        {
            m_oResult = new CResult();
        }

        public CResult GetTotalReport(Int64 inStartTime, Int64 inEndTime)
        {
            try
            {
                m_oResult.Data = RMS.DataAccess.Database.Instance.TotalReport.GetTotalPaymentSummary(inStartTime, inEndTime);
                m_oResult.Message = "Data Read Successful";
                m_oResult.IsSuccess = true;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occured at GetTotalPaymentSummary : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                m_oResult.SetParams(ex.Message);
                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in GetTotalPaymentSummary", LogLevel.Error, "CPaymentSummaryManager");
            }
            return m_oResult;
        }

    }
}
