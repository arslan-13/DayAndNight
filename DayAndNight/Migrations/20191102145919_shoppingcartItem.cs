using Microsoft.EntityFrameworkCore.Migrations;

namespace DayAndNight.Migrations
{
    public partial class shoppingcartItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblshoppingCartItems",
                columns: table => new
                {
                    ShoppingCartItemID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DrinkID = table.Column<int>(nullable: true),
                    Amount = table.Column<int>(nullable: false),
                    ShoppingCartID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblshoppingCartItems", x => x.ShoppingCartItemID);
                    table.ForeignKey(
                        name: "FK_tblshoppingCartItems_tblDrinks_DrinkID",
                        column: x => x.DrinkID,
                        principalTable: "tblDrinks",
                        principalColumn: "DrinkID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblshoppingCartItems_DrinkID",
                table: "tblshoppingCartItems",
                column: "DrinkID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblshoppingCartItems");
        }
    }
}
