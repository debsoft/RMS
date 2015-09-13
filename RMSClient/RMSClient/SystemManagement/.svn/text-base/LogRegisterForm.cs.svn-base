using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RMS.Common;
using Managers.TableInfo;
using Managers.Payment;
using RMS.Common.ObjectModel;
using RmsRemote;
using RMSUI;


namespace RMS.SystemManagement
{
    public partial class LogRegisterForm : BaseForm
    {
        #region "Initialization Area"

        public LogRegisterForm()
        {
            InitializeComponent();
        }

        #endregion

        #region "Manupulation Area"

        #endregion

        #region "UI Events"

        private void BackButton_Click(object sender, EventArgs e)
        {
            Form tempForm = CFormManager.Forms.Pop();
            tempForm.Show();
            this.Close();
        }


        /// <summary>
        /// Print orders Log
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrintOrders_Click(object sender, EventArgs e)
         {
             Int64 startTime = 0;
             Int64 endTime = 0;

             CPrintMethods tempPrintMethods = new CPrintMethods();
             CCommonConstants oConstant = ConfigManager.GetConfig<CCommonConstants>();

             //Set Start of the day
             DateTime dtStart = new DateTime(dtpOrders.Value.Year, dtpOrders.Value.Month, dtpOrders.Value.Day, 0, 0, 0);

             //Set End of the day
             DateTime dtEnd = new DateTime(dtpOrders.Value.Year, dtpOrders.Value.Month, dtpOrders.Value.Day, 23, 59, 59);
             startTime = dtStart.Ticks;
             endTime = dtEnd.Ticks;

             COrderManager objOrderManager = new COrderManager();
             CResult objResult = null;
             objResult = objOrderManager.GetOrderdetails(startTime, endTime);

             
                 ViewOrderLogForm objViewLog = ViewOrderLogForm.CreateInstance();
                 objViewLog.objResult = objResult;
                 objViewLog.Show();
                 CFormManager.Forms.Push(this);
                 this.Hide();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {

            Int64 startTime = 0;
            Int64 endTime = 0;

            CPrintMethods tempPrintMethods = new CPrintMethods();
            CCommonConstants oConstant = ConfigManager.GetConfig<CCommonConstants>();

            //Set Start of the day
            DateTime dtStart = new DateTime(dtpOrders.Value.Year, dtpOrders.Value.Month, dtpOrders.Value.Day, 0, 0, 0);

            //Set End of the day
            DateTime dtEnd = new DateTime(dtpOrders.Value.Year, dtpOrders.Value.Month, dtpOrders.Value.Day, 23, 59, 59);
            startTime = dtStart.Ticks;
            endTime = dtEnd.Ticks;

            CPaymentManager objPaymentManager = new CPaymentManager();
            CResult objResult = null;
            objResult = objPaymentManager.GetPaymentLogDetails(startTime, endTime);
            ViewLogRecordsForm objViewLog = ViewLogRecordsForm.CreateInstance();
            objViewLog.objResult = objResult;
            objViewLog.Show();
            CFormManager.Forms.Push(this);
            this.Hide();
        }

        private void btnDrawerOpen_Click(object sender, EventArgs e)
        {

            Int64 startTime = 0;
            Int64 endTime = 0;

            CPrintMethods tempPrintMethods = new CPrintMethods();
            CCommonConstants oConstant = ConfigManager.GetConfig<CCommonConstants>();

            //Set Start of the day
            DateTime dtStart = new DateTime(dtpOrders.Value.Year, dtpOrders.Value.Month, dtpOrders.Value.Day, 0, 0, 0);

            //Set End of the day
            DateTime dtEnd = new DateTime(dtpOrders.Value.Year, dtpOrders.Value.Month, dtpOrders.Value.Day, 23, 59, 59);
            startTime = dtStart.Ticks;
            endTime = dtEnd.Ticks;

            CPaymentManager objPaymentManager = new CPaymentManager();
            CResult objResult = null;
            objResult = objPaymentManager.GetPaymentLogDetails(startTime, endTime);
            ViewDrawerLogForm objViewLog = ViewDrawerLogForm.CreateInstance();
            objViewLog.objResult = objResult;
            objViewLog.Show();
            CFormManager.Forms.Push(this);
            this.Hide();
        }
        

        private void btnCustomerLog_Click(object sender, EventArgs e)
        {
            Int64 startTime = 0;
            Int64 endTime = 0;

            CPrintMethods tempPrintMethods = new CPrintMethods();
            CCommonConstants oConstant = ConfigManager.GetConfig<CCommonConstants>();

            //Set Start of the day
            DateTime dtStart = new DateTime(dtpOrders.Value.Year, dtpOrders.Value.Month, dtpOrders.Value.Day, 0, 0, 0);

            //Set End of the day
            DateTime dtEnd = new DateTime(dtpOrders.Value.Year, dtpOrders.Value.Month, dtpOrders.Value.Day, 23, 59, 59);
            startTime = dtStart.Ticks;
            endTime = dtEnd.Ticks;
            
            CPaymentManager objPaymentManager = new CPaymentManager();
            CResult objResult = null;
            objResult = objPaymentManager.GetDrawerLogDetails(startTime, endTime);
            ViewLogRecordsForm objViewLog = ViewLogRecordsForm.CreateInstance();
            objViewLog.objResult = objResult;
            objViewLog.Show();
            CFormManager.Forms.Push(this);
            this.Hide();
        }

        #endregion

        
    }
}