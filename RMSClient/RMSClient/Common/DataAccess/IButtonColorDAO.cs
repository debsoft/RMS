using System;
using System.Collections.Generic;
using System.Text;
using RMS.Common.ObjectModel;

namespace RMS.Common.DataAccess
{
    public interface IButtonColorDAO
    {
        void ButtonColorInsert(CButtonColor inButtonColor);
        void ButtonColorUpdate(CButtonColor inButtonColor);
        void ButtonColorDelete(CButtonColor inButtonColor);
        List<CButtonColor> GetAllButtonColor();
        CButtonColor ButtonColorGetByButtonName(String inButtonName);
    }
}
