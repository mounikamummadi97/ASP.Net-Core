using JWT_Authentication.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace JWT_Authentication.Data
{
    public class RepositoryContexts : IdentityDbContext<User>
    {
        public RepositoryContexts(DbContextOptions options):base(options)
        {

        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.ApplyConfiguration(new CompanyConfiguration());
        //    modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        //}
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
