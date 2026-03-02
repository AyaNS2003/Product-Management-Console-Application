using ProductManagementConsoleApplication.Models;

namespace ProductManagementConsoleApplication.Readers.Interfaces
{
    public interface IProductReader
    {
         List<Product> Read();
    }
}
