using CarManageSystem.Domain.Entities;

namespace CarManageSystem.Domain.Repositories;

public interface IInsuranceRepository
{
    Task<IEnumerable<Insurance>> GetAllAsync();
    Task<Insurance> GetByIdAsync(int id);
    Task<IEnumerable<Insurance>> GetByCarIdAsync(int carId);
    Task<int> CreateAsync(Insurance insurance);
    Task UpdateAsync(Insurance insurance);
    Task DeleteAsync(Insurance insurance);
}