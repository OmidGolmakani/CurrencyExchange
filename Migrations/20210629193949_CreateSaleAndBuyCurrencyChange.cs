using Microsoft.EntityFrameworkCore.Migrations;

namespace CurrencyExchange.Migrations
{
    public partial class CreateSaleAndBuyCurrencyChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrencyChangeId",
                table: "CurrencyChange");

            migrationBuilder.RenameColumn(
                name: "CurrencyPrice",
                table: "CurrencyChange",
                newName: "SalePrice");

            migrationBuilder.AddColumn<decimal>(
                name: "BuyPrice",
                table: "CurrencyChange",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuyPrice",
                table: "CurrencyChange");

            migrationBuilder.RenameColumn(
                name: "SalePrice",
                table: "CurrencyChange",
                newName: "CurrencyPrice");

            migrationBuilder.AddColumn<byte>(
                name: "CurrencyChangeId",
                table: "CurrencyChange",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }
    }
}
