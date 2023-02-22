using API_JWT_Authentication.Data;
using API_JWT_Authentication.Interface;
using API_JWT_Authentication.Models;

namespace API_JWT_Authentication.DataManager
{
    public class CustomerDataManager : IDataRepository<Customer>
    {
        readonly CustomerDbContext _customerDbcontext;
        public CustomerDataManager(CustomerDbContext customerDbcontext)
        {
            _customerDbcontext = customerDbcontext;
        }
        public void AddCustomer(Customer entity)
        {
            _customerDbcontext.Add(entity);
            _customerDbcontext.SaveChanges();
        }

        public void DeleteCustomerById(int id)
        {var obj = _customerDbcontext.Customers.FirstOrDefault(x => x.CustomerId == id);
            if (obj != null)
            {
                _customerDbcontext.Remove(obj);
                _customerDbcontext.SaveChanges();
            }
        }

        public IEnumerable<Customer> GetAllCustomer()
        {
            var list = _customerDbcontext.Customers.ToList();
            return list;
        }

        public Customer GetCustomerById(int id)
        {
            var result = _customerDbcontext.Customers.FirstOrDefault(x => x.CustomerId == id);
            return result;
        }
    }
}
