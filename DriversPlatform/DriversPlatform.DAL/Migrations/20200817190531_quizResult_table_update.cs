using Microsoft.EntityFrameworkCore.Migrations;

namespace DriversPlatform.DAL.Migrations
{
    public partial class quizResult_table_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "QuizResults",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_QuizResults_CategoryId",
                table: "QuizResults",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuizResults_Categories_CategoryId",
                table: "QuizResults",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuizResults_Categories_CategoryId",
                table: "QuizResults");

            migrationBuilder.DropIndex(
                name: "IX_QuizResults_CategoryId",
                table: "QuizResults");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "QuizResults");
        }
    }
}
