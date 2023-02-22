using ManyToMany_foreignKey_relation.Models;
using Microsoft.EntityFrameworkCore;

namespace ManyToMany_foreignKey_relation.Data
{
    public class DBContext:DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CustomerProduct> CustomersProducts { get; set; }
    }
}
