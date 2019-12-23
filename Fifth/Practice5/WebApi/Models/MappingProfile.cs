using AutoMapper;


namespace WebApi.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDTO>()
            .ForMember(dest => dest.ProductCategory, source => source.MapFrom(src => src.ProductCategory.Caption));
        }
    }
}
