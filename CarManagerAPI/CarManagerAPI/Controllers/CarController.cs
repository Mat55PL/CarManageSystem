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
}