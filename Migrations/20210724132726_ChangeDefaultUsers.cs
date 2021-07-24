using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CurrencyExchange.Migrations
{
    public partial class ChangeDefaultUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "NormalizedUserName", "UserName" },
                values: new object[] { "09150000000", "09150000000" });

            migrationBuilder.UpdateData(
                table: "AuthItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2021, 7, 24, 17, 57, 24, 387, DateTimeKind.Local).AddTicks(4887));

            migrationBuilder.UpdateData(
                table: "AuthItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2021, 7, 24, 17, 57, 24, 387, DateTimeKind.Local).AddTicks(7012));

            migrationBuilder.UpdateData(
                table: "AuthItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2021, 7, 24, 17, 57, 24, 387, DateTimeKind.Local).AddTicks(7039));

            migrationBuilder.UpdateData(
                table: "AuthItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2021, 7, 24, 17, 57, 24, 387, DateTimeKind.Local).AddTicks(7061));

            migrationBuilder.InsertData(
                table: "Currency",
                columns: new[] { "Id", "CreateDate", "CurrencyAbbreviationName", "CurrencyTypeId", "Deleted", "LastModifyDate", "PurchasePrice", "SalesPrice" },
                values: new object[] { 1, new DateTime(2021, 7, 24, 17, 57, 24, 387, DateTimeKind.Local).AddTicks(9679), "USDT", (byte)1, false, null, 0m, 0m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "NormalizedUserName", "UserName" },
                values: new object[] { "ADMIN", "Admin" });

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
        }
    }
}
