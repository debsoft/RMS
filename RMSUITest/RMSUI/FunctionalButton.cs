using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;


namespace RMSUI
{
    public class FunctionalButton: RMSGenericButton
    {
        private RMSUI.RMSUIConstants.FunctionType functionType;
        public FunctionalButton()
        {
            Font font = new Font("Arial", 10);

            base.BackgroundImage = RMSUI.Properties.Resources.inp_button_img_up_1;
            base.BackgroundImageLayout = ImageLayout.Tile;
            base.BgImageOnMouseDown = RMSUI.Properties.Resources.inp_button_img_down_2;
            base.BgImageOnMouseUp = RMSUI.Properties.Resources.inp_button_img_up_1;
            base.ForeColorOnMouseDown = Color.White;
            base.FlatAppearance.BorderSize = 1;
            base.Font = font;
            base.FlatAppearance.BorderColor = Color.FromArgb(51, 51, 51);
            base.TextImageRelation = TextImageRelation.ImageBeforeText;
            base.TextAlign = ContentAlignment.MiddleLeft;
            base.ImageAlign = ContentAlignment.MiddleLeft;
            base.Width = 70;
            base.Height = 40;
        }
        public  RMSUI.RMSUIConstants.FunctionType FunctionType
        {
            get { return functionType; }
            set 
            { 
                functionType = value;
                switch (functionType)
                {
                    case RMSUIConstants.FunctionType.Add:
                        base.Image = RMSUI.Properties.Resources.icon_add;
                        break;

                    case RMSUIConstants.FunctionType.NormalCenter:
                        base.TextAlign = ContentAlignment.MiddleCenter;
                        base.Image = null;
                        break;

                    case RMSUIConstants.FunctionType.Back:
                        base.Image = RMSUI.Properties.Resources.icon_back;
                        break;
                    case RMSUIConstants.FunctionType.Control:
                        base.Image = RMSUI.Properties.Resources.icon_control;
                        break;
                    case RMSUIConstants.FunctionType.Next:
                        base.Image = RMSUI.Properties.Resources.icon_next;
                        base.TextAlign = ContentAlignment.MiddleRight;
                        base.ImageAlign = ContentAlignment.MiddleRight;
                        base.TextImageRelation = TextImageRelation.TextBeforeImage;

                        break;
                    case RMSUIConstants.FunctionType.Normal:
                        base.Image = null;
                        break;
                    case RMSUIConstants.FunctionType.Option:
                        base.Image = RMSUI.Properties.Resources.icon_option;
                        break;
                    case  RMSUIConstants.FunctionType.Previous:
                        base.Image = RMSUI.Properties.Resources.icon_previous;
                        break;
                    case RMSUIConstants.FunctionType.Print:
                        base.Image = RMSUI.Properties.Resources.icon_print;
                        break;
                    case RMSUIConstants.FunctionType.Refresh:
                        base.Image = RMSUI.Properties.Resources.icon_reload;
                        break;

                    case RMSUIConstants.FunctionType.Remove:
                        base.Image = RMSUI.Properties.Resources.icon_remove;
                        break;
                   
                    
                    default:   base.Image =null;
                        break;
                 
                }

            
            
            }
         
        }

       


    }
}
