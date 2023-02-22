using DAL.Data;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.DataRepository
{
    public class ProductDataManager : IDataRepository<Product>, IDataRepository1<Product>
    {
        readonly API_DBContext _DBContext;
        public ProductDataManager(API_DBContext dbcontext)
        {
            _DBContext = dbcontext;
        }
        public void Add(Product entity)
        {
            var Result = new Product
            {
                ProductName = entity.ProductName,
                ProductPrice = entity.ProductPrice,
                 

            };
            _DBContext.Add(Result);
            _DBContext.SaveChanges();
        }

        public void Delete(Product entity)
        {
            _DBContext.ProductsTable.Remove(entity);
            _DBContext.SaveChanges();
        }

        public Product Get(int id)
        {
            return _DBContext.ProductsTable
                 .FirstOrDefault(e =>e.ProductId == id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _DBContext.ProductsTable.ToList();

        }

        public void Update(Product dbEntity, Product entity)
        {
            dbEntity.ProductName = entity.ProductName;
            dbEntity.ProductPrice = entity.ProductPrice;
            
            _DBContext.SaveChanges();
        }
    }
}
