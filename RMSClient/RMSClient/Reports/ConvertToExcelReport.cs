using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RMS.Reports
{
   public  class ConvertToExcelReport
    {

        public string ToCsV(DataGridView dGV, string filename)
        {
            string result = "";
            try
            {

                string stOutput = "";
                string sHeaders = "";

                for (int j = 0; j < dGV.Columns.Count; j++)
                {
                    if (dGV.Columns[j].Visible)
                        sHeaders = sHeaders.ToString() + Convert.ToString(dGV.Columns[j].HeaderText) + "\t";
                }
                stOutput += sHeaders + "\r\n";
                for (int i = 0; i < dGV.RowCount; i++)
                {

                    string stLine = "";
                    for (int j = 0; j < dGV.Rows[i].Cells.Count; j++)
                        if (dGV.Rows[i].Cells[j].Visible)
                        {
                            stLine = stLine.ToString() + Convert.ToString(dGV.Rows[i].Cells[j].Value) + "\t";

                        }
                    if (stLine != "")
                        stOutput += stLine + "\r\n";
                }
                Encoding utf16 = Encoding.GetEncoding(1254);
                byte[] output = utf16.GetBytes(stOutput);
                FileStream fs = new FileStream(filename, FileMode.Create);
                BinaryWriter bw = new BinaryWriter(fs);
                bw.Write(output, 0, output.Length);
                bw.Flush();
                bw.Close();
                fs.Close();
                result = "Excel Report Generated Sucessfullly";

            }
            catch (Exception)
            {

                result = "Something Error please try agian";
            }

            return result;
        }

        public string PrintExcel(DataGridView membershipreportdataGridView, string filename)
        {
            string result = "Cancel Reporting";

            SaveFileDialog fdlg = new SaveFileDialog();
            fdlg.Title = "Select file";
            fdlg.Filter = "Excel(*.xls,*.xlsx)|*.xls;*.xlsx|All Files(*.*)|*.*";
            fdlg.FileName = filename;

            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                ConvertToExcelReport aPrintUtility = new ConvertToExcelReport();
                result = aPrintUtility.ToCsV(membershipreportdataGridView, fdlg.FileName);


            }

            return result;
        }

    }
}
