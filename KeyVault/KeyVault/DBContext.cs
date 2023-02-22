using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace KeyVault
{
    public class EmpDBContext : DbContext
    {
        //private readonly IConfiguration _configuration;
        public EmpDBContext(DbContextOptions<EmpDBContext> options ) : base(options)
        {
            //_configuration = configuration;
            //var conn = (SqlConnection)this.Database.GetDbConnection();
            //conn.AccessToken = AzServiceTokenProvider.GetAccessToken(_configuration);
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
