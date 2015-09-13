using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RMS.Common;
using Managers.TableInfo;
using RMS.Common.ObjectModel;
using RMSUI;

namespace RMS.Common
{
    public partial class CTableInfoMessageBox : Form
    {
        public CTableInfoMessageBox()
        {
            InitializeComponent();
        }

        public CTableInfoMessageBox(Int64 inOrderID)
        {
            InitializeComponent();

            COrderManager tempOrderManager = new COrderManager();
            CResult oResult = tempOrderManager.OrderInfoByOrderID(inOrderID);
            COrderInfo oOrderInfo = new COrderInfo();
            if (oResult.IsSuccess && oResult.Data != null)
            {
                oOrderInfo=(COrderInfo)oResult.Data;
            }

            COrderSeatTime oOrderSeatTime = new COrderSeatTime();
            oResult = tempOrderManager.OrderSeatTimeByOrderID(inOrderID);
            if (oResult.IsSuccess && oResult.Data != null)
            {
                oOrderSeatTime = (COrderSeatTime)oResult.Data;
            }

            g_SeatedTimeLabel.Text = oOrderSeatTime.SeatTime.ToLongTimeString();
            if (oOrderInfo.Status.Equals("Seated"))
            {
                
            }

            g_TableNumberLabel.Text = oOrderInfo.TableNumber.ToString();
            g_GuestQuantityLabel.Text = oOrderInfo.GuestCount.ToString();


            if (oOrderInfo.Status.Equals("Ordered") || oOrderInfo.Status.Equals("Billed"))
            {
                g_OrderedTimeCaptionLabel.Visible = true;
                g_OrderedTimeLabel.Visible = true;
                g_OrderedTimeLabel.Text = oOrderInfo.OrderTime.ToLongTimeString();
            }
        }

        private void g_OKButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}