using Microsoft.EntityFrameworkCore.Migrations;

namespace CurrencyExchange.Migrations
{
    public partial class RemoveInstantPriceFromTrades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InstantPrice",
                table: "Trades");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "InstantPrice",
                table: "Trades",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
