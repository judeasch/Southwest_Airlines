using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Southwest_Airlines.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddFastpass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_CUSTOMERS_AspNetUsers_LoginID",
            //    table: "CUSTOMERS");

            //migrationBuilder.DropIndex(
            //    name: "IX_CUSTOMERS_LoginID",
            //    table: "CUSTOMERS");

            //migrationBuilder.DropColumn(
            //    name: "IsAdmin",
            //    table: "AspNetUsers");

            //migrationBuilder.AlterColumn<string>(
            //    name: "LoginID",
            //    table: "CUSTOMERS",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(450)");

            migrationBuilder.CreateTable(
                name: "FASTPASSES",
                columns: table => new
                {
                    FastpassID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketID = table.Column<int>(type: "int", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime", nullable: false),
                    ValidUntil = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FASTPASSES", x => x.FastpassID);
                    table.ForeignKey(
                        name: "FK_FASTPASSES_TICKETS_TicketID",
                        column: x => x.TicketID,
                        principalTable: "TICKETS",
                        principalColumn: "TicketID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PAYMENTINFO",
                columns: table => new
                {
                    PaymentInfoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    CardholderName = table.Column<string>(type: "nvarchar(240)", maxLength: 240, nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CardNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ExpiryDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAYMENTINFO", x => x.PaymentInfoID);
                    table.ForeignKey(
                        name: "FK_PAYMENTINFO_CUSTOMERS_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "CUSTOMERS",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FASTPASSES_TicketID",
                table: "FASTPASSES",
                column: "TicketID");

            migrationBuilder.CreateIndex(
                name: "IX_PAYMENTINFO_CustomerID",
                table: "PAYMENTINFO",
                column: "CustomerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FASTPASSES");

            migrationBuilder.DropTable(
                name: "PAYMENTINFO");

            //migrationBuilder.AlterColumn<string>(
            //    name: "LoginID",
            //    table: "CUSTOMERS",
            //    type: "nvarchar(450)",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)");

            //migrationBuilder.AddColumn<bool>(
            //    name: "IsAdmin",
            //    table: "AspNetUsers",
            //    type: "bit",
            //    nullable: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_CUSTOMERS_LoginID",
            //    table: "CUSTOMERS",
            //    column: "LoginID");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_CUSTOMERS_AspNetUsers_LoginID",
            //    table: "CUSTOMERS",
            //    column: "LoginID",
            //    principalTable: "AspNetUsers",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }
    }
}
