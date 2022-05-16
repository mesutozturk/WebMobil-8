using WissenShop.Core.Entities.Abstracts;

namespace WissenShop.Core.Entities;

public class Category : BaseEntity<int>
{
    public string Name { get; set; }
    public string Description { get; set; }

    public IList<Product>? Products { get; set; }
}