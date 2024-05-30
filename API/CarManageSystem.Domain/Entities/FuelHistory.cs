namespace CarManageSystem.Domain.Entities;

public class FuelHistory
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public DateTime Date { get; set; }
    public double FuelAmount { get; set; }
    public decimal Cost { get; set; }
    public int Odometer { get; set; }
    public CarFuelType FuelType { get; set; }
    public string Location { get; set; }
    public string Note { get; set; }
}