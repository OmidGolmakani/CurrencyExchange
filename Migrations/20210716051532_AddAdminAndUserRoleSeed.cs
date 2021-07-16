using Microsoft.EntityFrameworkCore.Migrations;

namespace CurrencyExchange.Migrations
{
    public partial class AddAdminAndUserRoleSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_AuthUserItems_AuthUserItemId",
                table: "Images");

            migrationBuilder.RenameColumn(
                name: "AuthUserItemId",
                table: "Images",
                newName: "AuthItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Images_AuthUserItemId",
                table: "Images",
                newName: "IX_Images_AuthItemId");

            migrationBuilder.AddColumn<long>(
                name: "AuthItemId",
                table: "BankAccount",
                type: "bigint",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 1L, "420d99de-7b2d-4a31-acd9-da52b0927bd0", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 2L, "47a274bd-9ea4-4475-a931-00ea4a3e86f7", "User", "USER" });

            migrationBuilder.CreateIndex(
                name: "IX_BankAccount_AuthItemId",
                table: "BankAccount",
                column: "AuthItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccount_AuthUserItems_AuthItemId",
                table: "BankAccount",
                column: "AuthItemId",
                principalTable: "AuthUserItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_AuthUserItems_AuthItemId",
                table: "Images",
                column: "AuthItemId",
                principalTable: "AuthUserItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankAccount_AuthUserItems_AuthItemId",
                table: "BankAccount");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_AuthUserItems_AuthItemId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_BankAccount_AuthItemId",
                table: "BankAccount");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DropColumn(
                name: "AuthItemId",
                table: "BankAccount");

            migrationBuilder.RenameColumn(
                name: "AuthItemId",
                table: "Images",
                newName: "AuthUserItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Images_AuthItemId",
                table: "Images",
                newName: "IX_Images_AuthUserItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_AuthUserItems_AuthUserItemId",
                table: "Images",
                column: "AuthUserItemId",
                principalTable: "AuthUserItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
