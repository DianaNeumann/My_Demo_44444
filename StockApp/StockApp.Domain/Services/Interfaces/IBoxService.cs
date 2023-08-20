namespace StockApp.Domain.Services.Interfaces;

public interface IBoxService
{
    Task<DateOnly> GetExpirationDateByIdAsync(int id, CancellationToken cancellationToken);
}