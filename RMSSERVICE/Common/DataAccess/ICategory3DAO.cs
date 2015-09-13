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

        CResult Cat3Update(CCategory3 oCat);

        CResult GetCategory3(CCategory3 inCat);

    }
}
