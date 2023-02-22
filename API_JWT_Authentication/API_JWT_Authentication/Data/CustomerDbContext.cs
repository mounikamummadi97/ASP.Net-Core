using API_JWT_Authentication.Models;
using Microsoft.EntityFrameworkCore;

namespace API_JWT_Authentication.Data
{
    public class CustomerDbContext:DbContext
    {
        public CustomerDbContext(DbContextOptions options) : base(options)
        { 
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<AuthenticatedResponse> Authenticated { get; set; }
        public DbSet<Login> Logins { get; set; }

    }
}
