using DAL.Data;
using DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.DataRepository
{
    public class NewProductManager : IDataRepository2<Product>
    {
        readonly API_DBContext _DBContext;
        public NewProductManager(API_DBContext dbcontext)
        {
            _DBContext = dbcontext;
        }
        public Product Get(int id)
        {
            Product result = _DBContext.Products2.Include(some=>some.Customer).FirstOrDefault(c=>c.ProductId==id);
            return result;
        }

        public IEnumerable<Product> GetAll()
        {
            return _DBContext.Products2.Include(y => y.Customer).ToList();
        }
    }
}
