using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace RMSUI
{
    public partial class LobbyItemButton : UserControl
    {
        private RMSUI.RMSUIConstants.ItemType itemType;

        private string name = "Table 1";
        private string guestCount = "1";
        private string user = "User";
        private Int64 tableNumber = 1;
        private string type = "Table";
        private Int64 orderId = 0;
        private DateTime seatedTime = new DateTime();
        private DateTime orderedTime = new DateTime();
       private string floorName = " ";
      
        public LobbyItemButton()
        {
            InitializeComponent();
        }
       

        public RMSUI.RMSUIConstants.ItemType ItemType
        {
            get { return itemType; }
            set { itemType = value;
            
                switch(itemType){
                    case RMSUIConstants.ItemType.SeatedButNoOrdered:
                        topPanel.BackgroundImage = RMSUI.Properties.Resources.icon_tb_seated;
                        break;
                    case RMSUIConstants.ItemType.Ordered:
                        topPanel.BackgroundImage = RMSUI.Properties.Resources.icon_tb_ordered;
                        break;
                    case RMSUIConstants.ItemType.WaitingForPayment:
                        topPanel.BackgroundImage = RMSUI.Properties.Resources.icon_tb_waiting_forpayment;
                        break;
                    case RMSUIConstants.ItemType.BarService:
                        topPanel.BackgroundImage = RMSUI.Properties.Resources.icon_tw_barservice;
                        break;
                    case RMSUIConstants.ItemType.Delevery:
                        topPanel.BackgroundImage = RMSUI.Properties.Resources.icon_tw_delevery;
                        break;
                    case RMSUIConstants.ItemType.Collection:
                        topPanel.BackgroundImage = RMSUI.Properties.Resources.icon_tb_waiting_collections;
                        break;
                    case RMSUIConstants.ItemType.Waiting:
                        topPanel.BackgroundImage = RMSUI.Properties.Resources.icon_tb_waiting_waiting;
                        break;
                }
            
            
            }
      
        }

        public string TableName
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                this.lblTableDetails.Text = name;
               /* if (name.Length > 13 && name.Contains(" "))
                {
                    NameLabel.Size = new Size(NameLabel.Size.Width, 30);
                }*/
            }
        }
        //for terminal name
        //public string TerminalName
        //{
        //    get
        //    {
        //        return terminalName;
        //    }
        //    set
        //    {
        //        terminalName = value;
        //        this.lblterminal.Text = terminalName;
        //        /* if (name.Length > 13 && name.Contains(" "))
        //         {
        //             NameLabel.Size = new Size(NameLabel.Size.Width, 30);
        //         }*/
        //    }
        //}

        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;

            }
        }
        public Int64 OrderID
        {
            get
            {
                return orderId;
            }
            set
            {
                orderId = value;
            }
        }

        public Int64 TableNumber
        {
            get
            {
                return tableNumber;
            }
            set
            {
                tableNumber = value;
                this.lblNumber.Text = tableNumber.ToString();
            }
        }



        public string GuestCount
        {
            get
            {
                return guestCount;
            }
            set
            {
                guestCount = value;
                if (Int32.Parse(guestCount) > 1)
                    this.lblType.Text = guestCount + " Covers";
                else
                    this.lblType.Text = guestCount + " Cover";
            }
        }

        public string User
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
                this.lblUser.Text = user;
            }
        }

        public DateTime SeatedTime
        {
            get { return seatedTime; }
            set { seatedTime = value; }
        }

        public DateTime OrderedTime
        {
            get { return orderedTime; }
            set { orderedTime = value; }
        }

        public string FloorName
        {
            get { 
                return floorName;
                }
            set { 
                floorName = value;
                floorlabel.Text = "Floor No: " + floorName;
            }
        }


        private void LobbyItemButton_MouseDown(object sender, MouseEventArgs e)
        {
            this.BackColor = Color.FromArgb(168, 197, 212);
        }

        private void LobbyItemButton_MouseUp(object sender, MouseEventArgs e)
        {
            this.BackColor = Color.FromArgb(255, 255, 255);
        }

        private void lblType_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

        

       

        
    }
}
