using ManyToMany_foreignKey_relation.Data;
using ManyToMany_foreignKey_relation.IDataRepository;
using ManyToMany_foreignKey_relation.Models;

namespace ManyToMany_foreignKey_relation.DataManager
{
    public class CustomerProductDataManager : IDataRepository<CustomerProduct>
    {
        readonly DBContext _DBContext;
        public CustomerProductDataManager(DBContext dbcontext)
        {
            _DBContext = dbcontext;
        }


        void IDataRepository<CustomerProduct>.Add(CustomerProduct entity)
        {
            var result = new CustomerProduct
            {
                CustomerId = entity.CustomerId,
                ProductId = entity.ProductId,
            };
            _DBContext.Add(result);
            _DBContext.SaveChanges();
        }

        void IDataRepository<CustomerProduct>.Delete(CustomerProduct entity)
        {
            _DBContext.CustomersProducts.Remove(entity);
            _DBContext.SaveChanges();
        }

        CustomerProduct IDataRepository<CustomerProduct>.Get(long id)
        {
            return _DBContext.CustomersProducts
                   .FirstOrDefault(e => e.CustomerId == id);
        }

        public IEnumerable<CustomerProduct> GetAll()
        {
            return _DBContext.CustomersProducts.ToList();
        }

        void IDataRepository<CustomerProduct>.Update(CustomerProduct dbEntity, CustomerProduct entity)
        {
            dbEntity.CustomerId = entity.CustomerId;
            dbEntity.ProductId = entity.ProductId;
        }
    }
}
