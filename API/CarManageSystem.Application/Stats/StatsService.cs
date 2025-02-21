using CarManageSystem.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace CarManageSystem.Application.Stats;

public class StatsService(IStatsRepository statsRepository, ILogger<StatsService> logger) : IStatsService
{
    public async Task<int> GetCarsCount()
    {
        logger.LogInformation("[GET] cars count on datetime: {datetime}", DateTime.Now);
        var carsCount = await statsRepository.GetCarsCountAsync();
        return carsCount;
    }
    
    public async Task<decimal> GetTotalFuelCost()
    {
        logger.LogInformation("[GET] total fuel cost on datetime: {datetime}", DateTime.Now);
        var fuelCost = await statsRepository.GetTotalFuelCostAsync();
        return fuelCost;
    }
    
    public async Task<decimal> GetTotalServiceCost()
    {
        logger.LogInformation("[GET] total service cost on datetime: {datetime}", DateTime.Now);
        var serviceCost = await statsRepository.GetTotalServiceCostAsync();
        return serviceCost;
    }
}