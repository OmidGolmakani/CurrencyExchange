using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CurrencyExchange.Migrations
{
    public partial class AddBuy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "BuyId",
                table: "Order",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Buy",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<long>(type: "bigint", nullable: true),
                    BuyDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    BuyNum = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    InstantPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    CurrencyPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AdminAcceptId = table.Column<long>(type: "bigint", nullable: true),
                    AdminAcceptDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    AdminAcceptTime = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Buy_AspNetUsers_AdminAcceptId",
                        column: x => x.AdminAcceptId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Buy_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Buy_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_BuyId",
                table: "Order",
                column: "BuyId");

            migrationBuilder.CreateIndex(
                name: "IX_Buy_AdminAcceptId",
                table: "Buy",
                column: "AdminAcceptId");

            migrationBuilder.CreateIndex(
                name: "IX_Buy_CurrencyId",
                table: "Buy",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Buy_UserId",
                table: "Buy",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Buy_BuyId",
                table: "Order",
                column: "BuyId",
                principalTable: "Buy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Buy_BuyId",
                table: "Order");

            migrationBuilder.DropTable(
                name: "Buy");

            migrationBuilder.DropIndex(
                name: "IX_Order_BuyId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "BuyId",
                table: "Order");
        }
    }
}
