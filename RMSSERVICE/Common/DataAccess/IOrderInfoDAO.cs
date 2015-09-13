using System;
using System.Collections.Generic;
using System.Text;
using RMS.Common.ObjectModel;

namespace RMS.Common.DataAccess
{
    public interface IOrderInfoDAO
    {
        void OrderInfoUpdate(COrderInfo inOrderInfo);
        COrderInfo GetOrderInfoByOrderID(Int64 inOrderID);

    }
}
