using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Managers.Customer;
using Managers.GManager;
using RMS.DataAccess;
using RMSUI;
using RMS.Common;
using RMS.Common.ObjectModel;
using Managers.SystemManagement;

namespace RMS.Reports
{
    public partial class OrderDetails : Form
    {
        private string strGuestBill = "";
        CPrintMethodsEXT cPrintMethodsEXT;
        CSearchOrderInfo tempSearchOrderInfo = new CSearchOrderInfo();
        public int orderID;
        public int customerId;
        private EFTCardManager eFTCardManager = new EFTCardManager();
        public OrderDetails()
        {
            InitializeComponent();
            
        }

        public OrderDetails(CSearchOrderInfo cSearchOrderInfo, int cID)
        {
            InitializeComponent();
            //MessageBox.Show(orderID);
            tempSearchOrderInfo = new CSearchOrderInfo();
            tempSearchOrderInfo = cSearchOrderInfo;

            orderID = (int)cSearchOrderInfo.OrderID;
            customerId = cID;

            lelOrderID.Text += cSearchOrderInfo.OrderID;
            this.showOrderDetails(cSearchOrderInfo.OrderID.ToString());

            lelOrderInfo.Text += "Serial no :" + cSearchOrderInfo.SerialNumber;
            lelOrderInfo.Text += "\r\nOrder Date: " +cSearchOrderInfo.OrderDateTime.ToString();
            lelOrderInfo.Text += "\r\nOrder Type: " + cSearchOrderInfo.OrderType;
            lelOrderInfo.Text += "\r\nCovers: " + cSearchOrderInfo.Covers;

            label2.Text = "Food Price: " + cSearchOrderInfo.FoodTotal.ToString("F02");
            label2.Text += "\r\nNonFood Price: " + cSearchOrderInfo.NonfoodTotal.ToString("F02");
            label2.Text += "\r\nOrder Total: " + cSearchOrderInfo.OrderTotal.ToString("F02");
            label2.Text += "\r\nService Charge: " + cSearchOrderInfo.ServiceChargeCash.ToString("F02");
            label2.Text += "\r\nDiscount Charge: " + cSearchOrderInfo.Discount.ToString("F02");
           
            label3.Text = "Total Paid (ExVat): " + cSearchOrderInfo.TotalPaidExcludingVat.ToString("F02");
            label3.Text += "\r\nTotal Paid (IncVat): " + cSearchOrderInfo.TotalPaidIncludingVat.ToString("F02");
            label3.Text += "\r\nVat Total: " + cSearchOrderInfo.VatPaid.ToString("F02");
            label3.Text += "\r\nVat Impsed: " + cSearchOrderInfo.VatImposed;
            label3.Text += "\r\nCash: " + cSearchOrderInfo.CashPaid.ToString("F02");
            label3.Text += "\r\nEFT: " + cSearchOrderInfo.EFTPaid.ToString("F02");
            label3.Text += "\r\nDUE BILL: " + cSearchOrderInfo.DueBill.ToString("F02");
            label3.Text += "\r\nEFT Card Name: " + cSearchOrderInfo.EFTCardName;

            strGuestBill = cSearchOrderInfo.GuestBill + "\r\n\r\nPrinted from archive\r\n";
            cPrintMethodsEXT = new CPrintMethodsEXT();
           
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void showOrderDetails(string orderID)
        {            
            SystemManager sysManager = new SystemManager();
            List<CArchiveItemDetails> oItemList = new List<CArchiveItemDetails>();
            int p_orderID = int.Parse(orderID);
            oItemList = sysManager.GetOrderDetailInfo(p_orderID);

            DataTable dtResult = new DataTable();
            dtResult.Columns.Add("Item name", typeof(string));
            dtResult.Columns.Add("Quantity", typeof(int));
            dtResult.Columns.Add("Amount", typeof(double));
            dtResult.Columns.Add("Remarks", typeof(string));
            dtResult.Columns.Add("Food type", typeof(string));
           // dtResult.Columns.Add("Table name", typeof(string));
           // dtResult.Columns.Add("Guest no", typeof(int));
            dtResult.Columns.Add("Order time", typeof(DateTime));
            dtResult.Columns.Add("Order taken by", typeof(string));

            for (int i = 0; i < oItemList.Count; i++)
            {
                dtResult.Rows.Add(oItemList[i].ItemName, 
                    oItemList[i].Quantity,
                    oItemList[i].Amount,
                    oItemList[i].Remarks,
                    oItemList[i].FoodType,
                    //oItemList[i].TableName,
                    //oItemList[i].GuestCount, 
                    new DateTime(Int64.Parse(oItemList[i].ItemOrderTime.ToString())),
                    oItemList[i].UserName);
            }

            dgvOrderDetails.DataSource = dtResult;

            
        }

        private void btnPrintGuestBill_Click(object sender, EventArgs e)
        {
            // FOr Small Received Printer
            cPrintMethodsEXT.USBPrint(strGuestBill, PrintDestiNation.CLIENT, true);

            //For A5 report print 
       //     int papersize = 70;
         //   cPrintMethodsEXT.USBPrintA5Report(strGuestBill, PrintDestiNation.CLIENT, true, papersize);
        }

        private void duebillPaymentButton_Click(object sender, EventArgs e)
        {

            if (tempSearchOrderInfo.DueBill > 0)
            {

                DueBillPaymentForm aDueBillPaymentForm = new DueBillPaymentForm();
                aDueBillPaymentForm.ShowDialog();

                double amount = 0.0;

                if (DueBillPaymentForm.inputResult.Equals("Cancel"))
                    return;

                string amt = DueBillPaymentForm.inputResult.Substring(Program.currency.Length);

                if (Convert.ToDouble(amt) == 0.00)
                {
                    CMessageBox tempMessageBox = new CMessageBox("Error!", "Price cannot be zero.");
                    tempMessageBox.ShowDialog();
                    return;
                }
                amount = Convert.ToDouble(amt);



                string paymentmethod = "";
                string cardName = "";
                PaymentMethod aPaymentMethod = new PaymentMethod();
                aPaymentMethod.ShowDialog();
                paymentmethod = PaymentMethod.inputResult;


                if (paymentmethod == "Card")
                {
                    EFTOptionForm eFTOptionForm = new EFTOptionForm();

                    DialogResult dr = eFTOptionForm.ShowDialog();

                    if (dr == DialogResult.Cancel)
                        return;

                    saveEFTCardAgainsOrderid(EFTOptionForm.seletedEFTCard);
                }

                PaymentDueBill aPaymentDueBill = new PaymentDueBill();
                CPayment aPayment = new CPayment();
                aPayment.OrderID = orderID;

                double tempamount = 0;
                if (amount - tempSearchOrderInfo.DueBill >= 0)
                {
                    tempamount = tempSearchOrderInfo.DueBill;
                }
                else if (tempSearchOrderInfo.DueBill - amount > 0)
                {
                    tempamount = amount;
                }
                if (paymentmethod == "Cash")
                {
                    aPayment.CashAmount = tempamount;
                    aPayment.EFTAmount = 0;
                    aPaymentDueBill.CashAmount = tempamount;
                }

                else if (paymentmethod == "Card")
                {
                    aPayment.EFTAmount = tempamount;
                    aPayment.CashAmount = 0;
                    aPaymentDueBill.CardAmount = tempamount;

                }
                aPayment.ChequeAmount = tempSearchOrderInfo.DueBill - tempamount;
                aPaymentDueBill.PaymentDate = DateTime.Now;

                CPaymentDAO aPaymentDao = new CPaymentDAO();
                string sr = aPaymentDao.UpdatePaymentForDueBill(aPayment, aPaymentDueBill);
                MessageBox.Show(sr);
                this.Close();
            }
            else
            {
                MessageBox.Show("Due Bill Must be greater than zero");
            }

        }

       


        private void saveEFTCardAgainsOrderid(EFTCard eftCard)
        {


            if (eFTCardManager.AllReadyExiste(orderID))
            {
                eFTCardManager.UpdateEFTPaymentByOrderID(orderID, eftCard.Id, eftCard.CardName);
            }
            else
            {

                eFTCardManager.InsertEFTPayment(orderID, eftCard.Id, eftCard.CardName);
            }


        }


    }
}
