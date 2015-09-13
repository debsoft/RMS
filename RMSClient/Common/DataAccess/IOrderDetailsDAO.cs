using System;
using System.Collections.Generic;
using System.Text;
using RMS.Common.ObjectModel;
using System.Collections;

namespace RMS.Common.DataAccess
{
    public interface IOrderDetailsDAO
    {
        COrderDetails OrderDetailsInsert(COrderDetails inOrderDetails);
        void OrderDetailsUpdate(COrderDetails inOrderDetails);
        void OrderDetailsDelete(Int64 inOrderDetailsID);

        List<COrderDetails> OrderDetailsGetAll();
        CResult OrderDetailsGetByOrderID(Int64 inOrderID);
        CResult OrderDetailsArchiveGetByOrderID(Int64 inOrderID);
        COrderDetails OrderDetailsGetByOrderDetailID(Int64 inOrderDetailID);
        CResult GetOnlineOrderDetailsByOrderID(Int64 inOrderID);
        void DeleteOnlineOrderDetails(Int64 p_itemsOrderNumber);
        void UpdateOnlineOrderDetails(COrderDetails inOrderDetails);
        void AddNewOnlineProducts(COrderDetails p_onlineOrderDetails);
        void AddNewLocalProducts(COrderDetails p_onlineOrderDetails);
        COrderDetails InsertOnlineOrderDetails(COrderDetails inOrderDetails);
        void UpdatePrintedQuantity(SortedList p_printedItemList);
        void UpdateOnlineOrderPrintedQuantity(SortedList p_printedItemList);
        void UpdateOnlineItemSpecial(COrderDetails inOrderDetails);

        CResult GetPluDataByProductPLU(Int32 product_plu,int priceTakeType,Int64 orderID,int productQuantity);
        CResult GetProductByProductPLU(Int32 product_plu);

        CResult UpdateOrderDetailsPricebyPLUProductTablePrice(int product_plu, Int64 orderID, int orderType);
        //CResult AddPLUToProduct(COrderDetails inOrderDetails);

    }
}
