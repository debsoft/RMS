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
    public partial class UpdateEmployee : Form
    {
        public int EmployyId { set; get; }

        public UpdateEmployee()
        {
            InitializeComponent();
        }

        private void UpdateEmployeebutton_Click(object sender, EventArgs e)
        {
            if (employeeNametextBox.Text.Length != 0)
            {
                try
                {
                    Employee aEmployee = new Employee();
                    aEmployee.EmployeeId = EmployyId;
                    aEmployee.EmployeeName = employeeNametextBox.Text.Replace("'", "''");
                    aEmployee.EmployeeAddress = employeeAddresstextBox.Text.Replace("'", "''");
                    aEmployee.EmployeePId = "123";
                    aEmployee.EmployeePhone = employeePhonetextBox.Text.Replace("'", "''");
                    aEmployee.EmployeePostion = positiontextBox.Text.Replace("'", "''");
                   // aEmployee.LastPayDate = DateTime.Now.Date;
                    EmployeeDAO aDao = new EmployeeDAO();
                    string sr = aDao.UpdateEmployee(aEmployee);

                    MessageBox.Show(sr);
                    if (sr == "Update Sucessfully")
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
