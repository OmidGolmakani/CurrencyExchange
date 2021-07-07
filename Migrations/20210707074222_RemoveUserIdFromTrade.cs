using Microsoft.EntityFrameworkCore.Migrations;

namespace CurrencyExchange.Migrations
{
    public partial class RemoveUserIdFromTrade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trades_AspNetUsers_UserId",
                table: "Trades");

            migrationBuilder.DropForeignKey(
                name: "FK_Trades_Currency_CurrencyId",
                table: "Trades");

            migrationBuilder.DropIndex(
                name: "IX_Trades_UserId",
                table: "Trades");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Trades");

            migrationBuilder.CreateIndex(
                name: "IX_Trades_OrderId",
                table: "Trades",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trades_Currency_CurrencyId",
                table: "Trades",
                column: "CurrencyId",
                principalTable: "Currency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trades_Order_OrderId",
                table: "Trades",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trades_Currency_CurrencyId",
                table: "Trades");

            migrationBuilder.DropForeignKey(
                name: "FK_Trades_Order_OrderId",
                table: "Trades");

            migrationBuilder.DropIndex(
                name: "IX_Trades_OrderId",
                table: "Trades");

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "Trades",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trades_UserId",
                table: "Trades",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trades_AspNetUsers_UserId",
                table: "Trades",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Trades_Currency_CurrencyId",
                table: "Trades",
                column: "CurrencyId",
                principalTable: "Currency",
                principalColumn: "Id");
        }
    }
}
