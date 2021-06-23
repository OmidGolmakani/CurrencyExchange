using Microsoft.EntityFrameworkCore.Migrations;

namespace CurrencyExchange.Migrations
{
    public partial class RenameCurrenciesToCurrency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Currencies_CurrencyId",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Currencies",
                table: "Currencies");

            migrationBuilder.RenameTable(
                name: "Currencies",
                newName: "Currency");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Currency",
                table: "Currency",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Currency_CurrencyId",
                table: "Order",
                column: "CurrencyId",
                principalTable: "Currency",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Currency_CurrencyId",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Currency",
                table: "Currency");

            migrationBuilder.RenameTable(
                name: "Currency",
                newName: "Currencies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Currencies",
                table: "Currencies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Currencies_CurrencyId",
                table: "Order",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id");
        }
    }
}
