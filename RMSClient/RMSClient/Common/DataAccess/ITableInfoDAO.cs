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
        CTableInfo TableInfoGetByTableNumber(int inTableNumber, string inTableType);
        List<Int32> GetTableNumberList(String TableType);
        CResult AvailableTableForTransfer();
        CResult UpdateDBForUnlock(int inTableNumber, String inTableType);
        void DeleteTableInfo(int inTableNumber, string inTableType);
    }
}
