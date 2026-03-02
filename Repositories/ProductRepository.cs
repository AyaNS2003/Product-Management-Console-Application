using ProductManagementConsoleApplication.Models;
using ProductManagementConsoleApplication.Repositories.Interfaces;

namespace ProductManagementConsoleApplication.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> _products;
        private static int _lastProductId = 0;
        public ProductRepository()
        {
            _products = new List<Product>();
        }
        public void Add(Product product)
        {
            product.ProductId = ++_lastProductId;
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
