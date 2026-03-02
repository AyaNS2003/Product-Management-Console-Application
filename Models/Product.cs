namespace ProductManagementConsoleApplication.Models
{
    public class Product
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
