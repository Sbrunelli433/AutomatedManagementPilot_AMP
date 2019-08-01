using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AutomatedManagementPilot_AMP.Migrations
{
    public partial class UpdateTCSModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TimeClockSummary",
                columns: table => new
                {
                    TimeClockSumId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TimeClockId = table.Column<int>(nullable: false),
                    Summary = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeClockSummary", x => x.TimeClockSumId);
                    table.ForeignKey(
                        name: "FK_TimeClockSummary_TimeClock_TimeClockId",
                        column: x => x.TimeClockId,
                        principalTable: "TimeClock",
                        principalColumn: "TimeClockId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TimeClockSummary_TimeClockId",
                table: "TimeClockSummary",
                column: "TimeClockId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimeClockSummary");
        }
    }
}
