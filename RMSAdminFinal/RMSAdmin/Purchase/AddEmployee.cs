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
    public partial class AddEmployee : Form
    {
        public AddEmployee()
        {
            InitializeComponent();
        }

        private void addEmployeebutton_Click(object sender, System.EventArgs e)
        {
            if (employeeNametextBox.Text.Length != 0)
            {
                try
                {
                    Employee aEmployee = new Employee();
                    aEmployee.EmployeeName = employeeNametextBox.Text.Replace("'", "''");
                    aEmployee.EmployeeAddress = employeeAddresstextBox.Text.Replace("'", "''");
                    aEmployee.EmployeePId = employeePidtextBox.Text.Replace("'", "''");
                    aEmployee.EmployeePhone = employeePhonetextBox.Text.Replace("'", "''");
                    aEmployee.EmployeePostion = positiontextBox.Text.Replace("'", "''");
                    aEmployee.LastPayDate = DateTime.Now.Date;
                    EmployeeDAO aDao = new EmployeeDAO();
                    string sr = aDao.InsertEmployee(aEmployee);
                
                    MessageBox.Show(sr);
                    if (sr == "Insert Sucessfully")
                    {
                        this.Close();
                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("Please Check Your Input");
                }

            }
            else MessageBox.Show("Please Check Your Input");
        }
    }
}
