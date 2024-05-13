using CarManageSystem.Application.Cars;
using Microsoft.Extensions.DependencyInjection;

namespace CarManageSystem.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ICarsService, CarsService>();
    }
}