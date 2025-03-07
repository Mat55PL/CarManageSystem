using CarManageSystem.Application.Cars.Dtos;
using CarManageSystem.Domain.Entities;

namespace CarManageSystem.Application.Cars;

public interface ICarsService
{
    Task<IEnumerable<Car>> GetAllCars();
    Task<Car?> GetById(int id);
    Task<IEnumerable<CarUsageHistory>> GetCarUsageHistory(int carId);
    Task<int> Create(CreateCarDto createCarDto);
    Task Delete(int id);
    Task Update(int id, CarDto updateCarDto);
    Task UpdateCarCurrentUserId(int carId, string userId);
}