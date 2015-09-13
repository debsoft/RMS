using System;
using System.Collections.Generic;
using System.Text;
using RMS.Common.ObjectModel;


namespace RMS.DataAccess
{
    public interface IParentCategoryDAO
    {
        void ParentCategoryInsert(CParentCategory inParentCategory);
        void ParentCategoryUpdate(CParentCategory inParentCategory);
        void ParentCategoryDelete(CParentCategory inParentCategory);
        List<CParentCategory> GetAllParentCategory();
    }
}
