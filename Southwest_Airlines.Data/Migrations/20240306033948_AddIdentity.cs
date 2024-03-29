﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Southwest_Airlines.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            //migrationBuilder.CreateTable(
            //    name: "FLIGHTS",
            //    columns: table => new
            //    {
            //        FlightID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Origin = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        Destination = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        DepartureTime = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        ArrivalTime = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        NumberOfSeats = table.Column<int>(type: "int", nullable: true),
            //        IsAvailable = table.Column<bool>(type: "bit", nullable: true),
            //        Price = table.Column<decimal>(type: "money", nullable: true),
            //        NumberOfFirstClassSeats = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_FLIGHTS", x => x.FlightID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "LOGINS",
            //    columns: table => new
            //    {
            //        LoginID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        IsAdmin = table.Column<bool>(type: "bit", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_LOGINS", x => x.LoginID);
            //    });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            //migrationBuilder.CreateTable(
            //    name: "SEATS",
            //    columns: table => new
            //    {
            //        SeatID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        SeatNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        IsAvailable = table.Column<bool>(type: "bit", nullable: true),
            //        Price = table.Column<decimal>(type: "money", nullable: true),
            //        FlightID = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_SEATS", x => x.SeatID);
            //        table.ForeignKey(
            //            name: "FK_SEATS_FLIGHTS_FlightID",
            //            column: x => x.FlightID,
            //            principalTable: "FLIGHTS",
            //            principalColumn: "FlightID");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "CUSTOMERS",
            //    columns: table => new
            //    {
            //        CustomerID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        PhoneNumber = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
            //        DateOfBirth = table.Column<DateOnly>(type: "date", nullable: true),
            //        Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        State = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        PostalCode = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
            //        Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        LoginID = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_CUSTOMERS", x => x.CustomerID);
            //        table.ForeignKey(
            //            name: "FK_CUSTOMERS_LOGINS_LoginID",
            //            column: x => x.LoginID,
            //            principalTable: "LOGINS",
            //            principalColumn: "LoginID",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "TICKETS",
            //    columns: table => new
            //    {
            //        TicketID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CustomerID = table.Column<int>(type: "int", nullable: true),
            //        FlightID = table.Column<int>(type: "int", nullable: true),
            //        SeatID = table.Column<int>(type: "int", nullable: true),
            //        BookingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        PricePaid = table.Column<decimal>(type: "money", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_TICKETS", x => x.TicketID);
            //        table.ForeignKey(
            //            name: "FK_TICKETS_CUSTOMERS_CustomerID",
            //            column: x => x.CustomerID,
            //            principalTable: "CUSTOMERS",
            //            principalColumn: "CustomerID",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_TICKETS_FLIGHTS_FlightID",
            //            column: x => x.FlightID,
            //            principalTable: "FLIGHTS",
            //            principalColumn: "FlightID",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_TICKETS_SEATS_SeatID",
            //            column: x => x.SeatID,
            //            principalTable: "SEATS",
            //            principalColumn: "SeatID",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CUSTOMERS_LoginID",
                table: "CUSTOMERS",
                column: "LoginID");

            migrationBuilder.CreateIndex(
                name: "IX_SEATS_FlightID",
                table: "SEATS",
                column: "FlightID");

            migrationBuilder.CreateIndex(
                name: "IX_TICKETS_CustomerID",
                table: "TICKETS",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_TICKETS_FlightID",
                table: "TICKETS",
                column: "FlightID");

            migrationBuilder.CreateIndex(
                name: "IX_TICKETS_SeatID",
                table: "TICKETS",
                column: "SeatID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            //migrationBuilder.DropTable(
            //    name: "TICKETS");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            //migrationBuilder.DropTable(
            //    name: "CUSTOMERS");

            //migrationBuilder.DropTable(
            //    name: "SEATS");

            //migrationBuilder.DropTable(
            //    name: "LOGINS");

            //migrationBuilder.DropTable(
            //    name: "FLIGHTS");
        }
    }
}
