using CarManageSystem.Domain.Entities;
using CarManageSystem.Domain.Repositories;
using CarManageSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CarManageSystem.Infrastructure.Repositories;

internal class MaintenanceRepository(CarDbContext dbContext) : IMaintenanceRepository
{
    public async Task<IEnumerable<Maintenance>> GetAllAsync()
    {
        var maintenances = await dbContext.Maintenances.ToListAsync();
        return maintenances;
    }

    public async Task<Maintenance?> GetByIdAsync(int id)
    {
        var maintenance = await dbContext.Maintenances
            .Include(m => m.MaintenanceItems)
            .FirstOrDefaultAsync(x => x.Id == id);
        return maintenance;
    }

    public async Task<IEnumerable<Maintenance>> GetByCarIdAsync(int carId)
    {
        var maintenances = await dbContext.Maintenances
            .Where(x => x.CarId == carId)
            .Include(m => m.MaintenanceItems)
            .ToListAsync();
        return maintenances;
    }

    public async Task<int> CreateAsync(Maintenance maintenance)
    {
        dbContext.Maintenances.Add(maintenance);
        await dbContext.SaveChangesAsync();
        return maintenance.Id;
    }

    public async Task UpdateAsync(Maintenance maintenance)
    {
        dbContext.Maintenances.Update(maintenance);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Maintenance maintenance)
    {
        dbContext.Maintenances.Remove(maintenance);
        await dbContext.SaveChangesAsync();
    }
}