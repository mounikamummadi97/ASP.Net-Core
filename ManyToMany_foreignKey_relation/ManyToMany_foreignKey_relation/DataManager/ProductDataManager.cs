using ManyToMany_foreignKey_relation.Data;
using ManyToMany_foreignKey_relation.IDataRepository;
using ManyToMany_foreignKey_relation.Models;
using Microsoft.EntityFrameworkCore;

namespace ManyToMany_foreignKey_relation.DataManager
{
    public class ProductDataManager : IDataRepository<Product>
    {
        readonly DBContext _DBContext;
        public ProductDataManager(DBContext dbcontext)
        {
            _DBContext = dbcontext;
        }
        void IDataRepository<Product>.Add(Product entity)
        {

            var result = new Product
            {
                //  CustomerId=entity.CustomerId,



                ProductPrice = entity.ProductPrice,
                ProductName = entity.ProductName,
                //ProductId = entity.ProductId
            };
            _DBContext.Add(result);
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
            return _DBContext.Products.Include("CustomerProducts")
                   .FirstOrDefault(e => e.ProductId == id);
#pragma warning restore CS8603 // Possible null reference return.
        }

        IEnumerable<Product> IDataRepository<Product>.GetAll()
        {
            return _DBContext.Products.ToList();
        }

        void IDataRepository<Product>.Update(Product dbEntity, Product entity)
        {
            dbEntity.ProductName = entity.ProductName;
            dbEntity.ProductPrice = entity.ProductPrice;

            //dbEntity.ProductId = entity.ProductId;
            _DBContext.SaveChanges();
        }
    }
}
