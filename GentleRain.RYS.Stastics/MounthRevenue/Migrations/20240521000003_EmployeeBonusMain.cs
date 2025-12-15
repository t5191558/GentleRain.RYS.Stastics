using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MonthRevenue.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeBonusMain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BonusMainId",
                table: "Employee",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_BonusMainId",
                table: "Employee",
                column: "BonusMainId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_BonusMain_BonusMainId",
                table: "Employee",
                column: "BonusMainId",
                principalTable: "BonusMain",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_BonusMain_BonusMainId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_BonusMainId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "BonusMainId",
                table: "Employee");
        }
    }
}
