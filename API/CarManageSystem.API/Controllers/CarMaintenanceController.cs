using CarManageSystem.Application.Maintenance;
using CarManageSystem.Application.Maintenance.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CarManageSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarMaintenanceController(IMaintenanceService maintenanceService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllMaintenance()
    {
        var maintenance = await maintenanceService.GetAllMaintenanceAsync();
        return Ok(maintenance);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var maintenance = await maintenanceService.GetMaintenanceByIdAsync(id);
        if (maintenance is null)
            return NotFound();
        
        return Ok(maintenance);
    }
    
    [HttpGet("car/{carId}")]
    public async Task<IActionResult> GetByCarId([FromRoute] int carId)
    {
        var maintenance = await maintenanceService.GetMaintenanceByCarIdAsync(carId);
        if (maintenance is null)
            return NotFound();
        
        return Ok(maintenance);
    }
    
}