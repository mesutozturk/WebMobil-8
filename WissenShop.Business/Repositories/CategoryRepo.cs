using WissenShop.Business.Repositories.Abstracts.EntityFrameworkCore;
using WissenShop.Core.Entities;
using WissenShop.Data.EntityFramework;

namespace WissenShop.Business.Repositories;

public class CategoryRepo : RepositoryBase<Category,int>
{
    public CategoryRepo(MyContext context) : base(context)
    {
    }
}