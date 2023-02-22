namespace ManyToMany_foreignKey_relation.IDataRepository
{
    public interface IDataRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();//ienum collection of objs that accessed one at a time
        TEntity Get(long id);
        void Add(TEntity entity);
        void Update(TEntity dbEntity, TEntity entity); 
        void Delete(TEntity entity);
    }
}
