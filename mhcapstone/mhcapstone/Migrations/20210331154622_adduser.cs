using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace mhcapstone.Migrations
{
    public partial class adduser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ADMIN",
                column: "ConcurrencyStamp",
                value: "1a886e4a-88ed-45bc-aee8-4e1d803969b6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "USER",
                column: "ConcurrencyStamp",
                value: "4787bcc5-7e9b-48cd-90fb-e5ba585d4aa0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ADMIN",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp", "BirthDate" },
                values: new object[] { "19c69bb7-8ea6-4466-88f7-a00d73d6b180", "6d91c608-4db5-4935-9061-b28ec662fd51", new DateTime(2021, 3, 31, 11, 46, 22, 145, DateTimeKind.Local).AddTicks(869) });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Active", "BirthDate", "FirstName", "LastName" },
                values: new object[] { "USER", 0, "6ef07245-eba9-4ac7-a53d-68facd171f4b", "User", "user@Develop.com", true, false, null, null, "USER@DEVELOP.COM", "AQAAAAEAACcQAAAAEE6fNGBLk0gWXtI+YF/euDFjEP3ASy0lEumjpTNbqgowNOzt9/dY3UByIFgSIFf1bA==", null, false, "018c259c-8c6f-43a6-a118-cd64ac0e85df", false, "user@develop.com", true, new DateTime(2021, 3, 31, 11, 46, 22, 146, DateTimeKind.Local).AddTicks(9597), "user", "user" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "USER", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "USER", "USER" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "USER");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ADMIN",
                column: "ConcurrencyStamp",
                value: "66e8cdf3-fe73-435a-a3f1-073f821c3b5b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "USER",
                column: "ConcurrencyStamp",
                value: "bb3a3eac-6eeb-4f2c-98c9-0d298ba69586");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ADMIN",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp", "BirthDate" },
                values: new object[] { "e37f8318-c534-4c5d-83dc-c7bab9b2b36b", "d66856b8-2421-4e48-a4da-dfa567a69085", new DateTime(2021, 3, 31, 11, 3, 45, 531, DateTimeKind.Local).AddTicks(6366) });
        }
    }
}
