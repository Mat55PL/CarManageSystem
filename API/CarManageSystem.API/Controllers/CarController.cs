using CarManageSystem.Application.Cars;
using Microsoft.AspNetCore.Mvc;

namespace CarManageSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarController(ICarsService carsService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllCars()
    {
        var cars = await carsService.GetAllCars();
        return Ok(cars);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var car = await carsService.GetById(id);
        if (car is null)
            return NotFound();
        
        return Ok(car);
    }
}