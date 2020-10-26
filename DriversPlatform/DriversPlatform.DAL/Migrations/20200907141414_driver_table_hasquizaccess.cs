using Microsoft.EntityFrameworkCore.Migrations;

namespace DriversPlatform.DAL.Migrations
{
    public partial class driver_table_hasquizaccess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasQuizAccess",
                table: "Drivers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasQuizAccess",
                table: "Drivers");
        }
    }
}
