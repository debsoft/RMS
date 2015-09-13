using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.ObjectModel
{
   public  class SalaryTransaction
    {
       public int SalaryTransactionId { set; get; }
       public int EmployeeId { set; get; }
       public int WorkingDay { set; get; }
       public int AttendingDay { set; get; }
       public double Salary { set; get; }
       public double DeductedSalary { set; get; }
       public double PayableSalary { set; get; }
       public double ServiceCharge { set; get; }
       public double FoodAndRoomAllowance { set; get; }
       public double TotalPayableSalary { set; get; }
       public String Remarks { set; get; }
    }
}
