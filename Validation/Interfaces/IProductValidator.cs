using ProductManagementConsoleApplication.Models;
using ProductManagementConsoleApplication.Repositories.Interfaces;

namespace ProductManagementConsoleApplication.Validation.Interfaces
{
    public interface IProductValidator
    {
        List<string> Validate(Product product, IProductRepository repository);
    }
}
