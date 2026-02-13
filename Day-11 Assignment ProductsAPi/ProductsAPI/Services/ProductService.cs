using ProductsAPI.Models;

namespace ProductsAPI.Services
{
    public class ProductService : IProductService
    {
        private static List<Product> _products = new List<Product>()
        {
            new Product { Id = 1, Name = "Laptop", Price = 50000, Category = "Electronics" }
        };

        public List<Product> GetAll()
        {
            return _products;
        }

        public Product GetById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public Product Create(Product product)
        {
            product.Id = _products.Max(p => p.Id) + 1;
            _products.Add(product);
            return product;
        }

        public bool Update(int id, Product updatedProduct)
        {
            var product = GetById(id);
            if (product == null) return false;

            product.Name = updatedProduct.Name;
            product.Price = updatedProduct.Price;
            product.Category = updatedProduct.Category;
            return true;
        }

        public bool Delete(int id)
        {
            var product = GetById(id);
            if (product == null) return false;

            _products.Remove(product);
            return true;
        }
    }
}
