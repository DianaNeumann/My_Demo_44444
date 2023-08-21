using StockApp.DataAcess.Entities;

namespace StockApp.Domain.Services.Interfaces;

public interface IPalleteService
{
    Task<Box?> TryToAddBoxToPalleteByIdAsync(Box box, int palleteId, CancellationToken cancellationToken);

    Task<double> GetPalleteWithBoxesVolumeByIdAsync(int palleteId, CancellationToken cancellationToken);
    double GetPalleteWithBoxesWeightByIdAsync(int palleteId);

    Task<Pallete> GetPalleteByIdAsync(int palleteId, CancellationToken cancellationToken);
    IEnumerable<Pallete> GetExpiredPalletes();
    IEnumerable<Pallete> GetNonExpiredPalletes();

    IEnumerable<Pallete> GetAllPalletes();

    IEnumerable<Pallete> GetFirstNPalletesWithBestExpiredDate(int count);



}