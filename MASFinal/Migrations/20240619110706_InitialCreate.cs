using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MASFinal.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adress",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HouseNumber = table.Column<int>(type: "int", nullable: false),
                    ApartmentNumber = table.Column<int>(type: "int", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adress", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CombustionEngines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Capacity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AverageFuelConsumption = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CombustionEngines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ElectricEngines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AveragePowerConsumption = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaximumChargingCurrent = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectricEngines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JoiningDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Client_Adress_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Adress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mechanics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateOfEmployment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GrossSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mechanics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mechanics_Adress_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Adress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DriveTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ElectricEngineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CombustionEngineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriveTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DriveTypes_CombustionEngines_CombustionEngineId",
                        column: x => x.CombustionEngineId,
                        principalTable: "CombustionEngines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DriveTypes_ElectricEngines_ElectricEngineId",
                        column: x => x.ElectricEngineId,
                        principalTable: "ElectricEngines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Boats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DailyRentalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NumberOfSeats = table.Column<int>(type: "int", nullable: false),
                    BuyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Power = table.Column<int>(type: "int", nullable: false),
                    DriveId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequiresHelmsmanLicense = table.Column<bool>(type: "bit", nullable: false),
                    Displacement = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HasSail = table.Column<bool>(type: "bit", nullable: false),
                    CanSleep = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Boats_DriveTypes_DriveId",
                        column: x => x.DriveId,
                        principalTable: "DriveTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroundVehicles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DailyRentalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NumberOfSeats = table.Column<int>(type: "int", nullable: false),
                    BuyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Power = table.Column<int>(type: "int", nullable: false),
                    DriveId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Mileage = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    NumberOfWheels = table.Column<int>(type: "int", nullable: false),
                    RimSize = table.Column<int>(type: "int", nullable: false),
                    BusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CamperId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    MaximumLaunchAngle = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DriveSystem = table.Column<int>(type: "int", nullable: true),
                    RequiresHelmsmanLicense = table.Column<bool>(type: "bit", nullable: true),
                    Displacement = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TrunkCapacity = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TypeOfBody = table.Column<int>(type: "int", nullable: true),
                    Equipment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasGenerator = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroundVehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroundVehicles_DriveTypes_DriveId",
                        column: x => x.DriveId,
                        principalTable: "DriveTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroundVehicles_GroundVehicles_BusId",
                        column: x => x.BusId,
                        principalTable: "GroundVehicles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GroundVehicles_GroundVehicles_CamperId",
                        column: x => x.CamperId,
                        principalTable: "GroundVehicles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Rents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RentalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RentalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BoatId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GroundVehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rents_Boats_BoatId",
                        column: x => x.BoatId,
                        principalTable: "Boats",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Rents_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rents_GroundVehicles_GroundVehicleId",
                        column: x => x.GroundVehicleId,
                        principalTable: "GroundVehicles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Repairs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RepairCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MechanicId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GroundVehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repairs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Repairs_GroundVehicles_GroundVehicleId",
                        column: x => x.GroundVehicleId,
                        principalTable: "GroundVehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Repairs_Mechanics_MechanicId",
                        column: x => x.MechanicId,
                        principalTable: "Mechanics",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Boats_DriveId",
                table: "Boats",
                column: "DriveId");

            migrationBuilder.CreateIndex(
                name: "IX_Client_AddressId",
                table: "Client",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_DriveTypes_CombustionEngineId",
                table: "DriveTypes",
                column: "CombustionEngineId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DriveTypes_ElectricEngineId",
                table: "DriveTypes",
                column: "ElectricEngineId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GroundVehicles_BusId",
                table: "GroundVehicles",
                column: "BusId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GroundVehicles_CamperId",
                table: "GroundVehicles",
                column: "CamperId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GroundVehicles_DriveId",
                table: "GroundVehicles",
                column: "DriveId");

            migrationBuilder.CreateIndex(
                name: "IX_Mechanics_AddressId",
                table: "Mechanics",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_BoatId",
                table: "Rents",
                column: "BoatId");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_ClientId",
                table: "Rents",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_GroundVehicleId",
                table: "Rents",
                column: "GroundVehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_GroundVehicleId",
                table: "Repairs",
                column: "GroundVehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_MechanicId",
                table: "Repairs",
                column: "MechanicId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rents");

            migrationBuilder.DropTable(
                name: "Repairs");

            migrationBuilder.DropTable(
                name: "Boats");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "GroundVehicles");

            migrationBuilder.DropTable(
                name: "Mechanics");

            migrationBuilder.DropTable(
                name: "DriveTypes");

            migrationBuilder.DropTable(
                name: "Adress");

            migrationBuilder.DropTable(
                name: "CombustionEngines");

            migrationBuilder.DropTable(
                name: "ElectricEngines");
        }
    }
}
