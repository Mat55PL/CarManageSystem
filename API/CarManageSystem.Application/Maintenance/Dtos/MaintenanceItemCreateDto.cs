namespace CarManageSystem.Application.Maintenance.Dtos;

public class MaintenanceItemCreateDto
{
    public string PartName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Cost { get; set; }
}