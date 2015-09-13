using System;
using System.Collections.Generic;
using System.Collections;
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
        
        /// <summary>
        /// /Added by Baruri
        /// </summary>
        /// <param name="inOrderInfo"></param>
        /// <returns></returns>
        CResult InsertOnlineOrderArchive(COrderInfo inOrderInfo);
        void UpdateTakeawayOrder(COrderInfo inOrderInfo);

        //Added byBaruri
        CResult GetOnlineOrderPrintStatus(Int64 inOrderID);
        CResult ChangeOnlineOrderPrintStatus(Int64 inOrderID);

        //Added by Baruri
        CResult InsertOrderServiceCharge(ServiceCharge inOrderServiceCharge);
        CResult UpdateOrderServiceCharge(ServiceCharge inOrderServiceCharge);
        CResult GetOrderServiceChargeByOrderID(Int64 inOrderID);

        CResult VoidPrintedItems(SortedList slPrintedList, Int64 orderID);

        CResult SaveOrderKitchenText(Int64 inOrderID, string kitchenText);

        CResult SaveOrderKitchenText(Int64 inOrderID, string kitchenText,int printstatus);

        CResult UpdateOrderKitchenTextStatus(Int64 orderID);

        CResult VoidOnlinePrintedItems(SortedList slPrintedList);

        CResult GetOrderLogInformation(Int64 orderID);

        CResult ChangeGuestBillPrintStatus(Int64 orderID);


        CResult GetOnlineOrderLogInformation(Int64 orderID);

        CResult GetKitchenText(Int64 orderID);

    }
}
