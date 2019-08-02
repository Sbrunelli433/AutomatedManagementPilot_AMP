using Microsoft.EntityFrameworkCore.Migrations;

namespace AutomatedManagementPilot_AMP.Migrations
{
    public partial class updateTimeClock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeClock_ShopOrder_ShopOrderNumber",
                table: "TimeClock");

            migrationBuilder.AlterColumn<int>(
                name: "ShopOrderNumber",
                table: "TimeClock",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_TimeClock_ShopOrder_ShopOrderNumber",
                table: "TimeClock",
                column: "ShopOrderNumber",
                principalTable: "ShopOrder",
                principalColumn: "ShopOrderNumber",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeClock_ShopOrder_ShopOrderNumber",
                table: "TimeClock");

            migrationBuilder.AlterColumn<int>(
                name: "ShopOrderNumber",
                table: "TimeClock",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeClock_ShopOrder_ShopOrderNumber",
                table: "TimeClock",
                column: "ShopOrderNumber",
                principalTable: "ShopOrder",
                principalColumn: "ShopOrderNumber",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
