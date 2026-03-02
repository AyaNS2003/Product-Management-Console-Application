using ProductManagementConsoleApplication.Models;
using ProductManagementConsoleApplication.Readers.Interfaces;

namespace ProductManagementConsoleApplication.Readers
{
    public class CsvProductReader : IProductReader
    {
        public List<Product> Read()
        {
            List<Product> _products = new List<Product>();
            Console.WriteLine("Enter full path of the file");
            string path = Console.ReadLine();

            if (!File.Exists(path))
            {
                Console.WriteLine("File not found.");
                return _products;
            }

            try
            {
                foreach (string line in File.ReadLines(path))
                {
                    Product currentProduct = ParseCsvProduct(line);
                    if (currentProduct != null)
                        _products.Add(currentProduct);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed: {ex.Message}");
            }

            Console.WriteLine("CSV file has been read successfully");

            return _products;
        }
        Product ParseCsvProduct(string line)
        {
            string[] values = line.Split(',');
            if (values.Length < 5)
            {
                Console.WriteLine($"Invalid format at line: ({line})");
                return null;
            }
            string code = values[0];
            string name = values[1];
            string description = values[2];
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
