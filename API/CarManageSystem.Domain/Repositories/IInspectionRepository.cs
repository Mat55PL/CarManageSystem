using CarManageSystem.Domain.Entities;

namespace CarManageSystem.Domain.Repositories;

public interface IInspectionRepository
{
    Task<IEnumerable<Inspection>> GetAllAsync();
    Task<Inspection> GetByIdAsync(int id);
    Task<IEnumerable<Inspection>> GetByCarIdAsync(int carId);
    Task<int> CreateAsync(Inspection inspection);
    Task UpdateAsync(Inspection inspection);
    Task DeleteAsync(Inspection inspection);
}