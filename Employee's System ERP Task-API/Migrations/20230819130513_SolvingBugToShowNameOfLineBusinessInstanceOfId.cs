using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employee_s_System_ERP_Task_API.Migrations
{
    /// <inheritdoc />
    public partial class SolvingBugToShowNameOfLineBusinessInstanceOfId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LineOfBusinessName",
                table: "account_LineOfBusinesses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "account_LineOfBusinesses",
                keyColumns: new[] { "AccountId", "LineOfBusinessId" },
                keyValues: new object[] { 1, 1 },
                column: "LineOfBusinessName",
                value: null);

            migrationBuilder.UpdateData(
                table: "account_LineOfBusinesses",
                keyColumns: new[] { "AccountId", "LineOfBusinessId" },
                keyValues: new object[] { 1, 2 },
                column: "LineOfBusinessName",
                value: null);

            migrationBuilder.UpdateData(
                table: "account_LineOfBusinesses",
                keyColumns: new[] { "AccountId", "LineOfBusinessId" },
                keyValues: new object[] { 2, 3 },
                column: "LineOfBusinessName",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LineOfBusinessName",
                table: "account_LineOfBusinesses");
        }
    }
}
