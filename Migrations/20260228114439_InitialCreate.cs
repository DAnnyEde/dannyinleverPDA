using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorProject.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    customerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    firstName = table.Column<string>(type: "char(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    lastName = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(100)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    phoneNumber = table.Column<string>(type: "varchar(20)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.customerID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    locationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    city = table.Column<string>(type: "varchar(100)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    province = table.Column<string>(type: "varchar(100)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    country = table.Column<string>(type: "varchar(100)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.locationID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    propertyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(50)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.propertyID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Accommodations",
                columns: table => new
                {
                    accommodationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    locationID = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    price = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    imageURL = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accommodations", x => x.accommodationID);
                    table.ForeignKey(
                        name: "FK_Accommodations_Location_locationID",
                        column: x => x.locationID,
                        principalTable: "Location",
                        principalColumn: "locationID",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CustomerWishes",
                columns: table => new
                {
                    customerID = table.Column<int>(type: "int", nullable: false),
                    wishID = table.Column<int>(type: "int", nullable: false),
                    propertyID = table.Column<int>(type: "int", nullable: false),
                    value = table.Column<string>(type: "varchar(50)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerWishes", x => new { x.customerID, x.wishID });
                    table.ForeignKey(
                        name: "FK_CustomerWishes_Customers_customerID",
                        column: x => x.customerID,
                        principalTable: "Customers",
                        principalColumn: "customerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerWishes_Properties_propertyID",
                        column: x => x.propertyID,
                        principalTable: "Properties",
                        principalColumn: "propertyID",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AccommodationProperties",
                columns: table => new
                {
                    accommodationID = table.Column<int>(type: "int", nullable: false),
                    propertyID = table.Column<int>(type: "int", nullable: false),
                    value = table.Column<string>(type: "varchar(50)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccommodationProperties", x => new { x.accommodationID, x.propertyID });
                    table.ForeignKey(
                        name: "FK_AccommodationProperties_Accommodations_accommodationID",
                        column: x => x.accommodationID,
                        principalTable: "Accommodations",
                        principalColumn: "accommodationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccommodationProperties_Properties_propertyID",
                        column: x => x.propertyID,
                        principalTable: "Properties",
                        principalColumn: "propertyID",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    bookingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    customerID = table.Column<int>(type: "int", nullable: false),
                    accommodationID = table.Column<int>(type: "int", nullable: false),
                    bookingDate = table.Column<DateTime>(type: "date", nullable: true),
                    arrivalDate = table.Column<DateTime>(type: "date", nullable: true),
                    departureDate = table.Column<DateTime>(type: "date", nullable: true),
                    numberOfGuests = table.Column<int>(type: "int", nullable: true),
                    totalPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.bookingID);
                    table.ForeignKey(
                        name: "FK_Bookings_Accommodations_accommodationID",
                        column: x => x.accommodationID,
                        principalTable: "Accommodations",
                        principalColumn: "accommodationID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bookings_Customers_customerID",
                        column: x => x.customerID,
                        principalTable: "Customers",
                        principalColumn: "customerID",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AccommodationProperties_propertyID",
                table: "AccommodationProperties",
                column: "propertyID");

            migrationBuilder.CreateIndex(
                name: "IX_Accommodations_locationID",
                table: "Accommodations",
                column: "locationID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_accommodationID",
                table: "Bookings",
                column: "accommodationID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_customerID",
                table: "Bookings",
                column: "customerID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerWishes_propertyID",
                table: "CustomerWishes",
                column: "propertyID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerWishes_wishID",
                table: "CustomerWishes",
                column: "wishID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccommodationProperties");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "CustomerWishes");

            migrationBuilder.DropTable(
                name: "Accommodations");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "Location");
        }
    }
}
