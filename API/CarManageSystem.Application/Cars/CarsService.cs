using CarManageSystem.Application.Cars.Dtos;
using CarManageSystem.Domain.Entities;
using CarManageSystem.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace CarManageSystem.Application.Cars;

internal class CarsService(ICarsRepository carsRepository, ILogger<CarsService> logger) : ICarsService
{
    public async Task<IEnumerable<Car>> GetAllCars()
    {
        logger.LogInformation("Getting all cars");
        var cars = await carsRepository.GetAllAsync();
        return cars;
    }

    public async Task<Car?> GetById(int id)
    {
        logger.LogInformation("Getting car by id: {id}", id);
        var car = await carsRepository.GetByIdAsync(id);
        return car;
    }

    public async Task<int> Create(CreateCarDto createCarDto)
    {
        logger.LogInformation("Creating car");
        var car = new Car
        {
            Brand = createCarDto.Brand,
            Model = createCarDto.Model,
            Vin = createCarDto.Vin,
            Year = createCarDto.Year,
            FuelType = createCarDto.FuelType,
            WheelType = createCarDto.WheelType,
            NumberPlate = createCarDto.NumberPlate
        };
        
        int id = await carsRepository.CreateAsync(car);
        return id;
    }
}