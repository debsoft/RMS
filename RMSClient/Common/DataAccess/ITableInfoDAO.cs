using System;
using System.Collections.Generic;
using System.Text;
using RMS.Common.ObjectModel;

namespace RMS.Common.DataAccess
{
    public interface ITableInfoDAO
    {
        void UpdateTableInfo(CTableInfo inTableInfo);
        void InsertTableInfo(CTableInfo inTableInfo);
        CTableInfo TableInfoGetByTableNumber(Int64 inTableNumber, string inTableType);
        List<Int32> GetTableNumberList(String TableType);
        CResult AvailableTableForTransfer();
        CResult UpdateDBForUnlock(Int64 inTableNumber, String inTableType);
        void DeleteTableInfo(Int64 inTableNumber, string inTableType);
        CResult GetCurentWaitingNumber(Int64 currentDate,int orderIndex);
    }
}
