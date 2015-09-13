using System;
using System.Collections.Generic;
using System.Text;
using RMS.Common.ObjectModel;

namespace RMS.Common.DataAccess
{
    public interface ICategory1DAO
    {

        CResult AddCat1(CCategory1 inUser);

        CResult Cat1Delete(CCategory1 oCat);

        CResult Cat1Update(CCategory1 oCat);

        CResult GetCategory1(CCategory1 inCat);
    }
}
