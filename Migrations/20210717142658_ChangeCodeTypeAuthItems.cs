using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CurrencyExchange.Migrations
{
    public partial class ChangeCodeTypeAuthItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "AuthTypeId", "CreateDate" },
                values: new object[] { (byte)2, new DateTime(2021, 7, 17, 18, 56, 56, 282, DateTimeKind.Local).AddTicks(8354) });

            migrationBuilder.UpdateData(
                table: "AuthItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2021, 7, 17, 18, 56, 56, 282, DateTimeKind.Local).AddTicks(8363));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AuthItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2021, 7, 16, 23, 49, 12, 262, DateTimeKind.Local).AddTicks(3971));

            migrationBuilder.UpdateData(
                table: "AuthItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2021, 7, 16, 23, 49, 12, 266, DateTimeKind.Local).AddTicks(8121));

            migrationBuilder.UpdateData(
                table: "AuthItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AuthTypeId", "CreateDate" },
                values: new object[] { (byte)4, new DateTime(2021, 7, 16, 23, 49, 12, 266, DateTimeKind.Local).AddTicks(8172) });

            migrationBuilder.UpdateData(
                table: "AuthItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2021, 7, 16, 23, 49, 12, 266, DateTimeKind.Local).AddTicks(8179));
        }
    }
}
