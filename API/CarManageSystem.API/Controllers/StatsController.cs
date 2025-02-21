using CarManageSystem.Application.Stats;
using Microsoft.AspNetCore.Mvc;

namespace CarManageSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StatsController(IStatsService statsService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetStats()
    {
        var carsCount = await statsService.GetCarsCount();
        var totalFuelCost = await statsService.GetTotalFuelCost();
        var totalServiceCost = await statsService.GetTotalServiceCost();
        
        return Ok(new
        {
            carsCount,
            totalFuelCost,
            totalServiceCost
        });
    }
}