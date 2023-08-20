using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employee_s_System_ERP_Task_API.Migrations
{
    /// <inheritdoc />
    public partial class MakeTheRelationManyToManyBetweenAccountsAndLineOfBusiness : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "account_LineOfBusinesses",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    LineOfBusinessId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_account_LineOfBusinesses", x => new { x.AccountId, x.LineOfBusinessId });
                    table.ForeignKey(
                        name: "FK_account_LineOfBusinesses_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_account_LineOfBusinesses_LineOfBusinesses_LineOfBusinessId",
                        column: x => x.LineOfBusinessId,
                        principalTable: "LineOfBusinesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_account_LineOfBusinesses_LineOfBusinessId",
                table: "account_LineOfBusinesses",
                column: "LineOfBusinessId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "account_LineOfBusinesses");
        }
    }
}
