using Microsoft.EntityFrameworkCore;
using OneToMany_foreignKey_Relation.Data;
using OneToMany_foreignKey_Relation.Model;
using static OneToMany_foreignKey_Relation.DataManager.IdataRepository;

namespace OneToMany_foreignKey_Relation.DataManager
{
    public class ProductDatamanager : IDataRepository<Product>
    {
        readonly API_DBContext _DBContext;
        public ProductDatamanager(API_DBContext dbcontext)
        {
            _DBContext = dbcontext;
        }
        public void Add(Product entity)
        {
            _DBContext.Products.Add(entity);
            _DBContext.SaveChanges();
        }

        public void Delete(Product entity)
        {
            _DBContext.Products.Remove(entity);
            _DBContext.SaveChanges();
        }

        public Product Get(int id)
        {
            Product result = _DBContext.Products.Find(id);
            return result;
        }

        

        public IEnumerable<Product> GetAll()
        {
            return _DBContext.Products.Include("Customer").ToList();
        }

        public void Update(Product dbEntity, Product entity)
        {
            dbEntity.ProductName = entity.ProductName;
            _DBContext.SaveChanges();
        }
    }
}
