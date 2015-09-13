using System;
using System.Collections.Generic;
using System.Text;
using RMS.Common.ObjectModel;
using RMS.DataAccess;
using RMS.Common;
using RMS;

namespace Managers.Category
{
    public class CParentCategoryManager
    {
        private CResult m_oResult;

        public CParentCategoryManager()
        {
            m_oResult = new CResult(); 
        }

        public CResult GetAllParentCategory()
        {
            try
            {
                List<CParentCategory> tempParentCategoryList = Database.Instance.ParentCategory.GetAllParentCategory();
                m_oResult.Data = tempParentCategoryList;
                m_oResult.IsSuccess = true;
                m_oResult.Message = "Data Read Successful";
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occured at GetAllParentCategory() : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                m_oResult.SetParams(ex.Message);
                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in GetAllParentCategory()", LogLevel.Error, "CParentCategoryManager");
            }
            return m_oResult;
        }
    }
}
