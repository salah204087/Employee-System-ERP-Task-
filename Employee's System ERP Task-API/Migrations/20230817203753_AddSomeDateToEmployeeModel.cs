using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employee_s_System_ERP_Task_API.Migrations
{
    /// <inheritdoc />
    public partial class AddSomeDateToEmployeeModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "AccountId", "Age", "BirthDate", "LanguageId", "LanguageLevelId", "Name", "NationalId" },
                values: new object[] { 1, 1, 0, new DateTime(2000, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 0, "salah", 300054896214789L });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
