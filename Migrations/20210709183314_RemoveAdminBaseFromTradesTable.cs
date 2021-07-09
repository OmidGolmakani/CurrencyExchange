using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CurrencyExchange.Migrations
{
    public partial class RemoveAdminBaseFromTradesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trades_AspNetUsers_AdminId",
                table: "Trades");

            migrationBuilder.DropColumn(
                name: "AdminConfirmDate",
                table: "Trades");

            migrationBuilder.DropColumn(
                name: "AdminDescription",
                table: "Trades");

            migrationBuilder.DropColumn(
                name: "VerifyType",
                table: "Trades");

            migrationBuilder.RenameColumn(
                name: "AdminId",
                table: "Trades",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Trades_AdminId",
                table: "Trades",
                newName: "IX_Trades_ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trades_AspNetUsers_ApplicationUserId",
                table: "Trades",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trades_AspNetUsers_ApplicationUserId",
                table: "Trades");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Trades",
                newName: "AdminId");

            migrationBuilder.RenameIndex(
                name: "IX_Trades_ApplicationUserId",
                table: "Trades",
                newName: "IX_Trades_AdminId");

            migrationBuilder.AddColumn<DateTime>(
                name: "AdminConfirmDate",
                table: "Trades",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdminDescription",
                table: "Trades",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "VerifyType",
                table: "Trades",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddForeignKey(
                name: "FK_Trades_AspNetUsers_AdminId",
                table: "Trades",
                column: "AdminId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
