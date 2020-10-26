using Microsoft.EntityFrameworkCore.Migrations;

namespace DriversPlatform.DAL.Migrations
{
    public partial class nullable_foreignkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drivers_Instructors_InstructorId",
                table: "Drivers");

            migrationBuilder.AlterColumn<int>(
                name: "InstructorId",
                table: "Drivers",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Drivers_Instructors_InstructorId",
                table: "Drivers",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drivers_Instructors_InstructorId",
                table: "Drivers");

            migrationBuilder.AlterColumn<int>(
                name: "InstructorId",
                table: "Drivers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Drivers_Instructors_InstructorId",
                table: "Drivers",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
