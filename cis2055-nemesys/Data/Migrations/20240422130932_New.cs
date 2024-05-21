using Microsoft.EntityFrameworkCore.Migrations;

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nemesys.Data.Migrations
{
    /// <inheritdoc />
    public partial class New : Migration
    {
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "NearMissReports",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Title = table.Column<string>(nullable:false),
					DateOfReport = table.Column<DateTime>(nullable: false),
					Location = table.Column<string>(nullable: false),
					DateAndTimeSpotted = table.Column<DateTime>(nullable: false),
					TypeOfHazard = table.Column<string>(nullable: false),
					Description = table.Column<string>(nullable: false),
					Status = table.Column<string>(nullable: false),
					ReporterEmail = table.Column<string>(nullable:false),
					ReporterPhone = table.Column<string>(nullable: false),
					OptionalPhoto = table.Column<string>(nullable: true),
					Upvotes = table.Column<int>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_NearMissReports", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Investigations",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					NearMissReportId = table.Column<int>(nullable: false),
					Description = table.Column<string>(nullable: false),
					DateOfAction = table.Column<DateTime>(nullable: false),
					InvestigatorEmail = table.Column<string>(nullable: false),
					InvestigatorPhone = table.Column<string>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Investigations", x => x.Id);
				});
            migrationBuilder.AddColumn<string>(
    name: "UserId",
    table: "NearMissReports",
    nullable: true);

        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Investigations",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfAction",
                value: new DateTime(2024, 4, 22, 12, 54, 31, 544, DateTimeKind.Utc).AddTicks(8245));

            migrationBuilder.UpdateData(
                table: "NearMissReports",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateAndTimeSpotted", "DateOfReport", "OptionalPhoto" },
                values: new object[] { new DateTime(2024, 4, 22, 12, 54, 31, 544, DateTimeKind.Utc).AddTicks(8033), new DateTime(2024, 4, 22, 12, 54, 31, 544, DateTimeKind.Utc).AddTicks(8029), "example.jpg" });
        }
    }
}
