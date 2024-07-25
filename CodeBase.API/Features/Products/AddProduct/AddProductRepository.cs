using CodeBase.Domain;
using CodeBase.Infrastructure.AppDbContext;
using CodeBase.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CodeBase.API.Features.Products.AddProduct
{
    public class AddProductRepository : GenericRepository<Product>, IAddProductRepository
    {
        public AddProductRepository(CodebaseDbContext context) : base(context) { }

        public async Task<bool> MustUniq(string name)
        {
            return await _context.Product.AnyAsync(q => q.Name == name) == false;
        }
    }
}

