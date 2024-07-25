using System.Reflection.Metadata;
using CodeBase.API.Features.Products.AddProduct;
using CodeBase.API.Features.Products.GetAllProducts;
using CodeBase.Domain;
using CodeBase.Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CodeBase.API.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IGenericRepository<Product> _repository;
        private readonly IMediator _mediator;

        public ProductsController(IGenericRepository<Product> repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetAllProductsResponse>>> GetAllProducts()
        {
            return Ok(await _mediator.Send(new GetAllProductsQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            var product = await _repository.GetByIdAsync(id);

            if (product is null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct([FromBody] AddProductCommand request)
        {
            var response = await _mediator.Send(request);

            return CreatedAtAction(nameof(AddProduct), new { id = response });
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] Product value)
        {

            var productToUpdate = await _repository.GetByIdAsync(id);

            if (productToUpdate is null)
                return NotFound();

            productToUpdate.Name = value.Name;
            productToUpdate.Description = value.Description;

            await _repository.UpdateAsync(productToUpdate);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);

            if (product is null)
                return NotFound();

            await _repository.DeleteAsync(product);

            return Ok();
        }
    }
}

