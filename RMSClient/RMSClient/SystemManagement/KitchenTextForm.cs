using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RMS.Common.ObjectModel;
using Managers.SystemManagement;
using RMSUI;

namespace RMS.SystemManagement
{
    public partial class KitchenTextForm : BaseForm
    {
        public string KeyBoardTitleText = "";
        public string PromptLabelText = "";
        public static string Content = "";
        private bool capsLock = false;
        private int m_iSelectionIndex = 0;
        private bool m_specialModifyText = false;


        public KitchenTextForm()
        {
            InitializeComponent();
            Content = "";
        }

        public KitchenTextForm(bool blnSpecialModify,string title)
        {
            InitializeComponent();
            m_specialModifyText = blnSpecialModify;
            Content = "";
            this.Text = title;
        }


        private void SetText(string input)
        {
            try
            {
                if (capsLock)
                {
                    input = input.ToUpper();
                }
                txtKitchenText.Text = txtKitchenText.Text.Insert(m_iSelectionIndex, input);
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

        private void KitchenTextForm_Load(object sender, EventArgs e)
        {
            this.LoadKitchenText();
        }

        private void LoadKitchenText()
        {
            SortedList slKitchenText = new SortedList();
            SystemManager objSystem = new SystemManager();
            CResult objCresult = new CResult();

            if (m_specialModifyText == false) //If for kitchen text
            {
                objCresult = objSystem.GetAllKitchenText();
                slKitchenText = (SortedList)objCresult.Data;
                dgvKitchenText.RowCount = 0;

                foreach (clsKitchenText objKitchenText in slKitchenText.Values)
                {
                    DataGridViewRowCollection dgvRow = (DataGridViewRowCollection)dgvKitchenText.Rows;
                    dgvRow.Add(objKitchenText.KitchenTextId, objKitchenText.KitchenText);
                }
            }
            else //If for special modification
            {
                objCresult = objSystem.GetAllSpecialModifyText();

                slKitchenText = (SortedList)objCresult.Data;
                dgvKitchenText.RowCount = 0;

                foreach (clsSpecialModfifyText objSpecialText in slKitchenText.Values)
                {
                    DataGridViewRowCollection dgvRow = (DataGridViewRowCollection)dgvKitchenText.Rows;
                    dgvRow.Add(objSpecialText.SpecialModfifyTextId, objSpecialText.SpecialModfifyText);
                }
            }
            
            dgvKitchenText.ClearSelection();
            txtKitchenText.Clear();
        }

        private void KeyButton_Click(object sender, EventArgs e)
        {
            SetText(((Button)sender).Text);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_specialModifyText == false)
                {
                    SortedList slKitchenText = new SortedList();
                    slKitchenText.Add("ID", txtKitchenText.Tag);
                    slKitchenText.Add("KT", txtKitchenText.Text);
                    SystemManager objSystem = new SystemManager();
                    objSystem.SaveKitchenText(slKitchenText);
                }
                else
                {
                    SortedList slKitchenText = new SortedList();
                    slKitchenText.Add("SPID", txtKitchenText.Tag);
                    slKitchenText.Add("SPTXT", txtKitchenText.Text);
                    SystemManager objSystem = new SystemManager();
                    objSystem.SaveSpecialText(slKitchenText);
                }
                this.LoadKitchenText();
                MessageBox.Show("Kitchen text has been saved scucessfully.", RMSGlobal.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

       
     


        private void BackSpaceButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtKitchenText.Text.Length == 1)
                    txtKitchenText.Clear();
                int tempLength;
                if (txtKitchenText.SelectionLength == 0)
                    tempLength = 1;
                else
                    tempLength = txtKitchenText.SelectionLength;

                txtKitchenText.Text = txtKitchenText.Text.Remove(m_iSelectionIndex - 1, tempLength);
                m_iSelectionIndex--;
            }
            catch (Exception eee)
            {
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Content = "Cancel";
            this.Close();
        }

        private void txtKitchenText_Click(object sender, EventArgs e)
        {
            m_iSelectionIndex = txtKitchenText.SelectionStart;
        }

        private void dgvKitchenText_SelectionChanged(object sender, EventArgs e)
        {
            string selectedText =Convert.ToString(dgvKitchenText.CurrentRow.Cells[1].Value);
            txtKitchenText.Text = selectedText;
            txtKitchenText.Tag = Convert.ToString(dgvKitchenText.CurrentRow.Cells[0].Value);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtKitchenText.Clear();
            txtKitchenText.Tag = null;
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to remove the selected text?", RMSGlobal.MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Int32 kitchenTextID = Convert.ToInt32("0" + dgvKitchenText.CurrentRow.Cells[0].Value);
                    SystemManager objSystem = new SystemManager();

                    if (m_specialModifyText == false)
                    {
                        objSystem.DeleteKitchenText(kitchenTextID);
                    }
                    else
                    {
                        objSystem.DeleteSpecialText(kitchenTextID);
                    }
                    this.LoadKitchenText();
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                
                Int32 kitchenTextID = Convert.ToInt32("0" + dgvKitchenText.CurrentRow.Cells[0].Value);
                string kitchenText = txtKitchenText.Text;
                SystemManager objSystem = new SystemManager();
                if (m_specialModifyText == false)
                {
                    objSystem.UpdateKitchenText(kitchenTextID, kitchenText);
                }
                else
                {
                    objSystem.UpdateSpecialText(kitchenTextID, kitchenText);                }
                this.LoadKitchenText();
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        private void ktInfoKeyBoard_UserKeyPressed(object sender, IbacsTouchScreenKeyBoard.KeyBoard.KeyboardEventArgs e)
        {
            txtKitchenText.Focus();
            SendKeys.Send(e.KeyboardKeyPressed);
        }
    }
}
