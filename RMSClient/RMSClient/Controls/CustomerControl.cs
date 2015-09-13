using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Managers.Customer;
using RMS.Common.ObjectModel;
using Managers.TableInfo;
using RMS.TakeAway;
using RMS.Common;

namespace RMS
{
    public partial class CustomerControl : UserControl
    {
        public Int64 m_orderID = 0;
        public Form m_previousForm = null;
        private List<OrderLogInformation> m_objOrderLog=new List<OrderLogInformation>();

        public CustomerControl(Int64 orderID,Form preForm,List<OrderLogInformation> objOrderLogInfo)
        {
            InitializeComponent();
            m_orderID = orderID;
            m_previousForm = preForm;
            m_objOrderLog = objOrderLogInfo;
        }

        private void CustomerControl_Load(object sender, EventArgs e)
        {
            string[] ktArr = new string[0];
            CCustomerManager tempCustomerManager = new CCustomerManager();
            CCustomerInfo tempCustomerInfo = new CCustomerInfo();
            CResult oResult = tempCustomerManager.GetCustomerTakeawayInfo(m_orderID);
            tempCustomerInfo = (CCustomerInfo)oResult.Data;
            string kitchenText = String.Empty;

            if (tempCustomerInfo.CustomerID > 0)
            {
                lblName.Text = tempCustomerInfo.CustomerName;
                if (tempCustomerInfo.CustomerPhone.Length > 0)
                {
                    lblPhone.Text = tempCustomerInfo.CustomerPhone;
                }
                if (tempCustomerInfo.CustomerTown.Length > 0)
                {
                    lblTown.Text = tempCustomerInfo.CustomerTown;
                }

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
                            lblFirstOrderTime.Text = "No order.";
                        }

                        if (m_objOrderLog[recordCounter].FirstOrderPrintTime > 0)
                        {
                            DateTime dt = new DateTime(m_objOrderLog[recordCounter].FirstOrderPrintTime);
                            lblFirstKitchen.Text = dt.ToString("hh:mm tt");
                        }
                        else
                        {
                            lblFirstKitchen.Text = "Not printed";
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
                            lblLastOrdertime.Text = "No order.";
                        }

                        if (m_objOrderLog[recordCounter].FirstOrderPrintTime > 0)
                        {
                            DateTime dt = new DateTime(m_objOrderLog[recordCounter].FirstOrderPrintTime);
                            lblLastKitchen.Text = dt.ToString("hh:mm tt");
                        }
                        else
                        {
                            lblLastKitchen.Text = "Not printed";
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
                    localCounter++;
                }
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


        private void btnEditCustomer_Click(object sender, EventArgs e)
        {
            //For modifying the customer information
            COrderManager tempOrderManager = new COrderManager();
            CResult objCresult = new CResult();
            objCresult = tempOrderManager.OrderInfoByOrderID(m_orderID);

            CDelivery objDeliveryTime = new CDelivery(); //Collecting the delivery information of the order
            objDeliveryTime.DeliveryOrderID = m_orderID;
            CResult objDeliveryInfo = tempOrderManager.GetDeliveryInfo(objDeliveryTime);
            objDeliveryTime = (CDelivery)objDeliveryInfo.Data;

            COrderInfo tempOrderInfo = (COrderInfo)objCresult.Data;
            CTakeAwayForm objTakeawayFrm = new CTakeAwayForm(m_orderID, objDeliveryTime, tempOrderInfo.Status, true);
            objTakeawayFrm.Show();
            CFormManager.Forms.Push(m_previousForm);
            this.Hide();
        }
    }
}
