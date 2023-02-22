using DAL.Data;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.DataRepository
{
    public class CustomerDataManager : IDataRepository<Customer>
    {
        readonly Customer_DbContext _customerContext;
        public CustomerDataManager(Customer_DbContext customerContext)
        {
            _customerContext = customerContext;
        }
        //public void Add(Customer entity)
        //{
        //    _customerContext.Add(entity);
        //    _customerContext.SaveChanges();
        //}

        public void AddCustomer(Customer entity)
        {
          _customerContext.Add(entity);
        _customerContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var result = _customerContext.Customers1.FirstOrDefault(x => x.CustomerId == id);
            if (result != null)
            {
                _customerContext.Customers1.Remove(result);
                _customerContext.SaveChanges();
            }
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _customerContext.Customers1.ToList();
        }

        //public IEnumerable<Customer> GetAllEmployees()
        //{
        //   return _customerContext.Customers1.ToList();
        //}

        public Customer GetCustomerById(int id)
        {
            var obj = _customerContext.Customers1.FirstOrDefault(x => x.CustomerId == id);
            return obj;
        }

        //public Customer GetEmployeebyId(int id)
        //{
        //    var obj = _customerContext.Customers1.FirstOrDefault(x => x.CustomerId == id);
        //    return obj;
        //}

        public void Update(Customer dbentity, Customer entity)
        {
            dbentity.CustomerName = entity.CustomerName;
            dbentity.CustomerAge = entity.CustomerAge;
            dbentity.CustomerAddress = entity.CustomerAddress;

            _customerContext.SaveChanges();
        }
    }
}
