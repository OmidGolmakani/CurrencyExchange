using Microsoft.EntityFrameworkCore.Migrations;

namespace CurrencyExchange.Migrations
{
    public partial class AddDefaultUserUserRecord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Family", "LockoutEnabled", "LockoutEnd", "Name", "NationalCode", "NationalCodeConfirmed", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Tel", "TelConfirmed", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1L, 0, "b4c38214-364e-4c16-9028-a2d7448435b1", null, false, "Admin", false, null, "Admin", null, false, null, "ADMIN", "AQAAAAEAACcQAAAAENSkzWsQZKhTh+7aBZLEAWRHo8O3XC0qp1d1RFJEdvxKt3rGy+8Agyt38iYrVR5Zyw==", "09150000000", true, "JF5Z6SA4QDPB246AF2WKXR5B5QAMMN7O", null, false, false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Family", "LockoutEnabled", "LockoutEnd", "Name", "NationalCode", "NationalCodeConfirmed", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Tel", "TelConfirmed", "TwoFactorEnabled", "UserName" },
                values: new object[] { 2L, 0, "8826450d-66b7-4a10-880a-cbad5790e841", null, false, "Admin", false, null, "Admin", null, false, null, "USER1", "AQAAAAEAACcQAAAAEEntwM294Ph6cmevAy6Q4LHVkhEEQC9Tqurw0jnG+J55aF0s2Ppsz4MRbR7ker9A8w==", "09150000000", true, "UC7D6KUHK3PXCOTP2CGX6L7IMP4TFWKM", null, false, false, "User1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2L);
        }
    }
}
