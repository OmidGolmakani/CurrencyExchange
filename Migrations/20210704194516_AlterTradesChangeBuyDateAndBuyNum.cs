using Microsoft.EntityFrameworkCore.Migrations;

namespace CurrencyExchange.Migrations
{
    public partial class AlterTradesChangeBuyDateAndBuyNum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BuyNum",
                table: "Trades",
                newName: "TradeNum");

            migrationBuilder.RenameColumn(
                name: "BuyDate",
                table: "Trades",
                newName: "TradeDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TradeNum",
                table: "Trades",
                newName: "BuyNum");

            migrationBuilder.RenameColumn(
                name: "TradeDate",
                table: "Trades",
                newName: "BuyDate");
        }
    }
}
