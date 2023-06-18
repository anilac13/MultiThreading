using MultiThreading;

namespace MultiThreadingTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            List<Payroll> payrolls = new List<Payroll>();
            payrolls.Add(new Payroll(employeeId: 1, employeeName: "Bruce", employeeAge: 20, salary: 18000.0));
            payrolls.Add(new Payroll(employeeId: 2, employeeName: "Ankit", employeeAge: 22, salary: 25000.0));
            payrolls.Add(new Payroll(employeeId: 3, employeeName: "Ram", employeeAge: 24, salary: 20000.0));
            payrolls.Add(new Payroll(employeeId: 4, employeeName: "Maria", employeeAge: 25, salary: 23000.0));
            payrolls.Add(new Payroll(employeeId: 5, employeeName: "Rashmi", employeeAge: 23, salary: 22000.0));
            
            PayrollOperations operations = new PayrollOperations();
            DateTime startDateTime = DateTime.Now;
            operations.AddEmployee(payrolls);
            DateTime stopDateTime = DateTime.Now;
            Console.WriteLine($"Time with Thread:- {stopDateTime - startDateTime}");
        }
    }
}