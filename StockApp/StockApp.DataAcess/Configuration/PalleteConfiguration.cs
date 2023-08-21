using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockApp.DataAcess.Entities;

namespace StockApp.DataAcess.Configuration;

public class PalleteConfiguration : IEntityTypeConfiguration<Pallete>
{
    public void Configure(EntityTypeBuilder<Pallete> builder)
    {
        builder
            .HasMany(p => p.Boxes)
            .WithOne(b => b.Pallete)
            .OnDelete(DeleteBehavior.Cascade);;
    }
}