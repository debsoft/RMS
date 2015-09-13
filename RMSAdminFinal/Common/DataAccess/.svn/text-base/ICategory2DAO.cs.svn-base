using System;
using System.Collections.Generic;
using System.Text;
using RMS.Common.ObjectModel;

namespace RMS.Common.DataAccess
{
    public interface ICategory2DAO
    {
        CResult Cat2Delete(CCategory2 oCat);

        CResult AddCat2(CCategory2 inUser);

        CResult Cat2Update(CCategory2 oCat, int inCatOrder);

        //CResult GetCategory2(CCategory2 inCat);

        CResult GetCategory2(int inCat2ID);

        CResult Cat2UpdateOrderUp(CCategory2 oCat, CCategory2 oCat2);

        CResult Cat2UpdateOrderDown(CCategory2 oCat, CCategory2 oCat2);
    }
}