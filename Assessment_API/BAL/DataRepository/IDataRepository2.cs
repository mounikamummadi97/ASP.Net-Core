using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.DataRepository
{
    public interface IDataRepository2<TEntity>
    {
        //IEnumerable<TEntity> GetAllAsync();
        //TEntity GetAsync(int id);
        Task<Customer> GetAsync(int id);
        Task<IEnumerable<Customer>> GetAllAsync();
    }
}
