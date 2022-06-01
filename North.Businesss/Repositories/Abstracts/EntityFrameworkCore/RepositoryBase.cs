using Microsoft.EntityFrameworkCore;
using North.Data;
using System.Linq.Expressions;

namespace North.Businesss.Repositories.Abstracts.EntityFrameworkCore
{
    public abstract class RepositoryBase<TEntity, TKey> : IRepository<TEntity, TKey>
        where TKey : IEquatable<TKey>
        where TEntity : class
    {
        protected readonly NorthwindContext _context;
        protected readonly DbSet<TEntity> _table;

        protected RepositoryBase(NorthwindContext context)
        {
            _context = context;
            _table = _context.Set<TEntity>();
        }
        public virtual IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate = null)
        {
            return predicate == null ? _table : _table.Where(predicate);
        }
        public virtual TEntity GetById(TKey id)
        {
            return _table.Find(id);
        }

        public virtual int Insert(TEntity entity, bool isSaveLater = false)
        {
            _table.Add(entity);
            if (!isSaveLater)
               return this.Save();
            return 0;
        }

        public virtual int Update(TEntity entity, bool isSaveLater = false)
        {
            _table.Update(entity);
            if (!isSaveLater)
                return this.Save();
            return 0;
        }

        public virtual int Delete(TEntity entity, bool isSaveLater = false)
        {
            _table.Remove(entity);
            if (!isSaveLater)
                return this.Save();
            return 0;
        }

        public virtual int Save()
        {
            return _context.SaveChanges();
        }
    }
}
