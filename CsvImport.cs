using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementConsoleApplication
{
    internal class CsvImport : IProductInputStrategy
    {
        ProductService _productService;

        public CsvImport(ProductService productService) {
            _productService = productService;
        }
        public void Execute()
        {

        }
    }
}
