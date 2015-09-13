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
using Managers.Customer;
using Managers.Category;
using Managers.Deposit;
using System.IO;
using RMSUI;



namespace RMS.SystemManagement
{
    public partial class CViewReportForm : BaseForm
    {
        public DateTime tempCurrentDate;
        public int tempViewType;

        public CViewReportForm()
        {
            InitializeComponent();
            this.myCalendar.DateSelected += new DateRangeEventHandler(this.myCalendar_DateSelected);
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
            try
            {
                if (tempCurrentDate.Date.CompareTo(DateTime.Today.Date) != 0) tempCurrentDate = new DateTime(tempCurrentDate.Year, tempCurrentDate.Month, tempCurrentDate.Day, 8, 0, 0);
                else if (tempCurrentDate.Date.CompareTo(DateTime.Today.Date) == 0) tempCurrentDate = DateTime.Now;

                CPaymentSummaryManager tempSummaryByOrderManager = new CPaymentSummaryManager();
                List<CPaymentSummaryByOrder> tempSummaryByOrder = (List<CPaymentSummaryByOrder>)tempSummaryByOrderManager.GetTotalPaymentSummaryForViewReport(tempCurrentDate).Data;
                ViewReportDataGridView.Rows.Clear();

                if (tempSummaryByOrder != null)
                {
                    PopulateViewReportDataGridView(tempSummaryByOrder);
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public void PopulateViewReportDataGridView(List<CPaymentSummaryByOrder> inSummaryByOrder)
        {
            try
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
                   

                    String[] tempString ={ tempPaymentSummaryByOrder[orderIndex].OrderID.ToString(), sl.ToString(), tempPaymentSummaryByOrder[orderIndex].OrderType, tempPaymentSummaryByOrder[orderIndex].TableNumber.ToString(), tempPayString, (tempPaymentSummaryByOrder[orderIndex].TotalPayment+tempPaymentSummaryByOrder[orderIndex].TotalServicePayment).ToString("F02") };

                    ViewReportDataGridView.Rows.Add(tempString);
                }

                
                for (int rowCounter = 0; rowCounter < ViewReportDataGridView.RowCount; rowCounter++)
                {
                    if (tempViewType == 0) ViewReportDataGridView.Rows[rowCounter].Visible = true;
                    else if (tempViewType == 1 && !tempPaymentSummaryByOrder[rowCounter].OrderType.Equals("Table")) ViewReportDataGridView.Rows[rowCounter].Visible = false;
                    else if (tempViewType == 2 && !tempPaymentSummaryByOrder[rowCounter].OrderType.Equals("TakeAway")) ViewReportDataGridView.Rows[rowCounter].Visible = false;
                    else if (tempViewType == 3 && !tempPaymentSummaryByOrder[rowCounter].OrderType.Equals("Tabs")) ViewReportDataGridView.Rows[rowCounter].Visible = false;
                }

                if (ViewReportDataGridView.RowCount < 19)
                {
                    ViewReportDataGridView.RowCount = 19;
                }
                FillLabels();
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public void FillLabels()
        {
            CashLabel.Text = "0.000";
            EFTLabel.Text = "0.000";
            ChequeLabel.Text = "0.000";
            VoucherLabel.Text = "0.000";
            DiscountLabel.Text = "0.000";
            DepositeLabel.Text = "0.000";
            lblNetSaleValue.Text = "0.000";
            lblServiceCharge.Text = "0.000";

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
                //tempPayamentSummary = (CPaymentSummary)tempResult.Data;
            }
           
            if (tempPayamentSummary != null)
            {
                CashLabel.Text = (tempPayamentSummary.TotalCashPayment - tempPayamentSummary.ServiceChargeCash).ToString("F02");
                EFTLabel.Text = (tempPayamentSummary.TotalEFTPayment - tempPayamentSummary.ServiceChargeEft).ToString("F02");
                ChequeLabel.Text = (tempPayamentSummary.TotalChequePayment - tempPayamentSummary.ServiceChargeCheque).ToString("F02");
                AccLabel.Text = (tempPayamentSummary.TotalAccPayment - tempPayamentSummary.ServiceChargeAcc).ToString("F02");

                VoucherLabel.Text = tempPayamentSummary.TotalVoucherPayment.ToString("F02");
                DiscountLabel.Text = tempPayamentSummary.TotalDiscount.ToString("F02");
                DepositeLabel.Text = tempPayamentSummary.TotalDepositePayment.ToString("F02");

                
                lblServiceCharge.Text=tempPayamentSummary.TotalServicePayment.ToString("F02");

                lblGrossValue.Text = (tempPayamentSummary.TotalPayment + tempPayamentSummary.TotalServicePayment + tempPayamentSummary.TotalDiscount + tempPayamentSummary.TotalVoucherPayment).ToString("F02");
                lblNetSaleValue.Text = ((tempPayamentSummary.TotalPayment + tempPayamentSummary.TotalServicePayment + tempPayamentSummary.TotalDiscount + tempPayamentSummary.TotalVoucherPayment ) - tempPayamentSummary.TotalDiscount - tempPayamentSummary.TotalVoucherPayment - tempPayamentSummary.TotalServicePayment).ToString("F02");  

                lblCashService.Text = tempPayamentSummary.ServiceChargeCash.ToString("F02");
                lblChequeService.Text = tempPayamentSummary.ServiceChargeCheque.ToString("F02");
                lblEftService.Text = tempPayamentSummary.ServiceChargeEft.ToString("F02");
                lblServiceAcc.Text = tempPayamentSummary.ServiceChargeAcc.ToString("F02");
                lblServiceVoucher.Text = tempPayamentSummary.ServiceChargeVoucher.ToString("F02");
            }
        }


        private void PrintSummaryButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (tempCurrentDate.Date.CompareTo(DateTime.Today.Date) != 0) tempCurrentDate = new DateTime(tempCurrentDate.Year, tempCurrentDate.Month, tempCurrentDate.Day, 8, 0, 0);
                else if (tempCurrentDate.Date.CompareTo(DateTime.Today.Date) == 0) tempCurrentDate = DateTime.Now;

                CPaymentSummaryManager tempPaymentSummaryManager = new CPaymentSummaryManager();
                CPaymentSummary tempPayamentSummary = new CPaymentSummary();
                tempPayamentSummary = (CPaymentSummary)tempPaymentSummaryManager.GetTotalPaymentSummary(tempCurrentDate).Data;

                CPrintMethods tempPrintMethods = new CPrintMethods();

                string serialHeader = "";
                string serialFooter = "";

                string serialBody = "";
                serialBody += "            Payment Summary Report";
                String DateString = "Billing Date: " + tempCurrentDate.ToLongDateString();
                serialBody += "\r\n".PadRight((int)(45 - DateString.Length) / 2) + DateString + "\r\n\r\n";

                if (tempPayamentSummary != null)
                {
                    serialBody += "Payable Summary:";
                    serialBody += "\r\n----------------------------------------";
                    serialBody += "\r\nGross Sale:" + (tempPayamentSummary.TotalPayment + tempPayamentSummary.TotalServicePayment + tempPayamentSummary.TotalDiscount + tempPayamentSummary.TotalVoucherPayment - tempPayamentSummary.ServiceChargeVoucher).ToString("F02");
                    serialBody += "\r\nNet Sale:" + (Convert.ToDouble(lblGrossValue.Text) - tempPayamentSummary.TotalDiscount - tempPayamentSummary.TotalVoucherPayment - tempPayamentSummary.TotalServicePayment + tempPayamentSummary.ServiceChargeVoucher).ToString("F02");

                    serialBody += "\r\n----------------------------------------";
                    serialBody += "\r\nNet Sales Breakdown:";
                    serialBody += "\r\n----------------------------------------";
                    serialBody += "\r\nTotal Cash: " + (tempPayamentSummary.TotalCashPayment-tempPayamentSummary.ServiceChargeCash).ToString("F02");
                    serialBody += "\r\n EFT: " + (tempPayamentSummary.TotalEFTPayment-tempPayamentSummary.ServiceChargeEft).ToString("F02");
                    serialBody += "\r\n Cheque: " + (tempPayamentSummary.TotalChequePayment-tempPayamentSummary.ServiceChargeCheque).ToString("F02");
                    serialBody += "\r\n Account: " + (tempPayamentSummary.TotalAccPayment - tempPayamentSummary.ServiceChargeAcc).ToString("F02");

                    serialBody += "\r\n----------------------------------------";
                    serialBody += "\r\nPromotions and Discounts:";
                    serialBody += "\r\n----------------------------------------";
                    serialBody += "\r\n Voucher: " + tempPayamentSummary.TotalVoucherPayment.ToString("F02");
                    serialBody += "\r\n Discount: " + tempPayamentSummary.TotalDiscount.ToString("F02");
                    serialBody += "\r\n Service Ch: " + tempPayamentSummary.TotalServicePayment.ToString("F02");
                    serialBody += "\r\n----------------------------------------";

                    serialBody += "\r\nService Charge Breakdown:";
                    serialBody += "\r\n----------------------------------------";
                    serialBody += "\r\n Cash: " + tempPayamentSummary.ServiceChargeCash.ToString("F02");
                    serialBody += "\r\n Cheque: " + tempPayamentSummary.ServiceChargeCheque.ToString("F02");
                    serialBody += "\r\n Voucher: " + tempPayamentSummary.ServiceChargeVoucher.ToString("F02");
                    serialBody += "\r\n Eft: " + tempPayamentSummary.ServiceChargeEft.ToString("F02");
                    serialBody += "\r\n Accounts: " + tempPayamentSummary.ServiceChargeAcc.ToString("F02");
                    serialBody += "\r\n----------------------------------------";
                    serialBody += "\r\n Deposit Used: " + tempPayamentSummary.TotalDepositePayment.ToString("F02");
                }
                serialBody += "\r\n\r\n";
                tempPrintMethods.SerialPrint(PRINTER_TYPES.NORMAL_PRINTER, serialHeader, serialBody, serialFooter, "");

                this.WriteString(serialBody);///Write to a file when print command is executed
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }        

        private void PrintDetailButton_Click(object sender, EventArgs e)
        {
            try
            {
                CPrintMethods tempPrintMethods = new CPrintMethods();
                string serialHeader = "";
                string serialFooter = "";

                string serialBody = "";
                serialBody += "            Payment Detail Report";
                String DateString = "Billing Date: " + tempCurrentDate.ToLongDateString();
                serialBody += "\r\n".PadRight((int)(45 - DateString.Length) / 2) + DateString + "\r\n\r\n";


                if (tempCurrentDate.Date.CompareTo(DateTime.Today.Date) != 0) tempCurrentDate = new DateTime(tempCurrentDate.Year, tempCurrentDate.Month, tempCurrentDate.Day, 8, 0, 0);
                else if (tempCurrentDate.Date.CompareTo(DateTime.Today.Date) == 0) tempCurrentDate = DateTime.Now;

                CPaymentSummaryManager tempSummaryByOrderManager = new CPaymentSummaryManager();
                List<CPaymentSummaryByOrder> tempSummaryByOrder = (List<CPaymentSummaryByOrder>)tempSummaryByOrderManager.GetTotalPaymentSummaryForViewReport(tempCurrentDate).Data;

                CPaymentSummaryByOrder[] tempSummaryByOrderArray = tempSummaryByOrder.ToArray();

                serialBody += "SL  Order     Table   Payment     Total";
                serialBody += "\r\n    Type      Number   Type";
                serialBody += "\r\n--- -------- ---- --------------- ------";
                for (int counter = 0; counter < tempSummaryByOrderArray.Length; counter++)
                {
                    bool tempbool = false;
                    float tempCashPayment = 0;
                    float tempChequePayment = 0;
                    float tempVoucherPayment = 0;
                    float tempDiscount = 0;
                    float tempDepositePayment = 0;
                    float tempEFTPayment = 0;
                    float tempServicePayment = 0;

                    float.TryParse(tempSummaryByOrderArray[counter].TotalCashPayment.ToString(), out tempCashPayment);
                    float.TryParse(tempSummaryByOrderArray[counter].TotalChequePayment.ToString(), out tempChequePayment);
                    float.TryParse(tempSummaryByOrderArray[counter].TotalVoucherPayment.ToString(), out tempVoucherPayment);
                    float.TryParse(tempSummaryByOrderArray[counter].TotalDepositePayment.ToString(), out tempDepositePayment);
                    float.TryParse(tempSummaryByOrderArray[counter].TotalEFTPayment.ToString(), out tempEFTPayment);
                    float.TryParse(tempSummaryByOrderArray[counter].TotalServicePayment.ToString(), out tempServicePayment);
                    float.TryParse(tempSummaryByOrderArray[counter].Discount.ToString(), out tempDiscount);

                    serialBody += "\r\n" + ((int)(counter + 1)).ToString().PadRight(3) + " " + (tempSummaryByOrderArray[counter].OrderType.Trim()).PadRight(8, ' ') + " " + tempSummaryByOrderArray[counter].TableNumber.ToString().PadRight(4, ' ') + " ";// +tempPayString.Trim().PadRight(13, ' ') + "  " + tempSummaryByOrderArray[i].TotalPayment;
                    if (tempCashPayment > 0)
                    {
                        string temp = "Cash:(" + tempCashPayment.ToString("F02") + ")";
                        if (!tempbool)
                        {
                            serialBody += temp.PadRight(15, ' ') + " " + (tempSummaryByOrderArray[counter].TotalPayment+tempSummaryByOrderArray[counter].TotalServicePayment).ToString("F02") + "\r\n";
                            tempbool = true;
                        }
                        else
                        {
                            serialBody += "                  " + temp.PadRight(15, ' ') + "\r\n";
                        }
                    }
                    if (tempChequePayment > 0)
                    {
                        string temp = "Cheque(" + tempChequePayment.ToString("F02") + ")";
                        if (!tempbool)
                        {
                            serialBody += temp.PadRight(15, ' ') + " " + (tempSummaryByOrderArray[counter].TotalPayment+tempSummaryByOrderArray[counter].TotalServicePayment).ToString("F02") + "\r\n";
                            tempbool = true;
                        }
                        else
                        {
                            serialBody += "                  " + temp.PadRight(15, ' ') + "\r\n";
                        }
                    }
                    if (tempVoucherPayment > 0)
                    {
                        string temp = "Voucher(" + tempVoucherPayment.ToString("F02") + ")";
                        if (!tempbool)
                        {
                            serialBody += temp.PadRight(15, ' ') + " " + (tempSummaryByOrderArray[counter].TotalPayment + tempSummaryByOrderArray[counter].TotalServicePayment).ToString("F02") + "\r\n";
                            tempbool = true;
                        }
                        else
                        {
                            serialBody += "                  " + temp.PadRight(15, ' ') + "\r\n";
                        }
                    }
                    if (tempEFTPayment > 0)
                    {
                        string temp = "EFT(" + tempEFTPayment.ToString("F02") + ")";
                        if (!tempbool)
                        {
                            serialBody += temp.PadRight(15, ' ') + " " + (tempSummaryByOrderArray[counter].TotalPayment + tempSummaryByOrderArray[counter].TotalServicePayment).ToString("F02") + "\r\n";
                            tempbool = true;
                        }
                        else
                        {
                            serialBody += "                  " + temp.PadRight(15, ' ') + "\r\n";
                        }
                    }
                    if (tempServicePayment > 0)
                    {
                        string temp = "Sevice(" + tempServicePayment.ToString("F02") + ")";
                        if (!tempbool)
                        {
                            serialBody += temp.PadRight(15, ' ') + " " + (tempSummaryByOrderArray[counter].TotalPayment + tempSummaryByOrderArray[counter].TotalServicePayment).ToString("F02") + "\r\n";
                            tempbool = true;
                        }
                        else
                        {
                            serialBody += "                  " + temp.PadRight(15, ' ') + "\r\n";
                        }
                    }
                    if (tempDiscount > 0)
                    {
                        string temp = "Discount(" + tempDiscount.ToString("F02") + ")";
                        if (!tempbool)
                        {
                            serialBody += temp.PadRight(15, ' ') + " " + (tempSummaryByOrderArray[counter].TotalPayment + tempSummaryByOrderArray[counter].TotalServicePayment).ToString("F02") + "\r\n";
                            tempbool = true;
                        }
                        else
                        {
                            serialBody += "                  " + temp.PadRight(15, ' ') + "\r\n";
                        }
                    }
                    if (tempDepositePayment > 0)
                    {
                        string temp = "Deposit(" + tempDepositePayment.ToString("F02") + ")";
                        if (!tempbool)
                        {
                            serialBody += temp.PadRight(15, ' ') + " " + (tempSummaryByOrderArray[counter].TotalPayment + tempSummaryByOrderArray[counter].TotalServicePayment).ToString("F02") + "\r\n";
                            tempbool = true;
                        }
                        else
                        {
                            serialBody += "                  " + temp.PadRight(15, ' ') + "\r\n";
                        }
                    }
                }

                CPaymentSummaryManager tempPaymentSummaryManager = new CPaymentSummaryManager();
                CPaymentSummary tempPayamentSummary = new CPaymentSummary();
                tempPayamentSummary = (CPaymentSummary)tempPaymentSummaryManager.GetTotalPaymentSummary(tempCurrentDate).Data;


                if (tempPayamentSummary != null)
                {
                    serialBody += "Payable Summary:";
                    serialBody += "\r\n----------------------------------------";
                    serialBody += "\r\nGross Sale:" + (tempPayamentSummary.TotalPayment + tempPayamentSummary.TotalServicePayment + tempPayamentSummary.TotalDiscount + tempPayamentSummary.TotalVoucherPayment - tempPayamentSummary.ServiceChargeVoucher).ToString("F02");
                    serialBody += "\r\nNet Sale:" + (Convert.ToDouble(lblGrossValue.Text) - tempPayamentSummary.TotalDiscount - tempPayamentSummary.TotalVoucherPayment - tempPayamentSummary.TotalServicePayment + tempPayamentSummary.ServiceChargeVoucher).ToString("F02");

                    serialBody += "\r\n----------------------------------------";
                    serialBody += "\r\nNet Sales Breakdown:";
                    serialBody += "\r\n----------------------------------------";
                    serialBody += "\r\nTotal Cash: " + (tempPayamentSummary.TotalCashPayment-tempPayamentSummary.ServiceChargeCash) .ToString("F02");
                    serialBody += "\r\n EFT: " + (tempPayamentSummary.TotalEFTPayment-tempPayamentSummary.ServiceChargeEft).ToString("F02");
                    serialBody += "\r\n Cheque: " + (tempPayamentSummary.TotalChequePayment-tempPayamentSummary.ServiceChargeCheque).ToString("F02");
                    serialBody += "\r\n Account: " + (tempPayamentSummary.TotalAccPayment - tempPayamentSummary.ServiceChargeAcc).ToString("F02");

                    serialBody += "\r\n----------------------------------------";
                    serialBody += "\r\nPromotions and Discounts:";
                    serialBody += "\r\n----------------------------------------";
                    serialBody += "\r\n Voucher: " + tempPayamentSummary.TotalVoucherPayment.ToString("F02");
                    serialBody += "\r\n Discount: " + tempPayamentSummary.TotalDiscount.ToString("F02");
                    serialBody += "\r\n Service Ch: " + tempPayamentSummary.TotalServicePayment.ToString("F02");
                    serialBody += "\r\n----------------------------------------";

                    serialBody += "\r\nService Charge Breakdown:";
                    serialBody += "\r\n----------------------------------------";
                    serialBody += "\r\n Cash: " + tempPayamentSummary.ServiceChargeCash.ToString("F02");
                    serialBody += "\r\n Cheque: " + tempPayamentSummary.ServiceChargeCheque.ToString("F02");
                    serialBody += "\r\n Voucher: " + tempPayamentSummary.ServiceChargeVoucher.ToString("F02");
                    serialBody += "\r\n Eft: " + tempPayamentSummary.ServiceChargeEft.ToString("F02");
                    serialBody += "\r\n Accounts: " + tempPayamentSummary.ServiceChargeAcc.ToString("F02");
                    serialBody += "\r\n----------------------------------------";
                    serialBody += "\r\n Deposit Used: " + tempPayamentSummary.TotalDepositePayment.ToString("F02");
                    serialBody += "\r\n\r\n";
                } 
                serialBody += "\r\n\r\n";

                tempPrintMethods.SerialPrint(PRINTER_TYPES.NORMAL_PRINTER, serialHeader, serialBody, serialFooter, "");

                this.WriteString(serialBody);///Write to a file when print command is executed
            }
            catch (Exception exp)
            {
                throw exp;
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
            ViewReportDataGridView.RowCount = 19;
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
                    for (int rowCounter = 0; rowCounter < ViewReportDataGridView.RowCount && ViewReportDataGridView.Rows[rowCounter].Cells["OrderIDColumn"].Value != null; rowCounter++)
                    {
                        ViewReportDataGridView.Rows[rowCounter].Visible = true;
                    }
                    FillLabels();
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        private void TableRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                tempViewType = 1;
                if (ViewReportDataGridView != null && ViewReportDataGridView.RowCount != 0 && TableRadioButton.Checked == true)
                {
                    for (int rowCounter = 0; rowCounter < ViewReportDataGridView.RowCount; rowCounter++)
                    {
                        if (ViewReportDataGridView.Rows[rowCounter].Cells["OrderIDColumn"].Value != null && (ViewReportDataGridView.Rows[rowCounter].Cells["OrderTypeColumn"].Value.ToString()).Equals("Table")) ViewReportDataGridView.Rows[rowCounter].Visible = true;
                        else
                        {
                            if (ViewReportDataGridView.Rows[rowCounter].Cells["OrderIDColumn"].Value != null) ViewReportDataGridView.Rows[rowCounter].Visible = false;
                        }
                    }
                    FillLabels();
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        private void TakeAwayRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                tempViewType = 2;
                if (ViewReportDataGridView != null && ViewReportDataGridView.RowCount != 0 && TakeAwayRadioButton.Checked == true)
                {
                    for (int rowCounter = 0; rowCounter < ViewReportDataGridView.RowCount; rowCounter++)
                    {
                        if (ViewReportDataGridView.Rows[rowCounter].Cells["OrderIDColumn"].Value != null && (ViewReportDataGridView.Rows[rowCounter].Cells["OrderTypeColumn"].Value.ToString()).Equals("TakeAway")) ViewReportDataGridView.Rows[rowCounter].Visible = true;
                        else
                        {
                            if (ViewReportDataGridView.Rows[rowCounter].Cells["OrderIDColumn"].Value != null) ViewReportDataGridView.Rows[rowCounter].Visible = false;
                        }
                    }
                    FillLabels();
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        private void TabsRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                tempViewType = 3;
                if (ViewReportDataGridView != null && ViewReportDataGridView.RowCount != 0 && TabsRadioButton.Checked == true)
                {
                    for (int rowCounter = 0; rowCounter < ViewReportDataGridView.RowCount; rowCounter++)
                    {
                        if (ViewReportDataGridView.Rows[rowCounter].Cells["OrderIDColumn"].Value != null && (ViewReportDataGridView.Rows[rowCounter].Cells["OrderTypeColumn"].Value.ToString()).Equals("Tabs")) ViewReportDataGridView.Rows[rowCounter].Visible = true;
                        else
                        {
                            if (ViewReportDataGridView.Rows[rowCounter].Cells["OrderIDColumn"].Value != null) ViewReportDataGridView.Rows[rowCounter].Visible = false;
                        }
                    }
                    FillLabels();
                }
            }
            catch (Exception ex)
            {
            }
        }        

        private void myCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            tempCurrentDate = e.Start;
            this.DateLabel.Text = tempCurrentDate.ToString("d/MM/yyyy");
        }

        private void ReprintButton_Click(object sender, EventArgs e)
        {
            try
            {
                int tempRowIndex = 0;
                bool tempFlag = false;
                for (int rowCounter = 0; rowCounter < ViewReportDataGridView.RowCount; rowCounter++)
                {
                    if (ViewReportDataGridView.Rows[rowCounter].Selected == true && ViewReportDataGridView.Rows[rowCounter].Cells["OrderIDColumn"].Value != null)
                    {
                        tempRowIndex = rowCounter;
                        tempFlag = true;
                        break;
                    }
                }

                if (tempFlag)
                {                    
                    CPrintMethods tempPrintMethods = new CPrintMethods();

                    Int64 orderID = 0;
                    Int64.TryParse(ViewReportDataGridView.Rows[tempRowIndex].Cells["OrderIDColumn"].Value.ToString(), out orderID);                   
                    COrderManager tempOrderManager = new COrderManager();
                    COrderInfoArchive tempOrderInfo = (COrderInfoArchive)tempOrderManager.OrderInfoArchiveByOrderID(orderID).Data;

                    //serial print                     
                    //string serialHeader = "IBACS RMS";
                    string serialHeader = "";
                    string serialFooter = "";
                    List<CSerialPrintContent> serialBody = new List<CSerialPrintContent>();
                    CSerialPrintContent tempSerialPrintContent = new CSerialPrintContent();
                    tempSerialPrintContent.StringLine = "               Guest Bill\n";
                    serialBody.Add(tempSerialPrintContent);

                    tempSerialPrintContent = new CSerialPrintContent();                  
                    tempSerialPrintContent.StringLine = "Reprint Date: " + System.DateTime.Now.ToLongDateString() + "\n";
                    serialBody.Add(tempSerialPrintContent);

                    tempSerialPrintContent = new CSerialPrintContent();
                    tempSerialPrintContent.StringLine = "Billing Date: " +  tempCurrentDate.ToLongDateString() + "\n";
                    serialBody.Add(tempSerialPrintContent);


                    if (tempOrderInfo.OrderType.Equals("Table"))
                    {
                        tempSerialPrintContent = new CSerialPrintContent();
                        tempSerialPrintContent.StringLine = "            Table Number: " + tempOrderInfo.TableNumber + "\n";
                        tempSerialPrintContent.Bold = true;
                        serialBody.Add(tempSerialPrintContent);


                        tempSerialPrintContent = new CSerialPrintContent();
                        tempSerialPrintContent.StringLine = "                  Covers: " + tempOrderInfo.GuestCount + "\n";
                        tempSerialPrintContent.Bold = true;
                        serialBody.Add(tempSerialPrintContent);
                    }
                    else if (tempOrderInfo.OrderType.Equals("TakeAway"))
                    {

                        tempSerialPrintContent = new CSerialPrintContent();
                        tempSerialPrintContent.StringLine = "Take Away ";
                        serialBody.Add(tempSerialPrintContent);
                        tempSerialPrintContent = new CSerialPrintContent();
                        tempSerialPrintContent.StringLine = "Type: " + tempOrderInfo.Status;
                        serialBody.Add(tempSerialPrintContent);

                        CCustomerManager tempCustomerManager = new CCustomerManager();
                        CCustomerInfo tempCustomerInfo = (CCustomerInfo)tempCustomerManager.CustomerInfoGetByCustomerID(tempOrderInfo.CustomerID).Data;

                        tempSerialPrintContent = new CSerialPrintContent();
                        tempSerialPrintContent.StringLine = "Customer Name: " + tempCustomerInfo.CustomerName;
                        serialBody.Add(tempSerialPrintContent);
                        if (tempOrderInfo.Status.Equals("Delivery"))
                        {
                            tempSerialPrintContent = new CSerialPrintContent();
                            tempSerialPrintContent.StringLine = "Address:";
                            serialBody.Add(tempSerialPrintContent);

                            tempSerialPrintContent = new CSerialPrintContent();
                            tempSerialPrintContent.StringLine = "----------------------------------------";
                            serialBody.Add(tempSerialPrintContent);

                            if (tempCustomerInfo.FloorAptNumber.Length > 0)
                            {
                                tempSerialPrintContent = new CSerialPrintContent();
                                tempSerialPrintContent.StringLine = "Floor or Apartment:" + tempCustomerInfo.FloorAptNumber;
                                serialBody.Add(tempSerialPrintContent);
                            }

                            if (tempCustomerInfo.BuildingName.Length > 0)
                            {
                                tempSerialPrintContent = new CSerialPrintContent();
                                tempSerialPrintContent.StringLine = "Building Name:" + tempCustomerInfo.BuildingName;
                                serialBody.Add(tempSerialPrintContent);
                            }

                            if (tempCustomerInfo.HouseNumber.Length > 0)
                            {
                                tempSerialPrintContent = new CSerialPrintContent();
                                tempSerialPrintContent.StringLine = "House Number:" + tempCustomerInfo.HouseNumber;
                                serialBody.Add(tempSerialPrintContent);
                            }

                            string[] street = new string[0];
                            street = tempCustomerInfo.StreetName.Split('-');

                            if (street.Length > 1)
                            {
                                if (street[0].ToString().Length > 0)
                                {
                                    tempSerialPrintContent = new CSerialPrintContent();
                                    tempSerialPrintContent.StringLine = "Street:" + street[0].ToString();
                                    serialBody.Add(tempSerialPrintContent);
                                }

                                if (street[1].ToString().Length > 0)
                                {
                                    tempSerialPrintContent = new CSerialPrintContent();
                                    tempSerialPrintContent.StringLine = street[1].ToString();
                                    serialBody.Add(tempSerialPrintContent);
                                }
                            }
                            else if (street.Length > 0 && street.Length < 2)
                            {
                                if (street[0].ToString().Length > 0)
                                {
                                    tempSerialPrintContent = new CSerialPrintContent();
                                    tempSerialPrintContent.StringLine = "Street:" + street[0].ToString();
                                    serialBody.Add(tempSerialPrintContent);
                                }
                            }

                            if (tempCustomerInfo.CustomerPostalCode.Length > 0)
                            {
                                tempSerialPrintContent = new CSerialPrintContent();
                                tempSerialPrintContent.StringLine = "Postal Code:" + tempCustomerInfo.CustomerPostalCode;
                                serialBody.Add(tempSerialPrintContent);
                            }
                            if (tempCustomerInfo.CustomerTown.Length > 0)
                            {
                                tempSerialPrintContent = new CSerialPrintContent();
                                tempSerialPrintContent.StringLine = "Town:" + tempCustomerInfo.CustomerTown;
                                serialBody.Add(tempSerialPrintContent);
                            }


                            tempSerialPrintContent = new CSerialPrintContent();
                            tempSerialPrintContent.StringLine = "----------------------------------------";
                            serialBody.Add(tempSerialPrintContent);

                            CDelivery objDelivery = new CDelivery();
                            objDelivery.DeliveryOrderID = orderID;
                            CResult objDeliveryInfo = tempOrderManager.GetDeliveryInfo(objDelivery);
                            objDelivery = (CDelivery)objDeliveryInfo.Data;
                            if (objDelivery != null)
                            {
                                tempSerialPrintContent = new CSerialPrintContent();
                                tempSerialPrintContent.StringLine = "\r\nDelivery Time:" + objDelivery.DeliveryTime;
                                serialBody.Add(tempSerialPrintContent);
                            }
                        }
                    }
                    else if (tempOrderInfo.OrderType.Equals("Tabs"))
                    {
                        tempSerialPrintContent = new CSerialPrintContent();
                        tempSerialPrintContent.StringLine = "            Tabs Number: " + tempOrderInfo.TableNumber + "\n";
                        tempSerialPrintContent.Bold = true;
                        serialBody.Add(tempSerialPrintContent);

                        tempSerialPrintContent = new CSerialPrintContent();
                        tempSerialPrintContent.StringLine = "            Guest Number: " + tempOrderInfo.GuestCount + "\n";
                        tempSerialPrintContent.Bold = true;
                        serialBody.Add(tempSerialPrintContent);
                    }
                    

                    tempSerialPrintContent = new CSerialPrintContent();
                    tempSerialPrintContent.StringLine = "Order Information";
                    serialBody.Add(tempSerialPrintContent);
                    tempSerialPrintContent = new CSerialPrintContent();
                    tempSerialPrintContent.StringLine = "----------------------------------------";
                    serialBody.Add(tempSerialPrintContent);
                    tempSerialPrintContent = new CSerialPrintContent();
                    tempSerialPrintContent.StringLine = "Qty Item                         Price  ";
                    serialBody.Add(tempSerialPrintContent);
                    tempSerialPrintContent = new CSerialPrintContent();
                    tempSerialPrintContent.StringLine = "----------------------------------------";
                    serialBody.Add(tempSerialPrintContent);
                    
                    CResult tempResult = new CResult();                 
                    tempResult = tempOrderManager.OrderDetailsArchiveByOrderID(orderID);

                    if (tempResult.IsSuccess)
                    {
                        List<COrderDetails> tempList = new List<COrderDetails>();
                        tempList = (List<COrderDetails>)tempResult.Data;
                        COrderDetails[] tempOrderDetails = tempList.ToArray();

                        for (int recordIndex = 0; recordIndex < tempOrderDetails.Length; recordIndex++)
                        {
                            String tempItemName = String.Empty;
                            if (tempOrderDetails[recordIndex].CategoryLevel == 3)
                            {
                                DataRow[] tempDataRowArr = Program.initDataSet.Tables["Category3"].Select("cat3_id = " + tempOrderDetails[recordIndex].ProductID);
                                tempItemName = tempDataRowArr[0]["cat3_name"].ToString();
                            }
                            else if (tempOrderDetails[recordIndex].CategoryLevel == 4)
                            {
                                DataRow[] tempDataRowArr = Program.initDataSet.Tables["Category4"].Select("cat4_id = " + tempOrderDetails[recordIndex].ProductID);
                                tempItemName = tempDataRowArr[0]["cat4_name"].ToString();
                            }
                          

                            tempSerialPrintContent = new CSerialPrintContent();
                            tempSerialPrintContent.StringLine = tempOrderDetails[recordIndex].OrderQuantity.ToString()+" ";
                            tempSerialPrintContent.StringLine += ProcessItemNameFormat(tempItemName, 38);
                            tempSerialPrintContent.StringLine += "\r\n---------------------------------- " + tempOrderDetails[recordIndex].OrderAmount.ToString("F02");
                            serialBody.Add(tempSerialPrintContent);                            
                        }
                    }
                    
                    tempSerialPrintContent = new CSerialPrintContent();
                    tempSerialPrintContent.StringLine = "----------------------------------------";
                    serialBody.Add(tempSerialPrintContent);
                    tempSerialPrintContent = new CSerialPrintContent();
                    tempSerialPrintContent.StringLine = "                      Order Total: " + ViewReportDataGridView.Rows[tempRowIndex].Cells["TotalPaymentColumn"].Value.ToString();
                    serialBody.Add(tempSerialPrintContent);

                    tempSerialPrintContent = new CSerialPrintContent();
                    tempSerialPrintContent.StringLine = "----------------------------------------";
                    serialBody.Add(tempSerialPrintContent);
                    tempSerialPrintContent = new CSerialPrintContent();
                    tempSerialPrintContent.StringLine = "\nS/N: " + tempOrderInfo.SerialNo.ToString();
                    serialBody.Add(tempSerialPrintContent);
                    tempPrintMethods.SerialPrint(PRINTER_TYPES.NORMAL_PRINTER, serialHeader, serialBody, serialFooter, tempOrderInfo.SerialNo.ToString());

                    string printingObject = "";
                    for (int arrayIndex = 0; arrayIndex < serialBody.Count; arrayIndex++)
                    {
                        printingObject += serialBody[arrayIndex].StringLine.ToString() + "\r\n";
                    }

                    this.WriteString(printingObject);///Write to a file when print command is executed
                
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        private void WriteString(string s)
        {
            StreamWriter fstr_out;

            // Open the file directly using StreamWriter. 
            try
            {
                fstr_out = new StreamWriter("rms_printedcopy.txt");
            }
            catch (IOException exc)
            {
                Console.WriteLine(exc.Message + "Cannot open file.");
                return;
            }

            try
            {
                fstr_out.Write(s);
            }
            catch (IOException exc)
            {
                Console.WriteLine(exc.Message + "File Error");
                return;
            }
            fstr_out.Close();
        } 


        private string ProcessItemNameFormat(string inItemName, int maxLength)
        {
            if (inItemName.Length <= maxLength)
            {
                return inItemName;
            }
            else
            {
                int lastTokenIndex = inItemName.LastIndexOf(" ");
                string firstLine = inItemName.Substring(0, lastTokenIndex);
                string secondLine = inItemName.Substring(lastTokenIndex + 1);

                return firstLine + "\r\n  " + secondLine;
            }
        }        
    }
}