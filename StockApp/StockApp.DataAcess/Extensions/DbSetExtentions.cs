using Microsoft.EntityFrameworkCore;
using StockApp.DataAcess.Entities;

namespace StockApp.DataAcess.Extensions;

public static class DbSetExtentions
{

    public static async Task<Pallete> GetPalleteAsync(
        this DbSet<Pallete> set,
        int id,
        CancellationToken cancellationToken)
    {
        return await set
            .Include(p => p.Boxes)
            .FirstAsync(p => p.Id == id, cancellationToken);
    }
    
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
}