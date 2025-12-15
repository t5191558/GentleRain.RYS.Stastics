using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MonthRevenue.Migrations
{
    /// <inheritdoc />
    public partial class BonusMainBasicPay : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "BasicPay",
                table: "BonusMain",
                type: "TEXT",
                nullable: true,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BasicPay",
                table: "BonusMain");
        }
    }
}
