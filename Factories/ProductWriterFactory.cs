using ProductManagementConsoleApplication.Writers;
using ProductManagementConsoleApplication.Writers.Interfaces;

public class ProductWriterFactory
{
    public static IProductWriter Create(int choice)
    {
        return choice switch
        {
            1 => new ConsoleProductWriter(),
            2 => new JsonProductWriter(),
            _ => throw new ArgumentException("Invalid writer choice")
        };
    }
}