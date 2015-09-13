using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RMS.Common.ObjectModel;

namespace RMS.Common.DataAccess
{
    /// <summary>
    /// Sales report interface.
    /// </summary>
    public interface IInventroySalesReportDAO
    {
        CResult GetSalesReport(Int64 p_startTime,Int64 p_endTime);
        CResult GetFoodTypes();
        CResult GetFoodCategories();
        CResult GetFoodItems();
        CResult GetSelectionOfItems();
    }
}
