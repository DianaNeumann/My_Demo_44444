using StockApp.DataAcess;
using StockApp.DataAcess.Extensions;
using StockApp.Domain.Services.Interfaces;

namespace StockApp.Domain.Services.Implementations;

public class BoxService : IBoxService
{
    private readonly MasterDbContext _dbContext = new MasterDbContext();
    

    public async Task<DateOnly> GetExpirationDateByIdAsync(int id, CancellationToken cancellationToken)
    {
        var box = await _dbContext.Boxes.GetEntityAsync(id, cancellationToken);
        return box.DateOfManufacture.AddDays(100);
    }
}