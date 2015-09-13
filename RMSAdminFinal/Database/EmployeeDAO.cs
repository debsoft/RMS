using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Common.ObjectModel;
using RMS.DataAccess;

namespace Database
{
    public class EmployeeDAO:BaseDAO
    {
        public string InsertEmployee(Employee aEmployee)
        {
            try
            {
                DateTime aDateTime = DateTime.Now.Date;
                this.OpenConnection();
                string sqlComm = string.Format(SqlQueries.GetQuery(Query.InsertEmployee), aEmployee.EmployeeName,"123",
                    aEmployee.EmployeePhone,aEmployee.EmployeeAddress,aEmployee.LastPayDate,aEmployee.EmployeePostion);
                this.ExecuteNonQuery(sqlComm);
                return "Insert Sucessfully";
            }
            catch (Exception ex)
            {
                return "Please try again";

                //throw new Exception(ex.ToString());

            }
            finally
            {
                this.CloseConnection();
            }
        }

        public List<Employee> GetAllEmployee()
        {
            List<Employee> aEmployees = new List<Employee>();
            try
            {
                this.OpenConnection();
                string sqlComm = string.Format(SqlQueries.GetQuery(Query.GetAllEmployee));
                IDataReader aReader = this.ExecuteReader(sqlComm);
                if (aReader != null)
                {
                    while (aReader.Read())
                    {
                        Employee aEmployee = new Employee();
                        aEmployee = ReadToEmployee(aReader);
                        aEmployees.Add(aEmployee);

                    }
                }


            }
            catch (Exception)
            {


            }
            return aEmployees;
        }

        private Employee ReadToEmployee(IDataReader aReader)
        {
            Employee aEmployee = new Employee();
            try
            {
                aEmployee.Delete = "Delete";
            }
            catch (Exception)
            {
            }
            try
            {
                aEmployee.EmployeeAddress = aReader["employee_address"].ToString();
            }
            catch (Exception)
            {
            }
            try
            {
                aEmployee.EmployeeId = Convert.ToInt32(aReader["employee_id"]);
            }
            catch (Exception)
            {
            }
            try
            {
                aEmployee.EmployeeName = aReader["employee_name"].ToString();
            }
            catch (Exception)
            {
            }

            try
            {
                aEmployee.EmployeePostion = aReader["position"].ToString();
            }
            catch (Exception)
            {
            }

            try
            {
                aEmployee.EmployeePId = aReader["employee_pid"].ToString();
            }
            catch (Exception)
            {
            }
            try
            {
                aEmployee.EmployeePhone = aReader["employee_phone"].ToString();
            }
            catch (Exception)
            {
            }
            try
            {
                aEmployee.LastPaidAmount = Convert.ToDouble(aReader["last_paid_amount"]);
            }
            catch (Exception)
            {
            }
            try
            {
                aEmployee.LastPayDate = Convert.ToDateTime(aReader["last_pay_date"]);
            }
            catch (Exception)
            {
            }
            try
            {
                aEmployee.TotalPaidAmount = Convert.ToDouble(aReader["total_paid_amount"]);
            }
            catch (Exception)
            {
            }
            try
            {
                aEmployee.Paid= "Paid";
            }
            catch (Exception)
            {
            }
            try
            {
                aEmployee.Update = "Update";
            }
            catch (Exception)
            {
            }
            return aEmployee;
        }

        public string EmployeeDeleted(int employeeId)
        {
            try
            {
                DateTime aDateTime = DateTime.Now.Date;
                this.OpenConnection();
                string sqlComm = string.Format(SqlQueries.GetQuery(Query.EmployeeDeleted), employeeId);
                this.ExecuteNonQuery(sqlComm);
                return "Delete Successfully";
            }
            catch (Exception ex)
            {

                return "Please try again";
                // throw new Exception(ex.ToString());

            }
            finally
            {
                this.CloseConnection();
            }
        }

        public string UpdateEmployee(Employee aEmployee)
        {
            try
            {
                
                this.OpenConnection();
                string sqlComm = string.Format(SqlQueries.GetQuery(Query.UpdateEmployee), aEmployee.EmployeeName, aEmployee.EmployeePId,
                    aEmployee.EmployeePhone, aEmployee.EmployeeAddress,aEmployee.EmployeePostion, aEmployee.EmployeeId);
                this.ExecuteNonQuery(sqlComm);
                return "Update Sucessfully";
            }
            catch (Exception ex)
            {
                return "Please try again";

                //throw new Exception(ex.ToString());

            }
            finally
            {
                this.CloseConnection();
            }
        }

        public string UpdateAmount(Employee aEmployee)
        {
            try
            {

                this.OpenConnection();
                string sqlComm = string.Format(SqlQueries.GetQuery(Query.UpdateAmount), aEmployee.LastPaidAmount,DateTime.Now.Date, aEmployee.EmployeeId);
                this.ExecuteNonQuery(sqlComm);
                return "Update Sucessfully";
            }
            catch (Exception ex)
            {
                return "Please try again";

                //throw new Exception(ex.ToString());

            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void InsertPaidAmountReport(SalaryTransaction aSalaryTransaction, string month, string year)
        {
            try
            {
                DateTime aDateTime = DateTime.Now.Date;
                this.OpenConnection();
                string sqlComm = string.Format(SqlQueries.GetQuery(Query.InsertPaidAmountReport), aSalaryTransaction.EmployeeId,
                        aSalaryTransaction.WorkingDay , aSalaryTransaction.AttendingDay ,aSalaryTransaction.Salary , aSalaryTransaction.DeductedSalary ,
                        aSalaryTransaction.PayableSalary, aSalaryTransaction.ServiceCharge,aSalaryTransaction.FoodAndRoomAllowance, aSalaryTransaction.TotalPayableSalary,
                        aDateTime, aSalaryTransaction.Remarks,month,year );
                this.ExecuteNonQuery(sqlComm);
              
            }
            catch (Exception ex)
            {
            

                //throw new Exception(ex.ToString());

            }
            finally
            {
                this.CloseConnection();
            }
           
        }

        public List<Transaction1> EmployeeTransactionReportBydate(DateTime fromDate, DateTime toDate)
        {
            List<Transaction1> aTransactions = new List<Transaction1>();
            try
            {
                this.OpenConnection();
                string sqlComm = string.Format(SqlQueries.GetQuery(Query.EmployeeTransactionReportBydate), fromDate, toDate);
                IDataReader aReader = this.ExecuteReader(sqlComm);
                if (aReader != null)
                {
                    while (aReader.Read())
                    {
                        Transaction1 aTransaction1 = new Transaction1();
                        aTransaction1 = ReadToTransactionforProfit(aReader);
                        aTransactions.Add(aTransaction1);

                    }
                }


            }
            catch (Exception)
            {


            }
            return aTransactions;
        }

        private Transaction1 ReadToTransactionforProfit(IDataReader aReader)
        {
            Transaction1 aTransaction1 = new Transaction1();
            try
            {
                aTransaction1.Date = Convert.ToDateTime(aReader["date"]);
            }
            catch (Exception)
            { }
            try
            {
                aTransaction1.Amount = Convert.ToDouble(aReader["amount"]);
            }
            catch (Exception)
            { }

            return aTransaction1;
        }

        public List<EmployeeReport> EmployeeTransactionReportBydateForMonth(DateTime fromDate, DateTime toDate)
        {
            List<EmployeeReport> aTransactions = new List<EmployeeReport>();
            try
            {
                this.OpenConnection();
                string sqlComm = string.Format(SqlQueries.GetQuery(Query.EmployeeTransactionReportBydate), fromDate, toDate);
                IDataReader aReader = this.ExecuteReader(sqlComm);
                if (aReader != null)
                {
                    while (aReader.Read())
                    {
                        EmployeeReport aTransaction = new EmployeeReport();
                        aTransaction = ReadToTransactionforMonth(aReader);
                        aTransactions.Add(aTransaction);

                    }
                }


            }
            catch (Exception)
            {


            }
            return aTransactions;
        }

        private EmployeeReport ReadToTransactionforMonth(IDataReader aReader)
        {
            EmployeeReport aTransaction = new EmployeeReport();
            try
            {
                aTransaction.SalaryDate= Convert.ToDateTime(aReader["date"]);
            }
            catch (Exception)
            { }
            try
            {
                aTransaction.SalaryAmount = Convert.ToDouble(aReader["amount"]);
            }
            catch (Exception)
            { }
            try
            {
                aTransaction.EmployeeName = (aReader["employee_name"]).ToString();
            }
            catch (Exception)
            { }

            return aTransaction;
        }
    }
}
