using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DayAndNight.Migrations
{
    public partial class orders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblorders",
                columns: table => new
                {
                    OrderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    AddressLine1 = table.Column<string>(nullable: true),
                    AddressLine2 = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    OrderTotal = table.Column<decimal>(nullable: false),
                    OrderPlaced = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblorders", x => x.OrderID);
                });

            migrationBuilder.CreateTable(
                name: "tblorderDetails",
                columns: table => new
                {
                    OrderDetailID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderID = table.Column<int>(nullable: false),
                    DrinkID = table.Column<int>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblorderDetails", x => x.OrderDetailID);
                    table.ForeignKey(
                        name: "FK_tblorderDetails_tblDrinks_DrinkID",
                        column: x => x.DrinkID,
                        principalTable: "tblDrinks",
                        principalColumn: "DrinkID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblorderDetails_tblorders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "tblorders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblorderDetails_DrinkID",
                table: "tblorderDetails",
                column: "DrinkID");

            migrationBuilder.CreateIndex(
                name: "IX_tblorderDetails_OrderID",
                table: "tblorderDetails",
                column: "OrderID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblorderDetails");

            migrationBuilder.DropTable(
                name: "tblorders");
        }
    }
}
