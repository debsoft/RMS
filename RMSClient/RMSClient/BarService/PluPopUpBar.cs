using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RMS.Common;
using RMS.Common.ObjectModel;
using Managers.SystemManagement;
using Managers.TableInfo;
using RMSUI;


namespace RMS.BarService
{
    public partial class PluPopUpBar : Form
    {  
        public string KeyBoardTitleText = "";
        public static string Content = "";
        private bool capsLock = false;
        private int m_iSelectionIndex = 0;
        public int m_priceTakeType = 0;
        public  Int64 m_orderID;

        public PluPopUpBar(Int64 orderID)
        {
            InitializeComponent();
            m_orderID = orderID;
             Content = "";
        }

        private void SetText(string input)
        {
            try
            {
                if (capsLock)
                {
                    input = input.ToUpper();
                }
                txtProductID.Text = txtProductID.Text.Insert(m_iSelectionIndex, input);
                m_iSelectionIndex++;
            }
            catch (Exception eee)
            {
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void KeyButton_Click(object sender, EventArgs e)
        {
            SetText(((Button)sender).Text);
        }

        private void txtProductID_Click(object sender, EventArgs e)
        {
            m_iSelectionIndex = txtProductID.SelectionStart;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string product_plu = txtProductID.Text;
            int returnVal;
            returnVal = 0;
            COrderManager objOrderManager = new COrderManager();
            m_priceTakeType = -99;
            CResult oResult =null ;//objOrderManager.GetPluDataByProductPLU(product_plu, m_priceTakeType,m_orderID);
            if (oResult.IsSuccess && oResult.Data != null)
                returnVal = int.Parse(oResult.Data.ToString());
            if (returnVal == 0)
            {
                MessageBox.Show("Please enter valid plu product", RMSGlobal.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (returnVal == 3)
            {
                MessageBox.Show("Please enter non food type plu product", RMSGlobal.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                this.Close();
            }
        }

        private void barkeyBoard_UserKeyPressed(object sender, IbacsTouchScreenKeyBoard.KeyBoard.KeyboardEventArgs e)
        {
            txtProductID.Focus();
            SendKeys.Send(e.KeyboardKeyPressed);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtProductID.Clear();
        }
    }
}
