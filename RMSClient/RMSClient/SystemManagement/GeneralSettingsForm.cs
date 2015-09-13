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

namespace RMS.SystemManagement
{
    public partial class GeneralSettingsForm : Form
    {

        private GeneralSettingsManager gms;
        private GeneralSettings gs;
        private DataSet tempDataSet;

        public GeneralSettingsForm()
        {

           
            InitializeComponent();
            RBEnablevatNo.Checked = true;
            gms = new GeneralSettingsManager();
            gs=gms.GetGeneralSettings();
            txtbxvatAmount.Text = gs.Vat.ToString();
            txtbxCurrency.Text = gs.Currency;
           
            
            RBenabledVat.Checked = gs.IsVatEnabled;

            tempDataSet = new DataSet();
            tempDataSet.ReadXml("Config/VatRegisterNo.xml");
            txtBoxVatRegistrationID.Text = tempDataSet.Tables[0].Rows[0]["des"].ToString();




        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
           
            try
            {  
                tempDataSet.Tables[0].Rows[0]["des"] = txtBoxVatRegistrationID.Text;
                tempDataSet.WriteXml("Config/VatRegisterNo.xml");
                Program.vatRegDes = txtBoxVatRegistrationID.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString()+ " Unable to save vat registration id." );
            }

            
            
            double tempVat= Convert.ToDouble( txtbxvatAmount.Text.Replace("%", ""));
            bool success= gms.UpdateSettings(tempVat, RBenabledVat.Checked, txtbxCurrency.Text);



           if (success)
           {
               this.DialogResult = DialogResult.OK;
               Program.currency = txtbxCurrency.Text;
               Program.vat = tempVat;
               Program.isVatEnabled = RBenabledVat.Checked;

           }
           else
           {
               this.DialogResult = DialogResult.Retry;
           }
        }
    }
}
