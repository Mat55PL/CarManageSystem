using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarManagerAPI.Entities;

public class CarInfo
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required]
    public int CarId { get; set; }
    
    [ForeignKey("CarId")]
    public Car Car { get; set; }
    
    [Required]
    public DateTime InspectionDate { get; set; }
    
    [Required]
    public DateTime InsuranceDate { get; set; }
    
    [Required]
    public DateTime OilChangeDate { get; set; }
    
    [Required]
    public DateTime NextInspectionDate { get; set; }
    
    [Required]
    public DateTime NextInsuranceDate { get; set; }
    
    [Required]
    public DateTime NextOilChangeDate { get; set; }
}