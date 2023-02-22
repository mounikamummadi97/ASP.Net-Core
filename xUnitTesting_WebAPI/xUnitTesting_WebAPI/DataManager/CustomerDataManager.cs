using System.Xml.Linq;
using xUnitTesting_WebAPI.Data;
using xUnitTesting_WebAPI.Interface;
using xUnitTesting_WebAPI.Model;

namespace xUnitTesting_WebAPI.DataManager
{

    public class CustomerDataManager : IDataRepository
    {
        private readonly DBContext _dbContext;

        public CustomerDataManager(DBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Insert(Customer entity)
        {
            var result = new Customer
            {
                CustomerName = entity.CustomerName,
                CustomerAddress = entity.CustomerAddress,
                CustomerAge = entity.CustomerAge,
            };
            _dbContext.Add(result);
            _dbContext.SaveChanges();
        }
        public bool DeleteCustomer(int Id)
        {
            var Data = _dbContext.Customers.Where(x => x.CustomerId == Id).FirstOrDefault();
            var result = _dbContext.Remove(Data);
            _dbContext.SaveChanges();
            return result != null ? true : false;
        }

        public Customer GetCustomerById(int id)
        {
            return _dbContext.Customers.Where(x => x.CustomerId == id).FirstOrDefault();
        }

        public IEnumerable<Customer> GetCustomerList()
        {
            //return _dbContext.Customers.ToList();
            return _dbContext.Customers.ToList();
        }

        public void UpdateCustomer(Customer customer)
        {
            var result = _dbContext.Customers.Update(customer);
               _dbContext.SaveChanges();
                

        }
    }
}

