using CarManageSystem.Domain.Entities;

namespace CarManageSystem.Application.Cars;

public interface ICarsService
{
    Task<IEnumerable<Car>> GetAllCars();
    Task<Car?> GetById(int id);
}