using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace RMSUI
{
    public class RMSToogleButton : RMSGenericButton
    {
        private bool isDown=false;

        public RMSToogleButton()
        {
              Font font = new Font("Arial", 20);
              base.BackgroundImage = RMSUI.Properties.Resources.inp_button_img_up_1;
              base.BackgroundImageLayout = ImageLayout.Tile;
              base.Width = 50;
              base.Height = 50;
              //base.BgImageOnMouseDown = RMSUI.Properties.Resources.inp_btn_img_down_1;
              //base.BgImageOnMouseUp = RMSUI.Properties.Resources.inp_button_img_up_1;
              base.ForeColorOnMouseDown = Color.White;
              base.FlatAppearance.BorderSize = 1;
              base.Font = font;
              base.FlatAppearance.BorderColor = Color.FromArgb(51, 51, 51);

        }
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            if (isDown)
            {
                isDown = false;

                base.BackColor = Color.Red;
                base.ForeColorOnMouseDown = Color.White;
                base.BackgroundImage = RMSUI.Properties.Resources.inp_btn_img_down_1;
                
                
                
            }
            else {
                isDown = true;
                base.BackColor = Color.Transparent;
                base.ForeColor = Color.White;
                base.BackgroundImage = RMSUI.Properties.Resources.inp_button_img_up_1;

            }
        }
        public bool IsDown
        {
            get { return this.isDown; }
            set
            {
                this.isDown = value;
            }
        
        }



    }
}
