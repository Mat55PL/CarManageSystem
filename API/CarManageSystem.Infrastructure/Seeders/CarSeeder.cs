using CarManageSystem.Domain.Entities;
using CarManageSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarManageSystem.Infrastructure.Seeders
{
    internal class CarSeeder : ICarSeeder
    {
        private readonly CarDbContext _context;

        public CarSeeder(CarDbContext context)
        {
            _context = context;
        }

        public async Task Seed()
        {
            if (await _context.Database.CanConnectAsync())
            {
                // Seedowanie samochodów
                if (!await _context.Cars.AnyAsync())
                {
                    var cars = GetCars();
                    _context.Cars.AddRange(cars);
                    await _context.SaveChangesAsync();
                }

                // Seedowanie przeglądów
                if (!await _context.Maintenances.AnyAsync())
                {
                    var maintenances = GetMaintenances();
                    _context.Maintenances.AddRange(maintenances);
                    await _context.SaveChangesAsync();
                }
            }
        }

        private IEnumerable<Car> GetCars()
        {
            List<Car> cars = new()
            {
                new Car
                {
                    Brand = "Toyota",
                    Model = "Corolla",
                    Year = 2021,
                    FuelType = CarFuelType.Gasoline,
                    WheelType = TyreType.Summer,
                    NumberPlate = "ABC123",
                    Vin = "JTNK4RBE0K3040001"
                },
                new Car
                {
                    Brand = "Ford",
                    Model = "Focus",
                    Year = 2020,
                    FuelType = CarFuelType.Diesel,
                    WheelType = TyreType.Winter,
                    NumberPlate = "DEF456",
                    Vin = "1FADP3K2XFL000000"
                },
                new Car
                {
                    Brand = "Tesla",
                    Model = "Model 3",
                    Year = 2022,
                    FuelType = CarFuelType.Electric,
                    WheelType = TyreType.AllSeason,
                    NumberPlate = "GHI789",
                    Vin = "5YJ3E1EA7KF000000"
                }
            };
            
            return cars;
        }

        private IEnumerable<Maintenance> GetMaintenances()
        {
            var cars = _context.Cars.ToList();
            List<Maintenance> maintenances = new();

            foreach (var car in cars)
            {
                var maintenance = new Maintenance
                {
                    CarId = car.Id,
                    MaintenanceDate = DateOnly.FromDateTime(DateTime.Now.AddMonths(-6)),
                    Description = "Regular maintenance check.",
                    MaintenanceItems = new List<MaintenanceItem>
                    {
                        new MaintenanceItem
                        {
                            PartName = "Oil Change",
                            Description = "Changed engine oil and replaced oil filter.",
                            Cost = 100.00m,
                        },
                        new MaintenanceItem
                        {
                            PartName = "Tire Rotation",
                            Description = "Rotated all four tires.",
                            Cost = 50.00m,
                        }
                    }
                };

                maintenances.Add(maintenance);
            }

            return maintenances;
        }
    }
}
