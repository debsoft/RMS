using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RMS.Common
{
    public partial class CTableIcon : UserControl
    {
        private Image icon;
        private string name="Table 1";
        private string guestCount="1";
        private string user="User";
        private Color color = Color.Goldenrod;
        private Int64 tableNumber=1;
        private string type = "Table";
        private Int64 orderId = 0;
        private DateTime seatedTime = new DateTime();
        private DateTime orderedTime = new DateTime();

        public CTableIcon()
        {
            InitializeComponent();
            
        }

        public Image Icon
        {
            get
            {
                return icon;
            }
            set
            {
                icon = value;
                this.TableNumberPanel.BackgroundImage = icon;
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
                name=value;
                this.NameLabel.Text = name;
                if (name.Length > 13 && name.Contains(" "))
                {
                    NameLabel.Size =new Size(NameLabel.Size.Width, 30);
                }
            }
        }

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

        public Int64 TableNumber
        {
            get
            {
                return tableNumber;
            }
            set
            {
                tableNumber = value;
                this.TableNumberLabel.Text = tableNumber.ToString();
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

        public string GuestCount
        {
            get
            {
                return guestCount;
            }
            set
            {
                guestCount=value;
                if (Int32.Parse(guestCount)>1)
                this.GuestCountLabel.Text = guestCount+ " Covers";
                else
                    this.GuestCountLabel.Text =  guestCount+" Cover" ;
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
                this.UserLabel.Text = user;
            }
        }

        public Color FontColor
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
                this.UserLabel.ForeColor = color;
                this.NameLabel.ForeColor = color;
                this.GuestCountLabel.ForeColor = color;
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

        

        private void NameLabel_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

        private void GuestCountLabel_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

        private void UserLabel_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

        private void TableNumberLabel_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

        private void TableNumberPanel_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

        
    }
}
