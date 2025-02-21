using CarManageSystem.Domain.Repositories;
using CarManageSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CarManageSystem.Infrastructure.Repositories;

internal class StatsRepository(CarDbContext dbContext) : IStatsRepository
{
    public async Task<int> GetCarsCountAsync()
    {
        var carsCount = await dbContext.Cars.CountAsync();
        return carsCount;
    }

    public async Task<decimal> GetTotalFuelCostAsync()
    {
        var fuelCost = await dbContext.FuelHistories.SumAsync(x => x.Cost);
        return fuelCost;
    }

    public async Task<decimal> GetTotalServiceCostAsync()
    {
        var serviceCost = await dbContext.MaintenanceItems.SumAsync(x => x.Cost);
        return serviceCost;
    }
}