using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RMS.Common;
using RMS.Common.ObjectModel;
using Managers.TableInfo;
using Microsoft.Reporting.WinForms;
using RMSUI;

namespace RMS.SystemManagement
{
    public partial class CBookingForm : BaseForm
    {
        public DateTime tempCurrentDate;
        public int tempViewType;
        public bool Updated;

        public CBookingForm()
        {
            InitializeComponent();
            this.myCalendar.DateSelected += new DateRangeEventHandler(this.myCalendar_DateSelected);
            tempCurrentDate = DateTime.Today.Date;
            Updated = false;
        }                                   

        private void BackButton_Click(object sender, EventArgs e)
        {
            Form tempForm = CFormManager.Forms.Pop();
            tempForm.Show();
            this.Close();
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

                COrderManager tempOrderManager = new COrderManager();
                CResult tempResult = tempOrderManager.GetBookingInfoAll(tempCurrentDate);

                if (tempResult.IsSuccess)
                {
                    List<CBooking> tempBookingList = (List<CBooking>)tempResult.Data;
                    viewBookingDataGridView.Rows.Clear();

                    if (tempBookingList != null)
                    {
                        PopulateviewBookingDataGridView(tempBookingList);
                    }
                }
                Updated = true;
            }
            catch(Exception ex)
            {
            }
        } 
        
        public void PopulateviewBookingDataGridView(List<CBooking> inBookingList)
        {
            try
            {
                CBooking[] tempBookingList = inBookingList.ToArray();

                for (int bkListCounter = 0; bkListCounter < tempBookingList.Length; bkListCounter++)
                {
                    int sl = bkListCounter + 1;
                    String[] tempString ={ tempBookingList[bkListCounter].BookingID.ToString(), sl.ToString(), tempBookingList[bkListCounter].CustomerName, tempBookingList[bkListCounter].Phone, tempBookingList[bkListCounter].BookingType, tempBookingList[bkListCounter].GuestCount.ToString(), tempBookingList[bkListCounter].StreetName, tempBookingList[bkListCounter].Comments };

                    viewBookingDataGridView.Rows.Add(tempString);
                    if (tempViewType == 0) viewBookingDataGridView.Rows[bkListCounter].Visible = true;
                    else if (tempViewType == 1 && !tempBookingList[bkListCounter].BookingType.Equals("Provisional")) viewBookingDataGridView.Rows[bkListCounter].Visible = false;
                    else if (tempViewType == 2 && !tempBookingList[bkListCounter].BookingType.Equals("Confirmed")) viewBookingDataGridView.Rows[bkListCounter].Visible = false;
                    else if (tempViewType == 3 && !tempBookingList[bkListCounter].BookingType.Equals("CallBack")) viewBookingDataGridView.Rows[bkListCounter].Visible = false;
                    else if (tempViewType == 4 && !tempBookingList[bkListCounter].BookingType.Equals("Finished")) viewBookingDataGridView.Rows[bkListCounter].Visible = false;
                }
                if (viewBookingDataGridView.RowCount < 19) viewBookingDataGridView.RowCount = 19;
            }
            catch (Exception ex)
            {
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                for (int bkRecordCounter = 0; bkRecordCounter < viewBookingDataGridView.Rows.Count; bkRecordCounter++)
                {
                    if (viewBookingDataGridView.Rows[bkRecordCounter].Selected == true && viewBookingDataGridView.Rows[bkRecordCounter].Cells["BookingIDColumn"].Value != null)
                    {
                        COrderManager tempOrderManager = new COrderManager();
                        Int64 tempBookingID = Int64.Parse(viewBookingDataGridView.Rows[bkRecordCounter].Cells["BookingIDColumn"].Value.ToString());
                        CResult tempResult = tempOrderManager.GetBookingInfoByID(tempBookingID);
                        if (tempResult.IsSuccess)
                        {
                            CBookingInfoForm tempTransferTableForm = new CBookingInfoForm("Update", (CBooking)tempResult.Data);
                            tempTransferTableForm.Show();
                            CFormManager.Forms.Push(this);
                            this.Hide();
                            Updated = true;
                        }
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                for (int bkRecordCounter = 0; bkRecordCounter < viewBookingDataGridView.Rows.Count; bkRecordCounter++)
                {
                    if (viewBookingDataGridView.Rows[bkRecordCounter].Selected == true && viewBookingDataGridView.Rows[bkRecordCounter].Cells["BookingIDColumn"].Value != null)
                    {
                        DialogResult tempDialogResult = MessageBox.Show("Are you sure you want to delete this booking?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (tempDialogResult.Equals(DialogResult.No)) return;
                        else
                        {
                            COrderManager tempOrderManager = new COrderManager();
                            Int64 tempBookingID = Int64.Parse(viewBookingDataGridView.Rows[bkRecordCounter].Cells["BookingIDColumn"].Value.ToString());
                            CResult tempResult = tempOrderManager.deleteBookingInfo(tempBookingID);
                            if (tempResult.IsSuccess)
                            {
                                viewBookingDataGridView.Rows.RemoveAt(bkRecordCounter);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (tempCurrentDate.Date.CompareTo(DateTime.Today.Date) != 0) tempCurrentDate = new DateTime(tempCurrentDate.Year, tempCurrentDate.Month, tempCurrentDate.Day, 8, 0, 0);
                else if (tempCurrentDate.Date.CompareTo(DateTime.Today.Date) == 0) tempCurrentDate = DateTime.Now;

                CBookingInfoForm tempTransferTableForm = new CBookingInfoForm("Add", null);
                tempTransferTableForm.Show();
                CFormManager.Forms.Push(this);
                this.Hide();

                Updated = true;
            }
            catch (Exception ex)
            {
            }
        }
      
        private void myCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            tempCurrentDate = e.Start;
            this.DateLabel.Text = tempCurrentDate.ToString("d/MM/yyyy");
        }

        private void myCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            tempCurrentDate = e.Start;
            this.DateLabel.Text = tempCurrentDate.ToString("d/MM/yyyy");
        }

        private void ProvisionalRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                tempViewType = 1;
                if (viewBookingDataGridView != null && viewBookingDataGridView.RowCount != 0)
                {
                    for (int rowIndex = 0; rowIndex < viewBookingDataGridView.RowCount; rowIndex++)
                    {
                        if (viewBookingDataGridView.Rows[rowIndex].Cells["BookingIDColumn"].Value != null && (viewBookingDataGridView.Rows[rowIndex].Cells["BookingTypeColumn"].Value.ToString()).Equals("Provisional")) viewBookingDataGridView.Rows[rowIndex].Visible = true;
                        else
                        {
                            if (viewBookingDataGridView.Rows[rowIndex].Cells["BookingIDColumn"].Value != null) viewBookingDataGridView.Rows[rowIndex].Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void ConfirmRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                tempViewType = 2;
                if (viewBookingDataGridView != null && viewBookingDataGridView.RowCount != 0)
                {
                    for (int rowCounter = 0; rowCounter < viewBookingDataGridView.RowCount; rowCounter++)
                    {
                        if (viewBookingDataGridView.Rows[rowCounter].Cells["BookingIDColumn"].Value != null && (viewBookingDataGridView.Rows[rowCounter].Cells["BookingTypeColumn"].Value.ToString()).Equals("Confirmed")) viewBookingDataGridView.Rows[rowCounter].Visible = true;
                        else
                        {
                            if (viewBookingDataGridView.Rows[rowCounter].Cells["BookingIDColumn"].Value != null) viewBookingDataGridView.Rows[rowCounter].Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void CallBackRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                tempViewType = 3;
                if (viewBookingDataGridView != null && viewBookingDataGridView.RowCount != 0)
                {
                    for (int rowCounter = 0; rowCounter < viewBookingDataGridView.RowCount; rowCounter++)
                    {
                        if (viewBookingDataGridView.Rows[rowCounter].Cells["BookingIDColumn"].Value != null && (viewBookingDataGridView.Rows[rowCounter].Cells["BookingTypeColumn"].Value.ToString()).Equals("CallBack")) viewBookingDataGridView.Rows[rowCounter].Visible = true;
                        else
                        {
                            if (viewBookingDataGridView.Rows[rowCounter].Cells["BookingIDColumn"].Value != null) viewBookingDataGridView.Rows[rowCounter].Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void AllRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                tempViewType = 0;
                if (viewBookingDataGridView != null && viewBookingDataGridView.RowCount != 0)
                {
                    for (int rowIndex = 0; rowIndex < viewBookingDataGridView.RowCount && viewBookingDataGridView.Rows[rowIndex].Cells["BookingIDColumn"].Value != null; rowIndex++)
                    {
                        viewBookingDataGridView.Rows[rowIndex].Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void FinishRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                tempViewType = 4;
                if (viewBookingDataGridView != null && viewBookingDataGridView.RowCount != 0)
                {
                    for (int rowIndex = 0; rowIndex < viewBookingDataGridView.RowCount; rowIndex++)
                    {
                        if (viewBookingDataGridView.Rows[rowIndex].Cells["BookingIDColumn"].Value != null && (viewBookingDataGridView.Rows[rowIndex].Cells["BookingTypeColumn"].Value.ToString()).Equals("Finished")) viewBookingDataGridView.Rows[rowIndex].Visible = true;
                        else
                        {
                            if (viewBookingDataGridView.Rows[rowIndex].Cells["BookingIDColumn"].Value != null) viewBookingDataGridView.Rows[rowIndex].Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void CBookingForm_Activated(object sender, EventArgs e)
        {
            try
            {
                DateLabel.Text = tempCurrentDate.ToString("d/MM/yyyy");
                viewBookingDataGridView.RowCount = 19;

                if (Updated == true)
                {
                    if (tempCurrentDate.Date.CompareTo(DateTime.Today.Date) != 0) tempCurrentDate = new DateTime(tempCurrentDate.Year, tempCurrentDate.Month, tempCurrentDate.Day, 8, 0, 0);
                    else if (tempCurrentDate.Date.CompareTo(DateTime.Today.Date) == 0) tempCurrentDate = DateTime.Now;

                    COrderManager tempOrderManager = new COrderManager();
                    CResult tempResult = tempOrderManager.GetBookingInfoAll(tempCurrentDate);

                    if (tempResult.IsSuccess)
                    {
                        List<CBooking> tempBookingList = (List<CBooking>)tempResult.Data;
                        viewBookingDataGridView.Rows.Clear();

                        if (tempBookingList != null)
                        {
                            PopulateviewBookingDataGridView(tempBookingList);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }        
        
    }
}