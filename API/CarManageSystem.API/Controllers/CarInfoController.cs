using CarManageSystem.Application.CarsInfo;
using CarManageSystem.Application.CarsInfo.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CarManageSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarInfoController(ICarsInfoService carsInfoService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllCarsInfo()
    {
        var carsInfo = await carsInfoService.GetAllCarsInfoAsync();
        return Ok(carsInfo);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var carInfo = await carsInfoService.GetCarInfoByIdAsync(id);
        if (carInfo is null)
            return NotFound();
        
        return Ok(carInfo);
    }
    
    [HttpGet("Car/{carId}")]
    public async Task<IActionResult> GetByCarId([FromRoute] int carId)
    {
        var carInfo = await carsInfoService.GetCarInfoByCarIdAsync(carId);
        if (carInfo is null)
            return NotFound();
        
        return Ok(carInfo);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCarInfoDto createCarInfoDto)
    {
        int id = await carsInfoService.CreateCarInfoAsync(createCarInfoDto);
        return CreatedAtAction(nameof(GetById), new { id }, null);
    }
}