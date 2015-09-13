using System;
using System.Collections.Generic;
using System.Text;
using RMS.Common.ObjectModel;

namespace RMS.Common.DataAccess
{
    public interface IOrderShowDAO
    {
        List<COrderShow> OrderListShowByStatus(string sStatus);
        CResult OrderListShowByStatusNDate(string sStatus, DateTime inCurrentDate);
        CResult OrderListForTransfer(bool inMerge);
        CResult AvailableTableForTransfer();
        CResult AvailableTableForUnlock();
        CResult AvailableTableForVoid();
        CResult UpdateDBForTransfer(String inOrderID, int inOldTableNumber, int inNewTableNumber, int inOldTableGuestCount);
        CResult UpdateDBForUnlock(int inTableNumber);
        CResult UpdateDBForVoid(String inOrderID, int inTableNumber, String inTableType, bool inReportTableVoid);
        CResult UpdateDBForMerge(String[] inOrderID, String inMasterOrderID, int[] inTableNumber, int inMasterTableNumber, int inTotalGuestCount);
    }//IOrderShowDAO
}
