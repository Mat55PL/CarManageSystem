using CarManageSystem.Application.Maintenance.Dtos;
using CarManageSystem.Domain.Entities;
using CarManageSystem.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace CarManageSystem.Application.Maintenance;

public class MaintenanceService(IMaintenanceRepository maintenanceRepository, ILogger<MaintenanceService> logger) : IMaintenanceService
{
    public async Task<IEnumerable<MaintenanceDto>> GetAllMaintenanceAsync()
    {
        logger.LogInformation("Getting all maintenance");
        var maintenances = await maintenanceRepository.GetAllAsync();
        
        var maintenanceDtos = maintenances.Select(maintenance => new MaintenanceDto
        {
            Id = maintenance.Id,
            CarId = maintenance.CarId,
            MaintenanceDate = maintenance.MaintenanceDate,
            Description = maintenance.Description,
            MaintenanceItems = maintenance.MaintenanceItems.Select(mi => new MaintenanceItemDto
            {
                MaintenanceId = mi.MaintenanceId,
                PartName = mi.PartName,
                Description = mi.Description,
                Cost = mi.Cost,
            }).ToList()
        }).ToList();

        return maintenanceDtos;
    }

    public async Task<MaintenanceDto?> GetMaintenanceByIdAsync(int id)
    {
        logger.LogInformation("Getting maintenance by id {Id}", id);
        var maintenance = await maintenanceRepository.GetByIdAsync(id);
        if (maintenance == null)
            return null;
        
        var maintenanceDto = new MaintenanceDto
        {
            Id = maintenance.Id,
            CarId = maintenance.CarId,
            MaintenanceDate = maintenance.MaintenanceDate,
            Description = maintenance.Description,
            MaintenanceItems = maintenance.MaintenanceItems.Select(mi => new MaintenanceItemDto
            {
                MaintenanceId = mi.MaintenanceId,
                PartName = mi.PartName,
                Description = mi.Description,
                Cost = mi.Cost,
            }).ToList()
        };
        
        return maintenanceDto;
    }

    public async Task<IEnumerable<MaintenanceDto>> GetMaintenanceByCarIdAsync(int carId)
    {
        logger.LogInformation("Getting maintenance by car id {CarId}", carId);
        var maintenances = await maintenanceRepository.GetByCarIdAsync(carId);
        
        var maintenanceDtos = maintenances.Select(maintenance => new MaintenanceDto
        {
            Id = maintenance.Id,
            CarId = maintenance.CarId,
            MaintenanceDate = maintenance.MaintenanceDate,
            Description = maintenance.Description,
            MaintenanceItems = maintenance.MaintenanceItems.Select(mi => new MaintenanceItemDto
            {
                MaintenanceId = mi.MaintenanceId,
                PartName = mi.PartName,
                Description = mi.Description,
                Cost = mi.Cost,
            }).ToList()
        }).ToList();
        
        return maintenanceDtos;
    }

    public async Task<int> CreateMaintenanceAsync(MaintenanceCreateDto maintenanceCreateDto)
    {
        var maintenance = new Domain.Entities.Maintenance
        {
            CarId = maintenanceCreateDto.CarId,
            MaintenanceDate = maintenanceCreateDto.MaintenanceDate,
            Description = maintenanceCreateDto.Description,
            MaintenanceItems = new List<MaintenanceItem>() // Pusta lista na start
        };
        
        await maintenanceRepository.CreateAsync(maintenance);
        
        return maintenance.Id;
    }

    public async Task UpdateMaintenanceAsync(int maintenanceId, MaintenanceUpdateDto maintenanceUpdateDto)
    {
        var maintenance = await maintenanceRepository.GetByIdAsync(maintenanceId);
        if (maintenance == null)
            throw new KeyNotFoundException("Maintenance not found");

        // Aktualizacja właściwości
        maintenance.MaintenanceDate = maintenanceUpdateDto.MaintenanceDate;
        maintenance.Description = maintenanceUpdateDto.Description;

        await maintenanceRepository.UpdateAsync(maintenance);
        
    }

    public async Task<bool> DeleteMaintenanceAsync(int maintenanceId)
    {
        var maintenance = await maintenanceRepository.GetByIdAsync(maintenanceId);
        if (maintenance == null)
            return false;

        await maintenanceRepository.DeleteAsync(maintenance);

        return true;
    }

    public async Task<MaintenanceItem> AddMaintenanceItemAsync(int maintenanceId, MaintenanceItemCreateDto maintenanceItemCreateDto)
    {
        var maintenance = await maintenanceRepository.GetByIdAsync(maintenanceId);
        if (maintenance == null)
            throw new KeyNotFoundException("Maintenance not found");

        // Manualne mapowanie MaintenanceItemCreateDto do MaintenanceItem
        var maintenanceItem = new MaintenanceItem
        {
            MaintenanceId = maintenanceId,
            PartName = maintenanceItemCreateDto.PartName,
            Description = maintenanceItemCreateDto.Description,
            Cost = maintenanceItemCreateDto.Cost,
        };

        maintenance.MaintenanceItems.Add(maintenanceItem);
        await maintenanceRepository.UpdateAsync(maintenance);

        return maintenanceItem;
    }

    public async Task<MaintenanceItem> UpdateMaintenanceItemAsync(int maintenanceId, MaintenanceItemUpdateDto maintenanceItemUpdateDto)
    {
        var maintenance = await maintenanceRepository.GetByIdAsync(maintenanceId);
        if (maintenance == null)
            throw new KeyNotFoundException("Maintenance not found");

        var maintenanceItem = maintenance.MaintenanceItems.FirstOrDefault(mi => mi.Id == maintenanceId);
        if (maintenanceItem == null)
            throw new KeyNotFoundException("MaintenanceItem not found");

        // Aktualizacja właściwości
        maintenanceItem.PartName = maintenanceItemUpdateDto.PartName;
        maintenanceItem.Description = maintenanceItemUpdateDto.Description;
        maintenanceItem.Cost = maintenanceItemUpdateDto.Cost;

        await maintenanceRepository.UpdateAsync(maintenance);

        return maintenanceItem;
    }

    public async Task<bool> DeleteMaintenanceItemAsync(int maintenanceId, int maintenanceItemId)
    {
        var maintenance = await maintenanceRepository.GetByIdAsync(maintenanceId);
        if (maintenance is null)
            return false;

        var maintenanceItem = maintenance.MaintenanceItems.FirstOrDefault(mi => mi.Id == maintenanceItemId);
        if (maintenanceItem == null)
            return false;

        maintenance.MaintenanceItems.Remove(maintenanceItem);
        await maintenanceRepository.UpdateAsync(maintenance);

        return true;
    }
}