using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MASFinal.Migrations
{
    /// <inheritdoc />
    public partial class change1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_GroundVehicles_BusId",
                table: "GroundVehicles");

            migrationBuilder.DropIndex(
                name: "IX_GroundVehicles_CamperId",
                table: "GroundVehicles");

            migrationBuilder.AlterColumn<Guid>(
                name: "CamperId",
                table: "GroundVehicles",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "BusId",
                table: "GroundVehicles",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_GroundVehicles_BusId",
                table: "GroundVehicles",
                column: "BusId",
                unique: true,
                filter: "[BusId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_GroundVehicles_CamperId",
                table: "GroundVehicles",
                column: "CamperId",
                unique: true,
                filter: "[CamperId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_GroundVehicles_BusId",
                table: "GroundVehicles");

            migrationBuilder.DropIndex(
                name: "IX_GroundVehicles_CamperId",
                table: "GroundVehicles");

            migrationBuilder.AlterColumn<Guid>(
                name: "CamperId",
                table: "GroundVehicles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "BusId",
                table: "GroundVehicles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

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
        }
    }
}
