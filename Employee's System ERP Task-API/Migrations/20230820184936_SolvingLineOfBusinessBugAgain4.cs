﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employee_s_System_ERP_Task_API.Migrations
{
    /// <inheritdoc />
    public partial class SolvingLineOfBusinessBugAgain4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BusinessLineName",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "BusinessLineId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "BusinessLineId",
                value: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_BusinessLineId",
                table: "Employees",
                column: "BusinessLineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_LineOfBusinesses_BusinessLineId",
                table: "Employees",
                column: "BusinessLineId",
                principalTable: "LineOfBusinesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_LineOfBusinesses_BusinessLineId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_BusinessLineId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "BusinessLineId",
                table: "Employees");

            migrationBuilder.AddColumn<string>(
                name: "BusinessLineName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "BusinessLineName",
                value: null);
        }
    }
}
