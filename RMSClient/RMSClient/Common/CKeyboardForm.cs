using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RMSUI;

namespace RMS.Common
{
    public partial class CKeyBoardForm : BaseForm
    {
        public string KeyBoardTitleText = "";
        public string PromptLabelText = "";
        public static string Content = "";
        private bool capsLock = false;
        private int m_iSelectionIndex = 0;
        public static bool m_foodType=false;
        private bool m_isMiscelleneousItem = false;

        public CKeyBoardForm()
        {
            InitializeComponent();
            m_foodType = false;
            m_isMiscelleneousItem = false;
        }

        public CKeyBoardForm(string title,string prompt)
        {
            InitializeComponent();
            KeyBoardTitleText = title;
            PromptLabelText = prompt;

            this.Text = title;
            PromptLabel.Text = prompt;
            Content = "";
            m_foodType = false;
            m_isMiscelleneousItem = false;
        }

        public CKeyBoardForm(string title, string prompt,bool isMiscelleneous)
        {
            InitializeComponent();
            KeyBoardTitleText = title;
            PromptLabelText = prompt;

            this.Text = title;
            PromptLabel.Text = prompt;
            Content = "";
            m_isMiscelleneousItem = isMiscelleneous; //For miscelleneous items
            rdoNonFood.Visible = true;
            rdoFood.Visible = true;
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
            if (m_isMiscelleneousItem == true)
            {
                if (rdoFood.Checked || rdoNonFood.Checked)
                {
                    Content = ContentTextBox.Text;
                    m_foodType = rdoFood.Checked;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Please select food type.", RMSGlobal.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                Content = ContentTextBox.Text;
                this.Close();
            }
        }

      

        private void ContentTextBox_Click(object sender, EventArgs e)
        {
            m_iSelectionIndex = ContentTextBox.SelectionStart;
        }

        private void miscKeyBoard_UserKeyPressed(object sender, IbacsTouchScreenKeyBoard.KeyBoard.KeyboardEventArgs e)
        {
            ContentTextBox.Focus();
            SendKeys.Send(e.KeyboardKeyPressed);
        }

        

        

        private void functionalButton1_Click(object sender, EventArgs e)
        {
            if (m_isMiscelleneousItem == true)
            {
                if (rdoFood.Checked || rdoNonFood.Checked)
                {
                    Content = ContentTextBox.Text;
                    m_foodType = rdoFood.Checked;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Please select food type.", RMSGlobal.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                Content = ContentTextBox.Text;
                this.Close();
            }
        }

        private void functionalButton2_Click(object sender, EventArgs e)
        {
            Content = "Cancel";
            this.Close();
        }

    

        
    }
}