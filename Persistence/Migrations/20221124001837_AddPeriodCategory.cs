using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class AddPeriodCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Receipts",
                table: "Receipts");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Receipts",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "PaymentDate",
                table: "Receipts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Receipts",
                table: "Receipts",
                columns: new[] { "PeriodId", "CategoryId", "ApartmentId" });

            migrationBuilder.CreateTable(
                name: "PeriodCategory",
                columns: table => new
                {
                    PeriodId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CategoryId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Amount = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeriodCategory", x => new { x.PeriodId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_PeriodCategory_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PeriodCategory_Periods_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Periods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PeriodCategory_CategoryId",
                table: "PeriodCategory",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_PeriodCategory_PeriodId_CategoryId",
                table: "Receipts",
                columns: new[] { "PeriodId", "CategoryId" },
                principalTable: "PeriodCategory",
                principalColumns: new[] { "PeriodId", "CategoryId" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_PeriodCategory_PeriodId_CategoryId",
                table: "Receipts");

            migrationBuilder.DropTable(
                name: "PeriodCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Receipts",
                table: "Receipts");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Receipts");

            migrationBuilder.DropColumn(
                name: "PaymentDate",
                table: "Receipts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Receipts",
                table: "Receipts",
                columns: new[] { "PeriodId", "ApartmentId" });
        }
    }
}
