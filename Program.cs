using ProductManagementConsoleApplication;


class Program
{
    static T ReadValue<T>() where T : IParsable<T>
    {
        while (true)
        {
            string input = Console.ReadLine();

            if (T.TryParse(input, null, out T result))
            {
                return result;
            }
            else
            {
                Console.WriteLine($"Invalid input, please enter a valid {typeof(T).Name}:");
            }
        }
    }

    static void Main()
    {
        List<Product> products = new List<Product>();

        while (true)
        {
            try
            {
                Console.WriteLine("Enter Product Code (required):");
                string code = Console.ReadLine();
                
                while (products.Any(p  => p.ProductCode == code))
                {
                    Console.WriteLine("Product code must be unique, Try again!");
                    code = Console.ReadLine();
                }
                Console.WriteLine("Enter Product Name (required):");
                string name = Console.ReadLine();


                Console.WriteLine("Enter Description:");
                string description = Console.ReadLine();

                Console.WriteLine("Enter Price (X.Y format):");
                decimal price = ReadValue<decimal>();

                Console.WriteLine("Enter Quantity:");
                int quantity = ReadValue<int>();

                Product product = new Product(code, name, description, price, quantity)
                {
                    ProductCode = code,
                    Name = name
                };
                products.Add(product);

                Console.WriteLine("Product added successfully!\n");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }

            Console.WriteLine("Add another product? (y/n)");
            string answer = Console.ReadLine().ToLower();

            if (answer != "y")
                break;
        }

        Console.WriteLine("\n===== All Products =====\n");

        foreach (var product in products)
        {
            Console.WriteLine(product.ToString());
        }
    }
}