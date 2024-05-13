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
    
    public async Task<Car> GetCarByIdAsync(int id)
    {
        try
        {
            return (await _carDbContext.Cars.FirstOrDefaultAsync(c => c.Id == id))!;
        }
        catch (Exception ex)
        {
            throw new Exception("Could not retrieve car", ex);
        }
    }
    
    public async Task<Car> AddCarAsync(Car car)
    {
        try
        {
            _carDbContext.Cars.Add(car);
            await _carDbContext.SaveChangesAsync();
            return car;
        }
        catch (Exception ex)
        {
            throw new Exception("Could not add car", ex);
        }
    }
    
    public async Task<Car> UpdateCarAsync(Car car)
    {
        try
        {
            _carDbContext.Cars.Update(car);
            await _carDbContext.SaveChangesAsync();
            return car;
        }
        catch (Exception ex)
        {
            throw new Exception("Could not update car", ex);
        }
    }
    
    public async Task DeleteCarAsync(int id)
    {
        try
        {
            var car = await _carDbContext.Cars.FirstOrDefaultAsync(c => c.Id == id);
            if (car == null)
            {
                throw new Exception("Car not found");
            }
            _carDbContext.Cars.Remove(car);
            await _carDbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception("Could not delete car", ex);
        }
    }
}