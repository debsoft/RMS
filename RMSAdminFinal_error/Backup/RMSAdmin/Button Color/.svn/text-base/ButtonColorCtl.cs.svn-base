using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RMS;
using RMS.Common.ObjectModel;
using Managers.User;
using RMS.Common.Config;
using RMS.DataAccess;
using System.Data.SqlClient;

namespace RMSAdmin
{
    public partial class ButtonColorCtl : UserControl
    {
        private Form m_parentForm = null;
        public ButtonColorCtl(Form objParent)
        {
            InitializeComponent();
            m_parentForm = objParent;
        }

        private void FillButtons()
        {
            try
            {
                String queryStr = SqlQueries.GetQuery(Query.ViewButtonColorCombo);

                CDalConfig oTempDal = ConfigManager.GetConfig<CDalConfig>();

                String tempConnStr = oTempDal.ConnectionString;

                SqlDataAdapter dataAdapter = new SqlDataAdapter(queryStr, tempConnStr);

                // Create a command builder to generate SQL update, insert, and
                // delete commands based on selectCommand. These are used to
                // update the database.
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                // Populate a new data table and bind it to the BindingSource.
                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(table);

                cmbButtonColor.DataSource = table;

                cmbButtonColor.DisplayMember = "name";

                cmbButtonColor.ValueMember = "button_id";

                dataAdapter.Dispose();

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp + ". Error Occured. Please contact to your administrator.");
            }
        }


        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                if (clrDlg.ShowDialog() == DialogResult.OK)
                {
                    String strR = clrDlg.Color.R.ToString("X");
                    if (strR.Length == 1)
                    {
                        strR = "0" + strR;
                    }

                    String strG = clrDlg.Color.G.ToString("X");
                    if (strG.Length == 1)
                    {
                        strG = "0" + strG;
                    }

                    String strB = clrDlg.Color.B.ToString("X");
                    if (strB.Length == 1)
                    {
                        strB = "0" + strB;
                    }
                    String sTempStr5 = "#" + strR + strG + strB;
                    txtColorName.Text = sTempStr5;
                }
            }
            catch (FormatException exp)//Modified at 13/08/2008
            {
                MessageBox.Show(exp.Message, RMSGlobal.MessageBoxTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, RMSGlobal.MessageBoxTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbButtonColor.SelectedValue != null)
                {
                    int iTempInt = Int32.Parse(cmbButtonColor.SelectedValue.ToString());

                    String sTempStr = txtColorName.Text.Trim();

                    if (sTempStr.Equals(String.Empty))
                    {
                    }
                    else
                    {
                        CButtonColor oTempButton = new CButtonColor();

                        oTempButton.ButtonColor = sTempStr;
                        oTempButton.ButtonID = iTempInt;
                        oTempButton.CurrentUserId = RMSGlobal.LogInUserName;
                        oTempButton.LoginDateTime = RMSGlobal.GetCurrentDateTime();

                        CUserManager oManager = new CUserManager();

                        CResult oResult = oManager.UpdateButtonColor(oTempButton);

                        if (oResult.IsSuccess)
                        {
                            lblSaveStatus.Text = "Button color has been saved successfully.";

                            lblSaveStatus.Visible = true;
                        }
                        else
                        {
                            lblSaveStatus.Text = "Could not update the button color. Please try again.";
                            lblSaveStatus.Visible = true;
                        }
                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, RMSGlobal.MessageBoxTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbButtonColor_DropDown(object sender, EventArgs e)
        {
            FillButtons();
        }
    }
}
