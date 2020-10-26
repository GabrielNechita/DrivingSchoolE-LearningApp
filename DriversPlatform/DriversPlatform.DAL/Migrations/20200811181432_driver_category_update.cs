using Microsoft.EntityFrameworkCore.Migrations;

namespace DriversPlatform.DAL.Migrations
{
    public partial class driver_category_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DriverCategoryLink");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Drivers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_CategoryId",
                table: "Drivers",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Drivers_Categories_CategoryId",
                table: "Drivers",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drivers_Categories_CategoryId",
                table: "Drivers");

            migrationBuilder.DropIndex(
                name: "IX_Drivers_CategoryId",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Drivers");

            migrationBuilder.CreateTable(
                name: "DriverCategoryLink",
                columns: table => new
                {
                    DriverId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverCategoryLink", x => new { x.DriverId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_DriverCategoryLink_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DriverCategoryLink_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DriverCategoryLink_CategoryId",
                table: "DriverCategoryLink",
                column: "CategoryId");
        }
    }
}
