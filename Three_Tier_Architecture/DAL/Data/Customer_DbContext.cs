using DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class Customer_DbContext:DbContext
    {
        public Customer_DbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Customer> Customers1 { get; set; }
    }
}
