using WissenShop.Business.Repositories.Abstracts.EntityFrameworkCore;
using WissenShop.Core.Entities;
using WissenShop.Data.EntityFramework;

namespace WissenShop.Business.Repositories;

public class ProductRepo : RepositoryBase<Product,Guid>
{
    public ProductRepo(MyContext context) : base(context)
    {
    }
}