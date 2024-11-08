namespace CarManageSystem.Application.Maintenance.Dtos;

public class MaintenanceItemDto
{
    public int MaintenanceId { get; set; }
    public string PartName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Cost { get; set; }
}