using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ET_ENTITY.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExpCategories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpCategories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "DailyExpences",
                columns: table => new
                {
                    ExpenceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    categoriesCategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyExpences", x => x.ExpenceId);
                    table.ForeignKey(
                        name: "FK_DailyExpences_ExpCategories_categoriesCategoryId",
                        column: x => x.categoriesCategoryId,
                        principalTable: "ExpCategories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DailyExpences_categoriesCategoryId",
                table: "DailyExpences",
                column: "categoriesCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyExpences");

            migrationBuilder.DropTable(
                name: "ExpCategories");
        }
    }
}
