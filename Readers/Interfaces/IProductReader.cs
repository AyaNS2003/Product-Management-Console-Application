using ProductManagementConsoleApplication.Models;

namespace ProductManagementConsoleApplication.Readers.Interfaces
{
    interface IProductReader
    {
        public List<Product> Read();
    }
}
