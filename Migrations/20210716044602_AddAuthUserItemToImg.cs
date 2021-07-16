using Microsoft.EntityFrameworkCore.Migrations;

namespace CurrencyExchange.Migrations
{
    public partial class AddAuthUserItemToImg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AuthUserItemId",
                table: "Images",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_AuthUserItemId",
                table: "Images",
                column: "AuthUserItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_AuthUserItems_AuthUserItemId",
                table: "Images",
                column: "AuthUserItemId",
                principalTable: "AuthUserItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_AuthUserItems_AuthUserItemId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_AuthUserItemId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "AuthUserItemId",
                table: "Images");
        }
    }
}
