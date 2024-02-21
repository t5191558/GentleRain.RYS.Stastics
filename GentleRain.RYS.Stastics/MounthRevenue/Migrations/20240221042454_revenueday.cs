using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MonthRevenue.Migrations
{
    /// <inheritdoc />
    public partial class Revenueday : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RevenueDay",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmployeeId = table.Column<int>(type: "INTEGER", nullable: false),
                    RevenueDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EmployeeName = table.Column<string>(type: "TEXT", nullable: false),
                    ProjectId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProjectName = table.Column<int>(type: "INTEGER", nullable: false),
                    Count = table.Column<decimal>(type: "TEXT", nullable: false),
                    UnitCardinal = table.Column<decimal>(type: "TEXT", nullable: false),
                    UnitPerformance = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RevenueDay", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RevenueDay");
        }
    }
}
