using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Flights.Data.Migrations
{
    public partial class CreateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlaneModel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartureTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArrivalTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartureCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DestinationCity = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlightId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "ArrivalTime", "DepartureCity", "DepartureTime", "DestinationCity", "PlaneModel" },
                values: new object[] { new Guid("b40df168-468c-4cbc-bc4e-7c42e9be41f9"), new DateTime(2021, 3, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), "Iasi", new DateTime(2021, 3, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), "Amsterdam", "B1" });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "ArrivalTime", "DepartureCity", "DepartureTime", "DestinationCity", "PlaneModel" },
                values: new object[] { new Guid("07636c4e-c6e5-447f-a98f-42aa7cdc6af6"), new DateTime(2021, 3, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), "Iasi", new DateTime(2021, 3, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), "Londra", "B6" });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "FlightId", "User" },
                values: new object[,]
                {
                    { new Guid("b2ea9dd2-629d-4138-9e71-a459a5032c83"), new Guid("b40df168-468c-4cbc-bc4e-7c42e9be41f9"), "Popa Ion" },
                    { new Guid("bdcedd4a-b5bb-4da4-8216-02db5060fb8d"), new Guid("b40df168-468c-4cbc-bc4e-7c42e9be41f9"), "Rusu Lara" },
                    { new Guid("a7d31ced-4866-458f-b718-932eef0d8802"), new Guid("07636c4e-c6e5-447f-a98f-42aa7cdc6af6"), "Popescu Vasile" },
                    { new Guid("71dbdf43-43a8-45bc-8337-456119bd64b5"), new Guid("07636c4e-c6e5-447f-a98f-42aa7cdc6af6"), "Frunza Ioana" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_FlightId",
                table: "Reservations",
                column: "FlightId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Flights");
        }
    }
}
