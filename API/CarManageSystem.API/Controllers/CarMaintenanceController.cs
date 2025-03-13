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
    
    [HttpPost] // api/carMaintenance
    public async Task<IActionResult> Create([FromBody] MaintenanceCreateDto maintenanceCreateDto)
    {
        int id = await maintenanceService.CreateMaintenanceAsync(maintenanceCreateDto);
        return CreatedAtAction(nameof(GetById), new { id }, null);
    }
    
    [HttpPost("{maintenanceId}/maintenanceItem")] // api/carMaintenance/{maintenanceId}/maintenanceItem
    public async Task<IActionResult> AddMaintenanceItem([FromRoute] int maintenanceId, [FromBody] MaintenanceItemCreateDto maintenanceItemCreateDto)
    {
        var maintenanceItem = await maintenanceService.AddMaintenanceItemAsync(maintenanceId, maintenanceItemCreateDto);
        return CreatedAtAction(nameof(GetById), new { id = maintenanceItem.MaintenanceId }, null);
    }
    
    [HttpPut("{id}")] // api/carMaintenance/{id}
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] MaintenanceUpdateDto maintenanceUpdateDto)
    {
        await maintenanceService.UpdateMaintenanceAsync(id, maintenanceUpdateDto);
        if (maintenanceUpdateDto is null)
            return NotFound();

        return Ok();
    }
    
    [HttpPut("{maintenanceId}/maintenanceItem/{maintenanceItemId}")] // api/carMaintenance/{maintenanceId}/maintenanceItem/{maintenanceItemId}
    public async Task<IActionResult> UpdateMaintenanceItem([FromRoute] int maintenanceId, [FromRoute] int maintenanceItemId, [FromBody] MaintenanceItemUpdateDto maintenanceItemUpdateDto)
    {
        await maintenanceService.UpdateMaintenanceItemAsync(maintenanceId, maintenanceItemUpdateDto);
        if (maintenanceItemUpdateDto is null)
            return NotFound();

        return Ok();
    }
    
    [HttpDelete("{id}")] // api/carMaintenance/{id}
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var result = await maintenanceService.DeleteMaintenanceAsync(id);
        if (!result)
            return NotFound();

        return NoContent();
    }
    
}