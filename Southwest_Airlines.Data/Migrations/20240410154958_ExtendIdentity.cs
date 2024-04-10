using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Southwest_Airlines.Data.Migrations
{
    /// <inheritdoc />
    public partial class ExtendIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CUSTOMERS_LoginID",
                table: "CUSTOMERS");

            migrationBuilder.DropForeignKey(
                name: "FK_CUSTOMERS_AspNetUsers_LoginID",
                table: "CUSTOMERS");

            migrationBuilder.DropColumn(
                name: "LoginID",
                table: "CUSTOMERS");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DepartureTime",
                table: "FLIGHTS",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ArrivalTime",
                table: "FLIGHTS",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "CUSTOMERS",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CUSTOMERS_UserId",
                table: "CUSTOMERS",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_CUSTOMERS_AspNetUsers_UserId",
                table: "CUSTOMERS",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CUSTOMERS_AspNetUsers_UserId",
                table: "CUSTOMERS");

            migrationBuilder.DropIndex(
                name: "IX_CUSTOMERS_UserId",
                table: "CUSTOMERS");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CUSTOMERS");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DepartureTime",
                table: "FLIGHTS",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ArrivalTime",
                table: "FLIGHTS",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "LoginID",
                table: "CUSTOMERS",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
