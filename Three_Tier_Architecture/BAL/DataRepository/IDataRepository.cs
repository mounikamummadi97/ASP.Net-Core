using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.DataRepository
{
    public interface IDataRepository<TEntity>
    {
        IEnumerable<TEntity> GetAllCustomers();

        TEntity GetCustomerById(int id);

        public void AddCustomer(TEntity entity);
       public  void Update(TEntity dbentity, TEntity entity);

        public void Delete(int id);

    }
}
