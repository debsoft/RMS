using System;
using System.Collections.Generic;
using System.Text;
using RMS.Common.ObjectModel;


namespace RMS.Common.DataAccess
{
    public interface ICategory4DAO
    {
        CResult Cat4Delete(CCategory4 oCat);

        CResult AddCat4(CCategory4 inUser);

        CResult Cat4Update(CCategory4 oCat, int inCatOrder);

        CResult GetCategory4(CCategory4 inCat);

        CResult GetCategory4(Int32 inCat4ID);

        CResult GetCategory4All();

        CResult Cat4UpdateOrderUp(CCategory4 oCat, CCategory4 oCat2);

        CResult Cat4UpdateOrderDown(CCategory4 oCat, CCategory4 oCat2);
    }
}