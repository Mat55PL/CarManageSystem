using System.ComponentModel.DataAnnotations;

namespace CarManageSystem.Application.Maintenance.Dtos;

public class MaintenanceCreateDto
{
    [Required]
    public int CarId { get; set; }

    [Required]
    public DateOnly MaintenanceDate { get; set; }
    
    public string Description { get; set; } = string.Empty;
}