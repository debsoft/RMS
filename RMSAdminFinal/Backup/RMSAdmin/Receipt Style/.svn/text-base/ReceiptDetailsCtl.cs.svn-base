using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RMS.Common.Config;
using RMS.DataAccess;
using System.Data.SqlClient;
using RMS;

namespace RMSAdmin
{
    public partial class ReceiptDetailsCtl : UserControl
    {
        private Form m_parentForm = null;
        public ReceiptDetailsCtl(Form objParent)
        {
            InitializeComponent();
            m_parentForm = objParent;
        }

        #region "Manupulation"
        private void FillReceiptStyle()
        {

            String sqlCommand = SqlQueries.GetQuery(Query.GetAllPrintStyle);

            CDalConfig oTempDal = ConfigManager.GetConfig<CDalConfig>();

            String tempConnStr = oTempDal.ConnectionString;

            // Create a new data adapter based on the specified query.
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand, tempConnStr);
          
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

            // Populate a new data table and bind it to the BindingSource.
            DataTable table = new DataTable();
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dataAdapter.Fill(table);
            dgvReceiptStyles.DataSource = table;
        }
        #endregion

        private void ReceiptDetailsCtl_Load(object sender, EventArgs e)
        {
            FillReceiptStyle();
        }

        private void dgvReceiptStyles_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            
            try
            {
                if (e.ColumnIndex == 5)
                {
                    Int32 receiptID = Int32.Parse(dgvReceiptStyles.CurrentRow.Cells[0].Value.ToString());

                    UpdateReceiptStyle objUpdate = new UpdateReceiptStyle(receiptID);
                    objUpdate.Parent = this.ParentForm;
                    UserControlManager.UserControls.Push(this);
                    Panel pnl = (Panel)this.ParentForm.Controls["pnlContext"];

                    string s = pnl.Name;

                    objUpdate.ParentForm.Controls[s].Controls.Clear();
                    objUpdate.ParentForm.Controls[s].Controls.Add(objUpdate);
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message + "Error Occured. Please contact to your administrator.",
                    RMSGlobal.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        }
}
