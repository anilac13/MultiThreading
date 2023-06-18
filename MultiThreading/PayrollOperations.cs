using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreading
{
    public class PayrollOperations
    {
        public List<Payroll> payrolls1 = new List<Payroll>();
        public void AddEmployee(List<Payroll> payrolls1)
        {
            /*foreach (Payroll payroll in payrolls1)
            {
                Console.WriteLine($"Employee being added:- {payroll.EmployeeName}");
                this.AddEmpoyeesToList(payroll);
                Console.WriteLine($"Employee added: {payroll.EmployeeName}");
            }*/

            payrolls1.ForEach(payrollData =>
            {
                Console.WriteLine($"Employee being added:- {payrollData.EmployeeName}");
                this.AddEmpoyeesToList(payrollData);
                Console.WriteLine($"Employee added: {payrollData.EmployeeName}");
            });
        }

        public void AddEmployeeWithThread(List<Payroll> payrolls1)
        {
            payrolls1.ForEach(payrollData =>
            {
                Task Thread = new Task(() =>
                {
                    Console.WriteLine($"Employee being added:- {payrollData.EmployeeName}");
                    this.AddEmpoyeesToList(payrollData);
                    Console.WriteLine($"Employee added: {payrollData.EmployeeName}");
                });
                Thread.Start();
            });
            Console.WriteLine(this.payrolls1.Count);
        }

        public void AddEmpoyeesToList(Payroll pay)
        {
            payrolls1.Add(pay);
        }
    }
}
