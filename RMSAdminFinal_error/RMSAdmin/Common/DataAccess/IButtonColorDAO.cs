using System;
using System.Collections.Generic;
using System.Text;
using RMS.Common.ObjectModel;

namespace RMS.Common.DataAccess
{
    public interface IButtonColorDAO
    {

        CResult AddButtonColor(CButtonColor inUser);

        CResult GetButtonColor(CButtonColor inCat);

        CResult UpdateButtonColor(CButtonColor inUser);
    }
}