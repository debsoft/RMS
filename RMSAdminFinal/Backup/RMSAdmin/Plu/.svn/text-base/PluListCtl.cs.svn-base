using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RMS.Common.Config;
using RMS;
using System.Data.SqlClient;
using RMS.DataAccess;

namespace RMSAdmin
{
    public partial class PluListCtl : UserControl
    {
        private Form m_parentForm = null;
        private DataTable dtFoodItem = new DataTable();
        private DataTable dtSelectedItem = new DataTable();

        public PluListCtl(Form parent)
        {
            InitializeComponent();
            m_parentForm = parent;
        }

        #region "Manupulation Area"
        private void FillProducts()
        {
            dtFoodItem = new DataTable();
            dtSelectedItem = new DataTable();
            
            String sqlCommand = SqlQueries.GetQuery(Query.GetPLUProductList3);

            CDalConfig oTempDal = ConfigManager.GetConfig<CDalConfig>();

            String tempConnStr = oTempDal.ConnectionString;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand, tempConnStr);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

            dtFoodItem.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dataAdapter.Fill(dtFoodItem);

            sqlCommand = SqlQueries.GetQuery(Query.GetPLUProductList4);

            dataAdapter = new SqlDataAdapter(sqlCommand, tempConnStr);
            commandBuilder = new SqlCommandBuilder(dataAdapter);

            dtSelectedItem.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dataAdapter.Fill(dtSelectedItem);

            dtFoodItem.Merge(dtSelectedItem);

            dgvProductList.DataSource = dtFoodItem;

        }

        #endregion

        private void PluListCtl_Load(object sender, EventArgs e)
        {
            FillProducts();
        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {
            DataView dvProducts = new DataView(dtFoodItem);
            dvProducts.RowFilter = "product_name like '%"+txtProductName.Text+"%'";
            dgvProductList.DataSource = dvProducts;
        }

        private void dgvProductList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }

            if (e.ColumnIndex == 3)
            {
                string productName = dgvProductList.CurrentRow.Cells[1].Value.ToString();
                string procuctID = dgvProductList.CurrentRow.Cells[0].Value.ToString() +"-"+ dgvProductList.CurrentRow.Cells[2].Value.ToString(); ;

                AddProductPluCtl objPLU = new AddProductPluCtl(procuctID, productName);
                objPLU.Parent = this.ParentForm;
                UserControlManager.UserControls.Push(this);
                Panel pnl = (Panel)this.ParentForm.Controls["pnlContext"];

                string s = pnl.Name;

                objPLU.ParentForm.Controls[s].Controls.Clear();
                objPLU.ParentForm.Controls[s].Controls.Add(objPLU);
            }
        }

        private void PluListCtl_VisibleChanged(object sender, EventArgs e)
        {
            FillProducts();
        }
    }
}
