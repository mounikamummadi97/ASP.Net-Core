using DAL.Data;
using DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.DataRepository
{
    public class NewCustomerManager:IDataRepository2<Customer>
    {
        readonly API_DBContext _DBContext;
        public NewCustomerManager(API_DBContext dbcontext)
        {
            _DBContext = dbcontext;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _DBContext.CustomersTable.Include(y => y.Product).ToListAsync();
        }

        public  async Task<Customer> GetAsync(int id)
        {
            Customer result = await _DBContext.CustomersTable.Include(some => some.Product).FirstOrDefaultAsync(c => c.CustomerId == id);
            return result;
        }
       

    }
}
