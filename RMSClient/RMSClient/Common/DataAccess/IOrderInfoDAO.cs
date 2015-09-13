using System;
using System.Collections.Generic;
using System.Text;
using RMS.Common.ObjectModel;

namespace RMS.Common.DataAccess
{
    public interface IOrderInfoDAO
    {
        COrderInfo OrderInfoInsert(COrderInfo inOrderInfo);
        void OrderInfoUpdate(COrderInfo inOrderInfo);
        COrderInfo GetOrderInfoByOrderID(Int64 inOrderID);
        CResult GetOrderInfoArchiveByOrderID(Int64 inOrderID);
        void InsertOrderSeatTime(COrderSeatTime inOrderSeatTime);
        COrderSeatTime OrderSeatTimeByOrderID(Int64 inOrderID);
        CResult InsertOrderDetailsArchive(Int64 inOrderID);
        CResult InsertOrderArchive(COrderInfo inOrderInfo);
        CResult OrderDetailsGetByOrderID(Int64 inOrderID);
        void DeleteOrderInfo(Int64 inOrderID);
        CResult InsertOrderDiscount(COrderDiscount inOrderDiscount);
        CResult UpdateOrderDiscount(COrderDiscount inOrderDiscount);
        CResult GetOrderDiscountByOrderID(Int64 inOrderID);
        CResult InsertOrderVoucher(COrderVoucher inOrderVoucher);
        CResult GetOrderdetails(Int64 startTime,Int64 endTime);
        
    }
}
