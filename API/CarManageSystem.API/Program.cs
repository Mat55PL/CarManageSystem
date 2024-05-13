using CarManageSystem.Infrastructure.Extensions;
using CarManageSystem.Infrastructure.Seeders;
using CarManageSystem.Application.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        corsPolicyBuilder =>
        {
            corsPolicyBuilder.WithOrigins("http://localhost:3000")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

builder.Services.AddControllers();

builder.Services.AddApplication();

builder.Services.AddInfrastructure(builder.Configuration);



var app = builder.Build();

var scope = app.Services.CreateScope();
// Seed the database with some initial data
var seeder = scope.ServiceProvider.GetRequiredService<ICarSeeder>();

await seeder.Seed();
// Configure the HTTP request pipeline.



app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
