using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.DataRepository
{
    public interface IDataRepository<TEntity>
    {
        IEnumerable<TEntity> GetAllEmployees();

        TEntity GetEmployeebyId(int id);

        void Add(TEntity entity);
        void Update(TEntity dbentity, TEntity entity);

        void Delete(int id);
       
    }
}
