using System;
using System.Collections.Generic;
using System.Text;
using RMS.Common.ObjectModel;

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
    }
}
