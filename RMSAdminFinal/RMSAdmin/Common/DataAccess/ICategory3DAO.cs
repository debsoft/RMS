using System;
using System.Collections.Generic;
using System.Text;
using RMS.Common.ObjectModel;

namespace RMS.Common.DataAccess
{
    public interface ICategory3DAO
    {
        CResult Cat3Delete(CCategory3 oCat);

        CResult AddCat3(CCategory3 inUser);

        CResult Cat3Update(CCategory3 oCat, int inCatOrder);

        //CResult GetCategory3(CCategory3 inCat);

        CResult GetCategory3(Int32 inCat3ID);
        CResult GetCategory3All();

        CResult Cat3UpdateOrderUp(CCategory3 oCat, CCategory3 oCat2);

        CResult Cat3UpdateOrderDown(CCategory3 oCat, CCategory3 oCat2);

    }
}