using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using xUnitTesting_WebAPI.Model;

namespace xUnitTesting_WebAPI.Data
{
    public class DBContext: DbContext
    {
        public DBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
    }
}
