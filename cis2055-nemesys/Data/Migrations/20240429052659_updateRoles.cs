using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nemesys.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d234f58e-7373-4ee5-98f0-c17892784b05", "27332294-dbf7-4e17-ae9a-ea9ee1577b1b" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "27332294-dbf7-4e17-ae9a-ea9ee1577b1b");

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "NearMissReports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Investigations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "471ddd6f-32ea-4e17-9d62-261fa6f87a84", 0, "f818d6cc-37e8-46cf-aee2-de2c8383a204", "admin@mail.com", true, false, null, "ADMIN@MAIL.COM", "ADMIN@MAIL.COM", "AQAAAAIAAYagAAAAEAJwaeG5phlLUy7Wkz66N6ZhloIu4mycUP6qlxhaPmx4Wk8NcqlHe3VBL9b1D5/PXA==", "", false, "c1684eac-7ef5-4ac2-a1be-a85e31f1b2fd", false, "admin@mail.com" });

            migrationBuilder.UpdateData(
                table: "Investigations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateOfAction", "Role" },
                values: new object[] { new DateTime(2024, 4, 29, 5, 26, 58, 117, DateTimeKind.Utc).AddTicks(1110), 0 });

            migrationBuilder.UpdateData(
                table: "NearMissReports",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateAndTimeSpotted", "DateOfReport", "Role" },
                values: new object[] { new DateTime(2024, 4, 29, 5, 26, 58, 117, DateTimeKind.Utc).AddTicks(1058), new DateTime(2024, 4, 29, 5, 26, 58, 117, DateTimeKind.Utc).AddTicks(1052), 0 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d234f58e-7373-4ee5-98f0-c17892784b05", "471ddd6f-32ea-4e17-9d62-261fa6f87a84" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d234f58e-7373-4ee5-98f0-c17892784b05", "471ddd6f-32ea-4e17-9d62-261fa6f87a84" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "471ddd6f-32ea-4e17-9d62-261fa6f87a84");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "NearMissReports");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Investigations");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "27332294-dbf7-4e17-ae9a-ea9ee1577b1b", 0, "d93244a4-993f-440e-83a7-e5feaf797023", "admin@mail.com", true, false, null, "ADMIN@MAIL.COM", "ADMIN@MAIL.COM", "AQAAAAIAAYagAAAAEFWEqhcyU4SXO+tG7xwR82b6Pp1e/xUgaJGmyRmY9MoDDRkjPyXePwBbUZpW8+2u8g==", "", false, "1ec4659e-1736-430c-9af9-e26006dba26e", false, "admin@mail.com" });

            migrationBuilder.UpdateData(
                table: "Investigations",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfAction",
                value: new DateTime(2024, 4, 24, 10, 13, 11, 715, DateTimeKind.Utc).AddTicks(9320));

            migrationBuilder.UpdateData(
                table: "NearMissReports",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateAndTimeSpotted", "DateOfReport" },
                values: new object[] { new DateTime(2024, 4, 24, 10, 13, 11, 715, DateTimeKind.Utc).AddTicks(9260), new DateTime(2024, 4, 24, 10, 13, 11, 715, DateTimeKind.Utc).AddTicks(9255) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d234f58e-7373-4ee5-98f0-c17892784b05", "27332294-dbf7-4e17-ae9a-ea9ee1577b1b" });
        }
    }
}
