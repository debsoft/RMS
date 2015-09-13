using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RMS.Account_Form;
using RMS.Inventory;
using RMS.ReportForms;

namespace PayRoll.Forms
{
    public partial class WelcomeForm : Form
    {
        public WelcomeForm(string RV, string VR)
        {
            InitializeComponent();
            textBox1.Text = VR;
            label2.Text = RV;
        }

        private void entryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.DatabaseEntry de = new Forms.DatabaseEntry();
            //de.WindowState = FormWindowState.Maximized;
            //de.MdiParent = this;
            de.Show();
        }

        private void entryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Forms.SalarySheet ss = new Forms.SalarySheet();
            //ss.WindowState = FormWindowState.Maximized;
            //ss.MdiParent = this;
            ss.Show();
        }

        private void monthlyStatementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void individualSalaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void databaseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void technicalSupportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.TechnicalSupport ts = new Forms.TechnicalSupport();
            //ts.WindowState = FormWindowState.Maximized;
            //ts.MdiParent = this;
            ts.Show();
        }

        private void salarySheetSummanryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.ChangePassword cs = new Forms.ChangePassword();
            //cs.WindowState = FormWindowState.Maximized;
            //cs.MdiParent = this;
            cs.Show();
        }

        private void bankAdviseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void invidualSalaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void userAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.UserAccount de = new Forms.UserAccount();
            //de.WindowState = FormWindowState.Maximized;
            //de.MdiParent = this;
            de.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void databaseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void individualSalaryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Forms.SalarySheetIndividualReport ssi = new Forms.SalarySheetIndividualReport();
            //ssi.WindowState = FormWindowState.Maximized;
            //ssi.MdiParent = this;
            ssi.Show();
        }

        private void allEmployeeSalaryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void allEmployeeSalaryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Forms.SalarySheetPaySlipAllReport ssi = new Forms.SalarySheetPaySlipAllReport();
            //ssi.WindowState = FormWindowState.Maximized;
            //ssi.MdiParent = this;
            ssi.Show();
        }

        private void monthlyStatementToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Forms.SalarySheetMonthlyReport ssm = new Forms.SalarySheetMonthlyReport();
            //ssm.WindowState = FormWindowState.Maximized;
            //ssm.MdiParent = this;
            ssm.Show();
        }

        private void salarySheetSummeryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.SalarySummaryReport ssrr = new Forms.SalarySummaryReport();
            //ssrr.WindowState = FormWindowState.Maximized;
            //ssrr.MdiParent = this;
            ssrr.Show();
        }

        private void bankAdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.BankAdviseReport ssrq = new Forms.BankAdviseReport();
            //ssrq.WindowState = FormWindowState.Maximized;
            //ssrq.MdiParent = this;
            ssrq.Show();
        }

        private void monthlyStatementLocationWiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.SalarySheetLocationWiseMonthlyReport ssm = new Forms.SalarySheetLocationWiseMonthlyReport();
            //ssm.WindowState = FormWindowState.Maximized;
            //ssm.MdiParent = this;
            ssm.Show();
        }

        private void listOfHoldSalaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.SalarySheetHoldListReport ssrq = new Forms.SalarySheetHoldListReport();
            //ssrq.WindowState = FormWindowState.Maximized;
            //ssrq.MdiParent = this;
            ssrq.Show();
        }

        private void searchToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Forms.AddMonthlySalary ss = new Forms.AddMonthlySalary();
            //ss.WindowState = FormWindowState.Maximized;
            //ss.MdiParent = this;
            ss.Show();
        }

        private void currentStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inventory.ProductStock ps = new Inventory.ProductStock();
            //ps.WindowState = FormWindowState.Maximized;
            //ps.MdiParent = this;
            ps.Show();
        }

        private void stockInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inventory.AfterManufactureStockIn ams = new Inventory.AfterManufactureStockIn();
            //ams.WindowState = FormWindowState.Maximized;
            //ams.MdiParent = this;
            ams.Show();
        }

        private void stockOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inventory.AfterManufactureStockOut ams = new Inventory.AfterManufactureStockOut();
            //ams.WindowState = FormWindowState.Maximized;
            //ams.MdiParent = this;
            ams.Show();
        }

        private void editInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inventory.EditStockOut ams = new Inventory.EditStockOut();
            //ams.WindowState = FormWindowState.Maximized;
            //ams.MdiParent = this;
            ams.Show();
        }

        private void accountStatementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Accounts.AccountStatement ams = new Accounts.AccountStatement();
            //ams.WindowState = FormWindowState.Maximized;
            //ams.MdiParent = this;
            ams.Show();
        }

        private void creditVoucherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Accounts.CreditVoucher ams = new Accounts.CreditVoucher();
            //ams.WindowState = FormWindowState.Maximized;
            //ams.MdiParent = this;
            ams.Show();
        }

        private void debitVoucherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Accounts.DebitVoucher ams = new Accounts.DebitVoucher();
            //ams.WindowState = FormWindowState.Maximized;
            //ams.MdiParent = this;
            ams.Show();
        }

        private void customerDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Accounts.CustomerDatabase ams = new Accounts.CustomerDatabase();
            //ams.WindowState = FormWindowState.Maximized;
            //ams.MdiParent = this;
            ams.Show();
        }

        private void customerAccountPostingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Accounts.CustomerAccountPosting ams = new Accounts.CustomerAccountPosting();
            //ams.WindowState = FormWindowState.Maximized;
            //ams.MdiParent = this;
            ams.Show();
        }

        private void WelcomeForm_Load(object sender, EventArgs e)
        {
            if (textBox1.Text == "HR")
            {
                userAccountToolStripMenuItem.Enabled = false;
                accountsToolStripMenuItem.Enabled = false;
                accountsToolStripMenuItem1.Enabled = false;
                masterEntryToolStripMenuItem.Enabled = false;
                masterEntryToolStripMenuItem1.Enabled = false;
            }
            if (textBox1.Text == "Accounts")
            {
                userAccountToolStripMenuItem.Enabled = false;
                databaseToolStripMenuItem.Enabled = false;
                masterEntryToolStripMenuItem.Enabled = false;
                inventoryToolStripMenuItem.Enabled = false;
                masterEntryToolStripMenuItem1.Enabled = false;
            }
        }

        private void addNewProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inventory.ProductName ams = new Inventory.ProductName();
            //ams.WindowState = FormWindowState.Maximized;
            //ams.MdiParent = this;
            ams.Show();
        }

        private void addNewCompanyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.AddNewCompany ams = new Forms.AddNewCompany();
            //ams.WindowState = FormWindowState.Maximized;
            //ams.MdiParent = this;
            ams.Show();
        }

        private void voucherNoWiseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportForms.CreditVoucherSLNoWiseReport ams = new ReportForms.CreditVoucherSLNoWiseReport();
            //ams.WindowState = FormWindowState.Maximized;
            //ams.MdiParent = this;
            ams.Show();
        }

        private void expenseHeadWiseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportForms.CreditVoucherExpenseWiseReport ams = new ReportForms.CreditVoucherExpenseWiseReport();
            //ams.WindowState = FormWindowState.Maximized;
            //ams.MdiParent = this;
            ams.Show();
        }

        private void creditACWiseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportForms.CreditVoucherCreditACWiseReport ams = new ReportForms.CreditVoucherCreditACWiseReport();
            //ams.WindowState = FormWindowState.Maximized;
            //ams.MdiParent = this;
            ams.Show();
        }

        private void dateToDateReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportForms.CreditVoucherDatetoDateReport ams = new ReportForms.CreditVoucherDatetoDateReport();
            //ams.WindowState = FormWindowState.Maximized;
            //ams.MdiParent = this;
            ams.Show();
        }

        private void voucherNoWiseReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ReportForms.DebitVoucherSLNoWiseReport ams = new ReportForms.DebitVoucherSLNoWiseReport();
            //ams.WindowState = FormWindowState.Maximized;
            //ams.MdiParent = this;
            ams.Show();
        }

        private void incomeHeadWiseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportForms.DebitVoucherIncomeWiseReport ams = new ReportForms.DebitVoucherIncomeWiseReport();
            //ams.WindowState = FormWindowState.Maximized;
            //ams.MdiParent = this;
            ams.Show();
        }

        private void debitACWiseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportForms.DebitVoucherDebitACWiseReport ams = new ReportForms.DebitVoucherDebitACWiseReport();
            //ams.WindowState = FormWindowState.Maximized;
            //ams.MdiParent = this;
            ams.Show();
        }

        private void dateToDateReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ReportForms.DebitVoucherDatetoDateReport ams = new ReportForms.DebitVoucherDatetoDateReport();
            // ams.WindowState = FormWindowState.Maximized;
            // ams.MdiParent = this;
            ams.Show();
        }

        private void leaveFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.LeaveForm ssm = new Forms.LeaveForm();
            //ssm.WindowState = FormWindowState.Maximized;
            //ssm.MdiParent = this;
            ssm.Show();
        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportForms.StockReport sr = new ReportForms.StockReport();
            //sr.WindowState = FormWindowState.Maximized;
            //sr.MdiParent = this;
            sr.Show();
        }

        private void appoinmentLetterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportForms.AppoinmentLetter sr = new ReportForms.AppoinmentLetter();
            //sr.WindowState = FormWindowState.Maximized;
            //sr.MdiParent = this;
            sr.Show();
        }

        private void employeeDatabaseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void warningLetterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportForms.WarningLetter sr = new ReportForms.WarningLetter();
            //sr.WindowState = FormWindowState.Maximized;
            //sr.MdiParent = this;
            sr.Show();
        }

        private void incomeHeadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Accounts.IncomeHead ih = new Accounts.IncomeHead();
            //ih.WindowState = FormWindowState.Maximized;
            //ih.MdiParent = this;
            ih.Show();
        }

        private void expenseHeadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Accounts.ExpenseHead ih = new Accounts.ExpenseHead();
            //ih.WindowState = FormWindowState.Maximized;
            //ih.MdiParent = this;
            ih.Show();
        }

        private void bankTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Accounts.BankingStatement bs = new Accounts.BankingStatement();
            //bs.WindowState = FormWindowState.Maximized;
            //bs.MdiParent = this;
            bs.Show();
        }

        private void bankStatementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportForms.BankStatementReport sr = new ReportForms.BankStatementReport();
            //sr.WindowState = FormWindowState.Maximized;
            //sr.MdiParent = this;
            sr.Show();
        }

        private void confirmationLetterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportForms.JobConfirmationLetter sr = new ReportForms.JobConfirmationLetter();
            //sr.WindowState = FormWindowState.Maximized;
            //sr.MdiParent = this;
            sr.Show();
        }

        private void jobPromotionLetterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportForms.JobPromotionLetter sr = new ReportForms.JobPromotionLetter();
            //sr.WindowState = FormWindowState.Maximized;
            //sr.MdiParent = this;
            sr.Show();
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void warningLetterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Forms.WarningLetter ssm = new Forms.WarningLetter();
            //ssm.WindowState = FormWindowState.Maximized;
            //ssm.MdiParent = this;
            ssm.Show();
        }

        private void performanceAppraisalFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.PerformanceAppraisalForm ssm = new Forms.PerformanceAppraisalForm();
            //ssm.WindowState = FormWindowState.Maximized;
            //ssm.MdiParent = this;
            ssm.Show();
        }

        private void perforToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportForms.PerformanceFormReport sr = new ReportForms.PerformanceFormReport();
            //sr.WindowState = FormWindowState.Maximized;
            //sr.MdiParent = this;
            sr.Show();
        }

        private void appoinmentLetterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Forms.AppoinmentLetter ssm = new Forms.AppoinmentLetter();
            //ssm.WindowState = FormWindowState.Maximized;
            //ssm.MdiParent = this;
            ssm.Show();
        }

        private void aLLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.DatabaseReport dr = new Forms.DatabaseReport();
            //dr.WindowState = FormWindowState.Maximized;
            //dr.MdiParent = this;
            dr.Show();
        }

        private void companyWiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportForms.CompanyWiseDatabaseReport dr = new ReportForms.CompanyWiseDatabaseReport();
            //dr.WindowState = FormWindowState.Maximized;
            //dr.MdiParent = this;
            dr.Show();
        }

        private void employeeWiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportForms.EmployeeWiseDatabase dr = new ReportForms.EmployeeWiseDatabase();
            //dr.WindowState = FormWindowState.Maximized;
            //dr.MdiParent = this;
            dr.Show();
        }

        private void createOpeningBalanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Accounts.CreateOpeningBalance ih = new Accounts.CreateOpeningBalance();
            //ih.WindowState = FormWindowState.Maximized;
            //ih.MdiParent = this;
            ih.Show();
        }

        private void masterEntryToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void factorySetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FactorySaveForm ih = new FactorySaveForm();
            //ih.WindowState = FormWindowState.Maximized;
            //ih.MdiParent = this;
            ih.Show();
        }

        private void accountStatementDateToDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountStatementForm  aAccountStatementForm=new AccountStatementForm();
            aAccountStatementForm.Show();
        }

        private void challanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StockOutChallenReport aStockOutChallenReport=new StockOutChallenReport();
            aStockOutChallenReport.Show();
        }

        private void invoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StockOutInvoiceReport aStockOutInvoiceReport=new StockOutInvoiceReport();
            aStockOutInvoiceReport.Show();
        }

        private void employeeWiseDetailsReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StockOutEmployeeReport aStockOutEmployeeReport=new StockOutEmployeeReport();
            aStockOutEmployeeReport.Show();
        }

        private void dateToDateSaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StockOutDateToDateReportForm aStockOutDateToDateReportForm=new StockOutDateToDateReportForm();
            aStockOutDateToDateReportForm.Show();
        }

        private void employeeLeaveReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LeaveReportForm  aLeaveReportForm=new LeaveReportForm();
            aLeaveReportForm.ShowDialog();
        }
    }
}