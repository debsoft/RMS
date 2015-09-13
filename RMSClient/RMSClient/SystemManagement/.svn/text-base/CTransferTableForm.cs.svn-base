using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Managers.TableInfo;
using RMS.Common.ObjectModel;
using RMS.Common;
using System.Data.SqlClient;
using RMS.Common.Config;
using RMSUI;


namespace RMS.SystemManagement
{    
    public partial class CTransferTableForm : BaseForm
    {
        private int[] tempOccupiedTableNumber;
        public CTransferTableForm()
        {
            InitializeComponent();            
        }
                
        private void CTransferTableForm_Load(object sender, EventArgs e)
        {
            try
            {
                COrderManager tempTransferTableManager = new COrderManager();
                List<CTransferOrderShow> tempOrderShowList = new List<CTransferOrderShow>();
                tempOrderShowList = (List<CTransferOrderShow>)tempTransferTableManager.OrderListForTransfer(false).Data;

                if (tempOrderShowList != null) PopulateCurrentTableDataGridView(tempOrderShowList);
                CurrrentTableDataGridView.CellClick += new DataGridViewCellEventHandler(CurrrentTableDataGridView_CellClick);
            }
            catch (Exception ex)
            {
            }
        }

        public void PopulateCurrentTableDataGridView(List<CTransferOrderShow> inOrderShowList)
        {
            try
            {
                CTransferOrderShow[] tempOrderShowArray = inOrderShowList.ToArray();
                CurrrentTableDataGridView.RowCount = tempOrderShowArray.Length;
                CurrrentTableDataGridView.AllowUserToResizeRows = false;
                CurrrentTableDataGridView.Rows.Clear();

                tempOccupiedTableNumber = new int[tempOrderShowArray.Length];

                for (int arrayIndex = 0; arrayIndex < tempOrderShowArray.Length; arrayIndex++)
                {
                    int sl = arrayIndex + 1;
                    String[] tempString ={ tempOrderShowArray[arrayIndex].OrderID.ToString(), tempOrderShowArray[arrayIndex].GuestCount.ToString(), sl.ToString(), tempOrderShowArray[arrayIndex].OrderType, tempOrderShowArray[arrayIndex].TableNumber.ToString(), tempOrderShowArray[arrayIndex].CustomerName, "Transfer" };
                    CurrrentTableDataGridView.Rows.Add(tempString);
                }
                if (CurrrentTableDataGridView.RowCount < 16) CurrrentTableDataGridView.RowCount = 16;
            }
            catch (Exception ex)
            {
            }
        }

        public void CurrrentTableDataGridView_CellClick(object sender,DataGridViewCellEventArgs e)
        {
            try
            {
                if (CurrrentTableDataGridView.Columns[e.ColumnIndex].Name.Equals("ActionButtonColumn") && e.RowIndex >= 0 && CurrrentTableDataGridView.Rows[e.RowIndex].Cells["OrderIDColumn"].Value != null)
                {
                    this.CustomerNameTextBox.Text = CurrrentTableDataGridView.Rows[e.RowIndex].Cells["CustomerNameColumn"].Value.ToString();
                    this.TableNumberTextBox.Text = CurrrentTableDataGridView.Rows[e.RowIndex].Cells["TableNumberColumn"].Value.ToString();
                    String tempOrderID = CurrrentTableDataGridView.Rows[e.RowIndex].Cells["OrderIDColumn"].Value.ToString();
                    int tempOldTableNumber = int.Parse(CurrrentTableDataGridView.Rows[e.RowIndex].Cells["TableNumberColumn"].Value.ToString());
                    int tempOldTableGuestCount = int.Parse(CurrrentTableDataGridView.Rows[e.RowIndex].Cells["GuestCountColumn"].Value.ToString());

                    CCalculatorForm tempCalculator = new CCalculatorForm("Transfer Table", "Enter new Table Number to Transfer");
                    tempCalculator.BackColor = Color.LightGray;
                    tempCalculator.InputNameLabel.ForeColor = Color.Black;
                    tempCalculator.InputTextBox.BackColor = Color.LightGray;
                    tempCalculator.InputTextBox.ForeColor = Color.Black;
                    tempCalculator.ShowDialog();

                    if (CCalculatorForm.inputResult.Equals("Cancel"))
                        return;

                    if (CCalculatorForm.inputResult.Equals("") || Int32.Parse(CCalculatorForm.inputResult) == 0)
                    {
                        MessageBox.Show("Input invalid.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (!CCalculatorForm.inputResult.Equals("Cancel") && !CCalculatorForm.inputResult.Equals(String.Empty))
                    {
                        int tempNewTableNumber = int.Parse(CCalculatorForm.inputResult);

                        COrderManager tempTransferTableManager = new COrderManager();
                        List<CTableInfo> tempAvailableTableList = new List<CTableInfo>();
                        tempAvailableTableList = (List<CTableInfo>)tempTransferTableManager.AvailableTableForTransfer().Data;
                        CTableInfo[] tempAvailableTableArray = tempAvailableTableList.ToArray();

                        bool tempPromptAgainBool = false;
                        CResult tempResult = new CResult();

                        for (int i = 0; i < tempAvailableTableArray.Length; i++)
                        {
                            if (tempNewTableNumber == tempAvailableTableArray[i].TableNumber) tempPromptAgainBool = true;
                        }

                        if (tempPromptAgainBool)
                        {
                            MessageBox.Show("The Table selected is already occupied.\n Please select another table.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        else
                        {
                            tempResult = tempTransferTableManager.UpdateForTransferTable(tempOrderID, tempOldTableNumber, tempNewTableNumber, tempOldTableGuestCount);
                            if (tempResult.IsSuccess)
                            {
                                CurrrentTableDataGridView.Rows[e.RowIndex].Cells["TableNumberColumn"].Value = tempNewTableNumber;
                                TableNumberTextBox.Text = tempNewTableNumber.ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }        

        private void BackButton_Click(object sender, EventArgs e)
        {
            Form tempForm = CFormManager.Forms.Pop();
            tempForm.Show();
            this.Close();
        } 
             
    }
}