using CarManagerAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarManagerAPI.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
    
    public DbSet<Car> Cars { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>()
            .HasData(
                new Car
                {
                    Id = 1, Brand = "Opel", Model = "Astra", FuelType = CarFuelType.Gasoline, Year = 2018, Mileage = 110300
                },
                new Car
                {
                    Id = 2, Brand = "BMW", Model = "X5", FuelType = CarFuelType.Diesel, Year = 2019, Mileage = 50000
                });
    }
}