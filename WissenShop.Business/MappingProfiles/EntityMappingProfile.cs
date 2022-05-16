using AutoMapper;
using WissenShop.Core.Dtos;
using WissenShop.Core.Entities;

namespace WissenShop.Business.MappingProfiles
{
    public class EntityMappingProfile : Profile //System.Reflection
    {
        public EntityMappingProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap(); //2 yöndede dönüşüm yapılır.
            //CreateMap<CategoryDto, Category>();

            //productdto
            //CreateMap<Product, ProductDto>().ForMember(x => x.CategoryName, 
            //    src => 
            //        src.MapFrom(x=>x.Category.Name)
            //        );
            CreateMap<Product, ProductDto>().ReverseMap();
            
        }
    }
}