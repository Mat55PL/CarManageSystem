namespace CarManageSystem.Application.Maintenance.Dtos;

public class MaintenanceDto
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public DateOnly MaintenanceDate { get; set; }
    public string Description { get; set; }
    public List<MaintenanceItemDto> MaintenanceItems { get; set; } = new List<MaintenanceItemDto>();
}