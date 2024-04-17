using CarManagerAPI.Data;
using CarManagerAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarManagerAPI.Services;

public class CarService
{
    private readonly DataContext _carDbContext;

    public CarService(DataContext context)
    {
        _carDbContext = context;
    }
    public async Task<IEnumerable<Car>> GetAllCarsAsync()
    {
        try
        {
            return await _carDbContext.Cars.ToListAsync();
        }
        catch (Exception ex)
        {
            throw new Exception("Could not retrieve cars", ex);
        }
    }
}