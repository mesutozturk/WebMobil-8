using North.Businesss.Repositories.Abstracts.EntityFrameworkCore;
using North.Core.Entities;
using North.Data;

namespace North.Businesss.Repositories;

public class OrderRepo : RepositoryBase<Order, int>
{
    public OrderRepo(NorthwindContext context) : base(context)
    {
    }
}