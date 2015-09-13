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
using RMS.Common.ObjectModel;
using Managers.Category;
using Managers.User;

namespace RMSAdmin
{
    public partial class UserDetailsCtl : UserControl
    {
        private Form m_usersParent = null;
        public UserDetailsCtl(Form objParent)
        {
            InitializeComponent();
            m_usersParent = objParent;
        }

        private void FillUsers()
        {
            try
            {
                String queryStr = SqlQueries.GetQuery(Query.ViewUserInfo);

                CDalConfig oTempDal = ConfigManager.GetConfig<CDalConfig>();

                String tempConnStr = oTempDal.ConnectionString;

                //create an OleDbDataAdapter to execute the query
                //OleDbDataAdapter dAdapter =
                //   new OleDbDataAdapter(query, connString);

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

                dgvUsers.DataSource = table;

                dataAdapter.Dispose();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message + "Error Occured. Please contact to your administrator.",
                    RMSGlobal.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UserDetailsCtl_Load(object sender, EventArgs e)
        {
            this.FillUsers();
        }

        private void dgvUsers_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 6)
                {
                    Int32 userID = Convert.ToInt32("0" + dgvUsers.Rows[e.RowIndex].Cells[0].Value);

                    UpdateUserCtl objUpdateUser = new UpdateUserCtl(userID);
                    objUpdateUser.Parent = this.ParentForm;
                    UserControlManager.UserControls.Push(this);
                    Panel pnl = (Panel)this.ParentForm.Controls["pnlContext"];

                    string s = pnl.Name;

                    objUpdateUser.ParentForm.Controls[s].Controls.Clear();
                    objUpdateUser.ParentForm.Controls[s].Controls.Add(objUpdateUser);
                }

                else if (e.ColumnIndex == 7)
                {
                    if (MessageBox.Show("Are you sure you want to delete the selected user?", RMSGlobal.MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Int32 userID = 0;

                        bool bTempBool = Int32.TryParse(dgvUsers.Rows[e.RowIndex].Cells[0].Value.ToString(), out userID);

                        if (bTempBool)
                        {
                            CUserInfo objUserInfo = new CUserInfo();

                            objUserInfo.UserID = userID;
                            CUserManager oManager = new CUserManager();

                            CResult oResult = oManager.DeleteUser(objUserInfo);

                            if (oResult.IsSuccess)
                            {
                                dgvUsers.Rows.RemoveAt(e.RowIndex);
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

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            try
            {
                AddNewUserCtl objAddUser = new AddNewUserCtl();
                objAddUser.Parent = this.ParentForm;
                UserControlManager.UserControls.Push(this);
                Panel pnl = (Panel)this.ParentForm.Controls["pnlContext"];

                string s = pnl.Name;

                objAddUser.ParentForm.Controls[s].Controls.Clear();
                objAddUser.ParentForm.Controls[s].Controls.Add(objAddUser);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        private void UserDetailsCtl_VisibleChanged(object sender, EventArgs e)
        {
            this.FillUsers();
        }
    }
}
