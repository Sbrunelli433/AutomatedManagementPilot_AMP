using Microsoft.EntityFrameworkCore.Migrations;

namespace AutomatedManagementPilot_AMP.Migrations
{
    public partial class UpdateTCModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Summary",
                table: "TimeClock",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Summary",
                table: "TimeClock");
        }
    }
}
