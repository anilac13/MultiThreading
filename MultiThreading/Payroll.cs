using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreading
{
    public class Payroll
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int EmployeeAge { get; set; }
        public double Salary { get; set; }
        public Payroll(int employeeId, string employeeName, int employeeAge, double salary)
        {
            this.EmployeeId = employeeId;
            this.EmployeeName = employeeName;
            this.EmployeeAge = employeeAge;
            this.Salary = salary;
        }
    }
}
