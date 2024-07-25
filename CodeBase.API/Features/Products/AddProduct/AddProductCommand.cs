using MediatR;

namespace CodeBase.API.Features.Products.AddProduct
{
    public class AddProductCommand : AddProductRequest, IRequest<int>
    {
    }
}