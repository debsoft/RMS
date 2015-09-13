using System;
using System.Collections.Generic;
using System.Text;
using RMS.Common.ObjectModel;

namespace RMS.Common.DataAccess
{
    public interface IPaymentSummaryDAO
    {
        //void PaymentSummaryInsert(CPaymentSummary oPayment);

        //void PaymentSummaryUpdate(CPaymentSummary oPayment);

        //void PaymentSummaryDelete(CPaymentSummary oPayment);

        CResult GetTotalPaymentSummary(DateTime inCurrentDate);
        CResult GetTotalPaymentSummaryByOrderType(DateTime inCurrentDate, String inOrderType);
        CResult GetTotalPaymentSummaryByPC(DateTime inCurrentDate, int inPCID);
        CResult GetTotalPaymentByTypeNDate(String inType, DateTime inCurrentDate);
        CResult GetTotalPaymentByTypeNDateByOrderType(String inType, DateTime inCurrentDate, String inOrderType);
        CResult GetTotalPaymentByTypeNDateNPC(String inType, DateTime inCurrentDate, int inPCID);
        //List<CPaymentSummaryByOrder> GetTotalPaymentSummaryByOrder(DateTime inCurrentDate);
        CResult GetTotalPaymentForViewReport(DateTime inCutrrentDate);
        CResult GetTotalPaymentForViewReportBySearch(DateTime inCurrentDate, string inRefNo, string inPrice, string inTableNo, bool inRef, bool inPr, bool inTable);//Added
        CResult GetTotalPaymentForViewReportByPC(DateTime inCutrrentDate, int inPCID);
    }
}
