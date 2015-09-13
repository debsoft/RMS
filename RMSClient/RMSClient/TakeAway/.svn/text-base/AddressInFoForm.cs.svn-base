using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using RMS.Common;
using RMSUI;


namespace RMS
{
    public partial class AddressInFoForm : BaseForm
    {
        public static string m_addressKey = String.Empty;
        private SortedList m_customerAddressList=new SortedList();
        public AddressInFoForm(SortedList p_AddressList)
        {
            m_customerAddressList = p_AddressList;
            InitializeComponent();
        }

        private void AddressInFoForm_Load(object sender, EventArgs e)
        {
            dgvAddressInfo.RowCount = 0;
            try
            {
                foreach (clsCustomerInfo objCustomer in m_customerAddressList.Values)
                {
                    DataGridViewRowCollection dgvRow = (DataGridViewRowCollection)dgvAddressInfo.Rows;
                    dgvRow.Add(objCustomer.ApartmentNumber, objCustomer.HouseNumber, objCustomer.buildingName, objCustomer.StreenName, objCustomer.Town, objCustomer.PostalCode);
                }
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }

        private void dgvAddressInfo_SelectionChanged(object sender, EventArgs e)
        {
            string key = dgvAddressInfo.CurrentRow.Cells[5].Value.ToString().Replace(" ", "").ToUpper()+"-" + dgvAddressInfo.CurrentRow.Cells[0].Value.ToString().Replace(" ", "").ToUpper()+"-" + dgvAddressInfo.CurrentRow.Cells[1].Value.ToString().Replace(" ", "").ToUpper();
            m_addressKey = key;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
