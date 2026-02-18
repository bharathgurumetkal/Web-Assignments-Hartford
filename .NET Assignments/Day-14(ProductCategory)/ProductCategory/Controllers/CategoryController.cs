using Microsoft.AspNetCore.Mvc;
using ProductCategory.Models;
using ProductCategory.Repositories;

namespace ProductCategory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _repo;

        public CategoryController(ICategoryRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _repo.GetAllAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _repo.GetByIdAsync(id);

            if (category == null)
                return NotFound("Category not found");

            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Category category)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _repo.AddAsync(category);

            return CreatedAtAction(
                nameof(GetById),
                new { id = created.Id },
                created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Category category)
        {
            if (id != category.Id)
                return BadRequest("Id mismatch");

            var result = await _repo.UpdateAsync(category);

            if (!result)
                return NotFound("Category not found");

            return Ok("Category updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _repo.DeleteAsync(id);

            if (!result)
                return NotFound("Category not found");

            return Ok("Category deleted successfully");
        }
    }
}
