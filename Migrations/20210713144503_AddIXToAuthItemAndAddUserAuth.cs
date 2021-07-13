using Microsoft.EntityFrameworkCore.Migrations;

namespace CurrencyExchange.Migrations
{
    public partial class AddIXToAuthItemAndAddUserAuth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AuthUserItems_UserId",
                table: "AuthUserItems");

            migrationBuilder.CreateIndex(
                name: "IX_AuthUserItems_UserId_AuthItemId_Deleted",
                table: "AuthUserItems",
                columns: new[] { "UserId", "AuthItemId", "Deleted" });

            migrationBuilder.CreateIndex(
                name: "IX_AuthItems_Order",
                table: "AuthItems",
                column: "Order");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AuthUserItems_UserId_AuthItemId_Deleted",
                table: "AuthUserItems");

            migrationBuilder.DropIndex(
                name: "IX_AuthItems_Order",
                table: "AuthItems");

            migrationBuilder.CreateIndex(
                name: "IX_AuthUserItems_UserId",
                table: "AuthUserItems",
                column: "UserId");
        }
    }
}
