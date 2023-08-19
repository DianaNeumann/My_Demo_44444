using Microsoft.EntityFrameworkCore;
using StockApp.DataAcess.Entities;

namespace StockApp.DataAcess;

public class MasterDbContext : DbContext
{
    public MasterDbContext()
    {
        Database.EnsureCreated();
    }

    public DbSet<Box> Boxes { get; set; }
    public DbSet<Pallete> Palletes { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Filename=Master.db");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
    
}