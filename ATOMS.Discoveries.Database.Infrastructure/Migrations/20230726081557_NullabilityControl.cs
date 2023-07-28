using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atoms.Discoveries.Database.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NullabilityControl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MultiTools",
                keyColumn: "Id",
                keyValue: 16m,
                columns: new[] { "DiscoveryType", "Galaxy" },
                values: new object[] { "Ship", "Hilbert" });

            migrationBuilder.UpdateData(
                table: "MultiTools",
                keyColumn: "Id",
                keyValue: 17m,
                columns: new[] { "DiscoveryType", "Galaxy" },
                values: new object[] { "Ship", "Hilbert" });

            migrationBuilder.UpdateData(
                table: "Planets",
                keyColumn: "Id",
                keyValue: 8m,
                column: "Galaxy",
                value: "Hilbert");

            migrationBuilder.UpdateData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: 10m,
                column: "Name",
                value: "Katori de Loucura");

            migrationBuilder.InsertData(
                table: "SystemDiscoveries",
                columns: new[] { "Id", "Coordinates", "DiscovererId", "DiscoveryType", "Galaxy", "Name", "Notes", "SolarSystemId", "Tags", "Version" },
                values: new object[] { 18m, "0FE8:00B0:0C61:0089", 3m, "Cosmic structure", "Euclid", "Atlas Messenger", null, 1m, null, "Endurance" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SystemDiscoveries",
                keyColumn: "Id",
                keyValue: 18m);

            migrationBuilder.UpdateData(
                table: "MultiTools",
                keyColumn: "Id",
                keyValue: 16m,
                columns: new[] { "DiscoveryType", "Galaxy" },
                values: new object[] { "MultiTool", "Euclid" });

            migrationBuilder.UpdateData(
                table: "MultiTools",
                keyColumn: "Id",
                keyValue: 17m,
                columns: new[] { "DiscoveryType", "Galaxy" },
                values: new object[] { "MultiTool", "Euclid" });

            migrationBuilder.UpdateData(
                table: "Planets",
                keyColumn: "Id",
                keyValue: 8m,
                column: "Galaxy",
                value: "Euclid");

            migrationBuilder.UpdateData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: 10m,
                column: "Name",
                value: "Flameborn");
        }
    }
}
