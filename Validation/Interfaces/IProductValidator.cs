using ProductManagementConsoleApplication.Models;
using ProductManagementConsoleApplication.Repositories.Interfaces;

namespace ProductManagementConsoleApplication.Validation.Interfaces
{
    interface IProductValidator
    {
        List<string> Validate(Product product, IProductRepository repository);
    }
}
