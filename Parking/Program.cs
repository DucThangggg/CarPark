using Microsoft.EntityFrameworkCore;
using Parking_DAL.DbContexts;
using Parking_DAL.Repository;
using Parking_DAL.UnitOfWork;
using AutoMapper;
using Parking_BLL.Service;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Parking_DAL.Repository.Interface;
using Parking_DAL.Repository.Implement;
using Parking_BLL.Service.Interface;
using Parking_BLL.Service.Implement;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add services sử dụng DataOnly và TimeOnly
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
        options.JsonSerializerOptions.Converters.Add(new TimeOnlyJsonConverter());
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// Add services sử dụng DataOnly và TimeOnly
builder.Services.AddSwaggerGen(options =>
{
    options.MapType<DateOnly>(() => new OpenApiSchema
    {
        Type = "string",
        Format = "date",
        Example = new OpenApiString("2022-01-01")
    });
    options.MapType<TimeOnly>(() => new OpenApiSchema
    {
        Type = "string",
        Format = "time",
        Example = new OpenApiString("10:10:05")
    });
});
// Add database SQL Server (chuỗi kết nối)
builder.Services.AddDbContext<MyDbContext>(
    dbContextOptions => dbContextOptions.UseSqlServer("Data Source=DESKTOP-171AVQP\\MSSQLSERVER03;Initial Catalog=ParkingCar;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true"));
// Add Service Employee Repository
builder.Services.AddScoped<IEmployeeInfoRepository, EmployeeInfoRepository>();
// Add Service Booking Office Repository
builder.Services.AddScoped<IBookingOfficeInfoRepository, BookingInfoRepository>();
// Add Service Trip Repository
builder.Services.AddScoped<ITripInfoRepository, TripInfoRepository>();
// Add Service Ticket Repository
builder.Services.AddScoped<ITicketInfoRepository, TicketInfoRepository>();
// Add Service Car Repository
builder.Services.AddScoped<ICarInfoRepository, CarInfoRepository>();
// Add Service ParkingLot Repository
builder.Services.AddScoped<IParkingLotInfoRepository, ParkingLotInfoRepository>();
// Add Service User Repository
builder.Services.AddScoped<IUserInfoRepository, UserInfoRepository>();
// Add Service Unit Of Work
builder.Services.AddScoped<IParking_UnitOfWork, Parking_UnitOfWork>();
// Add Service EmployeeBLL
builder.Services.AddScoped<IEmployeeBLL, EmployeeBLL>();
// Add Service TripBLL
builder.Services.AddScoped<ITripBLL, TripBLL>();
// Add Service BookingOfficeBLL
builder.Services.AddScoped<IBookingOfficeBLL, BookingOfficeBLL>();
// Add Service TicketBLL
builder.Services.AddScoped<ITicketBLL, TicketBLL>();
// Add Service CarBLL
builder.Services.AddScoped<ICarBLL, CarBLL>();
// Add Service ParkingLotBLL
builder.Services.AddScoped<IParkingLotBLL, ParkingLotBLL>();
// Add Service UserBLL
builder.Services.AddScoped<IUserBLL, UserBLL>();
// Thêm sử dụng AutoMap
object value = builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddAuthentication("Bearer").AddJwtBearer(options =>
{
    options.TokenValidationParameters = new()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Authentication:Issuer"],
        ValidAudience = builder.Configuration["Authentication:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.ASCII.GetBytes(builder.Configuration["Authentication:SecretForkey"]))
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("MustBeEmployee", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("name", "Thang");
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
