using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Managers.TableInfo;
using RMS.Common.ObjectModel;
using Managers.PaymentSummaryManager;
using RMS.Common;
using Managers.Deposit;
using RMSUI;

namespace RMS.SystemManagement
{
    public partial class CReviewTransactionForm : BaseForm
    {
        public DateTime tempCurrentDate;
        public int tempViewType;
        public bool tempSearch;
        public bool m_oViewed;
        public String m_sRef;
        public String m_sPrice;
        public String m_sTable;
        public bool m_bRef;
        public bool m_bPrice;
        public bool m_bTable;       

        public CReviewTransactionForm()
        {
            InitializeComponent();
            this.myCalendar.DateSelected += new DateRangeEventHandler(this.myCalendar_DateSelected);
            tempSearch = false;
            m_oViewed = false;
            m_sRef = "";
            m_sPrice = "";
            m_sTable = "";            
        }
        private void YearMinusButton_Click(object sender, EventArgs e)
        {
            tempCurrentDate = tempCurrentDate.AddYears(-1);
            myCalendar.SetDate(tempCurrentDate);
            myCalendar.Refresh();
            DateLabel.Text = tempCurrentDate.ToString("d/MM/yyyy");
        }
        private void MonthMinusButton_Click(object sender, EventArgs e)
        {
            tempCurrentDate = tempCurrentDate.AddMonths(-1);
            myCalendar.SetDate(tempCurrentDate);
            myCalendar.Refresh();
            DateLabel.Text = tempCurrentDate.ToString("d/MM/yyyy");
        }
        private void MonthPlusButton_Click(object sender, EventArgs e)
        {
            tempCurrentDate = tempCurrentDate.AddMonths(1);
            myCalendar.SetDate(tempCurrentDate);
            myCalendar.Refresh();
            DateLabel.Text = tempCurrentDate.ToString("d/MM/yyyy");
        }
        private void YearPlusButton_Click(object sender, EventArgs e)
        {
            tempCurrentDate = tempCurrentDate.AddYears(1);
            myCalendar.SetDate(tempCurrentDate);
            myCalendar.Refresh();
            DateLabel.Text = tempCurrentDate.ToString("d/MM/yyyy");
        }

        private void ViewButton_Click(object sender, EventArgs e)
        {
            this.PopulateViewReportDataGridView();
        }

        public void PopulateViewReportDataGridView()
        {
            ReferenceTextBox.Clear();
            ReferenceCheckBox.Checked = false;
            PriceTextBox.Clear();
            PriceCheckBox.Checked = false;
            TableNoTextBox.Clear();
            checkBox2.Checked = false;
            try
            {
                if (tempCurrentDate.Date.CompareTo(DateTime.Today.Date) != 0) tempCurrentDate = new DateTime(tempCurrentDate.Year, tempCurrentDate.Month, tempCurrentDate.Day, 8, 0, 0);
                else if (tempCurrentDate.Date.CompareTo(DateTime.Today.Date) == 0) tempCurrentDate = DateTime.Now;

                CPaymentSummaryManager tempSummaryByOrderManager = new CPaymentSummaryManager();
                List<CPaymentSummaryByOrder> inSummaryByOrder = (List<CPaymentSummaryByOrder>)tempSummaryByOrderManager.GetTotalPaymentSummaryForViewReport(tempCurrentDate).Data;
                ViewReportDataGridView.Rows.Clear();

                if (inSummaryByOrder != null)
                {
                    CPaymentSummaryByOrder[] tempPaymentSummaryByOrder = inSummaryByOrder.ToArray();

                    for (int orderIndex = 0; orderIndex < tempPaymentSummaryByOrder.Length; orderIndex++)
                    {
                        int sl = orderIndex + 1;                        
                        String tempPayString = "";
                        if (tempPaymentSummaryByOrder[orderIndex].TotalCashPayment > 0) tempPayString += "CSH(" + tempPaymentSummaryByOrder[orderIndex].TotalCashPayment.ToString("F02") + ") ";
                        if (tempPaymentSummaryByOrder[orderIndex].TotalChequePayment > 0) tempPayString += "CHQ(" + tempPaymentSummaryByOrder[orderIndex].TotalChequePayment.ToString("F02") + ") ";
                        if (tempPaymentSummaryByOrder[orderIndex].TotalVoucherPayment > 0) tempPayString += "VOU(" + tempPaymentSummaryByOrder[orderIndex].TotalVoucherPayment.ToString("F02") + ") ";
                        if (tempPaymentSummaryByOrder[orderIndex].TotalEFTPayment > 0) tempPayString += "EFT(" + tempPaymentSummaryByOrder[orderIndex].TotalEFTPayment.ToString("F02") + ") ";
                        if (tempPaymentSummaryByOrder[orderIndex].TotalAccPayment > 0) tempPayString += "ACC(" + tempPaymentSummaryByOrder[orderIndex].TotalAccPayment.ToString("F02") + ") ";
                        if (tempPaymentSummaryByOrder[orderIndex].TotalServicePayment > 0) tempPayString += "SRV(" + tempPaymentSummaryByOrder[orderIndex].TotalServicePayment.ToString("F02") + ") ";
                        if (tempPaymentSummaryByOrder[orderIndex].Discount > 0) tempPayString += "DIS(" + tempPaymentSummaryByOrder[orderIndex].Discount.ToString("F02") + ") ";
                        if (tempPaymentSummaryByOrder[orderIndex].TotalDepositePayment > 0) tempPayString += "DEP(" + tempPaymentSummaryByOrder[orderIndex].TotalDepositePayment.ToString("F02") + ") ";
                       

                        String[] tempString ={ tempPaymentSummaryByOrder[orderIndex].OrderID.ToString(), sl.ToString(), tempPaymentSummaryByOrder[orderIndex].OrderType, tempPaymentSummaryByOrder[orderIndex].TableNumber.ToString(), tempPayString, (tempPaymentSummaryByOrder[orderIndex].TotalPayment+tempPaymentSummaryByOrder[orderIndex].TotalServicePayment).ToString("F02"), "Void" };

                        ViewReportDataGridView.Rows.Add(tempString);                        
                    }
                    
                    for (int rowIndex = 0; rowIndex < ViewReportDataGridView.RowCount; rowIndex++)
                    {
                        if (tempViewType == 0)
                        {
                            ViewReportDataGridView.Rows[rowIndex].Visible = true;
                        }
                        else if (tempViewType == 1 && !tempPaymentSummaryByOrder[rowIndex].OrderType.Equals("Table"))
                        {
                            ViewReportDataGridView.Rows[rowIndex].Visible = false;
                        }
                        else if (tempViewType == 2 && !tempPaymentSummaryByOrder[rowIndex].OrderType.Equals("TakeAway"))
                        {
                            ViewReportDataGridView.Rows[rowIndex].Visible = false;
                        }
                        else if (tempViewType == 3 && !tempPaymentSummaryByOrder[rowIndex].OrderType.Equals("Tabs"))
                        {
                            ViewReportDataGridView.Rows[rowIndex].Visible = false;
                        }
                        else if (tempViewType == 4 && !tempPaymentSummaryByOrder[rowIndex].OrderType.Equals("Deposit"))
                        {
                            ViewReportDataGridView.Rows[rowIndex].Visible = false;
                        }
                    }

                    m_oViewed = true;
                    tempSearch = false;
                    LabelPayTextLabels("", "", "");
                }
                if (ViewReportDataGridView.RowCount < 15)
                {
                    ViewReportDataGridView.RowCount = 15;
                }
               
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }        

        public void ViewReportDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (ViewReportDataGridView.Columns[e.ColumnIndex].Name == "ActionButtonColumn" && e.RowIndex >= 0 && ViewReportDataGridView.Rows[e.RowIndex].Cells["OrderIDColumn"].Value != null)
                {
                    DialogResult tempDialogResult = MessageBox.Show("Are you sure you want to void this payment?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (tempDialogResult.Equals(DialogResult.No)) return;
                    else
                    {
                        String tempOldOrderID = ViewReportDataGridView.Rows[e.RowIndex].Cells["OrderIDColumn"].Value.ToString();
                        int tempOldTableNumber = int.Parse(ViewReportDataGridView.Rows[e.RowIndex].Cells["TableNumberColumn"].Value.ToString());
                        String tempTableType = ViewReportDataGridView.Rows[e.RowIndex].Cells["OrderTypeColumn"].Value.ToString();

                        COrderManager tempVoidTableManager = new COrderManager();
                        CResult tempResult = tempVoidTableManager.UpdateForVoidTable(tempOldOrderID, tempOldTableNumber, tempTableType, true);
                        if (tempResult.IsSuccess)
                        {
                            if (!tempSearch) this.PopulateViewReportDataGridView();
                            else this.PopulateViewReportDataGridViewBySearch(m_sRef, m_sPrice, m_sTable, m_bRef, m_bPrice, m_bTable);
                        }
                    }
                }
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }

        public void LabelPayTextLabels(string inRefNo, string inPrice, string inTableNo)
        {
            if (!tempSearch && m_oViewed)
            {
                if (tempCurrentDate.Date.CompareTo(DateTime.Today.Date) != 0) tempCurrentDate = new DateTime(tempCurrentDate.Year, tempCurrentDate.Month, tempCurrentDate.Day, 8, 0, 0);
                else if (tempCurrentDate.Date.CompareTo(DateTime.Today.Date) == 0) tempCurrentDate = DateTime.Now;

                CPaymentSummaryManager tempPaymentSummaryManager = new CPaymentSummaryManager();
                CPaymentSummary tempPayamentSummary = new CPaymentSummary();
                
                if (tempViewType == 0)
                {
                    tempPayamentSummary = (CPaymentSummary)tempPaymentSummaryManager.GetTotalPaymentSummary(tempCurrentDate).Data;                    
                }
                else if (tempViewType == 1)
                {
                    tempPayamentSummary = (CPaymentSummary)tempPaymentSummaryManager.GetTotalPaymentSummaryByOrderType(tempCurrentDate, "Table").Data;
                }

                else if (tempViewType == 2)
                {
                    tempPayamentSummary = (CPaymentSummary)tempPaymentSummaryManager.GetTotalPaymentSummaryByOrderType(tempCurrentDate, "TakeAway").Data;
                }

                else if (tempViewType == 3)
                {
                    tempPayamentSummary = (CPaymentSummary)tempPaymentSummaryManager.GetTotalPaymentSummaryByOrderType(tempCurrentDate, "Tabs").Data;
                }
                else if (tempViewType == 4)
                {
                    //tempPayamentSummary = (CPaymentSummary)tempPaymentSummaryManager.GetTotalPaymentSummaryByOrderType(tempCurrentDate, "Tabs").Data;
                    //tempPayamentSummary = (CPaymentSummary)tempResult.Data;
                }
               

                if (tempPayamentSummary != null)
                {
                    if ((tempPayamentSummary.TotalCashPayment - tempPayamentSummary.ServiceChargeCash)>0)
                    {
                    CashLabel.Text = (tempPayamentSummary.TotalCashPayment - tempPayamentSummary.ServiceChargeCash).ToString("F02");
                    }
                    if (tempPayamentSummary.TotalEFTPayment - tempPayamentSummary.ServiceChargeEft > 0)
                    {
                        EFTLabel.Text = (tempPayamentSummary.TotalEFTPayment - tempPayamentSummary.ServiceChargeEft).ToString("F02");
                    }
                    if ((tempPayamentSummary.TotalChequePayment - tempPayamentSummary.ServiceChargeCheque) > 0)
                    {
                        ChequeLabel.Text = (tempPayamentSummary.TotalChequePayment - tempPayamentSummary.ServiceChargeCheque).ToString("F02");
                    }
                    if ((tempPayamentSummary.TotalAccPayment - tempPayamentSummary.ServiceChargeAcc) > 0)
                    {
                        AccLabel.Text = (tempPayamentSummary.TotalAccPayment - tempPayamentSummary.ServiceChargeAcc).ToString("F02");
                    }

                    VoucherLabel.Text = tempPayamentSummary.TotalVoucherPayment.ToString("F02");
                    DiscountLabel.Text = tempPayamentSummary.TotalDiscount.ToString("F02");
                    DepositLabel.Text = tempPayamentSummary.TotalDepositePayment.ToString("F02");
                    TotalPayLabel.Text = tempPayamentSummary.TotalPayment.ToString("F02");
                    lblServiceCharge.Text = tempPayamentSummary.TotalServicePayment.ToString("F02");

                    lblGrossValue.Text = (tempPayamentSummary.TotalPayment + tempPayamentSummary.TotalServicePayment + tempPayamentSummary.TotalDiscount + tempPayamentSummary.TotalVoucherPayment).ToString("F02");
                    lblNetSaleValue.Text = ((tempPayamentSummary.TotalPayment + tempPayamentSummary.TotalServicePayment + tempPayamentSummary.TotalDiscount + tempPayamentSummary.TotalVoucherPayment) - tempPayamentSummary.TotalDiscount - tempPayamentSummary.TotalVoucherPayment - tempPayamentSummary.TotalServicePayment).ToString("F02");  

                    lblCashService.Text = tempPayamentSummary.ServiceChargeCash.ToString("F02");
                    lblChequeService.Text = tempPayamentSummary.ServiceChargeCheque.ToString("F02");
                    lblEftService.Text = tempPayamentSummary.ServiceChargeEft.ToString("F02");
                    lblServiceAcc.Text = tempPayamentSummary.ServiceChargeAcc.ToString("F02");
                    lblServiceVoucher.Text = tempPayamentSummary.ServiceChargeVoucher.ToString("F02");

                }
                else
                {
                    CashLabel.Text = "0.000";
                    EFTLabel.Text = "0.000";
                    ChequeLabel.Text = "0.000";
                    VoucherLabel.Text = "0.000";
                    DiscountLabel.Text = "0.000";
                    DepositLabel.Text = "0.000";
                    TotalPayLabel.Text = "0.000";

                    lblGrossValue.Text = "0.000";
                    lblNetSaleValue.Text = "0.000";

                    lblCashService.Text = "0.000";
                    lblChequeService.Text = "0.000";
                    lblEftService.Text = "0.000";
                    lblServiceAcc.Text = "0.000";
                    lblServiceCharge.Text = "0.000";
                    lblServiceVoucher.Text = "0.000";
                }
            }

            else if (tempSearch)
            {
                float tempCash = 0;
                float tempEFT = 0;
                float tempCheque = 0;
                float tempVoucher = 0;
                float tempDiscount = 0;
                float tempDeposite = 0;
                float tempTotal = 0;
                float tempService = 0;
                float tempAcc = 0;
                

                double tempCashService = 0;
                double tempChequeService = 0;
                double tempEftService = 0;
                double tempVoucherService = 0;
                double tempAccservice = 0;


                if (tempCurrentDate.Date.CompareTo(DateTime.Today.Date) != 0) tempCurrentDate = new DateTime(tempCurrentDate.Year, tempCurrentDate.Month, tempCurrentDate.Day, 8, 0, 0);
                else if (tempCurrentDate.Date.CompareTo(DateTime.Today.Date) == 0) tempCurrentDate = DateTime.Now;

                CPaymentSummaryManager tempSummaryByOrderManager = new CPaymentSummaryManager();
                List<CPaymentSummaryByOrder> inSummaryByOrder = (List<CPaymentSummaryByOrder>)tempSummaryByOrderManager.GetTotalPaymentSummaryForViewReportBySearch(tempCurrentDate, inRefNo, inPrice, inTableNo, m_bRef, m_bPrice, m_bTable).Data;

                if (inSummaryByOrder != null)
                {
                    CPaymentSummaryByOrder[] tempPaymentSummaryByOrder = inSummaryByOrder.ToArray();

                    for (int arrayIndex = 0; arrayIndex < tempPaymentSummaryByOrder.Length; arrayIndex++)
                    {
                        if (tempViewType == 0)
                        {
                            tempCash += tempPaymentSummaryByOrder[arrayIndex].TotalCashPayment;
                            tempCheque += tempPaymentSummaryByOrder[arrayIndex].TotalChequePayment;
                            tempEFT += tempPaymentSummaryByOrder[arrayIndex].TotalEFTPayment;
                            tempVoucher += tempPaymentSummaryByOrder[arrayIndex].TotalVoucherPayment;
                            tempDiscount += tempPaymentSummaryByOrder[arrayIndex].Discount;
                            tempDeposite += tempPaymentSummaryByOrder[arrayIndex].TotalDepositePayment;
                            tempTotal += tempPaymentSummaryByOrder[arrayIndex].TotalPayment;
                            tempService += tempPaymentSummaryByOrder[arrayIndex].TotalServicePayment;
                            tempAcc += tempPaymentSummaryByOrder[arrayIndex].TotalAccPayment;

                            tempCashService += tempPaymentSummaryByOrder[arrayIndex].ServiceChargeCash;
                            tempChequeService += tempPaymentSummaryByOrder[arrayIndex].ServiceChargeCheque;
                            tempEftService += tempPaymentSummaryByOrder[arrayIndex].ServiceChargeEft;
                            tempAccservice += tempPaymentSummaryByOrder[arrayIndex].ServiceChargeAcc;
                            tempVoucherService += tempPaymentSummaryByOrder[arrayIndex].ServiceChargeVoucher;
                        }

                        else if (tempViewType == 1 && tempPaymentSummaryByOrder[arrayIndex].OrderType.Equals("Table"))
                        {
                            tempCash += tempPaymentSummaryByOrder[arrayIndex].TotalCashPayment;
                            tempCheque += tempPaymentSummaryByOrder[arrayIndex].TotalChequePayment;
                            tempEFT += tempPaymentSummaryByOrder[arrayIndex].TotalEFTPayment;
                            tempVoucher += tempPaymentSummaryByOrder[arrayIndex].TotalVoucherPayment;
                            tempDiscount += tempPaymentSummaryByOrder[arrayIndex].Discount;
                            tempDeposite += tempPaymentSummaryByOrder[arrayIndex].TotalDepositePayment;
                            tempTotal += tempPaymentSummaryByOrder[arrayIndex].TotalPayment;
                            tempService += tempPaymentSummaryByOrder[arrayIndex].TotalServicePayment;
                            tempAcc += tempPaymentSummaryByOrder[arrayIndex].TotalAccPayment;

                            tempCashService += tempPaymentSummaryByOrder[arrayIndex].ServiceChargeCash;
                            tempChequeService += tempPaymentSummaryByOrder[arrayIndex].ServiceChargeCheque;
                            tempEftService += tempPaymentSummaryByOrder[arrayIndex].ServiceChargeEft;
                            tempAccservice += tempPaymentSummaryByOrder[arrayIndex].ServiceChargeAcc;
                            tempVoucherService += tempPaymentSummaryByOrder[arrayIndex].ServiceChargeVoucher;
                        }

                        else if (tempViewType == 2 && tempPaymentSummaryByOrder[arrayIndex].OrderType.Equals("TakeAway"))
                        {
                            tempCash += tempPaymentSummaryByOrder[arrayIndex].TotalCashPayment;
                            tempCheque += tempPaymentSummaryByOrder[arrayIndex].TotalChequePayment;
                            tempEFT += tempPaymentSummaryByOrder[arrayIndex].TotalEFTPayment;
                            tempVoucher += tempPaymentSummaryByOrder[arrayIndex].TotalVoucherPayment;
                            tempDiscount += tempPaymentSummaryByOrder[arrayIndex].Discount;
                            tempDeposite += tempPaymentSummaryByOrder[arrayIndex].TotalDepositePayment;
                            tempTotal += tempPaymentSummaryByOrder[arrayIndex].TotalPayment;
                            tempService += tempPaymentSummaryByOrder[arrayIndex].TotalServicePayment;
                            tempAcc += tempPaymentSummaryByOrder[arrayIndex].TotalAccPayment;

                            tempCashService += tempPaymentSummaryByOrder[arrayIndex].ServiceChargeCash;
                            tempChequeService += tempPaymentSummaryByOrder[arrayIndex].ServiceChargeCheque;
                            tempEftService += tempPaymentSummaryByOrder[arrayIndex].ServiceChargeEft;
                            tempAccservice += tempPaymentSummaryByOrder[arrayIndex].ServiceChargeAcc;
                            tempVoucherService += tempPaymentSummaryByOrder[arrayIndex].ServiceChargeVoucher;
                        }

                        else if (tempViewType == 3 && tempPaymentSummaryByOrder[arrayIndex].OrderType.Equals("Tabs"))
                        {
                            tempCash += tempPaymentSummaryByOrder[arrayIndex].TotalCashPayment;
                            tempCheque += tempPaymentSummaryByOrder[arrayIndex].TotalChequePayment;
                            tempEFT += tempPaymentSummaryByOrder[arrayIndex].TotalEFTPayment;
                            tempVoucher += tempPaymentSummaryByOrder[arrayIndex].TotalVoucherPayment;
                            tempDiscount += tempPaymentSummaryByOrder[arrayIndex].Discount;
                            tempDeposite += tempPaymentSummaryByOrder[arrayIndex].TotalDepositePayment;
                            tempTotal += tempPaymentSummaryByOrder[arrayIndex].TotalPayment;
                            tempService += tempPaymentSummaryByOrder[arrayIndex].TotalServicePayment;
                            tempAcc += tempPaymentSummaryByOrder[arrayIndex].TotalAccPayment;

                            tempCashService += tempPaymentSummaryByOrder[arrayIndex].ServiceChargeCash;
                            tempChequeService += tempPaymentSummaryByOrder[arrayIndex].ServiceChargeCheque;
                            tempEftService += tempPaymentSummaryByOrder[arrayIndex].ServiceChargeEft;
                            tempAccservice += tempPaymentSummaryByOrder[arrayIndex].ServiceChargeAcc;
                            tempVoucherService += tempPaymentSummaryByOrder[arrayIndex].ServiceChargeVoucher;
                        }
                        else if (tempViewType == 4 && tempPaymentSummaryByOrder[arrayIndex].OrderType.Equals("Deposit"))
                        {
                            tempCash += tempPaymentSummaryByOrder[arrayIndex].TotalCashPayment;
                            tempCheque += tempPaymentSummaryByOrder[arrayIndex].TotalChequePayment;
                            tempEFT += tempPaymentSummaryByOrder[arrayIndex].TotalEFTPayment;
                            tempVoucher += tempPaymentSummaryByOrder[arrayIndex].TotalVoucherPayment;
                            tempDiscount += tempPaymentSummaryByOrder[arrayIndex].Discount;
                            tempDeposite += tempPaymentSummaryByOrder[arrayIndex].TotalDepositePayment;
                            tempTotal += tempPaymentSummaryByOrder[arrayIndex].TotalPayment;
                            tempService += tempPaymentSummaryByOrder[arrayIndex].TotalServicePayment;
                            tempAcc += tempPaymentSummaryByOrder[arrayIndex].TotalAccPayment;

                            tempCashService += tempPaymentSummaryByOrder[arrayIndex].ServiceChargeCash;
                            tempChequeService += tempPaymentSummaryByOrder[arrayIndex].ServiceChargeCheque;
                            tempEftService += tempPaymentSummaryByOrder[arrayIndex].ServiceChargeEft;
                            tempAccservice += tempPaymentSummaryByOrder[arrayIndex].ServiceChargeAcc;
                            tempVoucherService += tempPaymentSummaryByOrder[arrayIndex].ServiceChargeVoucher;
                        }
                    }

                    CashLabel.Text = (tempCash-tempCashService).ToString("F02");
                    EFTLabel.Text = (tempEFT-tempEftService).ToString("F02");
                    ChequeLabel.Text = (tempCheque-tempChequeService).ToString("F02");
                    AccLabel.Text = (tempAcc - tempAccservice).ToString("F02");

                    VoucherLabel.Text = tempVoucher.ToString("F02");
                    DiscountLabel.Text = tempDiscount.ToString("F02");
                    DepositLabel.Text = tempDeposite.ToString("F02");
                    TotalPayLabel.Text = tempTotal.ToString("F02");

                    lblGrossValue.Text = (tempTotal+tempService+tempDiscount+tempVoucher).ToString("F02");
                    lblNetSaleValue.Text = (tempTotal).ToString("F02");


                    lblCashService.Text = tempCashService.ToString("F02");
                    lblChequeService.Text = tempChequeService.ToString("F02");
                    lblEftService.Text = tempEftService.ToString("F02");
                    lblServiceAcc.Text = tempAccservice.ToString("F02");
                    lblServiceVoucher.Text = tempVoucherService.ToString("F02");
                }
                else
                {
                    CashLabel.Text = "0.000";
                    EFTLabel.Text = "0.000";
                    ChequeLabel.Text = "0.000";
                    VoucherLabel.Text = "0.000";
                    DiscountLabel.Text = "0.000";
                    DepositLabel.Text = "0.000";
                    TotalPayLabel.Text = "0.000";

                    lblGrossValue.Text = "0.000";
                    lblNetSaleValue.Text = "0.000";
                    lblServiceCharge.Text = "0.000";
                    lblCashService.Text = "0.000";
                    lblChequeService.Text = "0.000";
                    lblEftService.Text = "0.000";
                    lblServiceAcc.Text = "0.000";
                    lblServiceVoucher.Text = "0.000";
                }
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Form tempForm = CFormManager.Forms.Pop();
            tempForm.Show();
            this.Close();
        }
        private void CViewReportForm_Load(object sender, EventArgs e)
        {
            tempCurrentDate = DateTime.Today.Date;
            DateLabel.Text = tempCurrentDate.ToString("d/MM/yyyy");
            tempViewType = 0;
            ViewReportDataGridView.RowCount = 15;
            ViewReportDataGridView.CellClick += new DataGridViewCellEventHandler(ViewReportDataGridView_CellClick);

        }
        private void myCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            tempCurrentDate = e.Start;
            this.DateLabel.Text = tempCurrentDate.ToString("d/MM/yyyy");
        }

        private void AllRedioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                tempViewType = 0;
                if (ViewReportDataGridView != null && ViewReportDataGridView.RowCount != 0 && AllRedioButton.Checked == true)
                {
                    for (int rowIndex = 0; rowIndex < ViewReportDataGridView.RowCount && ViewReportDataGridView.Rows[rowIndex].Cells["OrderIDColumn"].Value != null; rowIndex++)
                    {
                        ViewReportDataGridView.Rows[rowIndex].Visible = true;
                    }
                    LabelPayTextLabels(m_sRef, m_sPrice, m_sTable);
                }
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }

        private void TableRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                tempViewType = 1;
                if (ViewReportDataGridView != null && ViewReportDataGridView.RowCount != 0 && TableRadioButton.Checked == true)
                {
                    for (int rowIndex = 0; rowIndex < ViewReportDataGridView.RowCount; rowIndex++)
                    {
                        if (ViewReportDataGridView.Rows[rowIndex].Cells["OrderIDColumn"].Value != null && (ViewReportDataGridView.Rows[rowIndex].Cells["OrderTypeColumn"].Value.ToString()).Equals("Table")) ViewReportDataGridView.Rows[rowIndex].Visible = true;
                        else
                        {
                            if (ViewReportDataGridView.Rows[rowIndex].Cells["OrderIDColumn"].Value != null) ViewReportDataGridView.Rows[rowIndex].Visible = false;
                        }
                    }
                    LabelPayTextLabels(m_sRef, m_sPrice, m_sTable);
                }
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }
        private void TakeAwayRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                tempViewType = 2;
                if (ViewReportDataGridView != null && ViewReportDataGridView.RowCount != 0 && TakeAwayRadioButton.Checked == true)
                {
                    for (int rowIndex = 0; rowIndex < ViewReportDataGridView.RowCount; rowIndex++)
                    {
                        if (ViewReportDataGridView.Rows[rowIndex].Cells["OrderIDColumn"].Value != null && (ViewReportDataGridView.Rows[rowIndex].Cells["OrderTypeColumn"].Value.ToString()).Equals("TakeAway")) ViewReportDataGridView.Rows[rowIndex].Visible = true;
                        else
                        {
                            if (ViewReportDataGridView.Rows[rowIndex].Cells["OrderIDColumn"].Value != null) ViewReportDataGridView.Rows[rowIndex].Visible = false;
                        }
                    }
                    LabelPayTextLabels(m_sRef, m_sPrice, m_sTable);
                }
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }
        private void TabsRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                tempViewType = 3;
                if (ViewReportDataGridView != null && ViewReportDataGridView.RowCount != 0 && TabsRadioButton.Checked == true)
                {
                    for (int rowIndex = 0; rowIndex < ViewReportDataGridView.RowCount; rowIndex++)
                    {
                        if (ViewReportDataGridView.Rows[rowIndex].Cells["OrderIDColumn"].Value != null && (ViewReportDataGridView.Rows[rowIndex].Cells["OrderTypeColumn"].Value.ToString()).Equals("Tabs")) ViewReportDataGridView.Rows[rowIndex].Visible = true;
                        else
                        {
                            if (ViewReportDataGridView.Rows[rowIndex].Cells["OrderIDColumn"].Value != null) ViewReportDataGridView.Rows[rowIndex].Visible = false;
                        }
                    }
                    LabelPayTextLabels(m_sRef, m_sPrice, m_sTable);
                }
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }


        private void myCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            tempCurrentDate = e.Start;
            this.DateLabel.Text = tempCurrentDate.ToString("d/MM/yyyy");
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            string tempRefNo = String.Empty;
            string tempPrice = String.Empty;
            string tempTableNo = String.Empty;

            if (ReferenceCheckBox.Checked) tempRefNo = ReferenceTextBox.Text;
            if (PriceCheckBox.Checked) tempPrice = PriceTextBox.Text;
            if (checkBox2.Checked) tempTableNo = TableNoTextBox.Text;

            m_bRef = ReferenceCheckBox.Checked;
            m_bPrice = PriceCheckBox.Checked;
            m_bTable = checkBox2.Checked;

            if (ReferenceCheckBox.Checked && ReferenceTextBox.Text.Equals(""))
            {
                MessageBox.Show("Please enter a Reference No.");
                return;
            }
            else if (PriceCheckBox.Checked && PriceTextBox.Text.Equals(""))
            {
                MessageBox.Show("Please enter a Price.");
                return;
            }
            else if (checkBox2.Checked && TableNoTextBox.Text.Equals(""))
            {
                MessageBox.Show("Please enter a Table No.");
                return;
            }
            else
            {
                tempSearch = true;
                PopulateViewReportDataGridViewBySearch(tempRefNo, tempPrice, tempTableNo, m_bRef, m_bPrice, m_bTable);
            }
        }

        public void PopulateViewReportDataGridViewBySearch(string inRefNo, string inPrice, string inTableNo, bool inRef, bool inPrc, bool inTable)
        {
            try
            {
                if (tempCurrentDate.Date.CompareTo(DateTime.Today.Date) != 0) tempCurrentDate = new DateTime(tempCurrentDate.Year, tempCurrentDate.Month, tempCurrentDate.Day, 8, 0, 0);
                else if (tempCurrentDate.Date.CompareTo(DateTime.Today.Date) == 0) tempCurrentDate = DateTime.Now;

                CPaymentSummaryManager tempSummaryByOrderManager = new CPaymentSummaryManager();
                List<CPaymentSummaryByOrder> inSummaryByOrder = (List<CPaymentSummaryByOrder>)tempSummaryByOrderManager.GetTotalPaymentSummaryForViewReportBySearch(tempCurrentDate, inRefNo, inPrice, inTableNo, ReferenceCheckBox.Checked, PriceCheckBox.Checked, checkBox2.Checked).Data;
                ViewReportDataGridView.Rows.Clear();

                if (inSummaryByOrder != null)
                {
                    CPaymentSummaryByOrder[] tempPaymentSummaryByOrder = inSummaryByOrder.ToArray();

                    for (int orderIndex = 0; orderIndex < tempPaymentSummaryByOrder.Length; orderIndex++)
                    {
                        int sl = orderIndex + 1;
                        //String tempPayString = "CS(" + tempPaymentSummaryByOrder[i].TotalCashPayment.ToString() + ") CH(" + tempPaymentSummaryByOrder[i].TotalChequePayment.ToString() + ") V(" + tempPaymentSummaryByOrder[i].TotalVoucherPayment.ToString() + ") E(" + tempPaymentSummaryByOrder[i].TotalEFTPayment.ToString() + ") S(" + tempPaymentSummaryByOrder[i].TotalServicePayment.ToString() + ")";
                        String tempPayString = "";
                        if (tempPaymentSummaryByOrder[orderIndex].TotalCashPayment > 0) tempPayString += "CSH(" + tempPaymentSummaryByOrder[orderIndex].TotalCashPayment.ToString("F02") + ") ";
                        if (tempPaymentSummaryByOrder[orderIndex].TotalChequePayment > 0) tempPayString += "CHQ(" + tempPaymentSummaryByOrder[orderIndex].TotalChequePayment.ToString("F02") + ") ";
                        if (tempPaymentSummaryByOrder[orderIndex].TotalVoucherPayment > 0) tempPayString += "VOU(" + tempPaymentSummaryByOrder[orderIndex].TotalVoucherPayment.ToString("F02") + ") ";
                        if (tempPaymentSummaryByOrder[orderIndex].TotalEFTPayment > 0) tempPayString += "EFT(" + tempPaymentSummaryByOrder[orderIndex].TotalEFTPayment.ToString("F02") + ") ";
                        if (tempPaymentSummaryByOrder[orderIndex].TotalServicePayment > 0) tempPayString += "SRV(" + tempPaymentSummaryByOrder[orderIndex].TotalServicePayment.ToString("F02") + ") ";
                        if (tempPaymentSummaryByOrder[orderIndex].Discount > 0) tempPayString += "DIS(" + tempPaymentSummaryByOrder[orderIndex].Discount.ToString("F02") + ") ";
                        if (tempPaymentSummaryByOrder[orderIndex].TotalDepositePayment > 0) tempPayString += "DEP(" + tempPaymentSummaryByOrder[orderIndex].TotalDepositePayment.ToString("F02") + ") ";
                        else ;

                        String[] tempString ={ tempPaymentSummaryByOrder[orderIndex].OrderID.ToString(), sl.ToString(), tempPaymentSummaryByOrder[orderIndex].OrderType, tempPaymentSummaryByOrder[orderIndex].TableNumber.ToString(), tempPayString, tempPaymentSummaryByOrder[orderIndex].TotalPayment.ToString(), "Void" };

                        ViewReportDataGridView.Rows.Add(tempString);
                        if (tempViewType == 0) ViewReportDataGridView.Rows[orderIndex].Visible = true;
                        else if (tempViewType == 1 && !tempPaymentSummaryByOrder[orderIndex].OrderType.Equals("Table")) ViewReportDataGridView.Rows[orderIndex].Visible = false;
                        else if (tempViewType == 2 && !tempPaymentSummaryByOrder[orderIndex].OrderType.Equals("TakeAway")) ViewReportDataGridView.Rows[orderIndex].Visible = false;
                        else if (tempViewType == 3 && !tempPaymentSummaryByOrder[orderIndex].OrderType.Equals("Tabs")) ViewReportDataGridView.Rows[orderIndex].Visible = false;
                        else if (tempViewType == 4 && !tempPaymentSummaryByOrder[orderIndex].OrderType.Equals("Deposit")) ViewReportDataGridView.Rows[orderIndex].Visible = false;
                    }

                    m_sPrice = inPrice;
                    m_sRef = inRefNo;
                    m_sTable = inTableNo;

                    m_bRef = inRef;
                    m_bPrice = inPrc;
                    m_bTable = inTable;

                    LabelPayTextLabels(m_sRef, m_sPrice, m_sTable);
                }
                if (ViewReportDataGridView.RowCount < 15) ViewReportDataGridView.RowCount = 15;
            }
             catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }

        private void ReferenceTextBox_Click(object sender, EventArgs e)
        {
            ReferenceTextBox.Clear();
            ReferenceCheckBox.Checked = false;
            PriceTextBox.Clear();
            PriceCheckBox.Checked = false;
            TableNoTextBox.Clear();
            checkBox2.Checked = false;

            CCalculatorForm tempCalculatorForm = new CCalculatorForm("Reference No for Search", "Enter a Reference No");
            tempCalculatorForm.BackColor = Color.LightGray;
            tempCalculatorForm.InputNameLabel.ForeColor = Color.Black;
            tempCalculatorForm.InputTextBox.BackColor = Color.LightGray;
            tempCalculatorForm.InputTextBox.ForeColor = Color.Black;
            tempCalculatorForm.ShowDialog();

            if (CCalculatorForm.inputResult.Equals("Cancel"))
            {
                ReferenceTextBox.Text = "";
            }
            else
            {
                ReferenceTextBox.Text = CCalculatorForm.inputResult;
            }
        }
        private void PriceTextBox_Click(object sender, EventArgs e)
        {
            ReferenceTextBox.Clear();
            ReferenceCheckBox.Checked = false;
            PriceTextBox.Clear();
            PriceCheckBox.Checked = false;
            TableNoTextBox.Clear();
            checkBox2.Checked = false;

            CPriceCalculatorForm tempCalculatorForm = new CPriceCalculatorForm("Price for Search", "Enter a Price");
            tempCalculatorForm.BackColor = Color.LightGray;
            tempCalculatorForm.InputNameLabel.ForeColor = Color.Black;
            tempCalculatorForm.InputTextBox.BackColor = Color.LightGray;
            tempCalculatorForm.InputTextBox.ForeColor = Color.Black;
            tempCalculatorForm.ShowDialog();

            if (CCalculatorForm.inputResult.Equals("Cancel"))
            {
                PriceTextBox.Text = "";
            }
            else
            {
                PriceTextBox.Text = CCalculatorForm.inputResult;
            }
        }
        private void TableNoTextBox_Click(object sender, EventArgs e)
        {
            ReferenceTextBox.Clear();
            ReferenceCheckBox.Checked = false;
            PriceTextBox.Clear();
            PriceCheckBox.Checked = false;
            TableNoTextBox.Clear();
            checkBox2.Checked = false;

            CCalculatorForm tempCalculatorForm = new CCalculatorForm("Table No for Search", "Enter a Table No");
            tempCalculatorForm.BackColor = Color.LightGray;
            tempCalculatorForm.InputNameLabel.ForeColor = Color.Black;
            tempCalculatorForm.InputTextBox.BackColor = Color.LightGray;
            tempCalculatorForm.InputTextBox.ForeColor = Color.Black;
            tempCalculatorForm.ShowDialog();

            if (CCalculatorForm.inputResult.Equals("Cancel"))
            {
                TableNoTextBox.Text = "";
            }
            else
            {
                TableNoTextBox.Text = CCalculatorForm.inputResult;
            }
        }

        private void ReferenceTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}