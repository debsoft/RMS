using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RMS.Common
{
    public partial class SpiltBillItemWise : Form
    {
        private Int64 m_iOrderID;
        private String m_sTableType;
        private DataTable m_dtItemList = new DataTable();
        private DataTable m_dtSecondList = new DataTable();

        private DataTable m_dtThirdList = new DataTable();

        private Double m_dTotalAmount = 0;
        private Double m_dDiscount = 0;

        public SpiltBillItemWise(Int64 inOrderID, Double inTotalAmount, Double inDiscount, String inTableType, DataTable inItemList)
        {
            InitializeComponent();
            m_iOrderID = inOrderID;
            m_sTableType = inTableType;
            m_dtItemList = inItemList;
            m_dTotalAmount = inTotalAmount;
            m_dDiscount = inDiscount;
            m_dtSecondList = new DataTable();
            m_dtSecondList.Columns.Add("Item");
            m_dtSecondList.Columns.Add("Qty");
            m_dtSecondList.Columns.Add("Price");

            //m_dtThirdList = new DataTable();
            //m_dtThirdList.Columns.Add("Price");



            try
            {
                for (int rowIndex = 0; rowIndex < m_dtItemList.Rows.Count; rowIndex++)
                {
                    String ListBoxItem = "";
                    // String Mybox = "";

                    ListBoxItem = m_dtItemList.Rows[rowIndex]["Qty"].ToString() + "-";

                    ListBoxItem += m_dtItemList.Rows[rowIndex]["Item"].ToString();
                    ListBoxItem += "-";
                    ListBoxItem += m_dtItemList.Rows[rowIndex]["Price"].ToString();

                    g_PrintBill1ListBox.Items.Add(ListBoxItem);

                    //Mybox += m_dtItemList.Rows[rowIndex]["Price"].ToString();
                    //g_PrintBill1ListBox.Items.Add(Mybox);


                }



            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        private void g_RightAddButton_Click(object sender, EventArgs e)
        {
            try
            {

                if (g_PrintBill1ListBox.SelectedItem != null)
                {
                    ///Modify DataTable

                    DataRow tempDataRow = m_dtItemList.Rows[g_PrintBill1ListBox.SelectedIndex];


                    DataRow temp2DataRow = m_dtSecondList.NewRow();
                    // DataRow temp3Datarow = m_dtThirdList.NewRow();


                    temp2DataRow[0] = tempDataRow[0];
                    temp2DataRow[1] = tempDataRow[1];
                    temp2DataRow[2] = tempDataRow[2];

                    //tempDataRow.ItemArray.CopyTo(temp2DataRow.ItemArray, 0);

                    m_dtItemList.Rows.Remove(tempDataRow);

                    m_dtSecondList.Rows.Add(temp2DataRow);

                    g_PrintBill2ListBox.Items.Add(g_PrintBill1ListBox.SelectedItem);

                    g_PrintBill1ListBox.Items.Remove(g_PrintBill1ListBox.SelectedItem);



                }

            }
            catch (Exception exp)
            {
                throw exp;
            }

            g_PrintGuestBillButton.Enabled = true;
            btnGuestBillByCover.Enabled = false;
        }

        private void g_LeftAddButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (g_PrintBill2ListBox.SelectedItem != null)
                {
                    ///Modify DataTable
                    DataRow tempDataRow = m_dtSecondList.Rows[g_PrintBill2ListBox.SelectedIndex];

                    DataRow temp2DataRow = m_dtItemList.NewRow();


                    temp2DataRow[0] = tempDataRow[0];
                    temp2DataRow[1] = tempDataRow[1];
                    temp2DataRow[2] = tempDataRow[2];
                    ///tempDataRow.ItemArray.CopyTo(temp2DataRow.ItemArray, 0);

                    m_dtSecondList.Rows.Remove(tempDataRow);
                    m_dtItemList.Rows.Add(temp2DataRow);
                    ///


                    g_PrintBill1ListBox.Items.Add(g_PrintBill2ListBox.SelectedItem);
                    g_PrintBill2ListBox.Items.Remove(g_PrintBill2ListBox.SelectedItem);
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
    }
}
