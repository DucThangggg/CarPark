using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkingDAL.Migrations
{
    /// <inheritdoc />
    public partial class Parking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "employee_Entities",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmployeePhone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    EmployeeBrithday = table.Column<DateTime>(type: "date", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    EmployeeAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmployeeEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Account = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Department = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee_Entities", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "parkingLot_Entities",
                columns: table => new
                {
                    ParkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParkName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ParkPlace = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    ParkArea = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ParkPrice = table.Column<int>(type: "int", nullable: false),
                    ParkStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parkingLot_Entities", x => x.ParkId);
                });

            migrationBuilder.CreateTable(
                name: "trip_Entities",
                columns: table => new
                {
                    TripId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Destination = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Driver = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    CarType = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    MaximumOnlineTicketNumber = table.Column<int>(type: "int", nullable: false),
                    BookedTicketNumber = table.Column<int>(type: "int", nullable: false),
                    DepartureTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    DepartureDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trip_Entities", x => x.TripId);
                });

            migrationBuilder.CreateTable(
                name: "user_Entities",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Phone = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_Entities", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "car_Entities",
                columns: table => new
                {
                    LicensePlate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CarType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CarColor = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Company = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ParkId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_car_Entities", x => x.LicensePlate);
                    table.ForeignKey(
                        name: "FK_car_Entities_parkingLot_Entities_ParkId",
                        column: x => x.ParkId,
                        principalTable: "parkingLot_Entities",
                        principalColumn: "ParkId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "bookingOffice_Entities",
                columns: table => new
                {
                    OfficeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingOfficeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OfficePhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    OfficePlace = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OfficePrice = table.Column<int>(type: "int", nullable: false),
                    StartContractDeadline = table.Column<DateTime>(type: "date", nullable: false),
                    EndContractDeadline = table.Column<DateTime>(type: "date", nullable: false),
                    TripId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookingOffice_Entities", x => x.OfficeId);
                    table.ForeignKey(
                        name: "FK_bookingOffice_Entities_trip_Entities_TripId",
                        column: x => x.TripId,
                        principalTable: "trip_Entities",
                        principalColumn: "TripId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ticket_Entities",
                columns: table => new
                {
                    TicketId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    BookingTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    TripId = table.Column<int>(type: "int", nullable: false),
                    LicensePlate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ticket_Entities", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_ticket_Entities_car_Entities_LicensePlate",
                        column: x => x.LicensePlate,
                        principalTable: "car_Entities",
                        principalColumn: "LicensePlate",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ticket_Entities_trip_Entities_TripId",
                        column: x => x.TripId,
                        principalTable: "trip_Entities",
                        principalColumn: "TripId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bookingOffice_Entities_TripId",
                table: "bookingOffice_Entities",
                column: "TripId");

            migrationBuilder.CreateIndex(
                name: "IX_car_Entities_ParkId",
                table: "car_Entities",
                column: "ParkId");

            migrationBuilder.CreateIndex(
                name: "IX_ticket_Entities_LicensePlate",
                table: "ticket_Entities",
                column: "LicensePlate");

            migrationBuilder.CreateIndex(
                name: "IX_ticket_Entities_TripId",
                table: "ticket_Entities",
                column: "TripId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bookingOffice_Entities");

            migrationBuilder.DropTable(
                name: "employee_Entities");

            migrationBuilder.DropTable(
                name: "ticket_Entities");

            migrationBuilder.DropTable(
                name: "user_Entities");

            migrationBuilder.DropTable(
                name: "car_Entities");

            migrationBuilder.DropTable(
                name: "trip_Entities");

            migrationBuilder.DropTable(
                name: "parkingLot_Entities");
        }
    }
}
