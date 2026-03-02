using ProductManagementConsoleApplication.Models;
using ProductManagementConsoleApplication.Readers.Interfaces;
using ProductManagementConsoleApplication.Services;
using ProductManagementConsoleApplication.Validation.Interfaces;
using ProductManagementConsoleApplication.Repositories;
using ProductManagementConsoleApplication.Writers.Interfaces;
using ProductManagementConsoleApplication.Repositories.Interfaces;
using ProductManagementConsoleApplication.Validation;

class Program
{
    static IProductReader GetReader()
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Choose way of getting products info:");
            Console.WriteLine("1 - Manual Entry");
            Console.WriteLine("2 - CSV Import");
            Console.WriteLine("3 - EXIT");
            Console.Write("> ");

            string input = Console.ReadLine();

            if (input == "3")
                return null;

            if (int.TryParse(input, out int choice) && (choice == 1 || choice == 2))
            {
                return ProductReaderFactory.Create(choice);
            }

            Console.WriteLine("Invalid reader choice. Try again.");
        }
    }

    static IProductWriter GetWriter()
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Choose way of displaying products info: ");
            Console.WriteLine("1 - Console print");
            Console.WriteLine("2 - JSON file output");
            Console.WriteLine("3 - EXIT");
            Console.Write("> ");

            string input = Console.ReadLine();

            if (input == "3")
                return null;

            if (int.TryParse(input, out int choice) && (choice == 1 || choice == 2))
            {
                return ProductWriterFactory.Create(choice);
            }

            Console.WriteLine("Invalid writer choice. Try again.");
        }
    }
    static void Main()
    {
        IProductRepository repository = new ProductRepository();
        IProductValidator validator = new ProductValidator();

        while (true)
        {
            IProductReader reader = GetReader();
            if (reader == null) break;
            IProductWriter writer = GetWriter();
            if (writer == null) break;

            var service = new ProductService(reader, writer, validator, repository);

            service.AddProduct();
            service.GetProducts();
        }
    }
}