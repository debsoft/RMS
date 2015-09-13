using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RMS.Common;
using RMS;
using System.Data.SqlClient;
using System.Data;
using RMS.Common.ObjectModel;
using RMS.DataAccess;

namespace RMSAdmin
{
  public  class RMSAdminController
    {

      public static string CollectHeader()
      {
          CCommonConstants oConstants = ConfigManager.GetConfig<CCommonConstants>();
          string tempConnectionString = oConstants.DBConnection;
          string sSql = SqlQueries.GetQuery(Query.GetPrintStyles);
          SqlDataAdapter tempSqlAdapter = new SqlDataAdapter(sSql, tempConnectionString);
          DataSet tempDataSet = new DataSet();
          tempSqlAdapter.Fill(tempDataSet, "PrintStyle");

          string HeaderContent = tempDataSet.Tables["PrintStyle"].Select("style_name = 'normal'")[0]["header"].ToString();
          StringTokenizer tempStringTokenizer = new StringTokenizer(HeaderContent, "\r\n");
          string headerSting = tempStringTokenizer.NextToken();
          return headerSting;
      }

      public static string CollectFooter()
      {
          CCommonConstants oConstants = ConfigManager.GetConfig<CCommonConstants>();
          string tempConnectionString = oConstants.DBConnection;
          string sqlCommand = SqlQueries.GetQuery(Query.GetPrintStyles);
          SqlDataAdapter tempSqlAdapter = new SqlDataAdapter(sqlCommand, tempConnectionString);
          DataSet tempDataSet = new DataSet();
          tempSqlAdapter.Fill(tempDataSet, "PrintStyle");

          string HeaderContent = "\r\n\t" + tempDataSet.Tables["PrintStyle"].Select("style_name = 'normal'")[0]["footer"].ToString();
          StringTokenizer tempStringTokenizer = new StringTokenizer(HeaderContent, "\r\n");
          string footerString = tempStringTokenizer.NextToken();
          return footerString;
      }
    }
}
