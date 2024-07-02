using CodeBase.Domain;
using CodeBase.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CodeBase.API.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IGenericRepository<Product> _repository;

        public ProductsController(IGenericRepository<Product> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Product>>> Get()
        {
            var products = await _repository.GetAsync();

            return Ok(products);
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
        public async Task<ActionResult> Post([FromBody] Product value)
        {
            await _repository.CreateAsync(value);

            return Ok();
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

