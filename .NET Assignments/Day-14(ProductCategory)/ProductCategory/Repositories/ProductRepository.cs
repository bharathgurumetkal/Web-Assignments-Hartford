using Microsoft.EntityFrameworkCore;
using ProductCategory.Data;
using ProductCategory.Models;

namespace ProductCategory.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products
                .Include(p => p.Category)
                .ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<bool> AddAsync(Product product)
        {
          
            var categoryExists = await _context.Categories
                .AnyAsync(c => c.Id == product.CategoryId);

            if (!categoryExists)
                return false;

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(Product product)
        {
            var existing = await _context.Products
                .FindAsync(product.Id);

            if (existing == null)
                return false;

            existing.Name = product.Name;
            existing.Price = product.Price;
            existing.CategoryId = product.CategoryId;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
                return false;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
