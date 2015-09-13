using System;
using System.Collections.Generic;
using System.Text;
using RMS.Common.ObjectModel;

namespace RMS.Common.DataAccess
{
    public interface IPaymentDAO
    {
        CPayment InsertPayment(CPayment inPayment);
        void UpdatePayment(CPayment inPayment);
        void UpdatePaymentVatStat(bool stat,Int64 paymentID);

        void DeletePayment(CPayment inPayment);
        CPayment GetPaymentByOrderID(Int64 inOrderID);
        void InsertBillPrintTime(CPayment inPayment);
        double GetSortedPayment(DateTime inTime);
        CResult GetPaymentLogDetails(Int64 startTime,Int64 endTime);
        CPayment SaveDrawerLogs(Int32 terminalId, string userid, Int64 dateTime);
        CResult GetDrawerLogDetails(Int64 startTime, Int64 endTime);
        
    }
}
