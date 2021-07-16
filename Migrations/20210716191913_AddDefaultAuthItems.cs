using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CurrencyExchange.Migrations
{
    public partial class AddDefaultAuthItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AuthItems",
                columns: new[] { "Id", "AuthName", "AuthTypeId", "CreateDate", "Deleted", "Description", "LastModifyDate", "Order", "Required" },
                values: new object[,]
                {
                    { 1, "تصویر کاربر", (byte)4, new DateTime(2021, 7, 16, 23, 49, 12, 262, DateTimeKind.Local).AddTicks(3971), false, "با استفاده از این احراز تصویر کاربر احراز می گردد", null, (byte)1, true },
                    { 2, "کارت بانکی", (byte)3, new DateTime(2021, 7, 16, 23, 49, 12, 266, DateTimeKind.Local).AddTicks(8121), false, "احراز کارت بانکی", null, (byte)2, true },
                    { 3, "کد ملی", (byte)4, new DateTime(2021, 7, 16, 23, 49, 12, 266, DateTimeKind.Local).AddTicks(8172), false, "از طریق این احراز اطلاعات هویتی کاربر از طریق کارت ملی احراز می گردد", null, (byte)3, true },
                    { 4, "تلفن ثابت", (byte)6, new DateTime(2021, 7, 16, 23, 49, 12, 266, DateTimeKind.Local).AddTicks(8179), false, "احراز تلفن ثابت", null, (byte)4, true }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AuthItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AuthItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AuthItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AuthItems",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
