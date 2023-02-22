using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversionPrinciple
{
    public class EmployeeDataAccess : IEmployeeDataAccess
    {
        public Employee GetEmployeeDetails(int id)
        {
            // In real time get the employee details from db
            //but here we are hardcoded the employee details
            Employee objEmployee = new Employee()
            {
                EmployeeID = id,
                EmployeeName = "Mounika",
                EmployeeDepartment = "IT",
                EmployeeSalary = 12000
            };
            return objEmployee;
        }
    }
}
