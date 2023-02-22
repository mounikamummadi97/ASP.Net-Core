using Foreignkey_Creating_APIController.Model;
using Microsoft.EntityFrameworkCore;

namespace Foreignkey_Creating_APIController.Data
{
    public class API_DBContext:DbContext
    {
        public API_DBContext(DbContextOptions<API_DBContext> options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CustomerProduct> CustomersProducts { get; set; }
        
    }
}
