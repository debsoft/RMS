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
    public partial class CWinKeyboardForm : Form
    {
        public string KeyBoardTitleText = "";
        public string PromptLabelText = "";
        public static string Content = "";
        private bool capsLock = false;
        private int m_iSelectionIndex = 0;

        public CWinKeyboardForm()
        {
            InitializeComponent();
        }

        public CWinKeyboardForm(string title,string prompt)
        {
            InitializeComponent();
            KeyBoardTitleText = title;
            PromptLabelText = prompt;

            this.Text = title;
            PromptLabel.Text = prompt;
            Content = "";
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

        private void basicKeyBoard_UserKeyPressed(object sender, IbacsTouchScreenKeyBoard.KeyBoard.KeyboardEventArgs e)
        {
            ContentTextBox.Focus();
            SendKeys.Send(e.KeyboardKeyPressed);
        }

    }
}