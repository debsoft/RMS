using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.ObjectModel
{
    public class Employee
    {
        public int EmployeeId { set; get; }
        public string EmployeeName { set; get; }
        public string EmployeePostion { set; get; }
        public string EmployeePhone { set; get; }
        public string EmployeeAddress { set; get; }
        public string EmployeePId { set; get; }
        public double  TotalPaidAmount { set; get; }
        public DateTime LastPayDate { set; get; }
        public double LastPaidAmount { set; get; }
        public string Paid { set; get; }
        public string Update { set; get; }
        public string Delete { set; get; }
    }
}
