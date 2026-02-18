using Microsoft.AspNetCore.Mvc;
using ProductCategory.Models;
using ProductCategory.Repositories;

namespace ProductCategory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repo;

        public ProductController(IProductRepository repo)
        {
            _repo = repo;
        }

        // GET: api/product
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _repo.GetAllAsync();
            return Ok(products);
        }

        // GET: api/product/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _repo.GetByIdAsync(id);

            if (product == null)
                return NotFound(new { message = "Product not found" });

            return Ok(product);
        }

        // POST: api/product
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _repo.AddAsync(product);

            if (!result)
                return BadRequest(new { message = "Invalid CategoryId" });

            return CreatedAtAction(
                nameof(GetById),
                new { id = product.Id },
                product);
        }

        // PUT: api/product/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Product product)
        {
            if (id != product.Id)
                return BadRequest("Id mismatch");

            var result = await _repo.UpdateAsync(product);

            if (!result)
                return NotFound(new { message = "Product not found" });

            return Ok(new { message = "Product updated successfully" });
        }

        // DELETE: api/product/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _repo.DeleteAsync(id);

            if (!result)
                return NotFound(new { message = "Product not found" });

            return Ok(new { message = "Product deleted successfully" });
        }
    }
}
