using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarManagerAPI.Entities;

public class Car
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Brand { get; set; }
    [Required]
    public string Model { get; set; }
    [Required]
    [Range(1900, 2050)]
    public int Year { get; set; }
    [Required]
    [Range(0, int.MaxValue)]  //int.MaxValue is the maximum value for an integer
    public int Mileage { get; set; }
    [Required]
    public CarFuelType FuelType { get; set; }
}


public enum CarFuelType
{
    Gasoline,
    Diesel,
    Electric,
    Hybrid
}