using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CurrencyExchange.Migrations
{
    public partial class AlterAuthItemAndAdminBaseClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AdminConfirmDate",
                table: "AuthUserItems",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdminDescription",
                table: "AuthUserItems",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "AdminId",
                table: "AuthUserItems",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "VerifyType",
                table: "AuthUserItems",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateIndex(
                name: "IX_AuthUserItems_AdminId",
                table: "AuthUserItems",
                column: "AdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthUserItems_AspNetUsers_AdminId",
                table: "AuthUserItems",
                column: "AdminId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthUserItems_AspNetUsers_AdminId",
                table: "AuthUserItems");

            migrationBuilder.DropIndex(
                name: "IX_AuthUserItems_AdminId",
                table: "AuthUserItems");

            migrationBuilder.DropColumn(
                name: "AdminConfirmDate",
                table: "AuthUserItems");

            migrationBuilder.DropColumn(
                name: "AdminDescription",
                table: "AuthUserItems");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "AuthUserItems");

            migrationBuilder.DropColumn(
                name: "VerifyType",
                table: "AuthUserItems");
        }
    }
}
