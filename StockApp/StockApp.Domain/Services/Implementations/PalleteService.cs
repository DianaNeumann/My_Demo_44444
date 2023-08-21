using Microsoft.EntityFrameworkCore;
using StockApp.DataAcess;
using StockApp.DataAcess.Entities;
using StockApp.DataAcess.Extensions;
using StockApp.Domain.Services.Interfaces;

namespace StockApp.Domain.Services.Implementations;

public class PalleteService : IPalleteService
{
    private readonly MasterDbContext _dbContext = new MasterDbContext();
    
    private const int ExpirationDays = 100;   
    public async Task<Box?> TryToAddBoxToPalleteByIdAsync(Box box, int palleteId, CancellationToken cancellationToken)
    {
        try
        {
            var pallete = await _dbContext.Palletes.GetEntityAsync(palleteId, cancellationToken);

            /* :) only makes sense for the first box */
            /* Каждая коробка не должна превышать по размерам паллету (по ширине и глубине). */
            if (pallete.Width < box.Width || pallete.Depth < box.Depth)
            {
                return null;
            }
            
            pallete.Boxes.Add(box);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
        catch
        {
            return null;
        }

        return box;
    }

    public async Task<double> GetPalleteWithBoxesVolumeByIdAsync(int palleteId, CancellationToken cancellationToken)
    {
        var pallete = await _dbContext.Palletes.GetPalleteAsync(palleteId, cancellationToken);

        return pallete.Boxes
                   .Sum(b => b.Height * b.Width * b.Depth) +
               (pallete.Height * pallete.Width * pallete.Depth);
    }

    public double GetPalleteWithBoxesWeightByIdAsync(int palleteId)
    {
        var pallete = _dbContext.Palletes.First(p => p.Id == palleteId);

        return pallete.Boxes
                   .Sum(b => b.Height * b.Width * b.Depth) +
               (pallete.Height * pallete.Width * pallete.Depth);
    }

    public async Task<Pallete> GetPalleteByIdAsync(int palleteId, CancellationToken cancellationToken)
    {
        return await _dbContext.Palletes.GetPalleteAsync(palleteId, cancellationToken);
    }

    public IEnumerable<Pallete> GetExpiredPalletes()
    {
        return _dbContext.Palletes
            .Include(p => p.Boxes)
            .Where(p => p.Boxes
                .All(b => b.DateOfManufacture
                    .AddDays(ExpirationDays)
                    .CompareTo(DateOnly.FromDateTime(DateTime.Now)) < 0))
            .OrderBy(p => GetPalleteWithBoxesWeightByIdAsync(p.Id));
    }

    public IEnumerable<Pallete> GetNonExpiredPalletes()
    {
        return _dbContext.Palletes
            .Include(p => p.Boxes)
            .Where(p => p.Boxes
                .All(b => b.DateOfManufacture
                    .AddDays(ExpirationDays)
                    .CompareTo(DateOnly.FromDateTime(DateTime.Now)) > 0))
            .OrderBy(p => GetPalleteWithBoxesWeightByIdAsync(p.Id));
    }

    public IEnumerable<Pallete> GetAllPalletes()
    {
        return _dbContext.Palletes
            .Include(p => p.Boxes)
            .OrderBy(p => p.Boxes
                .Min(b => b.DateOfManufacture));
    }

    public IEnumerable<Pallete> GetFirstNPalletesWithBestExpiredDate(int count)
    {
        return _dbContext.Palletes
            .Include(p => p.Boxes)
            .OrderBy(p => p.Boxes
                .Max(b => b.DateOfManufacture))
            .Take(count);
    }
}