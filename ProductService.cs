namespace ProductManagementConsoleApplication
{
    internal class ProductService
    {
        List<Product> _products = new List<Product>();

        public void AddProduct(Product product)
        {
            
            _products.Add(product);
        }

        public List<Product> GetAll => _products;
        public void PrintProducts()
        {
            Console.WriteLine("\n===== All Products =====\n");

            foreach (var product in _products)
            {
                Console.WriteLine(product.ToString());
            }
        }
    }
}
