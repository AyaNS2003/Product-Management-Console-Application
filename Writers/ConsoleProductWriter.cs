using ProductManagementConsoleApplication.Models;
using ProductManagementConsoleApplication.Writers.Interfaces;

namespace ProductManagementConsoleApplication.Writers
{
    class ConsoleProductWriter : IProductWriter
    {
        public void Write(List<Product> products)
        {
            Console.WriteLine("========================= Products ========================");
            if (products.Count == 0)
            {
                Console.WriteLine("No available products!\n");
                return;
            }

            foreach (var product in products)
            {
                Console.WriteLine(product.ToString());
            }
        }
    }
}
