using System;
using System.Collections.Generic;
using System.Text;
using RMS.Common.ObjectModel;

namespace RMS.Common.DataAccess
{
    public interface IDeliveryDAO
    {
        CResult InsertDelivery(CDelivery inDelivery);
        CResult GetDelivery(CDelivery inDelivery);
        CResult UpdateDeliveryInfo(CDelivery inDelivery);
        CResult DeleteDeliveryInfo(Int64 orderID);
    }
}
