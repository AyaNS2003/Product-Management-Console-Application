namespace ProductManagementConsoleApplication
{
    internal class Product
    {
        private static int _lastProductId = 0;
        public int ProductId { get; private set; }
        public string ProductCode { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public Product(string productCode, string name, string? description, decimal price, int qty)
        {
            if (string.IsNullOrEmpty(name)) { 
                throw new ArgumentNullException("Product name is cannot be empty!");
            }
            if (string.IsNullOrEmpty(productCode))
            {
                throw new ArgumentNullException("Product code is required!");
            }
            if (price <= 0)
            {
                throw new ArgumentException("Price must be greater than 0!");
            }
            if (qty < 0)
            {
                throw new ArgumentException("Quantity must be non-negative number!");
            }
            ProductId = ++_lastProductId;
            ProductCode = productCode;
            Name = name;
            Description = description;
            Price = price;
            Quantity = qty;
        }

        public override string ToString()
        {
            return $"id: {ProductId}, product code: {ProductCode}, name: {Name}" +
                    $", description: {Description}, price: {Price}, quantity: {Quantity}" +
                    "\n **************************************************************************** \n";
        }
    }
}