using Microsoft.EntityFrameworkCore.Migrations;

namespace AutomatedManagementPilot_AMP.Migrations
{
    public partial class modelUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "Jobs",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "Jobs");
        }
    }
}
