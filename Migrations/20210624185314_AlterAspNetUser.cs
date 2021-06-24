using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CurrencyExchange.Migrations
{
    public partial class AlterAspNetUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Buy_BuyId",
                table: "Order");

            migrationBuilder.DropTable(
                name: "Buy");

            migrationBuilder.AlterColumn<string>(
                name: "SecurityStamp",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "AspNetUsers",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "AspNetUsers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Family",
                table: "AspNetUsers",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NationalCode",
                table: "AspNetUsers",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "NationalCodeConfirmed",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Trades",
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
                    table.PrimaryKey("PK_Trades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trades_AspNetUsers_AdminAcceptId",
                        column: x => x.AdminAcceptId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trades_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Trades_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trades_AdminAcceptId",
                table: "Trades",
                column: "AdminAcceptId");

            migrationBuilder.CreateIndex(
                name: "IX_Trades_CurrencyId",
                table: "Trades",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Trades_UserId",
                table: "Trades",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Trades_BuyId",
                table: "Order",
                column: "BuyId",
                principalTable: "Trades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Trades_BuyId",
                table: "Order");

            migrationBuilder.DropTable(
                name: "Trades");

            migrationBuilder.DropColumn(
                name: "Family",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NationalCode",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NationalCodeConfirmed",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "SecurityStamp",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Buy",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminAcceptDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    AdminAcceptId = table.Column<long>(type: "bigint", nullable: true),
                    AdminAcceptTime = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    BuyDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    BuyNum = table.Column<long>(type: "bigint", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    CurrencyPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    InstantPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    LastModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OrderId = table.Column<long>(type: "bigint", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
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
    }
}
