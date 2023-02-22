using Microsoft.EntityFrameworkCore;
using WebAPI_ForeignKey_Relations.Model;

namespace WebAPI_ForeignKey_Relations.Data
{

    public class API_DBContext : DbContext
    {
        public API_DBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
    }

}
