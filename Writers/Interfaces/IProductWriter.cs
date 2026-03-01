using ProductManagementConsoleApplication.Models;

namespace ProductManagementConsoleApplication.Writers.Interfaces
{
    interface IProductWriter
    {
        public void Write(List<Product> products);
    }
}
