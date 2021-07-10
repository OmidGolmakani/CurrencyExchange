using Microsoft.EntityFrameworkCore.Migrations;

namespace CurrencyExchange.Migrations
{
    public partial class AddSale_Purchase_Price : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SalePrice",
                table: "CurrencyChange",
                newName: "SalesPrice");

            migrationBuilder.RenameColumn(
                name: "BuyPrice",
                table: "CurrencyChange",
                newName: "PurchasePrice");

            migrationBuilder.AddColumn<decimal>(
                name: "PurchasePrice",
                table: "Currency",
                type: "decimal(18,4)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SalesPrice",
                table: "Currency",
                type: "decimal(18,4)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PurchasePrice",
                table: "Currency");

            migrationBuilder.DropColumn(
                name: "SalesPrice",
                table: "Currency");

            migrationBuilder.RenameColumn(
                name: "SalesPrice",
                table: "CurrencyChange",
                newName: "SalePrice");

            migrationBuilder.RenameColumn(
                name: "PurchasePrice",
                table: "CurrencyChange",
                newName: "BuyPrice");
        }
    }
}
