using CarManagerAPI.Data;
using CarManagerAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarManagerAPI.Services;

public class CarInfoService
{
    private readonly DataContext _carDbContext;
    
    public CarInfoService(DataContext context)
    {
        _carDbContext = context;
    }
    
    public async Task<IEnumerable<CarInfo>> GetAllCarInfosAsync()
    {
        try
        {
            return await _carDbContext.CarInfos.ToListAsync();
        }
        catch (Exception ex)
        {
            throw new Exception("Could not retrieve car infos", ex);
        }
    }
}