using CarManageSystem.Application.Maintenance;
using CarManageSystem.Application.Maintenance.Dtos;
using CarManageSystem.Domain.Entities;
using CarManageSystem.Domain.Repositories;
using Microsoft.Extensions.Logging;
using Moq;

namespace CarManageSystem.Tests;

public class MaintenanceTest
{
    private Mock<IMaintenanceRepository> _maintenanceRepositoryMock;
    private Mock<ILogger<MaintenanceService>> _loggerMock;
    private MaintenanceService _maintenanceService;
    
    [SetUp]
    public void Setup()
    {
        _maintenanceRepositoryMock = new Mock<IMaintenanceRepository>();
        _loggerMock = new Mock<ILogger<MaintenanceService>>();
        _maintenanceService = new MaintenanceService(_maintenanceRepositoryMock.Object, _loggerMock.Object);
    }
[Test]
public async Task GetMaintenanceByIdAsync_ShouldReturnMaintenance_WhenMaintenanceExists()
{
    // Przygotowanie przykładowego obiektu zgodnego z wzorem JSON
    var expected = new Maintenance
    {
        Id = 1,
        CarId = 1,
        MaintenanceDate = new DateOnly(2024, 5, 8),
        Description = "Regular maintenance check.",
        MaintenanceItems = new List<MaintenanceItem>
        {
            new MaintenanceItem
            {
                MaintenanceId = 1,
                PartName = "Oil Change",
                Description = "Changed engine oil and replaced oil filter.",
                Cost = 100
            },
            new MaintenanceItem
            {
                MaintenanceId = 1,
                PartName = "Tire Rotation",
                Description = "Rotated all four tires.",
                Cost = 50
            }
        }
    };

    _maintenanceRepositoryMock
        .Setup(repo => repo.GetByIdAsync(1))
        .ReturnsAsync(expected);

    // Wywołanie testowanej metody
    var result = await _maintenanceService.GetMaintenanceByIdAsync(1);

    // Porównanie poszczególnych właściwości
    Assert.Multiple(() =>
    {
        Assert.That(result.Id, Is.EqualTo(expected.Id));
        Assert.That(result.CarId, Is.EqualTo(expected.CarId));
        Assert.That(result.MaintenanceDate, Is.EqualTo(expected.MaintenanceDate));
        Assert.That(result.Description, Is.EqualTo(expected.Description));
        Assert.That(result.MaintenanceItems.Count, Is.EqualTo(expected.MaintenanceItems.Count));

        for (int i = 0; i < expected.MaintenanceItems.Count; i++)
        {
            Assert.That(result.MaintenanceItems.ElementAt(i).MaintenanceId, Is.EqualTo(expected.MaintenanceItems.ElementAt(i).MaintenanceId));
            Assert.That(result.MaintenanceItems.ElementAt(i).PartName, Is.EqualTo(expected.MaintenanceItems.ElementAt(i).PartName));
            Assert.That(result.MaintenanceItems.ElementAt(i).Description, Is.EqualTo(expected.MaintenanceItems.ElementAt(i).Description));
            Assert.That(result.MaintenanceItems.ElementAt(i).Cost, Is.EqualTo(expected.MaintenanceItems.ElementAt(i).Cost));
        }
    });
}

[Test]
public async Task GetMaintenanceByIdAsync_ShouldReturnNull_WhenMaintenanceDoesNotExist()
{
    _maintenanceRepositoryMock
        .Setup(repo => repo.GetByIdAsync(555))
        .ReturnsAsync((Maintenance)null);

    var result = await _maintenanceService.GetMaintenanceByIdAsync(555);

    Assert.That(result, Is.Null);

    _loggerMock.Verify(log => log.Log(
        LogLevel.Information,
        It.IsAny<EventId>(),
        It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("Getting maintenance by id")),
        null,
        It.IsAny<Func<It.IsAnyType, Exception, string>?>()), Times.Once);

    _maintenanceRepositoryMock.Verify(repo => repo.GetByIdAsync(555), Times.Once);

}

[Test]
public async Task CreateMaintenanceAsync_ShouldReturnNewMaintenanceId_WhenMaintenanceIsCreated()
{
    var maintenanceCreateDto = new MaintenanceCreateDto
    {
        CarId = 1,
        MaintenanceDate = new DateOnly(2024, 5, 8),
        Description = "Regular maintenance check."
    };
    
    var expectedId = 0;
    
    _maintenanceRepositoryMock
        .Setup(repo => repo.CreateAsync(It.IsAny<Maintenance>()))
        .ReturnsAsync(expectedId);
    
    var result = await _maintenanceService.CreateMaintenanceAsync(maintenanceCreateDto);
    
    Assert.That(result, Is.EqualTo(expectedId));
    
    _maintenanceRepositoryMock.Verify(repo => repo.CreateAsync(It.Is<Maintenance>(m =>
        m.CarId == maintenanceCreateDto.CarId &&
        m.MaintenanceDate == maintenanceCreateDto.MaintenanceDate &&
        m.Description == maintenanceCreateDto.Description &&
        (m.MaintenanceItems == null || !m.MaintenanceItems.Any())
    )), Times.Once);
}




}