namespace CarManageSystem.Domain.Entities;

public class CarLicence
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public string NumberPlate { get; set; } = default!;
    public string Vin { get; set; } = default!;
    public DateOnly ExpiryDate { get; set; }
}