using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementConsoleApplication
{
    internal class CsvImport : IProductInputStrategy
    {
        ProductService _productService;

        public CsvImport(ProductService productService) {
            _productService = productService;
        }
        public void Execute()
        {
            Console.WriteLine("Enter full path of the file");
            string path = Console.ReadLine();

            if (!File.Exists(path))
            {
                Console.WriteLine("File not found.");
                return;
            }

            //string[] lines = File.ReadLines(path);

            try
            {
                foreach (string line in File.ReadLines(path))
                {
                    Product currentProduct = ParseCsvProduct(line);
                    if (currentProduct == null)
                        continue;
                    _productService.AddProduct(currentProduct);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed: {ex.Message}");
            }

            Console.WriteLine("CSV file has been read successfully");
        }

        Product ParseCsvProduct(string line)
        {
            string[] values = line.Split(',');

            string code = values[0];
            string name = values[1];
            string description = values[2];
            if (_productService.GetAll.Any(p => p.ProductCode == code))
            {
                Console.WriteLine($"Failed: Product code must be unique at line ({line})");
                return null;
            }
            if (!decimal.TryParse(values[3], out decimal price))
            {
                Console.WriteLine($"Failed: Invalid price format at line ({line})");
                return null;
            }
            if (!int.TryParse(values[4], out int quantity) || quantity < 0)
            {
                Console.WriteLine($"Failed: Invalid quantity at line ({line})");
                return null;
            }

            return new Product(code, name, description, price, quantity);
        }
    }
}
