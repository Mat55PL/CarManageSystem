using CarManageSystem.Application.Cars.Dtos;
using CarManageSystem.Domain.Entities;
using CarManageSystem.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace CarManageSystem.Application.Cars;

public class CarsService(ICarsRepository carsRepository, ILogger<CarsService> logger) : ICarsService
{
    public async Task<IEnumerable<Car>> GetAllCars()
    {
        logger.LogInformation("Getting all cars on datetime: {datetime}", DateTime.Now);
        var cars = await carsRepository.GetAllAsync();
        return cars;
    }

    public async Task<Car?> GetById(int id)
    {
        logger.LogInformation("Getting car by id: {id} on datetime: {datetime}", id, DateTime.Now);
        var car = await carsRepository.GetByIdAsync(id);
        return car;
    }

    public async Task<IEnumerable<CarUsageHistory>> GetCarUsageHistory(int carId)
    {
        logger.LogInformation("Getting car usage history by carId: {carId} on datetime: {datetime}", carId, DateTime.Now);
        var usageHistory = await carsRepository.GetCarUsageHistoryAsync(carId);
        return usageHistory;
    }

    public async Task<int> Create(CreateCarDto createCarDto)
    {
        logger.LogInformation("Creating car on datetime: {datetime}", DateTime.Now);
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

    public async Task Delete(int id)
    {
        logger.LogInformation("Deleting car by id: {id} at {datetime}", id, DateTime.Now);
        await carsRepository.DeleteAsync(id);
    }

    public async Task Update(int id, CarDto updateCarDto)
    {
        logger.LogInformation("Updating car by id: {id} at {datetime}", id, DateTime.Now);
        var car = new Car
        {
            Id = id,
            Brand = updateCarDto.Brand,
            Model = updateCarDto.Model,
            Vin = updateCarDto.Vin,
            Year = updateCarDto.Year,
            FuelType = updateCarDto.FuelType,
            WheelType = updateCarDto.WheelType,
            NumberPlate = updateCarDto.NumberPlate
        };
        
        await carsRepository.UpdateAsync(car);
    }

    public async Task UpdateCarCurrentUserId(int carId, string userId)
    {
        logger.LogInformation("Updating car current user {userId} with id {id} at [{datetime}]", userId, carId, DateTime.Now);
        await carsRepository.UpdateCarCurrentUserIdAsync(carId, userId);
    }
}