using Microsoft.EntityFrameworkCore.Migrations;

namespace AutomatedManagementPilot_AMP.Migrations
{
    public partial class JobsModelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TargetTaskId",
                table: "Links",
                newName: "TargetJobId");

            migrationBuilder.RenameColumn(
                name: "SourceTaskId",
                table: "Links",
                newName: "SourceJobId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TargetJobId",
                table: "Links",
                newName: "TargetTaskId");

            migrationBuilder.RenameColumn(
                name: "SourceJobId",
                table: "Links",
                newName: "SourceTaskId");
        }
    }
}
