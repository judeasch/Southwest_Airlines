using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Southwest_Airlines.Data.Migrations
{
    /// <inheritdoc />
    public partial class MapUserToEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "EMPLOYEE",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEE_UserId",
                table: "EMPLOYEE",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_EMPLOYEE_AspNetUsers_UserId",
                table: "EMPLOYEE",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EMPLOYEE_AspNetUsers_UserId",
                table: "EMPLOYEE");

            migrationBuilder.DropIndex(
                name: "IX_EMPLOYEE_UserId",
                table: "EMPLOYEE");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "EMPLOYEE");
        }
    }
}
