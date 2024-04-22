using CarManagerAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarManagerAPI.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
    
    public DbSet<Car> Cars { get; set; }
    public DbSet<CarInfo> CarInfos { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>()
            .HasData(
                new Car
                {
                    Id = 1, Brand = "Opel", Model = "Astra", FuelType = CarFuelType.Gasoline, Year = 2018, NumberPlate = "RLA 1234"
                },
                new Car
                {
                    Id = 2, Brand = "BMW", Model = "X5", FuelType = CarFuelType.Diesel, Year = 2019, NumberPlate = "RZ 1234"
                });

        modelBuilder.Entity<CarInfo>()
            .HasData(
                new CarInfo
                {
                    Id = 1, CarId = 1, InspectionDate = new DateTime(2020, 1, 1), InsuranceDate = new DateTime(2020, 1, 1),
                    OilChangeDate = new DateTime(2020, 1, 1), NextInspectionDate = new DateTime(2021, 1, 1),
                    NextInsuranceDate = new DateTime(2021, 1, 1), NextOilChangeDate = new DateTime(2021, 1, 1)
                },
                new CarInfo
                {
                    Id = 2, CarId = 1, InspectionDate = new DateTime(2021, 1, 1),
                    InsuranceDate = new DateTime(2021, 1, 1),
                    OilChangeDate = new DateTime(2021, 1, 1), NextInspectionDate = new DateTime(2022, 1, 1),
                    NextInsuranceDate = new DateTime(2022, 1, 1), NextOilChangeDate = new DateTime(2022, 1, 1)
                });
    }
}