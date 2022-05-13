using AdminTemplate.BusinessLogic.Repository.Abstracts.EntityFrameworkCore;
using AdminTemplate.Data;
using AdminTemplate.Models.Entities;

namespace AdminTemplate.BusinessLogic.Repository
{
    public class ProductRepo : RepositoryBase<Product, Guid>
    {
        public ProductRepo(MyContext context) : base(context)
        {
        }
    }
}