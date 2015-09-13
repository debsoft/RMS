using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RMS.Common.ObjectModel;
using System.Collections;
using Managers.SystemManagement;
using RmsRemote;
using RMS.Common;
using Managers.TableInfo;
using Managers.Customer;
using RMSUI;


namespace RMS.TableOrder
{
    public partial class KitchenTextPrintForm : BaseForm
    {
        public string KeyBoardTitleText = "";
        public string PromptLabelText = "";
        public static string Content = "";
        private bool capsLock = false;
        public Int64 m_orderID=0;
        private Button[] buttons;
        private string m_terminalName = "";
        public static string m_initialKitchenText = "";
        private ArrayList m_arrList = null;

        public KitchenTextPrintForm(string p_terminalName)
        {
            InitializeComponent();
            m_terminalName = p_terminalName;
        }

        private void LoadKitchenTextButtons()
        {
            try
            {
                SortedList slKitchenText = new SortedList();
                SystemManager objSystem = new SystemManager();
                CResult objCresult = new CResult();
                objCresult = objSystem.GetAllKitchenText();
                slKitchenText = (SortedList)objCresult.Data;

                int buttonCount = slKitchenText.Count;
                buttons = new  Button[buttonCount];
                int btnCounter = 0;
                foreach (clsKitchenText objKitchenText in slKitchenText.Values)
                {
                    DataGridViewRowCollection dgvRow = (DataGridViewRowCollection)dgvKitchenText.Rows;
                    dgvRow.Add(new object[]{objKitchenText.KitchenText});
                    btnCounter++;
                }
                }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        private void ShowTextButtons()
        {
            //TextButtonPanel.Controls.Clear();
            //for (int buttonCounter = 0; buttonCounter < buttons.Length; buttonCounter++)
            //{
            //    TextButtonPanel.Controls.Add(buttons[buttonCounter]);
            //}

            //TextButtonPanel.VerticalScroll.Value = 70;
        }

        private void KitchenTextClicking_Click(object sender, EventArgs e)
        {

            Button btn = (Button)sender;
            txtKitchenText.Text = btn.Text;

            m_arrList = new ArrayList();
            foreach (Char obj in txtKitchenText.Text)
            {
                m_arrList.Add(obj);
            }
            
        }

        private void SetText(string input)
        {
            try
            {
                if (capsLock)
                {
                    input = input.ToUpper();
                }
            string currentValue = "";
            foreach (char chrCurrent in m_arrList)
            {
                currentValue += chrCurrent;
            }

            txtKitchenText.Text = currentValue + input;
        }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        private void BackSpaceButton_Click(object sender, EventArgs e)
        {
            if (txtKitchenText.Text == null || txtKitchenText.Text.Length<1)
            {
                return;
            }
            try
            {
                m_arrList = new ArrayList();
                foreach (Char obj in txtKitchenText.Text)
                {
                    m_arrList.Add(obj);
                }
                m_arrList.RemoveAt(m_arrList.Count - 1);

                string currentText = "";
                foreach (char o in m_arrList)
                {
                    currentText += o;
                }
                txtKitchenText.Text = currentText;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
                string serialHeader = "";
                string serialFooter = "";
                string serialBody = "";


                if (txtKitchenText.Text == null || txtKitchenText.Text.Length < 1)
                {
                    MessageBox.Show("Please enter kitchen text.", RMSGlobal.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                try
                {
                    if (MessageBox.Show("Do you confirm to send: '" + txtKitchenText.Text + "' at kitchen", RMSGlobal.MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        CCommonConstants oConstant = ConfigManager.GetConfig<CCommonConstants>();
                        COrderManager tempOrderManager = new COrderManager();
                        COrderInfo tempOrderInfo = (COrderInfo)tempOrderManager.OrderInfoByOrderID(m_orderID).Data;

                        CCustomerManager tempCustomerManager = new CCustomerManager();
                        CCustomerInfo tempCustomerInfo = (CCustomerInfo)tempCustomerManager.CustomerInfoGetByCustomerID(tempOrderInfo.CustomerID).Data;
                        string printedText = txtKitchenText.Text;

                        serialBody += "\r\n----------------------------------------";
                        if (tempOrderInfo.OrderType == "Table")
                        {
                            serialBody += "\r\n       TABLE NO: " + tempOrderInfo.TableNumber;
                            serialBody += "\r\n         COVERS: " + tempOrderInfo.GuestCount.ToString();
                        }
                        else
                        {
                            serialBody += "\r\nCUSTOMER NAME: " + tempCustomerInfo.CustomerName;
                            serialBody += "\r\nPHONE: " + tempCustomerInfo.CustomerPhone;

                            if (tempOrderInfo.Status.Equals("Delivery"))
                            {
                                CDelivery objDelivery = new CDelivery();
                                objDelivery.DeliveryOrderID = m_orderID;
                                CResult objDeliveryInfo = tempOrderManager.GetDeliveryInfo(objDelivery);
                                objDelivery = (CDelivery)objDeliveryInfo.Data;

                                serialBody += "\r\nDELIVERY TIME:" + objDelivery.DeliveryTime;
                            }
                        }
                        serialBody += "\r\n----------------------------------------";
                        serialBody += "\r\n       TIME:" + DateTime.Now.ToString("hh:m tt");

                        serialBody += "\r\n----------------------------------------";
                        serialBody += "\r\n" + printedText.ToUpper();
                        serialBody += "\r\n----------------------------------------";
                        serialBody += "\r\nWaiter:" + RMSGlobal.LoginUserName;
                        serialBody += "\r\n" + m_terminalName;


                        CPrintingFormat tempPrintingFormat = new CPrintingFormat();
                        tempPrintingFormat.Header = serialHeader;
                        tempPrintingFormat.Body = serialBody;
                        tempPrintingFormat.Footer = serialFooter;

                        tempPrintingFormat.PrintType = (int)PRINTER_TYPES.Serial;

                        CLogin oLogin = new CLogin();
                        oLogin = (RmsRemote.CLogin)Activator.GetObject(typeof(RmsRemote.CLogin), oConstant.RemoteURL);
                        oLogin.PostPrintingRequest(tempPrintingFormat);

                        tempOrderManager.SaveOrderKitchenText(m_orderID, txtKitchenText.Text,1);

                        this.DialogResult = DialogResult.OK;
                    }
                }
                catch (Exception exp)
                {
                    throw exp;
                }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtKitchenText.Clear();
        }

        private void KitchenTextPrintForm_Load(object sender, EventArgs e)
        {
            this.LoadKitchenTextButtons();
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            COrderManager tempOrderManager = new COrderManager();
            tempOrderManager.SaveOrderKitchenText(m_orderID,txtKitchenText.Text,0);
            this.Close();
        }

        private void txtKitchenText_TextChanged(object sender, EventArgs e)
        {
            m_arrList = new ArrayList();
            foreach (Char obj in txtKitchenText.Text)
            {
                m_arrList.Add(obj);
            }
           
        }

        private void KitchentextKeyBoard_UserKeyPressed(object sender, IbacsTouchScreenKeyBoard.KeyBoard.KeyboardEventArgs e)
        {
            txtKitchenText.Focus();
            SendKeys.Send(e.KeyboardKeyPressed);
        }

        private void dgvKitchenText_SelectionChanged(object sender, EventArgs e)
        {
            string kitchenText =Convert.ToString(dgvKitchenText.CurrentRow.Cells[0].Value);
            txtKitchenText.Text = kitchenText;
        }
    }
}
