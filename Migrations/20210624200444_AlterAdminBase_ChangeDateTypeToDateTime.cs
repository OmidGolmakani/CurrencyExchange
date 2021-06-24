using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CurrencyExchange.Migrations
{
    public partial class AlterAdminBase_ChangeDateTypeToDateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_AspNetUsers_AdminAcceptId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Trades_AspNetUsers_AdminAcceptId",
                table: "Trades");

            migrationBuilder.DropColumn(
                name: "AdminAcceptDate",
                table: "Trades");

            migrationBuilder.DropColumn(
                name: "AdminAcceptTime",
                table: "Trades");

            migrationBuilder.DropColumn(
                name: "AdminAcceptDate",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "AdminAcceptTime",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "AdminAcceptId",
                table: "Trades",
                newName: "AdminId");

            migrationBuilder.RenameIndex(
                name: "IX_Trades_AdminAcceptId",
                table: "Trades",
                newName: "IX_Trades_AdminId");

            migrationBuilder.RenameColumn(
                name: "AdminAcceptId",
                table: "Order",
                newName: "AdminId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_AdminAcceptId",
                table: "Order",
                newName: "IX_Order_AdminId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BuyDate",
                table: "Trades",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AddColumn<DateTime>(
                name: "AdminConfirmDate",
                table: "Trades",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "VerifyType",
                table: "Trades",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<DateTime>(
                name: "AdminConfirmDate",
                table: "Order",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "VerifyType",
                table: "Order",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastChangeDate",
                table: "CurrencyChange",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AddColumn<byte>(
                name: "CurrencyChangeId",
                table: "CurrencyChange",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_AspNetUsers_AdminId",
                table: "Order",
                column: "AdminId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trades_AspNetUsers_AdminId",
                table: "Trades",
                column: "AdminId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_AspNetUsers_AdminId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Trades_AspNetUsers_AdminId",
                table: "Trades");

            migrationBuilder.DropColumn(
                name: "AdminConfirmDate",
                table: "Trades");

            migrationBuilder.DropColumn(
                name: "VerifyType",
                table: "Trades");

            migrationBuilder.DropColumn(
                name: "AdminConfirmDate",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "VerifyType",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "CurrencyChangeId",
                table: "CurrencyChange");

            migrationBuilder.RenameColumn(
                name: "AdminId",
                table: "Trades",
                newName: "AdminAcceptId");

            migrationBuilder.RenameIndex(
                name: "IX_Trades_AdminId",
                table: "Trades",
                newName: "IX_Trades_AdminAcceptId");

            migrationBuilder.RenameColumn(
                name: "AdminId",
                table: "Order",
                newName: "AdminAcceptId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_AdminId",
                table: "Order",
                newName: "IX_Order_AdminAcceptId");

            migrationBuilder.AlterColumn<string>(
                name: "BuyDate",
                table: "Trades",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "AdminAcceptDate",
                table: "Trades",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdminAcceptTime",
                table: "Trades",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdminAcceptDate",
                table: "Order",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdminAcceptTime",
                table: "Order",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastChangeDate",
                table: "CurrencyChange",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_AspNetUsers_AdminAcceptId",
                table: "Order",
                column: "AdminAcceptId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trades_AspNetUsers_AdminAcceptId",
                table: "Trades",
                column: "AdminAcceptId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
