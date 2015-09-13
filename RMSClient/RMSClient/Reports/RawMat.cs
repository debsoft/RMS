using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RMSUI;
using Managers.SystemManagement;
using RMS.Common.ObjectModel;
using System.Collections;
using RMS.Common;
using System.Linq;
using System.Drawing.Printing;
using Managers.Payment;
using ns;
using RmsRemote;
using System.IO;
using System.Diagnostics;
using RMS.DataAccess;
using System.Data.SqlClient;
using RMS.Common.DataAccess;
using RMSClient.DataAccess;
using RMS.Utility;

namespace RMS.Reports
{
    
    public partial class RawMat : Form
    {


        protected IDbConnection m_oConnection;

      
        protected IDbConnection CreateConnection(string sConnectionString)
        {
            //for now returning hardcoded connection object
            return new SqlConnection(sConnectionString);
        }
        protected void OpenConnection(string sConnectionString)
        {
            try
            {
                if (sConnectionString.Length > 0)
                {
                    m_oConnection = this.CreateConnection(sConnectionString);
                    m_oConnection.Open();
                }
                else
                {
                    Debug.WriteLine("Error occured while oppening database connection: ConnectionString was empty.");
                }
            }
            catch (Exception exp)
            {
                //TODO: Logs the error and send emails
                throw new Exception("Exception occured while oppening database connection.", exp);
            }
        }
        
        public RawMat()
        {
            InitializeComponent();
        }


        DataTable tableReport;
        //public void FormatDataTime()
        //{
        //    chkFromTime.Checked = true;
        //    DateTime fromDateTaken = new DateTime(1971, 1, 1, System.DateTime.Now.Hour, System.DateTime.Now.Minute, System.DateTime.Now.Second);

        //    fromDateTaken.Value = System.DateTime.Now;
        //    toDateTaken.Value = System.DateTime.Now;
        //    DateTime firstDate = new DateTime(1971, 1, 1, 12, 0, 0);
        //    DateTime secondDate = new DateTime(1971, 1, 1, 6, 59, 59);
        //    DateTime excepTime = dtpStart.Value.AddHours(-1);

        //    if (fromDateTaken >= firstDate && fromDateTaken <= secondDate || excepTime.Day < dtpStart.Value.Day)
        //    {
        //        fromDate.Value = fromDate.Value.AddDays(-1);
        //    }
        //    else
        //    {
        //        toDate.Value = toDate.Value.AddDays(1);
        //    }

        //}
        private void button1_Click(object sender, EventArgs e)
        {
            DataSet dsSalesRecords = new DataSet();
            CResult objResult = new CResult();
            SystemManager objSystemMgnr = new SystemManager();

        
            DateTime fromDateTaken = new DateTime();
            DateTime toDateTaken = new DateTime();

            fromDateTaken = new DateTime(fromDate.Value.Year, fromDate.Value.Month, fromDate.Value.Day, 7, 0, 0);
            toDateTaken = new DateTime(toDate.Value.Year, toDate.Value.Month, toDate.Value.Day, 6, 59, 59);

            toDateTaken = toDateTaken.AddDays(1);

            objResult = objSystemMgnr.GetRawMat(fromDateTaken.Ticks, toDateTaken.Ticks);

            RawMatGrid.DataSource = null;

            DataTable dt = (DataTable)objResult.Data;

            tableReport = new DataTable();
           
            tableReport.Columns.Add("cat3_id", typeof(int));
            
            tableReport.Columns.Add("cat3_name", typeof(string));
           
            
            tableReport.Columns.Add("UnitsInStock", typeof(float));

            tableReport.Columns.Add("uom", typeof(string));

            tableReport.Columns.Add("Date", typeof(DateTime));
            tableReport.Columns.Add("AdditionalQty", typeof(float));
            tableReport.Columns.Add("PrevQty",typeof(float));

            //long beginTicks = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).Ticks;

            if (dt != null || dt.Rows.Count > 0)
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                   //long dateNumber = Convert.ToInt64(dt.Rows[i]["datetime"]);
                    
                  //  DateTime dateValue = new DateTime(beginTicks + Convert.ToInt64(dt.Rows[i]["datetime"]) * 10000);
                    tableReport.Rows.Add(Convert.ToInt16(dt.Rows[i]["cat3_id"]), Convert.ToString(dt.Rows[i]["cat3_name"]), dt.Rows[i]["UnitsInStock"].ToString(), dt.Rows[i]["uom"].ToString(), dt.Rows[i]["Date"], dt.Rows[i]["AdditionalQty"], dt.Rows[i]["PrevQty"]);
                }


            RawMatGrid.AutoGenerateColumns = false;
            RawMatGrid.DataSource = tableReport;

      //      decimal GrandTotal = 0, TotalQty = 0;

         //   foreach (DataRow row in dt.Rows)
         //   {
         //       GrandTotal = GrandTotal + Convert.ToDecimal(row["TotalAmount"]);
         //       TotalQty = TotalQty + Convert.ToDecimal(row["quantity"]);
          //  }

      //      this.OpenConnection();
        //    SqlCommand Comm = new SqlCommand();

          


    
           
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form tempForm = CFormManager.Forms.Pop();
            tempForm.Show();
            this.Close();
        }

        private void btnA4Print_Click(object sender, EventArgs e)
        {

        }
    }
}
