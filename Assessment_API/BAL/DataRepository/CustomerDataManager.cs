using DAL.Data;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.DataRepository
{
    public class CustomerDataManager : IDataRepository<Customer>, IDataRepository1<Customer>
    {
        readonly API_DBContext _DBContext;
        public CustomerDataManager(API_DBContext dbcontext)
        {
            _DBContext = dbcontext;
        }
        public void Add(Customer entity)
        {
            var Result = new Customer
            {
                CustomerName = entity.CustomerName,
                CustomerAddress = entity.CustomerAddress,
                CustomerAge = entity.CustomerAge,
                ProductId=entity.ProductId

            };
            _DBContext.Add(Result);
            _DBContext.SaveChanges();
        }

        public void Delete(Customer entity)
        {
            //var customer=_DBContext.CustomersTable.FirstOrDefault(x => x.)
            _DBContext.CustomersTable.Remove(entity);
            _DBContext.SaveChanges();
        }

        public Customer Get(int id)
        {
            Customer result = _DBContext.CustomersTable.Find(id);
            return result;
        }

        public IEnumerable<Customer> GetAll()
        {
            return _DBContext.CustomersTable.ToList();

        }

        public void Update(Customer dbEntity, Customer entity)
        {
            dbEntity.CustomerName = entity.CustomerName;
            dbEntity.CustomerAddress = entity.CustomerAddress;
            dbEntity.CustomerAge = entity.CustomerAge;
            // dbEntity.CustomerId = entity.CustomerId;
            _DBContext.SaveChanges();
        }
    }
}
