using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;


namespace RMSUI
{
    public partial class KeyButton : InputTextButton
    {
        private TextBox controlToInputText;
        private bool removeLastChar = false;

        private string defaultStateText;
        private string changeStateText;
        private bool showDefaultState = true;



        public KeyButton()
        {
            Font font = new Font("Arial", 14);
            base.BackgroundImage = RMSUI.Properties.Resources.inp_button_img_up_1;
            base.BackgroundImageLayout = ImageLayout.Tile;
            base.Width = 50;
            base.Height = 50;
            base.BgImageOnMouseDown = RMSUI.Properties.Resources.inp_btn_img_down_1;
            base.BgImageOnMouseUp = RMSUI.Properties.Resources.inp_button_img_up_1;
            base.ForeColorOnMouseDown = Color.White;
            base.FlatAppearance.BorderSize = 1;
            base.Font = font;
            base.FlatAppearance.BorderColor = Color.FromArgb(51, 51, 51);

        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            if (controlToInputText != null)
            {

                if (removeLastChar)
                {

                    if (controlToInputText.Text != "")
                    {
                        string stRemove = controlToInputText.Text.ToString();

                        string aa = stRemove.Remove(stRemove.Length - 1, 1);

                        controlToInputText.Text = aa;
                    
                    }

                    else
                    {
                        controlToInputText.Text = "";
                        
                    }
                }

                else
                {
                    controlToInputText.AppendText(this.Text);
                }

            }



        }

        public TextBox ControlToInputText
        {
            get { return this.controlToInputText; }
            set { this.controlToInputText = value; }

        }

        public bool RemoveLastChar
        {
            get { return this.removeLastChar; }
            set { this.removeLastChar = value; }
        }

        public string DefaultStateText
        {
            get { return this.defaultStateText; }
            set
            {
                this.defaultStateText = value;
                this.Text = value;

            }

        }



        public string ChangeStateText
        {
            get { return this.changeStateText; }
            set
            {
                this.changeStateText = value;
                
                
            }

        }

        public void AlterState()
        {
            if (showDefaultState)
            {
                showDefaultState = false;
                this.Text = changeStateText;
            }
            else
            {
                showDefaultState = true;
                this.Text = defaultStateText;
            }


        }

    }
}
