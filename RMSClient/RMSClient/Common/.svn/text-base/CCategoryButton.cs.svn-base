using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RMS.Common
{
    public partial class CCategoryButton : Button
    {
        private int catOrder;
        private int catLevel;
        private int catID;
        private string sellingIn;

        public CCategoryButton()
        {
            InitializeComponent();
            catOrder = 0;
            catLevel = 0;
            catID = 0;
            sellingIn = String.Empty;
        }


        public string SellingQuantityorWeight
        {
            get { return sellingIn; }
            set { sellingIn = value; }
        }

        public int CategoryOrder
        {
            get { return catOrder; }
            set { catOrder = value; }
        }

        public int CategoryID
        {
            get { return catID; }
            set { catID = value; }
        }

        public int CategoryLevel
        {
            get { return catLevel; }
            set
            {
                catLevel = value;
            }

        }
    }
}
