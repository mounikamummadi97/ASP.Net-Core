using Foreignkey_Creating_APIController.Data;
using Foreignkey_Creating_APIController.IDataRepository;
using Foreignkey_Creating_APIController.Model;
using Microsoft.EntityFrameworkCore;

namespace Foreignkey_Creating_APIController.DataManager
{
    public class CustomerProductDataManager : IDataRepository<CustomerProduct>
    {
        readonly API_DBContext _DBContext;
        public CustomerProductDataManager(API_DBContext dbcontext)
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
#pragma warning disable CS8603 // Possible null reference return.
            //return _DBContext.CustomersProducts
                  //.FirstOrDefault(e => e.CustomerId == id);
            return _DBContext.CustomersProducts.Where(x=>x.CustomerProductId== id).Include(x=>x.customer).FirstOrDefault();
#pragma warning restore CS8603 // Possible null reference return.
            //return _DBContext.Customers.Include("CustomerProducts").Include("products")
                 //.FirstOrDefault(e => e.CustomerId == id);
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
