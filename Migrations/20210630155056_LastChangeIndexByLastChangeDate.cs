using Microsoft.EntityFrameworkCore.Migrations;

namespace CurrencyExchange.Migrations
{
    public partial class LastChangeIndexByLastChangeDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CurrencyChange_LastChangeDate_LastChangeTime",
                table: "CurrencyChange");

            migrationBuilder.DropColumn(
                name: "LastChangeTime",
                table: "CurrencyChange");

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyChange_LastChangeDate",
                table: "CurrencyChange",
                column: "LastChangeDate",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CurrencyChange_LastChangeDate",
                table: "CurrencyChange");

            migrationBuilder.AddColumn<int>(
                name: "LastChangeTime",
                table: "CurrencyChange",
                type: "int",
                maxLength: 8,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyChange_LastChangeDate_LastChangeTime",
                table: "CurrencyChange",
                columns: new[] { "LastChangeDate", "LastChangeTime" },
                unique: true);
        }
    }
}
