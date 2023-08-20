using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Employee_s_System_ERP_Task_API.Migrations
{
    /// <inheritdoc />
    public partial class AddSomeDataToAccount_LineOfBusinessTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "account_LineOfBusinesses",
                columns: new[] { "AccountId", "LineOfBusinessId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "account_LineOfBusinesses",
                keyColumns: new[] { "AccountId", "LineOfBusinessId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "account_LineOfBusinesses",
                keyColumns: new[] { "AccountId", "LineOfBusinessId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "account_LineOfBusinesses",
                keyColumns: new[] { "AccountId", "LineOfBusinessId" },
                keyValues: new object[] { 2, 3 });
        }
    }
}
