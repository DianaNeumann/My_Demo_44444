using StockApp.DataAcess;
using StockApp.DataAcess.Entities;

namespace StockApp.Terminal.Generations;

public static class StartDataGenerator
{
    private static readonly MasterDbContext _dbContext = new MasterDbContext();

    public static async Task Generate(CancellationToken cancellationToken)
    {
        var pallete1 = new Pallete()
        {
            Id = 1,
            Height = 11,
            Width = 21,
            Depth = 31,
            Weight = 30,
        };

        var pallete2 = new Pallete()
        {
            Id = 2,
            Height = 12,
            Width = 22,
            Depth = 32,
            Weight = 30,
        };
        
        var pallete3 = new Pallete()
        {
            Id = 3,
            Height = 13,
            Width = 23,
            Depth = 33,
            Weight = 30,
        };
        
        var box1 = new Box()
        {
            Id = 1,
            Height = 1,
            Width = 2,
            Depth = 2,
            PalleteId = 1,
            Weight = 10,
            DateOfManufacture = new DateOnly(2023, 03, 1)
        };
        
        var box2 = new Box()
        {
            Id = 2,
            Height = 1,
            Width = 2,
            Depth = 2,
            PalleteId = 1,
            Weight = 13,
            DateOfManufacture = new DateOnly(2023, 08, 1)
        };
        
        var box3 = new Box()
        {
            Id = 3,
            Height = 1,
            Width = 2,
            Depth = 2,
            PalleteId = 2,
            Weight = 8,
            DateOfManufacture = new DateOnly(2023, 04, 1)
        };
        
        var box4 = new Box()
        {
            Id = 4,
            Height = 1,
            Width = 2,
            Depth = 2,
            PalleteId = 2,
            Weight = 12,
            DateOfManufacture = new DateOnly(2022, 03, 1)
        };
        
        var box5 = new Box()
        {
            Id = 5,
            Height = 1,
            Width = 2,
            Depth = 2,
            PalleteId = 3,
            Weight = 15,
            DateOfManufacture = new DateOnly(2023, 07, 1)
        };
        
        var box6 = new Box()
        {
            Id = 6,
            Height = 1,
            Width = 2,
            Depth = 2,
            Weight = 3,
            DateOfManufacture = new DateOnly(2023, 07, 1)
        };

        await _dbContext.Palletes.AddRangeAsync(pallete1, pallete2, pallete3);
        await _dbContext.SaveChangesAsync(cancellationToken);
        await _dbContext.Boxes.AddRangeAsync(box1, box2, box3, box4, box5, box6);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}