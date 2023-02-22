using Microsoft.EntityFrameworkCore;
using WebAPI_Ex2.Model;

namespace WebAPI_Ex2.Data
{
    public class CustomerAPI_DBContext:DbContext
    {
        public CustomerAPI_DBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
       // public DbSet<Product> Products { get; set; }    
    }
}
