namespace CarManageSystem.Domain.Entities;

public class Maintenance
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public DateOnly MaintenanceDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    public string Description { get; set; } = string.Empty;
    
    public Car Car { get; set; }
    public ICollection<MaintenanceItem> MaintenanceItems { get; set; } = new List<MaintenanceItem>();
}
