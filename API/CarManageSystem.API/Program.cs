using CarManageSystem.Infrastructure.Extensions;
using CarManageSystem.Infrastructure.Seeders;
using CarManageSystem.Application.Extensions;

var builder = WebApplication.CreateBuilder(args);

//builder.WebHost.UseUrls("http://mattu.bieda.it:40076", "https://mattu.bieda.it:40076");
// Add services to the container.

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", build =>
    {
        build.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddControllers();

builder.Services.AddApplication();

builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var scope = app.Services.CreateScope();
// Seed the database with some initial data
var seeder = scope.ServiceProvider.GetRequiredService<ICarSeeder>();

await seeder.Seed();
// Configure the HTTP request pipeline.

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
