using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Services;
using ProductsAPI.DTOs;
using ProductsAPI.Models;

namespace ProductsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductReadDto>> GetAll()
        {
            var products = _service.GetAll()
                .Select(p => new ProductReadDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price
                });

            return Ok(products);
        }

        [HttpGet("{id}")]
        public ActionResult<ProductReadDto> GetById(int id)
        {
            var product = _service.GetById(id);
            if (product == null) return NotFound();

            return Ok(new ProductReadDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            });
        }

        [HttpPost]
        public ActionResult<ProductReadDto> Create(ProductCreateDto dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                Price = dto.Price,
                Category = dto.Category
            };

            var created = _service.Create(product);

            return CreatedAtAction(nameof(GetById),
                new { id = created.Id },
                new ProductReadDto
                {
                    Id = created.Id,
                    Name = created.Name,
                    Price = created.Price
                });
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ProductUpdateDto dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                Price = dto.Price,
                Category = dto.Category
            };

            var result = _service.Update(id, product);

            if (!result) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _service.Delete(id);
            if (!result) return NotFound();

            return NoContent();
        }
    }
}
