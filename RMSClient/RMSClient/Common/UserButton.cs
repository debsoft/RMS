using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RMS.Common
{
    public partial class UserButton : UserControl
    {
        private String gender;
        public UserButton()
        {
            InitializeComponent();
        }

        public String Gender
        {
            get { return gender; }
            set 
            {
                gender = value;
                if (gender.ToLower().Equals("male"))
                     this.TouchButton.BackgroundImage = global::RMS.Properties.Resources.male_user;//this.TouchButton.BackgroundImage = global::RMS.Properties.Resources.male;
                else
                    this.TouchButton.BackgroundImage = global::RMS.Properties.Resources.female_user; //this.TouchButton.BackgroundImage = global::RMS.Properties.Resources.female;
            }
        }

        private void UserButton_MouseEnter(object sender, EventArgs e)
        {
            if (gender.ToLower().Equals("male"))
                this.TouchButton.BackgroundImage = global::RMS.Properties.Resources.male_user_hover;//this.TouchButton.BackgroundImage = global::RMS.Properties.Resources.male_over;
            else
                this.TouchButton.BackgroundImage = global::RMS.Properties.Resources.female_user_hover;// this.TouchButton.BackgroundImage = global::RMS.Properties.Resources.female_over;
        }

        private void UserButton_MouseLeave(object sender, EventArgs e)
        {
            if (gender.ToLower().Equals("male"))
                this.TouchButton.BackgroundImage = global::RMS.Properties.Resources.male_user;//this.TouchButton.BackgroundImage = global::RMS.Properties.Resources.male;
            else
                this.TouchButton.BackgroundImage = global::RMS.Properties.Resources.female_user; //this.TouchButton.BackgroundImage = global::RMS.Properties.Resources.female;
        }

        private void TouchButton_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

        private void rmsUserName_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }
    }
}
