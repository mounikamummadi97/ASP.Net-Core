using DAL.Data;
using DAL.Model;

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

               
            };
            _DBContext.Add(Result);
            _DBContext.SaveChanges();
        }

        public void Delete(Customer entity)
        {
            _DBContext.Customers2.Remove(entity);
            _DBContext.SaveChanges();
        }

        public Customer Get(int id)
        {
            return _DBContext.Customers2
                 .FirstOrDefault(e => e.CustomerId == id);
        }

        public IEnumerable<Customer> GetAll()
        {
          return _DBContext.Customers2.ToList();

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
