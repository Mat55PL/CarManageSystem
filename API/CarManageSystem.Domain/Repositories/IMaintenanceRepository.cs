using CarManageSystem.Domain.Entities;

namespace CarManageSystem.Domain.Repositories;

public interface IMaintenanceRepository
{
    Task<IEnumerable<Maintenance>> GetAllAsync();
    Task<Maintenance?> GetByIdAsync(int id);
    Task<IEnumerable<Maintenance>> GetByCarIdAsync(int carId);
    Task<int> CreateAsync(Maintenance maintenance);
    Task UpdateAsync(Maintenance maintenance);
    Task DeleteAsync(Maintenance maintenance);
}