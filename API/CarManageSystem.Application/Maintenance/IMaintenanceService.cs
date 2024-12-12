using CarManageSystem.Application.Maintenance.Dtos;
using CarManageSystem.Domain.Entities;

namespace CarManageSystem.Application.Maintenance;

public interface IMaintenanceService
{
    Task<IEnumerable<MaintenanceDto>> GetAllMaintenanceAsync();
    Task<MaintenanceDto?> GetMaintenanceByIdAsync(int id);
    Task<IEnumerable<MaintenanceDto>> GetMaintenanceByCarIdAsync(int carId);
    Task<int> CreateMaintenanceAsync(MaintenanceCreateDto maintenanceCreateDto);
    Task UpdateMaintenanceAsync(int maintenanceId, MaintenanceUpdateDto maintenanceUpdateDto);
    Task<bool> DeleteMaintenanceAsync(int maintenanceId);
    
    // maintenenceitem methods
    
    Task<MaintenanceItem> AddMaintenanceItemAsync(int maintenanceId, MaintenanceItemCreateDto maintenanceItemCreateDto);
    Task<MaintenanceItem> UpdateMaintenanceItemAsync(int maintenanceId, MaintenanceItemUpdateDto maintenanceItemUpdateDto);
    Task<bool> DeleteMaintenanceItemAsync(int maintenanceId, int maintenanceItemId);
}