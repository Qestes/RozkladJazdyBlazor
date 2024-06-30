using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using RozkladJazdyBlazor.Data;

#nullable disable

namespace RozkladJazdyBlazor.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    agency_id = table.Column<string>(type: "TEXT", nullable: true),
                    agency_name = table.Column<string>(type: "TEXT", nullable: true),
                    agency_url = table.Column<string>(type: "TEXT", nullable: true),
                    agency_lang = table.Column<string>(type: "TEXT", nullable: true),
                    agency_timezone = table.Column<string>(type: "TEXT", nullable: true),
                    agency_phone = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Calendar_Dates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    service_id = table.Column<string>(type: "TEXT", nullable: true),
                    date = table.Column<string>(type: "TEXT", nullable: true),
                    exception_type = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calendar_Dates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    agency_id = table.Column<string>(type: "TEXT", nullable: true),
                    route_id = table.Column<string>(type: "TEXT", nullable: true),
                    route_long_name = table.Column<string>(type: "TEXT", nullable: true),
                    route_type = table.Column<string>(type: "TEXT", nullable: true),
                    route_color = table.Column<string>(type: "TEXT", nullable: true),
                    route_text_color = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stop_Times",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    trip_id = table.Column<string>(type: "TEXT", nullable: true),
                    stop_sequence = table.Column<string>(type: "TEXT", nullable: true),
                    stop_id = table.Column<string>(type: "TEXT", nullable: true),
                    arrival_time = table.Column<string>(type: "TEXT", nullable: true),
                    departure_time = table.Column<string>(type: "TEXT", nullable: true),
                    platform = table.Column<string>(type: "TEXT", nullable: true),
                    official_dist_traveled = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stop_Times", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    stop_id = table.Column<string>(type: "TEXT", nullable: true),
                    stop_name = table.Column<string>(type: "TEXT", nullable: true),
                    stop_lat = table.Column<string>(type: "TEXT", nullable: true),
                    stop_lon = table.Column<string>(type: "TEXT", nullable: true),
                    stop_IBNR = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stops", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transfers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    from_stop_id = table.Column<string>(type: "TEXT", nullable: true),
                    to_stop_id = table.Column<string>(type: "TEXT", nullable: true),
                    from_trip_id = table.Column<string>(type: "TEXT", nullable: true),
                    to_trip_id = table.Column<string>(type: "TEXT", nullable: true),
                    transfer_type = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transfers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    route_id = table.Column<string>(type: "TEXT", nullable: true),
                    service_id = table.Column<string>(type: "TEXT", nullable: true),
                    trip_id = table.Column<string>(type: "TEXT", nullable: true),
                    trip_short_name = table.Column<string>(type: "TEXT", nullable: true),
                    trip_headsign = table.Column<string>(type: "TEXT", nullable: true),
                    wheelchair_accessible = table.Column<string>(type: "TEXT", nullable: true),
                    bikes_allowed = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agencies");

            migrationBuilder.DropTable(
                name: "Calendar_Dates");

            migrationBuilder.DropTable(
                name: "Routes");

            migrationBuilder.DropTable(
                name: "Stop_Times");

            migrationBuilder.DropTable(
                name: "Stops");

            migrationBuilder.DropTable(
                name: "Transfers");

            migrationBuilder.DropTable(
                name: "Trips");
        }
    }
}
