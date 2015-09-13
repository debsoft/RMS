using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RMS.Common.ObjectModel;
using Managers.TableInfo;
using RMS.Common;
using RMSUI;

namespace RMS.SystemManagement
{
    public partial class CUnlockTableForm : Form
    {
        public CUnlockTableForm()
        {
            InitializeComponent();           
        }

        private void button1_Click(object sender, EventArgs e)
        {
          //  Form tempForm = CFormManager.Forms.Pop();
           // tempForm.Show();
           // this.Close();
        }        

        private void CUnlockTableForm_Load(object sender, EventArgs e)
        {                        
            PopulateUnlockTableDataGridView();
            UnlockTableDataGridView.CellClick += new DataGridViewCellEventHandler(UnlockTableDataGridView_CellClick);
        }

        public void PopulateUnlockTableDataGridView()
        {
            try
            {
                COrderManager tempUnlockTableManager = new COrderManager();
                List<CTransferOrderShow> tempOrderShowList = new List<CTransferOrderShow>();
                tempOrderShowList = (List<CTransferOrderShow>)tempUnlockTableManager.AvailableTableForUnlock().Data;

                if (tempOrderShowList != null)
                {
                    CTransferOrderShow[] tempOrderShowArray = tempOrderShowList.ToArray();
                    UnlockTableDataGridView.RowCount = tempOrderShowArray.Length;
                    UnlockTableDataGridView.AllowUserToResizeRows = false;
                    UnlockTableDataGridView.Rows.Clear();

                    for (int arrayIndex = 0; arrayIndex < tempOrderShowArray.Length; arrayIndex++)
                    {
                        int sl = arrayIndex + 1;
                        String[] tempString ={ sl.ToString(), tempOrderShowArray[arrayIndex].OrderType, tempOrderShowArray[arrayIndex].TableNumber.ToString(), tempOrderShowArray[arrayIndex].CustomerName, "Unlock", tempOrderShowArray[arrayIndex].OrderID.ToString() };
                        UnlockTableDataGridView.Rows.Add(tempString);
                    }
                }
                if (UnlockTableDataGridView.RowCount < 16) UnlockTableDataGridView.RowCount = 16;
            }
            catch (Exception ex)
            {
            }
        }
       

        public void UnlockTableDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (UnlockTableDataGridView.Columns[e.ColumnIndex].Name == "ActionButtonColumn" && e.RowIndex >= 0 && UnlockTableDataGridView.Rows[e.RowIndex].Cells["OrderIDColumn"].Value != null)
                {
                    DialogResult tempDialogResult = MessageBox.Show("Are you sure you want to unlock?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (tempDialogResult.Equals(DialogResult.No)) return;
                    else
                    {
                        String tempOldOrderID = UnlockTableDataGridView.Rows[e.RowIndex].Cells["OrderIDColumn"].Value.ToString();
                        Int64 tempOldTableNumber = Int64.Parse(UnlockTableDataGridView.Rows[e.RowIndex].Cells["TableNumberColumn"].Value.ToString());
                        String tempOldTableType = UnlockTableDataGridView.Rows[e.RowIndex].Cells["TableTypeColumn"].Value.ToString();

                        COrderManager tempUnlockTableManager = new COrderManager();
                        CResult tempResult = tempUnlockTableManager.UpdateForUnlockTable(tempOldTableNumber, tempOldTableType);
                        if (tempResult.IsSuccess)
                        {
                            this.PopulateUnlockTableDataGridView();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }        
    }
}