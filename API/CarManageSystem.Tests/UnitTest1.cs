using CarManageSystem.Domain.Entities;
using CarManageSystem.Application.Cars;
namespace CarManageSystem.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void CarInitTest()
    {
        var car = new Car
        {
            Id = 1,
            Brand = "Toyota",
            Model = "Corolla",
            Vin = "12345678901234567",
            Year = 2020,
            FuelType = CarFuelType.Gasoline,
            WheelType = TyreType.Summer,
            NumberPlate = "ABC123"
        };
        
        Assert.That(car.Id, Is.EqualTo(1));
        Assert.That(car.Brand, Is.EqualTo("Toyota"));
        Assert.That(car.Model, Is.EqualTo("Corolla"));
        Assert.That(car.Vin, Is.EqualTo("12345678901234567"));
        Assert.That(car.Year, Is.EqualTo(2020));
        Assert.That(car.FuelType, Is.EqualTo(CarFuelType.Gasoline));
        Assert.That(car.WheelType, Is.EqualTo(TyreType.Summer));
        Assert.That(car.NumberPlate, Is.EqualTo("ABC123"));
    }
    
    [Test]
    public void CarDefaultInitTest()
    {
        // Arrange & Act
        var car = new Car();

        // Assert
        Assert.That(car.Id, Is.EqualTo(default(int)));
        Assert.That(car.Brand, Is.EqualTo(default(string)));
        Assert.That(car.Model, Is.EqualTo(default(string)));
        Assert.That(car.Vin, Is.EqualTo(default(string)));
        Assert.That(car.Year, Is.EqualTo(default(int)));
        Assert.That(car.FuelType, Is.EqualTo(default(CarFuelType)));
        Assert.That(car.WheelType, Is.EqualTo(default(TyreType)));
        Assert.That(car.NumberPlate, Is.EqualTo(default(string)));
    }
}