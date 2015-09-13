using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RMSUI;

namespace RMS.Common
{
    public partial class CCategory4Form : Form
    {

        private String m_sTitle = "Title";
        public static CCategoryButton m_cbResult;
        public static int ItemQTY = 1;

        public CCategory4Form()
        {
            InitializeComponent();
        }

        public CCategory4Form(Int64 inOrderID,List<CCategoryButton> inCategory4ButtonList,String inTitle)
        {
            InitializeComponent();
            this.Title = inTitle+" Choose Between";

            for (int categoryButtonCounter = 0; categoryButtonCounter < inCategory4ButtonList.Count; categoryButtonCounter++)
            {
                inCategory4ButtonList[categoryButtonCounter].Click+=new EventHandler(Category4Button_Click);
                g_Category4Panel.Controls.Add(inCategory4ButtonList[categoryButtonCounter]);
            }
        }

        private void Category4Button_Click(object sender, EventArgs e)
        {
            try
            {
                CCalculatorForm tempCalculatorForm = new CCalculatorForm("Order Quantity", "Item Quantity");
                tempCalculatorForm.ShowDialog();

                if (!CCalculatorForm.inputResult.Equals("Cancel"))
                {

                   string str=CCalculatorForm.inputResult;
                   if (str == "")
                   {
                       str = "1";
                   }

                   if (Int32.Parse(str) == 0)
                    {
                        CMessageBox tempMessageBox = new CMessageBox("Error", "Input invalid!");
                        tempMessageBox.ShowDialog();
                        return;
                    }
                    else {

                        int tempOrderedQty = Int32.Parse(str);
                        ItemQTY = tempOrderedQty;
                        m_cbResult = (CCategoryButton)sender;
                        this.Close();

                    }

                  
                }


            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, RMSGlobal.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            
          
        }

        public String Title
        {
            get { return m_sTitle; }
            set { m_sTitle = value; this.Text = m_sTitle; }
        }

        private void g_CancelButton_Click(object sender, EventArgs e)
        {
            m_cbResult = null;
            this.Close();
        }
    }
}