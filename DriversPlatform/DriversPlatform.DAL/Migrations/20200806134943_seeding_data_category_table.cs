using Microsoft.EntityFrameworkCore.Migrations;

namespace DriversPlatform.DAL.Migrations
{
    public partial class seeding_data_category_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Varsta minima: 16 ani", "AM" },
                    { 16, "Varsta minima: 18 ani", "Tr" },
                    { 15, "Varsta minima: 24 ani", "DE" },
                    { 14, "Varsta minima: 24 ani", "D" },
                    { 13, "Varsta minima: 21 ani", "D1E" },
                    { 12, "Varsta minima: 21 ani", "D1" },
                    { 11, "Varsta minima: 21 ani", "CE" },
                    { 10, "Varsta minima: 21 ani", "C" },
                    { 9, "Varsta minima: 18 ani", "C1E" },
                    { 8, "Varsta minima: 18 ani", "C1" },
                    { 7, "Varsta minima: 18 ani", "BE" },
                    { 6, "Varsta minima: 18 ani", "B" },
                    { 5, "Varsta minima: 16 ani", "B1" },
                    { 4, "Varsta minima: 24 ani", "A" },
                    { 3, "Varsta minima: 18 ani", "A2" },
                    { 2, "Varsta minima: 16 ani", "A1" },
                    { 17, "Varsta minima: 24 ani", "Tb" },
                    { 18, "Varsta minima: 24 ani", "Tv" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 18);
        }
    }
}
