using ProductManagementConsoleApplication.Models;
using ProductManagementConsoleApplication.Repositories.Interfaces;
using ProductManagementConsoleApplication.Validation.Interfaces;

namespace ProductManagementConsoleApplication.Validation
{
    public class ProductValidator : IProductValidator
    {
        public List<string> Validate(Product product, IProductRepository repository)
        {
            List<string> errors = new List<string>();

            if (string.IsNullOrWhiteSpace(product.ProductCode))
                errors.Add("Product Code is required.");

            if (!repository.IsCodeUnique(product.ProductCode))
                errors.Add($"Product Code '{product.ProductCode}' already exists.");

            if (string.IsNullOrWhiteSpace(product.Name))
                errors.Add("Product Name is required.");

            if (product.Description?.Length > 500)
                errors.Add("Description cannot exceed 500 characters.");

            if (product.Price <= 0)
                errors.Add("Price must be greater than 0.");

            if (product.Quantity < 0)
                errors.Add("Quantity cannot be negative.");
            return errors;
        }
    }
}
