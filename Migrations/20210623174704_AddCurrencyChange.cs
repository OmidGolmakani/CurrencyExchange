using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CurrencyExchange.Migrations
{
    public partial class AddCurrencyChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CurrencyChange",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    CurrencyPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    LastChangeDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    LastChangeTime = table.Column<int>(type: "int", maxLength: 8, nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyChange", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurrencyChange_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyChange_CurrencyId",
                table: "CurrencyChange",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyChange_LastChangeDate_LastChangeTime",
                table: "CurrencyChange",
                columns: new[] { "LastChangeDate", "LastChangeTime" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurrencyChange");
        }
    }
}
