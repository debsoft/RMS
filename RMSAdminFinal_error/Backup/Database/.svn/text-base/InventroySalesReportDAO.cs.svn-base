using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RMS.Common.DataAccess;
using RMS.Common.ObjectModel;
using RMS.DataAccess;
using System.Data;

namespace Database
{
    public class InventroySalesReportDAO :BaseDAO, IInventroySalesReportDAO
    {

        #region IInventroySalesReportDAO Members

        RMS.Common.ObjectModel.CResult IInventroySalesReportDAO.GetFoodCategories()
        {
            CResult objResult = new CResult();
            String sqlCommand = String.Format(SqlQueries.GetQuery(Query.GetFoodCategoryRecords));
            DataSet dsSalessRecords = this.GetDataset(sqlCommand);
            objResult.Data = dsSalessRecords;
            return objResult;
        }

        RMS.Common.ObjectModel.CResult IInventroySalesReportDAO.GetFoodItems()
        {
            CResult objResult = new CResult();
            String sqlCommand = String.Format(SqlQueries.GetQuery(Query.GetFoodItemRecords));
            DataSet dsSalessRecords = this.GetDataset(sqlCommand);
            objResult.Data = dsSalessRecords;
            return objResult;
        }

        RMS.Common.ObjectModel.CResult IInventroySalesReportDAO.GetFoodTypes()
        {
            CResult objResult = new CResult();
            String sqlCommand = String.Format(SqlQueries.GetQuery(Query.GetFoodTypeRecords));
            DataSet dsSalessRecords = this.GetDataset(sqlCommand);
            objResult.Data = dsSalessRecords;
            return objResult;
        }

        RMS.Common.ObjectModel.CResult IInventroySalesReportDAO.GetSalesReport(long p_startTime, long p_endTime)
        {
            CResult objResult = new CResult();
            String sqlCommand = String.Format(SqlQueries.GetQuery(Query.GetInventorySalesRecords), p_startTime, p_endTime);
            DataSet dsSalessRecords = this.GetDataset(sqlCommand);
            objResult.Data = dsSalessRecords;
            return objResult;
        }

        RMS.Common.ObjectModel.CResult IInventroySalesReportDAO.GetSelectionOfItems()
        {
            CResult objResult = new CResult();
            String sqlCommand = String.Format(SqlQueries.GetQuery(Query.GetSelectionofItemsRecords));
            DataSet dsSalessRecords = this.GetDataset(sqlCommand);
            objResult.Data = dsSalessRecords;
            return objResult;
        }

        #endregion
    }
}
