namespace CarManageSystem.Domain.Entities;

public class Insurance
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public DateOnly InsuranceDate { get; set; }
    public DateOnly InsuranceExpirationDate { get; set; }
    public string InsuranceCompany { get; set; } = string.Empty;
    public string PolicyNumber { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    
    public Car Car { get; set; }
}