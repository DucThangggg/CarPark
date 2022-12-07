﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Parking_DAL.DbContexts;

#nullable disable

namespace ParkingDAL.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Parking_DAL.Entities.BookingOffice_Entities", b =>
                {
                    b.Property<int>("OfficeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OfficeId"));

                    b.Property<string>("BookingOfficeName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("EndContractDeadline")
                        .HasColumnType("date");

                    b.Property<string>("OfficePhone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("OfficePlace")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("OfficePrice")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartContractDeadline")
                        .HasColumnType("date");

                    b.Property<int>("TripId")
                        .HasColumnType("int");

                    b.HasKey("OfficeId");

                    b.HasIndex("TripId");

                    b.ToTable("bookingOffice_Entities");
                });

            modelBuilder.Entity("Parking_DAL.Entities.Car_Entities", b =>
                {
                    b.Property<string>("LicensePlate")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CarColor")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("CarType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ParkId")
                        .HasColumnType("int");

                    b.HasKey("LicensePlate");

                    b.HasIndex("ParkId");

                    b.ToTable("car_Entities");
                });

            modelBuilder.Entity("Parking_DAL.Entities.Employee_Entities", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<string>("Account")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("EmployeeAddress")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("EmployeeBrithday")
                        .HasColumnType("date");

                    b.Property<string>("EmployeeEmail")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("EmployeePhone")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("EmployeeId");

                    b.ToTable("employee_Entities");
                });

            modelBuilder.Entity("Parking_DAL.Entities.ParkingLot_Entities", b =>
                {
                    b.Property<int>("ParkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ParkId"));

                    b.Property<string>("ParkArea")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("ParkName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ParkPlace")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<int>("ParkPrice")
                        .HasColumnType("int");

                    b.Property<string>("ParkStatus")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ParkId");

                    b.ToTable("parkingLot_Entities");
                });

            modelBuilder.Entity("Parking_DAL.Entities.Ticket_Entities", b =>
                {
                    b.Property<int>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TicketId"));

                    b.Property<TimeSpan>("BookingTime")
                        .HasColumnType("time");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("LicensePlate")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("TripId")
                        .HasColumnType("int");

                    b.HasKey("TicketId");

                    b.HasIndex("LicensePlate");

                    b.HasIndex("TripId");

                    b.ToTable("ticket_Entities");
                });

            modelBuilder.Entity("Parking_DAL.Entities.Trip_Entities", b =>
                {
                    b.Property<int>("TripId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TripId"));

                    b.Property<int>("BookedTicketNumber")
                        .HasColumnType("int");

                    b.Property<string>("CarType")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<DateTime>("DepartureDate")
                        .HasColumnType("date");

                    b.Property<TimeSpan>("DepartureTime")
                        .HasColumnType("time");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Driver")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<int>("MaximumOnlineTicketNumber")
                        .HasColumnType("int");

                    b.HasKey("TripId");

                    b.ToTable("trip_Entities");
                });

            modelBuilder.Entity("Parking_DAL.Entities.User_Entities", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("Phone")
                        .HasColumnType("int");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("UserId");

                    b.ToTable("user_Entities");
                });

            modelBuilder.Entity("Parking_DAL.Entities.BookingOffice_Entities", b =>
                {
                    b.HasOne("Parking_DAL.Entities.Trip_Entities", "trip_Entities")
                        .WithMany("ListBookingOffice")
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("trip_Entities");
                });

            modelBuilder.Entity("Parking_DAL.Entities.Car_Entities", b =>
                {
                    b.HasOne("Parking_DAL.Entities.ParkingLot_Entities", "parkingLot_Entities")
                        .WithMany("ListCar")
                        .HasForeignKey("ParkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("parkingLot_Entities");
                });

            modelBuilder.Entity("Parking_DAL.Entities.Ticket_Entities", b =>
                {
                    b.HasOne("Parking_DAL.Entities.Car_Entities", "Car_Entities")
                        .WithMany("ListTicket")
                        .HasForeignKey("LicensePlate")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Parking_DAL.Entities.Trip_Entities", "trip_Entities")
                        .WithMany("ListTicket")
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car_Entities");

                    b.Navigation("trip_Entities");
                });

            modelBuilder.Entity("Parking_DAL.Entities.Car_Entities", b =>
                {
                    b.Navigation("ListTicket");
                });

            modelBuilder.Entity("Parking_DAL.Entities.ParkingLot_Entities", b =>
                {
                    b.Navigation("ListCar");
                });

            modelBuilder.Entity("Parking_DAL.Entities.Trip_Entities", b =>
                {
                    b.Navigation("ListBookingOffice");

                    b.Navigation("ListTicket");
                });
#pragma warning restore 612, 618
        }
    }
}
