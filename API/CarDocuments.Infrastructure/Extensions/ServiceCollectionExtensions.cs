using CarDocuments.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarDocuments.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DocumentsDbConnection");
        var serverVersion = ServerVersion.AutoDetect(connectionString);
        services.AddDbContext<DocumentDbContext>(options => options.UseMySql(connectionString, serverVersion));
    }
}