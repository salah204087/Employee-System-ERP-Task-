using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employee_s_System_ERP_Task_API.Migrations
{
    /// <inheritdoc />
    public partial class MakeManyToManyRelationShipBetweenEmployeeAndLangLevel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LanguageLevels_Employees_EmployeeId",
                table: "LanguageLevels");

            migrationBuilder.DropIndex(
                name: "IX_LanguageLevels_EmployeeId",
                table: "LanguageLevels");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "LanguageLevels");

            migrationBuilder.DropColumn(
                name: "LanguageLevelId",
                table: "Employees");

            migrationBuilder.CreateTable(
                name: "EmployeeLangLevels",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    LanguageLevelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeLangLevels", x => new { x.EmployeeId, x.LanguageLevelId });
                    table.ForeignKey(
                        name: "FK_EmployeeLangLevels_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeLangLevels_LanguageLevels_LanguageLevelId",
                        column: x => x.LanguageLevelId,
                        principalTable: "LanguageLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeLangLevels_LanguageLevelId",
                table: "EmployeeLangLevels",
                column: "LanguageLevelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeLangLevels");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "LanguageLevels",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageLevelId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "LanguageLevelId",
                value: 0);

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

            migrationBuilder.AddForeignKey(
                name: "FK_LanguageLevels_Employees_EmployeeId",
                table: "LanguageLevels",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }
    }
}
