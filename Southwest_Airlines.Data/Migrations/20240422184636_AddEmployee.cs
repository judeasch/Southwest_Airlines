using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Southwest_Airlines.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "FLIGHTS");

            //migrationBuilder.AddColumn<int>(
            //    name: "TicketId",
            //    table: "PAYMENTINFO",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "TotalNumberOfSeats",
                table: "FLIGHTS",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NumberOfSeats",
                table: "FLIGHTS",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfFastpasses",
                table: "FLIGHTS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EMPLOYEE",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPLOYEE", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeFlight",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    FlightId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeFlight", x => new { x.EmployeeId, x.FlightId });
                    table.ForeignKey(
                        name: "FK_EmployeeFlight_EMPLOYEE_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EMPLOYEE",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeFlight_FLIGHTS_FlightId",
                        column: x => x.FlightId,
                        principalTable: "FLIGHTS",
                        principalColumn: "FlightID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeFlight_FlightId",
                table: "EmployeeFlight",
                column: "FlightId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeFlight");

            migrationBuilder.DropTable(
                name: "EMPLOYEE");

            //migrationBuilder.DropColumn(
            //    name: "TicketId",
            //    table: "PAYMENTINFO");

            migrationBuilder.DropColumn(
                name: "NumberOfFastpasses",
                table: "FLIGHTS");

            migrationBuilder.AlterColumn<int>(
                name: "TotalNumberOfSeats",
                table: "FLIGHTS",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "NumberOfSeats",
                table: "FLIGHTS",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "FLIGHTS",
                type: "bit",
                nullable: true);
        }
    }
}
