using System;
using System.Collections.Generic;
using System.Text;
using RMS.Common.ObjectModel;

namespace RMS.Common.DataAccess
{
    public interface IPrintStyleDAO
    {

        CResult UpdatePrintStyle(CPrintStyle inUser);
    }
}
