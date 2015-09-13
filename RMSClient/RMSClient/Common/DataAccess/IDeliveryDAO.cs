using System;
using System.Collections.Generic;
using System.Text;
using RMS.Common.ObjectModel;

namespace RMS.Common.DataAccess
{
    public interface IDeliveryDAO
    {
        CResult InsertDelivery(CDelivery inDelivery);
    }
}
