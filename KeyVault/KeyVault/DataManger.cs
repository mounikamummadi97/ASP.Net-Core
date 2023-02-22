namespace KeyVault
{
    public class DataManger : IEmployeeServive<Employee>
    {
        readonly EmpDBContext _employeeDbcontext;
        public DataManger(EmpDBContext employeeDbcontext)
        {
            _employeeDbcontext = employeeDbcontext;
        }
        public bool DeleteEmployee(int Id)

        {
            var obj = _employeeDbcontext.Employees.FirstOrDefault(x => x.EmployeeId == Id);
            if (obj != null)
            {
                _employeeDbcontext.Remove(obj);
                _employeeDbcontext.SaveChanges();
            }
            return true;
        }
    

        public Employee GetEmployeeById(int id)
        {
            var result = _employeeDbcontext.Employees.FirstOrDefault(x => x.EmployeeId == id);
            return result;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employeeDbcontext.Employees.ToList();
            
        }

        public void Insert(Employee entity)
        {
            _employeeDbcontext.Add(entity);
            _employeeDbcontext.SaveChanges();
        }

        //public void UpdateEmployee(Employee employee)
        //{
           
        //    _employeeDbcontext.Update(employee);
        //    _employeeDbcontext.SaveChanges();
        //}

        public void UpdateEmployee(Employee employee, Employee employees)
        {
            employee.EmployeeName = employees.EmployeeName;
            employee.EmployeeSalary=employees.EmployeeSalary;
            _employeeDbcontext.SaveChanges();
        }
    }
}
