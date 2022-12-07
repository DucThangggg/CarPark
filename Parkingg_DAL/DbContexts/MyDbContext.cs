using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Parking_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_DAL.DbContexts
{
    public class MyDbContext : DbContext
    {
        public DbSet<Employee_Entities> employee_Entities { get; set; } = null!;
        public DbSet<Car_Entities> car_Entities { get; set; } = null!;
        public DbSet<BookingOffice_Entities> bookingOffice_Entities { get; set; } = null!;
        public DbSet<ParkingLot_Entities> parkingLot_Entities { get; set; } = null!;
        public DbSet<Ticket_Entities> ticket_Entities { get; set; } = null!;
        public DbSet<Trip_Entities> trip_Entities { get; set; } = null!;
        public DbSet<User_Entities> user_Entities { get; set; } = null!;
        // Tạo hàm kết nối với SQL Server
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {

        }
      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            builder.Properties<DateOnly>()
                .HaveConversion<DateOnlyConverter>()
                .HaveColumnType("date");

            builder.Properties<TimeOnly>()
                .HaveConversion<TimeOnlyConverter>()
                .HaveColumnType("time");
        }
    }
    public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
    {
        public DateOnlyConverter() : base(
                dateOnly => dateOnly.ToDateTime(TimeOnly.MinValue),
                dateTime => DateOnly.FromDateTime(dateTime))
        {
        }
    }
    public class TimeOnlyConverter : ValueConverter<TimeOnly, TimeSpan>
    {
        public TimeOnlyConverter() : base(
                timeOnly => timeOnly.ToTimeSpan(),
                timeSpan => TimeOnly.FromTimeSpan(timeSpan))
        {
        }
    }
}
