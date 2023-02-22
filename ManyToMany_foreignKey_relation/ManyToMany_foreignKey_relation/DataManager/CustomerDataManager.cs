using ManyToMany_foreignKey_relation.Data;
using ManyToMany_foreignKey_relation.IDataRepository;
using ManyToMany_foreignKey_relation.Models;
using Microsoft.EntityFrameworkCore;

namespace ManyToMany_foreignKey_relation.DataManager
{
    public class CustomerDataManager : IDataRepository<Customer>
    {
        readonly DBContext _DBContext;
        public CustomerDataManager(DBContext  dbcontext)
        {
            _DBContext = dbcontext;
        }

        public void Add(Customer entity)
        {
            var result = new Customer
            {
                CustomerName = entity.CustomerName,
                CustomerAddress = entity.CustomerAddress,
                CustomerAge = entity.CustomerAge,

                //CustomerId = entity.CustomerId
            };
            _DBContext.Add(result);
            _DBContext.SaveChanges();
        }

        public void Delete(Customer customer)
        {
            _DBContext.Customers.Remove(customer);
            _DBContext.SaveChanges();
        }

        public Customer Get(long id)
        {
            return _DBContext.Customers.Include("CustomerProducts")
                  .FirstOrDefault(e => e.CustomerId == id);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _DBContext.Customers.ToList();
        }

        public void Update(Customer dbEntity, Customer entity)
        {
            dbEntity.CustomerName = entity.CustomerName;
            dbEntity.CustomerAddress = entity.CustomerAddress;
            dbEntity.CustomerAge = entity.CustomerAge;
            _DBContext.SaveChanges();
        }
    }
}
