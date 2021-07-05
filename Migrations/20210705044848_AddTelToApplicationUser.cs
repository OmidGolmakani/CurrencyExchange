using Microsoft.EntityFrameworkCore.Migrations;

namespace CurrencyExchange.Migrations
{
    public partial class AddTelToApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tel",
                table: "AspNetUsers",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TelConfirmed",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tel",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TelConfirmed",
                table: "AspNetUsers");
        }
    }
}
