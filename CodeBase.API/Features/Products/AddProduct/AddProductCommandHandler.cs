using AutoMapper;
using CodeBase.Domain;
using MediatR;

namespace CodeBase.API.Features.Products.AddProduct
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, int>
    {
        private readonly IMapper _mapper;
        public readonly IAddProductRepository _repository;

        public AddProductCommandHandler(
            IMapper mapper,
            IAddProductRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<int> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var validator = new AddProductValidation(_repository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Count != 0)
                throw new BadHttpRequestException(validationResult.ToString());

            var newProduct = _mapper.Map<Product>(request);

            await _repository.CreateAsync(newProduct);

            return newProduct.Id;
        }
    }
}

