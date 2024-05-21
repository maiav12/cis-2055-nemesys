using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nemesys.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
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
					Title = table.Column<string>(nullable: true),
					DateOfReport = table.Column<DateTime>(nullable: false),
					Location = table.Column<string>(nullable: true),
					DateAndTimeSpotted = table.Column<DateTime>(nullable: false),
					TypeOfHazard = table.Column<string>(nullable: true),
					Description = table.Column<string>(nullable: true),
					Status = table.Column<string>(nullable: true),
					ReporterEmail = table.Column<string>(nullable: true),
					ReporterPhone = table.Column<string>(nullable: true),
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
					Description = table.Column<string>(nullable: true),
					DateOfAction = table.Column<DateTime>(nullable: false),
					InvestigatorEmail = table.Column<string>(nullable: true),
					InvestigatorPhone = table.Column<string>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Investigations", x => x.Id);
				});
		}


		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
