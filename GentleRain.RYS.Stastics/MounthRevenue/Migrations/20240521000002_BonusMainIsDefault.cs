using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MonthRevenue.Migrations
{
    /// <inheritdoc />
    public partial class BonusMainIsDefault : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "BonusMain",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddCheckConstraint(
                name: "CK_BonusMain_IsDefaultRequiresActive",
                table: "BonusMain",
                sql: "IsActive = 1 OR IsDefault = 0");

            migrationBuilder.CreateIndex(
                name: "IX_BonusMain_IsDefault",
                table: "BonusMain",
                column: "IsDefault",
                unique: true,
                filter: "IsDefault = 1");

            migrationBuilder.Sql(@"
WITH first_active AS (
    SELECT Id FROM BonusMain WHERE IsActive = 1 ORDER BY Id LIMIT 1
)
UPDATE BonusMain
SET IsDefault = CASE WHEN Id = (SELECT Id FROM first_active) THEN 1 ELSE 0 END;
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BonusMain_IsDefault",
                table: "BonusMain");

            migrationBuilder.DropCheckConstraint(
                name: "CK_BonusMain_IsDefaultRequiresActive",
                table: "BonusMain");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "BonusMain");
        }
    }
}
