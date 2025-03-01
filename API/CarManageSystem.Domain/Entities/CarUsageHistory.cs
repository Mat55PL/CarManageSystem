namespace CarManageSystem.Domain.Entities;

public class CarUsageHistory
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public string UserId { get; set; } = default!;
    public DateTime StartDate { get; set; }
}