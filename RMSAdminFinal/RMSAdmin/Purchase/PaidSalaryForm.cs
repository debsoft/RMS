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
    public partial class PaidSalaryForm : Form
    {
        public int EmployeeId { set; get; }
       private double Payablesalary = 0.0;
       private double Totalpayablesalary = 0.0;

        public PaidSalaryForm()
        {
            InitializeComponent();
            monthcomboBox.SelectedIndex = 0;
            yearcomboBox.SelectedIndex = 0;
        }

        private void paidbutton_Click(object sender, EventArgs e)
        {
            if(totalPayableSalarytextBox.Text.Length!=0)
            {
                try
                {
                    Employee aEmployee=new Employee();
                    aEmployee.EmployeeId = EmployeeId;
                    aEmployee.LastPaidAmount = Convert.ToDouble(totalPayableSalarytextBox.Text);
                    EmployeeDAO aDao=new EmployeeDAO();
                    string sr = aDao.UpdateAmount(aEmployee);
                    if (sr == "Update Sucessfully")
                    {
                        SalaryTransaction aSalaryTransaction=new SalaryTransaction();
                        aSalaryTransaction.EmployeeId = EmployeeId;
                        aSalaryTransaction.WorkingDay = Convert.ToInt32("0" + workingdaystextBox.Text);
                        aSalaryTransaction.AttendingDay = Convert.ToInt32("0" + attendingtextBox.Text);
                        aSalaryTransaction.Salary = Convert.ToDouble("0" + salarystructuretextBox.Text);
                        aSalaryTransaction.DeductedSalary = Convert.ToDouble("0" + deductedsalarytextBox.Text);
                        aSalaryTransaction.PayableSalary = Convert.ToDouble("0" + payablesalarytextBox.Text);
                        aSalaryTransaction.ServiceCharge = Convert.ToDouble("0" + servicechargetextBox.Text);
                        aSalaryTransaction.FoodAndRoomAllowance = Convert.ToDouble("0" + foodAndRoomtextBox.Text);
                        aSalaryTransaction.TotalPayableSalary = Convert.ToDouble("0" +totalPayableSalarytextBox.Text);
                        aSalaryTransaction.Remarks =  remarkstextBox.Text;
                        aDao.InsertPaidAmountReport(aSalaryTransaction,monthcomboBox.Text, yearcomboBox.Text);
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

        private void deductedsalarytextBox_TextChanged(object sender, EventArgs e)
        {

            TotalSalaryCalculation();
            //if (!deductedsalarytextBox.Text.Trim().Equals("") && !salarystructuretextBox.Text.Trim().Equals(""))
            //{
            //    double payablesalaryamount = (Convert.ToDouble("0"+deductedsalarytextBox.Text.Trim()) +
            //                                  Convert.ToDouble("0" + salarystructuretextBox.Text.Trim()));
            //    payablesalarytextBox.Text = payablesalaryamount.ToString();

            //}
        }

        private void servicechargetextBox_TextChanged(object sender, EventArgs e)
        {
            TotalSalaryCalculation();
            //if (!servicechargetextBox.Text.Trim().Equals("") && !payablesalarytextBox.Text.Trim().Equals(""))
            //{
            //    double payablesalaryamount = (Convert.ToDouble("0" + payablesalarytextBox.Text.Trim()) +
            //                                  Convert.ToDouble("0" + payablesalarytextBox.Text.Trim()));
            //    payablesalarytextBox.Text = payablesalaryamount.ToString();

            //}
        }



        private void payablesalarytextBox_TextChanged(object sender, EventArgs e)
        {
            TotalSalaryCalculation();
        }

        private void foodAndRoomtextBox_TextChanged(object sender, EventArgs e)
        {
            TotalSalaryCalculation();
        }

        private void salarystructuretextBox_TextChanged(object sender, EventArgs e)
        {
            TotalSalaryCalculation();
        }


        public void TotalSalaryCalculation()
        {

            double salary = Convert.ToDouble("0" + salarystructuretextBox.Text);
            double deductsalary = Convert.ToDouble("0" + deductedsalarytextBox.Text);
            Payablesalary = (salary - deductsalary);
            payablesalarytextBox.Text = Payablesalary.ToString();
            double payablesalary = Convert.ToDouble("0" + payablesalarytextBox.Text);
            double servicecharge = Convert.ToDouble("0" + servicechargetextBox.Text);
            double foodroomallowance = Convert.ToDouble("0" + foodAndRoomtextBox.Text);
            Totalpayablesalary = (Payablesalary + servicecharge + foodroomallowance);
            totalPayableSalarytextBox.Text = Totalpayablesalary.ToString();


        }

        private void salarystructuretextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
              && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

     

     


    }
}
