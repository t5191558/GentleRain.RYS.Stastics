using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MonthRevenue.Migrations
{
    /// <inheritdoc />
    public partial class BonusMain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BonusMain",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Desc = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BonusMain", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "BonusMain",
                columns: new[] { "Id", "Desc", "IsActive", "Name" },
                values: new object[] { 1, "迁移自动创建的默认方案", true, "默认方案" });

            migrationBuilder.AddColumn<int>(
                name: "BonusMainId",
                table: "BonusRule",
                type: "INTEGER",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_BonusRule_BonusMainId",
                table: "BonusRule",
                column: "BonusMainId");

            migrationBuilder.AddForeignKey(
                name: "FK_BonusRule_BonusMain_BonusMainId",
                table: "BonusRule",
                column: "BonusMainId",
                principalTable: "BonusMain",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BonusRule_BonusMain_BonusMainId",
                table: "BonusRule");

            migrationBuilder.DropIndex(
                name: "IX_BonusRule_BonusMainId",
                table: "BonusRule");

            migrationBuilder.DropColumn(
                name: "BonusMainId",
                table: "BonusRule");

            migrationBuilder.DropTable(
                name: "BonusMain");
        }
    }
}
