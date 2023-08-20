using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employee_s_System_ERP_Task_API.Migrations
{
    /// <inheritdoc />
    public partial class SolvingBugToShowNameOfLanguageLevelOfId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LanguageLevelName",
                table: "EmployeeLangLevels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "EmployeeLangLevels",
                keyColumns: new[] { "EmployeeId", "LanguageLevelId" },
                keyValues: new object[] { 1, 2 },
                column: "LanguageLevelName",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LanguageLevelName",
                table: "EmployeeLangLevels");
        }
    }
}
