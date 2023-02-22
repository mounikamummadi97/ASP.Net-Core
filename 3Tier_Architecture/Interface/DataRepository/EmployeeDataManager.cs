using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employee_DBLayer.Model;

namespace Interface.DataRepository
{
    public class EmployeeDataManager : IDataRepository<Employee>
    {
        readonly Employee_DbContext _employeeContext;
        public EmployeeDataManager(Employee_DbContext employeeContext)
        {
            _employeeContext = employeeContext;
        }

        public static object Object { get; set; }

        public void Add(Employee entity)
        {
            _employeeContext.Add(entity);
            _employeeContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var result = _employeeContext.Employee.FirstOrDefault(x => x.EmployeeId == id);
            if (result != null)
            {
                _employeeContext.Employee.Remove(result);
                _employeeContext.SaveChanges();
            }
        }

       public IEnumerable<Employee> GetAllEmployees()
        {
                return _employeeContext.Employee.ToList();
            }

        public Employee GetEmployeebyId(int id)
        {
                var obj = _employeeContext.Employee.FirstOrDefault(x => x.EmployeeId == id);
                return obj;
            }

        public void Update(Employee dbentity, Employee entity)
        {
            dbentity.EmployeeName = entity.EmployeeName;
            dbentity.EmployeeAge = entity.EmployeeAge;
            dbentity.EmployeeSalary = entity.EmployeeSalary;

            _employeeContext.SaveChanges();


        }

       
    }
}
