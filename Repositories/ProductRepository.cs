using ProductManagementConsoleApplication.Models;
using ProductManagementConsoleApplication.Repositories.Interfaces;

namespace ProductManagementConsoleApplication.Repositories
{
    class ProductRepository : IProductRepository
    {
        private readonly List<Product> _products;
        public ProductRepository()
        {
            _products = new List<Product>();
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }
        public List<Product> GetAll()
        {
            return _products;
        }
        public bool IsCodeUnique(string productCode)
        {
            return !(_products.Any(p => p.ProductCode == productCode));
        }
    }
}
