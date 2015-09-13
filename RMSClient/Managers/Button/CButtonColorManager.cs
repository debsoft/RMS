using System;
using System.Collections.Generic;
using System.Text;
using RMS.Common.ObjectModel;
using RMS.DataAccess;
using RMS.Common;
using RMS;

namespace Managers.Button
{
    public class CButtonColorManager
    {
        private CResult m_oResult;

        public CButtonColorManager()
        {
            m_oResult = new CResult(); 
        }

        public CResult GetAllButtonColor()
        {
            try
            {
                List<CButtonColor> tempButtonColorList = Database.Instance.ButtonColor.GetAllButtonColor();
                m_oResult.Data = tempButtonColorList;
                m_oResult.IsSuccess = true;
                m_oResult.Message = "Data Read Successful";
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occured at GetAllButtonColor() : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                m_oResult.SetParams(ex.Message);
                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in GetAllButtonColor()", LogLevel.Error, "CButtonColorManager");
            }
            return m_oResult;
        }

        public CResult ButtonColorbyButtonName(String inButtonName)
        {
            try
            {
                CButtonColor tempButtonColor = Database.Instance.ButtonColor.ButtonColorGetByButtonName(inButtonName);
                m_oResult.Data = tempButtonColor;
                m_oResult.IsSuccess = true;
                m_oResult.Message = "Data Read Successful";
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occured at ButtonColorbyButtonName() : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                m_oResult.SetParams(ex.Message);
                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in ButtonColorbyButtonName()", LogLevel.Error, "CButtonColorManager");
            }
            return m_oResult;
        }
    }
}
