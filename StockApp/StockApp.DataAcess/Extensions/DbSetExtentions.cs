using Microsoft.EntityFrameworkCore;

namespace StockApp.DataAcess.Extensions;

public static class DbSetExtentions
{
    public static async Task<T> GetEntityAsync<T>(
        this DbSet<T> set,
        int id,
        CancellationToken cancellationToken
    )
        where T : class
    {
        var entity = await set.FindAsync(new object[] { id }, cancellationToken);

        if (entity is null)
        {
            throw new KeyNotFoundException("Entity wasn't found [-]");
        }

        return entity;
    }
    
    public static async Task<T?> FindEntityAsync<T>(
        this DbSet<T> set,
        int id,
        CancellationToken cancellationToken
    )
        where T : class
    {
        return await set.FindAsync(new object[] { id }, cancellationToken);
    }
}