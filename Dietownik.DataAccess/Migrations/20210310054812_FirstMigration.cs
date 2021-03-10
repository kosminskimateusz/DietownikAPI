using Microsoft.EntityFrameworkCore.Migrations;

namespace Dietownik.DataAccess.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kcal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FatsPerHundredGrams = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CarbsPerHundredGrams = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProteinsPerHundredGrams = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
