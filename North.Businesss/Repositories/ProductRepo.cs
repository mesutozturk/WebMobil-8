using North.Businesss.Repositories.Abstracts.EntityFrameworkCore;
using North.Core.Entities;
using North.Data;

namespace North.Businesss.Repositories;

public class ProductRepo : RepositoryBase<Product, int>
{
    public ProductRepo(NorthwindContext context) : base(context)
    {
    }
}