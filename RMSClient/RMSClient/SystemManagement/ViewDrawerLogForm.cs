using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RMS.Common.ObjectModel;
using RMS.Common;
using RmsRemote;
using RMSUI;

namespace RMS
{
    public partial class ViewDrawerLogForm : BaseForm
    {
        public static ViewDrawerLogForm objDrawerLog;
        public CResult objResult = null;

        public ViewDrawerLogForm()
        {
            InitializeComponent();
        }

        public static ViewDrawerLogForm CreateInstance()
        {
            if (objDrawerLog == null)
            {
                objDrawerLog = new ViewDrawerLogForm();
            }
            return objDrawerLog;
        }

        private void ViewDrawerLogForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            objDrawerLog = null;
        }

        private void ViewDrawerLogForm_Activated(object sender, EventArgs e)
        {
            List<CPayment> tempPayment = new List<CPayment>();
            if (objResult != null)
            {
            tempPayment = (List<CPayment>)objResult.Data;
            
                dgvLogDrawer.RowCount = 0;
                if (tempPayment!=null)
                {
                    for (int index = 0; index < tempPayment.Count; index++)
                    {
                        DataGridViewRowCollection dgvRow = (DataGridViewRowCollection)dgvLogDrawer.Rows;
                        dgvRow.Add(tempPayment[index].PcID,tempPayment[index].OrderID, tempPayment[index].UserID,Convert.ToDateTime(tempPayment[index].PaymentTime).ToString("dd/MM/yy hh:mm tt"), "Opening");
                    }
                }
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Form tempForm = CFormManager.Forms.Pop();
            tempForm.Show();
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvLogDrawer.RowCount > 0)
                {
                    String logBody = String.Empty;
                    string serialFooter = "";
                    string serialHeader = "";

                    CCommonConstants oConstant = ConfigManager.GetConfig<CCommonConstants>();

                    logBody += "\r\n\r\n\tLog Register";
                    logBody += "\r\n--------------------------------------";
                    logBody += "\r\nTID OID  UID    Date & Time   Activity";
                    logBody += "\r\n--------------------------------------";


                    for (int rowIndex = 0; rowIndex < dgvLogDrawer.Rows.Count; rowIndex++)
                    {
                        logBody += "\r\n\r " + dgvLogDrawer[0, rowIndex].Value.ToString();
                        logBody += " " + dgvLogDrawer[1, rowIndex].Value.ToString();
                        logBody += " " + dgvLogDrawer[2, rowIndex].Value.ToString();
                        logBody += "  " + Convert.ToDateTime(dgvLogDrawer[3, rowIndex].Value).ToString("dd/MM/yy hh:mmtt");
                        logBody += " Open";
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
    }
}