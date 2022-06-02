using System.Linq.Expressions;

namespace North.Businesss.Repositories.Abstracts
{
    public interface IRepository<TEntity, TKey>
        where TKey : IEquatable<TKey>
        where TEntity : class
    {
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate = null);
        //Task<IQueryable<TEntity>> GetAsnyc(Expression<Func<TEntity, bool>> predicate = null);
        TEntity? GetById(TKey id);
        int Insert(TEntity entity, bool isSaveLater = false);
        int Update(TEntity entity, bool isSaveLater = false);
        int Delete(TEntity entity, bool isSaveLater = false);
        int Save();
    }
}