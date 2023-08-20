using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employee_s_System_ERP_Task_API.Migrations
{
    /// <inheritdoc />
    public partial class AddDataTOEmployeeLangLevelTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "EmployeeLangLevels",
                columns: new[] { "EmployeeId", "LanguageLevelId" },
                values: new object[] { 1, 2 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EmployeeLangLevels",
                keyColumns: new[] { "EmployeeId", "LanguageLevelId" },
                keyValues: new object[] { 1, 2 });
        }
    }
}
