using WissenShop.Core.Dtos.Abstracts;

namespace WissenShop.Core.Dtos
{
    public class ProductDto : BaseDto<Guid>
    {
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public int CategoryId { get; set; }

        public CategoryDto? Category { get; set; }
    }
}
