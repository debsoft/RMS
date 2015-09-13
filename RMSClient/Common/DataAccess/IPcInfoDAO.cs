using System;
using System.Collections.Generic;
using System.Text;
using RMS.Common.ObjectModel;

namespace RMS.Common.DataAccess
{
    public interface IPcInfoDAO
    {
        CPcInfo PcInfoByPcIP(String inPcIP);

        List<CPcInfo> GetAllPcInfo();
    }
}
