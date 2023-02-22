using Foreignkey_Creating_APIController.Data;
using Foreignkey_Creating_APIController.IDataRepository;
using Foreignkey_Creating_APIController.Model;
using Microsoft.EntityFrameworkCore;

namespace Foreignkey_Creating_APIController.DataManager
{
    public class ProductDataManager : IDataRepository<Product>
    {
        readonly API_DBContext _DBContext;
        public ProductDataManager(API_DBContext dbcontext)
        {
            _DBContext = dbcontext;
        }
        void IDataRepository<Product>.Add(Product entity)
        {
            
            var abc = new Product
            {
                //  CustomerId=entity.CustomerId,

                productPrice = entity.productPrice,
                ProductName = entity.ProductName,
                //ProductId = entity.ProductId
            };
            _DBContext.Add(abc);
            _DBContext.SaveChanges();

        }

        void IDataRepository<Product>.Delete(Product entity)
        {
            _DBContext.Products.Remove(entity);
            _DBContext.SaveChanges();
        }

        Product IDataRepository<Product>.Get(long id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            //return _DBContext.Products.Include(x=>x.ProductName)
                   //.FirstOrDefault(e => e.ProductId==id);

            return _DBContext.Products.Include("CustomerProducts")
                   .FirstOrDefault(e => e.ProductId == id);

#pragma warning restore CS8603 // Possible null reference return.
        }
       /* Product IDataRepository<Product>.Get(string name)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return _DBContext.Products.Include("CustomerProducts")
                   .FirstOrDefault(e => e.ProductName == name);

            

#pragma warning restore CS8603 // Possible null reference return.
        }*/

        IEnumerable<Product> IDataRepository<Product>.GetAll()
        {
            return _DBContext.Products.ToList();
        }

        void IDataRepository<Product>.Update(Product dbEntity, Product entity)
        {
            dbEntity.ProductName = entity.ProductName;
            dbEntity.productPrice = entity.productPrice;
            
            //dbEntity.ProductId = entity.ProductId;
            _DBContext.SaveChanges();
        }
    }
}
