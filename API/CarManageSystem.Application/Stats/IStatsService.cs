namespace CarManageSystem.Application.Stats;

public interface IStatsService
{
    Task<int> GetCarsCount();
    Task<decimal> GetTotalFuelCost();
    Task<decimal> GetTotalServiceCost();
}