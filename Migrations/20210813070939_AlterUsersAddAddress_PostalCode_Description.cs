using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CurrencyExchange.Migrations
{
    public partial class AlterUsersAddAddress_PostalCode_Description : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AspNetUsers",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "AspNetUsers",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "AspNetUsers");

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
    }
}
