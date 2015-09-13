using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using RMS.Common.ObjectModel;
using Managers.TableInfo;

namespace RMS
{
    public partial class TableInformationControl : UserControl
    {
        public Int64 m_orderID = 0;
        public Form m_previousForm = null;
        private List<OrderLogInformation> m_objOrderLog = new List<OrderLogInformation>();
        private List<OrderLogInformation> m_objKitchenTextInfo = new List<OrderLogInformation>();

        public TableInformationControl(Int64 orderID, Form preForm, List<OrderLogInformation> objOrderLogInfo)
        {
            InitializeComponent();
            m_orderID = orderID;
            m_previousForm = preForm;
            m_objOrderLog = objOrderLogInfo;
        }

        private void TableInformationControl_Load(object sender, EventArgs e)
        {
            string[] ktArr = new string[0];
            string kitchenText = String.Empty;
            this.FillBasciInfo();
            int localCounter = 0;
            for (int recordCounter = 0; recordCounter < m_objOrderLog.Count; recordCounter++)
            {
                if (localCounter == 0) //For first items
                {
                    if (m_objOrderLog[recordCounter].FirstOrderTakenTime > 0)
                    {
                        DateTime dt = new DateTime(m_objOrderLog[recordCounter].FirstOrderTakenTime);
                        lblFirstOrderTime.Text = dt.ToString("hh:mm tt") + " (" + m_objOrderLog[recordCounter].UserName + ")";
                    }
                    else
                    {
                        lblFirstOrderTime.Text = "No order";
                    }

                    if (m_objOrderLog[recordCounter].FirstOrderPrintTime > 0)
                    {
                        DateTime dt = new DateTime(m_objOrderLog[recordCounter].FirstOrderPrintTime);
                        lblFirstKitchen.Text = dt.ToString("hh:mm tt");
                    }
                    else
                    {
                        lblFirstKitchen.Text = "N/A";
                    }
                }
                else
                {
                    if (m_objOrderLog[recordCounter].FirstOrderTakenTime > 0)
                    {
                        DateTime dt = new DateTime(m_objOrderLog[recordCounter].FirstOrderTakenTime);
                        lblLastOrdertime.Text = dt.ToString("hh:mm tt") + " (" + m_objOrderLog[recordCounter].UserName + ")";
                    }
                    else
                    {
                        lblLastOrdertime.Text = "No order";
                    }

                    if (m_objOrderLog[recordCounter].FirstOrderPrintTime > 0)
                    {
                        DateTime dt = new DateTime(m_objOrderLog[recordCounter].FirstOrderPrintTime);
                        lblLastKitchen.Text = dt.ToString("hh:mm tt");
                    }
                    else
                    {
                        lblLastKitchen.Text = "N/A";
                    }
                }

                if (m_objOrderLog[recordCounter].BillPrintStatus > 1)
                {
                    lblGuestBillPrintStatus.Text = "Printed";
                }
                else
                {
                    lblGuestBillPrintStatus.Text = "Not Printed";
                }
               
                 //kitchenText = m_objOrderLog[recordCounter].KitchenText; //Taking the kitchen text
                localCounter++;
            }
            ShowKitchenText();
        }

        private void ShowKitchenText()
        {
            COrderManager tempOrderManager = new COrderManager();
            CResult objKitchenText = tempOrderManager.GetKitchenTextByOrderID(m_orderID);
            List<OrderLogInformation> tempOrderLogInfoList = new List<OrderLogInformation>();
            tempOrderLogInfoList = (List<OrderLogInformation>)objKitchenText.Data;
            string kitchenTextatKitchen = "";
            string kitchennotatKitchen = "";

            for (int recordCounter = 0; recordCounter < tempOrderLogInfoList.Count; recordCounter++)
            {
                if (tempOrderLogInfoList[recordCounter].KitchenTextPrintStatus > 0)
                {
                    kitchenTextatKitchen += "=> " + tempOrderLogInfoList[recordCounter].KitchenText + "\r\n";
                }
                else
                {
                    kitchennotatKitchen += "=> " + tempOrderLogInfoList[recordCounter].KitchenText + "\r\n";
                }
            }

            if (kitchennotatKitchen.Length > 0)
            {
                txtKitchenText.Text = kitchennotatKitchen;
                lblKitchen.Visible = true;
            }
            if (kitchenTextatKitchen.Length > 0)
            {
                txtKitchenTextSent.Text = kitchenTextatKitchen;
                lblKitchenTextSent.Visible = true;
            }
        }


        private void FillBasciInfo()
        {
            COrderManager tempOrderManager = new COrderManager();
            CResult oResult = tempOrderManager.OrderInfoByOrderID(m_orderID);
            COrderInfo oOrderInfo = new COrderInfo();
            if (oResult.IsSuccess && oResult.Data != null)
            {
                oOrderInfo = (COrderInfo)oResult.Data;
            }

            COrderSeatTime oOrderSeatTime = new COrderSeatTime();
            oResult = tempOrderManager.OrderSeatTimeByOrderID(m_orderID);
            if (oResult.IsSuccess && oResult.Data != null)
            {
                oOrderSeatTime = (COrderSeatTime)oResult.Data;
            }

            lblSeatTime.Text = oOrderSeatTime.SeatTime.ToString("hh:mm tt");
            
            lblTableNumber.Text = oOrderInfo.TableNumber.ToString("00");
            lblGuestQuantity.Text = oOrderInfo.GuestCount.ToString("00");
        }
    }
}
