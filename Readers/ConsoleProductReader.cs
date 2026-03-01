using ProductManagementConsoleApplication.Models;
using ProductManagementConsoleApplication.Readers.Interfaces;

namespace ProductManagementConsoleApplication.Readers
{
    class ConsoleProductReader : IProductReader
    {
        public List<Product> Read()
        {
            List<Product> _products = new List<Product>();
            while (true)
            {
                Console.WriteLine("Enter Product Code (required):");
                string code = Console.ReadLine();

                Console.WriteLine("Enter Product Name (required):");
                string name = Console.ReadLine();

                Console.WriteLine("Enter Description:");
                string description = Console.ReadLine();

                Console.WriteLine("Enter Price (X.Y format):");
                decimal price = ReadValue<decimal>();

                Console.WriteLine("Enter Quantity:");
                int quantity = ReadValue<int>();

                Product product = new Product(code, name, description, price, quantity);
                _products.Add(product);

                Console.WriteLine("Product added successfully!\n");
               
                Console.WriteLine("Add another product? (y/n)");
                string answer = Console.ReadLine().ToLower();

                if (answer != "y")
                    break;
            }
            return _products;
        }
        private T ReadValue<T>() where T : IParsable<T>
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (T.TryParse(input, null, out T result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine($"Invalid input, please enter a valid {typeof(T).Name}:");
                }
            }
        }
    }
}
