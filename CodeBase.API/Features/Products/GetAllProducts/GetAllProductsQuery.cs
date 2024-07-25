using MediatR;

namespace CodeBase.API.Features.Products.GetAllProducts
{
	public class GetAllProductsQuery: IRequest<List<GetAllProductsDto>>
	{
	}
}