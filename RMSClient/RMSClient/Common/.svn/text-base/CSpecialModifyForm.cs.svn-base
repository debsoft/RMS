using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Managers.SystemManagement;
using RMS.Common.ObjectModel;
using RMSUI;

namespace RMS.Common
{
    public partial class CSpecialModifyForm : BaseForm
    {
        public string KeyBoardTitleText = "";
        public string PromptLabelText = "";
        public static string Content = "";
        private bool capsLock = false;
        private int m_iSelectionIndex = 0;

        public CSpecialModifyForm()
        {
            InitializeComponent();
            Content = "";
        }
        public CSpecialModifyForm(string title, string prompt)
        {
            InitializeComponent();
            KeyBoardTitleText = title;
            PromptLabelText = prompt;

            this.Text = title;
            PromptLabel.Text = prompt;
            Content = "";
        }
        private void CMiscItemForm_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.DrawLine(new Pen(new SolidBrush(this.ForeColor)), new Point(480, 30), new Point(480, 360));
        }

      
        private void BackSpaceButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (ContentTextBox.Text.Length == 1)
                    ContentTextBox.Clear();
                int tempLength;
                if (ContentTextBox.SelectionLength == 0)
                    tempLength = 1;
                else
                    tempLength = ContentTextBox.SelectionLength;


                ContentTextBox.Text = ContentTextBox.Text.Remove(m_iSelectionIndex - 1, tempLength);
                m_iSelectionIndex--;
            }
            catch (Exception eee)
            {
            }
        }

        private void SetText(string input)
        {
            try
            {
                if (capsLock)
                    input = input.ToUpper();

                ContentTextBox.Text = ContentTextBox.Text.Insert(m_iSelectionIndex, input);
                m_iSelectionIndex++;
            }
            catch (Exception eee)
            {
            }
        }

        private void KeyButton_Click(object sender, EventArgs e)
        {
            SetText(((Button)sender).Text);
        }

       

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Content = "Cancel";
            this.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (ContentTextBox.Text.Length < 1)
            {
                MessageBox.Show("Please select or enter text.",RMSGlobal.MessageBoxTitle,MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            Content = ContentTextBox.Text;
            this.Close();
        }

        private void SpaceButton_Click(object sender, EventArgs e)
        {
            SetText(" ");
        }

        private void ContentTextBox_Click(object sender, EventArgs e)
        {
            m_iSelectionIndex = ContentTextBox.SelectionStart;
        }

        private void FixedItemButton_Click(object sender, EventArgs e)
        {
            Content = ((CCategoryButton)sender).Text;
            this.Close();
        }

        private void CSpecialModifyForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.LoadModificationText();
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        private void LoadModificationText()
        {
            SortedList slKitchenText = new SortedList();
            SystemManager objSystem = new SystemManager();
            CResult objCresult = new CResult();

                objCresult = objSystem.GetAllSpecialModifyText();

                slKitchenText = (SortedList)objCresult.Data;
                dgvKitchenText.RowCount = 0;

                foreach (clsSpecialModfifyText objSpecialText in slKitchenText.Values)
                {
                    DataGridViewRowCollection dgvRow = (DataGridViewRowCollection)dgvKitchenText.Rows;
                    dgvRow.Add(objSpecialText.SpecialModfifyTextId, objSpecialText.SpecialModfifyText);
                }

            dgvKitchenText.ClearSelection();
            ContentTextBox.Clear(); //Initially clearing the text box
        }

        private void dgvKitchenText_SelectionChanged(object sender, EventArgs e)
        {
            string currentSpecial = Convert.ToString(dgvKitchenText.CurrentRow.Cells[1].Value);
            ContentTextBox.Text = currentSpecial;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ContentTextBox.Clear();
        }

        private void specialKeyBoard_UserKeyPressed(object sender, IbacsTouchScreenKeyBoard.KeyBoard.KeyboardEventArgs e)
        {
            ContentTextBox.Focus();
            SendKeys.Send(e.KeyboardKeyPressed);
        }
    }
}