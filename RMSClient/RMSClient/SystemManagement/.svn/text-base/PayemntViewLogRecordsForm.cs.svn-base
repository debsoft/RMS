using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RMS.Common.ObjectModel;
using RmsRemote;
using RMS.Common;
using RMSUI;


namespace RMS
{
    public partial class ViewLogRecordsForm : BaseForm
    {
        public static ViewLogRecordsForm objViewLog;
        public CResult objResult = null;

        public ViewLogRecordsForm()
        {
            InitializeComponent();
        }

        public static ViewLogRecordsForm CreateInstance()
        {
            if (objViewLog == null)
            {
                objViewLog = new ViewLogRecordsForm();
            }
            return objViewLog;
        }

        private void ViewLogRecordsForm_Activated(object sender, EventArgs e)
        {
            List<CPayment> tempPayment = new List<CPayment>();
            if (objResult != null)
            {
           
            tempPayment = (List<CPayment>)objResult.Data;
            
                dgvLogRecords.RowCount = 0;
                if (tempPayment!=null)
                {
                    for (int index = 0; index < tempPayment.Count; index++)
                    {
                        DataGridViewRowCollection dgvRow = (DataGridViewRowCollection)dgvLogRecords.Rows;
                        dgvRow.Add(tempPayment[index].PcID,tempPayment[index].OrderID, tempPayment[index].UserID,Convert.ToDateTime(tempPayment[index].PaymentTime).ToString("dd/MM/yy hh:mm tt"), tempPayment[index].TotalAmount);
                    }
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvLogRecords.RowCount > 0)
                {
                    String logBody = String.Empty;
                    string serialFooter = "";
                    string serialHeader = "";

                    CCommonConstants oConstant = ConfigManager.GetConfig<CCommonConstants>();

                    logBody += "\r\n\r\n\t\tLog Register";
                    logBody += "\r\n-----------------------------------";
                    logBody += "\r\nTID OID  UID   Date & Time Activity";
                    logBody += "\r\n-----------------------------------";


                    for (int rowIndex = 0; rowIndex < dgvLogRecords.Rows.Count; rowIndex++)
                    {
                        logBody += "\r\n\r " + dgvLogRecords[0, rowIndex].Value.ToString();
                        logBody += " " + dgvLogRecords[1, rowIndex].Value.ToString();
                        logBody += " " + dgvLogRecords[2, rowIndex].Value.ToString();
                        logBody += " " +Convert.ToDateTime(dgvLogRecords[3, rowIndex].Value).ToString("dd/MM/yy hh:mmtt");
                        logBody += " " +Convert.ToDouble("0"+ dgvLogRecords[4, rowIndex].Value).ToString("F02");
                    }

                    CPrintingFormat tempPrintingFormat = new CPrintingFormat();
                    tempPrintingFormat.Header = serialHeader;
                    tempPrintingFormat.Body = logBody.ToUpper();
                    tempPrintingFormat.Footer = serialFooter;

                    tempPrintingFormat.PrintType = (int)PRINTER_TYPES.Serial;

                    CLogin oLogin = new CLogin();
                    oLogin = (RmsRemote.CLogin)Activator.GetObject(typeof(RmsRemote.CLogin), oConstant.RemoteURL);
                    oLogin.PostPrintingRequest(tempPrintingFormat);
                }
               
            }
            catch (Exception exp)
            { 
             
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void ViewLogRecordsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            objViewLog = null;
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Form tempForm = CFormManager.Forms.Pop();
            tempForm.Show();
            this.Close();
        }
    }
}