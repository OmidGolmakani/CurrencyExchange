using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CurrencyExchange.Migrations
{
    public partial class RemoveAuthUserIX : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AuthUserItems_UserId_AuthItemId_Deleted",
                table: "AuthUserItems");

            migrationBuilder.UpdateData(
                table: "AuthItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2021, 7, 18, 23, 9, 13, 266, DateTimeKind.Local).AddTicks(8751));

            migrationBuilder.UpdateData(
                table: "AuthItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2021, 7, 18, 23, 9, 13, 271, DateTimeKind.Local).AddTicks(8994));

            migrationBuilder.UpdateData(
                table: "AuthItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2021, 7, 18, 23, 9, 13, 271, DateTimeKind.Local).AddTicks(9054));

            migrationBuilder.UpdateData(
                table: "AuthItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2021, 7, 18, 23, 9, 13, 271, DateTimeKind.Local).AddTicks(9062));

            migrationBuilder.CreateIndex(
                name: "IX_AuthUserItems_UserId",
                table: "AuthUserItems",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AuthUserItems_UserId",
                table: "AuthUserItems");

            migrationBuilder.UpdateData(
                table: "AuthItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2021, 7, 17, 18, 56, 56, 276, DateTimeKind.Local).AddTicks(3276));

            migrationBuilder.UpdateData(
                table: "AuthItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2021, 7, 17, 18, 56, 56, 282, DateTimeKind.Local).AddTicks(8272));

            migrationBuilder.UpdateData(
                table: "AuthItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2021, 7, 17, 18, 56, 56, 282, DateTimeKind.Local).AddTicks(8354));

            migrationBuilder.UpdateData(
                table: "AuthItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2021, 7, 17, 18, 56, 56, 282, DateTimeKind.Local).AddTicks(8363));

            migrationBuilder.CreateIndex(
                name: "IX_AuthUserItems_UserId_AuthItemId_Deleted",
                table: "AuthUserItems",
                columns: new[] { "UserId", "AuthItemId", "Deleted" },
                unique: true);
        }
    }
}
