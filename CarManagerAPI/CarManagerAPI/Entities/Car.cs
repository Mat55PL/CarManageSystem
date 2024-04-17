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
    public CarFuelType FuelType { get; set; }
}


public enum CarFuelType
{
    Gasoline,
    Diesel,
    Electric,
    Hybrid
}