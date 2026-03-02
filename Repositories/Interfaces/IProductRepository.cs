using ProductManagementConsoleApplication.Models;

namespace ProductManagementConsoleApplication.Repositories.Interfaces
{
    interface IProductRepository
    {
        void Add(Product product);
        List<Product> GetAll();
        bool IsCodeUnique(string productCode);
    }
}
