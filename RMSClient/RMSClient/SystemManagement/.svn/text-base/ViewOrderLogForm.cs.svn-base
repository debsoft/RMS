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
    public partial class ViewOrderLogForm : BaseForm
    {
        public static ViewOrderLogForm objOrderLog;
        public CResult objResult = null;

        public ViewOrderLogForm()
        {
            InitializeComponent();
        }

        public static ViewOrderLogForm CreateInstance()
        {
            if (objOrderLog == null)
            {
                objOrderLog = new ViewOrderLogForm();
            }
            return objOrderLog;
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
                if (dgvLogRecords.RowCount > 0)
                {
                    String logBody = String.Empty;
                    string serialFooter = "";
                    string serialHeader = "";

                    CCommonConstants oConstant = ConfigManager.GetConfig<CCommonConstants>();

                    logBody += "\r\n\r\n\t\tLog Register";
                    logBody += "\r\n----------------------------------------";
                    logBody += "\r\nTID OID  UID    Date & Time     Activity";
                    logBody += "\r\n----------------------------------------";
                    string orderType = "";

                    for (int rowIndex = 0; rowIndex < dgvLogRecords.Rows.Count; rowIndex++)
                    {
                        logBody += "\r\n\r " + dgvLogRecords[0, rowIndex].Value.ToString();
                        logBody += " " + dgvLogRecords[1, rowIndex].Value.ToString();
                        logBody += " " + dgvLogRecords[2, rowIndex].Value.ToString();
                        logBody += "  " + Convert.ToDateTime(dgvLogRecords[3, rowIndex].Value).ToString("dd/MM/yy hh:mmtt");

                        if (dgvLogRecords[4, rowIndex].Value.ToString().Replace(" ", "").ToUpper() == "table".Replace(" ", "").ToUpper())
                        {
                            orderType = "TB";
                        }
                        else if (dgvLogRecords[4, rowIndex].Value.ToString().Replace(" ", "").ToUpper() == "Delivery".Replace(" ", "").ToUpper())
                        {
                            orderType = "DL";
                        }
                        else if (dgvLogRecords[4, rowIndex].Value.ToString().Replace(" ", "").ToUpper() == "takeaway".Replace(" ", "").ToUpper())
                        {
                            orderType = "TK";
                        }
                        else if (dgvLogRecords[4, rowIndex].Value.ToString().Replace(" ", "").ToUpper() == "tabs".Replace(" ", "").ToUpper())
                        {
                            orderType = "BR";
                        }
                        logBody += "  " + orderType;

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
                Console.Write(exp.Message);
            }
        }

        private void ViewOrderLogForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            objOrderLog = null;
        }

        private void ViewOrderLogForm_Activated(object sender, EventArgs e)
        {
            List<COrderInfoArchive> tempOrderDetailsList = new List<COrderInfoArchive>();
            if (objResult != null)
            {
              tempOrderDetailsList = (List<COrderInfoArchive>)objResult.Data;
           
                dgvLogRecords.RowCount = 0;
                if (tempOrderDetailsList!=null)
                {
                    for (int index = 0; index < tempOrderDetailsList.Count; index++)
                    {
                        DataGridViewRowCollection dgvRow = (DataGridViewRowCollection)dgvLogRecords.Rows;
                        dgvRow.Add(tempOrderDetailsList[index].TerminalID,tempOrderDetailsList[index].OrderID, tempOrderDetailsList[index].UserName, Convert.ToDateTime(tempOrderDetailsList[index].OrderTime).ToString("dd/MM/yy hh:mm tt"), tempOrderDetailsList[index].OrderType);
                    }
                }
            }
        }
    }
}