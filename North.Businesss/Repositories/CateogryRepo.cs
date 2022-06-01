using North.Businesss.Repositories.Abstracts.EntityFrameworkCore;
using North.Core.Entities;
using North.Data;

namespace North.Businesss.Repositories
{
    public class CateogryRepo : RepositoryBase<Category, int>
    {
        public CateogryRepo(NorthwindContext context) : base(context)
        {
        }
    }
}
