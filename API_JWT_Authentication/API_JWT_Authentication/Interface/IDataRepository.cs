namespace API_JWT_Authentication.Interface
{
    public interface IDataRepository<TEntity>
    {
        IEnumerable<TEntity> GetAllCustomer();

        TEntity GetCustomerById(int id);

        void DeleteCustomerById(int id);

        void AddCustomer(TEntity entity);
    }
}
