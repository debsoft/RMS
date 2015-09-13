using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Managers.Customer;
using RMS.Common.ObjectModel;
using RMSUI;

namespace RMS.TakeAway
{
    public partial class CustomerListForm : BaseForm
    {
        public static string m_customerName = String.Empty;
        public static string m_phoneNumber = "";
        public static DataTable m_dtCustomerList=new DataTable();

        public CustomerListForm(DataTable p_dtCustomerList)
        {
            InitializeComponent();
            m_phoneNumber = String.Empty;
            m_dtCustomerList = p_dtCustomerList;
        }

        private void CustomerListForm_Activated(object sender, EventArgs e)
        {
            try
            {
                this.ShowData(m_dtCustomerList);
                m_phoneNumber = String.Empty;
               
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }

        /// <summary>
        /// Filling up the records
        /// </summary>
        /// <param name="dtable"></param>
        public void ShowData(DataTable dtable)
            {
                dgvCustomerInfo.RowCount = 0;
                foreach (DataRow drow in dtable.Rows)
                {
                    DataGridViewRowCollection dgvRow = (DataGridViewRowCollection)dgvCustomerInfo.Rows;
                    dgvRow.Add(drow[0].ToString(), drow[1].ToString(), drow[2].ToString());
                }
                dgvCustomerInfo.ClearSelection();
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvCustomerInfo_SelectionChanged(object sender, EventArgs e)
        {
            m_phoneNumber =Convert.ToString(dgvCustomerInfo.CurrentRow.Cells[2].Value);
        }
    }
}
