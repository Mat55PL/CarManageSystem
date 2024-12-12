using System.ComponentModel.DataAnnotations;

namespace CarManageSystem.Application.Maintenance.Dtos;

public class MaintenanceUpdateDto
{
    [Required]
    public DateOnly MaintenanceDate { get; set; }
    
    public string Description { get; set; } = string.Empty;
}