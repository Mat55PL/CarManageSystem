namespace CarManageSystem.Domain.Entities;

public class Car
{
    public int Id { get; set; }
    public string Brand { get; set; } = default!;
    public string Model { get; set; } = default!;
    public string Vin { get; set; } = default!;
    public int Year { get; set; }
    public CarFuelType FuelType { get; set; }
    public TyreType WheelType { get; set; }
    public string NumberPlate { get; set; } = default!;
    
    public ICollection<Inspection> Inspections { get; set; } = new List<Inspection>();
    public ICollection<Maintenance> Maintenances { get; set; } = new List<Maintenance>();
    public ICollection<Insurance> Insurances { get; set; } = new List<Insurance>();
    
}

public enum CarFuelType
{
    Gasoline,
    Diesel,
    Electric,
    Hybrid,
    LPG,
    CNG,
    Hydrogen,
    Other,
}

public enum TyreType
{
    Summer,
    Winter,
    AllSeason
}