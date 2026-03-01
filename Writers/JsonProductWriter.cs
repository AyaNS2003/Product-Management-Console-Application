using ProductManagementConsoleApplication.Models;
using ProductManagementConsoleApplication.Writers.Interfaces;
using System.Text.Json;

namespace ProductManagementConsoleApplication.Writers
{
    internal class JsonProductWriter : IProductWriter
    {
        public void Write (List<Product> products)
        {
            if (products == null || products.Count == 0)
            {
                Console.WriteLine("No products to save.");
                return;
            }

            Console.WriteLine("Enter full path to save JSON file:");
            string path = Console.ReadLine();

            if (path == null)
            {
                path = "output.json";
            }

            try
            {
                var options = new JsonSerializerOptions{WriteIndented = true};

                string output = JsonSerializer.Serialize(products, options);

                File.WriteAllText(path, output);

                Console.WriteLine($"Products printed successfully to the file: {path}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to convert to JSON, {ex.Message}");
            }
        }
    }
}
