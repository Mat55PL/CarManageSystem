namespace CarManageSystem.Domain.Entities;

public class MaintenanceItem
{
    public int Id { get; set; }
    public int MaintenanceId { get; set; }
    public string PartName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Cost { get; set; }
    
    public Maintenance Maintenance { get; set; }
}