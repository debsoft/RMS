using System;
using System.Collections.Generic;
using System.Text;
using RMS.Common.ObjectModel;

namespace RMS.Common.DataAccess
{
    public interface ICustomerInfoDAO
    {
        CCustomerInfo InsertCustomerInfo(CCustomerInfo inCustomerInfo);
        void UpdateCustomerInfo(CCustomerInfo inCustomerInfo);
        void DeleteCustomerInfo(CCustomerInfo inCustomerInfo);
        CCustomerInfo CustomerInfoGetByCustomerID(Int64 CustomerID);
        CCustomerInfo CustomerInfoGetByPhone(String CustomerPhone);

        CCustomerInfo CustomerInfoGetByName(String CustomerPhone);
        //CCustomerInfo GetCustomerLog(Int64 startDateTime, Int64 endDateTime);
    }
}
