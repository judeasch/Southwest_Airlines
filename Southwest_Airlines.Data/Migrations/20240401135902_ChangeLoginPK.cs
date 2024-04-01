using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Southwest_Airlines.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeLoginPK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CUSTOMERS_LOGINS_LoginID",
                table: "CUSTOMERS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LOGINS",
                table: "LOGINS");

            migrationBuilder.DropColumn(
                name: "LoginID",
                table: "LOGINS");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "LOGINS");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "LOGINS");

            migrationBuilder.AddColumn<string>(
                name: "LoginId",
                table: "LOGINS",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "LoginID",
                table: "CUSTOMERS",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LOGINS",
                table: "LOGINS",
                column: "LoginId");

            migrationBuilder.AddForeignKey(
                name: "FK_CUSTOMERS_LOGINS_LoginID",
                table: "CUSTOMERS",
                column: "LoginID",
                principalTable: "LOGINS",
                principalColumn: "LoginId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LOGINS_AspNetUsers_Id",
                table: "LOGINS",
                column: "LoginId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CUSTOMERS_LOGINS_LoginID",
                table: "CUSTOMERS");

            migrationBuilder.DropForeignKey(
                name: "FK_LOGINS_AspNetUsers_Id",
                table: "LOGINS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LOGINS",
                table: "LOGINS");

            migrationBuilder.DropColumn(
                name: "LoginId",
                table: "LOGINS");

            migrationBuilder.AddColumn<int>(
                name: "LoginID",
                table: "LOGINS",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "LOGINS",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "LOGINS",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LoginID",
                table: "CUSTOMERS",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LOGINS",
                table: "LOGINS",
                column: "LoginID");

            migrationBuilder.AddForeignKey(
                name: "FK_CUSTOMERS_LOGINS_LoginID",
                table: "CUSTOMERS",
                column: "LoginID",
                principalTable: "LOGINS",
                principalColumn: "LoginID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
