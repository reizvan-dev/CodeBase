using AutoMapper;
using CodeBase.Domain;

namespace CodeBase.API.Features.Products.AddProduct
{
    public class AddProductProfile : Profile
    {
        public AddProductProfile()
        {
            CreateMap<AddProductRequest, Product>();
        }
    }
}

