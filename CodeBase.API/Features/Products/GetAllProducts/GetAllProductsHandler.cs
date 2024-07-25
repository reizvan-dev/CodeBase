using CodeBase.Domain;
using CodeBase.Infrastructure.Repositories;
using MediatR;
using AutoMapper;

namespace CodeBase.API.Features.Products.GetAllProducts
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, List<GetAllProductsResponse>>
    {
        private readonly IMapper _mapper;
        public readonly IGenericRepository<Product> _repository;

        public GetAllProductsHandler(
            IMapper mapper,
            IGenericRepository<Product> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<List<GetAllProductsResponse>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _repository.GetAsync();

            List<GetAllProductsResponse> productDtos = _mapper.Map<List<GetAllProductsResponse>>(products);

            return productDtos;
        }
    }
}

