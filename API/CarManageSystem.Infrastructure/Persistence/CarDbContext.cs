using CarManageSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManageSystem.Infrastructure.Persistence
{
    public class CarDbContext(DbContextOptions<CarDbContext> options) : DbContext(options)
    {
        internal DbSet<Car> Cars { get; set; }
        internal DbSet<CarInfo> CarsInfo { get; set; }
        internal DbSet<FuelHistory> FuelHistories { get; set; }
        internal DbSet<Insurance> Insurances { get; set; }
        internal DbSet<Inspection> Inspections { get; set; }
        internal DbSet<Maintenance> Maintenances { get; set; }
        internal DbSet<MaintenanceItem> MaintenanceItems { get; set; }
        internal DbSet<CarUsageHistory> CarUsageHistories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Konfiguracja relacji Car - Maintenance
            modelBuilder.Entity<Maintenance>()
                .HasOne(m => m.Car)
                .WithMany(c => c.Maintenances)
                .HasForeignKey(m => m.CarId)
                .OnDelete(DeleteBehavior.Cascade);

            // Konfiguracja relacji Maintenance - MaintenanceItem
            modelBuilder.Entity<MaintenanceItem>()
                .HasOne(mi => mi.Maintenance)
                .WithMany(m => m.MaintenanceItems)
                .HasForeignKey(mi => mi.MaintenanceId)
                .OnDelete(DeleteBehavior.Cascade);

            // Konfiguracja typu danych dla Cost
            modelBuilder.Entity<MaintenanceItem>()
                .Property(mi => mi.Cost)
                .HasColumnType("decimal(18,2)");
            
            // relacja Car z Inspection
            modelBuilder.Entity<Inspection>()
                .HasOne(i => i.Car)
                .WithMany(c => c.Inspections)
                .HasForeignKey(i => i.CarId)
                .OnDelete(DeleteBehavior.Cascade);
            
            // relacja Car z Insurance
            modelBuilder.Entity<Insurance>()
                .HasOne(i => i.Car)
                .WithMany(c => c.Insurances)
                .HasForeignKey(i => i.CarId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
