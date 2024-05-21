using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nemesys.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNearMissReportTitleColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d234f58e-7373-4ee5-98f0-c17892784b05", "28ea07ca-d3d0-49ae-a673-2df9825311f7" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "28ea07ca-d3d0-49ae-a673-2df9825311f7");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d234f58e-7373-4ee5-98f0-c17892784b05", "27332294-dbf7-4e17-ae9a-ea9ee1577b1b" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "27332294-dbf7-4e17-ae9a-ea9ee1577b1b");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "28ea07ca-d3d0-49ae-a673-2df9825311f7", 0, "bc7d3bc2-ce31-4ab7-b0bf-c43341e8bb8a", "admin@mail.com", true, false, null, "ADMIN@MAIL.COM", "ADMIN@MAIL.COM", "AQAAAAIAAYagAAAAEHKzkM8qzCMBYn6XDXiDymM1+GZc3PfBWGH2IZ6CNSI4ZXJMvKGbfPwlvmuNRWo4bw==", "", false, "560e6936-0fa4-455a-9f66-131ce0b8cbf0", false, "admin@mail.com" });

            migrationBuilder.UpdateData(
                table: "Investigations",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfAction",
                value: new DateTime(2024, 4, 24, 9, 55, 52, 800, DateTimeKind.Utc).AddTicks(1065));

            migrationBuilder.UpdateData(
                table: "NearMissReports",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateAndTimeSpotted", "DateOfReport" },
                values: new object[] { new DateTime(2024, 4, 24, 9, 55, 52, 800, DateTimeKind.Utc).AddTicks(976), new DateTime(2024, 4, 24, 9, 55, 52, 800, DateTimeKind.Utc).AddTicks(969) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d234f58e-7373-4ee5-98f0-c17892784b05", "28ea07ca-d3d0-49ae-a673-2df9825311f7" });
        }
    }
}
