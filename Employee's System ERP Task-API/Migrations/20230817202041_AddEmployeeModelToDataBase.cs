using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employee_s_System_ERP_Task_API.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployeeModelToDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "LanguageLevels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalId = table.Column<long>(type: "bigint", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    LanguageLevelId = table.Column<int>(type: "int", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "LanguageLevels",
                keyColumn: "Id",
                keyValue: 1,
                column: "EmployeeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "LanguageLevels",
                keyColumn: "Id",
                keyValue: 2,
                column: "EmployeeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "LanguageLevels",
                keyColumn: "Id",
                keyValue: 3,
                column: "EmployeeId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_LanguageLevels_EmployeeId",
                table: "LanguageLevels",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_AccountId",
                table: "Employees",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_LanguageId",
                table: "Employees",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_LanguageLevels_Employees_EmployeeId",
                table: "LanguageLevels",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LanguageLevels_Employees_EmployeeId",
                table: "LanguageLevels");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_LanguageLevels_EmployeeId",
                table: "LanguageLevels");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "LanguageLevels");
        }
    }
}
