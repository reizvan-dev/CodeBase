using CodeBase.Domain;
using CodeBase.Infrastructure.Repositories;

namespace CodeBase.API.Features.Products.AddProduct
{
    public interface IAddProductRepository: IGenericRepository<Product>
	{
        Task<bool> MustUniq(string name);
    }
}

