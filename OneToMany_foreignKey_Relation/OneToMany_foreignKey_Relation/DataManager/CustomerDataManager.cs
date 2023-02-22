using OneToMany_foreignKey_Relation.Data;
using OneToMany_foreignKey_Relation.Model;
using static OneToMany_foreignKey_Relation.DataManager.IdataRepository;

namespace OneToMany_foreignKey_Relation.DataManager
{
    public class CustomerDataManager : IDataRepository<Customer>
    {
        readonly API_DBContext _DBContext;
        public CustomerDataManager(API_DBContext dbcontext)
        {
            _DBContext = dbcontext;
        }
        public void Add(Customer entity)
        {
            //_DBContext.Customers.Add(entity);
            //_DBContext.SaveChanges();
            var abc = new Customer
            {
                CustomerName = entity.CustomerName,
                CustomerAddress = entity.CustomerAddress,
                CustomerAge = entity.CustomerAge,

               // Id = entity.Id
            };
            _DBContext.Add(abc);
            _DBContext.SaveChanges();
        }

        public void Delete(Customer customer)
        {
            _DBContext.Customers.Remove(customer);
            _DBContext.SaveChanges();
        }

        public Customer Get(int id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return _DBContext.Customers
                  .FirstOrDefault(e => e.CustomerId == id);
#pragma warning restore CS8603 // Possible null reference return.
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
            dbEntity.CustomerId = entity.CustomerId;
            _DBContext.SaveChanges();
        }
    }
}
