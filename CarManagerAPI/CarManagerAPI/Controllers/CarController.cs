using CarManagerAPI.Entities;
using CarManagerAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarManagerAPI.Controllers;


[Route("api/[controller]")]
[ApiController]
public class CarController : ControllerBase
{
    private readonly CarService _carService;
    
    public CarController(CarService carService)
    {
        _carService = carService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllCars()
    {
        try
        {
            var cars = await _carService.GetAllCarsAsync();
            return Ok(cars);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCarById(int id)
    {
        try
        {
            var car = await _carService.GetCarByIdAsync(id);
            return Ok(car);
        }
        catch (Exception ex)
        {
            return StatusCode(204, ex.Message);
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> AddCar(Car car)
    {
        try
        {
            var newCar = await _carService.AddCarAsync(car);
            return Ok(newCar);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateCar(Car car)
    {
        try
        {
            var updatedCar = await _carService.UpdateCarAsync(car);
            return Ok(updatedCar);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCar(int id)
    {
        try
        {
            await _carService.DeleteCarAsync(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}