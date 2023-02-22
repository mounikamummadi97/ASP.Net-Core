namespace KeyVault
{
    public interface IEmployeeServive<Employee>
    {
        public IEnumerable<Employee> GetAll();
        public Employee GetEmployeeById(int id);
        public void Insert(Employee entity);
        public void UpdateEmployee(Employee employee, Employee employees);
        public bool DeleteEmployee(int Id);
    }
    
}
