using CarManageSystem.Domain.Entities;
using CarManageSystem.Domain.Repositories;
using CarManageSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CarManageSystem.Infrastructure.Repositories;

internal class CarInfosRepository(CarDbContext dbContext) : ICarInfoRepository
{
    public async Task<IEnumerable<CarInfo>> GetAllAsync()
    {
        var carInfos = await dbContext.CarsInfo.ToListAsync();
        return carInfos;
    }

    public async Task<IEnumerable<CarInfo>> GetByCarIdAsync(int carId)
    {
        var carInfos = await dbContext.CarsInfo.Where(car => car.CarId == carId).ToListAsync();
        return carInfos;
    }

    public async Task<CarInfo?> GetByIdAsync(int id)
    {
        var carInfo = await dbContext.CarsInfo.FirstOrDefaultAsync(car => car.Id == id);
        return carInfo;
    }

    public async Task<int> CreateAsync(CarInfo carInfo)
    {
        dbContext.CarsInfo.Add(carInfo);
        await dbContext.SaveChangesAsync();
        return carInfo.Id;
    }
}