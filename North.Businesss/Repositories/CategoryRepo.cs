using North.Businesss.Repositories.Abstracts.EntityFrameworkCore;
using North.Core.Entities;
using North.Data;

namespace North.Businesss.Repositories
{
    public class CategoryRepo : RepositoryBase<Category, int>
    {
        public CategoryRepo(NorthwindContext context) : base(context)
        {
        }
    }
}
