using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Atoms.Discoveries.Database.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "DiscoverySequence");

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiscoveryId = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NickName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Discoveries",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false, defaultValueSql: "NEXT VALUE FOR [DiscoverySequence]"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscoveryType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Coordinates = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Galaxy = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "Euclid"),
                    DiscovererId = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Platform = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "PC"),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discoveries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Discoveries_Users_DiscovererId",
                        column: x => x.DiscovererId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SolarSystems",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false, defaultValueSql: "NEXT VALUE FOR [DiscoverySequence]"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscoveryType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Coordinates = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Galaxy = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "Euclid"),
                    DiscovererId = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Platform = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "PC"),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DominantLifeform = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "Abadoned"),
                    Economy = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "None")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolarSystems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SolarSystems_Users_DiscovererId",
                        column: x => x.DiscovererId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Freighters",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false, defaultValueSql: "NEXT VALUE FOR [DiscoverySequence]"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscoveryType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Coordinates = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Galaxy = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "Euclid"),
                    DiscovererId = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Platform = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "PC"),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolarSystemId = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slots = table.Column<short>(type: "smallint", nullable: true),
                    Colors = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Freighters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Freighters_SolarSystems_SolarSystemId",
                        column: x => x.SolarSystemId,
                        principalTable: "SolarSystems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Freighters_Users_DiscovererId",
                        column: x => x.DiscovererId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Frigates",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false, defaultValueSql: "NEXT VALUE FOR [DiscoverySequence]"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscoveryType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Coordinates = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Galaxy = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "Euclid"),
                    DiscovererId = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Platform = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "PC"),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolarSystemId = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Colors = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frigates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Frigates_SolarSystems_SolarSystemId",
                        column: x => x.SolarSystemId,
                        principalTable: "SolarSystems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Frigates_Users_DiscovererId",
                        column: x => x.DiscovererId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Planets",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false, defaultValueSql: "NEXT VALUE FOR [DiscoverySequence]"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscoveryType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Coordinates = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Galaxy = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "Euclid"),
                    DiscovererId = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Platform = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "PC"),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolarSystemId = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    SentinelsActivity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Biome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Resources = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GrassColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SkyColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WaterColor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Planets_SolarSystems_SolarSystemId",
                        column: x => x.SolarSystemId,
                        principalTable: "SolarSystems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Planets_Users_DiscovererId",
                        column: x => x.DiscovererId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SystemDiscoveries",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false, defaultValueSql: "NEXT VALUE FOR [DiscoverySequence]"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscoveryType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Coordinates = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Galaxy = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "Euclid"),
                    DiscovererId = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Platform = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "PC"),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolarSystemId = table.Column<decimal>(type: "decimal(20,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemDiscoveries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SystemDiscoveries_SolarSystems_SolarSystemId",
                        column: x => x.SolarSystemId,
                        principalTable: "SolarSystems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SystemDiscoveries_Users_DiscovererId",
                        column: x => x.DiscovererId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Fauna",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false, defaultValueSql: "NEXT VALUE FOR [DiscoverySequence]"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscoveryType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Coordinates = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Galaxy = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "Euclid"),
                    DiscovererId = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Platform = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "PC"),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolarSystemId = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    PlanetId = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    Species = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TameProduct = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Height = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fauna", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fauna_Planets_PlanetId",
                        column: x => x.PlanetId,
                        principalTable: "Planets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Fauna_SolarSystems_SolarSystemId",
                        column: x => x.SolarSystemId,
                        principalTable: "SolarSystems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Fauna_Users_DiscovererId",
                        column: x => x.DiscovererId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MultiTools",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false, defaultValueSql: "NEXT VALUE FOR [DiscoverySequence]"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscoveryType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Coordinates = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Galaxy = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "Euclid"),
                    DiscovererId = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Platform = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "PC"),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolarSystemId = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    PlanetId = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Class = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Colors = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultiTools", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MultiTools_Planets_PlanetId",
                        column: x => x.PlanetId,
                        principalTable: "Planets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MultiTools_SolarSystems_SolarSystemId",
                        column: x => x.SolarSystemId,
                        principalTable: "SolarSystems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MultiTools_Users_DiscovererId",
                        column: x => x.DiscovererId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlanetDiscoveries",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false, defaultValueSql: "NEXT VALUE FOR [DiscoverySequence]"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscoveryType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Coordinates = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Galaxy = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "Euclid"),
                    DiscovererId = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Platform = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "PC"),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolarSystemId = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    PlanetId = table.Column<decimal>(type: "decimal(20,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanetDiscoveries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanetDiscoveries_Planets_PlanetId",
                        column: x => x.PlanetId,
                        principalTable: "Planets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlanetDiscoveries_SolarSystems_SolarSystemId",
                        column: x => x.SolarSystemId,
                        principalTable: "SolarSystems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlanetDiscoveries_Users_DiscovererId",
                        column: x => x.DiscovererId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Ships",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false, defaultValueSql: "NEXT VALUE FOR [DiscoverySequence]"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscoveryType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Coordinates = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Galaxy = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "Euclid"),
                    DiscovererId = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Platform = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "PC"),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolarSystemId = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    PlanetId = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Class = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slots = table.Column<short>(type: "smallint", nullable: true),
                    Colors = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ships_Planets_PlanetId",
                        column: x => x.PlanetId,
                        principalTable: "Planets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ships_SolarSystems_SolarSystemId",
                        column: x => x.SolarSystemId,
                        principalTable: "SolarSystems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ships_Users_DiscovererId",
                        column: x => x.DiscovererId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "NickName" },
                values: new object[,]
                {
                    { 1m, "Maverick von Fritzwilliams" },
                    { 2m, "Dragon Kreig" },
                    { 3m, "Nut" }
                });

            migrationBuilder.InsertData(
                table: "SolarSystems",
                columns: new[] { "Id", "Coordinates", "DiscovererId", "DiscoveryType", "Name", "Notes", "Tags", "Version" },
                values: new object[] { 1m, "0FE8:00B0:0C61:0089", 1m, "SolarSystem", "Felucia", null, null, "Endurance" });

            migrationBuilder.InsertData(
                table: "SolarSystems",
                columns: new[] { "Id", "Coordinates", "DiscovererId", "DiscoveryType", "DominantLifeform", "Economy", "Name", "Notes", "Tags", "Version" },
                values: new object[] { 2m, "04DF:00CA:0551:0197", 2m, "SolarSystem", "Korvax", "Tier2", "Kairn", null, null, "Endurance" });

            migrationBuilder.InsertData(
                table: "SolarSystems",
                columns: new[] { "Id", "Coordinates", "DiscovererId", "DiscoveryType", "DominantLifeform", "Economy", "Galaxy", "Name", "Notes", "Tags", "Version" },
                values: new object[] { 3m, "0EF6:00FB:0EE5:0025", 3m, "SolarSystem", "Gek", "Tier1", "Hilbert", "Mepacket", null, null, "Endurance" });

            migrationBuilder.InsertData(
                table: "Freighters",
                columns: new[] { "Id", "Colors", "Coordinates", "DiscovererId", "DiscoveryType", "Name", "Notes", "Slots", "SolarSystemId", "Tags", "Type", "Version" },
                values: new object[] { 14m, "Black, Yellow", "04DF:00CA:0551:0197", 1m, "Freighter", "MS-9 Yanagata", null, (short)40, 2m, null, "Resurgent", null });

            migrationBuilder.InsertData(
                table: "Frigates",
                columns: new[] { "Id", "Colors", "Coordinates", "DiscovererId", "DiscoveryType", "Name", "Notes", "SolarSystemId", "Tags", "Type", "Version" },
                values: new object[] { 15m, "Red, Black, White", "04DF:00CA:0551:0197", 3m, "Frigate", "Makojim's Omen", null, 1m, null, "Combat", null });

            migrationBuilder.InsertData(
                table: "MultiTools",
                columns: new[] { "Id", "Class", "Colors", "Coordinates", "DiscovererId", "DiscoveryType", "Name", "Notes", "PlanetId", "Size", "SolarSystemId", "Tags", "Type", "Version" },
                values: new object[] { 16m, "A", null, "0EF6:00FB:0EE5:0025", 3m, "MultiTool", "Messenger of the Anomaly G-2-92T", null, null, "Rifle", 3m, null, "Experimental", null });

            migrationBuilder.InsertData(
                table: "Planets",
                columns: new[] { "Id", "Biome", "Coordinates", "DiscovererId", "DiscoveryType", "GrassColor", "Name", "Notes", "Resources", "SentinelsActivity", "SkyColor", "SolarSystemId", "Tags", "Version", "WaterColor" },
                values: new object[,]
                {
                    { 4m, "Temperate", "0FE8:00B0:0C61:0089", 1m, "Planet", null, "Heff I", null, "Frost crystal, Emeril, Dioxite, Silver", "None", null, 1m, null, "Endurance", null },
                    { 5m, "Icebound", "0FE8:00B0:0C61:0089", 1m, "Planet", null, "Gefiant IV", null, "Star bulb, Emeril, Parafinium, Magnetized Ferrite", "Aggressive", null, 1m, null, "Endurance", null },
                    { 6m, "Arctic", "0FE8:00B0:0C61:0089", 1m, "Planet", null, "Ommones Gamma III", null, "Frost crystal, Emeril, Dioxite, Silver", "None", null, 1m, null, "Endurance", null },
                    { 7m, "Vapour", "04DF:00CA:0551:0197", 2m, "Planet", null, "Aydar II", null, "Sodium, Parafinium, Copper", "Aggressive", null, 2m, null, "Interceptor", null },
                    { 8m, "Viridescent", "0EF6:00FB:0EE5:0025", 2m, "Planet", null, "Adninkin Beta", null, "Star bulb, Copper, Parafinium, Salt", "High", null, 3m, null, "Singularity", null }
                });

            migrationBuilder.InsertData(
                table: "Ships",
                columns: new[] { "Id", "Class", "Colors", "Coordinates", "DiscovererId", "DiscoveryType", "Name", "Notes", "PlanetId", "Slots", "SolarSystemId", "Tags", "Type", "Version" },
                values: new object[] { 9m, "S", "White, Black, Red", "04DF:00CA:0551:0197", 3m, "Ship", "Flameborn", null, null, (short)25, 2m, null, "Interceptor", "Singularity" });

            migrationBuilder.InsertData(
                table: "Fauna",
                columns: new[] { "Id", "Coordinates", "DiscovererId", "DiscoveryType", "Height", "Name", "Notes", "PlanetId", "SolarSystemId", "Species", "Tags", "TameProduct", "Version" },
                values: new object[,]
                {
                    { 12m, "0FE8:00B0:0C61:0089", 1m, "Fauna", 1.2, "C. Livercoyllera", null, 4m, null, "Robot", null, null, null },
                    { 13m, "0FE8:00B0:0C61:0089", 1m, "Fauna", 1.7, "C. Potasamensium", null, 4m, null, "Robot", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "MultiTools",
                columns: new[] { "Id", "Class", "Colors", "Coordinates", "DiscovererId", "DiscoveryType", "Name", "Notes", "PlanetId", "Size", "SolarSystemId", "Tags", "Type", "Version" },
                values: new object[] { 17m, "B", null, "0EF6:00FB:0EE5:0025", 3m, "MultiTool", "Touch of Matter", null, 8m, "Rifle", 3m, null, "Alien", null });

            migrationBuilder.InsertData(
                table: "PlanetDiscoveries",
                columns: new[] { "Id", "Coordinates", "DiscovererId", "DiscoveryType", "Name", "Notes", "PlanetId", "SolarSystemId", "Tags", "Version" },
                values: new object[] { 11m, "0FE8:00B0:0C61:0089", 1m, "Base", "Felucia", null, 4m, null, null, "Endurance" });

            migrationBuilder.InsertData(
                table: "Ships",
                columns: new[] { "Id", "Class", "Colors", "Coordinates", "DiscovererId", "DiscoveryType", "Name", "Notes", "PlanetId", "Slots", "SolarSystemId", "Tags", "Type", "Version" },
                values: new object[] { 10m, "A", "White, Black, Orange", "04DF:00CA:0551:0197", 3m, "Ship", "Flameborn", null, 7m, (short)20, 2m, null, "Exotic", "Singularity" });

            migrationBuilder.CreateIndex(
                name: "IX_Discoveries_DiscovererId",
                table: "Discoveries",
                column: "DiscovererId");

            migrationBuilder.CreateIndex(
                name: "IX_Fauna_DiscovererId",
                table: "Fauna",
                column: "DiscovererId");

            migrationBuilder.CreateIndex(
                name: "IX_Fauna_PlanetId",
                table: "Fauna",
                column: "PlanetId");

            migrationBuilder.CreateIndex(
                name: "IX_Fauna_SolarSystemId",
                table: "Fauna",
                column: "SolarSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_Freighters_DiscovererId",
                table: "Freighters",
                column: "DiscovererId");

            migrationBuilder.CreateIndex(
                name: "IX_Freighters_SolarSystemId",
                table: "Freighters",
                column: "SolarSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_Frigates_DiscovererId",
                table: "Frigates",
                column: "DiscovererId");

            migrationBuilder.CreateIndex(
                name: "IX_Frigates_SolarSystemId",
                table: "Frigates",
                column: "SolarSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_DiscoveryId",
                table: "Images",
                column: "DiscoveryId");

            migrationBuilder.CreateIndex(
                name: "IX_MultiTools_DiscovererId",
                table: "MultiTools",
                column: "DiscovererId");

            migrationBuilder.CreateIndex(
                name: "IX_MultiTools_PlanetId",
                table: "MultiTools",
                column: "PlanetId");

            migrationBuilder.CreateIndex(
                name: "IX_MultiTools_SolarSystemId",
                table: "MultiTools",
                column: "SolarSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanetDiscoveries_DiscovererId",
                table: "PlanetDiscoveries",
                column: "DiscovererId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanetDiscoveries_PlanetId",
                table: "PlanetDiscoveries",
                column: "PlanetId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanetDiscoveries_SolarSystemId",
                table: "PlanetDiscoveries",
                column: "SolarSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_Planets_DiscovererId",
                table: "Planets",
                column: "DiscovererId");

            migrationBuilder.CreateIndex(
                name: "IX_Planets_SolarSystemId",
                table: "Planets",
                column: "SolarSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_Ships_DiscovererId",
                table: "Ships",
                column: "DiscovererId");

            migrationBuilder.CreateIndex(
                name: "IX_Ships_PlanetId",
                table: "Ships",
                column: "PlanetId");

            migrationBuilder.CreateIndex(
                name: "IX_Ships_SolarSystemId",
                table: "Ships",
                column: "SolarSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_SolarSystems_DiscovererId",
                table: "SolarSystems",
                column: "DiscovererId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemDiscoveries_DiscovererId",
                table: "SystemDiscoveries",
                column: "DiscovererId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemDiscoveries_SolarSystemId",
                table: "SystemDiscoveries",
                column: "SolarSystemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Discoveries");

            migrationBuilder.DropTable(
                name: "Fauna");

            migrationBuilder.DropTable(
                name: "Freighters");

            migrationBuilder.DropTable(
                name: "Frigates");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "MultiTools");

            migrationBuilder.DropTable(
                name: "PlanetDiscoveries");

            migrationBuilder.DropTable(
                name: "Ships");

            migrationBuilder.DropTable(
                name: "SystemDiscoveries");

            migrationBuilder.DropTable(
                name: "Planets");

            migrationBuilder.DropTable(
                name: "SolarSystems");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropSequence(
                name: "DiscoverySequence");
        }
    }
}
