using MediatR;

namespace CodeBase.API.Features.Products.GetAllProducts
{
	public record GetAllProductsQuery: IRequest<List<GetAllProductsResponse>>;
}