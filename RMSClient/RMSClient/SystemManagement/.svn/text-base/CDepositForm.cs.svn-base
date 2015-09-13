using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RMS.Common;
using RMS.DataAccess;
using System.Data.SqlClient;
using Managers.Deposit;
using RMS.Common.ObjectModel;
using Managers.Customer;
using RMSUI;

namespace RMS.SystemManagement
{
    public partial class CDepositForm : BaseForm
    {
        public CDepositForm()
        {
            InitializeComponent();
            DepositDataGridView.RowCount = 13;
        }

        private void LoadAllCustomerList()
        {
            try
            {
                string sSql = SqlQueries.GetQuery(Query.CustomerInfoGetAll);
                CCommonConstants oConstants = ConfigManager.GetConfig<CCommonConstants>();
                SqlDataAdapter tempSqlDataAdapter = new SqlDataAdapter(sSql, oConstants.DBConnection);
                DataSet tempCustomerDataSet = new DataSet();
                tempSqlDataAdapter.Fill(tempCustomerDataSet);

                CustomerDataGridView.Rows.Clear();
                for (int rowIndex = 0; rowIndex < tempCustomerDataSet.Tables[0].Rows.Count; rowIndex++)
                {
                    string[] newRow =
                        {
                            tempCustomerDataSet.Tables[0].Rows[rowIndex]["customer_id"].ToString(),
                            tempCustomerDataSet.Tables[0].Rows[rowIndex]["Name"].ToString(),
                            tempCustomerDataSet.Tables[0].Rows[rowIndex]["Phone"].ToString(),
                            tempCustomerDataSet.Tables[0].Rows[rowIndex]["postal_code"].ToString(),
                            tempCustomerDataSet.Tables[0].Rows[rowIndex]["Town"].ToString(),
                            tempCustomerDataSet.Tables[0].Rows[rowIndex]["Country"].ToString()
                        };
                    CustomerDataGridView.Rows.Add(newRow);
                }

                CustomerDataGridView.Update();
                if (CustomerDataGridView.RowCount < 17)
                    CustomerDataGridView.RowCount = 17;
                tempSqlDataAdapter.Dispose();
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        private void CustomerSearchButton_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlCommand=String.Empty;
                CCommonConstants oConstants;
                SqlDataAdapter tempSqlDataAdapter;
                DataSet tempCustomerDataSet;
                CustomerDataGridView.Rows.Clear();
                if (!NameTextBox.Text.Trim().Equals("") && PhoneTextBox.Text.Trim().Equals(""))
                {
                    sqlCommand = String.Format(SqlQueries.GetQuery(Query.CustomerInfoGetByName), NameTextBox.Text.Trim());
                    oConstants = ConfigManager.GetConfig<CCommonConstants>();
                    tempSqlDataAdapter = new SqlDataAdapter(sqlCommand, oConstants.DBConnection);
                    tempCustomerDataSet = new DataSet();
                    tempSqlDataAdapter.Fill(tempCustomerDataSet);


                    for (int recordIndex = 0; recordIndex < tempCustomerDataSet.Tables[0].Rows.Count; recordIndex++)
                    {
                        string[] newRow =
                        {
                            tempCustomerDataSet.Tables[0].Rows[recordIndex]["customer_id"].ToString(),
                            tempCustomerDataSet.Tables[0].Rows[recordIndex]["name"].ToString(),
                            tempCustomerDataSet.Tables[0].Rows[recordIndex]["phone"].ToString(),
                            tempCustomerDataSet.Tables[0].Rows[recordIndex]["postal_code"].ToString(),
                            tempCustomerDataSet.Tables[0].Rows[recordIndex]["town"].ToString(),
                            tempCustomerDataSet.Tables[0].Rows[recordIndex]["country"].ToString()
                        };
                        CustomerDataGridView.Rows.Add(newRow);
                    }
                    tempSqlDataAdapter.Dispose();
                }
                else if (NameTextBox.Text.Trim().Equals("") && !PhoneTextBox.Text.Trim().Equals(""))
                {
                    sqlCommand = String.Format(SqlQueries.GetQuery(Query.CustomerInfoGetByPhone), PhoneTextBox.Text.Trim());
                    oConstants = ConfigManager.GetConfig<CCommonConstants>();
                    tempSqlDataAdapter = new SqlDataAdapter(sqlCommand, oConstants.DBConnection);
                    tempCustomerDataSet = new DataSet();
                    tempSqlDataAdapter.Fill(tempCustomerDataSet);

                    for (int recordIndex = 0; recordIndex < tempCustomerDataSet.Tables[0].Rows.Count; recordIndex++)
                    {
                        string[] newRow =
                        {
                            tempCustomerDataSet.Tables[0].Rows[recordIndex]["customer_id"].ToString(),
                            tempCustomerDataSet.Tables[0].Rows[recordIndex]["name"].ToString(),
                            tempCustomerDataSet.Tables[0].Rows[recordIndex]["phone"].ToString(),
                            tempCustomerDataSet.Tables[0].Rows[recordIndex]["postal_code"].ToString(),
                            tempCustomerDataSet.Tables[0].Rows[recordIndex]["town"].ToString(),
                            tempCustomerDataSet.Tables[0].Rows[recordIndex]["country"].ToString()
                        };
                        CustomerDataGridView.Rows.Add(newRow);
                    }
                    tempSqlDataAdapter.Dispose();
                }
                else if (!NameTextBox.Text.Trim().Equals("") && !PhoneTextBox.Text.Trim().Equals(""))
                {
                    sqlCommand = String.Format(SqlQueries.GetQuery(Query.CustomerInfoGetByNameNPhone), NameTextBox.Text.Trim(), PhoneTextBox.Text.Trim());
                    oConstants = ConfigManager.GetConfig<CCommonConstants>();
                    tempSqlDataAdapter = new SqlDataAdapter(sqlCommand, oConstants.DBConnection);
                    tempCustomerDataSet = new DataSet();
                    tempSqlDataAdapter.Fill(tempCustomerDataSet);

                    for (int recordIndex = 0; recordIndex < tempCustomerDataSet.Tables[0].Rows.Count; recordIndex++)
                    {
                        string[] newRow =
                        {
                            tempCustomerDataSet.Tables[0].Rows[recordIndex]["customer_id"].ToString(),
                            tempCustomerDataSet.Tables[0].Rows[recordIndex]["name"].ToString(),
                            tempCustomerDataSet.Tables[0].Rows[recordIndex]["phone"].ToString(),
                            tempCustomerDataSet.Tables[0].Rows[recordIndex]["postal_code"].ToString(),
                            tempCustomerDataSet.Tables[0].Rows[recordIndex]["town"].ToString(),
                            tempCustomerDataSet.Tables[0].Rows[recordIndex]["country"].ToString()
                        };
                        CustomerDataGridView.Rows.Add(newRow);
                    }
                    tempSqlDataAdapter.Dispose();
                }

                CustomerDataGridView.Update();
                if (CustomerDataGridView.RowCount < 17)
                    CustomerDataGridView.RowCount = 17;

            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        private void ViewAllButton_Click(object sender, EventArgs e)
        {
            this.LoadAllCustomerList();
        }

        private void NewCustomerButton_Click(object sender, EventArgs e)
        {
            CCustomerInfoForm tempCustomerInfoForm= new CCustomerInfoForm("Add",null);
            tempCustomerInfoForm.Show();
            CFormManager.Forms.Push(this);
            this.Hide();
        }

        private void CDepositForm_Activated(object sender, EventArgs e)
        {
            LoadAllCustomerList();
        }

        private void NewDeposit_Click(object sender, EventArgs e)
        {
            Int64 customerID =Int64.Parse(CustomerDataGridView.CurrentRow.Cells[0].Value.ToString());
            CNewDepositForm tempDepositForm = new CNewDepositForm(customerID);
            tempDepositForm.ShowDialog();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Form form = CFormManager.Forms.Pop();
            form.Show();
            this.Close();
        }

        private void ShowDepositButton_Click(object sender, EventArgs e)
        {
            try
            {
                CustomerLabel.Text = "";
                PhoneLabel.Text = "";
                Int64 customerID = 0;
                Int64.TryParse(CustomerDataGridView.CurrentRow.Cells[0].Value.ToString(), out customerID);
                CustomerLabel.Text = CustomerDataGridView.CurrentRow.Cells[1].Value.ToString();
                PhoneLabel.Text = CustomerDataGridView.CurrentRow.Cells[2].Value.ToString();

                CCommonConstants oConstants = ConfigManager.GetConfig<CCommonConstants>();
                string sSql = String.Format(SqlQueries.GetQuery(Query.DepositGetByCustomerID), customerID);
                SqlDataAdapter tempAdapter = new SqlDataAdapter(sSql, oConstants.DBConnection);
                DataSet tempDataSet = new DataSet();
                tempAdapter.Fill(tempDataSet, "CustomerDeposit");

                DepositDataGridView.Rows.Clear();
                for (int recordIndex = 0; recordIndex < tempDataSet.Tables["CustomerDeposit"].Rows.Count; recordIndex++)
                {
                    DataRow tempDataRow = tempDataSet.Tables["CustomerDeposit"].Rows[recordIndex];
                    DateTime depositDate = new DateTime(Int64.Parse(tempDataRow["deposit_time"].ToString()));
                    string[] row ={
                    tempDataRow["deposit_id"].ToString(),
                    depositDate.ToShortDateString(),
                    Double.Parse(tempDataRow["total_amount"].ToString()).ToString("F02"),
                    Double.Parse(tempDataRow["balance"].ToString()).ToString("F02"),
                    tempDataRow["deposit_type"].ToString()
                };

                    DepositDataGridView.Rows.Add(row);
                    DepositDataGridView.Update();
                }
                DepositDataGridView.RowCount = 13;

            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        private void DepositSearchButton_Click(object sender, EventArgs e)
        {
            try
            {
                Int64 tempDepositSerial = Int64.Parse(DepositSerialTextBox.Text.Trim());
                DepositDataGridView.Rows.Clear();
                CDepositManager tempDepositManager = new CDepositManager();
                CDeposit tempDeposit = new CDeposit();
                CResult oResult = tempDepositManager.DepositGetByDepositID(tempDepositSerial);
                if (oResult.IsSuccess && oResult.Data != null)
                {
                    tempDeposit = (CDeposit)oResult.Data;
                }
                if (tempDeposit.DepositBalance != 0)
                {

                    string[] newRow ={
                tempDeposit.DepositID.ToString(),
                new DateTime(tempDeposit.DepositTime).ToShortDateString(),
                tempDeposit.DepositTotalAmount.ToString("F02"),
                tempDeposit.DepositBalance.ToString("F02"),
                tempDeposit.DepositType
                };

                    CCustomerManager tempCustomerManager = new CCustomerManager();
                    CCustomerInfo tempCustomerInfo = new CCustomerInfo();
                    oResult = tempCustomerManager.CustomerInfoGetByCustomerID(tempDeposit.CustomerID);
                    if (oResult.IsSuccess && oResult.Data != null)
                    {
                        tempCustomerInfo = (CCustomerInfo)oResult.Data;
                    }
                    CustomerLabel.Text = tempCustomerInfo.CustomerName;
                    PhoneLabel.Text = tempCustomerInfo.CustomerPhone;

                    DepositDataGridView.Rows.Add(newRow);
                }
                else
                {
                    MessageBox.Show("No deposit information found. This deposit may be already used or never existed.", "Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                DepositDataGridView.RowCount = 13;

            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        private void NameTextBox_Click(object sender, EventArgs e)
        {
            CWinKeyboardForm tempWinKeyboardForm = new CWinKeyboardForm("Customer Name","Enter Name");
            tempWinKeyboardForm.ShowDialog();
            if (CWinKeyboardForm.Content.Equals("Cancel"))
            {
                return;
            }
            NameTextBox.Text = CWinKeyboardForm.Content;
        }

        private void PhoneTextBox_Click(object sender, EventArgs e)
        {
            CWinKeyboardForm tempWinKeyboardForm = new CWinKeyboardForm("Customer Phone Number","Enter Phone Number");
            tempWinKeyboardForm.ShowDialog();
            if (CWinKeyboardForm.Content.Equals("Cancel"))
            {
                return;
            }
            PhoneTextBox.Text = CWinKeyboardForm.Content;
        }

        private void DepositSerialTextBox_Click(object sender, EventArgs e)
        {
            CCalculatorForm tempCalculatorForm = new CCalculatorForm("Deposit Number","Enter deposit number");
            tempCalculatorForm.BackColor = Color.LightGray;
            tempCalculatorForm.InputNameLabel.ForeColor = Color.Black;
            tempCalculatorForm.InputTextBox.BackColor = Color.LightGray;
            tempCalculatorForm.InputTextBox.ForeColor = Color.Black;
            tempCalculatorForm.ShowDialog();

            if (CCalculatorForm.inputResult.Equals("Cancel"))
            {
                return;
            }
            DepositSerialTextBox.Text = CCalculatorForm.inputResult;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}