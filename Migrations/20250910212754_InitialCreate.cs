using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectricalManagmentApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Consumers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    AccountNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Caption = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consumers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeterPoints",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Caption = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    CurrentTransoformationRatio = table.Column<double>(type: "REAL", nullable: false),
                    VoltageTransoformationRatio = table.Column<double>(type: "REAL", nullable: false),
                    ConsumerId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ReadingsId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeterPoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeterPoints_Consumers_ConsumerId",
                        column: x => x.ConsumerId,
                        principalTable: "Consumers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ElectricityMeters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SerialNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    InstallationDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    MeterPointId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectricityMeters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ElectricityMeters_MeterPoints_MeterPointId",
                        column: x => x.MeterPointId,
                        principalTable: "MeterPoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MetersReadings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Value = table.Column<double>(type: "REAL", nullable: false),
                    MeterPointId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetersReadings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MetersReadings_MeterPoints_MeterPointId",
                        column: x => x.MeterPointId,
                        principalTable: "MeterPoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ElectricityMeters_MeterPointId",
                table: "ElectricityMeters",
                column: "MeterPointId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MeterPoints_ConsumerId",
                table: "MeterPoints",
                column: "ConsumerId");

            migrationBuilder.CreateIndex(
                name: "IX_MetersReadings_MeterPointId",
                table: "MetersReadings",
                column: "MeterPointId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ElectricityMeters");

            migrationBuilder.DropTable(
                name: "MetersReadings");

            migrationBuilder.DropTable(
                name: "MeterPoints");

            migrationBuilder.DropTable(
                name: "Consumers");
        }
    }
}
