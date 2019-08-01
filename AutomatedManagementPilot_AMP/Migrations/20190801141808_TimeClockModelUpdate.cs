using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AutomatedManagementPilot_AMP.Migrations
{
    public partial class TimeClockModelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "HoursWorked",
                table: "TimeClock",
                nullable: false,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "HoursWorked",
                table: "TimeClock",
                nullable: false,
                oldClrType: typeof(TimeSpan));
        }
    }
}
