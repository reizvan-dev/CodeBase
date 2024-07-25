using FluentValidation;

namespace CodeBase.API.Features.Products.AddProduct
{
    public class AddProductValidation : AbstractValidator<AddProductCommand>
    {
        private readonly IAddProductRepository _repository;

        public AddProductValidation(IAddProductRepository repository)
        {
            _repository = repository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(70).WithMessage("{PropertyName} length must less than 70 character")
                .MustAsync(MustUniq).WithMessage("Product already exist");
        }

        private Task<bool> MustUniq(string name, CancellationToken token)
        {
            return _repository.MustUniq(name);
        }
    }
}