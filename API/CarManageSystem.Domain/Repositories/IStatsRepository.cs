namespace CarManageSystem.Domain.Repositories;

public interface IStatsRepository
{
    Task<int> GetCarsCountAsync();
    Task<decimal> GetTotalFuelCostAsync();
    Task<decimal> GetTotalServiceCostAsync();
}