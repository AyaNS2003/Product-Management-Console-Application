using ProductManagementConsoleApplication.Models;

namespace ProductManagementConsoleApplication.Writers.Interfaces
{
    public interface IProductWriter
    {
         void Write(List<Product> products);
    }
}
