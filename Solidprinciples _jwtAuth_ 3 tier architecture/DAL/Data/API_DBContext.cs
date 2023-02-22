using DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class API_DBContext : DbContext
    {
        public API_DBContext(DbContextOptions<API_DBContext> options) : base(options)
        {

        }
        public DbSet<Product> Products2 { get; set; }
        public DbSet<Customer> Customers2 { get; set; }

    }
}
