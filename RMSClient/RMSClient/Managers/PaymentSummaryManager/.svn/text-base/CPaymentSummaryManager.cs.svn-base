/*
 * File name: CButtonAccess.cs 
 * Author: Md. Zahidur Rahman
 *   
 * Description: 
 * 
 * Modification history:
 * Name					Date					Desc
 *                     1/4/2008
 *  
 * Version: 1.0
 * Copyright (c) 2007: Ibacs Ltd..
 */

using System;
using System.Collections.Generic;
using System.Text;
using RMS.DataAccess;
using RMS.Common.ObjectModel;
using RMS.Common;
using RMS;

namespace Managers.PaymentSummaryManager
{
    public class CPaymentSummaryManager
    {
        private CResult m_oResult;

        public CPaymentSummaryManager()
        {
            m_oResult = new CResult();
        }

        public CResult GetTotalPaymentSummary(DateTime inCurrentDate)
        {
            try
            {
                //CPaymentSummary oPaymentSummary = Database.Instance.PaymentSummary.GetTotalPaymentSummary(inCurrentDate);
                //oPaymentSummary.PaymentFoodType = Database.Instance.PaymentSummary.GetTotalPaymentByTypeNDate("Food", inCurrentDate);
                //oPaymentSummary.PaymentNonFoodType = Database.Instance.PaymentSummary.GetTotalPaymentByTypeNDate("Nonfood", inCurrentDate);

                m_oResult = Database.Instance.PaymentSummary.GetTotalPaymentSummary(inCurrentDate);
                if (m_oResult.IsSuccess)
                {
                    CPaymentSummary oPaymentSummary = (CPaymentSummary)m_oResult.Data;
                    CResult tempResult1 = Database.Instance.PaymentSummary.GetTotalPaymentByTypeNDate("Food", inCurrentDate);
                    CResult tempResult2 = Database.Instance.PaymentSummary.GetTotalPaymentByTypeNDate("Nonfood", inCurrentDate);
                    if (tempResult1.IsSuccess) oPaymentSummary.PaymentFoodType = (float)tempResult1.Data;
                    if (tempResult2.IsSuccess) oPaymentSummary.PaymentNonFoodType = (float)tempResult2.Data;

                    m_oResult = new CResult();
                    m_oResult.IsSuccess = true;
                    m_oResult.Data = oPaymentSummary;
                    m_oResult.Message = "Data Read Successful";
                }

                //m_oResult.Data = oPaymentSummary;
                //m_oResult.IsSuccess = true;               
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

        public CResult GetTotalPaymentSummaryByOrderType(DateTime inCurrentDate, String inOrderType) //New Added
        {
            try
            {
                //CPaymentSummary oPaymentSummary = Database.Instance.PaymentSummary.GetTotalPaymentSummaryByOrderType(inCurrentDate, inOrderType);
                //oPaymentSummary.PaymentFoodType = Database.Instance.PaymentSummary.GetTotalPaymentByTypeNDateByOrderType("Food", inCurrentDate, inOrderType);
                //oPaymentSummary.PaymentNonFoodType = Database.Instance.PaymentSummary.GetTotalPaymentByTypeNDateByOrderType("Nonfood", inCurrentDate, inOrderType);

                m_oResult = Database.Instance.PaymentSummary.GetTotalPaymentSummaryByOrderType(inCurrentDate, inOrderType);
                if (m_oResult.IsSuccess)
                {
                    CPaymentSummary oPaymentSummary = (CPaymentSummary)m_oResult.Data;
                    CResult tempResult1 = Database.Instance.PaymentSummary.GetTotalPaymentByTypeNDateByOrderType("Food", inCurrentDate, inOrderType);
                    CResult tempResult2 = Database.Instance.PaymentSummary.GetTotalPaymentByTypeNDateByOrderType("Nonfood", inCurrentDate, inOrderType);
                    if (tempResult1.IsSuccess) oPaymentSummary.PaymentFoodType = (float)tempResult1.Data;
                    if (tempResult2.IsSuccess) oPaymentSummary.PaymentNonFoodType = (float)tempResult2.Data;

                    m_oResult = new CResult();
                    m_oResult.IsSuccess = true;
                    m_oResult.Data = oPaymentSummary;
                    m_oResult.Message = "Data Read Successful";
                }
                //m_oResult.Data = oPaymentSummary;
                //m_oResult.IsSuccess = true;
                //m_oResult.Message = "Data Read Successful";
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occured at GetTotalPaymentSummaryByOrderType : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                m_oResult.SetParams(ex.Message);
                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in GetTotalPaymentSummaryByOrderType", LogLevel.Error, "CPaymentSummaryManager");
            }
            return m_oResult;
        }

        public CResult GetTotalPaymentSummaryByPC(DateTime inCurrentDate, int inPCID)
        {
            try
            {
                //CPaymentSummary oPaymentSummary = Database.Instance.PaymentSummary.GetTotalPaymentSummaryByPC(inCurrentDate, inPCID);
                //oPaymentSummary.PaymentFoodType = Database.Instance.PaymentSummary.GetTotalPaymentByTypeNDateNPC("Food", inCurrentDate, inPCID);
                //oPaymentSummary.PaymentNonFoodType = Database.Instance.PaymentSummary.GetTotalPaymentByTypeNDateNPC("Nonfood", inCurrentDate, inPCID);

                m_oResult = Database.Instance.PaymentSummary.GetTotalPaymentSummaryByPC(inCurrentDate, inPCID);
                if (m_oResult.IsSuccess)
                {
                    CPaymentSummary oPaymentSummary = (CPaymentSummary)m_oResult.Data;
                    CResult tempResult1 = Database.Instance.PaymentSummary.GetTotalPaymentByTypeNDateNPC("Food", inCurrentDate, inPCID);
                    CResult tempResult2 = Database.Instance.PaymentSummary.GetTotalPaymentByTypeNDateNPC("Nonfood", inCurrentDate, inPCID);
                    if (tempResult1.IsSuccess) oPaymentSummary.PaymentFoodType = (float)tempResult1.Data;
                    if (tempResult2.IsSuccess) oPaymentSummary.PaymentNonFoodType = (float)tempResult2.Data;

                    m_oResult = new CResult();
                    m_oResult.IsSuccess = true;
                    m_oResult.Data = oPaymentSummary;
                    m_oResult.Message = "Data Read Successful";
                }

                //m_oResult.Data = oPaymentSummary;
                //m_oResult.IsSuccess = true;
                //m_oResult.Message = "Data Read Successful";
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occured at GetTotalPaymentSummaryByPC : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                m_oResult.SetParams(ex.Message);
                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in GetTotalPaymentSummaryByPC", LogLevel.Error, "CPaymentSummaryManager");
            }
            return m_oResult;
        }

        public CResult GetTotalPaymentSummaryForViewReport(DateTime inCurrentDate)
        {
            try
            {
                //List<CPaymentSummaryByOrder> oPaymentSummaryByOrder = Database.Instance.PaymentSummaryByOrder.GetTotalPaymentSummaryByOrder(inCurrentDate);
                //List<CPaymentSummaryByOrder> oPaymentSummaryByOrder = Database.Instance.PaymentSummaryForViewReport.GetTotalPaymentForViewReport(inCurrentDate);
                m_oResult = Database.Instance.PaymentSummaryForViewReport.GetTotalPaymentForViewReport(inCurrentDate);
                //m_oResult.Data = oPaymentSummaryByOrder;
                //m_oResult.IsSuccess = true;
                m_oResult.Message = "Data Read Successful";
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

        public CResult GetTotalPaymentSummaryForViewReportBySearch(DateTime inCurrentDate, string inRefNo, string inPrice, string inTableNo, bool inRef, bool inPr, bool inTable)
        {
            try
            {
                //List<CPaymentSummaryByOrder> oPaymentSummaryByOrder = Database.Instance.PaymentSummaryForViewReport.GetTotalPaymentForViewReportBySearch(inCurrentDate, inRefNo, inPrice, inTableNo, inRef, inPr, inTable);
                m_oResult = Database.Instance.PaymentSummaryForViewReport.GetTotalPaymentForViewReportBySearch(inCurrentDate, inRefNo, inPrice, inTableNo, inRef, inPr, inTable);
                //m_oResult.Data = oPaymentSummaryByOrder;
                //m_oResult.IsSuccess = true;
                m_oResult.Message = "Data Read Successful";
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

        public CResult GetTotalPaymentSummaryForViewReportByPC(DateTime inCurrentDate, int inPCID) //Check
        {
            try
            {
                //List<CPaymentSummaryByOrder> oPaymentSummaryByOrder = Database.Instance.PaymentSummaryByOrder.GetTotalPaymentSummaryByOrder(inCurrentDate);
                //List<CPaymentSummaryByOrder> oPaymentSummaryByOrder = Database.Instance.PaymentSummaryForViewReport.GetTotalPaymentForViewReportByPC(inCurrentDate, inPCID);
                m_oResult = Database.Instance.PaymentSummaryForViewReport.GetTotalPaymentForViewReportByPC(inCurrentDate, inPCID);
                //m_oResult.Data = oPaymentSummaryByOrder;
                //m_oResult.IsSuccess = true;
                m_oResult.Message = "Data Read Successful";
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occured at GetTotalPaymentSummaryForViewReportByPC() : " + ex.Message);
                m_oResult.IsException = true;
                m_oResult.Action = EERRORNAME.EXCEPTION_OCCURE;
                m_oResult.SetParams(ex.Message);
                m_oResult.Message = ex.Message;
                Logger.Write("Exception : " + ex + " in GetTotalPaymentSummaryForViewReportByPC() ", LogLevel.Error, "CPaymentSummaryManager");
            }
            return m_oResult;
        }

    }
}
