using System;
using System.Collections.Generic;
using System.Text;
using RMS.Common.ObjectModel;

namespace RMS.Common.DataAccess
{
    public interface IShiftOrderInfoDao
    {
        CShiftOrderInfo AddShiftOrderInfo(CShiftOrderInfo shiftOrderInfo);
        CShiftOrderInfo UpdateShiftOrderInfo(CShiftOrderInfo shiftOrderInfo);
        bool DeleteShiftOrderInfo(long ShiftOrderID);
        List<CShiftOrderInfo> GetAllShiftOrderInfo();
        CShiftOrderInfo GetAllShiftOrderInfoID(long ShiftOrderID);
        List<CShiftOrderInfo> GetAllShiftOrderInfoByPaymentcreationDate(DateTime paymentcreationDate);
    }
}
