using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AutomatedManagementPilot_AMP.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(nullable: true),
                    SourceJobId = table.Column<int>(nullable: false),
                    TargetJobId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Machine",
                columns: table => new
                {
                    MachineId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MachineNumber = table.Column<string>(nullable: true),
                    CycleTime = table.Column<decimal>(nullable: false),
                    Utilization = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machine", x => x.MachineId);
                });

            migrationBuilder.CreateTable(
                name: "Operation",
                columns: table => new
                {
                    OperationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OperationName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operation", x => x.OperationId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(nullable: true),
                    ApplicationId = table.Column<string>(nullable: true),
                    PayRoll = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employee_AspNetUsers_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Manager",
                columns: table => new
                {
                    ManagerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(nullable: true),
                    ApplicationId = table.Column<string>(nullable: true),
                    PayRoll = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manager", x => x.ManagerId);
                    table.ForeignKey(
                        name: "FK_Manager_AspNetUsers_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Supervisor",
                columns: table => new
                {
                    SupervisorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(nullable: true),
                    ApplicationId = table.Column<string>(nullable: true),
                    RoleId = table.Column<string>(nullable: true),
                    PayRoll = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supervisor", x => x.SupervisorId);
                    table.ForeignKey(
                        name: "FK_Supervisor_AspNetUsers_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Supervisor_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(nullable: true),
                    Customer = table.Column<string>(nullable: true),
                    Part = table.Column<string>(nullable: true),
                    OrderQuantity = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    Duration = table.Column<int>(nullable: false),
                    JobTimeSpan = table.Column<TimeSpan>(nullable: false),
                    Progress = table.Column<decimal>(nullable: false),
                    ParentId = table.Column<int>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    SortOrder = table.Column<int>(nullable: false),
                    MachineId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jobs_Machine_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machine",
                        principalColumn: "MachineId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShopOrder",
                columns: table => new
                {
                    ShopOrderNumber = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Customer = table.Column<string>(nullable: true),
                    PartNumber = table.Column<int>(nullable: false),
                    PartName = table.Column<string>(nullable: true),
                    OrderQuantity = table.Column<int>(nullable: false),
                    OrderRecDate = table.Column<DateTime>(maxLength: 250000, nullable: false),
                    OrderDueDate = table.Column<DateTime>(nullable: false),
                    MachineId = table.Column<int>(nullable: true),
                    ScheduleStartTime = table.Column<DateTime>(nullable: false),
                    ScheduleEndTime = table.Column<DateTime>(nullable: false),
                    OperationSetUp = table.Column<string>(nullable: true),
                    OperationSetUpHours = table.Column<TimeSpan>(nullable: false),
                    OperationProduction = table.Column<string>(nullable: true),
                    OperationProductionHours = table.Column<TimeSpan>(nullable: false),
                    OperationTearDown = table.Column<string>(nullable: true),
                    OperationTearDownHours = table.Column<TimeSpan>(nullable: false),
                    GrossProductionRate = table.Column<decimal>(nullable: false),
                    NetProductionRate = table.Column<decimal>(nullable: false),
                    Profitability = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopOrder", x => x.ShopOrderNumber);
                    table.ForeignKey(
                        name: "FK_ShopOrder_Machine_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machine",
                        principalColumn: "MachineId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JobCard",
                columns: table => new
                {
                    JobCardId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OperationClockIn = table.Column<DateTime>(nullable: false),
                    OperationClockOut = table.Column<DateTime>(nullable: false),
                    OperationTotal = table.Column<TimeSpan>(nullable: false),
                    PartsMade = table.Column<int>(nullable: false),
                    Summary = table.Column<string>(nullable: true),
                    EmployeeId = table.Column<int>(nullable: false),
                    ShopOrderNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCard", x => x.JobCardId);
                    table.ForeignKey(
                        name: "FK_JobCard_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobCard_ShopOrder_ShopOrderNumber",
                        column: x => x.ShopOrderNumber,
                        principalTable: "ShopOrder",
                        principalColumn: "ShopOrderNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimeClock",
                columns: table => new
                {
                    TimeClockId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClockIn = table.Column<DateTime>(nullable: false),
                    ClockOut = table.Column<DateTime>(nullable: false),
                    HoursWorked = table.Column<TimeSpan>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    ShopOrderNumber = table.Column<int>(nullable: true),
                    Summary = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeClock", x => x.TimeClockId);
                    table.ForeignKey(
                        name: "FK_TimeClock_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimeClock_ShopOrder_ShopOrderNumber",
                        column: x => x.ShopOrderNumber,
                        principalTable: "ShopOrder",
                        principalColumn: "ShopOrderNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Machine",
                columns: new[] { "MachineId", "CycleTime", "MachineNumber", "Utilization" },
                values: new object[,]
                {
                    { 1, 0m, "01", 0m },
                    { 2, 0m, "02", 0m }
                });

            migrationBuilder.InsertData(
                table: "ShopOrder",
                columns: new[] { "ShopOrderNumber", "Customer", "GrossProductionRate", "MachineId", "NetProductionRate", "OperationProduction", "OperationProductionHours", "OperationSetUp", "OperationSetUpHours", "OperationTearDown", "OperationTearDownHours", "OrderDueDate", "OrderQuantity", "OrderRecDate", "PartName", "PartNumber", "Profitability", "ScheduleEndTime", "ScheduleStartTime" },
                values: new object[,]
                {
                    { 1, "Terrill Inc.", 0m, null, 0m, "Production", new TimeSpan(0, 2, 30, 0, 0), "Set Up", new TimeSpan(0, 0, 30, 0, 0), "Tear Down", new TimeSpan(0, 0, 45, 0, 0), new DateTime(2019, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 10000, new DateTime(2019, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Widget", 12345, 0m, new DateTime(2019, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Bradley Industries.", 0m, null, 0m, null, new TimeSpan(0, 5, 30, 0, 0), null, new TimeSpan(0, 1, 0, 0, 0), null, new TimeSpan(0, 1, 30, 0, 0), new DateTime(2019, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 200000, new DateTime(2019, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Clip", 2, 0m, new DateTime(2019, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "ACME Solutions", 0m, null, 0m, null, new TimeSpan(0, 2, 30, 0, 0), null, new TimeSpan(0, 0, 30, 0, 0), null, new TimeSpan(0, 0, 45, 0, 0), new DateTime(2019, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 15000, new DateTime(2019, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Washer", 321, 0m, new DateTime(2019, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_ApplicationId",
                table: "Employee",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_JobCard_EmployeeId",
                table: "JobCard",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_JobCard_ShopOrderNumber",
                table: "JobCard",
                column: "ShopOrderNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_MachineId",
                table: "Jobs",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_Manager_ApplicationId",
                table: "Manager",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopOrder_MachineId",
                table: "ShopOrder",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_Supervisor_ApplicationId",
                table: "Supervisor",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Supervisor_RoleId",
                table: "Supervisor",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeClock_EmployeeId",
                table: "TimeClock",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeClock_ShopOrderNumber",
                table: "TimeClock",
                column: "ShopOrderNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "JobCard");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropTable(
                name: "Manager");

            migrationBuilder.DropTable(
                name: "Operation");

            migrationBuilder.DropTable(
                name: "Supervisor");

            migrationBuilder.DropTable(
                name: "TimeClock");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "ShopOrder");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Machine");
        }
    }
}
