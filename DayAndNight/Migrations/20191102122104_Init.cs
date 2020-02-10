using Microsoft.EntityFrameworkCore.Migrations;

namespace DayAndNight.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblcategories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: true),
                    CategoryDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblcategories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "tblDrinks",
                columns: table => new
                {
                    DrinkID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ShortDescription = table.Column<string>(nullable: true),
                    LongDescription = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    ImgUrl = table.Column<string>(nullable: true),
                    ImgThumbnailUrl = table.Column<string>(nullable: true),
                    IsPerferredDrink = table.Column<bool>(nullable: false),
                    Instock = table.Column<bool>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDrinks", x => x.DrinkID);
                    table.ForeignKey(
                        name: "FK_tblDrinks_tblcategories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "tblcategories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblDrinks_CategoryID",
                table: "tblDrinks",
                column: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblDrinks");

            migrationBuilder.DropTable(
                name: "tblcategories");
        }
    }
}
