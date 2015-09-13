using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RMS.Common;
using RMS.Common.ObjectModel;
using RMS.DataAccess;
using RMS.Common.Constants;

namespace RMS.TableOrder
{
    public partial class WaiterForm : Form
    {

        public static string m_DeliveryChargeType = "Fixed";
        public static double m_DeliveryChargeAmount = 0.000;

        private List<CUserInfo> userList = new List<CUserInfo>();

        public List<CUserInfo> UserList
        {
            set { userList = value; }
        }
       // private DeliverySettingDAO deliverySettingDAO = new DeliverySettingDAO();

        private CUserInfo userInfo = new CUserInfo();

        public CUserInfo UserInfoData
        {
            get { return userInfo; }
        }

        public WaiterForm()
        {
            InitializeComponent();
        }

        private void btnFixed_1_Click(object sender, EventArgs e)
        {
            m_DeliveryChargeType = "Fixed";
            m_DeliveryChargeAmount = 1.00;
            this.Close();
        }

        private void btnFixed_105_Click(object sender, EventArgs e)
        {
            m_DeliveryChargeType = "Fixed";
            m_DeliveryChargeAmount = 1.50;
            this.Close();
        }

        private void btnFixed_2_Click(object sender, EventArgs e)
        {
            m_DeliveryChargeType = "Fixed";
            m_DeliveryChargeAmount = 2.00;
            this.Close();
        }

        private void btnFixed_250_Click(object sender, EventArgs e)
        {
            m_DeliveryChargeType = "Fixed";
            m_DeliveryChargeAmount = 2.50;
            this.Close();
        }

        private void btnFixed_3_Click(object sender, EventArgs e)
        {
            m_DeliveryChargeType = "Fixed";
            m_DeliveryChargeAmount = 3.00;
            this.Close();
        }

        private void btnFixed_350_Click(object sender, EventArgs e)
        {
            m_DeliveryChargeType = "Fixed";
            m_DeliveryChargeAmount = 3.50;
            this.Close();
        }

        private void btnFixed_4_Click(object sender, EventArgs e)
        {
            m_DeliveryChargeType = "Fixed";
            m_DeliveryChargeAmount = 4.00;
            this.Close();
        }

        private void btnFixed_450_Click(object sender, EventArgs e)
        {
            m_DeliveryChargeType = "Fixed";
            m_DeliveryChargeAmount = 4.50;
            this.Close();
        }

        private void btnFixed_5_Click(object sender, EventArgs e)
        {
            m_DeliveryChargeType = "Fixed";
            m_DeliveryChargeAmount = 5.00;
            this.Close();
        }

        private void btnFixed_550_Click(object sender, EventArgs e)
        {
            m_DeliveryChargeType = "Fixed";
            m_DeliveryChargeAmount = 5.50;
            this.Close();
        }

        private void PercentButton_Click(object sender, EventArgs e)
        {
            CCalculatorForm tempPriceCalculator = new CCalculatorForm("Set Charge", "Enter charge in percentage");
            tempPriceCalculator.ShowDialog();

            if (CCalculatorForm.inputResult.Equals("Cancel"))
                return;

            Double.TryParse(CCalculatorForm.inputResult, out m_DeliveryChargeAmount);
            m_DeliveryChargeType = "Percent";
            this.Close();
        }

        private void FixedAmountButton_Click(object sender, EventArgs e)
        {
            CPriceCalculatorForm tempPriceCalculator = new CPriceCalculatorForm("Set Charge", "Enter charge in exact amount");
            tempPriceCalculator.ShowDialog();

            if (CPriceCalculatorForm.inputResult.Equals("Cancel"))
                return;

            Double.TryParse(CPriceCalculatorForm.inputResult, out m_DeliveryChargeAmount);
            m_DeliveryChargeType = "Fixed";
            this.Close();
        }

        private void g_CancelButton_Click(object sender, EventArgs e)
        {
            m_DeliveryChargeType = "Cancel";
            this.Close();
        }

        /// <summary>
        /// EFTCardButton insted use another Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void DeliveryChargeAmountForm_Load(object sender, EventArgs e)
        {
            foreach (CUserInfo user in userList)
            {
                if (user.Type == CUserConstant.GetUSerConstant("WAITER"))
                {
                    EFTCardButton cardButton = new EFTCardButton();
                    cardButton.CardID = user.UserID;
                    cardButton.Text = user.UserName;
                    cardButton.DialogResult = DialogResult.OK;
                    cardButton.Click += new EventHandler(cardButton_Click);
                    flowLayoutPanel1.Controls.Add(cardButton);
                }
            }
        }

        void cardButton_Click(object sender, EventArgs e)
        {
           // userInfo.DeliverySettingAmount = Convert.ToDouble("0" + ((EFTCardButton)sender).Text);
            userInfo.UserID = ((EFTCardButton)sender).CardID;
            var data = (from c in userList where c.UserID == userInfo.UserID select (c)).FirstOrDefault();
            userInfo = data;
            this.DialogResult = DialogResult.OK;      
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
}
