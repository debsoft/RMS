using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using RMS.Common.Config;
using RMS.DataAccess;
using RMS;
using Managers.Category;
using RMS.Common.ObjectModel;

namespace RMSAdmin
{
    public partial class ParentDetailsCtl : UserControl
    {
        private Form m_parentForm = null;
        public ParentDetailsCtl(Form objParent)
        {
            InitializeComponent();
            m_parentForm= objParent;
        }

        #region "Manupulation"
        private void LoadParentCategory()
        {
            try
            {
                String queryStr = SqlQueries.GetQuery(Query.ViewParentCategory);

                CDalConfig oTempDal = ConfigManager.GetConfig<CDalConfig>();

                String tempConnStr = oTempDal.ConnectionString;

                // Create a new data adapter based on the specified query.
                SqlDataAdapter dataAdapter = new SqlDataAdapter(queryStr, tempConnStr);

                // Create a command builder to generate SQL update, insert, and
                // delete commands based on selectCommand. These are used to
                // update the database.
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                // Populate a new data table and bind it to the BindingSource.
                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(table);
                //bindingSource1.DataSource = table;

                dgvParentCategory.DataSource = table;
               // dgvParentCategory.Columns["Parent_Category_Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                table.TableName = "parent_category";
                table.WriteXml("parent_category.xml",XmlWriteMode.IgnoreSchema);

                dataAdapter.Dispose();

                //this.dgvParentCategory.Columns["parent_cat_id"].Visible = false;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message+ ". Error Occured. Please contact to your administrator.");
            }
        }
        #endregion


        private void ParentDetailsCtl_Load(object sender, EventArgs e)
        {
            this.LoadParentCategory();
        }

        private void dgvParentCategory_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            
            try
            {
                if (e.ColumnIndex == 2)
                {
                    Int32 parentCatId = Convert.ToInt32("0"+dgvParentCategory.Rows[e.RowIndex].Cells[0].Value);
                    string parentCatName=Convert.ToString(dgvParentCategory.Rows[e.RowIndex].Cells[1].Value);

                    UpdateParentCtl objUpdate = new UpdateParentCtl(parentCatId, parentCatName);
                    objUpdate.Parent = this.ParentForm;
                    UserControlManager.UserControls.Push(this);
                    Panel pnl =(Panel)this.ParentForm.Controls["pnlContext"];

                    string s = pnl.Name;

                    objUpdate.ParentForm.Controls[s].Controls.Clear();
                    objUpdate.ParentForm.Controls[s].Controls.Add(objUpdate);
                }

                else if (e.ColumnIndex == 3)
                {
                    if (MessageBox.Show("Are you sure you want to delete the selected parent category?", RMSGlobal.MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int parentCatId=0;

                        bool bTempBool = Int32.TryParse(dgvParentCategory.Rows[e.RowIndex].Cells[0].Value.ToString(), out parentCatId);

                        if (bTempBool)
                        {
                            CParentCategory oCat = new CParentCategory();

                            oCat.ParentCatID = parentCatId;
                            CCategoryManager oManager = new CCategoryManager();

                            CResult oResult = oManager.DeleteParentCat(oCat);

                            if (oResult.IsSuccess)
                            {
                                dgvParentCategory.Rows.RemoveAt(e.RowIndex);
                            }
                        }
                    }
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }


        /// <summary>
        /// Add new parent category
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddParentCategory_Click(object sender, EventArgs e)
        {
            try
            {
                AddParentCatCtl objAddCat = new AddParentCatCtl();
                objAddCat.Parent = this.ParentForm;
                UserControlManager.UserControls.Push(this);
                Panel pnl = (Panel)this.ParentForm.Controls["pnlContext"];

                string s = pnl.Name;

                objAddCat.ParentForm.Controls[s].Controls.Clear();
                objAddCat.ParentForm.Controls[s].Controls.Add(objAddCat);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        private void ParentDetailsCtl_VisibleChanged(object sender, EventArgs e)
        {
            this.LoadParentCategory();


        }
    }
}
