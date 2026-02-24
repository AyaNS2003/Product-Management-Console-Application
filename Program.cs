using ProductManagementConsoleApplication;


class Program
{   
    public static T ReadValue<T>() where T : IParsable<T>
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
        ProductService service = new ProductService();

        while (true)
        {
            Console.WriteLine("1 - Manual Entry");
            Console.WriteLine("2 - CSV Import");
            Console.WriteLine("3 - Print products");
            Console.WriteLine("4 - Exit");

            string choice = Console.ReadLine();

            IProductInputStrategy strategy = null;

            switch (choice)
            {
                case "1":
                    strategy = new ManualEntry(service);
                    break;
                case "2":
                    strategy = new ManualEntry(service);
                    break;
                case "3":
                    service.PrintProducts();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
            if (strategy == null)
                continue;

            strategy.Execute();
        }
    }
}