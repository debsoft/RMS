using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Common.ObjectModel;
using RMS;
using RMS.Common;
using RMS.Common.ObjectModel;
using RMS.DataAccess;

namespace RMSAdmin.Purchase
{
  public  class VariousMethod
    {

        StringPrintFormater stringPrintFormater = new StringPrintFormater(172);
        public string GetPrintDecorationText(PrintDecoration printDecoration)
        {

            string firstString = "[---]";

            string fieldName = printDecoration == PrintDecoration.HEADER ? "header" : "footer";
            try
            {

                string HeaderContent = HeaderFooterDataset().Tables["PrintStyle"].Select("style_name = 'normal'")[0][fieldName].ToString();
                StringTokenizer tempStringTokenizer = new StringTokenizer(HeaderContent, "\r\n");
                firstString = tempStringTokenizer.NextToken();

                while (tempStringTokenizer.HasMoreTokens())
                {
                    firstString += "\r\n" + tempStringTokenizer.NextToken();

                }
            }
            catch (Exception esx)
            {


            }

            string[] lines = null;
            char[] param = { '\n' };
            if (firstString != null && firstString.Length > 0)
                lines = firstString.Split(param);
            int i = 0;
            char[] trimParam = { '\r' };

            string TotalHader = "";

            if (lines != null && lines.Length > 0)
                foreach (string s in lines)
                {
                    TotalHader += stringPrintFormater.CenterTextWithWhiteSpace(s.TrimEnd(trimParam)) + "\r\n";
                }
            TotalHader += "\r\n\r\n\r\n\r\n";

            return TotalHader;
        }



        private DataSet HeaderFooterDataset()
        {

            DataSet tempDataSet = new DataSet();
            CCommonConstants oConstants = ConfigManager.GetConfig<CCommonConstants>();
            string tempConnectionString = oConstants.DBConnection;
            string sSql = SqlQueries.GetQuery(Query.GetPrintStyles);
            SqlDataAdapter tempSqlAdapter = new SqlDataAdapter(sSql, tempConnectionString);
            tempSqlAdapter.Fill(tempDataSet, "PrintStyle");

            return tempDataSet;
        }


        public enum PrintDecoration
        {
            HEADER,
            FOOTER
        }

        public string AddEndPart()
        {
            string strBody = "";
            strBody += "\r\n";
            strBody += "\r\n" + stringPrintFormater.CenterTextWithDashed("END REPORT");


            strBody += "\r\n\r\n\r\n" + "                     --------------------" + "                        --------------------" + "                                        ---------------------      ";
            strBody += "\r\n" + "                           Accountant" + "                              General Manager" + "                                              Managing Director        ";

            strBody += "\r\n";

            strBody += "\r\n";
            strBody += "Printed Time:" + DateTime.Now;

            return strBody;
        }
    }
}
