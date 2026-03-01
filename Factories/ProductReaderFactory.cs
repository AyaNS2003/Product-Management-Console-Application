using ProductManagementConsoleApplication.Readers;
using ProductManagementConsoleApplication.Readers.Interfaces;

class ProductReaderFactory
{
    public static IProductReader Create(int choice)
    {
        return choice switch
        {
            1 => new ConsoleProductReader(),
            2 => new CsvProductReader(),
            _ => throw new ArgumentException("Invalid reader choice")
        };
    }
}