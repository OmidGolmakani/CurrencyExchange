using Microsoft.EntityFrameworkCore.Migrations;

namespace CurrencyExchange.Migrations
{
    public partial class AddAdminDescToAdminEntites : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdminDescription",
                table: "Trades",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdminDescription",
                table: "Order",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdminDescription",
                table: "Images",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdminDescription",
                table: "BankAccount",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdminDescription",
                table: "Trades");

            migrationBuilder.DropColumn(
                name: "AdminDescription",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "AdminDescription",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "AdminDescription",
                table: "BankAccount");
        }
    }
}
