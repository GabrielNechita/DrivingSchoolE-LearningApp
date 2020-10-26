using Microsoft.EntityFrameworkCore.Migrations;

namespace DriversPlatform.DAL.Migrations
{
    public partial class instructorCategoryLink_many_to_many : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InstructorCategoryLink",
                columns: table => new
                {
                    InstructorId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorCategoryLink", x => new { x.InstructorId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_InstructorCategoryLink_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstructorCategoryLink_Instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InstructorCategoryLink_CategoryId",
                table: "InstructorCategoryLink",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InstructorCategoryLink");
        }
    }
}
