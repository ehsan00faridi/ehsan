using AutoMapper;
using Domain.Models.Products;

namespace Application.Mapper
{
    public class MapperProfile:Profile
    {
        public MapperProfile() {


            CreateMap<Product, Domain.Models.Products.ProductDto>()
                .ForMember(dest => dest.Weight, opt => opt.MapFrom(src => src.Property.Weight))
                .ForMember(m=>m.material,opt=>opt.MapFrom(src=>src.Property.material)).ReverseMap();

            
        }



    }
}
