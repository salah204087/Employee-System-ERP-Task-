using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Employee_s_System_ERP_Task_API.Migrations
{
    /// <inheritdoc />
    public partial class AddSomeDataToLangauageLevelTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "LanguageLevels",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "B1" },
                    { 2, "B2" },
                    { 3, "C1" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LanguageLevels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LanguageLevels",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "LanguageLevels",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
