using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Southwest_Airlines.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeFlightNumberOfSeats : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfFirstClassSeats",
                table: "FLIGHTS");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "FLIGHTS");

            migrationBuilder.AddColumn<int>(
                name: "TotalNumberOfSeats",
                table: "FLIGHTS",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalNumberOfSeats",
                table: "FLIGHTS");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfFirstClassSeats",
                table: "FLIGHTS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "FLIGHTS",
                type: "money",
                nullable: true);
        }
    }
}
