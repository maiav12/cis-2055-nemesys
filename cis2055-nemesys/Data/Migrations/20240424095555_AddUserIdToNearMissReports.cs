using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nemesys.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUserIdToNearMissReports : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d234f58e-7373-4ee5-98f0-c17892784b05", "48e6a5a0-edb8-4d3a-b936-7889d81d5338" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "48e6a5a0-edb8-4d3a-b936-7889d81d5338");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "NearMissReports",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

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
                columns: new[] { "DateAndTimeSpotted", "DateOfReport", "UserId" },
                values: new object[] { new DateTime(2024, 4, 24, 9, 55, 52, 800, DateTimeKind.Utc).AddTicks(976), new DateTime(2024, 4, 24, 9, 55, 52, 800, DateTimeKind.Utc).AddTicks(969), "d234f58e-7373-4ee5-98f0-c17892784b05" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d234f58e-7373-4ee5-98f0-c17892784b05", "28ea07ca-d3d0-49ae-a673-2df9825311f7" });

            migrationBuilder.CreateIndex(
                name: "IX_NearMissReports_UserId",
                table: "NearMissReports",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_NearMissReports_AspNetUsers_UserId",
                table: "NearMissReports",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NearMissReports_AspNetUsers_UserId",
                table: "NearMissReports");

            migrationBuilder.DropIndex(
                name: "IX_NearMissReports_UserId",
                table: "NearMissReports");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d234f58e-7373-4ee5-98f0-c17892784b05", "28ea07ca-d3d0-49ae-a673-2df9825311f7" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "28ea07ca-d3d0-49ae-a673-2df9825311f7");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "NearMissReports");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "48e6a5a0-edb8-4d3a-b936-7889d81d5338", 0, "aabb2709-a40f-4861-8d4c-e68af758fac8", "admin@mail.com", true, false, null, "ADMIN@MAIL.COM", "ADMIN@MAIL.COM", "AQAAAAIAAYagAAAAELCXeUVncNinJnvfjJacgy5dsbixgQcrkHzwomJSw1REvgR9Wu5UJrR/9CxVEbZZCw==", "", false, "b0330f5d-3cb4-414a-bfcd-d542a757ac06", false, "admin@mail.com" });

            migrationBuilder.UpdateData(
                table: "Investigations",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfAction",
                value: new DateTime(2024, 4, 24, 6, 52, 35, 163, DateTimeKind.Utc).AddTicks(4081));

            migrationBuilder.UpdateData(
                table: "NearMissReports",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateAndTimeSpotted", "DateOfReport" },
                values: new object[] { new DateTime(2024, 4, 24, 6, 52, 35, 163, DateTimeKind.Utc).AddTicks(3711), new DateTime(2024, 4, 24, 6, 52, 35, 163, DateTimeKind.Utc).AddTicks(3704) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d234f58e-7373-4ee5-98f0-c17892784b05", "48e6a5a0-edb8-4d3a-b936-7889d81d5338" });
        }
    }
}
