using CarManagerAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarManagerAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarInfoController : ControllerBase
{
    private readonly CarInfoService _carInfoService;
    
    public CarInfoController(CarInfoService carInfoService)
    {
        _carInfoService = carInfoService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCarsInfo()
    {
        try
        {
            var cars = await _carInfoService.GetAllCarInfosAsync();
            return Ok(cars);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}