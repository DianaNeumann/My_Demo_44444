using StockApp.Domain.Services.Interfaces;

namespace StockApp.Domain.Services.Implementations;

public class PalleteService : IPalleteService
{
    public int Test()
    {
        Console.WriteLine("test");
        return 47;
    }
}