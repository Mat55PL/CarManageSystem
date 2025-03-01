﻿// <auto-generated />
using System;
using CarManageSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarManageSystem.Infrastructure.Migrations
{
    [DbContext(typeof(CarDbContext))]
    [Migration("20250228231426_CarUsageHistory")]
    partial class CarUsageHistory
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("CarManageSystem.Domain.Entities.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CurrentUserId")
                        .HasColumnType("longtext");

                    b.Property<int>("FuelType")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NumberPlate")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Vin")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("WheelType")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("CarManageSystem.Domain.Entities.CarInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("InspectionDate")
                        .HasColumnType("date");

                    b.Property<DateOnly>("InsuranceDate")
                        .HasColumnType("date");

                    b.Property<DateOnly>("OilChangeDate")
                        .HasColumnType("date");

                    b.Property<DateOnly>("TireChangeDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.ToTable("CarsInfo");
                });

            modelBuilder.Entity("CarManageSystem.Domain.Entities.CarUsageHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("CarUsageHistories");
                });

            modelBuilder.Entity("CarManageSystem.Domain.Entities.FuelHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(65,30)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<double>("FuelAmount")
                        .HasColumnType("double");

                    b.Property<int>("FuelType")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Odometer")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("FuelHistories");
                });

            modelBuilder.Entity("CarManageSystem.Domain.Entities.Inspection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("InspectionDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("NextInspectionDate")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("Passed")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.ToTable("Inspections");
                });

            modelBuilder.Entity("CarManageSystem.Domain.Entities.Insurance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("InsuranceCompany")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateOnly>("InsuranceDate")
                        .HasColumnType("date");

                    b.Property<DateOnly>("InsuranceExpirationDate")
                        .HasColumnType("date");

                    b.Property<string>("PolicyNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.ToTable("Insurances");
                });

            modelBuilder.Entity("CarManageSystem.Domain.Entities.Maintenance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateOnly>("MaintenanceDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.ToTable("Maintenances");
                });

            modelBuilder.Entity("CarManageSystem.Domain.Entities.MaintenanceItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("MaintenanceId")
                        .HasColumnType("int");

                    b.Property<string>("PartName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("MaintenanceId");

                    b.ToTable("MaintenanceItems");
                });

            modelBuilder.Entity("CarManageSystem.Domain.Entities.Inspection", b =>
                {
                    b.HasOne("CarManageSystem.Domain.Entities.Car", "Car")
                        .WithMany("Inspections")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("CarManageSystem.Domain.Entities.Insurance", b =>
                {
                    b.HasOne("CarManageSystem.Domain.Entities.Car", "Car")
                        .WithMany("Insurances")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("CarManageSystem.Domain.Entities.Maintenance", b =>
                {
                    b.HasOne("CarManageSystem.Domain.Entities.Car", "Car")
                        .WithMany("Maintenances")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("CarManageSystem.Domain.Entities.MaintenanceItem", b =>
                {
                    b.HasOne("CarManageSystem.Domain.Entities.Maintenance", "Maintenance")
                        .WithMany("MaintenanceItems")
                        .HasForeignKey("MaintenanceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Maintenance");
                });

            modelBuilder.Entity("CarManageSystem.Domain.Entities.Car", b =>
                {
                    b.Navigation("Inspections");

                    b.Navigation("Insurances");

                    b.Navigation("Maintenances");
                });

            modelBuilder.Entity("CarManageSystem.Domain.Entities.Maintenance", b =>
                {
                    b.Navigation("MaintenanceItems");
                });
#pragma warning restore 612, 618
        }
    }
}
