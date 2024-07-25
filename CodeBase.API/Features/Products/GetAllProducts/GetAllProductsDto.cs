using System;
namespace CodeBase.API.Features.Products.GetAllProducts
{
	public class GetAllProductsDto
	{
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
    }
}