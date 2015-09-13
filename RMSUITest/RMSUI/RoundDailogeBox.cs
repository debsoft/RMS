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
    public partial class RoundDailogeBox : UserControl
    {
        public RoundDailogeBox()
        {
            InitializeComponent();
        }

        public Panel DailogeContentHolder
        {
            get { return dailogeBoxContentHolder; }
            set { dailogeBoxContentHolder = value; }
        }
    }
}
