using CodeBase.Domain;
using CodeBase.Infrastructure.Repositories;
using MediatR;

namespace CodeBase.API.Features.Products.GetAllProducts
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, List<GetAllProductsDto>>
    {
        public readonly IGenericRepository<Product> _repository;


        public GetAllProductsHandler(IGenericRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAllProductsDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _repository.GetAsync();

            var productDtos = products.Select(product => new GetAllProductsDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description
            }).ToList();

            return productDtos;
        }
    }
}

