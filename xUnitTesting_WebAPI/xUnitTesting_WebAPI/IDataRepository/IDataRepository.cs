using xUnitTesting_WebAPI.Model;

namespace xUnitTesting_WebAPI.Interface
{
    public interface IDataRepository
    {
        public IEnumerable<Customer> GetCustomerList();
        public Customer GetCustomerById(int id);
        public void Insert(Customer entity);
        public void UpdateCustomer(Customer customer);
        public bool DeleteCustomer(int Id);
    }
}
