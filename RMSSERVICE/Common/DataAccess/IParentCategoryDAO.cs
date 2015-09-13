using System;
using System.Collections.Generic;
using System.Text;
using RMS.Common.ObjectModel;

namespace RMS.Common.DataAccess
{
    public interface IParentCategoryDAO
    {

        CResult AddParentCat(CParentCategory inUser);

        CResult ParentCatDelete(CParentCategory oCat);

        CResult GetParentCategory(CParentCategory inCat);

        CResult ParentCatUpdate(CParentCategory oCat);
    }
}
