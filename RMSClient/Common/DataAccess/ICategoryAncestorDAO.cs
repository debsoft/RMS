using System;
using System.Collections.Generic;
using System.Text;
//using ProductCommon.ObjectModel;
using RMS.Common.ObjectModel;

namespace RMS.Common.DataAccess
{
    public interface ICategoryAncestorDAO
    {
        CResult GetCategoryAnchestors(int inLeafCategoryID, int inCatLevel);
    }
}
