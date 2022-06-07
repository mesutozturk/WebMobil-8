using System.Linq.Expressions;
using North.Businesss.Repositories.Abstracts.EntityFrameworkCore;
using North.Core.Entities;
using North.Data;

namespace North.Businesss.Repositories;

public class ProductRepo : RepositoryBase<Product, int>
{
    public ProductRepo(NorthwindContext context) : base(context)
    {
    }

    public override IQueryable<Product> Get(Expression<Func<Product, bool>> predicate = null)
    {
        if (predicate == null)
            return _table.Where(x => !x.Discontinued);
        return base.Get(predicate);
    }
}