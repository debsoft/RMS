using System;
using System.Collections.Generic;
using System.Text;
using RMS.Common.ObjectModel;

namespace RMS.Common.DataAccess
{
   public interface IFinishedRawProductListDAO
    {
        CFinishedRawProductList FinishedRawProductListInsert(CFinishedRawProductList finishedRawProductList);
        CFinishedRawProductList FinishedRawProductListUpdate(CFinishedRawProductList finishedRawProductList);
        bool FinishedRawProductListDelete(CFinishedRawProductList finishedRawProductList);

        CFinishedRawProductList GetFinishedRawProductListByFinishedProductIDRawProductID(long productID, long rawProductID);

        List<CFinishedRawProductList> GetFinishedRawProductListByProductID(long productID);
        List<CFinishedRawProductList> GetFinishedRawProductListByProductName();

        List<CFinishedRawProductList> GetFinishedRawProductListAll();
    }
}
