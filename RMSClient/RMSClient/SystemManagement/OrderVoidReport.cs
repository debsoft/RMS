using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RMS.Common.ObjectModel;
using RMSClient.DataAccess;

namespace RMS.SystemManagement
{
    public partial class OrderVoidReport : Form
    {
        public OrderVoidReport()
        {
            InitializeComponent();
        }

        private void btnSetToday_Click(object sender, EventArgs e)
        {
            DateTime startDate = new DateTime(dtpStart.Value.Year, dtpStart.Value.Month, dtpStart.Value.Day, 0, 0, 0);
            DateTime dtTemp = dtpEnd.Value.AddDays(1);
            DateTime endDate = new DateTime(dtTemp.Year, dtTemp.Month, dtTemp.Day, 0, 0, 0);
            endDate = endDate.AddSeconds(-1);
            List<OrderVoid> aOrderVoids=new List<OrderVoid>();
            OrderVoidDAO aOrderVoidDao=new OrderVoidDAO();
            aOrderVoids = aOrderVoidDao.GetAllOrderVoid(startDate,endDate);
            orderVoiddataGridView.DataSource = aOrderVoids;
        }
    }
}
