using System;
using System.Collections.Generic;
using System.Text;
using RMS.Common.ObjectModel;

namespace RMS.Common.DataAccess
{
    public interface IOrderwaiterDao
    {
        COrderwaiter InsertOrderwaiter(COrderwaiter orderwaiter);
        COrderwaiter UpdateOrderwaiter(COrderwaiter orderwaiter);
        bool DeleteOrderwaiter(long orderID);
        COrderwaiter GetOrderwaiterByOrderID(Int64 inOrderID);
        COrderwaiter GetOrderwaiterBywaiterID(Int64 inOrderID);
        List<RMS.Common.ObjectModel.COrderwaiter> GetAllOrderwaiter();
    }
}
