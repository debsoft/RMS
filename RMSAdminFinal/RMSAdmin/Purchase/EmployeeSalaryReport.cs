using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common.ObjectModel;
using Database;
using RMS;
using RMS.Common.Config;
using RMS.DataAccess;

namespace RMSAdmin.Purchase
{
    public partial class EmployeeSalaryReport : Form
    {
        public EmployeeSalaryReport()
        {
            InitializeComponent();
            yearcomboBox.SelectedIndex = 0;
            monthcomboBox.SelectedIndex = 0;
            EmployeeDAO aEmployeeDao=new EmployeeDAO();
            List<Employee> aEmployees=new List<Employee>();
            aEmployees = aEmployeeDao.GetAllEmployee();
            employeecomboBox.DataSource = aEmployees;
            employeecomboBox.DisplayMember = "EmployeeName";
            employeecomboBox.ValueMember = "EmployeeId";
        }

        private void showreportButton_Click(object sender, EventArgs e)
        {
          



            try
            {
                
                    String sqlCommand ="";
                    if (employeecheckBox.Checked)
                    {
                        sqlCommand = string.Format(SqlQueries.GetQuery(Query.ViewEmployeeSalaryReportWithEmployee),yearcomboBox.Text,monthcomboBox.Text,Convert.ToInt32(employeecomboBox.SelectedValue));
                    }else
                    {
                        sqlCommand = string.Format(SqlQueries.GetQuery(Query.ViewEmployeeSalaryReport), yearcomboBox.Text, monthcomboBox.Text);
                    }




                //sqlCommand = String.Format(sqlCommand, categoryID);



                    CDalConfig oTempDal = ConfigManager.GetConfig<CDalConfig>();

                    String tempConnStr = oTempDal.ConnectionString;

                    // Create a new data adapter based on the specified query.
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand, tempConnStr);

                    // Create a command builder to generate SQL update, insert, and
                    // delete commands based on selectCommand. These are used to
                    // update the database.
                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                    // Populate a new data table and bind it to the BindingSource.
                    DataTable table = new DataTable();
                    table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    dataAdapter.Fill(table);
                   employeereportdataGridView.DataSource = table;

                    dataAdapter.Dispose();
                
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message + "Error Occured. Please contact to your administrator.", RMSGlobal.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }






            
        }

        private void printreportButton_Click(object sender, EventArgs e)
        {

         


            List<EmployeeReport> aList = new List<EmployeeReport>();
            //aList = (List<EmployeeReport>)employeereportdataGridView.DataSource;
            //if (aList == null)
            //{
            //    MessageBox.Show("No data Available");
            //    return;
            //}
            int printlenght = aList.Count;
            PrintDocument doc = new TextDocument(PrintEmployeeReport(aList), printlenght);
            
            doc.PrintPage += this.Doc_PrintPage;


            doc.DefaultPageSettings.Landscape = true;
            PrintDialog dlgSettings = new PrintDialog();
            dlgSettings.Document = doc;
            dlgSettings.UseEXDialog = true;

            if (dlgSettings.ShowDialog() == DialogResult.OK)
            {
                doc.Print();
            }
        }

        private string PrintEmployeeReport(List<EmployeeReport> aList)
        {
            string strBody = "";
            StringPrintFormater stringPrintFormater = new StringPrintFormater(180);
            VariousMethod aMethod = new VariousMethod();
            string header = aMethod.GetPrintDecorationText(VariousMethod.PrintDecoration.HEADER);
            strBody += header;
            //   strBody += "\r\n";

            strBody += "\r\n" + stringPrintFormater.CenterTextWithWhiteSpace("Employee Salary Report");
            // strBody += "\r\n";
     
            strBody += "\r\n";
            strBody += "\r\n" + stringPrintFormater.CreateDashedLine();

            strBody += "\r\n" + stringPrintFormater.GridCell("Id No.",15, false);
            strBody += stringPrintFormater.GridCell("Name", 15, false);
            strBody += stringPrintFormater.GridCell("Position", 15, false);
             strBody += stringPrintFormater.GridCell("Working days", 15, false);
            strBody += stringPrintFormater.GridCell("Ateending days", 15, false);
            strBody += stringPrintFormater.GridCell("Salary Structure(Tk)", 15, false);
             strBody +=  stringPrintFormater.GridCell("Deducted Salary(Tk)", 15, false);
            strBody += stringPrintFormater.GridCell("Payable Salary(Tk)", 15, false);
            strBody += stringPrintFormater.GridCell("Service Charge(Tk)", 15, false);
             strBody +=  stringPrintFormater.GridCell("Food And H.Rent Allow.(Tk)", 15, false);
            strBody += stringPrintFormater.GridCell("Total Payable Salary(Tk)", 15, false);
            strBody += stringPrintFormater.GridCell("Remarks", 15, false);


            strBody += "\r\n" + stringPrintFormater.CreateDashedLine() + "\r\n";

            foreach (DataGridViewRow report in employeereportdataGridView.Rows)
            {
                foreach (DataGridViewCell col in report.Cells)
                {
                    if (col.Value != null)
                    {
                        strBody += stringPrintFormater.GridCell(col.Value.ToString(), 15, false);
                    }
                    else
                    {
                        strBody += stringPrintFormater.GridCell("", 15, false);
                    }
                }

                strBody += "\r\n" + stringPrintFormater.CreateDashedLine() + "\r\n";

            }


            strBody += aMethod.AddEndPart();


            return strBody;
        }

        private void Doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {

                TextDocument doc = (TextDocument) sender;

                Font font = new Font("Lucida Console", 8);

                float lineHeight = font.GetHeight(e.Graphics);

                float x = e.MarginBounds.Left;
                float y = e.MarginBounds.Top;

             

                    e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\aroma.jpg"), 465, 0);
                

    
     


                doc.PageNumber += 1;

                while ((y + lineHeight) < e.MarginBounds.Bottom && doc.Offset <= doc.Text.GetUpperBound(0))
                {
                    e.Graphics.DrawString(doc.Text[doc.Offset], font, Brushes.Black, 0, y);
                    doc.Offset += 1;
                    y += lineHeight;
                }

                if (doc.Offset < doc.Text.GetUpperBound(0))
                {
                    e.HasMorePages = true;
                }
                else
                {
                    doc.Offset = 0;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Sorry! Problem occured." + ex.ToString());
            }
        }
    }
}

    

