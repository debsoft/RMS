using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RMSUI;
using RMS.DataAccess;
using Managers.TableInfo;
using Managers.GManager;
using RMS.Common.ObjectModel;
using RMS.Common;

namespace RMS.SystemManagement
{
    public partial class StockSettingsForm : Form
    {

        private GeneralSettingsManager gms;
        private GeneralSettings gs;
        private DataSet tempDataSet;

        public StockSettingsForm()
        {           
            InitializeComponent();
            

            tempDataSet = new DataSet();
            tempDataSet.ReadXml("Config/StockSetting.xml");

            bool isAllowedToOrder = Convert.ToBoolean(tempDataSet.Tables[0].Rows[0]["AllowedtoOrder"].ToString());

            if(isAllowedToOrder)
            {
                rdbAllowedToOrder.Checked = true;
            }
            else
            {
                rdbNo.Checked = true;
            }

        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
           
            try
            {
                bool isAllowedToOrder = false;

                if(rdbAllowedToOrder.Checked)
                {
                    isAllowedToOrder = true;
                }
                tempDataSet.Tables[0].Rows[0]["AllowedtoOrder"] = isAllowedToOrder;

                tempDataSet.WriteXml("Config/StockSetting.xml");

             //   Program.vatRegDes = txtBoxVatRegistrationID.Text;

                
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString()+ " Unable to save vat registration id." );
            }
            
        }

        private void roundDailogeBox1_Load(object sender, EventArgs e)
        {

        }
        
    }
}
