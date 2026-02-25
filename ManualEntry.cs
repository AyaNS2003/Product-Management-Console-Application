using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementConsoleApplication
{
    internal class ManualEntry : IProductInputStrategy
    {
        ProductService _productService;
        public ManualEntry(ProductService productService) { 
            _productService = productService;
        }
        public void Execute()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter Product Code (required):");
                    string code = Console.ReadLine();
                    if (_productService.GetAll.Any(p => p.ProductCode == code))
                    {
                        throw new Exception("Product code must be unique!\n");
                    }

                    Console.WriteLine("Enter Product Name (required):");
                    string name = Console.ReadLine();

                    Console.WriteLine("Enter Description:");
                    string description = Console.ReadLine();

                    Console.WriteLine("Enter Price (X.Y format):");
                    decimal price = Program.ReadValue<decimal>();

                    Console.WriteLine("Enter Quantity:");
                    int quantity = Program.ReadValue<int>();

                    Product product = new Product(code, name, description, price, quantity);
                    _productService.AddProduct(product);

                    Console.WriteLine("Product added successfully!\n");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }

                Console.WriteLine("Add another product? (y/n)");
                string answer = Console.ReadLine().ToLower();

                if (answer != "y")
                    break;
            }
        }
    }
}
