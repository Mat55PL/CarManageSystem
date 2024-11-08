namespace CarManageSystem.Domain.Entities;
// przegląd techniczny pojazdu
public class Inspection
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public DateTime InspectionDate { get; set; } = DateTime.Now;
    public DateTime NextInspectionDate { get; set; }
    public bool Passed { get; set; }
    public string Description { get; set; } = string.Empty;
    
    public Car Car { get; set; }
}
