using Microsoft.EntityFrameworkCore;
using OneToMany_foreignKey_Relation.Model;

namespace OneToMany_foreignKey_Relation.Data
{
    public class API_DBContext:DbContext
    {
        public API_DBContext(DbContextOptions<API_DBContext> options) : base(options)
        {
           
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        
    }
}