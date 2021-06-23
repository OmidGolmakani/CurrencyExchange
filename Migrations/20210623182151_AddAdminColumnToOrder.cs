using Microsoft.EntityFrameworkCore.Migrations;

namespace CurrencyExchange.Migrations
{
    public partial class AddAdminColumnToOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AdminAccept",
                table: "Order",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "AdminAcceptDate",
                table: "Order",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "AdminAcceptId",
                table: "Order",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdminAcceptTime",
                table: "Order",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_AdminAcceptId",
                table: "Order",
                column: "AdminAcceptId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_AspNetUsers_AdminAcceptId",
                table: "Order",
                column: "AdminAcceptId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_AspNetUsers_AdminAcceptId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_AdminAcceptId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "AdminAccept",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "AdminAcceptDate",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "AdminAcceptId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "AdminAcceptTime",
                table: "Order");
        }
    }
}
