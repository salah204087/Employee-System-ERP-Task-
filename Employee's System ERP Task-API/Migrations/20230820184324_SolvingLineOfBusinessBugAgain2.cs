using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employee_s_System_ERP_Task_API.Migrations
{
    /// <inheritdoc />
    public partial class SolvingLineOfBusinessBugAgain2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LineOfBusiness",
                table: "EmployeeLangLevels");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LineOfBusiness",
                table: "EmployeeLangLevels",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "EmployeeLangLevels",
                keyColumns: new[] { "EmployeeId", "LanguageLevelId" },
                keyValues: new object[] { 1, 2 },
                column: "LineOfBusiness",
                value: null);
        }
    }
}
