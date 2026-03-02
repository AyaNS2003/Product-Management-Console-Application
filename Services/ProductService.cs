using ProductManagementConsoleApplication.Models;
using ProductManagementConsoleApplication.Readers.Interfaces;
using ProductManagementConsoleApplication.Repositories.Interfaces;
using ProductManagementConsoleApplication.Services.Interfaces;
using ProductManagementConsoleApplication.Validation.Interfaces;
using ProductManagementConsoleApplication.Writers.Interfaces;

namespace ProductManagementConsoleApplication.Services
{
    public class ProductService : IProductService
    {
        IProductReader _reader;
        IProductWriter _writer;
        IProductValidator _validator;
        IProductRepository _repository;

        public ProductService(IProductReader reader, IProductWriter writer,
            IProductValidator validator, IProductRepository repository) 
        { 
            _reader = reader;
            _writer = writer;
            _validator = validator;
            _repository = repository;
        }
        public void AddProduct()
        {
            List<Product> productsFromReader = _reader.Read();
            foreach (Product p in productsFromReader)
            {
                List<string> errors = _validator.Validate(p, _repository);
                if (errors.Count > 0)
                {
                    foreach (string s in errors)
                    {
                        Console.WriteLine(s);
                    }
                    continue;
                }
                _repository.Add(p);
            }
        }

        public void GetProducts()
        {
            List<Product> products = _repository.GetAll();
            _writer.Write(products);
        }
    }
}
