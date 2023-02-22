namespace OneToMany_foreignKey_Relation.DataManager
{
    public interface IdataRepository
    {
        public interface IDataRepository<TEntity>
        {
            IEnumerable<TEntity> GetAll();
            TEntity Get(int id);
            void Add(TEntity entity);
            void Update(TEntity dbEntity, TEntity entity);
            void Delete(TEntity entity);
        }
    }
}
