using Microsoft.EntityFrameworkCore.Migrations;

namespace AutomatedManagementPilot_AMP.Migrations
{
    public partial class MachineUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ShopOrder",
                keyColumn: "ShopOrderNumber",
                keyValue: 2,
                column: "MachineId",
                value: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ShopOrder",
                keyColumn: "ShopOrderNumber",
                keyValue: 2,
                column: "MachineId",
                value: 1);
        }
    }
}
