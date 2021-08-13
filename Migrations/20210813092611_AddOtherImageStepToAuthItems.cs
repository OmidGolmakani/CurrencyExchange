using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CurrencyExchange.Migrations
{
    public partial class AddOtherImageStepToAuthItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AuthItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2021, 8, 13, 13, 56, 10, 8, DateTimeKind.Local).AddTicks(232));

            migrationBuilder.UpdateData(
                table: "AuthItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2021, 8, 13, 13, 56, 10, 8, DateTimeKind.Local).AddTicks(1908));

            migrationBuilder.UpdateData(
                table: "AuthItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2021, 8, 13, 13, 56, 10, 8, DateTimeKind.Local).AddTicks(1930));

            migrationBuilder.UpdateData(
                table: "AuthItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2021, 8, 13, 13, 56, 10, 8, DateTimeKind.Local).AddTicks(1945));

            migrationBuilder.InsertData(
                table: "AuthItems",
                columns: new[] { "Id", "AuthName", "AuthTypeId", "CreateDate", "Deleted", "Description", "LastModifyDate", "Order", "Required" },
                values: new object[] { 5, "شماره شبا", (byte)7, new DateTime(2021, 8, 13, 13, 56, 10, 8, DateTimeKind.Local).AddTicks(1960), false, "احراز شماره شبا", null, (byte)5, true });

            migrationBuilder.UpdateData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2021, 8, 13, 13, 56, 10, 8, DateTimeKind.Local).AddTicks(3523));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AuthItems",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "AuthItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2021, 8, 13, 11, 39, 37, 894, DateTimeKind.Local).AddTicks(3494));

            migrationBuilder.UpdateData(
                table: "AuthItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2021, 8, 13, 11, 39, 37, 894, DateTimeKind.Local).AddTicks(5317));

            migrationBuilder.UpdateData(
                table: "AuthItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2021, 8, 13, 11, 39, 37, 894, DateTimeKind.Local).AddTicks(5342));

            migrationBuilder.UpdateData(
                table: "AuthItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2021, 8, 13, 11, 39, 37, 894, DateTimeKind.Local).AddTicks(5360));

            migrationBuilder.UpdateData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2021, 8, 13, 11, 39, 37, 894, DateTimeKind.Local).AddTicks(7080));
        }
    }
}
