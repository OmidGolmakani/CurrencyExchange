using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CurrencyExchange.Migrations
{
    public partial class AddIssueTrackingColumnToOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IssueTracking",
                table: "Order",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AuthItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2021, 8, 1, 17, 19, 45, 504, DateTimeKind.Local).AddTicks(2));

            migrationBuilder.UpdateData(
                table: "AuthItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2021, 8, 1, 17, 19, 45, 504, DateTimeKind.Local).AddTicks(4066));

            migrationBuilder.UpdateData(
                table: "AuthItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2021, 8, 1, 17, 19, 45, 504, DateTimeKind.Local).AddTicks(4120));

            migrationBuilder.UpdateData(
                table: "AuthItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2021, 8, 1, 17, 19, 45, 504, DateTimeKind.Local).AddTicks(4155));

            migrationBuilder.UpdateData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2021, 8, 1, 17, 19, 45, 504, DateTimeKind.Local).AddTicks(8373));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IssueTracking",
                table: "Order");

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

            migrationBuilder.UpdateData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2021, 7, 24, 17, 57, 24, 387, DateTimeKind.Local).AddTicks(9679));
        }
    }
}
