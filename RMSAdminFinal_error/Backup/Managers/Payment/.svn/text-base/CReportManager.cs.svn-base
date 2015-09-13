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

        /// <summary>
        /// Collecting the sold reports of the selected date range.
        /// </summary>
        /// <param name="inStartTime"></param>
        /// <param name="inEndTime"></param>
        /// <returns></returns>
        public CResult GetSoldRecords(Int64 inStartTime, Int64 inEndTime)
        {
            try
            {
                m_oResult= RMS.DataAccess.Database.Instance.TotalReport.GetSoldItems(inStartTime, inEndTime);
                m_oResult.Message = "Data Read Successful";
                m_oResult.IsSuccess = true;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception created at GetSoldRecords : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                m_oResult.SetParams(ex.Message);
                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in GetSoldRecords", LogLevel.Error, "ReportManager");
            }
            return m_oResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inStartTime"></param>
        /// <param name="inEndTime"></param>
        /// <returns></returns>
        public CResult GetInventorySalesRecords(Int64 inStartTime, Int64 inEndTime)
        {
            try
            {
                m_oResult = RMS.DataAccess.Database.Instance.InventorySalesReport.GetSalesReport(inStartTime, inEndTime);
                m_oResult.Message = "Data Read Successful";
                m_oResult.IsSuccess = true;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception created at GetSoldRecords : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                m_oResult.SetParams(ex.Message);
                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in GetSoldRecords", LogLevel.Error, "ReportManager");
            }
            return m_oResult;
        }

        /// <summary>
        /// Collecting the food types.
        /// </summary>
        /// <returns></returns>
        public CResult GetFoodTypesRecords()
        {
            try
            {
                m_oResult = RMS.DataAccess.Database.Instance.InventorySalesReport.GetFoodTypes();
                m_oResult.Message = "Data Read Successful";
                m_oResult.IsSuccess = true;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception created at GetSoldRecords : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                m_oResult.SetParams(ex.Message);
                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in GetSoldRecords", LogLevel.Error, "ReportManager");
            }
            return m_oResult;
        }

        /// <summary>
        /// Collecting the food category
        /// </summary>
        /// <returns></returns>
        public CResult GetFoodCategoryRecords()
        {
            try
            {
                m_oResult = RMS.DataAccess.Database.Instance.InventorySalesReport.GetFoodCategories();
                m_oResult.Message = "Data Read Successful";
                m_oResult.IsSuccess = true;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception created at GetSoldRecords : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                m_oResult.SetParams(ex.Message);
                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in GetSoldRecords", LogLevel.Error, "ReportManager");
            }
            return m_oResult;
        }

        /// <summary>
        /// Collecting the food items 
        /// </summary>
        /// <returns></returns>
        public CResult GetFoodItemRecords()
        {
            try
            {
                m_oResult = RMS.DataAccess.Database.Instance.InventorySalesReport.GetFoodItems();
                m_oResult.Message = "Data Read Successful";
                m_oResult.IsSuccess = true;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception created at GetSoldRecords : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                m_oResult.SetParams(ex.Message);
                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in GetSoldRecords", LogLevel.Error, "ReportManager");
            }
            return m_oResult;
        }

        /// <summary>
        /// Collecting the slection of items
        /// </summary>
        /// <returns></returns>
        public CResult GetSelectionofItemsRecords()
        {
            try
            {
                m_oResult = RMS.DataAccess.Database.Instance.InventorySalesReport.GetSelectionOfItems();
                m_oResult.Message = "Data Read Successful";
                m_oResult.IsSuccess = true;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception created at GetSoldRecords : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                m_oResult.SetParams(ex.Message);
                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in GetSoldRecords", LogLevel.Error, "ReportManager");
            }
            return m_oResult;
        }

    }
}
