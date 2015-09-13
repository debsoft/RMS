using System;
using System.Collections.Generic;
using System.Text;
using RMS.Common.ObjectModel;
using RMS.DataAccess;

namespace Managers.GManager
{
    public class GeneralSettingsManager
    {
        public GeneralSettingsManager()
        { 
        
        }

        public GeneralSettings GetGeneralSettings()
        {
           CResult cResult= Database.Instance.GeneralSettings.GetGeneralSettings();
           return (GeneralSettings)cResult.Data;
        }

        public bool UpdateSettings(double vat, bool isVatEnabled, string currency)
        {
            CResult cResult = Database.Instance.GeneralSettings.UpdateGeneralSettings(vat, isVatEnabled, currency);
            return cResult.IsSuccess;
        }
    }
}
