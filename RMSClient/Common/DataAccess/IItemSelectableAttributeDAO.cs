using System;
using System.Collections.Generic;

using System.Text;


using RMS.Common.ObjectModel;


namespace RMS.Common.DataAccess
{
    public interface IItemSelectableAttributeDAO
    {
        CResult DeleteItemSelectableAttributeByID(int ID);

        CResult AddItemSelectableAttribute(CItemSelectableAttribute inUser);

        CResult UpdateItemSelectableAttribute(CItemSelectableAttribute theData);

        CItemSelectableAttribute GetItemSelectableAttribute(CItemSelectableAttribute inCat);

        CItemSelectableAttribute GetItemSelectableAttributeByID(Int32 itemSelectableAttributeID);

        List<CItemSelectableAttribute> GetGlobalSelectableAttributeByCategory4ID(int cat4ID, bool isCat4ID);

        CItemSelectableAttribute GetGlobalSelectableAttributeByCategory4IDAndByToppingID(int cat4ID, int toppingID, bool isCat4ID);

        List<CItemSelectableAttribute> GetAllItemSelectableAttribute();
    }
}
