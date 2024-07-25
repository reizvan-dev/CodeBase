using AutoMapper;
using CodeBase.Domain;

namespace CodeBase.API.Features.Products.GetAllProducts
{
    public class GetAllProductsProfile : Profile
    {
        public GetAllProductsProfile()
        {
            CreateMap<Product, GetAllProductsResponse>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.Name} - {src.Description}"))
                .ReverseMap();
        }
    }
}

