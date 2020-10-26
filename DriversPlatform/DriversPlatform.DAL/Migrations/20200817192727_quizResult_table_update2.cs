using Microsoft.EntityFrameworkCore.Migrations;

namespace DriversPlatform.DAL.Migrations
{
    public partial class quizResult_table_update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Difficulty",
                table: "QuizResults",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Difficulty",
                table: "QuizResults");
        }
    }
}
