using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common.ObjectModel;
using Database;

namespace RMSAdmin.Purchase
{
    public partial class SalaryForm : Form
    {
        public SalaryForm()
        {
            InitializeComponent();
            LoadDataGridView();
        }

        private void LoadDataGridView()
        {
           EmployeeDAO aEmployeeDao=new EmployeeDAO();
           List<Employee> aEmployees=new List<Employee>();
            aEmployees = aEmployeeDao.GetAllEmployee();
            employeedataGridView.DataSource = aEmployees;
        }

        private void addemployeebutton_Click(object sender, EventArgs e)
        {
            AddEmployee aForm=new AddEmployee();
            aForm.ShowDialog();
            LoadDataGridView();
        }

        private void employeeNametextBox_TextChanged(object sender, EventArgs e)
        {
            if (employeeNametextBox.Text == "" || string.IsNullOrEmpty(employeeNametextBox.Text))
            {
                LoadDataGridView();
            }
            else
            {
                EmployeeDAO aEmployeeDao = new EmployeeDAO();
                List<Employee> aEmployees = new List<Employee>();
                aEmployees = aEmployeeDao.GetAllEmployee();
                List<Employee> aaEmployees = (from myRow in aEmployees.AsEnumerable()
                                              where myRow.EmployeeName.ToUpper().StartsWith(employeeNametextBox.Text.ToUpper())
                                       select myRow).ToList();
                // DataView view = results.AsDataView();
                employeedataGridView.DataSource = aaEmployees;
            }

        }

        private void findemployeebutton_Click(object sender, EventArgs e)
        {
            if (employeeNametextBox.Text == "" || string.IsNullOrEmpty(employeeNametextBox.Text))
            {
                LoadDataGridView();
            }
            else
            {
                EmployeeDAO aEmployeeDao = new EmployeeDAO();
                List<Employee> aEmployees = new List<Employee>();
                aEmployees = aEmployeeDao.GetAllEmployee();
                List<Employee> aaEmployees = (from myRow in aEmployees.AsEnumerable()
                                              where myRow.EmployeeName.ToUpper().StartsWith(employeeNametextBox.Text.ToUpper())
                                              select myRow).ToList();
                // DataView view = results.AsDataView();
                employeedataGridView.DataSource = aaEmployees;
            }
        }

        private void employeedataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            try
            {

                if (e.ColumnIndex == 9) //when paid
                {
                    PaidSalaryForm aForm = new PaidSalaryForm();
                    aForm.EmployeeId = Convert.ToInt32("0" + employeedataGridView.Rows[e.RowIndex].Cells["EmployeeId"].Value);
                    aForm.employeeNamelabel.Text = (employeedataGridView.Rows[e.RowIndex].Cells["EmployeeName"].Value).ToString();
                    aForm.ShowDialog();
                    LoadDataGridView();
                }
                if (e.ColumnIndex == 10) //when update
                {
                    UpdateEmployee aForm = new UpdateEmployee();
                    aForm.EmployyId = Convert.ToInt32("0" + employeedataGridView.Rows[e.RowIndex].Cells["EmployeeId"].Value);
                    aForm.employeeNametextBox.Text = (employeedataGridView.Rows[e.RowIndex].Cells["EmployeeName"].Value).ToString();
                    aForm.employeePhonetextBox.Text = (employeedataGridView.Rows[e.RowIndex].Cells["EmployeePhone"].Value).ToString();
                    aForm.employeeAddresstextBox.Text = (employeedataGridView.Rows[e.RowIndex].Cells["EmployeeAddress"].Value).ToString();
                    aForm.positiontextBox.Text = (employeedataGridView.Rows[e.RowIndex].Cells["EmployeePostion"].Value).ToString();
                    aForm.employeePidtextBox.Text = (employeedataGridView.Rows[e.RowIndex].Cells[4].Value).ToString();
                    aForm.ShowDialog();
                    LoadDataGridView();
                }
         

                if (e.ColumnIndex == 11) //when delete
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure want to delete it?", "Alert!", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        EmployeeDAO aEmployeeDao = new EmployeeDAO();
                        string sr = aEmployeeDao.EmployeeDeleted(Convert.ToInt32("0" + employeedataGridView.Rows[e.RowIndex].Cells[0].Value));
                        MessageBox.Show(sr);
                        LoadDataGridView();
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        //do something else
                    }
                }


            }
            catch (Exception)
            {


            }
        }
    }
}
